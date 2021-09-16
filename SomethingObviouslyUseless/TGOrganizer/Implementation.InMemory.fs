module TGOrganizer.Implementation.InMemory

open System
open System.Collections.Concurrent
open System.Collections.Generic
open System.Threading.Channels
open System.Threading.Tasks
open En3Tho.FSharp.Extensions.Core
open En3Tho.FSharp.Validation
open En3Tho.FSharp.Validation.CommonTypes
open Microsoft.Extensions.Logging
open TGOrganizer.Contracts
open FSharp.Control.Tasks
open TGOrganizer.Primitives

type InMemoryBusChannel<'a>(consumers: seq<IEventConsumer<'a>>) =
    let channel = Channel.CreateUnbounded<'a>()
    do
        Task.Run(fun() -> unitTask {
            while true do
                let! message = channel.Reader.ReadAsync()
                for consumer in consumers do
                    do! consumer.Consume message
        }) |> ignore

    interface IEventBus<'a> with
        member _.Publish event = vtask { do! channel.Writer.WriteAsync event }

type InMemoryTodoTaskStorage(logger: ILogger<InMemoryTodoTaskStorage>) =
    let userItemStorage = ConcurrentDictionary<_, ConcurrentDictionary<_,_>>()

    let getUsersItemsStorage (user: User) =
        match userItemStorage.TryGetValue user.Id with
        | true, usersItemsStorage -> usersItemsStorage
        | _ ->
            userItemStorage.TryAdd (user.Id, ConcurrentDictionary()) |> ignore
            userItemStorage.[user.Id]

    let createTodoItem (user: User) (command: CreateTodoTaskCommand) =
        let usersItems = getUsersItemsStorage user
        let todoItem = {
            TodoTask.Id = NonEmptyGuid.Make (Guid.NewGuid())
            Body = command.Body
            Schedule = command.Schedule
            User = user
            State = InProgress
        }
        usersItems.[todoItem.Id] <- todoItem
        Ok todoItem
        |> Task.FromResult

    let editTodoItem (user: User) (todoItem: TodoTask) =
        let usersItems = getUsersItemsStorage user
        match usersItems.TryGetValue todoItem.Id with
        | true, oldItem ->
            usersItems.[todoItem.Id] <- todoItem
            Ok oldItem
        | _ -> Error (TodoTaskDoesNotExist todoItem)
        |> Task.FromResult

    let removeTodoItem (user: User) (todoItem: TodoTask) =
        let usersItems = getUsersItemsStorage user
        match usersItems.TryRemove(KeyValuePair(todoItem.Id, todoItem)) with
        | true -> Ok ()
        | false -> Error (TodoTaskDoesNotExist todoItem)
        |> Task.FromResult

    let getItems (user: User) =
        let usersItemsStorage = getUsersItemsStorage user
        usersItemsStorage.Values
        |> Seq.toArray
        |> NonNullValue.Make
        |> Ok
        |> Task.FromResult

    interface ITodoTaskStorage with
        member this.CreateTodoItem(user, command) = createTodoItem user command
        member this.EditTodoItem(user, item) = editTodoItem user item
        member this.RemoveTodoItem(user, item) = removeTodoItem user item
        member this.GetTodoItems(user) = getItems user

type TodoItemEditorService(logger: ILogger<TodoItemEditorService>, storage: ITodoTaskStorage, bus: IEventBus<_>) =

    let createTodoItem user command = vtask {
        logger.LogTrace("Creating todo item {item} for user {user}", command, user)
        let! createResult = storage.CreateTodoItem(user, command)
        match createResult with
        | Ok todoItem ->
            do! bus.Publish (TodoItemCreated todoItem)
        | Error exn ->
            logger.LogError("Unable to create todo item {item} for user {user}: {exn}", command, user, exn)
        return createResult
    }

    let editTodoItem user newTodoItem = vtask {
        logger.LogTrace("Editing todo item {item} for user {user}", newTodoItem, user)
        let! createResult = storage.EditTodoItem(user, newTodoItem)
        match createResult with
        | Ok oldItem ->
            do! bus.Publish (TodoItemEdited(OldItem = oldItem, NewItem = newTodoItem))
        | Error exn ->
            logger.LogError("Unable to edit todo item {item} for user {user}: {exn}", newTodoItem, user, exn)
        return createResult
    }

    let removeTodoItem user todoItem = vtask {
        logger.LogTrace("Removing todo item {item} for user {user}", todoItem, user)
        let! createResult = storage.RemoveTodoItem(user, todoItem)
        match createResult with
        | Ok _ ->
            do! bus.Publish (TodoItemRemoved todoItem)
        | Error exn ->
            logger.LogError("Unable to remove todo item {item} for user {user}: {exn}", todoItem, user, exn)
        return createResult
    }

    interface ITodoItemEditorService with
        member this.CreateTodoItem(user, command) = createTodoItem user command
        member this.EditTodoItem(user, item) = editTodoItem user item
        member this.GetTodoItems(user) = ValueTask<_>(task = storage.GetTodoItems user)
        member this.RemoveTodoItem(user, item) = removeTodoItem user item

type InMemoryTodoItemSchedulingService(logger: ILogger<InMemoryTodoItemSchedulingService>, bus: IEventBus<_>, notificationsService: ITodoTaskNotificationsService) =
    let timeSlots = SortedDictionary()

    let getScheduledItems time =
        match timeSlots.TryGetValue time with
        | true, todoItems ->
            todoItems
        | _ ->
            let todoItems: TodoTask NonEmptyArray = [||] |> NonEmptyArray.Make
            timeSlots.[time] <- todoItems
            todoItems

    let getItemSlot item =
        timeSlots
        |> Seq.tryFind ^ fun (Kvp (_, NonEmptyArray todoItems)) ->
            todoItems |> Seq.exists ^ fun { TodoTask.Id = guid } ->
                guid = item.Id

    let scheduleTodoItemInternal (time: ValidDateTimeOffset) (item: TodoTask) = vtask {
        if !time < DateTimeOffset.Now then
            return Error (TodoTaskScheduleDateAlreadyPassed item)
        else
            return! lockVTask timeSlots ^ fun() -> vtask {
                let todoItems = getScheduledItems time
                match !todoItems |> Array.tryFind ^ fun { TodoTask.Id = guid } -> guid = item.Id with
                | Some todoItem ->
                    return Error (TodoTaskIsAlreadyScheduled todoItem)
                | None ->
                    let newItems = todoItems.MapMake ^ Array.append [| item |]
                    timeSlots.[time] <- newItems
                    return Ok()
            }
    }

    let scheduleTodoItem time item = vtask {
        let! result = scheduleTodoItemInternal time item
        match result with
        | Ok _ ->
            do! bus.Publish (TodoItemScheduled (time, item))
        | _ -> ()
        return result
    }

    let dropSchedulingInternal item = vtask {
        let scheduledItemsSlot = getItemSlot item
        match scheduledItemsSlot with
        | Some (Kvp (time, todoItems)) ->
            match todoItems.MapTry ^ Array.except [| item |] with
            | Ok values ->
                timeSlots.[time] <- values
            | _ ->
                timeSlots.Remove(time) |> ignore
            return Ok ()
        | _ ->
            return Error (TodoTaskDoesNotExist item)
    }

    let dropScheduling item = vtask {
        return! lockVTask timeSlots ^ fun () -> vtask {
            let! result = dropSchedulingInternal item
            match result with
            | Ok _ ->
                do! bus.Publish (TodoItemDropped item)
            | _ -> ()
            return result
        }
    }

    let rescheduleTodoItem (newTime: ValidDateTimeOffset) (item: TodoTask) = vtask {
        return! lockVTask timeSlots ^ fun() -> vtask {
            match! dropSchedulingInternal item with
            | Ok _ ->
                let! result = scheduleTodoItemInternal newTime item
                match result with
                | Ok _ ->
                    do! bus.Publish (TodoItemRescheduled(newTime, item))
                | _ ->()
                return result
            | _ as err ->
                return err
        }
    }

    let fireTodoItemEvents (fireTime: ValidDateTimeOffset) = vtask {
        do! lockVTask timeSlots ^ fun () -> vtask {
            let timeSlotsToProcess =
                timeSlots
                |> Seq.takeWhile ^ fun (Kvp (slotTime, _)) -> slotTime <= fireTime
                |> Seq.toArray
            for Kvp (slotTime, slotItems) in timeSlotsToProcess do
                let todoItemsToRemove = ResizeArray()
                for todoItem in !slotItems do
                    match! notificationsService.SendNotification { Time = slotTime; Item = todoItem} with
                    | Ok _ ->
                        todoItemsToRemove.Add(todoItem)
                    | Error exn ->
                        logger.LogError("Error when trying to send notification: {exn}", exn)
                if todoItemsToRemove.Count = slotItems.Value.Length then
                    timeSlots.Remove(slotTime) |> ignore
                else
                    match slotItems.MapTry ^ Array.except todoItemsToRemove with
                    | Ok newItems ->
                        timeSlots.[slotTime] <- newItems
                    | _ ->
                        timeSlots.Remove(slotTime) |> ignore
        }
    }

    do
        unitTask {
            while true do
                do! Task.Delay 1000
                let time = DateTimeOffset.Now |> ValidDateTimeOffset.Make
                do! fireTodoItemEvents time
        } |> ignore

    interface ITodoTaskSchedulingService with
        member this.DropScheduling(item) = dropScheduling item
        member this.Reschedule(newTime, item) = rescheduleTodoItem newTime item
        member this.Schedule(time, item) = scheduleTodoItem time item

type InMemoryEventBus<'a>(consumers: IEventConsumer<'a> seq) =
    let consumers = consumers |> Seq.toArray
    let channels = consumers |> Array.map ^ fun _ -> Channel.CreateUnbounded()
    do
        (channels, consumers) ||> Array.iter2 ^ fun channel consumer -> ignore (task {
            while true do
                let! event = channel.Reader.ReadAsync()
                do! consumer.Consume event
        })
    interface IEventBus<'a> with
        member this.Publish(value) = vtask {
            for channel in channels do
                do! channel.Writer.WriteAsync(value)
        }
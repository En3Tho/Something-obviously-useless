namespace TGOrganizer.Implementation.Telegram.InMemory.Services

open System
open System.Collections.Concurrent
open System.Threading.Tasks
open En3Tho.FSharp.Validation.CommonValidatedTypes
open Microsoft.Extensions.Logging
open TGOrganizer.Contracts
open TGOrganizer.Contracts.Telegram
open FSharp.Control.Tasks

type InMemoryTelegramTodoTaskNotificationsService(logger: ILogger<InMemoryTelegramTodoTaskNotificationsService>,
                                                  telegramUserRepository: ITelegramUserStorage,
                                                  bus: IEventBus) =
    interface ITodoTaskNotificationsService with
        member this.SendNotification(notification) = vtask {
            match! telegramUserRepository.GetUser notification.Item.User with
            | Ok telegramUser ->
                do! bus.Publish { Time = notification.Time; Item = notification.Item; TelegramUser = telegramUser }
                do! bus.Publish notification
                return Ok ()
            | Error (:? TelegramUserDoesNotExistException as exn) ->
                logger.LogError("Unable to find matching telegram user for {user}", notification.Item.User)
                return Error (exn :> exn)
            | Error exn ->
                logger.LogError("Unexpected exception occured: {exn}", exn)
                return Error exn
        }

type InMemoryTelegramUserStorage() =

    let userDictTelegramId = ConcurrentDictionary()
    let userDictSystemUserId = ConcurrentDictionary()

    let createUser (command: CreateTelegramUserCommand) =
        match userDictSystemUserId.TryGetValue command.SystemUser.Id with
        | true, _ ->
            Error (TelegramUserAlreadyExistsException() :> exn)
        | _ ->
            let userGuid = Guid.NewGuid() |> NonEmptyGuid.Make
            let user: TelegramUser = {
                Id = userGuid
                TelegramId = command.TelegramId
                SystemUser = command.SystemUser
            }
            userDictTelegramId.[user.TelegramId] <- user
            userDictSystemUserId.[user.SystemUser.Id] <- user
            Ok user

    let changeUser (user: TelegramUser) =
        match userDictTelegramId.TryGetValue user.TelegramId with
        | true, oldUser ->
            userDictTelegramId.[user.TelegramId] <- user
            userDictSystemUserId.[user.SystemUser.Id] <- user
            Ok oldUser
        | _ ->
            Error (TelegramUserDoesNotExistException() :> exn)

    let getUserById userId =
        match userDictSystemUserId.TryGetValue userId with
        | true, user ->
            Ok user
        | _ ->
            Error (TelegramUserDoesNotExistException() :> exn)

    let getUserByTelegramId telegramId =
        match userDictTelegramId.TryGetValue telegramId with
        | true, user ->
            Ok user
        | _ ->
            Error (TelegramUserDoesNotExistException() :> exn)

    interface ITelegramUserStorage with
        member this.ChangeUser(user) = changeUser user |> Task.FromResult
        member this.CreateUser(command) = createUser command |> Task.FromResult
        member this.GetUser(user: User) = getUserById user.Id |> Task.FromResult
        member this.GetUser(userId: TelegramUserId) = getUserByTelegramId userId |> Task.FromResult
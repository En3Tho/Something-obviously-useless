namespace TGOrganizer.Implementation.InMemory.Consumers

open FSharp.Control.Tasks
open Microsoft.Extensions.Logging
open En3Tho.FSharp.Extensions.Core
open En3Tho.FSharp.Validation
open TGOrganizer.Contracts
open TGOrganizer.Primitives

type ReschedulerTodoTaskNotificationConsumer(logger: ILogger<ReschedulerTodoTaskNotificationConsumer>,
                                             scheduler: ITodoTaskSchedulingService) =
    interface IEventConsumer<TodoTaskNotification> with
        member this.Consume event = vtask {
            match event.Item.Schedule with
            | ScheduleType.RunPeriodically (ValidTimeSpan period) ->
                let newTime = event.Time.MapMake ^ fun time -> time + period
                logger.LogTrace("Scheduling a new todo task: {time}, {item}", newTime, event.Item)
                match! scheduler.Schedule(newTime, event.Item) with
                | Error exn ->
                    logger.LogError("Unable to schedule new todo item: {exn}", exn)
                | _ -> ()
            | _ -> ()
        }
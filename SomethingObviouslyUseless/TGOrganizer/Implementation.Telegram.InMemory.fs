module TGOrganizer.Implementation.Telegram.InMemory

open Microsoft.Extensions.Logging
open TGOrganizer.Contracts
open TGOrganizer.Contracts.Telegram
open FSharp.Control.Tasks

type TelegramTodoTaskNotificationsService(bus: IEventBus<TodoTaskNotification>) =
    interface ITodoTaskNotificationsService with
        member this.SendNotification(notification) = vtask {
            do! bus.Publish notification
            return Ok ()
        }

type TodoTaskNotificationConsumer(logger: ILogger<TodoTaskNotificationConsumer>,
                                  telegramUserRepository: ITelegramUserStorage,
                                  bus: IEventBus<TodoTaskTelegramNotification>) =
    interface IEventConsumer<TodoTaskNotification> with
        member this.Consume event = vtask {
            match! telegramUserRepository.GetUser event.Item.User with
            | Ok telegramUser ->
                do! bus.Publish { Time = event.Time; Item = event.Item; TelegramUser = telegramUser }
            | Error TelegramUserDoesNotExist ->
                logger.LogError("Unable to find matching telegram user for {user}", event.Item.User)
            | Error exn ->
                logger.LogError("Unexpected exception occured: {exn}", exn)
        }
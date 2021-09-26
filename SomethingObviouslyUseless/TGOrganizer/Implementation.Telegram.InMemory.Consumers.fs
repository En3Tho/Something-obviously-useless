namespace TGOrganizer.Implementation.Telegram.InMemory.Consumers

open System.Threading.Tasks
open Microsoft.Extensions.Logging
open TGOrganizer.Contracts
open TGOrganizer.Contracts.Telegram

type TelegramTodoTaskNotificationConsumer(logger: ILogger<TelegramTodoTaskNotificationConsumer>) =
    interface IEventConsumer<TodoTaskTelegramNotification> with
        member this.Consume(event) =
            logger.LogInformation("Got telegram todo task notification event: {event}", event)
            ValueTask.FromResult ()
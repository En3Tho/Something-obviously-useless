namespace TGOrganizer.Host

open System
open System.Threading.Tasks
open FSharp.Control.Tasks
open Microsoft.Extensions.Hosting
open Microsoft.Extensions.Logging
open TGOrganizer.Primitives
open TGOrganizer.Contracts

type InMemoryHostedService(scheduler: ITodoTaskSchedulingService) =
    interface IHostedService with
        member this.StartAsync(cancellationToken) = Task.CompletedTask
        member this.StopAsync(cancellationToken) = Task.CompletedTask

type ConsolePrinterTodoTaskNotificationConsumer(logger: ILogger<ConsolePrinterTodoTaskNotificationConsumer>) =
    interface IEventConsumer<TodoTaskNotification> with
        member this.Consume event = vtask {
            logger.LogInformation $"Got an event! {event}"
        }

type InMemoryServiceProviderBasedEventBus(serviceProvider: IServiceProvider) =
    interface IEventBus with
        member this.Publish<'a>(value) = vtask {
            let bus = serviceProvider.GetService<IEventBus<'a>>()
            do! bus.Publish value
        }
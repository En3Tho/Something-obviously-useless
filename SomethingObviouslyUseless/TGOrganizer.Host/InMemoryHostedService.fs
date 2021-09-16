namespace TGOrganizer.Host

open System.Threading.Tasks
open Microsoft.Extensions.Hosting
open TGOrganizer.Contracts

type InMemoryHostedService(scheduler: ITodoTaskSchedulingService) =
    interface IHostedService with
        member this.StartAsync(cancellationToken) = Task.CompletedTask
        member this.StopAsync(cancellationToken) = Task.CompletedTask
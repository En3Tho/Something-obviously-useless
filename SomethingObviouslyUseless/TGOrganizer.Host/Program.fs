namespace TGOrganizer.Host

open System
open System.Threading
open System.Threading.Tasks
open En3Tho.FSharp.Extensions
open En3Tho.FSharp.Validation.CommonValidatedTypes
open Microsoft.AspNetCore.Hosting
open Microsoft.Extensions.Hosting
open Microsoft.Extensions.Logging
open TGOrganizer.Contracts
open TGOrganizer.Contracts.Telegram
open TGOrganizer.Primitives

module Program =
    let createHostBuilder args =
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(fun webBuilder ->
                webBuilder.UseStartup<Startup>() |> ignore
            )

    [<EntryPoint>]
    let main args =

        let host = createHostBuilder(args).Build()
        let userStorage = host.Services.GetService<IUserStorage>()
        let editorService = host.Services.GetService<ITodoItemEditorService>()
        let schedulingService = host.Services.GetService<ITodoTaskSchedulingService>()
        let tgUserStorage = host.Services.GetService<ITelegramUserStorage>()

        let user =
            { Name = "Igor" |> NonEmptyString.Make
              Login = "Igor123" |> NonEmptyString.Make }
            |> userStorage.CreateUser
            |> Task.RunSynchronously
            |> EResult.unwrap

        let tgUser =
            { TelegramId = TelegramUserId.Make 1L
              SystemUser = user }
            |> tgUserStorage.CreateUser
            |> Task.RunSynchronously
            |> EResult.unwrap

        let todoItem =
            let request = {
                Body = { Description = "My first todotask!" |> NonEmptyString.Make }
                Schedule = ScheduleType.RunPeriodically(TimeSpan.FromSeconds(3.) |> ValidTimeSpan.Make)
            }
            editorService.CreateTodoItem(tgUser.SystemUser, request)
            |> ValueTask.RunSynchronously
            |> EResult.unwrap

        schedulingService.Schedule(DateTimeOffset.UtcNow + TimeSpan.FromSeconds(3.) |> ValidDateTimeOffset.Make, todoItem)
        |> ValueTask.RunSynchronously
        |> EResult.unwrap

        Thread.Sleep(15000)

        schedulingService.DropScheduling(todoItem)
        |> ValueTask.RunSynchronously
        |> EResult.unwrap

        Console.ReadLine() |> ignore

        0 // Exit code
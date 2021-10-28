namespace TGOrganizer.Host

open Microsoft.AspNetCore.Builder
open Microsoft.AspNetCore.Hosting
open Microsoft.AspNetCore.Http
open Microsoft.Extensions.DependencyInjection
open Microsoft.Extensions.Hosting
open TGOrganizer.Implementation
open TGOrganizer.Contracts
open TGOrganizer.Contracts.Telegram
open TGOrganizer.Implementation.InMemory.Consumers
open TGOrganizer.Implementation.InMemory.Services
open TGOrganizer.Implementation.Telegram.InMemory.Consumers
open TGOrganizer.Implementation.Telegram.InMemory.Services

[<AutoOpen>]
module ServiceCollectionExtensions =
    type IServiceCollection with
        member this.AddSingletonAsOpenGeneric<'TService>() =
            this.AddSingleton(typedefof<'TService>)

        member this.AddSingletonAsOpenGeneric<'TService, 'TImpl>() =
            this.AddSingleton(typedefof<'TService>, typedefof<'TImpl>)

        member this.AddScopedAsOpenGeneric<'TService>() =
            this.AddScoped(typedefof<'TService>)

        member this.AddScopedAsOpenGeneric<'TService, 'TImpl>() =
            this.AddScoped(typedefof<'TService>, typedefof<'TImpl>)

        member this.AddTransientAsOpenGeneric<'TService>() =
            this.AddSingleton(typedefof<'TService>)

        member this.AddTransientAsOpenGeneric<'TService, 'TImpl>() =
            this.AddSingleton(typedefof<'TService>, typedefof<'TImpl>)

type Startup() =

    member _.ConfigureServices(services: IServiceCollection) =
        services
            .AddSingletonAsOpenGeneric<IEventBus<_>, InMemoryEventBus<_>>()
            .AddSingleton<IEventBus, InMemoryServiceProviderBasedEventBus>()

            .AddSingleton<IUserStorage, InMemoryUserStorage>()
            .AddSingleton<ITodoTaskStorage, InMemoryTodoTaskStorage>()

            .AddSingleton<ITodoTaskNotificationsService, InMemoryTelegramTodoTaskNotificationsService>()
            .AddSingleton<ITodoItemEditorService, TodoItemEditorService>()
            .AddSingleton<ITodoTaskSchedulingService, InMemoryTodoItemSchedulingService>()

            .AddSingleton<ITelegramWebHookService, TelegramWebHookService>()

            .AddSingleton<IEventConsumer<_>, ReschedulerTodoTaskNotificationConsumer>()
            .AddSingleton<IEventConsumer<_>, ConsolePrinterTodoTaskNotificationConsumer>()
            .AddSingleton<IEventConsumer<_>, TelegramTodoTaskNotificationConsumer>()

            .AddSingleton<ITelegramUserStorage, InMemoryTelegramUserStorage>()

            .AddHostedService<InMemoryHostedService>()

            .AddLogging()
        |> ignore

    member _.Configure(app: IApplicationBuilder, env: IWebHostEnvironment) =
        if env.IsDevelopment() then
            app.UseDeveloperExceptionPage() |> ignore

        app.UseRouting()
           .UseEndpoints(fun endpoints ->
                endpoints.MapGet("/", fun context ->
                    context.Response.WriteAsync("Hello World!")) |> ignore
            ) |> ignore
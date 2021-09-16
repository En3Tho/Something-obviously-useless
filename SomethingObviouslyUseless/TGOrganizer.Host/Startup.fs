namespace TGOrganizer.Host

open System
open Microsoft.AspNetCore.Builder
open Microsoft.AspNetCore.Hosting
open Microsoft.AspNetCore.Http
open Microsoft.Extensions.DependencyInjection
open Microsoft.Extensions.Hosting
open TGOrganizer.Contracts
open TGOrganizer.Implementation
open TGOrganizer.TelegramInfrastructure

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

    // This method gets called by the runtime. Use this method to add services to the container.
    // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
    member _.ConfigureServices(services: IServiceCollection) =
        services
            .AddSingletonAsOpenGeneric<IEventBus<_>, InMemoryEventBus<_>>()

            .AddSingleton<ITodoTaskNotificationsService, TelegramTodoTaskNotificationsService>()
            .AddSingleton<IEventConsumer<_>, TodoTaskNotificationConsumer>()
            .AddSingleton<ITodoItemEditorService, TodoItemEditorService>()
            .AddSingleton<ITodoTaskStorage, InMemoryTodoTaskStorage>()
            .AddSingleton<ITodoTaskSchedulingService, InMemoryTodoItemSchedulingService>()

            .AddHostedService<InMemoryHostedService>()
        |> ignore

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    member _.Configure(app: IApplicationBuilder, env: IWebHostEnvironment) =
        if env.IsDevelopment() then
            app.UseDeveloperExceptionPage() |> ignore

        app.UseRouting()
           .UseEndpoints(fun endpoints ->
                endpoints.MapGet("/", fun context ->
                    context.Response.WriteAsync("Hello World!")) |> ignore
            ) |> ignore
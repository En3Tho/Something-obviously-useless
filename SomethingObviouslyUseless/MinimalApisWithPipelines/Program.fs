open System
open Microsoft.AspNetCore.Builder
open Microsoft.AspNetCore.Http
open Microsoft.Extensions.Hosting
open MinimalApisWithPipelines
open MinimalApisWithPipelines.Framework
open MinimalApisWithPipelines.Pipelines

type ValidationException(message) =
    inherit Exception(message)

type DomainException(message) =
    inherit Exception(message)

module Results =
    let fromRequestResult (result: PipelineResult<'a>) =
        match result with
        | Ok value -> Results.Ok value
        | Error (:? ValidationException as exn) -> Results.BadRequest(exn) // for example
        | Error (:? DomainException as exn) -> Results.UnprocessableEntity(exn) // for example
        | Error exn ->  Results.BadRequest(exn)

[<EntryPoint>]
let main args =
    let builder = WebApplication.CreateBuilder(args)

    builder.Services
        .AddFSharpJsonOptions()
        .RegisterPipeline(Unchecked.defaultof<CreateUserPipeline>) |> ignore

    let app = builder.Build()

    app.MapGet("/new-user/{name}", Func<string, CreateUserPipeline, _>(fun name ([<FromServices>] pipeline) ->
        { CreateUserRequest.Name = name }
        |> pipeline.Handle
        |> Results.fromRequestResult
    )) |> ignore

    app.Run()

    0 // Exit code
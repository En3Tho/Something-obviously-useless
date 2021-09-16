namespace MinimalApisWithPipelines.Framework

open Microsoft.Extensions.DependencyInjection

#nowarn "0686"

type PipelineResult<'a> = Result<'a, exn>

type IRequestHandler<'TRequest, 'TResult> =
    abstract member Handle: request: 'TRequest -> PipelineResult<'TResult>

type IRequestFilter<'TRequest> = IRequestHandler<'TRequest, 'TRequest>

type IRequestPipeline<'TRequest, 'THandler1, 'TState, 'THandler2, 'TResult
    when 'THandler1 :> IRequestHandler<'TRequest, 'TState>
    and 'THandler2 :> IRequestHandler<'TState, 'TResult>> =
        abstract member Handle: request: 'TRequest -> PipelineResult<'TResult>

module RequestHandler =
    let inline handle (handler: #IRequestHandler<_,_>) request =
        handler.Handle request

type RequestPipeline<'TRequest, 'THandler1, 'TState, 'THandler2, 'TResult
    when 'THandler1 :> IRequestHandler<'TRequest, 'TState>
    and 'THandler2 :> IRequestHandler<'TState, 'TResult>>(handler1: 'THandler1, handler2: 'THandler2) =
    member _.Handle request =
       request
       |> RequestHandler.handle<_,_,'TState> handler1
       |> Result.bind (RequestHandler.handle handler2)

    interface IRequestPipeline<'TRequest, 'THandler1, 'TState, 'THandler2, 'TResult> with
        member this.Handle request = this.Handle request

[<AutoOpen>]
module ServiceCollectionExtensions =
    type IServiceCollection with
        member this.RegisterPipeline (_: 'pipeline when 'pipeline :> IRequestPipeline<_, 'handler, _, 'handler2, _>) =
            this.AddTransient<'handler>()
                .AddTransient<'handler2>()
                .AddTransient<'pipeline>()
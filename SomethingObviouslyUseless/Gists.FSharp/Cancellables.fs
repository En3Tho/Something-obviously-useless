module Gists.FSharp.Cancellables

open System.Threading.Tasks


type CancellableBacktrackingExecution<'state> =
    | Success of Value: EResult<'state>
    | Cancel
    | Back

type AsyncCancellableBacktrackingExecution<'result> = Task<CancellableBacktrackingExecution<'result>>
type AsyncCancellableBacktrackingExecutionFactory<'result> = 'result -> AsyncCancellableBacktrackingExecution<'result>

type CancellableBacktrackingExecutionRunner<'result>(initial: 'result) =
    let steps = ResizeArray()
    let states = ResizeArray() { initial }

    member this.Yield (yieldResult: AsyncCancellableBacktrackingExecutionFactory<'result>) =
        yieldResult

    member this.Delay f = f

    member this.Run(initialState: 'result, computation) = task {
        states.Add initialState
        return! computation
    }

    member this.Combine(step: AsyncCancellableBacktrackingExecutionFactory<'result>, continuation) = task {
        steps.Add step
        let state = states.TakeLast()

        match! step state with
        | Success (Ok value) ->
            states.Add value
            return! continuation value
        | Success (Error exn) ->
            return Error exn
        | Cancel ->
            return Error (OperationCanceledException() :> exn)
        | Back when steps.Count <= 1 ->
            return Error (OperationCanceledException() :> exn)
        | Back ->
            states.RemoveLast()
            let currentStep = steps.PopLast()
            let prevStep = steps.PopLast()

            return! this.Combine(prevStep, fun value -> task {
                states.Add value
                return! this.Combine(currentStep, continuation)
            })
    }

type AsyncResultBuilder() =

    member _.Return (value: 'T) : Async<Result<'T, 'TError>> =
      async.Return <| Ok value

    member inline _.ReturnFrom
        (asyncResult: Async<Result<'T, 'TError>>)
        : Async<Result<'T, 'TError>> =
      asyncResult

    member _.Zero () : Async<Result<unit, 'TError>> =
      async.Return <| Ok ()

    member inline _.Bind
        (asyncResult: Async<Result<'T, 'TError>>,
         binder: 'T -> Async<Result<'U, 'TError>>)
        : Async<Result<'U, 'TError>> =
      async {
        let! result = asyncResult
        match result with
        | Ok x -> return! binder x
        | Error x -> return Error x
      }

    member _.Delay
        (generator: unit -> Async<Result<'T, 'TError>>)
        : Async<Result<'T, 'TError>> =
      async.Delay generator

    member this.Combine
        (computation1: Async<Result<unit, 'TError>>,
         computation2: Async<Result<'U, 'TError>>)
        : Async<Result<'U, 'TError>> =
      this.Bind(computation1, fun () -> computation2)

    member _.TryWith
        (computation: Async<Result<'T, 'TError>>,
         handler: System.Exception -> Async<Result<'T, 'TError>>)
        : Async<Result<'T, 'TError>> =
      async.TryWith(computation, handler)

    member _.TryFinally
        (computation: Async<Result<'T, 'TError>>,
         compensation: unit -> unit)
        : Async<Result<'T, 'TError>> =
      async.TryFinally(computation, compensation)

    member _.Using
        (resource: 'T when 'T :> IDisposable,
         binder: 'T -> Async<Result<'U, 'TError>>)
        : Async<Result<'U, 'TError>> =
      async.Using(resource, binder)

    member this.While
        (guard: unit -> bool, computation: Async<Result<unit, 'TError>>)
        : Async<Result<unit, 'TError>> =
      if not <| guard () then this.Zero ()
      else this.Bind(computation, fun () -> this.While (guard, computation))

    member this.For
        (sequence: #seq<'T>, binder: 'T -> Async<Result<unit, 'TError>>)
        : Async<Result<unit, 'TError>> =
      this.Using(sequence.GetEnumerator (), fun enum ->
        this.While(enum.MoveNext,
          this.Delay(fun () -> binder enum.Current)))

type AsyncResultBuilder2() =

    member _.Return (value: 'T) : Async<EResult<'T>> =
      async.Return <| (Ok value)

    member inline _.ReturnFrom
        (asyncResult: Async<CancellableBacktrackingExecution<'T>>)
        : Async<EResult<'T>> = async {
            match! asyncResult with
            | Success (Ok value) -> return Ok value
            | Success (Error exn) -> return Error exn
            | Cancel -> return Error (OperationCanceledException() :> exn)
            | Back when ... -> return Error (OperationCanceledException() :> exn)
            | Back -> ...
        }

    member _.Zero () : Async<Result<unit, 'TError>> =
      async.Return <| Ok ()

    member inline _.Bind
        (asyncResult: Async<CancellableBacktrackingExecution<'T>>,
         binder: 'T -> Async<CancellableBacktrackingExecution<'U>>)
        : Async<CancellableBacktrackingExecution<'U>> = async {
            match! asyncResult with
            | Success (Ok value) ->
                return! binder value
            | Success (Error exn) ->
                return Error exn
            | Cancel ->
                return Error (OperationCanceledException() :> exn)
            | Back when steps.Count <= 1 ->
                return Error (OperationCanceledException() :> exn)
            | Back ->
                states.RemoveLast()
                let currentStep = steps.PopLast()
                let prevStep = steps.PopLast()

                return! this.Bind(prevStep, fun value -> task {
                    states.Add value
                    return! this.Bind(currentStep, continuation)
                })
    }

    member _.Delay
        (generator: unit -> Async<CancellableBacktrackingExecution<'T>>)
        : Async<CancellableBacktrackingExecution<'T>> =
      async.Delay generator

    member this.Combine
        (computation1: Async<CancellableBacktrackingExecution<unit>>,
         computation2: Async<CancellableBacktrackingExecution<'U>>)
        : Async<EResult<'U>> =
      this.Bind(computation1, fun () -> computation2)

//    member _.TryWith
//        (computation: Async<CancellableBacktrackingExecution<'T>>,
//         handler: System.Exception -> Async<EResult<'T>>)
//        : Async<EResult<'T>> = async {
//            try
//                return! computation
//            with exn ->
//                return! handler exn
//        }
//
//    member _.TryFinally
//        (computation: Async<CancellableBacktrackingExecution<'T>>,
//         compensation: unit -> unit)
//        : Async<EResult<'T>> = async {
//            try
//                return! computation
//            finally
//                compensation()
//        }
//
//    member _.Using
//        (resource: 'T when 'T :> IDisposable,
//         binder: 'T -> Async<EResult<'U>>)
//        : Async<EResult<'U>> =
//      async.Using(resource, binder)

//    member this.While
//        (guard: unit -> bool, computation: Async<EResult<unit>>)
//        : Async<EResult<unit>> =
//      if not <| guard () then this.Zero ()
//      else this.Bind(computation, fun () -> this.While (guard, computation))
//
//    member this.For
//        (sequence: #seq<'T>, binder: 'T -> Async<EResult<unit>>)
//        : Async<EResult<unit>> =
//      this.Using(sequence.GetEnumerator (), fun enum ->
//        this.While(enum.MoveNext,
//          this.Delay(fun () -> binder enum.Current)))

type CancellableBacktrackingExecutionRunner2<'result>(initial: 'result) =

    let steps = ResizeArray()
    let states = ResizeArray() { initial }

    member this.Delay f = f

    member this.Bind(step: AsyncCancellableBacktrackingExecutionFactory<'result>, continuation) = task {
        let state = states.TakeLast()

        match! step state with
        | Success (Ok value) ->
            states.Add value
            return! continuation value
        | Success (Error exn) ->
            return Error exn
        | Cancel ->
            return Error (OperationCanceledException() :> exn)
        | Back when steps.Count <= 1 ->
            return Error (OperationCanceledException() :> exn)
        | Back ->
            states.RemoveLast()
            let currentStep = steps.PopLast()
            let prevStep = steps.PopLast()

            return! this.Bind(prevStep, fun value -> task {
                states.Add value
                return! this.Bind(currentStep, continuation)
            })
    }

    member this.ReturnFrom(step) = task {
        return! this.Bind(step, fun result -> Task.FromResult (Ok result))
    }

    member this.Return(execution) = Task.FromResult execution

let canc initial = CancellableBacktrackingExecutionRunner2()
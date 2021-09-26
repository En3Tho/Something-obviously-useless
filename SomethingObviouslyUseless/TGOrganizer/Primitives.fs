module TGOrganizer.Primitives

open System
open System.Collections.Generic
open System.Threading
open System.Threading.Tasks
open En3Tho.FSharp.Validation
open En3Tho.FSharp.Validation.CommonTypes
open En3Tho.FSharp.ComputationExpressions.ICollectionBuilder
open FSharp.Control.Tasks

[<AutoOpen>]
module TopLevelOperators =
    let inline (!) value = (^a: (member Value: ^b) value)
    let inline (|Kvp|) (kvp: KeyValuePair<_,_>) = kvp.Key, kvp.Value

    let inline lockVTask (lockObj: 'lock when 'lock : not struct) (job: unit -> ValueTask<'a>) = vtask {
        Monitor.Enter lockObj
        try
            return! job()
        finally
            Monitor.Exit lockObj
    }

    type List<'a> with
        member this.RemoveLast() = this.RemoveAt(this.Count - 1)
        member this.TakeLast() = this.[this.Count - 1]
        member this.PopLast() =
            let result = this.TakeLast()
            this.RemoveLast()
            result

    type IServiceProvider with
        member this.GetService<'a>() =
            match this.GetService(typeof<'a>) with
            | null -> failwith ("Unable to find service of type " + typeof<'a>.FullName)
            | service -> service :?> 'a

type ValidDateTimeOffset = DateTimeOffset NonDefaultValue
let inline (|ValidDateTimeOffset|) (value: ValidDateTimeOffset) = value.Value

type ValidTimeSpan = TimeSpan NonNegativeValue
let inline (|ValidTimeSpan|) (value: ValidTimeSpan) = value.Value

type BacktrackingCancelableExecution<'state> =
    | Success of Value: EResult<'state>
    | Cancel
    | Back

let runBacktrackingCancelables (state: 'a) (steps: ('a -> Task<BacktrackingCancelableExecution<'a>>) IList) = task {
    if steps.Count = 0 then
        return Error (OperationCanceledException() :> exn)
    else
    let mutable x = 0
    let mutable states = ResizeArray() { state }
    let rec goNext() = task {
        let step = steps.[x]
        let state = states.TakeLast()
        match! step state with
        | Success (Ok state) when x = steps.Count - 1 ->
            return Ok state
        | Success (Error exn) ->
            return Error exn
        | Back when x = 0 ->
            return Error (OperationCanceledException() :> exn)
        | Cancel ->
            return Error (OperationCanceledException() :> exn)
        | Success (Ok state) ->
            states.Add state
            x <- x + 1
            return! goNext()
        | Back ->
            states.RemoveLast()
            x <- x - 1
            return! goNext()
    }
    return! goNext()
}
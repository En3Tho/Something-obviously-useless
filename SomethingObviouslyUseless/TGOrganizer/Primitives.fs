module TGOrganizer.Primitives

open System
open System.Collections.Generic
open System.Threading
open System.Threading.Tasks
open En3Tho.FSharp.Validation.CommonTypes
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

    type Task with
        static member inline RunSynchronously (task: Task) =
            if task.IsCompletedSuccessfully then () else
            task.ConfigureAwait(false).GetAwaiter().GetResult()

        static member inline RunSynchronously (task: Task<'a>) =
            if task.IsCompletedSuccessfully then task.Result else
            task.ConfigureAwait(false).GetAwaiter().GetResult()

    type ValueTask with
        static member inline RunSynchronously (task: ValueTask) =
            if task.IsCompletedSuccessfully then () else
            task.ConfigureAwait(false).GetAwaiter().GetResult()

        static member inline RunSynchronously (task: ValueTask<'a>) =
            if task.IsCompletedSuccessfully then task.Result else
            task.ConfigureAwait(false).GetAwaiter().GetResult()

    type List<'a> with
        member this.RemoveLast() = this.RemoveAt(this.Count - 1)
        member this.TakeLast() = this.[this.Count - 1]
        member this.PopLast() =
            let result = this.TakeLast()
            this.RemoveLast()
            result

type ValidDateTimeOffset = DateTimeOffset NonDefaultValue
let inline (|ValidDateTimeOffset|) (value: ValidDateTimeOffset) = value.Value

type ValidTimeSpan = TimeSpan NonNegativeValue
let inline (|ValidTimeSpan|) (value: ValidTimeSpan) = value.Value
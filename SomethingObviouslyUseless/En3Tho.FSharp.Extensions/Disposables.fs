namespace En3Tho.FSharp.Extensions.Disposables

open System

[<Struct>]
type ValueDisposable<'a>(value: 'a, dispose: 'a -> unit) =
    member _.Value = value
    interface IDisposable with
        member this.Dispose() = dispose value

[<Struct>]
type UnitDisposable(dispose: unit -> unit) =
    interface IDisposable with
        member this.Dispose() = dispose()
namespace En3Tho.FSharpExtensions.Disposables

open System

[<Struct>]
type ValueDisposable<'a>(value: 'a, dispose: 'a -> unit) =
    member _.Value = value
    interface IDisposable with
        member this.Dispose() = dispose value

[<Struct>]
type ActionDisposable(dispose: unit -> unit) =
    interface IDisposable with
        member this.Dispose() = dispose()
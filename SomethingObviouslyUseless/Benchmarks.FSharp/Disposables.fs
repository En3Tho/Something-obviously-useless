module Benchmarks.FSharp.Disposables

open System
open System.Collections.Concurrent
open System.Threading
open System.Threading.Tasks

[<Struct>]
type DisposableValue<'a when 'a :> IDisposable> =
    | Disposed
    | NotDisposed of 'a

/// A borrowed ref counted value
type RentedDisposableValue<'a when 'a :> IDisposable>(disposable: DisposableRefCounter<'a>) =
    let mutable valueGiven = 0
    let mutable valueReturned = 0

    /// Sets the dispose marker of an underlying disposable counter
    member _.RequestDispose() =
        disposable.RequestDispose()

    /// Tries to rent the value from underlying disposable counter only once
    /// Value is not actually rented until this method is called
    member _.TryGetValue() =
        match Interlocked.Increment &valueGiven with
        | 1 -> disposable.DangerousTryGetValue()
        | _ -> ValueNone

    /// Rents a value again from an underlying disposable counter
    member _.RentAgain() = disposable.Rent()

    /// Decrements the count of an underlying disposable counter only once
    member this.Dispose() =
        match Interlocked.Increment &valueGiven with
        | 1 -> () // no need to notify counter as value was never borrowed
        | _ ->
            if Interlocked.Increment &valueReturned = 1 then
                disposable.DangerousReturn()

    interface IDisposable with
         member this.Dispose() = this.Dispose()

/// A ref counter for async disposable values
and DisposableRefCounter<'a when 'a :> IDisposable>(value: 'a) =
    let [<Literal>] DisposeMarker = 2147483647L // Int32.MaxValue
    let mutable uses = 0L
    let mutable disposeRequested = 0

    /// Sets the dispose marker
    member this.RequestDispose() =
        match Interlocked.Increment &disposeRequested with
        | 1 -> Interlocked.Add(&uses, DisposeMarker) |> ignore // set
        | _ -> ()

    /// Returns true if dispose marker is set
    member this.DisposeRequested = Volatile.Read &uses >= DisposeMarker

    /// Rents the protected value
    member this.Rent() =
        new RentedDisposableValue<'a>(this)

    /// Tries to get the value if it is not disposed
    /// This can be called only from the rented object only 1 time
    member internal _.DangerousTryGetValue() =
        if Interlocked.Increment &uses < DisposeMarker then
            ValueSome value
        else
            ValueNone

    /// Disposes the protected value if dispose marker is set and no other uses are detected
    /// This can be called only from the rented object only 1 time
    member internal this.DangerousReturn() =
        if Interlocked.Decrement &uses = DisposeMarker then // 0 uses basically, only dispose marker is set
            value.Dispose()

    member this.Dispose() =
        if Interlocked.Increment &disposeRequested = 1
            && Interlocked.Add(&uses, DisposeMarker) = DisposeMarker then
                value.Dispose()

    interface IDisposable with
        member this.Dispose() = this.Dispose()

/// A borrowed ref counted value
type RentedAsyncDisposableValue<'a when 'a :> IAsyncDisposable>(disposable: AsyncDisposableRefCounter<'a>) =
    let mutable valueGiven = 0
    let mutable valueReturned = 0

    /// Sets the dispose marker of an underlying disposable counter
    member _.RequestDispose() =
        disposable.RequestDispose()

    /// Tries to rent the value from underlying disposable counter only once
    /// Value is not actually rented until this method is called
    member _.TryGetValue() =
        match Interlocked.Increment &valueGiven with
        | 1 -> disposable.DangerousTryGetValue()
        | _ -> ValueNone

    /// Rents a value again from an underlying disposable counter
    member _.RentAgain() = disposable.Rent()

    /// Decrements the count of underlying disposable counter
    member this.DisposeAsync() =
        match Interlocked.Increment &valueGiven with
        | 1 -> ValueTask() // no need to notify counter as value was never borrowed
        | _ ->
            match Interlocked.Increment &valueReturned with
            | 1 -> disposable.DangerousReturn()
            | _ -> ValueTask()

    interface IAsyncDisposable with
         member this.DisposeAsync() = this.DisposeAsync()

/// A ref counter for async disposable values
and AsyncDisposableRefCounter<'a when 'a :> IAsyncDisposable>(value: 'a) =
    let [<Literal>] DisposeMarker = 2147483647L // Int32.MaxValue
    let mutable uses = 0L
    let mutable disposeRequested = 0

    /// Sets the dispose marker
    member this.RequestDispose() =
        match Interlocked.Increment &disposeRequested with
        | 1 -> Interlocked.Add(&uses, DisposeMarker) |> ignore // set
        | _ -> ()

    /// Returns true if dispose marker is set
    member this.DisposeRequested = Volatile.Read &uses >= DisposeMarker

    /// Rents the protected value
    member this.Rent() =
        new RentedAsyncDisposableValue<'a>(this)

    /// Tries to get the value if it is not disposed
    /// This can be called only from the rented object only 1 time
    member _.DangerousTryGetValue() =
        if Interlocked.Increment &uses < DisposeMarker then
            ValueSome value
        else
            ValueNone

    /// Disposes the protected value if dispose marker is set and no other uses are detected
    /// This can be called only from the rented object only 1 time
    member internal this.DangerousReturn() =
        if Interlocked.Decrement &uses = DisposeMarker then // 0 uses basically, only dispose marker is set
            value.DisposeAsync()
        else
            ValueTask()

    member this.DisposeAsync() =
        if Interlocked.Increment &disposeRequested = 1
            && Interlocked.Add(&uses, DisposeMarker) = DisposeMarker then
            value.DisposeAsync()
        else
            ValueTask()

    interface IAsyncDisposable with
        member this.DisposeAsync() = this.DisposeAsync()

type SomeDisposable() =
    let mutable isDisposed = false

    member _.DoSomething() =
        if isDisposed then invalidOp "Disposed"
        DateTime.Now

    interface IDisposable with
        member _.Dispose() =
            isDisposed <- true
            //Console.WriteLine("Value is disposed")

type Param = {
    Key: string
    Value: int
}

type DisposableAndParam = DisposableRefCounter<SomeDisposable> * Param

let testConcurrentAccess() =

    let inline refCount value = new DisposableRefCounter<_>(value)

    let collection = ConcurrentDictionary<string, DisposableAndParam>()

    let rentValue (param: Param) =
        match collection.TryGetValue param.Key with
        | true, (oldValue, oldParam) ->
            if oldParam <> param then
                oldValue.Dispose()

                let newValue = refCount (new SomeDisposable())
                collection.[param.Key] <- (newValue, param)
                newValue.Rent()
            else
                oldValue.Rent()
        | _ ->
            let newValue = refCount (new SomeDisposable())
            collection.[param.Key] <- (newValue, param)
            newValue.Rent()

    // works as expected
    let getAndUseMutableValueWorks param f =
        let mutable r = rentValue param
        let mutable goNext = true
        try
            while goNext do
                match r.TryGetValue() with
                | ValueSome value ->
                    f value
                    goNext <- false
                | ValueNone ->
                    r.Dispose()
                    r <- rentValue param
        finally
            r.Dispose()

    // works as expected
    let rec getAndUseValueRecWorks param f =
        let rented = rentValue param
        match rented.TryGetValue() with
        | ValueSome value ->
            f value
            rented.Dispose()
        | ValueNone ->
            rented.Dispose()
            getAndUseValueRecWorks param f

    // fails with stackoverflow
    // cannot be tailcall optimized?
    let rec getAndUseValueRecDoesntWork param f =
        use rented = rentValue param
        match rented.TryGetValue() with
        | ValueSome value ->
            f value
        | ValueNone ->
            getAndUseValueRecWorks param f

    let rnd = Random()
    let getNextKey() = rnd.Next(0, 10).ToString()

    let action() =
        let key = getNextKey()
        let value = DateTime.Now.Millisecond % 10

        try
            getAndUseValueRecWorks { Key = key; Value = value } (fun value ->
                for i in 0 .. 10 do
                    value.DoSomething() |> ignore)
        with e -> Console.WriteLine(e.Message)

    for i in 0 .. 1000 do
        Console.WriteLine($"Run {i}")
        [| for _ in 0 .. 100000 do
            Task.Run(action) |]
        |> Task.WaitAll
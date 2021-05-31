module Gists.FSharp.Structs

open System.Buffers
open System.Collections.Concurrent
open System.Runtime.CompilerServices
open System
open System.Runtime.InteropServices
open System.Threading
open System.Threading.Tasks
open Microsoft.FSharp.NativeInterop

#nowarn "9"
module StackAlloc =

    type RentedDisposableValue<'a when 'a :> IDisposable>(disposable: DisposableRefCounter<'a>, value: 'a) =
        let mutable valueGiven = 0
        let mutable valueReturned = 0

        /// Sets the dispose marker of an underlying disposable counter
        member _.RequestDispose() =
            disposable.RequestDispose()

        /// Tries to rent the value from underlying disposable counter only once
        member _.TryGetValue() =
            match Interlocked.Increment &valueGiven with
            | 1 -> ValueSome value
            | _ -> ValueNone

        /// Rents a value again from an underlying disposable counter
        member _.RentAgain() = disposable.Rent()

        /// Decrements the count of an underlying disposable counter
        member _.Dispose() =
            if Interlocked.Increment &valueReturned = 1 then
                disposable.Dispose()

        interface IDisposable with
             member this.Dispose() = this.Dispose()

    and DisposableRefCounter<'a when 'a :> IDisposable>(value: 'a) =
        let [<Literal>] DisposeMarker = 2147483647L // Int32.MaxValue
        let mutable uses = 1L
        let mutable disposeRequested = 0

        /// Sets the dispose marker
        member this.RequestDispose() =
            match Interlocked.Increment &disposeRequested with
            | 1 -> Interlocked.Add(&uses, DisposeMarker) |> ignore // set
            | _ -> ()

        /// Gets the protected value if dispose marker is not set yet
        member this.Rent() =
            Interlocked.Increment &uses |> ignore
            new RentedDisposableValue<'a>(this, value)

        /// Disposes the protected value if dispose marker is set and no other uses is detected
        member this.Dispose() =
            if Interlocked.Decrement &uses = DisposeMarker then // 0 uses basically, only dispose marker is set
                value.Dispose()

        interface IDisposable with
            member this.Dispose() = this.Dispose()

    type RentedAsyncDisposableValue<'a when 'a :> IAsyncDisposable>(disposable: AsyncDisposableRefCounter<'a>, value: 'a) =
        let mutable valueGiven = 0
        let mutable valueReturned = 0

        /// Sets the dispose marker of an underlying disposable counter
        member _.RequestDispose() =
            disposable.RequestDispose()

        /// Tries to rent the value from underlying disposable counter only once
        member _.TryGetValue() =
            match Interlocked.Increment &valueGiven with
            | 1 -> ValueSome value
            | _ -> ValueNone

        /// Rents a value again from an underlying disposable counter
        member _.RentAgain() = disposable.Rent()

        /// Decrements the count of underlying disposable counter
        member _.DisposeAsync() =
            match Interlocked.Increment &valueReturned with
            | 1 -> disposable.DisposeAsync()
            | _ -> ValueTask()

        interface IAsyncDisposable with
             member this.DisposeAsync() = this.DisposeAsync()

    and AsyncDisposableRefCounter<'a when 'a :> IAsyncDisposable>(value: 'a) =
        let [<Literal>] DisposeMarker = 2147483647L // Int32.MaxValue
        let mutable uses = 1L
        let mutable disposeRequested = 0

        /// Sets the dispose marker
        member this.RequestDispose() =
            match Interlocked.Increment &disposeRequested with
            | 1 -> Interlocked.Add(&uses, DisposeMarker) |> ignore // set
            | _ -> ()

        /// Gets the protected value if dispose marker is not set yet
        member this.Rent() =
            Interlocked.Increment &uses |> ignore
            new RentedAsyncDisposableValue<'a>(this, value)

        /// Disposes the protected value if dispose marker is set and no other uses is detected
        member this.DisposeAsync() =
            if Interlocked.Decrement &uses = DisposeMarker then // 0 uses basically, only dispose marker is set
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
            member _.Dispose() = isDisposed <- true

    type Param = {
        Key: string
        Value: int
    }

    type DispAndParam = DisposableRefCounter<SomeDisposable> * Param

    let test123 =

        let inline refCount value = new DisposableRefCounter<_>(value)

        let collection = ConcurrentDictionary<string, DispAndParam>()

        let rentValue (param: Param) =
            match collection.TryGetValue param.Key with
            | true, (oldValue, oldParam) ->
                if oldParam <> param then
                    oldValue.RequestDispose()
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

        let rec getAndUseValue param f =
            use rented = rentValue param
            match rented.TryGetValue() with
            | ValueSome value ->
                f value
            | ValueNone ->
                getAndUseValue param f

        let rnd = Random()
        let getNextKey() = rnd.Next(0, 10).ToString()

        let tasks =
            let action() =
                let key = getNextKey()
                let value = DateTime.Now.Second % 10
                getAndUseValue { Key = key; Value = value } (fun value ->
                    for i in 0 .. 10 do
                        value.DoSomething() |> ignore)

            [| for i in 0 .. 100 do
                   Task.Run(action) |] |> Task.WaitAll

        tasks

//    type RefCountingConcurrentDictionary<'key, 'value when 'value :> IAsyncDisposable>() =
//        let dict = ConcurrentDictionary<'key, 'value AsyncDisposableRefCounter>()
//
//        member _.TryGetValue key =
//            match dict.TryGetValue key with
//            | true, value ->
//                ValueSome (value.Rent())
//            | _ -> ValueNone
//
//        member _.TryRemove key =
//            match dict.TryRemove key with
//            | true, value ->
//                value.RequestDispose()
//                true
//            | _ -> false
//
//        member _.TryAdd key value =
//            let value = AsyncDisposableRefCounter value
//            dict.TryAdd(key, value)
//
//        member _.SetValue key value =
//

    [<Struct; IsByRefLike>]
    type RefHolder4<'a when 'a: not struct> =
        [<DefaultValue(false)>] val mutable value1: 'a
        [<DefaultValue(false)>] val mutable private value2: 'a
        [<DefaultValue(false)>] val mutable private value3: 'a
        [<DefaultValue(false)>] val mutable private value4: 'a

    [<Struct; IsByRefLike>]
    type RefHolder8<'a when 'a: not struct> =
        [<DefaultValue(false)>] val mutable value1: RefHolder4<'a>
        [<DefaultValue(false)>] val mutable private value2: RefHolder4<'a>

    [<Struct; IsByRefLike>]
    type RefHolder16<'a when 'a: not struct> =
        [<DefaultValue(false)>] val mutable value1: RefHolder8<'a>
        [<DefaultValue(false)>] val mutable private value2: RefHolder8<'a>

    [<Struct; IsByRefLike>]
    type RefHolder32<'a when 'a: not struct> =
        [<DefaultValue(false)>] val mutable value1: RefHolder16<'a>
        [<DefaultValue(false)>] val mutable private value2: RefHolder16<'a>

    [<Struct; IsByRefLike>]
    type RefHolder64<'a when 'a: not struct> =
        [<DefaultValue(false)>] val mutable value1: RefHolder32<'a>
        [<DefaultValue(false)>] val mutable private value2: RefHolder32<'a>

    [<Struct; IsByRefLike>]
    type RefHolder128<'a when 'a: not struct> =
        [<DefaultValue(false)>] val mutable value1: RefHolder64<'a>
        [<DefaultValue(false)>] val mutable private value2: RefHolder64<'a>

    [<Struct; IsByRefLike>]
    type RefHolder256<'a when 'a: not struct> =
        [<DefaultValue(false)>] val mutable value1: RefHolder128<'a>
        [<DefaultValue(false)>] val mutable private value2: RefHolder128<'a>

    [<Struct; IsByRefLike>]
    type RefHolder512<'a when 'a: not struct> =
        [<DefaultValue(false)>] val mutable value1: RefHolder256<'a>
        [<DefaultValue(false)>] val mutable private value2: RefHolder256<'a>

    [<Struct; IsByRefLike; IsReadOnly>]
    type StackOrPooled<'a> =
        val private array: 'a array
        val private span: 'a Span

        new(arr) = { array = arr; span = arr.AsSpan() }
        new(span) = { array = null; span = span }

        member this.Span = this.span

        member this.Dispose() =
            if not (Object.ReferenceEquals(this.array, null)) then
                ArrayPool.Shared.Return this.array

        interface IDisposable with
            member this.Dispose() = this.Dispose()

    [<Struct; IsByRefLike; IsReadOnly>]
    type StackOrCustomPooled<'a> =
        val private array: 'a array
        val private pool: 'a ArrayPool
        val private span: 'a Span

        new(arr, pool) = { array = arr; pool = pool; span = arr.AsSpan() }
        new(span) = { array = null; pool = null; span = span }
        member this.Span = this.span

        member this.Dispose() =
            if not (Object.ReferenceEquals(this.array, null)) then
                this.pool.Return this.array

        interface IDisposable with
            member this.Dispose() = this.Dispose()

    let inline alloc<'a when 'a: unmanaged> len =
        let ptr = NativePtr.stackalloc<'a> len
        Span<'a>(NativePtr.toVoidPtr ptr, len)

    let inline allocOrPool<'a when 'a: unmanaged> len maxLen =
        if len > maxLen then
            new StackOrPooled<'a>(ArrayPool<'a>.Shared.Rent len)
        else
            new StackOrPooled<'a>(alloc<'a> len)

    let inline allocOrNew<'a when 'a: unmanaged> len maxLen =
        if len > maxLen then
            Span<'a>(Array.zeroCreate<'a> len)
        else
            alloc<'a> len

    let inline allocRef32OrNew<'a when 'a: not struct> len =
        if len <= 32 then
            let mutable values = RefHolder32<'a>()
            MemoryMarshal.CreateSpan(&values.value1.value1.value1.value1, 32)
        else
            Span(Array.zeroCreate len)

    let inline allocRef64OrNew<'a when 'a: not struct> len =
        if len <= 64 then
            let mutable values = RefHolder64<'a>()
            MemoryMarshal.CreateSpan(&values.value1.value1.value1.value1.value1, 64)
        else
            Span(Array.zeroCreate len)

    let inline allocRef128OrNew<'a when 'a: not struct> len =
        if len <= 128 then
            let mutable values = RefHolder128<'a>()
            MemoryMarshal.CreateSpan(&values.value1.value1.value1.value1.value1.value1, 128)
        else
            Span(Array.zeroCreate len)

    let inline allocRef256OrNew<'a when 'a: not struct> len =
        if len <= 256 then
            let mutable values = RefHolder256<'a>()
            MemoryMarshal.CreateSpan(&values.value1.value1.value1.value1.value1.value1.value1, 256)
        else
            Span(Array.zeroCreate len)

    let inline allocRef512OrNew<'a when 'a: not struct> len =
        if len <= 512 then
            let mutable values = RefHolder512<'a>()
            MemoryMarshal.CreateSpan(&values.value1.value1.value1.value1.value1.value1.value1.value1, 512)
        else
            Span(Array.zeroCreate len)

    let inline allocRef32OrPool<'a when 'a: not struct> len =
        if len <= 32 then
            let mutable values = RefHolder32<'a>()
            new StackOrPooled<'a>(MemoryMarshal.CreateSpan(&values.value1.value1.value1.value1, 32))
        else
            new StackOrPooled<'a>(ArrayPool<'a>.Shared.Rent len)

    let inline allocRef64OrPool<'a when 'a: not struct> len =
        if len <= 64 then
            let mutable values = RefHolder64<'a>()
            new StackOrPooled<'a>(MemoryMarshal.CreateSpan(&values.value1.value1.value1.value1.value1, 64))
        else
            new StackOrPooled<'a>(ArrayPool<'a>.Shared.Rent len)

    let inline allocRef128OrPool<'a when 'a: not struct> len =
        if len <= 128 then
            let mutable values = RefHolder128<'a>()
            new StackOrPooled<'a>(MemoryMarshal.CreateSpan(&values.value1.value1.value1.value1.value1.value1, 128))
        else
            new StackOrPooled<'a>(ArrayPool<'a>.Shared.Rent len)

    let inline allocRef256OrPool<'a when 'a: not struct> len =
        if len <= 256 then
            let mutable values = RefHolder256<'a>()
            new StackOrPooled<'a>(MemoryMarshal.CreateSpan(&values.value1.value1.value1.value1.value1.value1.value1, 256))
        else
            new StackOrPooled<'a>(ArrayPool<'a>.Shared.Rent len)

    let inline allocRef512OrPool<'a when 'a: not struct> len =
        if len <= 512 then
            let mutable values = RefHolder512<'a>()
            new StackOrPooled<'a>(MemoryMarshal.CreateSpan(&values.value1.value1.value1.value1.value1.value1.value1.value1, 512))
        else
            new StackOrPooled<'a>(ArrayPool<'a>.Shared.Rent len)
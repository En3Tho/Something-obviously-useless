namespace En3Tho.FSharp.GSeq

open System.Collections.Generic
open System.Collections.Immutable
open System.Runtime.CompilerServices
open En3Tho.FSharp.Extensions
open En3Tho.FSharp.Extensions.Byref.Operators
open En3Tho.FSharp.ComputationExpressions.ArrayPoolBasedBuilders

module GenericEnumeratorsImpl =
    type SStructEnumerator<'i, 'e when 'e: struct
                                  and 'e :> IEnumerator<'i>> = 'e

    [<Struct; NoComparison; NoEquality>]
    type StructIEnumeratorWrapper<'i>(enumerator: IEnumerator<'i>) =
        [<MethodImpl(MethodImplOptions.AggressiveInlining)>]
        member this.MoveNext() = enumerator.MoveNext()

        member this.Current with [<MethodImpl(MethodImplOptions.AggressiveInlining)>] get() =
            enumerator.Current

        member this.Dispose() = enumerator.Dispose()

        interface IEnumerator<'i> with
            member this.Current = enumerator.Current :> obj
            member this.Current = enumerator.Current
            member this.Dispose() = enumerator.Dispose()
            member this.MoveNext() = enumerator.MoveNext()
            member this.Reset() = enumerator.Reset()

    [<Struct; NoComparison; NoEquality>]
    type StructArrayEnumerator<'i> =
        val private array: 'i[]
        val mutable private index: int

        new (array) = { index = -1; array = array; }

        [<MethodImpl(MethodImplOptions.AggressiveInlining)>]
        member this.MoveNext() =
            &this.index +<- 1
            uint32 this.index < uint32 this.array.Length

        member this.Current with [<MethodImpl(MethodImplOptions.AggressiveInlining)>] get() =
            this.array.[this.index]

        member this.Dispose() = ()

        interface IEnumerator<'i> with
            member this.Current = this.Current :> obj
            member this.Current = this.Current
            member this.Dispose() = ()
            member this.MoveNext() = this.MoveNext()
            member this.Reset() = ()

    [<Struct; NoComparison; NoEquality>]
    type StructResizeArrayEnumerator<'i> =
        val private array: 'i ResizeArray
        val mutable private index: int

        new (array) = { index = -1; array = array; }

        [<MethodImpl(MethodImplOptions.AggressiveInlining)>]
        member this.MoveNext() =
            &this.index +<- 1
            uint32 this.index < uint32 this.array.Count

        member this.Current with [<MethodImpl(MethodImplOptions.AggressiveInlining)>] get() =
            this.array.[this.index]

        member this.Dispose() = ()

        interface IEnumerator<'i> with
            member this.Current = this.Current :> obj
            member this.Current = this.Current
            member this.Dispose() = ()
            member this.MoveNext() = this.MoveNext()
            member this.Reset() = ()

    [<Struct; NoComparison; NoEquality>]
    type StructIListEnumerator<'i> =
        val private array: 'i IList
        val mutable private index: int

        new (array) = { index = -1; array = array; }

        [<MethodImpl(MethodImplOptions.AggressiveInlining)>]
        member this.MoveNext() =
            &this.index +<- 1
            uint32 this.index < uint32 this.array.Count

        member this.Current with [<MethodImpl(MethodImplOptions.AggressiveInlining)>] get() =
            this.array.[this.index]

        member this.Dispose() = ()

        interface IEnumerator<'i> with
            member this.Current = this.Current :> obj
            member this.Current = this.Current
            member this.Dispose() = ()
            member this.MoveNext() = this.MoveNext()
            member this.Reset() = ()

    [<Struct; NoComparison; NoEquality>]
    type StructArrayRevEnumerator<'i> =
        val private array: 'i[]
        val mutable private index: int

        new (array) = { array = array; index = array.Length }

        [<MethodImpl(MethodImplOptions.AggressiveInlining)>]
        member this.MoveNext() =
            &this.index -<- 1
            uint32 this.index < uint32 this.array.Length

        member this.Current with [<MethodImpl(MethodImplOptions.AggressiveInlining)>] get() =
            this.array.[this.index]

        member this.Dispose() = ()

        interface IEnumerator<'i> with
            member this.Current = this.Current :> obj
            member this.Current = this.Current
            member this.Dispose() = ()
            member this.MoveNext() = this.MoveNext()
            member this.Reset() = ()

    [<Struct; NoComparison; NoEquality>]
    type StructResizeArrayRevEnumerator<'i> =
        val private array: 'i ResizeArray
        val mutable private index: int

        new (array) = { array = array; index = array.Count }

        [<MethodImpl(MethodImplOptions.AggressiveInlining)>]
        member this.MoveNext() =
            &this.index -<- 1
            uint32 this.index < uint32 this.array.Count

        member this.Current with [<MethodImpl(MethodImplOptions.AggressiveInlining)>] get() =
            this.array.[this.index]

        member this.Dispose() = ()

        interface IEnumerator<'i> with
            member this.Current = this.Current :> obj
            member this.Current = this.Current
            member this.Dispose() = ()
            member this.MoveNext() = this.MoveNext()
            member this.Reset() = ()

    [<Struct; NoComparison; NoEquality>]
    type StructIListRevEnumerator<'i> =
        val private array: 'i IList
        val mutable private index: int

        new (array) = { array = array; index = array.Count }

        [<MethodImpl(MethodImplOptions.AggressiveInlining)>]
        member this.MoveNext() =
            &this.index -<- 1
            uint32 this.index < uint32 this.array.Count

        member this.Current with [<MethodImpl(MethodImplOptions.AggressiveInlining)>] get() =
            this.array.[this.index]

        member this.Dispose() = ()

        interface IEnumerator<'i> with
            member this.Current = this.Current :> obj
            member this.Current = this.Current
            member this.Dispose() = ()
            member this.MoveNext() = this.MoveNext()
            member this.Reset() = ()

    [<Struct; NoComparison; NoEquality>]
    type StructImmutableArrayEnumerator<'i> =
        val private array: 'i ImmutableArray
        val mutable private index: int

        new (array) = { index = -1; array = array; }

        [<MethodImpl(MethodImplOptions.AggressiveInlining)>]
        member this.MoveNext() =
            &this.index +<- 1
            uint32 this.index < uint32 this.array.Length

        member this.Current with [<MethodImpl(MethodImplOptions.AggressiveInlining)>] get() =
            this.array.[this.index]

        member this.Dispose() = ()

        interface IEnumerator<'i> with
            member this.Current = this.Current :> obj
            member this.Current = this.Current
            member this.Dispose() = ()
            member this.MoveNext() = this.MoveNext()
            member this.Reset() = ()

    [<Struct; NoComparison; NoEquality>]
    type StructImmutableArrayRevEnumerator<'i> =
        val private array: 'i ImmutableArray
        val mutable private index: int

        new (array) = { index = -1; array = array; }

        [<MethodImpl(MethodImplOptions.AggressiveInlining)>]
        member this.MoveNext() =
            &this.index -<- 1
            uint32 this.index < uint32 this.array.Length

        member this.Current with [<MethodImpl(MethodImplOptions.AggressiveInlining)>] get() =
            this.array.[this.index]

        member this.Dispose() = ()

        interface IEnumerator<'i> with
            member this.Current = this.Current :> obj
            member this.Current = this.Current
            member this.Dispose() = ()
            member this.MoveNext() = this.MoveNext()
            member this.Reset() = ()

    [<Struct; NoComparison; NoEquality>]
    type StructFSharpListEnumerator<'i> =
        val mutable private list: 'i list
        val mutable private prev: 'i list

        new (list) = { prev = list; list = list; }

        [<MethodImpl(MethodImplOptions.AggressiveInlining)>]
        member this.MoveNext() =
            match this.list with
            | [] -> false
            | _ :: rest ->
                this.prev <- this.list
                this.list <- rest
                true
        member this.Current with [<MethodImpl(MethodImplOptions.AggressiveInlining)>] get() = this.prev.Head

        member this.Dispose() = ()

        interface IEnumerator<'i> with
            member this.Current = this.Current :> obj
            member this.Current = this.Current
            member this.Dispose() = ()
            member this.MoveNext() = this.MoveNext()
            member this.Reset() = ()

    [<Struct; NoComparison; NoEquality>]
    type StructMapEnumerator<'i, 'res, 'e when 'e: struct
                                           and 'e :> IEnumerator<'i>> =

        val mutable private enumerator: SStructEnumerator<'i, 'e>
        val private map: 'i -> 'res

        new (map, enumerator) = { enumerator = enumerator; map = map; }

        [<MethodImpl(MethodImplOptions.AggressiveInlining)>]
        member this.MoveNext() = this.enumerator.MoveNext()

        member this.Current with [<MethodImpl(MethodImplOptions.AggressiveInlining)>] get() =
            this.enumerator.Current |> this.map

        member this.Dispose() = ()

        interface IEnumerator<'res> with
            member this.Current = this.Current :> obj
            member this.Current = this.Current
            member this.Dispose() = ()
            member this.MoveNext() = this.MoveNext()
            member this.Reset() = ()

    [<Struct; NoComparison; NoEquality>]
    type StructMapVEnumerator<'i, 'state, 'res, 'e when 'e: struct
                                           and 'e :> IEnumerator<'i>> =

        val mutable private enumerator: SStructEnumerator<'i, 'e>
        val private state: 'state
        val private map: OptimizedClosures.FSharpFunc<'state, 'i, 'res>

        new (state, map, enumerator) =
            { enumerator = enumerator; map = OptimizedClosures.FSharpFunc<_,_,_>.Adapt map; state = state }

        [<MethodImpl(MethodImplOptions.AggressiveInlining)>]
        member this.MoveNext() =
            this.enumerator.MoveNext()

        member this.Current with [<MethodImpl(MethodImplOptions.AggressiveInlining)>] get() =
            this.map.Invoke(this.state, this.enumerator.Current)

        member this.Dispose() = ()

        interface IEnumerator<'res> with
            member this.Current = this.Current :> obj
            member this.Current = this.Current
            member this.Dispose() = ()
            member this.MoveNext() = this.MoveNext()
            member this.Reset() = ()

    [<Struct; NoComparison; NoEquality>]
    type StructMapiEnumerator<'i, 'res, 'e when 'e: struct
                                           and 'e :> IEnumerator<'i>> =

        val mutable private enumerator: SStructEnumerator<'i, 'e>
        val mutable private count: int
        val private map: OptimizedClosures.FSharpFunc<int, 'i, 'res>

        new (map, enumerator) =
            { enumerator = enumerator; map = OptimizedClosures.FSharpFunc<_,_,_>.Adapt map; count = -1 }

        [<MethodImpl(MethodImplOptions.AggressiveInlining)>]
        member this.MoveNext() =
            &this.count +<- 1
            this.enumerator.MoveNext()

        member this.Current with [<MethodImpl(MethodImplOptions.AggressiveInlining)>] get() =
            this.map.Invoke(this.count, this.enumerator.Current)

        member this.Dispose() = ()

        interface IEnumerator<'res> with
            member this.Current = this.Current :> obj
            member this.Current = this.Current
            member this.Dispose() = ()
            member this.MoveNext() = this.MoveNext()
            member this.Reset() = ()

    [<Struct; NoComparison; NoEquality>]
    type StructMapiVEnumerator<'i, 'state, 'res, 'e when 'e: struct
                                           and 'e :> IEnumerator<'i>> =

        val mutable private enumerator: SStructEnumerator<'i, 'e>
        val mutable private count: int
        val private state: 'state
        val private map: OptimizedClosures.FSharpFunc<int, 'state, 'i, 'res>

        new (state, map, enumerator) =
            { enumerator = enumerator; map = OptimizedClosures.FSharpFunc<_,_,_,_>.Adapt map; count = -1; state = state }

        [<MethodImpl(MethodImplOptions.AggressiveInlining)>]
        member this.MoveNext() =
            &this.count +<- 1
            this.enumerator.MoveNext()

        member this.Current with [<MethodImpl(MethodImplOptions.AggressiveInlining)>] get() =
            this.map.Invoke(this.count, this.state, this.enumerator.Current)

        member this.Dispose() = ()

        interface IEnumerator<'res> with
            member this.Current = this.Current :> obj
            member this.Current = this.Current
            member this.Dispose() = ()
            member this.MoveNext() = this.MoveNext()
            member this.Reset() = ()

    [<Struct; NoComparison; NoEquality>]
    type StructMap2Enumerator<'i, 'i2, 'res, 'e, 'e2 when 'e: struct
                                                      and 'e :> IEnumerator<'i>
                                                      and 'e2: struct
                                                      and 'e2 :> IEnumerator<'i2>> =

        val mutable private enumerator: SStructEnumerator<'i, 'e>
        val mutable private enumerator2: SStructEnumerator<'i2, 'e2>
        val private map: OptimizedClosures.FSharpFunc<'i2, 'i, 'res>

        new (map, enumerator, enumerator2) =
            { enumerator = enumerator; enumerator2 = enumerator2; map = OptimizedClosures.FSharpFunc<_,_,_>.Adapt map; }

        [<MethodImpl(MethodImplOptions.AggressiveInlining)>]
        member this.MoveNext() = this.enumerator.MoveNext() && this.enumerator2.MoveNext()

        member this.Current with [<MethodImpl(MethodImplOptions.AggressiveInlining)>] get() =
            this.map.Invoke(this.enumerator2.Current, this.enumerator.Current)

        member this.Dispose() = ()

        interface IEnumerator<'res> with
            member this.Current = this.Current :> obj
            member this.Current = this.Current
            member this.Dispose() = ()
            member this.MoveNext() = this.MoveNext()
            member this.Reset() = ()

     [<Struct; NoComparison; NoEquality>]
    type StructMap2VEnumerator<'i, 'i2, 'state, 'res, 'e, 'e2 when 'e: struct
                                                      and 'e :> IEnumerator<'i>
                                                      and 'e2: struct
                                                      and 'e2 :> IEnumerator<'i2>> =

        val mutable private enumerator: SStructEnumerator<'i, 'e>
        val mutable private enumerator2: SStructEnumerator<'i2, 'e2>
        val private map: OptimizedClosures.FSharpFunc<'state, 'i2, 'i, 'res>
        val private state: 'state

        new (state, map, enumerator, enumerator2) =
            { enumerator = enumerator; enumerator2 = enumerator2; map = OptimizedClosures.FSharpFunc<_,_,_,_>.Adapt map; state = state }

        [<MethodImpl(MethodImplOptions.AggressiveInlining)>]
        member this.MoveNext() = this.enumerator.MoveNext() && this.enumerator2.MoveNext()

        member this.Current with [<MethodImpl(MethodImplOptions.AggressiveInlining)>] get() =
            this.map.Invoke(this.state, this.enumerator2.Current, this.enumerator.Current)

        member this.Dispose() = ()

        interface IEnumerator<'res> with
            member this.Current = this.Current :> obj
            member this.Current = this.Current
            member this.Dispose() = ()
            member this.MoveNext() = this.MoveNext()
            member this.Reset() = ()

    [<Struct; NoComparison; NoEquality>]
    type StructMapi2Enumerator<'i, 'i2, 'res, 'e, 'e2 when 'e: struct
                                                      and 'e :> IEnumerator<'i>
                                                      and 'e2: struct
                                                      and 'e2 :> IEnumerator<'i2>> =

        val mutable private enumerator: SStructEnumerator<'i, 'e>
        val mutable private enumerator2: SStructEnumerator<'i2, 'e2>
        val mutable private count: int
        val private map: OptimizedClosures.FSharpFunc<int, 'i2, 'i, 'res>

        new (map, enumerator, enumerator2) =
            { enumerator = enumerator; enumerator2 = enumerator2; map = OptimizedClosures.FSharpFunc<_,_,_,_>.Adapt map; count = -1; }

        [<MethodImpl(MethodImplOptions.AggressiveInlining)>]
        member this.MoveNext() =
            &this.count +<- 1
            this.enumerator.MoveNext()
            && this.enumerator2.MoveNext()

        member this.Current with [<MethodImpl(MethodImplOptions.AggressiveInlining)>] get() =
            this.map.Invoke(this.count, this.enumerator2.Current, this.enumerator.Current)

        member this.Dispose() = ()

        interface IEnumerator<'res> with
            member this.Current = this.Current :> obj
            member this.Current = this.Current
            member this.Dispose() = ()
            member this.MoveNext() = this.MoveNext()
            member this.Reset() = ()

    [<Struct; NoComparison; NoEquality>]
    type StructMapi2VEnumerator<'i, 'i2, 'state, 'res, 'e, 'e2 when 'e: struct
                                                      and 'e :> IEnumerator<'i>
                                                      and 'e2: struct
                                                      and 'e2 :> IEnumerator<'i2>> =

        val mutable private enumerator: SStructEnumerator<'i, 'e>
        val mutable private enumerator2: SStructEnumerator<'i2, 'e2>
        val mutable private count: int
        val private map: OptimizedClosures.FSharpFunc<int, 'state, 'i2, 'i, 'res>
        val private state: 'state

        new (state, map, enumerator, enumerator2) =
            { enumerator = enumerator; enumerator2 = enumerator2; map = OptimizedClosures.FSharpFunc<_,_,_,_,_>.Adapt map; count = -1; state = state }

        [<MethodImpl(MethodImplOptions.AggressiveInlining)>]
        member this.MoveNext() =
            &this.count +<- 1
            this.enumerator.MoveNext()
            && this.enumerator2.MoveNext()

        member this.Current with [<MethodImpl(MethodImplOptions.AggressiveInlining)>] get() =
            this.map.Invoke(this.count, this.state, this.enumerator2.Current, this.enumerator.Current)

        member this.Dispose() = ()

        interface IEnumerator<'res> with
            member this.Current = this.Current :> obj
            member this.Current = this.Current
            member this.Dispose() = ()
            member this.MoveNext() = this.MoveNext()
            member this.Reset() = ()

    [<Struct; NoComparison; NoEquality>]
    type StructMap3Enumerator<'i, 'i2, 'i3, 'res, 'e, 'e2, 'e3 when 'e: struct
                                                                and 'e :> IEnumerator<'i>
                                                                and 'e2: struct
                                                                and 'e2 :> IEnumerator<'i2>
                                                                and 'e3: struct
                                                                and 'e3 :> IEnumerator<'i3>> =

        val mutable private enumerator: SStructEnumerator<'i, 'e>
        val mutable private enumerator2: SStructEnumerator<'i2, 'e2>
        val mutable private enumerator3: SStructEnumerator<'i3, 'e3>
        val private map: OptimizedClosures.FSharpFunc<'i2, 'i3, 'i, 'res>

        new (map, enumerator, enumerator2, enumerator3) =
            { enumerator = enumerator; enumerator2 = enumerator2; enumerator3 = enumerator3; map = OptimizedClosures.FSharpFunc<_,_,_,_>.Adapt map; }

        [<MethodImpl(MethodImplOptions.AggressiveInlining)>]
        member this.MoveNext() =
            this.enumerator.MoveNext()
            && this.enumerator2.MoveNext()
            && this.enumerator3.MoveNext()

        member this.Current with [<MethodImpl(MethodImplOptions.AggressiveInlining)>] get() =
            this.map.Invoke(this.enumerator2.Current, this.enumerator3.Current, this.enumerator.Current)

        member this.Dispose() = ()

        interface IEnumerator<'res> with
            member this.Current = this.Current :> obj
            member this.Current = this.Current
            member this.Dispose() = ()
            member this.MoveNext() = this.MoveNext()
            member this.Reset() = ()

    [<Struct; NoComparison; NoEquality>]
    type StructMap3VEnumerator<'i, 'i2, 'i3, 'state, 'res, 'e, 'e2, 'e3 when 'e: struct
                                                                and 'e :> IEnumerator<'i>
                                                                and 'e2: struct
                                                                and 'e2 :> IEnumerator<'i2>
                                                                and 'e3: struct
                                                                and 'e3 :> IEnumerator<'i3>> =

        val mutable private enumerator: SStructEnumerator<'i, 'e>
        val mutable private enumerator2: SStructEnumerator<'i2, 'e2>
        val mutable private enumerator3: SStructEnumerator<'i3, 'e3>
        val private map: OptimizedClosures.FSharpFunc<'state, 'i2, 'i3, 'i, 'res>
        val private state: 'state

        new (state, map, enumerator, enumerator2, enumerator3) =
            { enumerator = enumerator; enumerator2 = enumerator2; enumerator3 = enumerator3; map = OptimizedClosures.FSharpFunc<_,_,_,_,_>.Adapt map; state = state }

        [<MethodImpl(MethodImplOptions.AggressiveInlining)>]
        member this.MoveNext() =
            this.enumerator.MoveNext()
            && this.enumerator2.MoveNext()
            && this.enumerator3.MoveNext()

        member this.Current with [<MethodImpl(MethodImplOptions.AggressiveInlining)>] get() =
            this.map.Invoke(this.state, this.enumerator2.Current, this.enumerator3.Current, this.enumerator.Current)

        member this.Dispose() = ()

        interface IEnumerator<'res> with
            member this.Current = this.Current :> obj
            member this.Current = this.Current
            member this.Dispose() = ()
            member this.MoveNext() = this.MoveNext()
            member this.Reset() = ()

    [<Struct; NoComparison; NoEquality>]
    type StructMapi3Enumerator<'i, 'i2, 'i3, 'res, 'e, 'e2, 'e3 when 'e: struct
                                                                and 'e :> IEnumerator<'i>
                                                                and 'e2: struct
                                                                and 'e2 :> IEnumerator<'i2>
                                                                and 'e3: struct
                                                                and 'e3 :> IEnumerator<'i3>> =

        val mutable private enumerator: SStructEnumerator<'i, 'e>
        val mutable private enumerator2: SStructEnumerator<'i2, 'e2>
        val mutable private enumerator3: SStructEnumerator<'i3, 'e3>
        val mutable private count: int
        val private map: OptimizedClosures.FSharpFunc<int, 'i2, 'i3, 'i, 'res>

        new (map, enumerator, enumerator2, enumerator3) =
            { enumerator = enumerator; enumerator2 = enumerator2; enumerator3 = enumerator3; map = OptimizedClosures.FSharpFunc<_,_,_,_,_>.Adapt map; count = -1 }

        [<MethodImpl(MethodImplOptions.AggressiveInlining)>]
        member this.MoveNext() =
            &this.count +<- 1
            this.enumerator.MoveNext()
            && this.enumerator2.MoveNext()
            && this.enumerator3.MoveNext()

        member this.Current with [<MethodImpl(MethodImplOptions.AggressiveInlining)>] get() =
            this.map.Invoke(this.count, this.enumerator2.Current, this.enumerator3.Current, this.enumerator.Current)

        member this.Dispose() = ()

        interface IEnumerator<'res> with
            member this.Current = this.Current :> obj
            member this.Current = this.Current
            member this.Dispose() = ()
            member this.MoveNext() = this.MoveNext()
            member this.Reset() = ()

    [<Struct; NoComparison; NoEquality>]
    type StructMapi3VEnumerator<'i, 'i2, 'i3, 'state, 'res, 'e, 'e2, 'e3 when 'e: struct
                                                                and 'e :> IEnumerator<'i>
                                                                and 'e2: struct
                                                                and 'e2 :> IEnumerator<'i2>
                                                                and 'e3: struct
                                                                and 'e3 :> IEnumerator<'i3>> =

        val mutable private enumerator: SStructEnumerator<'i, 'e>
        val mutable private enumerator2: SStructEnumerator<'i2, 'e2>
        val mutable private enumerator3: SStructEnumerator<'i3, 'e3>
        val mutable private count: int
        val private map: OptimizedClosures.FSharpFunc<int, 'state, 'i2, 'i3, 'i, 'res>
        val private state: 'state

        new (state, map, enumerator, enumerator2, enumerator3) =
            { enumerator = enumerator; enumerator2 = enumerator2; enumerator3 = enumerator3; map = OptimizedClosures.FSharpFunc<_,_,_,_,_,_>.Adapt map; count = -1; state = state }

        [<MethodImpl(MethodImplOptions.AggressiveInlining)>]
        member this.MoveNext() =
            &this.count +<- 1
            this.enumerator.MoveNext()
            && this.enumerator2.MoveNext()
            && this.enumerator3.MoveNext()

        member this.Current with [<MethodImpl(MethodImplOptions.AggressiveInlining)>] get() =
            this.map.Invoke(this.count, this.state, this.enumerator2.Current, this.enumerator3.Current, this.enumerator.Current)

        member this.Dispose() = ()

        interface IEnumerator<'res> with
            member this.Current = this.Current :> obj
            member this.Current = this.Current
            member this.Dispose() = ()
            member this.MoveNext() = this.MoveNext()
            member this.Reset() = ()

    [<Struct; NoComparison; NoEquality>]
    type StructFilterEnumerator<'i, 'e when 'e: struct
                                        and 'e :> IEnumerator<'i>> =

        val mutable private enumerator: SStructEnumerator<'i, 'e>
        val private filter: 'i -> bool

        new (filter, enumerator) = { enumerator = enumerator; filter = filter; }

        [<MethodImpl(MethodImplOptions.AggressiveInlining)>]
        member this.MoveNext() =
            let mutable found = false
            while not found && this.enumerator.MoveNext() do
                found <- this.enumerator.Current |> this.filter
            found
        member this.Current with [<MethodImpl(MethodImplOptions.AggressiveInlining)>] get() =
            this.enumerator.Current

        member this.Dispose() = ()

        interface IEnumerator<'i> with
            member this.Current = this.Current :> obj
            member this.Current = this.Current
            member this.Dispose() = ()
            member this.MoveNext() = this.MoveNext()
            member this.Reset() = ()

    [<Struct; NoComparison; NoEquality>]
    type StructFilterVEnumerator<'i, 'state, 'e when 'e: struct
                                        and 'e :> IEnumerator<'i>> =

        val mutable private enumerator: SStructEnumerator<'i, 'e>
        val private filter: OptimizedClosures.FSharpFunc<'state, 'i, bool>
        val private state: 'state

        new (state, filter, enumerator) = { enumerator = enumerator; filter = OptimizedClosures.FSharpFunc<_,_,_>.Adapt filter; state = state }

        [<MethodImpl(MethodImplOptions.AggressiveInlining)>]
        member this.MoveNext() =
            let mutable found = false
            while not found && this.enumerator.MoveNext() do
                found <- this.filter.Invoke(this.state, this.enumerator.Current)
            found
        member this.Current with [<MethodImpl(MethodImplOptions.AggressiveInlining)>] get() =
            this.enumerator.Current

        member this.Dispose() = ()

        interface IEnumerator<'i> with
            member this.Current = this.Current :> obj
            member this.Current = this.Current
            member this.Dispose() = ()
            member this.MoveNext() = this.MoveNext()
            member this.Reset() = ()

    [<Struct; NoComparison; NoEquality>]
    type StructTakeEnumerator<'i, 'e when 'e: struct
                                      and 'e :> IEnumerator<'i>> =

        val mutable private enumerator: SStructEnumerator<'i, 'e>
        val mutable private count: int

        new (count, enumerator) = { enumerator = enumerator; count = count; }

        [<MethodImpl(MethodImplOptions.AggressiveInlining)>]
        member this.MoveNext() =
            let oldCount = this.count
            &this.count -<- 1
            oldCount > 0 && this.enumerator.MoveNext()

        member this.Current with [<MethodImpl(MethodImplOptions.AggressiveInlining)>] get() =
            this.enumerator.Current

        member this.Dispose() = ()

        interface IEnumerator<'i> with
            member this.Current = this.Current :> obj
            member this.Current = this.Current
            member this.Dispose() = ()
            member this.MoveNext() = this.MoveNext()
            member this.Reset() = ()

    [<Struct; NoComparison; NoEquality>]
    type StructTakeWhileEnumerator<'i, 'e when 'e: struct
                                           and 'e :> IEnumerator<'i>> =

        val mutable private enumerator: SStructEnumerator<'i, 'e>
        val private filter: 'i -> bool

        new (filter, enumerator) = { enumerator = enumerator; filter = filter }

        [<MethodImpl(MethodImplOptions.AggressiveInlining)>]
        member this.MoveNext() =
            this.enumerator.MoveNext() && this.filter this.enumerator.Current

        member this.Current with [<MethodImpl(MethodImplOptions.AggressiveInlining)>] get() =
            this.enumerator.Current

        member this.Dispose() = ()

        interface IEnumerator<'i> with
            member this.Current = this.Current :> obj
            member this.Current = this.Current
            member this.Dispose() = ()
            member this.MoveNext() = this.MoveNext()
            member this.Reset() = ()

    [<Struct; NoComparison; NoEquality>]
    type StructTakeWhileVEnumerator<'i, 'state, 'e when 'e: struct
                                           and 'e :> IEnumerator<'i>> =

        val mutable private enumerator: SStructEnumerator<'i, 'e>
        val private filter: OptimizedClosures.FSharpFunc<'state, 'i, bool>
        val private state: 'state

        new (state, filter, enumerator) = { enumerator = enumerator; filter = OptimizedClosures.FSharpFunc<_,_,_>.Adapt filter; state = state }

        [<MethodImpl(MethodImplOptions.AggressiveInlining)>]
        member this.MoveNext() =
            this.enumerator.MoveNext() && this.filter.Invoke(this.state, this.enumerator.Current)

        member this.Current with [<MethodImpl(MethodImplOptions.AggressiveInlining)>] get() =
            this.enumerator.Current

        member this.Dispose() = ()

        interface IEnumerator<'i> with
            member this.Current = this.Current :> obj
            member this.Current = this.Current
            member this.Dispose() = ()
            member this.MoveNext() = this.MoveNext()
            member this.Reset() = ()

    [<Struct; NoComparison; NoEquality>]
    type StructSkipEnumerator<'i, 'e when 'e: struct
                                      and 'e :> IEnumerator<'i>> =

        val mutable private enumerator: SStructEnumerator<'i, 'e>
        val mutable private count: int

        new (count, enumerator) = { enumerator = enumerator; count = count; }

        [<MethodImpl(MethodImplOptions.AggressiveInlining)>]
        member this.MoveNext() =
            while this.count > 0 && this.enumerator.MoveNext() do
                &this.count -<- 1
            this.enumerator.MoveNext()

        member this.Current with [<MethodImpl(MethodImplOptions.AggressiveInlining)>] get() =
            this.enumerator.Current

        member this.Dispose() = ()

        interface IEnumerator<'i> with
            member this.Current = this.Current :> obj
            member this.Current = this.Current
            member this.Dispose() = ()
            member this.MoveNext() = this.MoveNext()
            member this.Reset() = ()

    [<Struct; NoComparison; NoEquality>]
    type StructSkipWhileEnumerator<'i, 'e when 'e: struct
                                           and 'e :> IEnumerator<'i>> =

        val mutable private enumerator: SStructEnumerator<'i, 'e>
        val private filter: 'i -> bool
        val mutable private flag: int

        new (filter, enumerator) = { enumerator = enumerator; filter = filter; flag = 0 }

        [<MethodImpl(MethodImplOptions.AggressiveInlining)>]
        member this.MoveNext() =
            match this.flag with
            | 0 ->
                let mutable skip = true
                while skip && this.enumerator.MoveNext() do
                    skip <- this.filter this.enumerator.Current
                this.flag <- 1
                not skip
            | _ ->
                this.enumerator.MoveNext()

        member this.Current with [<MethodImpl(MethodImplOptions.AggressiveInlining)>] get() =
            this.enumerator.Current

        member this.Dispose() = ()

        interface IEnumerator<'i> with
            member this.Current = this.Current :> obj
            member this.Current = this.Current
            member this.Dispose() = ()
            member this.MoveNext() = this.MoveNext()
            member this.Reset() = ()

    [<Struct; NoComparison; NoEquality>]
    type StructSkipWhileVEnumerator<'i, 'state, 'e when 'e: struct
                                           and 'e :> IEnumerator<'i>> =

        val mutable private enumerator: SStructEnumerator<'i, 'e>
        val private filter: OptimizedClosures.FSharpFunc<'state, 'i, bool>
        val mutable private flag: int
        val private state: 'state

        new (state, filter, enumerator) = { enumerator = enumerator; filter = OptimizedClosures.FSharpFunc<_,_,_>.Adapt filter; flag = 0; state = state }

        [<MethodImpl(MethodImplOptions.AggressiveInlining)>]
        member this.MoveNext() =
            match this.flag with
            | 0 ->
                let mutable skip = true
                while skip && this.enumerator.MoveNext() do
                    skip <- this.filter.Invoke(this.state, this.enumerator.Current)
                this.flag <- 1
                not skip
            | _ ->
                this.enumerator.MoveNext()

        member this.Current with [<MethodImpl(MethodImplOptions.AggressiveInlining)>] get() =
            this.enumerator.Current

        member this.Dispose() = ()

        interface IEnumerator<'i> with
            member this.Current = this.Current :> obj
            member this.Current = this.Current
            member this.Dispose() = ()
            member this.MoveNext() = this.MoveNext()
            member this.Reset() = ()

    [<Struct; NoComparison; NoEquality>]
    type StructChooseEnumerator<'i, 'res, 'e when 'e: struct
                                              and 'e :> IEnumerator<'i>> =
        val mutable private enumerator: SStructEnumerator<'i, 'e>
        val mutable private current: 'res option
        val private chooser: 'i -> 'res option

        new (chooser, enumerator) = { enumerator = enumerator; chooser = chooser; current = None }

        [<MethodImpl(MethodImplOptions.AggressiveInlining)>]
        member this.MoveNext() =
            this.current <- None
            while this.current.IsNone && this.enumerator.MoveNext() do
                this.current <- this.chooser this.enumerator.Current
            this.current.IsSome
        member this.Current with [<MethodImpl(MethodImplOptions.AggressiveInlining)>] get() =
            this.current |> Option.get

        member this.Dispose() = ()

        interface IEnumerator<'res> with
            member this.Current = this.Current :> obj
            member this.Current = this.Current
            member this.Dispose() = ()
            member this.MoveNext() = this.MoveNext()
            member this.Reset() = ()

    [<Struct; NoComparison; NoEquality>]
    type StructChooseVEnumerator<'i, 'state, 'res, 'e when 'e: struct
                                                         and 'e :> IEnumerator<'i>> =

        val mutable private enumerator: SStructEnumerator<'i, 'e>
        val mutable private current: 'res option
        val private chooser: OptimizedClosures.FSharpFunc<'state, 'i, 'res option>
        val private state: 'state

        new (state, chooser, enumerator) = { enumerator = enumerator; chooser = OptimizedClosures.FSharpFunc<_,_,_>.Adapt chooser; current = None; state = state }

        [<MethodImpl(MethodImplOptions.AggressiveInlining)>]
        member this.MoveNext() =
            this.current <- None
            while this.current.IsNone && this.enumerator.MoveNext() do
                this.current <- this.chooser.Invoke(this.state, this.enumerator.Current)
            this.current.IsSome
        member this.Current with [<MethodImpl(MethodImplOptions.AggressiveInlining)>] get() =
            this.current |> Option.get

        member this.Dispose() = ()

        interface IEnumerator<'res> with
            member this.Current = this.Current :> obj
            member this.Current = this.Current
            member this.Dispose() = ()
            member this.MoveNext() = this.MoveNext()
            member this.Reset() = ()

    [<Struct; NoComparison; NoEquality>]
    type StructChoose2Enumerator<'i, 'i2, 'res, 'e, 'e2 when 'e: struct
                                                         and 'e :> IEnumerator<'i>
                                                         and 'e2: struct
                                                         and 'e2 :> IEnumerator<'i2>> =
        val mutable private enumerator: SStructEnumerator<'i, 'e>
        val mutable private enumerator2: SStructEnumerator<'i2, 'e2>
        val mutable private current: 'res option
        val private chooser: OptimizedClosures.FSharpFunc<'i2, 'i, 'res option>

        new (chooser, enumerator, enumerator2) = { enumerator = enumerator; enumerator2 = enumerator2; chooser = OptimizedClosures.FSharpFunc<_,_,_>.Adapt chooser; current = None }

        [<MethodImpl(MethodImplOptions.AggressiveInlining)>]
        member this.MoveNext() =
            this.current <- None
            while this.current.IsNone && this.enumerator.MoveNext() && this.enumerator2.MoveNext() do
                this.current <- this.chooser.Invoke(this.enumerator2.Current, this.enumerator.Current)
            this.current.IsSome
        member this.Current with [<MethodImpl(MethodImplOptions.AggressiveInlining)>] get() =
            this.current |> Option.get

        member this.Dispose() = ()

        interface IEnumerator<'res> with
            member this.Current = this.Current :> obj
            member this.Current = this.Current
            member this.Dispose() = ()
            member this.MoveNext() = this.MoveNext()
            member this.Reset() = ()

    [<Struct; NoComparison; NoEquality>]
    type StructChoose2VEnumerator<'i, 'i2, 'state, 'res, 'e, 'e2 when 'e: struct
                                                         and 'e :> IEnumerator<'i>
                                                         and 'e2: struct
                                                         and 'e2 :> IEnumerator<'i2>> =
        val mutable private enumerator: SStructEnumerator<'i, 'e>
        val mutable private enumerator2: SStructEnumerator<'i2, 'e2>
        val mutable private current: 'res option
        val private chooser: OptimizedClosures.FSharpFunc<'state, 'i2, 'i, 'res option>
        val private state: 'state

        new (state, chooser, enumerator, enumerator2) =
            { enumerator = enumerator; enumerator2 = enumerator2; chooser = OptimizedClosures.FSharpFunc<_,_,_,_>.Adapt chooser; current = None; state = state }

        [<MethodImpl(MethodImplOptions.AggressiveInlining)>]
        member this.MoveNext() =
            this.current <- None
            while this.current.IsNone && this.enumerator.MoveNext() && this.enumerator2.MoveNext() do
                this.current <- this.chooser.Invoke(this.state, this.enumerator2.Current, this.enumerator.Current)
            this.current.IsSome
        member this.Current with [<MethodImpl(MethodImplOptions.AggressiveInlining)>] get() =
            this.current |> Option.get

        member this.Dispose() = ()

        interface IEnumerator<'res> with
            member this.Current = this.Current :> obj
            member this.Current = this.Current
            member this.Dispose() = ()
            member this.MoveNext() = this.MoveNext()
            member this.Reset() = ()

    [<Struct; NoComparison; NoEquality>]
    type StructChoose3Enumerator<'i, 'i2, 'i3, 'res, 'e, 'e2, 'e3 when 'e: struct
                                                                   and 'e :> IEnumerator<'i>
                                                                   and 'e2: struct
                                                                   and 'e2 :> IEnumerator<'i2>
                                                                   and 'e3: struct
                                                                   and 'e3 :> IEnumerator<'i3>> =
        val mutable private enumerator: SStructEnumerator<'i, 'e>
        val mutable private enumerator2: SStructEnumerator<'i2, 'e2>
        val mutable private enumerator3: SStructEnumerator<'i3, 'e3>
        val mutable private current: 'res option
        val private chooser: OptimizedClosures.FSharpFunc<'i2, 'i3, 'i, 'res option>

        new (chooser, enumerator, enumerator2, enumerator3) =
            { enumerator = enumerator; enumerator2 = enumerator2; enumerator3 = enumerator3; chooser = OptimizedClosures.FSharpFunc<_,_,_,_>.Adapt chooser; current = None }

        [<MethodImpl(MethodImplOptions.AggressiveInlining)>]
        member this.MoveNext() =
            this.current <- None
            while this.current.IsNone && this.enumerator.MoveNext() && this.enumerator2.MoveNext() && this.enumerator3.MoveNext() do
                this.current <- this.chooser.Invoke(this.enumerator2.Current, this.enumerator3.Current, this.enumerator.Current)
            this.current.IsSome
        member this.Current with [<MethodImpl(MethodImplOptions.AggressiveInlining)>] get() =
            this.current |> Option.get

        member this.Dispose() = ()

        interface IEnumerator<'res> with
            member this.Current = this.Current :> obj
            member this.Current = this.Current
            member this.Dispose() = ()
            member this.MoveNext() = this.MoveNext()
            member this.Reset() = ()

    [<Struct; NoComparison; NoEquality>]
    type StructChoose3VEnumerator<'i, 'i2, 'i3, 'state, 'res, 'e, 'e2, 'e3 when 'e: struct
                                                                   and 'e :> IEnumerator<'i>
                                                                   and 'e2: struct
                                                                   and 'e2 :> IEnumerator<'i2>
                                                                   and 'e3: struct
                                                                   and 'e3 :> IEnumerator<'i3>> =
        val mutable private enumerator: SStructEnumerator<'i, 'e>
        val mutable private enumerator2: SStructEnumerator<'i2, 'e2>
        val mutable private enumerator3: SStructEnumerator<'i3, 'e3>
        val mutable private current: 'res option
        val private chooser: OptimizedClosures.FSharpFunc<'state, 'i2, 'i3, 'i, 'res option>
        val private state: 'state

        new (state, chooser, enumerator, enumerator2, enumerator3) =
            { enumerator = enumerator; enumerator2 = enumerator2; enumerator3 = enumerator3; chooser = OptimizedClosures.FSharpFunc<_,_,_,_,_>.Adapt chooser; current = None; state = state }

        [<MethodImpl(MethodImplOptions.AggressiveInlining)>]
        member this.MoveNext() =
            this.current <- None
            while this.current.IsNone && this.enumerator.MoveNext() && this.enumerator2.MoveNext() && this.enumerator3.MoveNext() do
                this.current <- this.chooser.Invoke(this.state, this.enumerator2.Current, this.enumerator3.Current, this.enumerator.Current)
            this.current.IsSome
        member this.Current with [<MethodImpl(MethodImplOptions.AggressiveInlining)>] get() =
            this.current |> Option.get

        member this.Dispose() = ()

        interface IEnumerator<'res> with
            member this.Current = this.Current :> obj
            member this.Current = this.Current
            member this.Dispose() = ()
            member this.MoveNext() = this.MoveNext()
            member this.Reset() = ()

    [<Struct; NoComparison; NoEquality>]
    type StructValueChooseEnumerator<'i, 'res, 'e when 'e: struct
                                                   and 'e :> IEnumerator<'i>> =
        val mutable private enumerator: SStructEnumerator<'i, 'e>
        val mutable private current: 'res voption
        val private chooser: 'i -> 'res voption

        new (chooser, enumerator) = { enumerator = enumerator; chooser = chooser; current = ValueNone }

        [<MethodImpl(MethodImplOptions.AggressiveInlining)>]
        member this.MoveNext() =
            this.current <- ValueNone
            while this.current.IsNone && this.enumerator.MoveNext() do
                this.current <- this.chooser this.enumerator.Current
            this.current.IsSome
        member this.Current with [<MethodImpl(MethodImplOptions.AggressiveInlining)>] get() =
            this.current |> ValueOption.get

        member this.Dispose() = ()

        interface IEnumerator<'res> with
            member this.Current = this.Current :> obj
            member this.Current = this.Current
            member this.Dispose() = ()
            member this.MoveNext() = this.MoveNext()
            member this.Reset() = ()

    [<Struct; NoComparison; NoEquality>]
    type StructValueChooseVEnumerator<'i, 'state, 'res, 'e when 'e: struct
                                                   and 'e :> IEnumerator<'i>> =
        val mutable private enumerator: SStructEnumerator<'i, 'e>
        val mutable private current: 'res voption
        val private chooser: OptimizedClosures.FSharpFunc<'state, 'i, 'res voption>
        val private state: 'state

        new (state, chooser, enumerator) = { enumerator = enumerator; chooser = OptimizedClosures.FSharpFunc<_,_,_>.Adapt chooser; current = ValueNone; state = state }

        [<MethodImpl(MethodImplOptions.AggressiveInlining)>]
        member this.MoveNext() =
            this.current <- ValueNone
            while this.current.IsNone && this.enumerator.MoveNext() do
                this.current <- this.chooser.Invoke(this.state, this.enumerator.Current)
            this.current.IsSome
        member this.Current with [<MethodImpl(MethodImplOptions.AggressiveInlining)>] get() =
            this.current |> ValueOption.get

        member this.Dispose() = ()

        interface IEnumerator<'res> with
            member this.Current = this.Current :> obj
            member this.Current = this.Current
            member this.Dispose() = ()
            member this.MoveNext() = this.MoveNext()
            member this.Reset() = ()

    [<Struct; NoComparison; NoEquality>]
    type StructValueChoose2Enumerator<'i, 'i2, 'res, 'e, 'e2 when 'e: struct
                                                              and 'e :> IEnumerator<'i>
                                                              and 'e2: struct
                                                              and 'e2 :> IEnumerator<'i2>> =
        val mutable private enumerator: SStructEnumerator<'i, 'e>
        val mutable private enumerator2: SStructEnumerator<'i2, 'e2>
        val mutable private current: 'res voption
        val private chooser: OptimizedClosures.FSharpFunc<'i2, 'i, 'res voption>

        new (chooser, enumerator, enumerator2) =
            { enumerator = enumerator; enumerator2 = enumerator2; chooser = OptimizedClosures.FSharpFunc<_,_,_>.Adapt chooser; current = ValueNone }

        [<MethodImpl(MethodImplOptions.AggressiveInlining)>]
        member this.MoveNext() =
            this.current <- ValueNone
            while this.current.IsNone && this.enumerator.MoveNext() && this.enumerator2.MoveNext() do
                this.current <- this.chooser.Invoke(this.enumerator2.Current, this.enumerator.Current)
            this.current.IsSome
        member this.Current with [<MethodImpl(MethodImplOptions.AggressiveInlining)>] get() =
            this.current |> ValueOption.get

        member this.Dispose() = ()

        interface IEnumerator<'res> with
            member this.Current = this.Current :> obj
            member this.Current = this.Current
            member this.Dispose() = ()
            member this.MoveNext() = this.MoveNext()
            member this.Reset() = ()

    [<Struct; NoComparison; NoEquality>]
    type StructValueChoose2VEnumerator<'i, 'i2, 'state, 'res, 'e, 'e2 when 'e: struct
                                                              and 'e :> IEnumerator<'i>
                                                              and 'e2: struct
                                                              and 'e2 :> IEnumerator<'i2>> =
        val mutable private enumerator: SStructEnumerator<'i, 'e>
        val mutable private enumerator2: SStructEnumerator<'i2, 'e2>
        val mutable private current: 'res voption
        val private chooser: OptimizedClosures.FSharpFunc<'state, 'i2, 'i, 'res voption>
        val private state: 'state

        new (state, chooser, enumerator, enumerator2) =
            { enumerator = enumerator; enumerator2 = enumerator2; chooser = OptimizedClosures.FSharpFunc<_,_,_,_>.Adapt chooser; current = ValueNone; state = state }

        [<MethodImpl(MethodImplOptions.AggressiveInlining)>]
        member this.MoveNext() =
            this.current <- ValueNone
            while this.current.IsNone && this.enumerator.MoveNext() && this.enumerator2.MoveNext() do
                this.current <- this.chooser.Invoke(this.state, this.enumerator2.Current, this.enumerator.Current)
            this.current.IsSome
        member this.Current with [<MethodImpl(MethodImplOptions.AggressiveInlining)>] get() =
            this.current |> ValueOption.get

        member this.Dispose() = ()

        interface IEnumerator<'res> with
            member this.Current = this.Current :> obj
            member this.Current = this.Current
            member this.Dispose() = ()
            member this.MoveNext() = this.MoveNext()
            member this.Reset() = ()

    [<Struct; NoComparison; NoEquality>]
    type StructValueChoose3Enumerator<'i, 'i2, 'i3, 'res, 'e, 'e2, 'e3 when 'e: struct
                                                                        and 'e :> IEnumerator<'i>
                                                                        and 'e2: struct
                                                                        and 'e2 :> IEnumerator<'i2>
                                                                        and 'e3: struct
                                                                        and 'e3 :> IEnumerator<'i3>> =
        val mutable private enumerator: SStructEnumerator<'i, 'e>
        val mutable private enumerator2: SStructEnumerator<'i2, 'e2>
        val mutable private enumerator3: SStructEnumerator<'i3, 'e3>
        val mutable private current: 'res voption
        val private chooser: OptimizedClosures.FSharpFunc<'i2, 'i3, 'i, 'res voption>

        new (chooser, enumerator, enumerator2, enumerator3) =
            { enumerator = enumerator; enumerator2 = enumerator2; enumerator3 = enumerator3; chooser = OptimizedClosures.FSharpFunc<_,_,_,_>.Adapt chooser; current = ValueNone }

        [<MethodImpl(MethodImplOptions.AggressiveInlining)>]
        member this.MoveNext() =
            this.current <- ValueNone
            while this.current.IsNone && this.enumerator.MoveNext() && this.enumerator2.MoveNext() && this.enumerator3.MoveNext() do
                this.current <- this.chooser.Invoke(this.enumerator2.Current, this.enumerator3.Current, this.enumerator.Current)
            this.current.IsSome
        member this.Current with [<MethodImpl(MethodImplOptions.AggressiveInlining)>] get() =
            this.current |> ValueOption.get

        member this.Dispose() = ()

        interface IEnumerator<'res> with
            member this.Current = this.Current :> obj
            member this.Current = this.Current
            member this.Dispose() = ()
            member this.MoveNext() = this.MoveNext()
            member this.Reset() = ()

    [<Struct; NoComparison; NoEquality>]
    type StructValueChoose3VEnumerator<'i, 'i2, 'i3, 'state, 'res, 'e, 'e2, 'e3 when 'e: struct
                                                                        and 'e :> IEnumerator<'i>
                                                                        and 'e2: struct
                                                                        and 'e2 :> IEnumerator<'i2>
                                                                        and 'e3: struct
                                                                        and 'e3 :> IEnumerator<'i3>> =
        val mutable private enumerator: SStructEnumerator<'i, 'e>
        val mutable private enumerator2: SStructEnumerator<'i2, 'e2>
        val mutable private enumerator3: SStructEnumerator<'i3, 'e3>
        val mutable private current: 'res voption
        val private chooser: OptimizedClosures.FSharpFunc<'state, 'i2, 'i3, 'i, 'res voption>
        val private state: 'state

        new (state, chooser, enumerator, enumerator2, enumerator3) =
            { enumerator = enumerator; enumerator2 = enumerator2; enumerator3 = enumerator3; chooser = OptimizedClosures.FSharpFunc<_,_,_,_,_>.Adapt chooser; current = ValueNone; state = state }

        [<MethodImpl(MethodImplOptions.AggressiveInlining)>]
        member this.MoveNext() =
            this.current <- ValueNone
            while this.current.IsNone && this.enumerator.MoveNext() && this.enumerator2.MoveNext() && this.enumerator3.MoveNext() do
                this.current <- this.chooser.Invoke(this.state, this.enumerator2.Current, this.enumerator3.Current, this.enumerator.Current)
            this.current.IsSome
        member this.Current with [<MethodImpl(MethodImplOptions.AggressiveInlining)>] get() =
            this.current |> ValueOption.get

        member this.Dispose() = ()

        interface IEnumerator<'res> with
            member this.Current = this.Current :> obj
            member this.Current = this.Current
            member this.Dispose() = ()
            member this.MoveNext() = this.MoveNext()
            member this.Reset() = ()

    [<Struct; NoComparison; NoEquality>]
    type StructAppendEnumerator<'i, 'e when 'e: struct
                                        and 'e :> IEnumerator<'i>> =

        val mutable private enumerator1: SStructEnumerator<'i, 'e>
        val mutable private enumerator2: SStructEnumerator<'i, 'e>
        val mutable private index: int

        new (enumerator1, enumerator2) = { enumerator1 = enumerator1; enumerator2 = enumerator2; index = 0 }

        [<MethodImpl(MethodImplOptions.AggressiveInlining)>]
        member this.MoveNext() =
            match this.index with
            | 0 ->
                match this.enumerator1.MoveNext() with
                | true -> true
                | _ ->
                    this.index <- 1
                    this.enumerator2.MoveNext()
            | _ ->
                this.enumerator2.MoveNext()

        member this.Current with [<MethodImpl(MethodImplOptions.AggressiveInlining)>] get() =
            match this.index with
            | 0 -> this.enumerator1.Current
            | _ -> this.enumerator2.Current

        member this.Dispose() = ()

        interface IEnumerator<'i> with
            member this.Current = this.Current :> obj
            member this.Current = this.Current
            member this.Dispose() = ()
            member this.MoveNext() = this.MoveNext()
            member this.Reset() = ()

    [<Struct; NoComparison; NoEquality>]
    type StructZipEnumerator<'i, 'i2, 'e, 'e2 when 'e: struct
                                               and 'e :> IEnumerator<'i>
                                               and 'e2: struct
                                               and 'e2 :> IEnumerator<'i2>> =

        val mutable private enumerator1: SStructEnumerator<'i, 'e>
        val mutable private enumerator2: SStructEnumerator<'i2, 'e2>

        new (enumerator1, enumerator2) = { enumerator1 = enumerator1; enumerator2 = enumerator2 }

        [<MethodImpl(MethodImplOptions.AggressiveInlining)>]
        member this.MoveNext() =
            this.enumerator1.MoveNext()
            && this.enumerator2.MoveNext()

        member this.Current with [<MethodImpl(MethodImplOptions.AggressiveInlining)>] get() =
            this.enumerator2.Current, this.enumerator1.Current

        member this.Dispose() = ()

        interface IEnumerator<'i2 * 'i> with
            member this.Current = this.Current :> obj
            member this.Current = this.Current
            member this.Dispose() = ()
            member this.MoveNext() = this.MoveNext()
            member this.Reset() = ()

    [<Struct; NoComparison; NoEquality>]
    type StructValueZipEnumerator<'i, 'i2, 'e, 'e2 when 'e: struct
                                                    and 'e :> IEnumerator<'i>
                                                    and 'e2: struct
                                                    and 'e2 :> IEnumerator<'i2>> =
        val mutable private enumerator1: SStructEnumerator<'i, 'e>
        val mutable private enumerator2: SStructEnumerator<'i2, 'e2>

        new (enumerator1, enumerator2) = { enumerator1 = enumerator1; enumerator2 = enumerator2 }

        [<MethodImpl(MethodImplOptions.AggressiveInlining)>]
        member this.MoveNext() =
            this.enumerator1.MoveNext()
            && this.enumerator2.MoveNext()

        member this.Current with [<MethodImpl(MethodImplOptions.AggressiveInlining)>] get() =
            struct (this.enumerator2.Current, this.enumerator1.Current)

        member this.Dispose() = ()

        interface IEnumerator<struct('i2 * 'i)> with
            member this.Current = this.Current :> obj
            member this.Current = this.Current
            member this.Dispose() = ()
            member this.MoveNext() = this.MoveNext()
            member this.Reset() = ()

    [<Struct; NoComparison; NoEquality>]
    type StructInitEnumerator<'i> =
        val mutable private length: int
        val mutable private count: int
        val private initializer: int -> 'i

        new (count, initializer) = { length = -1; count = count; initializer = initializer }

        [<MethodImpl(MethodImplOptions.AggressiveInlining)>]
        member this.MoveNext() =
            &this.length +<- 1
            this.length < this.count

        member this.Current with [<MethodImpl(MethodImplOptions.AggressiveInlining)>] get() = this.initializer this.length

        member this.Dispose() = ()

        interface IEnumerator<'i> with
            member this.Current = this.Current :> obj
            member this.Current = this.Current
            member this.Dispose() = ()
            member this.MoveNext() = this.MoveNext()
            member this.Reset() = ()

    [<Struct; NoComparison; NoEquality>]
    type StructInitInfiniteEnumerator<'i> =
        val mutable private length: int
        val private initializer: int -> 'i

        new (initializer) = { length = -1; initializer = initializer }

        [<MethodImpl(MethodImplOptions.AggressiveInlining)>]
        member this.MoveNext() =
            &this.length +<- 1
            true

        member this.Current with [<MethodImpl(MethodImplOptions.AggressiveInlining)>] get() = this.initializer this.length

        member this.Dispose() = ()

        interface IEnumerator<'i> with
            member this.Current = this.Current :> obj
            member this.Current = this.Current
            member this.Dispose() = ()
            member this.MoveNext() = this.MoveNext()
            member this.Reset() = ()

#nowarn "0760"
module GSeq =
    open GenericEnumeratorsImpl

    let inline getEnumerator<'i, 'e, ^seq when 'e: struct
                                           and 'e :> IEnumerator<'i>
                                           and ^seq: (member GetEnumerator: unit -> SStructEnumerator<'i, 'e>)> (seq: ^seq) =
        (^seq: (member GetEnumerator: unit ->  SStructEnumerator<'i, 'e>) seq)

    [<MethodImpl(MethodImplOptions.AggressiveInlining)>]
    let ofIEnumerator enumerator = StructIEnumeratorWrapper(enumerator)

    [<MethodImpl(MethodImplOptions.AggressiveInlining)>]
    let ofSeq (seq: 'a seq) = StructIEnumeratorWrapper(seq.GetEnumerator())

    [<MethodImpl(MethodImplOptions.AggressiveInlining)>]
    let ofArray array = StructArrayEnumerator(array)

    [<MethodImpl(MethodImplOptions.AggressiveInlining)>]
    let ofArrayRev array = StructArrayRevEnumerator(array)

    [<MethodImpl(MethodImplOptions.AggressiveInlining)>]
    let ofResizeArray array = StructResizeArrayEnumerator(array)

    [<MethodImpl(MethodImplOptions.AggressiveInlining)>]
    let ofResizeArrayRev array = StructResizeArrayRevEnumerator(array)

    [<MethodImpl(MethodImplOptions.AggressiveInlining)>]
    let ofIList array = StructIListEnumerator(array)

    [<MethodImpl(MethodImplOptions.AggressiveInlining)>]
    let ofIListRev array = StructIListRevEnumerator(array)

    [<MethodImpl(MethodImplOptions.AggressiveInlining)>]
    let ofBlock array = StructImmutableArrayEnumerator(array)

    [<MethodImpl(MethodImplOptions.AggressiveInlining)>]
    let ofList list = StructFSharpListEnumerator(list)

    [<MethodImpl(MethodImplOptions.AggressiveInlining)>]
    let ofMap (map: Map<_,_>) = map |> ofSeq // TODO: Fast implementation?

    [<MethodImpl(MethodImplOptions.AggressiveInlining)>]
    let filter filter enumerator = StructFilterEnumerator(filter, enumerator)

    [<MethodImpl(MethodImplOptions.AggressiveInlining)>]
    let filterv state filter enumerator = StructFilterVEnumerator(state, filter, enumerator)

    [<MethodImpl(MethodImplOptions.AggressiveInlining)>]
    let choose chooser enumerator = StructChooseEnumerator(chooser, enumerator)

    [<MethodImpl(MethodImplOptions.AggressiveInlining)>]
    let choosev state chooser enumerator = StructChooseVEnumerator(state, chooser, enumerator)

    [<MethodImpl(MethodImplOptions.AggressiveInlining)>]
    let choose2 enumerator2 chooser enumerator = StructChoose2Enumerator(chooser, enumerator, enumerator2)

    [<MethodImpl(MethodImplOptions.AggressiveInlining)>]
    let choose2v state enumerator2 chooser enumerator = StructChoose2VEnumerator(state, chooser, enumerator, enumerator2)

    [<MethodImpl(MethodImplOptions.AggressiveInlining)>]
    let choose3 enumerator2 enumerator3 chooser enumerator = StructChoose3Enumerator(chooser, enumerator, enumerator2, enumerator3)

    [<MethodImpl(MethodImplOptions.AggressiveInlining)>]
    let choose3v state enumerator2 enumerator3 chooser enumerator = StructChoose3VEnumerator(state, chooser, enumerator, enumerator2, enumerator3)

    [<MethodImpl(MethodImplOptions.AggressiveInlining)>]
    let valueChoose chooser enumerator = StructValueChooseEnumerator(chooser, enumerator)

    [<MethodImpl(MethodImplOptions.AggressiveInlining)>]
    let valueChoosev state chooser enumerator = StructValueChooseVEnumerator(state, chooser, enumerator)

    [<MethodImpl(MethodImplOptions.AggressiveInlining)>]
    let valueChoose2 enumerator2 chooser enumerator = StructValueChoose2Enumerator(chooser, enumerator, enumerator2)

    [<MethodImpl(MethodImplOptions.AggressiveInlining)>]
    let valueChoose2v state enumerator2 chooser enumerator = StructValueChoose2VEnumerator(state, chooser, enumerator, enumerator2)

    [<MethodImpl(MethodImplOptions.AggressiveInlining)>]
    let valueChoose3 enumerator2 enumerator3 chooser enumerator = StructValueChoose3Enumerator(chooser, enumerator, enumerator2, enumerator3)

    [<MethodImpl(MethodImplOptions.AggressiveInlining)>]
    let valueChoose3v state enumerator2 enumerator3 chooser enumerator = StructValueChoose3VEnumerator(state, chooser, enumerator, enumerator2, enumerator3)

    [<MethodImpl(MethodImplOptions.AggressiveInlining)>]
    let append enumerator2 enumerator = StructAppendEnumerator(enumerator, enumerator2)

    [<MethodImpl(MethodImplOptions.AggressiveInlining)>]
    let zip enumerator2 enumerator = StructZipEnumerator(enumerator, enumerator2)

    [<MethodImpl(MethodImplOptions.AggressiveInlining)>]
    let valueZip enumerator2 enumerator = StructValueZipEnumerator(enumerator, enumerator2)

    [<MethodImpl(MethodImplOptions.AggressiveInlining)>]
    let map map enumerator = StructMapEnumerator(map, enumerator)

    [<MethodImpl(MethodImplOptions.AggressiveInlining)>]
    let mapv state map enumerator = StructMapVEnumerator(state, map, enumerator)

    [<MethodImpl(MethodImplOptions.AggressiveInlining)>]
    let mapi map enumerator = StructMapiEnumerator(map, enumerator)

    [<MethodImpl(MethodImplOptions.AggressiveInlining)>]
    let mapiv state map enumerator = StructMapiVEnumerator(state, map, enumerator)

    [<MethodImpl(MethodImplOptions.AggressiveInlining)>]
    let map2 map enumerator2 enumerator = StructMap2Enumerator(map, enumerator, enumerator2)

    [<MethodImpl(MethodImplOptions.AggressiveInlining)>]
    let map2v state map enumerator2 enumerator = StructMap2VEnumerator(state, map, enumerator, enumerator2)

    [<MethodImpl(MethodImplOptions.AggressiveInlining)>]
    let mapi2 map enumerator2 enumerator = StructMapi2Enumerator(map, enumerator, enumerator2)

    [<MethodImpl(MethodImplOptions.AggressiveInlining)>]
    let mapi2v state map enumerator2 enumerator = StructMapi2VEnumerator(state, map, enumerator, enumerator2)

    [<MethodImpl(MethodImplOptions.AggressiveInlining)>]
    let skip count enumerator = StructSkipEnumerator(count, enumerator)

    [<MethodImpl(MethodImplOptions.AggressiveInlining)>]
    let take count enumerator = StructTakeEnumerator(count, enumerator)

    [<MethodImpl(MethodImplOptions.AggressiveInlining)>]
    let skipWhile filter enumerator = StructSkipWhileEnumerator(filter, enumerator)

    [<MethodImpl(MethodImplOptions.AggressiveInlining)>]
    let skipWhilev state filter enumerator = StructSkipWhileVEnumerator(state, filter, enumerator)

    [<MethodImpl(MethodImplOptions.AggressiveInlining)>]
    let takeWhile filter enumerator = StructTakeWhileEnumerator(filter, enumerator)

    [<MethodImpl(MethodImplOptions.AggressiveInlining)>]
    let takeWhilev state filter enumerator = StructTakeWhileVEnumerator(state, filter, enumerator)

    [<MethodImpl(MethodImplOptions.AggressiveInlining)>]
    let tryFind filter (enumerator: SStructEnumerator<'i,'e>) =
        let mutable enumerator = enumerator
        let mutable result = None
        while result.IsNone && enumerator.MoveNext() do
            let value = enumerator.Current
            if value |> filter then result <- Some value
        result

    [<MethodImpl(MethodImplOptions.AggressiveInlining)>]
    let tryFindv state filter (enumerator: SStructEnumerator<'i,'e>) =
        let filter = OptimizedClosures.FSharpFunc<_,_,_>.Adapt filter
        let mutable enumerator = enumerator
        let mutable result = None
        while result.IsNone && enumerator.MoveNext() do
            let value = enumerator.Current
            if filter.Invoke(state, value) then result <- Some value
        result

    [<MethodImpl(MethodImplOptions.AggressiveInlining)>]
    let tryValueFind filter (enumerator: SStructEnumerator<'i,'e>) =
        let mutable enumerator = enumerator
        let mutable result = ValueNone
        while result.IsNone && enumerator.MoveNext() do
            let value = enumerator.Current
            if value |> filter then result <- ValueSome value
        result

    [<MethodImpl(MethodImplOptions.AggressiveInlining)>]
    let tryValueFindv state filter (enumerator: SStructEnumerator<'i,'e>) =
        let filter = OptimizedClosures.FSharpFunc<_,_,_>.Adapt filter
        let mutable enumerator = enumerator
        let mutable result = ValueNone
        while result.IsNone && enumerator.MoveNext() do
            let value = enumerator.Current
            if filter.Invoke(state, value) then result <- ValueSome value
        result

    [<MethodImpl(MethodImplOptions.AggressiveInlining)>]
    let tryPick filter (enumerator: SStructEnumerator<'i,'e>) =
        let mutable enumerator = enumerator
        let mutable result = None
        while result.IsNone && enumerator.MoveNext() do
            let value = enumerator.Current
            result <- filter value
        result

    [<MethodImpl(MethodImplOptions.AggressiveInlining)>]
    let tryPickv state filter (enumerator: SStructEnumerator<'i,'e>) =
        let filter = OptimizedClosures.FSharpFunc<_,_,_>.Adapt filter
        let mutable enumerator = enumerator
        let mutable result = None
        while result.IsNone && enumerator.MoveNext() do
            let value = enumerator.Current
            result <- filter.Invoke(state, value)
        result

    [<MethodImpl(MethodImplOptions.AggressiveInlining)>]
    let tryValuePick filter (enumerator: SStructEnumerator<'i,'e>) =
        let mutable enumerator = enumerator
        let mutable result = ValueNone
        while result.IsNone && enumerator.MoveNext() do
            let value = enumerator.Current
            result <- filter value
        result

    [<MethodImpl(MethodImplOptions.AggressiveInlining)>]
    let tryValuePickv state filter (enumerator: SStructEnumerator<'i,'e>) =
        let filter = OptimizedClosures.FSharpFunc<_,_,_>.Adapt filter
        let mutable enumerator = enumerator
        let mutable result = ValueNone
        while result.IsNone && enumerator.MoveNext() do
            let value = enumerator.Current
            result <- filter.Invoke(state, value)
        result

    [<MethodImpl(MethodImplOptions.AggressiveInlining)>]
    let exists filter (enumerator: SStructEnumerator<'i,'e>) =
        let mutable enumerator = enumerator
        let mutable found = false
        while not found && enumerator.MoveNext() do
            let value = enumerator.Current
            found <- value |> filter
        found

    [<MethodImpl(MethodImplOptions.AggressiveInlining)>]
    let existsv state filter (enumerator: SStructEnumerator<'i,'e>) =
        let filter = OptimizedClosures.FSharpFunc<_,_,_>.Adapt filter
        let mutable enumerator = enumerator
        let mutable found = false
        while not found && enumerator.MoveNext() do
            let value = enumerator.Current
            found <- filter.Invoke(state, value)
        found

    [<MethodImpl(MethodImplOptions.AggressiveInlining)>]
    let forall filter (enumerator: SStructEnumerator<'i,'e>) =
        let mutable enumerator = enumerator
        let mutable result = true
        while result && enumerator.MoveNext() do
            let value = enumerator.Current
            result <- value |> filter
        result

    [<MethodImpl(MethodImplOptions.AggressiveInlining)>]
    let forallv state filter (enumerator: SStructEnumerator<'i,'e>) =
        let filter = OptimizedClosures.FSharpFunc<_,_,_>.Adapt filter
        let mutable enumerator = enumerator
        let mutable result = true
        while result && enumerator.MoveNext() do
            let value = enumerator.Current
            result <- filter.Invoke(state, value)
        result

    [<MethodImpl(MethodImplOptions.AggressiveInlining)>]
    let forall2 (enumerator2: SStructEnumerator<'i2,'e2>) filter (enumerator: SStructEnumerator<'i,'e>) =
        let filter = OptimizedClosures.FSharpFunc<_,_,_>.Adapt filter
        let mutable enumerator = enumerator
        let mutable enumerator2 = enumerator2
        let mutable result = true
        while result && enumerator.MoveNext() && enumerator2.MoveNext() do
            result <- filter.Invoke(enumerator2.Current, enumerator.Current)
        result

    [<MethodImpl(MethodImplOptions.AggressiveInlining)>]
    let forallv2 state (enumerator2: SStructEnumerator<'i2,'e2>) filter (enumerator: SStructEnumerator<'i,'e>) =
        let filter = OptimizedClosures.FSharpFunc<_,_,_,_>.Adapt filter
        let mutable enumerator = enumerator
        let mutable enumerator2 = enumerator2
        let mutable result = true
        while result && enumerator.MoveNext() && enumerator2.MoveNext() do
            result <- filter.Invoke(state, enumerator2.Current, enumerator.Current)
        result

    [<MethodImpl(MethodImplOptions.AggressiveInlining)>]
    let forall3 (enumerator2: SStructEnumerator<'i2,'e2>) (enumerator3: SStructEnumerator<'i2,'e2>) filter (enumerator: SStructEnumerator<'i,'e>) =
        let filter = OptimizedClosures.FSharpFunc<_,_,_,_>.Adapt filter
        let mutable enumerator = enumerator
        let mutable enumerator2 = enumerator2
        let mutable enumerator3 = enumerator3
        let mutable result = true
        while result && enumerator.MoveNext() && enumerator2.MoveNext() && enumerator3.MoveNext() do
            result <- filter.Invoke(enumerator2.Current, enumerator3.Current, enumerator.Current)
        result

    [<MethodImpl(MethodImplOptions.AggressiveInlining)>]
    let forallv3 state (enumerator2: SStructEnumerator<'i2,'e2>) (enumerator3: SStructEnumerator<'i2,'e2>) filter (enumerator: SStructEnumerator<'i,'e>) =
        let filter = OptimizedClosures.FSharpFunc<_,_,_,_,_>.Adapt filter
        let mutable enumerator = enumerator
        let mutable enumerator2 = enumerator2
        let mutable enumerator3 = enumerator3
        let mutable result = true
        while result && enumerator.MoveNext() && enumerator2.MoveNext() && enumerator3.MoveNext() do
            result <- filter.Invoke(state, enumerator2.Current, enumerator3.Current, enumerator.Current)
        result

    [<MethodImpl(MethodImplOptions.AggressiveInlining)>]
    let contains value (enumerator: SStructEnumerator<'i,'e>) =
        let mutable enumerator = enumerator
        let mutable found = false
        while not found && enumerator.MoveNext() do
            let value2 = enumerator.Current
            found <- value = value2
        found

    [<MethodImpl(MethodImplOptions.AggressiveInlining)>]
    let tryValueItem index (enumerator: SStructEnumerator<'i,'e>) =
        if index < 0 then ValueNone else
        let mutable enumerator = enumerator
        let mutable counter = 0
        while counter < index && enumerator.MoveNext() do ()
        if enumerator.MoveNext() then ValueSome enumerator.Current
        else ValueNone

    [<MethodImpl(MethodImplOptions.AggressiveInlining)>]
    let tryItem index (enumerator: SStructEnumerator<'i,'e>) =
        if index < 0 then None else
        let mutable enumerator = enumerator
        let mutable counter = 0
        while counter < index && enumerator.MoveNext() do ()
        if enumerator.MoveNext() then Some enumerator.Current
        else None

    [<MethodImpl(MethodImplOptions.AggressiveInlining)>]
    let fold initial folder (enumerator: SStructEnumerator<'i,'e>) =
        let folder = OptimizedClosures.FSharpFunc<_,_,_>.Adapt folder
        let mutable enumerator = enumerator
        let mutable result = initial
        while enumerator.MoveNext() do
            result <- folder.Invoke(result, enumerator.Current)
        result

    [<AbstractClass>]
    type GSeq2() =
        [<MethodImpl(MethodImplOptions.AggressiveInlining)>]
        static member foldTest(initial, folder, enumerator: SStructEnumerator<'i,'e>) =
            let folder = OptimizedClosures.FSharpFunc<_,_,_>.Adapt folder
            let mutable enumerator = enumerator
            let mutable result = initial
            while enumerator.MoveNext() do
                result <- folder.Invoke(result, enumerator.Current)
            result

    [<MethodImpl(MethodImplOptions.AggressiveInlining)>]
    let foldTest (initial, folder, enumerator: SStructEnumerator<'i,'e>) =
        let folder = OptimizedClosures.FSharpFunc<_,_,_>.Adapt folder
        let mutable enumerator = enumerator
        let mutable result = initial
        while enumerator.MoveNext() do
            result <- folder.Invoke(result, enumerator.Current)
        result

    [<MethodImpl(MethodImplOptions.AggressiveInlining)>]
    let foldv state initial folder (enumerator: SStructEnumerator<'i,'e>) =
        let folder = OptimizedClosures.FSharpFunc<_,_,_,_>.Adapt folder
        let mutable enumerator = enumerator
        let mutable result = initial
        while enumerator.MoveNext() do
            result <- folder.Invoke(state, result, enumerator.Current)
        result

    [<MethodImpl(MethodImplOptions.AggressiveInlining)>]
    let fold2 (enumerator2: SStructEnumerator<'i2,'e2>) initial folder (enumerator: SStructEnumerator<'i,'e>) =
        let folder = OptimizedClosures.FSharpFunc<_,_,_,_>.Adapt folder
        let mutable enumerator = enumerator
        let mutable enumerator2 = enumerator2
        let mutable result = initial
        while enumerator.MoveNext() && enumerator2.MoveNext() do
            result <- folder.Invoke(result, enumerator2.Current, enumerator.Current)
        result

    [<MethodImpl(MethodImplOptions.AggressiveInlining)>]
    let fold2v state initial (enumerator2: SStructEnumerator<'i2,'e2>) folder (enumerator: SStructEnumerator<'i,'e>) =
        let folder = OptimizedClosures.FSharpFunc<_,_,_,_,_>.Adapt folder
        let mutable enumerator = enumerator
        let mutable enumerator2 = enumerator2
        let mutable result = initial
        while enumerator.MoveNext() && enumerator2.MoveNext() do
            result <- folder.Invoke(state, result, enumerator2.Current, enumerator.Current)
        result

    [<MethodImpl(MethodImplOptions.AggressiveInlining)>]
    let foldi initial folder (enumerator: SStructEnumerator<'i,'e>) =
        let folder = OptimizedClosures.FSharpFunc<_,_,_,_>.Adapt folder
        let mutable enumerator = enumerator
        let mutable count = 0
        let mutable result = initial
        while enumerator.MoveNext() do
            result <- folder.Invoke(count, result, enumerator.Current)
            &count +<- 1
        result

    [<MethodImpl(MethodImplOptions.AggressiveInlining)>]
    let foldiv state initial folder (enumerator: SStructEnumerator<'i,'e>) =
        let folder = OptimizedClosures.FSharpFunc<_,_,_,_,_>.Adapt folder
        let mutable enumerator = enumerator
        let mutable count = 0
        let mutable result = initial
        while enumerator.MoveNext() do
            result <- folder.Invoke(count, state, result, enumerator.Current)
            &count +<- 1
        result

    [<MethodImpl(MethodImplOptions.AggressiveInlining)>]
    let foldi2 (enumerator2: SStructEnumerator<'i2,'e2>) initial folder (enumerator: SStructEnumerator<'i,'e>) =
        let folder = OptimizedClosures.FSharpFunc<_,_,_,_,_>.Adapt folder
        let mutable enumerator = enumerator
        let mutable enumerator2 = enumerator2
        let mutable count = 0
        let mutable result = initial
        while enumerator.MoveNext() && enumerator2.MoveNext() do
            result <- folder.Invoke(count, result, enumerator2.Current, enumerator.Current)
            &count +<- 1
        result

    [<MethodImpl(MethodImplOptions.AggressiveInlining)>]
    let foldi2v state initial (enumerator2: SStructEnumerator<'i2,'e2>) folder (enumerator: SStructEnumerator<'i,'e>) =
        let folder = OptimizedClosures.FSharpFunc<_,_,_,_,_,_>.Adapt folder
        let mutable enumerator = enumerator
        let mutable enumerator2 = enumerator2
        let mutable count = 0
        let mutable result = initial
        while enumerator.MoveNext() && enumerator2.MoveNext() do
            result <- folder.Invoke(count, state, result, enumerator2.Current, enumerator.Current)
            &count +<- 1
        result

    [<MethodImpl(MethodImplOptions.AggressiveInlining)>]
    let iter action (enumerator: SStructEnumerator<'i,'e>) =
        let mutable enumerator = enumerator
        while enumerator.MoveNext() do
            action enumerator.Current

    [<MethodImpl(MethodImplOptions.AggressiveInlining)>]
    let iterv state action (enumerator: SStructEnumerator<'i,'e>) =
        let action = OptimizedClosures.FSharpFunc<_,_,_>.Adapt action
        let mutable enumerator = enumerator
        while enumerator.MoveNext() do
            action.Invoke(state, enumerator.Current)

    [<MethodImpl(MethodImplOptions.AggressiveInlining)>]
    let iter2 (enumerator2: SStructEnumerator<'i2,'e2>) action (enumerator: SStructEnumerator<'i,'e>) =
        let action = OptimizedClosures.FSharpFunc<_,_,_>.Adapt action
        let mutable enumerator = enumerator
        let mutable enumerator2 = enumerator2
        while enumerator.MoveNext() && enumerator2.MoveNext() do
            action.Invoke(enumerator2.Current, enumerator.Current)

    [<MethodImpl(MethodImplOptions.AggressiveInlining)>]
    let iter2test action (seq2: seq<'b>) (seq1: seq<'a>) =
        let action = OptimizedClosures.FSharpFunc<_,_,_>.Adapt action
        use enumerator1 = seq1.GetEnumerator()
        use enumerator2 = seq2.GetEnumerator()
        while enumerator1.MoveNext() && enumerator2.MoveNext() do
            action.Invoke(enumerator2.Current, enumerator1.Current)

    [<MethodImpl(MethodImplOptions.AggressiveInlining)>]
    let iter2v state (enumerator2: SStructEnumerator<'i2,'e2>) action (enumerator: SStructEnumerator<'i,'e>) =
        let action = OptimizedClosures.FSharpFunc<_,_,_,_>.Adapt action
        let mutable enumerator = enumerator
        let mutable enumerator2 = enumerator2
        while enumerator.MoveNext() && enumerator2.MoveNext() do
            action.Invoke(state, enumerator2.Current, enumerator.Current)

    [<MethodImpl(MethodImplOptions.AggressiveInlining)>]
    let iter3 (enumerator2: SStructEnumerator<'i2,'e2>) (enumerator3: SStructEnumerator<'i3,'e3>) action (enumerator: SStructEnumerator<'i,'e>) =
        let action = OptimizedClosures.FSharpFunc<_,_,_,_>.Adapt action
        let mutable enumerator = enumerator
        let mutable enumerator2 = enumerator2
        let mutable enumerator3 = enumerator3
        while enumerator.MoveNext() && enumerator2.MoveNext() && enumerator3.MoveNext() do
            action.Invoke(enumerator2.Current, enumerator3.Current, enumerator.Current)

    [<MethodImpl(MethodImplOptions.AggressiveInlining)>]
    let iter3v state (enumerator2: SStructEnumerator<'i2,'e2>) (enumerator3: SStructEnumerator<'i3,'e3>) action (enumerator: SStructEnumerator<'i,'e>) =
        let action = OptimizedClosures.FSharpFunc<_,_,_,_,_>.Adapt action
        let mutable enumerator = enumerator
        let mutable enumerator2 = enumerator2
        let mutable enumerator3 = enumerator3
        while enumerator.MoveNext() && enumerator2.MoveNext() && enumerator3.MoveNext() do
            action.Invoke(state, enumerator2.Current, enumerator3.Current, enumerator.Current)

    [<MethodImpl(MethodImplOptions.AggressiveInlining)>]
    let iteri action (enumerator: SStructEnumerator<'i,'e>) =
        let action = OptimizedClosures.FSharpFunc<_,_,_>.Adapt action
        let mutable enumerator = enumerator
        let mutable i = 0
        while enumerator.MoveNext() do
            action.Invoke(i, enumerator.Current)
            &i +<- 1

    [<MethodImpl(MethodImplOptions.AggressiveInlining)>]
    let iteriv state action (enumerator: SStructEnumerator<'i,'e>) =
        let action = OptimizedClosures.FSharpFunc<_,_,_,_>.Adapt action
        let mutable enumerator = enumerator
        let mutable i = 0
        while enumerator.MoveNext() do
            action.Invoke(i, state, enumerator.Current)
            &i +<- 1

    [<MethodImpl(MethodImplOptions.AggressiveInlining)>]
    let iteri2 (enumerator2: SStructEnumerator<'i2,'e2>) action (enumerator: SStructEnumerator<'i,'e>) =
        let action = OptimizedClosures.FSharpFunc<_,_,_,_>.Adapt action
        let mutable enumerator = enumerator
        let mutable enumerator2 = enumerator2
        let mutable i = 0
        while enumerator.MoveNext() && enumerator2.MoveNext() do
            action.Invoke(i, enumerator2.Current, enumerator.Current)
            &i +<- 1

    [<MethodImpl(MethodImplOptions.AggressiveInlining)>]
    let iteri2v state (enumerator2: SStructEnumerator<'i2,'e2>) action (enumerator: SStructEnumerator<'i,'e>) =
        let action = OptimizedClosures.FSharpFunc<_,_,_,_,_>.Adapt action
        let mutable enumerator = enumerator
        let mutable enumerator2 = enumerator2
        let mutable i = 0
        while enumerator.MoveNext() && enumerator2.MoveNext() do
            action.Invoke(i, state, enumerator2.Current, enumerator.Current)
            &i +<- 1

    [<MethodImpl(MethodImplOptions.AggressiveInlining)>]
    let iteri3 (enumerator2: SStructEnumerator<'i2,'e2>) (enumerator3: SStructEnumerator<'i3,'e3>) action (enumerator: SStructEnumerator<'i,'e>) =
        let action = OptimizedClosures.FSharpFunc<_,_,_,_,_>.Adapt action
        let mutable enumerator = enumerator
        let mutable enumerator2 = enumerator2
        let mutable enumerator3 = enumerator3
        let mutable i = 0
        while enumerator.MoveNext() && enumerator2.MoveNext() && enumerator3.MoveNext() do
            action.Invoke(i, enumerator2.Current, enumerator3.Current, enumerator.Current)
            &i +<- 1

    [<MethodImpl(MethodImplOptions.AggressiveInlining)>]
    let iteri3v state (enumerator2: SStructEnumerator<'i2,'e2>) (enumerator3: SStructEnumerator<'i3,'e3>) action (enumerator: SStructEnumerator<'i,'e>) =
        let action = OptimizedClosures.FSharpFunc<_,_,_,_,_,_>.Adapt action
        let mutable enumerator = enumerator
        let mutable enumerator2 = enumerator2
        let mutable enumerator3 = enumerator3
        let mutable i = 0
        while enumerator.MoveNext() && enumerator2.MoveNext() && enumerator3.MoveNext() do
            action.Invoke(i, state, enumerator2.Current, enumerator3.Current, enumerator.Current)
            &i +<- 1

    [<MethodImpl(MethodImplOptions.AggressiveInlining)>]
    let identical (enumerator2: SStructEnumerator<'i,'e>) (enumerator: SStructEnumerator<'i,'e>) =
        let mutable enumerator = enumerator
        let mutable enumerator2 = enumerator2
        let mutable state = 0
        while state = 0 do
            state <-
                match enumerator.MoveNext(), enumerator2.MoveNext() with
                | false, false -> 1
                | true, true when enumerator.Current = enumerator2.Current -> 0
                | _ -> -1
        state = 1

    [<MethodImpl(MethodImplOptions.AggressiveInlining)>]
    let identicalBy (enumerator2: SStructEnumerator<'i,'e>) comparer (enumerator: SStructEnumerator<'i,'e>) =
        let comparer = OptimizedClosures.FSharpFunc<_,_,_>.Adapt comparer
        let mutable enumerator = enumerator
        let mutable enumerator2 = enumerator2
        let mutable flag = 0
        while flag = 0 do
            flag <-
                match enumerator.MoveNext(), enumerator2.MoveNext() with
                | false, false -> 1
                | true, true when comparer.Invoke(enumerator2.Current, enumerator.Current) -> 0
                | _ -> -1
        flag = 1

    [<MethodImpl(MethodImplOptions.AggressiveInlining)>]
    let identicalByv state (enumerator2: SStructEnumerator<'i,'e>) comparer (enumerator: SStructEnumerator<'i,'e>) =
        let comparer = OptimizedClosures.FSharpFunc<_,_,_,_>.Adapt comparer
        let mutable enumerator = enumerator
        let mutable enumerator2 = enumerator2
        let mutable flag = 0
        while flag = 0 do
            flag <-
                match enumerator.MoveNext(), enumerator2.MoveNext() with
                | false, false -> 1
                | true, true when comparer.Invoke(state, enumerator2.Current, enumerator.Current) -> 0
                | _ -> -1
        flag = 1

    let inline private minImpl (enumerator: SStructEnumerator<'i,'e> byref) =
        let mutable current = enumerator.Current
        while enumerator.MoveNext() do
            current <- Operators.min current enumerator.Current
        current

    [<MethodImpl(MethodImplOptions.AggressiveInlining)>]
    let min (enumerator: SStructEnumerator<'i,'e>) =
        let mutable enumerator = enumerator
        if not ^ enumerator.MoveNext() then
            invalidOp "Seq is empty"
        else
            minImpl &enumerator

    [<MethodImpl(MethodImplOptions.AggressiveInlining)>]
    let tryMin (enumerator: SStructEnumerator<'i,'e>) =
        let mutable enumerator = enumerator
        if not ^ enumerator.MoveNext() then
            None
        else
            minImpl &enumerator |> Some

    [<MethodImpl(MethodImplOptions.AggressiveInlining)>]
    let tryValueMin (enumerator: SStructEnumerator<'i,'e>) =
        let mutable enumerator = enumerator
        if not ^ enumerator.MoveNext() then
            ValueNone
        else
            minImpl &enumerator |> ValueSome

    let inline private maxImpl (enumerator: SStructEnumerator<'i,'e> byref) =
        let mutable current = enumerator.Current
        while enumerator.MoveNext() do
            current <- Operators.max current enumerator.Current
        current

    [<MethodImpl(MethodImplOptions.AggressiveInlining)>]
    let max (enumerator: SStructEnumerator<'i,'e>) =
        let mutable enumerator = enumerator
        if not ^ enumerator.MoveNext() then
            invalidOp "Seq is empty"
        else
            maxImpl &enumerator

    [<MethodImpl(MethodImplOptions.AggressiveInlining)>]
    let tryMax (enumerator: SStructEnumerator<'i,'e>) =
        let mutable enumerator = enumerator
        if not ^ enumerator.MoveNext() then
            None
        else
            maxImpl &enumerator |> Some

    [<MethodImpl(MethodImplOptions.AggressiveInlining)>]
    let tryValueMax (enumerator: SStructEnumerator<'i,'e>) =
        let mutable enumerator = enumerator
        if not ^ enumerator.MoveNext() then
            ValueNone
        else
            maxImpl &enumerator |> ValueSome

    let inline private minByImpl map (enumerator: SStructEnumerator<'i,'e> byref) =
        let mutable result = enumerator.Current
        let mutable mapping = map result
        while enumerator.MoveNext() do
            let next = enumerator.Current
            let nextMapping = map next
            if mapping > nextMapping then
                mapping <- nextMapping
                result <- next
        result

    let inline private minByvImpl state map (enumerator: SStructEnumerator<'i,'e> byref) =
        let map = OptimizedClosures.FSharpFunc<_,_,_>.Adapt map
        let mutable result = enumerator.Current
        let mutable mapping = map.Invoke(state, result)
        while enumerator.MoveNext() do
            let next = enumerator.Current
            let nextMapping = map.Invoke(state, next)
            if mapping > nextMapping then
                mapping <- nextMapping
                result <- next
        result

    [<MethodImpl(MethodImplOptions.AggressiveInlining)>]
    let minBy map (enumerator: SStructEnumerator<'i,'e>) =
        let mutable enumerator = enumerator
        if not ^ enumerator.MoveNext() then
            invalidOp "Seq is empty"
        else
            minByImpl map &enumerator

    [<MethodImpl(MethodImplOptions.AggressiveInlining)>]
    let minByv state map (enumerator: SStructEnumerator<'i,'e>) =
        let mutable enumerator = enumerator
        if not ^ enumerator.MoveNext() then
            invalidOp "Seq is empty"
        else
            minByvImpl state map &enumerator

    [<MethodImpl(MethodImplOptions.AggressiveInlining)>]
    let tryMinBy map (enumerator: SStructEnumerator<'i,'e>) =
        let mutable enumerator = enumerator
        if not ^ enumerator.MoveNext() then
            None
        else
            minByImpl map &enumerator |> Some

    [<MethodImpl(MethodImplOptions.AggressiveInlining)>]
    let tryMinByv state map (enumerator: SStructEnumerator<'i,'e>) =
        let mutable enumerator = enumerator
        if not ^ enumerator.MoveNext() then
            None
        else
            minByvImpl state map &enumerator |> Some

    [<MethodImpl(MethodImplOptions.AggressiveInlining)>]
    let tryValueMinBy map (enumerator: SStructEnumerator<'i,'e>) =
        let mutable enumerator = enumerator
        if not ^ enumerator.MoveNext() then
            ValueNone
        else
            minByImpl map &enumerator |> ValueSome

    [<MethodImpl(MethodImplOptions.AggressiveInlining)>]
    let tryValueMinByv state map (enumerator: SStructEnumerator<'i,'e>) =
        let mutable enumerator = enumerator
        if not ^ enumerator.MoveNext() then
            ValueNone
        else
            minByvImpl state map &enumerator |> ValueSome

    let inline private maxByImpl map (enumerator: SStructEnumerator<'i,'e> byref) =
        let mutable result = enumerator.Current
        let mutable mapping = map result
        while enumerator.MoveNext() do
            let next = enumerator.Current
            let nextMapping = map next
            if mapping < nextMapping then
                mapping <- nextMapping
                result <- next
        result

    let inline private maxByvImpl state map (enumerator: SStructEnumerator<'i,'e> byref) =
        let map = OptimizedClosures.FSharpFunc<_,_,_>.Adapt map
        let mutable result = enumerator.Current
        let mutable mapping = map.Invoke(state,  result)
        while enumerator.MoveNext() do
            let next = enumerator.Current
            let nextMapping = map.Invoke(state, next)
            if mapping < nextMapping then
                mapping <- nextMapping
                result <- next
        result

    [<MethodImpl(MethodImplOptions.AggressiveInlining)>]
    let maxBy map (enumerator: SStructEnumerator<'i,'e>) =
        let mutable enumerator = enumerator
        if not ^ enumerator.MoveNext() then
            invalidOp "Seq is empty"
        else
            maxByImpl map &enumerator

    [<MethodImpl(MethodImplOptions.AggressiveInlining)>]
    let maxByv state map (enumerator: SStructEnumerator<'i,'e>) =
        let mutable enumerator = enumerator
        if not ^ enumerator.MoveNext() then
            invalidOp "Seq is empty"
        else
            maxByvImpl state map &enumerator

    [<MethodImpl(MethodImplOptions.AggressiveInlining)>]
    let tryMaxBy map (enumerator: SStructEnumerator<'i,'e>) =
        let mutable enumerator = enumerator
        if not ^ enumerator.MoveNext() then
            None
        else
            maxByImpl map &enumerator |> Some

    [<MethodImpl(MethodImplOptions.AggressiveInlining)>]
    let tryMaxByv state map (enumerator: SStructEnumerator<'i,'e>) =
        let mutable enumerator = enumerator
        if not ^ enumerator.MoveNext() then
            None
        else
            maxByvImpl state map &enumerator |> Some

    [<MethodImpl(MethodImplOptions.AggressiveInlining)>]
    let tryValueMaxBy map (enumerator: SStructEnumerator<'i,'e>) =
        let mutable enumerator = enumerator
        if not ^ enumerator.MoveNext() then
            ValueNone
        else
            maxByImpl map &enumerator |> ValueSome

    [<MethodImpl(MethodImplOptions.AggressiveInlining)>]
    let tryValueMaxByv state map (enumerator: SStructEnumerator<'i,'e>) =
        let mutable enumerator = enumerator
        if not ^ enumerator.MoveNext() then
            ValueNone
        else
            maxByvImpl state map &enumerator |> ValueSome

    let inline sum (enumerator: SStructEnumerator<'i,'e>) = Core.TODO<'obj>

    [<MethodImpl(MethodImplOptions.AggressiveInlining)>]
    let length (enumerator: SStructEnumerator<'i,'e>) =
        let mutable result = 0
        let mutable enumerator = enumerator
        while enumerator.MoveNext() do
            &result +<- 1
        result

    [<MethodImpl(MethodImplOptions.AggressiveInlining)>]
    let toArray (enumerator: SStructEnumerator<'i,'e>) = arr {
        let mutable enumerator = enumerator
        while enumerator.MoveNext() do
            enumerator.Current
    }

    [<MethodImpl(MethodImplOptions.AggressiveInlining)>]
    let toResizeArray (enumerator: SStructEnumerator<'i,'e>) = rsz {
        let mutable enumerator = enumerator
        while enumerator.MoveNext() do
            enumerator.Current
    }

    [<MethodImpl(MethodImplOptions.AggressiveInlining)>]
    let toBlock (enumerator: SStructEnumerator<'i,'e>) = block {
        let mutable enumerator = enumerator
        while enumerator.MoveNext() do
            enumerator.Current
    }

    let toSeq (enumerator: SStructEnumerator<'i,'e>) =
        let boxed = enumerator :> IEnumerator<'i>
        { new IEnumerable<'i> with
            member _.GetEnumerator() = boxed :> System.Collections.IEnumerator
            member _.GetEnumerator() = boxed }

    // TODO: Match Seq's module functions
    // TODO: ActivePatterns
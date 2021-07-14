namespace En3Tho.FSharpExtensions

open System.Collections.Generic
open System.Runtime.CompilerServices

module GenericEnumeratorsImpl =
    type StructEnumerator<'i, 'e when 'e: struct
                                  and 'e :> IEnumerator<'i>> = 'e

    [<Struct; NoComparison; NoEquality>]
    type StructSelectEnumerator<'i, 'res, 'e when 'e: struct
                                              and 'e :> IEnumerator<'i>> =

        val mutable private enumerator: StructEnumerator<'i, 'e>
        val private map: 'i -> 'res

        new (map, enumerator) = { enumerator = enumerator; map = map; }

        [<MethodImpl(MethodImplOptions.AggressiveInlining)>]
        member this.MoveNext() = this.enumerator.MoveNext()

        member this.Current with [<MethodImpl(MethodImplOptions.AggressiveInlining)>] get() =
            this.enumerator.Current |> this.map

        member this.Dispose() = ()

        member inline internal this.GetEnumerator() = this

        interface IEnumerator<'res> with
            member this.Current = this.Current :> obj
            member this.Current = this.Current
            member this.Dispose() = ()
            member this.MoveNext() = this.MoveNext()
            member this.Reset() = ()

    [<Struct; NoComparison; NoEquality>]
    type StructWhereEnumerator<'i, 'e when 'e: struct
                                  and 'e :> IEnumerator<'i>> =

        val mutable private enumerator: StructEnumerator<'i, 'e>
        val private filter: 'i -> bool

        new (filter, enumerator) = { enumerator = enumerator; filter = filter; }

        [<MethodImpl(MethodImplOptions.AggressiveInlining)>]
        member this.MoveNext() =
            let mutable found = false
            while not found && this.enumerator.MoveNext() do
                found <-
                    if this.enumerator.Current |> this.filter then
                        true
                    else
                        false
            found
        member this.Current with [<MethodImpl(MethodImplOptions.AggressiveInlining)>] get() =
            this.enumerator.Current

        member this.Dispose() = ()

        member inline internal this.GetEnumerator() = this

        interface IEnumerator<'i> with
            member this.Current = this.Current :> obj
            member this.Current = this.Current
            member this.Dispose() = ()
            member this.MoveNext() = this.MoveNext()
            member this.Reset() = ()

    [<Struct; NoComparison; NoEquality>]
    type StructConcatEnumerator<'i, 'e when 'e: struct
                                        and 'e :> IEnumerator<'i>> =

        val mutable private enumerator1: StructEnumerator<'i, 'e>
        val mutable private enumerator2: StructEnumerator<'i, 'e>
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

        member inline internal this.GetEnumerator() = this

        interface IEnumerator<'i> with
            member this.Current = this.Current :> obj
            member this.Current = this.Current
            member this.Dispose() = ()
            member this.MoveNext() = this.MoveNext()
            member this.Reset() = ()

    [<Struct; NoComparison; NoEquality>]
    type StructArrayEnumerator<'i> =
        val private array: 'i[]
        val mutable private index: int

        new (array) = { index = -1; array = array; }

        [<MethodImpl(MethodImplOptions.AggressiveInlining)>]
        member this.MoveNext() =
            this.index <- this.index + 1
            uint32 this.index < uint32 this.array.Length


        member this.Current with [<MethodImpl(MethodImplOptions.AggressiveInlining)>] get() =
            this.array.[this.index]

        member this.Dispose() = ()

        member this.GetEnumerator() = this

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

        member this.GetEnumerator() = this

        interface IEnumerator<'i> with
            member this.Current = this.Current :> obj
            member this.Current = this.Current
            member this.Dispose() = ()
            member this.MoveNext() = this.MoveNext()
            member this.Reset() = ()

module GSeq =
    open GenericEnumeratorsImpl
    let inline getEnumerator<'i, 'e, ^seq when 'e: struct
                                           and 'e :> IEnumerator<'i>
                                           and ^seq: (member GetEnumerator: unit -> StructEnumerator<'i, 'e>)> (seq: ^seq) =
        (^seq: (member GetEnumerator: unit ->  StructEnumerator<'i, 'e>) seq)

    [<MethodImpl(MethodImplOptions.AggressiveInlining)>]
    let ofArray array = new StructArrayEnumerator<_>(array)

    [<MethodImpl(MethodImplOptions.AggressiveInlining)>]
    let ofList list = new StructFSharpListEnumerator<_>(list)

    [<MethodImpl(MethodImplOptions.AggressiveInlining)>]
    let filter filter enum = new StructWhereEnumerator<_,_>(filter, enum)

    [<MethodImpl(MethodImplOptions.AggressiveInlining)>]
    let concat enum2 enum1 = new StructConcatEnumerator<_, _>(enum1, enum2)

    [<MethodImpl(MethodImplOptions.AggressiveInlining)>]
    let map map enum = new StructSelectEnumerator<_,_,_>(map, enum)

    [<MethodImpl(MethodImplOptions.AggressiveInlining)>]
    let iter action (enum: StructEnumerator<'i,'e>) =
        let mutable enum = enum
        while enum.MoveNext() do
            action enum.Current

    [<MethodImpl(MethodImplOptions.AggressiveInlining)>]
    let iter2 action (enum: StructEnumerator<'i,'e>) (enum2: StructEnumerator<'i2,'e2>) =
        let mutable enum = enum
        let mutable enum2 = enum2
        while enum.MoveNext() && enum2.MoveNext() do
            action enum.Current enum2.Current

    [<MethodImpl(MethodImplOptions.AggressiveInlining)>]
    let iteri action (enum: StructEnumerator<'i,'e>) =
        let mutable enum = enum
        let mutable i = 0
        while enum.MoveNext() do
            action i enum.Current
            i <- i + 1

    [<MethodImpl(MethodImplOptions.AggressiveInlining)>]
    let iteri2 action (enum: StructEnumerator<'i,'e>) (enum2: StructEnumerator<'i2,'e2>) =
        let mutable enum = enum
        let mutable enum2 = enum2
        let mutable i = 0
        while enum.MoveNext() && enum2.MoveNext() do
            action i enum.Current enum2.Current
            i <- i + 1

    // TODO: Match Seq's module functions
    // TODO: ActivePatterns
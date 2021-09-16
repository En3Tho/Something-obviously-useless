namespace En3Tho.FSharp.GSeq.AlternativeGSeq

open System.Collections.Generic
open System.Runtime.CompilerServices
open En3Tho.FSharp.Extensions.Byref.Operators

#nowarn "0760"

module GSeq =
    module CustomEnumerator =
        type IGSeqEnumerator<'a> =
            abstract member MoveNext: 'a outref -> bool

        type SStructEnumerator<'i, 'e when 'e: struct
                                  and 'e :> IEnumerator<'i>> = 'e

        type SStructGSeqEnumerator<'i, 'e when 'e: struct
                                  and 'e :> IGSeqEnumerator<'i>> = 'e

        [<Struct; NoComparison; NoEquality>]
        type StructArrayEnumerator<'i> =
            val private array: 'i[]
            val mutable private index: int

            new (array) = { array = array; index = 0 }

            interface IGSeqEnumerator<'i> with
                [<MethodImpl(MethodImplOptions.AggressiveInlining)>]
                member this.MoveNext(result) =
                    if uint32 this.index < uint32 this.array.Length then
                        result <- this.array.[this.index]
                        &this.index +<- 1
                        true
                    else
                        false

        [<Struct; NoComparison; NoEquality>]
        type StructMapEnumerator<'i, 'res, 'e when 'e: struct
                                               and 'e :> IGSeqEnumerator<'i>> =

            val mutable private enumerator: SStructGSeqEnumerator<'i, 'e>
            val private map: 'i -> 'res

            new (map, enumerator) = { enumerator = enumerator; map = map; }

            interface IGSeqEnumerator<'res> with
                [<MethodImpl(MethodImplOptions.AggressiveInlining)>]
                member this.MoveNext(result) =
                    match this.enumerator.MoveNext() with
                    | true, value ->
                        result <- this.map value
                        true
                    | _ -> false

        [<Struct; NoComparison; NoEquality>]
        type StructFilterEnumerator<'i, 'e when 'e: struct
                                            and 'e :> IGSeqEnumerator<'i>> =

            val mutable private enumerator: SStructGSeqEnumerator<'i, 'e>
            val private filter: 'i -> bool

            new (filter, enumerator) = { enumerator = enumerator; filter = filter; }

            member this.Dispose() = ()

            interface IGSeqEnumerator<'i> with
                member this.MoveNext(result) =
                    let mutable found = false
                    while not found
                        && match this.enumerator.MoveNext() with
                           | true, value ->
                               found <- this.filter value
                               if found then result <- value
                               not found
                           | _ -> false
                           do ()
                    found

        [<Struct; NoComparison; NoEquality>]
        type StructSkipEnumerator<'i, 'e when 'e: struct
                                          and 'e :> IGSeqEnumerator<'i>> =

            val mutable private enumerator: SStructGSeqEnumerator<'i, 'e>
            val mutable private count: int

            new (count, enumerator) = { enumerator = enumerator; count = count; }

            interface IGSeqEnumerator<'i> with
                member this.MoveNext(result) =
                    while this.count > 0 && match this.enumerator.MoveNext() with | true, _ -> true | _ -> false
                        do &this.count -<- 1

                    match this.enumerator.MoveNext() with
                    | true, value -> result <- value; true
                    | _ -> false

        [<MethodImpl(MethodImplOptions.AggressiveInlining)>]
        let ofArray array = StructArrayEnumerator(array)

        [<MethodImpl(MethodImplOptions.AggressiveInlining)>]
        let filter filter enumerator = StructFilterEnumerator(filter, enumerator)

        [<MethodImpl(MethodImplOptions.AggressiveInlining)>]
        let map map enumerator = StructMapEnumerator(map, enumerator)

        [<MethodImpl(MethodImplOptions.AggressiveInlining)>]
        let skip count enumerator = StructSkipEnumerator(count, enumerator)

        [<MethodImpl(MethodImplOptions.AggressiveInlining)>]
        let fold initial folder (enumerator: SStructGSeqEnumerator<'i,'e>) =
            let folder = OptimizedClosures.FSharpFunc<_,_,_>.Adapt folder
            let mutable enumerator = enumerator
            let mutable result = initial
            while
                match enumerator.MoveNext() with
                | true, value ->
                    result <- folder.Invoke(result, value)
                    true
                | _ -> false
                do()
            result

    module StructFuncBased =

        type SStructEnumerator<'i, 'e when 'e: struct
                                  and 'e :> IEnumerator<'i>> = 'e

        type IInvocable<'a, 'b> =
            abstract member Invoke: value: 'a -> 'b

        type IInvocable<'a, 'b, 'c> =
            abstract member Invoke: value: 'a * value2: 'b -> 'c

        type IInvocable<'a, 'b, 'c, 'd> =
            abstract member Invoke: value: 'a * value2: 'b * value3: 'c -> 'd

        type SStructFunc<'f, 'a, 'b when 'f: struct
                                    and 'f :> IInvocable<'a, 'b>> = 'f

        type SStructFunc<'f, 'a, 'b, 'c when 'f: struct
                                        and 'f :> IInvocable<'a, 'b, 'c>> = 'f

        [<Struct; NoComparison; NoEquality>]
        type StructMapEnumeratorExperimental<'i, 'res, 'e, 'f when 'e: struct
                                                               and 'e :> IEnumerator<'i>
                                                               and 'f: struct
                                                               and 'f :> IInvocable<'i, 'res>> =

            val mutable private enumerator: SStructEnumerator<'i, 'e>
            val private map: 'f

            new (map, enumerator) = { enumerator = enumerator; map = map; }

            [<MethodImpl(MethodImplOptions.AggressiveInlining)>]
            member this.MoveNext() = this.enumerator.MoveNext()

            member this.Current with [<MethodImpl(MethodImplOptions.AggressiveInlining)>] get() =
                this.enumerator.Current |> this.map.Invoke

            member this.Dispose() = ()

            interface IEnumerator<'res> with
                member this.Current = this.Current :> obj
                member this.Current = this.Current
                member this.Dispose() = ()
                member this.MoveNext() = this.MoveNext()
                member this.Reset() = ()

        [<Struct; NoComparison; NoEquality>]
        type StructFilterEnumeratorExperimental<'i, 'e, 'f when 'e: struct
                                                            and 'e :> IEnumerator<'i>
                                                            and 'f: struct
                                                            and 'f :> IInvocable<'i, bool>> =

            val mutable private enumerator: SStructEnumerator<'i, 'e>
            val private filter: 'f

            new (filter, enumerator) = { enumerator = enumerator; filter = filter; }

            [<MethodImpl(MethodImplOptions.AggressiveInlining)>]
            member this.MoveNext() =
                let mutable found = false
                while not found && this.enumerator.MoveNext() do
                    found <- this.enumerator.Current |> this.filter.Invoke
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

        [<MethodImpl(MethodImplOptions.AggressiveInlining)>]
        let filter filter enumerator = StructFilterEnumeratorExperimental(filter, enumerator)

        [<MethodImpl(MethodImplOptions.AggressiveInlining)>]
        let map map enumerator = StructMapEnumeratorExperimental(map, enumerator)

        [<MethodImpl(MethodImplOptions.AggressiveInlining)>]
        let fold initial (folder: SStructFunc<_, _, _, _>) (enumerator: SStructEnumerator<'i,'e>) =
            let mutable enumerator = enumerator
            let mutable result = initial
            while enumerator.MoveNext() do
                result <- folder.Invoke(result, enumerator.Current)
            result
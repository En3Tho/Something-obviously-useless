module Benchmarks.FSharp.Lib.GSeq

open BenchmarkDotNet.Attributes
open En3Tho.FSharp.Extensions.Core
open En3Tho.FSharp.GSeq
open En3Tho.FSharp.GSeq.GenericEnumeratorsImpl

type [<Struct>] FoldPlus =
    interface IInvocable<int, int, int> with
        member this.Invoke(value, value2) = value + value2

type [<Struct>] FilterIsOdd =
    interface IInvocable<int, bool> with
        member this.Invoke(value) = value % 2 <> 0

type [<Struct>] MapPlus15 =
    interface IInvocable<int, int> with
        member this.Invoke(value) = value + 15

[<MemoryDiagnoser; DisassemblyDiagnoser>]
type Benchmark() =
    [<Params(10, 100, 1000)>]
    member val Count = 0 with get, set

    member val Items = [||] with get, set

    [<GlobalSetup>]
    member this.GlobalSetup() =
        this.Items <- Array.init this.Count id

    [<Benchmark>]
    member this.SeqFilterMapSkipFold() =
        this.Items
        |> Seq.filter ^ fun x -> x % 2 <> 0
        |> Seq.skip 5
        |> Seq.map ^ fun x -> x + 15
        |> Seq.fold (fun x y -> x + y) 0

    [<Benchmark>]
    member this.GSeqFilterMapSkipFold() =
        this.Items
        |> GSeq.ofArray
        |> GSeq.filter ^ fun x -> x % 2 <> 0
        |> GSeq.skip 5
        |> GSeq.map ^ fun x -> x + 15
        |> GSeq.fold 0 ^ fun x y -> x + y

    [<Benchmark>]
    member this.GSeqFilterMapSkipFoldHybrid() =
        this.Items
        |> GSeq.ofArray
        |> GSeq.filter ^ fun x -> x % 2 <> 0
        |> GSeq.skip 5
        |> GSeq.map ^ fun x -> x + 15
        |> GSeq.toSeq
        |> Seq.fold (fun x y -> x + y) 0

    [<Benchmark>]
    member this.GSeqFilterMapSkipFoldExp() =
        this.Items
        |> GSeq.ofArray
        |> GSeq.filterExperimental (FilterIsOdd())
        |> GSeq.skip 5
        |> GSeq.mapExperimental (MapPlus15())
        |> GSeq.foldExperimental 0 (FoldPlus())

    [<Benchmark>]
    member this.LoopFilterMapSkipFold() =
        let mutable skip = 0
        let mutable result = 0
        for item in this.Items do
            if item % 2 <> 0 then
                if skip < 5 then
                    skip <- skip + 1
                else result <- result + item
        result
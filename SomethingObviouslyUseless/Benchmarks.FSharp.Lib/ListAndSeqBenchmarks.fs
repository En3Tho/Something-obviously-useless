module Benchmarks.FSharp.ListAndSeqBenchmarks

open BenchmarkDotNet.Attributes
open BenchmarkDotNet.Jobs

type SomeRecord = {
    IsValid: bool
    Data: string
}

type SomeRecord2 = {
    Number: int
    Data: string
}

[<MemoryDiagnoser>]
[<SimpleJob(RuntimeMoniker.NetCoreApp31)>]
[<SimpleJob(RuntimeMoniker.NetCoreApp50)>]
type ListAndSeqBench() =
    [<Params(10, 50, 100)>]
    member val Count = 0 with get, set

    member val RecordsList = [] with get, set
    member val Records2List = [] with get, set

    [<GlobalSetup>]
    member this.GlobalSetup() =
        this.RecordsList <- List.init this.Count (fun i -> { IsValid = i % 2 = 0; Data = i.ToString() })
        this.Records2List <- List.init this.Count (fun i -> { Number = i; Data = i.ToString() })

    [<Benchmark>]
    member this.ListZipFilterMap() =
        List.zip this.RecordsList this.Records2List |> List.filter (fun (x, _) -> x.IsValid) |> List.map snd

    [<Benchmark>]
    member this.SeqZipFilterMap() =
        Seq.zip this.RecordsList this.Records2List |> Seq.filter (fun (x, _) -> x.IsValid) |> Seq.map snd |> Seq.toList

    [<Benchmark>]
    member this.ListFold2() =
        List.fold2 (fun lst r1 r2 -> if r1.IsValid then r2 :: lst else lst) [] this.RecordsList this.Records2List

    [<Benchmark>]
    member this.ListFold2Rev() =
        List.fold2 (fun lst r1 r2 -> if r1.IsValid then r2 :: lst else lst) [] this.RecordsList this.Records2List
        |> List.rev

    [<Benchmark>]
    member this.ListFoldBack2() =
        [] |> List.foldBack2 (fun r1 r2 lst -> if r1.IsValid then r2 :: lst else lst) this.RecordsList this.Records2List

    [<Benchmark>]
    member this.ListChoose() =
        this.RecordsList |> List.choose (fun r -> if r.IsValid then Some r else None)

    [<Benchmark>]
    member this.ListFold() =
        this.RecordsList |> List.fold (fun lst r -> if r.IsValid then r :: lst else lst) []

    [<Benchmark>]
    member this.ListFoldRev() =
        this.RecordsList |> List.fold (fun lst r -> if r.IsValid then r :: lst else lst) [] |> List.rev

    [<Benchmark>]
    member this.ListFoldBack() =
        [] |> List.foldBack (fun r lst -> if r.IsValid then r :: lst else lst) this.RecordsList
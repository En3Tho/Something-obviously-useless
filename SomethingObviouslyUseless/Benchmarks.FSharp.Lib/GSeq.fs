module Benchmarks.FSharp.Lib.GSeq

open BenchmarkDotNet.Attributes
open BenchmarkDotNet.Configs
open BenchmarkDotNet.Jobs
open BenchmarkDotNet.Environments;
open Benchmarks.CSharp.Lib
open En3Tho.FSharp.Extensions.Core
open En3Tho.FSharp.GSeq
open En3Tho.FSharp.GSeq.AlternativeGSeq

type [<Struct>] FoldPlus =
    interface GSeq.StructFuncBased.IInvocable<int, int, int> with
        member this.Invoke(value, value2) = value + value2

type [<Struct>] FilterIsOdd =
    interface GSeq.StructFuncBased.IInvocable<int, bool> with
        member this.Invoke(value) = value % 2 <> 0

type [<Struct>] MapPlus15 =
    interface GSeq.StructFuncBased.IInvocable<int, int> with
        member this.Invoke(value) = value + 15

type private BenchmarkConfig() =
    inherit ManualConfig()

    let [<Literal>] TieredPGO = "DOTNET_TieredPGO"
    let [<Literal>] QuickJitForLoops = "DOTNET_TC_QuickJitForLoop"
    let [<Literal>] ReadyToRun = "DOTNET_ReadyToRun"

    do
        base.AddJob([|
            Job.Default.WithRuntime(CoreRuntime.Core50).WithId("Net5")
            Job.Default.WithRuntime(CoreRuntime.Core60).WithId("NoPGO")
            Job.Default.WithRuntime(CoreRuntime.Core60).WithId("DynamicPGO")
                        .WithEnvironmentVariables(EnvironmentVariable(TieredPGO, "1"),
                                                  EnvironmentVariable(QuickJitForLoops, "1"),
                                                  EnvironmentVariable(ReadyToRun, "0"))
        |]) |> ignore

[<MemoryDiagnoser; DisassemblyDiagnoser>]
[<Config(typeof<BenchmarkConfig>)>]
type Benchmark() =

    [<Params(10, 100, 1000)>]
    member val Count = 0 with get, set

    member val Array = [||] with get, set

    [<GlobalSetup>]
    member this.GlobalSetup() =
        this.Array <- Array.init this.Count id

   // [<Benchmark>]
    member this.SeqFilterMapSkipFold() =
        this.Array
        |> Seq.filter ^ fun x -> x % 2 <> 0
        |> Seq.skip 5
        |> Seq.map ^ fun x -> x + 15
        |> Seq.fold (fun x y -> x + y) 0

    [<Benchmark>]
    member this.GSeqFilterMapSkipFold() =
        this.Array
        |> GSeq.ofArray
//        |> GSeq.filter ^ fun x -> x % 2 <> 0
//        |> GSeq.skip 5
//        |> GSeq.map ^ fun x -> x + 15
        |> GSeq.fold 0 ^ fun x y -> x + y

    [<Benchmark>]
    member this.GSeqFilterMapSkipFoldTest() =
        this.Array
        |> GSeq.ofArray
//        |> GSeq.filter ^ fun x -> x % 2 <> 0
//        |> GSeq.skip 5
//        |> GSeq.map ^ fun x -> x + 15
        |> fun gseq -> GSeq.foldTest(0, (fun x y -> x + y), gseq)

    [<Benchmark>]
    member this.GSeqFilterMapSkipFoldTestMember() =
        this.Array
        |> GSeq.ofArray
//        |> GSeq.filter ^ fun x -> x % 2 <> 0
//        |> GSeq.skip 5
//        |> GSeq.map ^ fun x -> x + 15
        |> fun gseq -> GSeq.GSeq2.foldTest(0, (fun x y -> x + y), gseq)

    [<Benchmark>]
    member this.GSeqFilterMapSkipCSharpFold() =
        this.Array
        |> GSeq.ofArray
//        |> GSeq.filter ^ fun x -> x % 2 <> 0
//        |> GSeq.skip 5
//        |> GSeq.map ^ fun x -> x + 15
        |> fun gseq -> GSeqCSharp.Fold(0, (fun x y -> x + y), gseq)

    //[<Benchmark>]
    member this.GSeqFilterMapSkipFoldHybrid() =
        this.Array
        |> GSeq.ofArray
        |> GSeq.filter ^ fun x -> x % 2 <> 0
        |> GSeq.skip 5
        |> GSeq.map ^ fun x -> x + 15
        |> GSeq.toSeq
        |> Seq.fold (fun x y -> x + y) 0

    //[<Benchmark>]
    member this.GSeqFilterMapSkipFoldStructFuncBased() =
        this.Array
        |> GSeq.ofArray
        |> GSeq.StructFuncBased.filter (FilterIsOdd())
        |> GSeq.skip 5
        |> GSeq.StructFuncBased.map (MapPlus15())
        |> GSeq.StructFuncBased.fold 0 (FoldPlus())

    //[<Benchmark>]
    member this.GSeqFilterMapSkipFoldCustomEnumeratorBased() =
        this.Array
        |> GSeq.CustomEnumerator.ofArray
        |> GSeq.CustomEnumerator.filter ^ fun x -> x % 2 <> 0
        |> GSeq.CustomEnumerator.skip 5
        |> GSeq.CustomEnumerator.map ^ fun x -> x + 15
        |> GSeq.CustomEnumerator.fold 0 ^ fun x y -> x + y

    //[<Benchmark>]
    member this.LoopFilterMapSkipFold() =
        let mutable skip = 0
        let mutable result = 0
        for item in this.Array do
            if item % 2 <> 0 then
                if skip < 5 then
                    skip <- skip + 1
                else result <- result + item
        result
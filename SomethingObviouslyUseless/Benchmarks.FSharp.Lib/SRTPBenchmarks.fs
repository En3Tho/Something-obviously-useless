module Benchmarks.FSharp.SRTPBenchmarks

open System.Collections.Generic
open BenchmarkDotNet.Attributes
open BenchmarkDotNet.Jobs

module CustomSeq =
    let inline iter< ^a, 'b when ^a: (member GetEnumerator: unit -> IEnumerator< 'b>)> f seq =
        let enumerator = (^a: (member GetEnumerator: unit -> IEnumerator< 'b>) seq)
        while enumerator.MoveNext() do
            f enumerator.Current

let readFrom = [|
    for i = 0 to 1000 do
        string i
|]

[<MemoryDiagnoser>]
[<SimpleJob(RuntimeMoniker.NetCoreApp31)>]
[<SimpleJob(RuntimeMoniker.NetCoreApp50)>]
type CustomIter() =
    member _.LibraryIter() =
        let mutable sum = 0
        readFrom |> Seq.iter (fun str -> sum <- sum + str.Length)
        sum

//    member _.CustomIter() =
//        let mutable sum = 0
//        readFrom :> IEnumerable<string> |> CustomSeq.iter (fun str -> sum <- sum + str.Length)
//        sum
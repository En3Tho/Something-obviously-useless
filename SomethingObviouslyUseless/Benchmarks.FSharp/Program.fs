// Learn more about F# at http://docs.microsoft.com/dotnet/fsharp

open BenchmarkDotNet.Running
open Benchmarks.FSharp
open Benchmarks.FSharp.Lib

[<EntryPoint>]
let main argv =
    //Record.apply ApplyBenchmark.basicType3 ApplyBenchmark.valueToApply2 |> ignore
    BenchmarkRunner.Run<CustomBuildersVsLibraryBuilders.Benchmark>() |> ignore
    //Disposables.testConcurrentAccess()
    0 // return an integer exit code
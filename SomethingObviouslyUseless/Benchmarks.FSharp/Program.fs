// Learn more about F# at http://docs.microsoft.com/dotnet/fsharp

open BenchmarkDotNet.Running
open Benchmarks.FSharp

[<EntryPoint>]
let main argv =
    //Record.apply ApplyBenchmark.basicType3 ApplyBenchmark.valueToApply2 |> ignore
    BenchmarkRunner.Run<ActivePatterns.ExistsVsExistsv>() |> ignore
    //Disposables.testConcurrentAccess()
    0 // return an integer exit code
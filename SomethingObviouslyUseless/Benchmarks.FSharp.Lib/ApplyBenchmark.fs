module Benchmarks.FSharp.ApplyBenchmark

open System
open BenchmarkDotNet.Attributes
open En3Tho.FSharpExtensions

type RecordType3 = { Id : int; Name : string; SomeNum : float }
type RecordType4 = { Id : int; Name : string; SomeNum : float; SomeText : string }
type RecordType5 = { Id : int; Name : string; SomeNum : float; SomeText : string; SomeValue : obj }

let basicType3 = { RecordType3.Id = 0; Name = ""; SomeNum = 0. }
let basicType4 = { RecordType4.Id = 0; Name = ""; SomeNum = 0.; SomeText = "" }
let basicType5 = { RecordType5.Id = 0; Name = ""; SomeNum = 0.; SomeText = ""; SomeValue = Object() }

let valueToApply2 = {| Id = 123; Name = "123"; |}
let valueToApply3 = {| Id = 123; Name = "123"; SomeNum = 123. |}
let valueToApply4 = {| Id = 123; Name = "123"; SomeNum = 123.; SomeText = "123" |}
let valueToApply5 = {| Id = 123; Name = "123"; SomeNum = 123.; SomeText = "123"; SomeValue = Object() |}

[<MemoryDiagnoser>]
type Applier() =
    [<Benchmark>]
    member _.ApplyFSharp32() = { basicType3 with Id = valueToApply2.Id; Name = valueToApply2.Name }
    [<Benchmark>]
    member _.ApplyFSharp33() = { basicType3 with Id = valueToApply3.Id; Name = valueToApply3.Name; SomeNum = valueToApply3.SomeNum }
    [<Benchmark>]
    member _.ApplyFSharp43() = { basicType4 with Id = valueToApply3.Id; Name = valueToApply3.Name; SomeNum = valueToApply3.SomeNum }
    [<Benchmark>]
    member _.ApplyFSharp44() = { basicType4 with Id = valueToApply4.Id; Name = valueToApply4.Name; SomeNum = valueToApply4.SomeNum; SomeText = valueToApply4.SomeText }
    [<Benchmark>]
    member _.ApplyFSharp54() = { basicType5 with Id = valueToApply4.Id; Name = valueToApply4.Name; SomeNum = valueToApply4.SomeNum; SomeText = valueToApply4.SomeText }
    [<Benchmark>]
    member _.ApplyFSharp55() = { basicType5 with Id = valueToApply5.Id; Name = valueToApply5.Name; SomeNum = valueToApply5.SomeNum; SomeText = valueToApply5.SomeText; SomeValue = valueToApply5.SomeValue }

    [<Benchmark>]
    member _.ApplyGenerated32() = Record.apply basicType3 valueToApply2
    [<Benchmark>]
    member _.ApplyGenerated33() = Record.apply basicType3 valueToApply3
    [<Benchmark>]
    member _.ApplyGenerated43() = Record.apply basicType4 valueToApply3
    [<Benchmark>]
    member _.ApplyGenerated44() = Record.apply basicType4 valueToApply4
    [<Benchmark>]
    member _.ApplyGenerated54() = Record.apply basicType5 valueToApply4
    [<Benchmark>]
    member _.ApplyGenerated55() = Record.apply basicType5 valueToApply5
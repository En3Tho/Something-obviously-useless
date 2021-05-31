module Benchmarks.FSharp.FuncsVsFSharpFuncs

open System
open BenchmarkDotNet.Attributes

module List =
    let iteri2WithFunc (func: Func<int, 'a, 'a, 'a>) list1 list2 =
        let rec iteri2Internal i list1 list2 =
            match list1, list2 with
            | h1 :: t1, h2 :: t2 ->
                func.Invoke(i, h1, h2) |> ignore
                iteri2Internal (i + 1) t1 t2
            | [], [] -> ()
            | _ -> invalidOp "Lists cannot have different lengths"

        iteri2Internal 0 list1 list2

let values = [
    for i in 0..10 do i
]

let values2 = values

let uncurriedPlus x y z = x + y + z
let curriedPlus2 x =
    fun y z -> x + y + z

let curriedPlus3 x =
    fun y ->
        fun z -> x + y + z

let getUncurriedPlus() =
    //printf "%A" |> ignore
    fun x y z -> x + y + z

let getCurriedPlus2() =
    //printf "%A" |> ignore
    fun x ->
        fun y z -> x + y + z

let getCurriedPlus3() =
    //printf "%A" |> ignore
    fun x ->
        fun y ->
            fun z -> x + y + z

let getCurriedOrUncurriedPlus x =
    match x with
    | 0 -> getUncurriedPlus()
    | 1 -> getCurriedPlus2()
    | _ -> getCurriedPlus3()

let uncurriedFuncWithIgnore x y z = x + y + z |> ignore

let cachedUncurriedFuncWithIgnore =
    let getFunc() = fun x y z -> x + y + z |> ignore
    getFunc()

let uncurriedMarker = [ for i in 0..0 do i ] |> List.head
let uncurriedValuePlus = getCurriedOrUncurriedPlus uncurriedMarker
let curriedValuePlus2 = getCurriedOrUncurriedPlus (uncurriedMarker + 1)
let curriedValuePlus3 = getCurriedOrUncurriedPlus (uncurriedMarker + 2)

let uncurriedDelegate = Func<int, int, int, int>(fun x y z -> x + y + z)
let curriedDelegate2 = Func<int, Func<int, int, int>>(fun x -> Func<int, int, int>(fun y z -> x + y + z))
let curriedDelegate3 = Func<int, Func<int, Func<int, int>>>(fun x -> Func<int, Func<int, int>>(fun y -> Func<int, int>(fun z -> x + y + z)))

let callDirectDelegateUncurriedPlus() =
    (values, values2) ||> List.iteri2WithFunc uncurriedDelegate

[<MemoryDiagnoser>]
type SimpleBenchmark() =
    [<Benchmark>]
    member _.CallDirectUncurriedPlus() =
        (values, values2) ||> List.iteri2 (fun index v1 v2 -> index + v1 + v2 |> ignore)

    [<Benchmark>]
    member _.CallDirectCurriedPlus2() =
        (values, values2) ||> List.iteri2 (fun index v1 v2 -> (fun v1 v2 -> index + v1 + v2) v1 v2 |> ignore)

    [<Benchmark>]
    member _.CallDirectCurriedPlus3() =
        (values, values2) ||> List.iteri2 (fun index v1 v2 -> ((fun v1 -> fun v2 -> index + v1 + v2) v1) v2 |> ignore)

    [<Benchmark>]
    member _.CallLetFuncUncurriedPlus() =
        (values, values2) ||> List.iteri2 (fun index v1 v2 -> uncurriedPlus index v1 v2 |> ignore)

    [<Benchmark>]
    member _.CallLetFuncCurriedPlus2() =
        (values, values2) ||> List.iteri2 (fun index v1 v2 -> curriedPlus2 index v1 v2 |> ignore)

    [<Benchmark>]
    member _.CallLetFuncCurriedPlus3() =
        (values, values2) ||> List.iteri2 (fun index v1 v2 -> curriedPlus3 index v1 v2 |> ignore)

    [<Benchmark>]
    member _.CallLetValueFuncUncurriedPlus() =
        (values, values2) ||> List.iteri2 (fun index v1 v2 -> uncurriedValuePlus index v1 v2 |> ignore)

    [<Benchmark>]
    member _.CallLetValueFuncCurriedPlus2() =
        (values, values2) ||> List.iteri2 (fun index v1 v2 -> curriedValuePlus2 index v1 v2 |> ignore)

    [<Benchmark>]
    member _.CallLetValueFuncCurriedPlus3() =
        (values, values2) ||> List.iteri2 (fun index v1 v2 -> curriedValuePlus3 index v1 v2 |> ignore)

    [<Benchmark>]
    member _.CallLetFuncUncurriedPlusWithIgnore() =
        (values, values2) ||> List.iteri2 uncurriedFuncWithIgnore

    [<Benchmark>]
    member _.CallCachedUncurriedPlusWithIgnore() =
        (values, values2) ||> List.iteri2 cachedUncurriedFuncWithIgnore

    [<Benchmark>]
    member _.CallDelegateUncurriedPlus() =
        (values, values2) ||> List.iteri2 (fun index v1 v2 -> uncurriedDelegate.Invoke(index, v1, v2) |> ignore)

    [<Benchmark>]
    member _.CallDirectDelegateUncurriedPlus() =
        (values, values2) ||> List.iteri2WithFunc uncurriedDelegate

    [<Benchmark>]
    member _.CallDelegateCurriedPlus2() =
        (values, values2) ||> List.iteri2 (fun index v1 v2 -> curriedDelegate2.Invoke(index).Invoke(v1, v2) |> ignore)

    [<Benchmark>]
    member _.CallDelegateCurriedPlus3() =
        (values, values2) ||> List.iteri2 (fun index v1 v2 -> curriedDelegate3.Invoke(index).Invoke(v1).Invoke(v2) |> ignore)
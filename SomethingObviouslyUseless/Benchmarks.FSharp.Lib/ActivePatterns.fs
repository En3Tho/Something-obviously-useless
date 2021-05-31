module Benchmarks.FSharp.ActivePatterns

open System
open System.Collections.Generic
open BenchmarkDotNet.Attributes

type FSharpList<'a> = list<'a>

module Option =
    let someObj = Some()
    let inline ofBool value = if value then someObj else None

let cache f = f

[<Struct>]
type ListEnumerator<'a> =
    val mutable list: FSharpList<'a>
    val mutable current: 'a
    new (list) = { list = list; current = Unchecked.defaultof<'a> }

    member this.MoveNext() =
        match this.list with
        | h :: t ->
            this.list <- t
            this.current <- h
            true
        | [] ->
            false

    member this.Current = this.current
    member this.Reset() = invalidOp "This iterator does not support resetting"
    member this.Dispose() = ()

    interface IEnumerator<'a> with
        member this.Current = this.Current
        member this.Current = this.Current :> obj
        member this.Dispose() = this.Dispose()
        member this.MoveNext() = this.MoveNext()
        member this.Reset() = this.Reset()

[<Struct>]
type ArrayEnumerator<'a> =
    val mutable array: 'a[]
    val mutable index: int
    new (array) = { array = array; index = -1 }

    member this.MoveNext() =
        this.index <- this.index + 1
        this.index < this.array.Length
    member this.Current = this.array.[this.index]
    member this.Reset() = this.index <- -1
    member this.Dispose() = ()

    interface IEnumerator<'a> with
        member this.Current = this.Current
        member this.Current = this.Current :> obj
        member this.Dispose() = this.Dispose()
        member this.MoveNext() = this.MoveNext()
        member this.Reset() = this.Reset()

module Array =
    let inline getEnumerator array = new ArrayEnumerator<'a>(array)
    let inline existsv state f (array: 'a[]) =
        let mutable found = false
        let mutable index = 0
        while not found && index < array.Length do
            found <- f state array.[index]
            index <- index + 1
        found

module List =
    let inline getEnumerator list = new ListEnumerator<'a>(list)
    let inline existsv state f list =
        let rec existsvInternal list =
            match list with
            | h :: t ->
                if f state h then
                    true
                else
                    existsvInternal t
            | _ -> false
        existsvInternal list

module ResizeArray =
    let inline existsv state f (list: 'a ResizeArray) =
        let mutable found = false
        let mutable index = 0
        while not found && index < list.Count do
            found <- f state list.[index]
            index <- index + 1
        found

module IEnumerator =
    let inline exists f (enumerator: #IEnumerator<'a> byref) =
        let mutable found = false
        while not found && enumerator.MoveNext() do
            found <- f enumerator.Current
        found

    let inline existsv state f (enumerator: #IEnumerator<'a> byref) =
        let mutable found = false
        while not found && enumerator.MoveNext() do
            found <- f state enumerator.Current
        found

module Seq =
    let inline getEnumerator (seq: #IEnumerable<'a>) = seq.GetEnumerator()

    let inline existsv state f (seq: 'a seq) =
        match seq with
        | :? FSharpList<'a> as list -> List.existsv state f list
        | :? ('a[]) as array -> Array.existsv state f array
        | :? ResizeArray<'a> as list -> ResizeArray.existsv state f list
        | _ ->
        let mutable enumerator = getEnumerator seq
        let mutable found = false
        while not found && enumerator.MoveNext() do
            found <- f state enumerator.Current
        found

module String =
    let inline equalsOrdinal value (str: string) = str.Equals(value, StringComparison.OrdinalIgnoreCase)
    let inline equalsOrdinalIgnoreCase value (str: string) = str.Equals(value, StringComparison.OrdinalIgnoreCase)

    module ActivePatterns =
        let inline (|EqualsAnyOrdinalIgnoreCasev|_|) values (str: string) =
            values |> Seq.existsv str equalsOrdinalIgnoreCase |> Option.ofBool

        let inline (|EqualsAnyOrdinalIgnoreCasevl|_|) values (str: string) =
            values |> List.existsv str equalsOrdinalIgnoreCase |> Option.ofBool

        let inline (|EqualsAnyOrdinalIgnoreCaseva|_|) values (str: string) =
            values |> Array.existsv str equalsOrdinalIgnoreCase |> Option.ofBool

        let inline (|EqualsAnyOrdinalIgnoreCase|_|) values (str: string) =
            values |> Seq.exists (equalsOrdinalIgnoreCase str) |> Option.ofBool

let valuesList = [
    for i in 1000000..1000010 do
        string i
]

let valuesArray = List.toArray valuesList

let value = [ for i in 1000011..1000011 do string i ] |> List.head

[<MemoryDiagnoser>]
type ExistsVsExistsv() =
    [<Benchmark>]
    member _.Exists() =
        match value with
        | String.ActivePatterns.EqualsAnyOrdinalIgnoreCase valuesList -> true
        | _ -> false
        |> ignore

    [<Benchmark>]
    member _.ExistsvListAsSeq() =
        match value with
        | String.ActivePatterns.EqualsAnyOrdinalIgnoreCasev valuesList -> true
        | _ -> false
        |> ignore

    [<Benchmark>]
    member _.ExistsvArrayAsSeq() =
        match value with
        | String.ActivePatterns.EqualsAnyOrdinalIgnoreCasev valuesArray -> true
        | _ -> false
        |> ignore

    [<Benchmark>]
    member _.ExistsvList() =
        match value with
        | String.ActivePatterns.EqualsAnyOrdinalIgnoreCasevl valuesList -> true
        | _ -> false
        |> ignore

    [<Benchmark>]
    member _.ExistsvArray() =
        match value with
        | String.ActivePatterns.EqualsAnyOrdinalIgnoreCaseva valuesArray -> true
        | _ -> false
        |> ignore
namespace AutoDecoratorGeneratorFSharp.Core

open System
open System.Linq

[<AutoOpen>]
module internal TopLevelOperators =
    let inline (^) f x = f x
    let someObj = Some()
    let inline (|NotNull|_|) (value: 'a when 'a: not struct) = if Object.ReferenceEquals(value, null) |> not then someObj else None

module Option =
    let inline ofBool value = if value then someObj else None

module Seq =
    let inline ofType<'a> seq = Enumerable.OfType<'a> seq
    let inline identical (seq2: 'a seq) (seq1: 'a seq) =
        use enum1 = seq1.GetEnumerator()
        use enum2 = seq2.GetEnumerator()

        let rec moveNext() =
            match enum1.MoveNext(), enum2.MoveNext() with
            | true, true ->
                enum1.Current = enum2.Current
                && moveNext()
            | false, false -> true
            | _ -> false

        moveNext()

    let identicalBy equals (seq2: 'a seq) (seq1: 'a seq) =
        use enum1 = seq1.GetEnumerator()
        use enum2 = seq2.GetEnumerator()

        let rec moveNext() =
            match enum1.MoveNext(), enum2.MoveNext() with
            | true, true ->
                enum1.Current |> equals enum2.Current
                && moveNext()
            | false, false -> true
            | _ -> false

        moveNext()
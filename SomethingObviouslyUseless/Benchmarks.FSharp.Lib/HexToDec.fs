module Benchmarks.FSharp.HexToDec

open System

#nowarn "9"

open System
open System.Globalization
open Microsoft.FSharp.NativeInterop
open BenchmarkDotNet.Attributes
open BenchmarkDotNet.Running

let inline private stackalloc<'a when 'a: unmanaged> size =
    let p = NativePtr.stackalloc<'a> size |> NativePtr.toVoidPtr
    Span<'a>(p, size)

let someObj = Some()

type And = And
let inline (|Between|_|) a (_: And) b value = if value >= a && value <= b then someObj else None

let createHexToDecLut (converter: int -> 'a) = [|
    for i = 0 to 255 do
        match char i with
        | Between 'A' And 'F' -> i - 55
        | Between 'a' And 'f' -> i - 90
        | Between '0' And '9' -> i - 48
        | _ -> 0
        |> converter
|]

let inline hexToDec (hex: byte) =
    if hex > '9'B then
        hex - 'a'B + 10uy
    else
        hex - '0'B

let hexToDecLut = createHexToDecLut int64

let inline hexToDec2 (hex: byte) =
    hexToDecLut.[int hex]

let inline hexToInt642 (bytes: ReadOnlySpan<byte>) =
    let mutable x = 0L
    let last = bytes.Length - 1
    for i in 0..last do
        x <- x + (hexToDec2 bytes.[i] <<< 4 * (last - i))
    x

let inline hexToInt64 (bytes: ReadOnlySpan<byte>) =
    let mutable x = 0L
    let last = bytes.Length - 1
    for i = 0 to last do
        x <- x + (int64 (hexToDec bytes.[i]) <<< 4 * (last - i))
    x

let inline hexTo (convert: byte -> ^a) (bytes: ReadOnlySpan<byte>): ^a  =
    let mutable x = LanguagePrimitives.GenericZero
    let last = bytes.Length - 1
    for i = 0 to last do
        x <- x + (convert (hexToDec bytes.[i]) <<< 4 * (last - i))
    x

[<MemoryDiagnoser>]
type Tests() =

    member _.Data() = seq {
        "243c104b2d800"B
    }

    [<Benchmark(Baseline = true)>]
    [<ArgumentsSource("Data")>]
    member _.HexToInt64(bytes: array<byte>) =
        hexToInt64 (ReadOnlySpan(bytes))

    [<Benchmark>]
    [<ArgumentsSource("Data")>]
    member _.HexToInt642(bytes: array<byte>) =
        hexToInt642 (ReadOnlySpan(bytes))

    [<Benchmark>]
    [<ArgumentsSource("Data")>]
    member _.HexToInt64Generic(bytes: array<byte>) =
        hexTo int64 (ReadOnlySpan(bytes))

    [<Benchmark>]
    [<ArgumentsSource("Data")>]
    member _.ConvertToInt64(bytes: array<byte>) =
        let a = Text.Encoding.UTF8.GetString(ReadOnlySpan(bytes))
        Convert.ToInt64(a, 16)

    [<Benchmark>]
    [<ArgumentsSource("Data")>]
    member _.Int64Parse(bytes: array<byte>) =
        let a = Text.Encoding.UTF8.GetString(ReadOnlySpan(bytes))
        Int64.Parse(a, NumberStyles.HexNumber, CultureInfo.InvariantCulture)

    [<Benchmark>]
    [<ArgumentsSource("Data")>]
    member _.Int64ParseAllocFree(bytes: array<byte>) =
        let input = ReadOnlySpan(bytes)
        let a = stackalloc<char> bytes.Length
        for i = 0 to bytes.Length - 1 do
            a.[i] <- char(input.[i])
        Int64.Parse(Span.op_Implicit a, NumberStyles.HexNumber, CultureInfo.InvariantCulture)
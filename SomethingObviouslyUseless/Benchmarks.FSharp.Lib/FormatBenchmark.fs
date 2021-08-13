module Benchmarks.FSharp.FormatBenchmark
#nowarn "20"
module Printer =
    
    open System
    open TypeShape.Core
    open TypeShape.Core.Utils
    
    // Generic pretty printer with recursive type support
    
    let rec mkPrinter<'T> () : 'T -> string =
        let ctx = new TypeGenerationContext()
        mkPrinterCached<'T> ctx
    
    and mkPrinterCached<'T> (ctx : TypeGenerationContext) : 'T -> string =
        match ctx.InitOrGetCachedValue<'T -> string> (fun c t -> c.Value t) with
        | Cached(value = p) -> p
        | NotCached t ->
            let p = mkPrinterAux<'T> ctx
            ctx.Commit t p
    
    and mkPrinterAux<'T> (ctx : TypeGenerationContext) : 'T -> string =
        let wrap(p : 'a -> string) = unbox<'T -> string> p
        let mkFieldPrinter (field : IShapeReadOnlyMember<'DeclaringType>) =
            field.Accept {
                new IReadOnlyMemberVisitor<'DeclaringType, string * ('DeclaringType -> string)> with
                    member _.Visit(field : ReadOnlyMember<'DeclaringType, 'Field>) =
                        let fp = mkPrinterCached<'Field> ctx
                        field.Label, fp << field.Get
            }
    
        match shapeof<'T> with
        | Shape.Unit -> wrap(fun () -> "()") // 'T = unit
        | Shape.Bool -> wrap(sprintf "%b") // 'T = bool
        | Shape.Byte -> wrap(fun (b:byte) -> sprintf "%duy" b) // 'T = byte
        | Shape.Int32 -> wrap(sprintf "%d")
        | Shape.Int64 -> wrap(fun (b:int64) -> sprintf "%dL" b)
        | Shape.String -> wrap(sprintf "\"%s\"")
        | Shape.DateTime       -> wrap (fun (b:DateTime      ) -> sprintf "DateTime (%i, %i, %i, %i, %i, %i, %i)" b.Year b.Month b.Day b.Hour b.Minute b.Second b.Millisecond)
        | Shape.DateTimeOffset -> wrap (fun (b:DateTimeOffset) -> sprintf "DateTimeOffset (%i, %i, %i, %i, %i, %i, %i, TimeSpan.FromMinutes %i.)" b.Year b.Month b.Day b.Hour b.Minute b.Second b.Millisecond b.Offset.Minutes)    
        | Shape.FSharpOption s ->
            s.Element.Accept {
                new ITypeVisitor<'T -> string> with
                    member _.Visit<'a> () = // 'T = 'a option
                        let tp = mkPrinterCached<'a> ctx
                        wrap(function None -> "None" | Some t -> sprintf "Some (%s)" (tp t))
            }
    
        | Shape.FSharpList s ->
            s.Element.Accept {
                new ITypeVisitor<'T -> string> with
                    member _.Visit<'a> () = // 'T = 'a list
                        let tp = mkPrinterCached<'a> ctx
                        wrap(fun (ts : 'a list) -> ts |> Seq.map tp |> String.concat "; " |> sprintf "[%s]")
            }
    
        | Shape.Array s when s.Rank = 1 ->
            s.Element.Accept {
                new ITypeVisitor<'T -> string> with
                    member _.Visit<'a> () = // 'T = 'a []
                        let tp = mkPrinterCached<'a> ctx
                        wrap(fun (ts : 'a []) -> ts |> Seq.map tp |> String.concat "; " |> sprintf "[|%s|]")
            }
    
        | Shape.FSharpSet s ->
            s.Accept {
                new IFSharpSetVisitor<'T -> string> with
                    member _.Visit<'a when 'a : comparison> () =  // 'T = Set<'a>
                        let tp = mkPrinterCached<'a> ctx
                        wrap(fun (s : Set<'a>) -> s |> Seq.map tp |> String.concat "; " |> sprintf "set [%s]")
            }
    
        | Shape.Tuple (:? ShapeTuple<'T> as shape) ->
            let elemPrinters = shape.Elements |> Array.map mkFieldPrinter
            fun (t:'T) ->
                elemPrinters
                |> Seq.map (fun (_,ep) -> let value = ep t in value)
                |> String.concat ", "
                |> sprintf "(%s)"
    
        | Shape.FSharpRecord (:? ShapeFSharpRecord<'T> as shape) ->
            let fieldPrinters = shape.Fields |> Array.map mkFieldPrinter
            fun (r:'T) ->
                fieldPrinters
                |> Seq.map (fun (label, ep) -> let value = ep r in sprintf "%s = %s" label value)
                |> String.concat "; "
                |> sprintf "{ %s }"
    
        | Shape.FSharpUnion (:? ShapeFSharpUnion<'T> as shape) ->
            let mkUnionCasePrinter (s : ShapeFSharpUnionCase<'T>) =
                let fieldPrinters = s.Fields |> Array.map mkFieldPrinter
                fun (u:'T) -> 
                    match fieldPrinters with
                    | [||] -> s.CaseInfo.Name
                    | [|_,fp|] -> sprintf "%s %s" s.CaseInfo.Name (fp u)
                    | fps ->
                        fps
                        |> Seq.map (fun (_,fp) -> fp u)
                        |> String.concat ", "
                        |> sprintf "%s(%s)" s.CaseInfo.Name
    
            let casePrinters = shape.UnionCases |> Array.map mkUnionCasePrinter
            fun (u:'T) -> 
                let printer = casePrinters.[shape.GetTag u]
                printer u
    
        | Shape.Poco (:? ShapePoco<'T> as shape) ->
            let propPrinters = shape.Properties |> Array.map mkFieldPrinter
            fun (r:'T) ->
                propPrinters
                |> Seq.map (fun (label, ep) -> let value = ep r in sprintf "%s = %s" label value)
                |> String.concat "; "
                |> sprintf "{ %s }"
    
        | _ -> failwithf "unsupported type '%O'" typeof<'T>

open System
open System.Reflection
open System.Text
open BenchmarkDotNet.Attributes
open BenchmarkDotNet.Jobs
open System.Buffers
open System.Runtime.CompilerServices

let ignoreFormatting = String.Equals("abc", "ABC", StringComparison.OrdinalIgnoreCase)

type Test =
    | Bla of int
    | BlaBla of string

type T = T with
    static member inline ($) (T, arg: unit) = ()
    static member inline ($) (T, arg: int) = 0 // mandatory second terminal case; is unused in runtime but is required for the code to compile
    static member inline ($) (T, func: ^a -> ^b) : ^a -> ^b = fun (_ : 'a) -> T $ Unchecked.defaultof<'b>

let toStringReflection (obj: 'a) =
    let properties = typeof<'a>.GetProperties(BindingFlags.Instance ||| BindingFlags.Public)
    let sb = properties
             |> Array.fold (fun (accumulator: int) value -> accumulator + value.Name.Length) 0
             |> (+) 5
             |> StringBuilder
    let rec printPropertyToStringBuilder obj (prop: PropertyInfo) =
        let propType = prop.PropertyType
        let propValue = prop.GetValue obj
        sb.Append(prop.Name).Append " = " |> ignore
        if propType.IsPrimitive || propType = typeof<string> || propType = typeof<DateTime> then /// ... else
            let valueToAppend = if isNull propValue then "null" else propValue.ToString()
            let valueToAppend = if String.IsNullOrWhiteSpace valueToAppend then "\"\"" else valueToAppend
            sb.Append valueToAppend |> ignore
        else
            sb.Append "{ " |> ignore
            propType.GetProperties(BindingFlags.Instance ||| BindingFlags.Public)
            |> Array.iter (printPropertyToStringBuilder propValue)
            sb.Append " }" |> ignore
    sb.Append "{ " |> ignore
    properties |> Array.iter (printPropertyToStringBuilder obj)
    sb.Append " }" |> ignore
    sb.ToString()

let inline conditionalIgnore format : 'a =
    if ignoreFormatting then
       T $ Unchecked.defaultof<'a>
    else
        Printf.kprintf (printfn "%A: %s" DateTime.Now) format

type StringFieldRecord = { Field: string
                           Field2: string
                           Field3: string
                           Field4: string
                           Field5: string
                           Field6: string
                           Field7: string }
let stringFieldRecord = { Field = "Sas"
                          Field2 = "Sas" 
                          Field3 = "Sas" 
                          Field4 = "Sas" 
                          Field5 = "Sas" 
                          Field6 = "Sas" 
                          Field7 = "Sas" }
let anonStringFieldRecord = {| Field = "Sas"
                               Field2 = "Sas" 
                               Field3 = "Sas" 
                               Field4 = "Sas" 
                               Field5 = "Sas" 
                               Field6 = "Sas" 
                               Field7 = "Sas" |}

let toString (record: StringFieldRecord) = "{ Field = " + record.Field + "\nField2 = " + record.Field2 + "\nField3 = " + record.Field3 + "\nField4 = " + record.Field4 + "\nField5 = " + record.Field5 + "\nField6 = " + record.Field6 + "\nField7 = " + record.Field7 + " }"

[<Extension>]
type IgnoreAnyExtensions =
    [<Extension>]
    static member Ignore _ = ()

[<Struct; IsByRefLike>]
type SpanCharWriter =
    val mutable private index: int
    val private chars: Span<char>
    new (start: int, chars: Span<char>) = { index = start; chars = chars }
    
    member this.Append(chars: ReadOnlySpan<char>) =
        chars.CopyTo(this.chars.Slice(this.index))
        this.index <- this.index + chars.Length
        this

    member this.Append(str: string) = this.Append(str.AsSpan())

let toStringCreate (record: StringFieldRecord) =
    let BaseLength = 10 + 11 + 11 + 11 + 11 + 11 + 11 + 2 + 12 + 14
    let finalLength = BaseLength + record.Field.Length + record.Field2.Length + record.Field3.Length + record.Field4.Length + record.Field5.Length + record.Field6.Length + record.Field7.Length

    String.Create(finalLength, record, SpanAction (fun chars state -> 
        let mutable a = SpanCharWriter(0, chars)
        let _ = a.Append("{ Field = \"").Append(state.Field)
                 .Append("\"\n  Field2 = \"").Append(state.Field2)
                 .Append("\"\n  Field3 = \"").Append(state.Field3)
                 .Append("\"\n  Field4 = \"").Append(state.Field4)
                 .Append("\"\n  Field5 = \"").Append(state.Field5)
                 .Append("\"\n  Field6 = \"").Append(state.Field6)
                 .Append("\"\n  Field7 = \"").Append(state.Field7)
                 .Append("\" }")
        ()
    ))

[<MemoryDiagnoser>]
[<SimpleJob(RuntimeMoniker.NetCoreApp31)>]
[<SimpleJob(RuntimeMoniker.Net50)>]
type Formatter() =
    let someNum = DateTime.Now.Millisecond;
    let someString = DateTime.Now.ToString()
    let someDate = DateTime.Now
    let argNullException = ArgumentNullException("arg1", "test")
    let someDateString = someDate.ToString()
    let typeShapePrinter = Printer.mkPrinter<StringFieldRecord>()
    [<Benchmark>]
    member _.FormatSprintf() = sprintf "%i %s %O" someNum someString someDate

    [<Benchmark>]
    member _.FormatStringFormat() = String.Format("{0} {1} {2}", someNum, someString, someDate)

    [<Benchmark>]
    member _.FormatInterpolation() = $"%i{someNum} %s{someString} %O{someDate}"    

    [<Benchmark>]
    member _.FormatIgnoreSprintf() = conditionalIgnore "%i %s %O" someNum someString someDate

    [<Benchmark>]
    member _.FormatIgnoreInterpolation() = conditionalIgnore $"%i{someNum} %s{someString} %O{someDate}"

    [<Benchmark>]
    member _.FormatUsingSimpleReflection() = toStringReflection stringFieldRecord    

    [<Benchmark>]
    member _.FormatStringFieldRecordSprintf() = sprintf "%A" stringFieldRecord

    [<Benchmark>]
    member _.FormatAnonStringFieldRecordSprintf() = sprintf "%A" stringFieldRecord

    [<Benchmark>]
    member _.JsonSerializeStringFieldRecord() = Json.JsonSerializer.Serialize(stringFieldRecord)

    [<Benchmark>]
    member _.FormatSpecializedStringFieldRecord() = toString stringFieldRecord

    [<Benchmark>]
    member _.FormatSpecializedStringCreateFieldRecord() = toStringCreate stringFieldRecord

    [<Benchmark>]
    member _.FormatAnonUsingSimpleReflection() = toStringReflection anonStringFieldRecord

    [<Benchmark>]
    member _.FormatStringFieldRecordInterpolation() = $"%A{anonStringFieldRecord}"

    [<Benchmark>]
    member _.FormatAnonStringFieldRecordInterpolation() = $"%A{anonStringFieldRecord}"

    [<Benchmark>]
    member _.JsonSerializeAnonStringFieldRecord() = Json.JsonSerializer.Serialize(anonStringFieldRecord)

    [<Benchmark>]
    member _.FormatExceptionWithA() = $"%A{argNullException}"

    [<Benchmark>]
    member _.FormatExceptionWithO() = $"%O{argNullException}"

    [<Benchmark>]
    member _.FormatStringUsingS() = $"%s{someDateString}"

    [<Benchmark>]
    member _.FormatStringUsingA() = $"%A{someDateString}"

    [<Benchmark>]
    member _.FormatUsingTypeShape() = typeShapePrinter stringFieldRecord
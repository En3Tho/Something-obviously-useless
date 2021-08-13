namespace En3Tho.FSharp.Validation

open System.Runtime.CompilerServices
open System.Runtime.InteropServices
open System.Threading.Tasks

type ValidationResult<'value> = Result<'value, exn>

module ValidationResult =
    let unwrap (result: ValidationResult<'a>) =
        match result with
        | Ok value -> value
        | Error err -> raise err
        
    let defaultValue defaultValue (result: ValidationResult<'a>) =
        match result with
        | Ok value -> value
        | _ -> defaultValue
    
    let defaultWith defThunk (result: ValidationResult<'a>) =
        match result with
        | Ok value -> value
        | Error exn -> defThunk exn

type IAsyncValidator<'value> =
    abstract member Validate: 'value -> ValidationResult<'value> ValueTask // TODO: AsyncVersion?

type IValidator<'value> =
    abstract member Validate: 'value -> ValidationResult<'value>

type [<Struct>] internal ExnBag7 = // ToStackList ? GetEnumerator?
    val mutable private count: int
    val mutable private exn1: exn
    val mutable private exn2: exn
    val mutable private exn3: exn
    val mutable private exn4: exn
    val mutable private exn5: exn
    val mutable private exn6: exn
    val mutable private exn7: exn
    member this.Add(exn) =
        match this.count with
        | offset when offset < 7 ->
            Unsafe.Add(&this.exn1, offset) <- exn
            this.count <- this.count + 1
        | _ -> ()
    
    member this.IsEmpty = this.count = 0
    
    member this.ToArray() =
        match this.count with
        | 0 -> [||]
        | arrayLength ->
            let span = MemoryMarshal.CreateSpan(&this.exn1, arrayLength)
            span.ToArray()


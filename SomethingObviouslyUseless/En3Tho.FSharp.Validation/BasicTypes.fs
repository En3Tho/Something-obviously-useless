namespace En3Tho.FSharp.Validation

open System
open System.Runtime.CompilerServices
open System.Runtime.InteropServices
open System.Threading.Tasks

type EResult<'value> = Result<'value, exn>
type AsyncEResult<'value> = ValueTask<EResult<'value>>

/// Indicates an error when trying to map DTO to domain type. Maps to BadRequest when used with REST. TODO: ResourceManagement, Localization
type ValidationException(message, innerException: Exception) =
    inherit Exception(message, innerException)
    new (message) = ValidationException(message, null)

/// Indicates a domain processing error. Maps to UnprocessableEntity when used with REST.
type DomainException(message, innerException: Exception) =
    inherit Exception(message, innerException)
    new (message) = DomainException(message, null)

/// Indicates an error which doesn't come from domain. Used to wrap an unknown exception we can do nothing about
type FatalException(message, innerException: Exception) =
    inherit Exception(message, innerException)
    new (message) = FatalException(message, null)
    new (innerException) = FatalException("Fatal exception occured", innerException)

type IAsyncValidator<'value> =
    abstract member Validate: 'value -> EResult<'value> ValueTask

type IValidator<'value> =
    inherit IAsyncValidator<'value>
    abstract member Validate: 'value -> EResult<'value>

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
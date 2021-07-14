namespace En3Tho.FSharpExtensions.DomainAndValidation.ExnValidation

open System
open System.Collections.Generic
open System.Runtime.CompilerServices
open System.Runtime.InteropServices

#nowarn "0058"

type ValidationResult<'value> = Result<'value, exn>

module ValidationResult =
    let getValueOrFail (result: ValidationResult<'a>) =
        match result with
        | Ok value -> value
        | Error err -> raise err

type IValidator<'value> =
    abstract member Validate: 'value -> ValidationResult<'value> // ValidateAsync only ? Return ValueTask ...
    // abstract member ValidateAsync: 'value -> ValidationResult<'value> ValueTask
    // abstract member IsAsync: bool // quick check to skip state machine generation // if IsAsync await ... else .Result

type [<Struct>] internal ExnBag7 =
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
    
    member this.ToArray() =
        match this.count with
        | 0 -> [||]
        | arrayLength ->
            let span = MemoryMarshal.CreateSpan(&this.exn1, arrayLength)
            span.ToArray()

type [<Struct>] internal ValidatorEnumerator02<'value, 'validator, 'validator2 when 'validator: struct
                                                                                and 'validator: (new: unit -> 'validator)
                                                                                and 'validator :> IValidator<'value>
                                                                                and 'validator2: struct
                                                                                and 'validator2: (new: unit -> 'validator2)
                                                                                and 'validator2 :> IValidator<'value>>
    (value: 'value) =
    [<DefaultValue(false)>] val mutable private state: int
    [<DefaultValue(false)>] val mutable private current: ValidationResult<'value>
    member this.MoveNext() =
        match this.state with
        | 0 ->
            this.current <- (new 'validator()).Validate value
            this.state <- 1
            true
        | 1 ->
            this.current <- (new 'validator2()).Validate value
            this.state <- 2
            true
        | _ ->
            false
            
    member this.Current = this.current
    
    member this.Reset() =
        this.state <- 0
        this.current <- Unchecked.defaultof<_>
    
    interface IEnumerator<ValidationResult<'value>> with
        member this.Current = this.Current :> obj
        member this.Current = this.Current
        member this.Dispose() = ()
        member this.MoveNext() = this.MoveNext()
        member this.Reset() = this.Reset()

type [<Struct; IsReadOnly>] DomainEntity10<'value, 'validator when 'validator: struct
                                                               and 'validator: (new: unit -> 'validator)
                                                               and 'validator :> IValidator<'value>>                                                       
#if DEBUG
    private (value: 'value, wasValidated: bool) =
    private new(value) = DomainEntity10(value, true)
    member _.Value =
        if not wasValidated then invalidOp "Value was not properly validated"
        else value
#else
    private (value: 'value) =
    member _.Value = value
#endif

    static member Create value : ValidationResult<DomainEntity10<'value, 'validator>> =
        match (new 'validator()).Validate value with
        | Ok value -> DomainEntity10 value |> Ok
        | Error err -> Error err

type [<Struct>] DomainEntity01<'value, 'validator when 'validator: not struct
                                                   and 'validator :> IValidator<'value>>
#if DEBUG
    private (value: 'value, wasValidated: bool) =
    private new(value) = DomainEntity01(value, true)
    member _.Value =
        if not wasValidated then invalidOp "Value was not properly validated"
        else value
#else
    private (value: 'value) =
    member _.Value = value
#endif

    static member Create (validator: 'validator, value) : ValidationResult<DomainEntity01<'value, 'validator>> =
        match validator.Validate value with
        | Ok value -> DomainEntity01 value |> Ok
        | Error err -> Error err

type [<Struct; IsReadOnly>] DomainEntity20<'value, 'validator, 'validator2 when 'validator: struct
                                                                            and 'validator: (new: unit -> 'validator)
                                                                            and 'validator :> IValidator<'value>
                                                                            and 'validator2: struct
                                                                            and 'validator2: (new: unit -> 'validator2)
                                                                            and 'validator2 :> IValidator<'value>>
#if DEBUG
    private (value: 'value, isValidated: bool) =
    private new (value) = DomainEntity20(value, true)
    member _.Value =
        if not isValidated then invalidOp "Value was not properly validated"
        else value
#else
    private (value: 'value) =

    member _.Value = value
#endif
    static member Create value : ValidationResult<DomainEntity20<'value, 'validator, 'validator2>> =
        match (new 'validator()).Validate value with
        | Ok value ->
            match (new 'validator2()).Validate value with
            | Ok value -> DomainEntity20(value, true) |> Ok
            | Error err -> Error err
        | Error err -> Error err    
    
    static member CreateAggregate value : ValidationResult<DomainEntity20<'value, 'validator, 'validator2>> =
        let mutable enum = new ValidatorEnumerator02<'value, 'validator, 'validator2>(value)
        let mutable exnBag = ExnBag7() // stack/span list is nice here.
        while enum.MoveNext() do
            match enum.Current with
            | Error exn ->
                exnBag.Add exn
            | _ -> ()
        match exnBag.ToArray() with
        | [||] -> DomainEntity20(value) |> Ok
        | errors -> AggregateException(errors) :> exn |> Error

type [<Struct; IsReadOnly>] DomainEntity02<'value, 'validator, 'validator2 when 'validator: not struct
                                                                            and 'validator :> IValidator<'value>
                                                                            and 'validator2: not struct
                                                                            and 'validator2 :> IValidator<'value>>
#if DEBUG
    private (value: 'value, isValidated: bool) =
    private new (value) = DomainEntity02(value, true)
    member _.Value =
        if not isValidated then invalidOp "Value was not properly validated"
        else value
#else
    private (value: 'value) =

    member _.Value = value
#endif
    static member Create (validator: 'validator, validator2: 'validator2, value) : ValidationResult<DomainEntity02<'value, 'validator, 'validator2>> =
        match validator.Validate value with
        | Ok value ->
            match validator2.Validate value with
            | Ok value -> DomainEntity02(value, true) |> Ok
            | Error err -> Error err
        | Error err -> Error err    
    
//    static member CreateAggregate value : ValidationResult<DomainEntity20<'validator, 'validator2, 'value>> =
//        let mutable enum = new ValidatorEnumerator02<'validator, 'validator2, 'value>(value)
//        let mutable exnBag = ExnBag7() // stack/span list is nice here.
//        while enum.MoveNext() do
//            match enum.Current with
//            | Error exn ->
//                exnBag.Add exn
//            | _ -> ()
//        match exnBag.ToArray() with
//        | [||] -> DomainEntity20(value) |> Ok
//        | errors -> AggregateException(errors) :> exn |> Error

type [<Struct; IsReadOnly>] DomainEntity11<'value, 'validator, 'validator2 when 'validator: not struct
                                                                            and 'validator :> IValidator<'value>
                                                                            and 'validator2: struct
                                                                            and 'validator2: (new: unit -> 'validator2)
                                                                            and 'validator2 :> IValidator<'value>>
#if DEBUG
    private (value: 'value, wasValidated: bool) =
    private new value = DomainEntity11(value, true)
    member _.Value =
        if not wasValidated then invalidOp "Value was not properly validated"
        else value

    static member Create (validator: 'validator, value) : ValidationResult<DomainEntity11<'value, 'validator, 'validator2>> =
        match validator.Validate value with
        | Ok value ->
            match (new 'validator2()).Validate value with
            | Ok value -> DomainEntity11 value |> Ok
            | Error err -> Error err
        | Error err -> Error err
  
//    static member CreateAggregate value : ValidationResult<DomainEntity11<'validator, 'validator2, 'value>> =
//        let mutable enum = new ValidatorEnumerator11<'validator, 'validator2, 'value>(value)
//        let mutable exnBag = ExnBag7()
//        while enum.MoveNext() do
//            match enum.Current with
//            | Error exn ->
//                exnBag.Add exn
//            | _ -> ()
//        match exnBag.ToArray() with
//        | [||] -> DomainEntity11<_, _, _>(value, true) |> Ok
//        | errors -> AggregateException(errors) :> exn |> Error
#else
    private (value: 'value) =

    member _.Value = value
#endif

type [<Struct; IsReadOnly>] DomainEntity07<'value, 'validator, 'validator2, 'validator3, 'validator4, 'validator5, 'validator6, 'validator7
    when 'validator: not struct
     and 'validator :> IValidator<'value>
     and 'validator2: not struct
     and 'validator2 :> IValidator<'value>
     and 'validator3: not struct
     and 'validator3 :> IValidator<'value>
     and 'validator4: not struct
     and 'validator4 :> IValidator<'value>
     and 'validator5: not struct
     and 'validator5 :> IValidator<'value>
     and 'validator6: not struct
     and 'validator6 :> IValidator<'value>
     and 'validator7: not struct
     and 'validator7 :> IValidator<'value>>
#if DEBUG
    private (value: 'value, isValid: bool) =
    private new (value) = DomainEntity07(value, true)
    member _.Value =
        if not isValid then invalidOp "Value was not properly validated"
        else value
#else
    private (value: 'value) =
    member _.Value = value
#endif
    static member Create (validator: 'validator, validator2: 'validator2, validator3: 'validator3, validator4: 'validator4, validator5: 'validator5, validator6: 'validator6, validator7: 'validator7, value)
        : ValidationResult<DomainEntity07<'value, 'validator, 'validator2, 'validator3, 'validator4, 'validator5, 'validator6, 'validator7>> =
        match validator.Validate value with
        | Ok value ->
            match validator2.Validate value with
            | Ok value ->
                match validator3.Validate value with
                | Ok value ->
                    match validator4.Validate value with
                    | Ok value ->
                        match validator5.Validate value with
                        | Ok value ->
                            match validator6.Validate value with
                            | Ok value ->
                                match validator7.Validate value with
                                | Ok value ->
                                    DomainEntity07 value |> Ok
                                | Error err -> Error err
                            | Error err -> Error err
                        | Error err -> Error err
                    | Error err -> Error err
                | Error err -> Error err
            | Error err -> Error err
        | Error err -> Error err

type [<Struct>] DomainEntity70<'value, 'validator, 'validator2, 'validator3, 'validator4, 'validator5, 'validator6, 'validator7
    when 'validator: struct
     and 'validator: (new: unit -> 'validator)
     and 'validator :> IValidator<'value>
     and 'validator2: struct
     and 'validator2: (new: unit -> 'validator2)
     and 'validator2 :> IValidator<'value>
     and 'validator3: struct
     and 'validator3: (new: unit -> 'validator3)
     and 'validator3 :> IValidator<'value>
     and 'validator4: struct
     and 'validator4: (new: unit -> 'validator4)
     and 'validator4 :> IValidator<'value>
     and 'validator5: struct
     and 'validator5: (new: unit -> 'validator5)
     and 'validator5 :> IValidator<'value>
     and 'validator6: struct
     and 'validator6: (new: unit -> 'validator6)
     and 'validator6 :> IValidator<'value>
     and 'validator7: struct
     and 'validator7: (new: unit -> 'validator7)
     and 'validator7 :> IValidator<'value>>
#if DEBUG
    private (value: 'value, isValid: bool) =
    private new (value) = DomainEntity70(value, true)
    member _.Value =
        if not isValid then invalidOp "Value was not properly validated"
        else value
#else
    private (value: 'value) =
    member _.Value = value
#endif
    static member Create value
        : ValidationResult<DomainEntity70<'value, 'validator, 'validator2, 'validator3, 'validator4, 'validator5, 'validator6, 'validator7>> =
        match (new 'validator()).Validate value with
        | Ok value ->
            match (new 'validator2()).Validate value with
            | Ok value ->
                match (new 'validator3()).Validate value with
                | Ok value ->
                    match (new 'validator4()).Validate value with
                    | Ok value ->
                        match (new 'validator5()).Validate value with
                        | Ok value ->
                            match (new 'validator6()).Validate value with
                            | Ok value ->
                                match (new 'validator7()).Validate value with
                                | Ok value ->
                                    DomainEntity70 value |> Ok
                                | Error err -> Error err
                            | Error err -> Error err
                        | Error err -> Error err
                    | Error err -> Error err
                | Error err -> Error err
            | Error err -> Error err
        | Error err -> Error err

module DomainEntity =
    let map mapFun (entity: DomainEntity10<_,_>) = mapFun entity
    let mapValue mapFun (entity: DomainEntity10<_,_>) = mapFun entity.Value
    
module ValidateCE = // TODO: validateAll builder ?
    [<Sealed>]
    type ValidateBuilder() =
        member inline this.Bind(value: ValidationResult<'a>, next) =
            match value with
            | Ok value -> next value
            | Error exn -> Error exn            
        
        member inline this.Return(value: 'a) : ValidationResult<'a> = Ok value
        member inline this.ReturnFrom(value: ValidationResult<'a>) = value

    let validate = ValidateBuilder()

module DomainEntityExtensions =
    type DomainEntity10<'value, 'validator when 'validator: struct
                                            and 'validator: (new: unit -> 'validator)
                                            and 'validator :> IValidator<'value>> with
        static member Create value =
            match value with
            | ValueNone -> ValueNone |> Ok
            | ValueSome value ->
                match DomainEntity10<'value, 'validator>.Create value with
                | Ok value -> value |> ValueSome |> Ok
                | Error err -> Error err

module ExceptionExtensions =
    type Exception with
        member this.IsOrContains<'a when 'a :> exn>() =
            match this with
            | :? 'a as result -> ValueSome result
            | :? AggregateException as exn ->
                let mutable result = ValueNone
                let enum = exn.InnerExceptions.GetEnumerator()
                while result.IsNone && enum.MoveNext() do
                    result <- enum.Current.IsOrContains<'a>()
                match result with
                | ValueSome _ -> result
                | _ -> exn.InnerException.IsOrContains<'a>()
            | _ ->
                match this.InnerException with
                | null -> ValueNone
                | exn -> exn.IsOrContains<'a>()
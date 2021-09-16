namespace En3Tho.FSharp.Validation

open System
open System.Collections.Generic
open System.Runtime.CompilerServices
open En3Tho.FSharp.Validation.ValidateComputationExpression

#nowarn "0058"

type [<Struct>] internal ValidatorEnumerator02<'value, 'validator, 'validator2 when 'validator: struct
                                                                                and 'validator: (new: unit -> 'validator)
                                                                                and 'validator :> IValidator<'value>
                                                                                and 'validator2: struct
                                                                                and 'validator2: (new: unit -> 'validator2)
                                                                                and 'validator2 :> IValidator<'value>>
    (value: 'value) =
    [<DefaultValue(false)>] val mutable private state: int
    [<DefaultValue(false)>] val mutable private current: EResult<'value>
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
    
    interface IEnumerator<EResult<'value>> with
        member this.Current = this.Current :> obj
        member this.Current = this.Current
        member this.Dispose() = ()
        member this.MoveNext() = this.MoveNext()
        member this.Reset() = this.Reset()

type [<Struct; IsReadOnly;>] DomainEntity10<'value, 'validator when 'validator: struct
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

    override this.ToString() = this.Value.ToString()

    static member Try value : EResult<DomainEntity10<'value, 'validator>> =
        match (new 'validator()).Validate value with
        | Ok value -> DomainEntity10 value |> Ok
        | Error err -> Error err

type [<Struct; IsReadOnly;>] DomainEntity01<'value, 'validator when 'validator: not struct
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

    static member Try (validator: 'validator, value) : EResult<DomainEntity01<'value, 'validator>> =
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
    static member Try value : EResult<DomainEntity20<'value, 'validator, 'validator2>> =
        match (new 'validator()).Validate value with
        | Ok value ->
            match (new 'validator2()).Validate value with
            | Ok value -> DomainEntity20(value) |> Ok
            | Error err -> Error err
        | Error err -> Error err    
    
    static member TryAggregate value : EResult<DomainEntity20<'value, 'validator, 'validator2>> =
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
    static member Try (value, validator: 'validator, validator2: 'validator2) : EResult<DomainEntity02<'value, 'validator, 'validator2>> =
        match validator.Validate value with
        | Ok value ->
            match validator2.Validate value with
            | Ok value -> DomainEntity02(value) |> Ok
            | Error err -> Error err
        | Error err -> Error err
    
//    static member TryAggregate value : ValidationResult<DomainEntity20<'validator, 'validator2, 'value>> =
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

type [<Struct; IsReadOnly>] DomainEntity11<'value, 'validator, 'validator2 when 'validator: struct
                                                                            and 'validator: (new: unit -> 'validator)
                                                                            and 'validator :> IValidator<'value>
                                                                            and 'validator2: not struct
                                                                            and 'validator2 :> IValidator<'value>>
#if DEBUG
    private (value: 'value, wasValidated: bool) =
    private new value = DomainEntity11(value, true)
    member _.Value =
        if not wasValidated then invalidOp "Value was not properly validated"
        else value
#else
    private (value: 'value) =

    member _.Value = value
#endif
    static member Try (value, validator: 'validator2) : EResult<DomainEntity11<'value, 'validator, 'validator2>> =
    match (new 'validator()).Validate value with
    | Ok value ->
        match validator.Validate value with
        | Ok value -> DomainEntity11 value |> Ok
        | Error err -> Error err
    | Error err -> Error err
  
//    static member TryAggregate value : ValidationResult<DomainEntity11<'validator, 'validator2, 'value>> =
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
    static member Try (value, validator: 'validator, validator2: 'validator2, validator3: 'validator3, validator4: 'validator4, validator5: 'validator5, validator6: 'validator6, validator7: 'validator7)
        : EResult<DomainEntity07<'value, 'validator, 'validator2, 'validator3, 'validator4, 'validator5, 'validator6, 'validator7>> =
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

type [<Struct; IsReadOnly>] DomainEntity70<'value, 'validator, 'validator2, 'validator3, 'validator4, 'validator5, 'validator6, 'validator7
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
    static member Try value
        : EResult<DomainEntity70<'value, 'validator, 'validator2, 'validator3, 'validator4, 'validator5, 'validator6, 'validator7>> = eresult {
            let! _ = (new 'validator()).Validate value
            let! _ = (new 'validator2()).Validate value
            let! _ = (new 'validator3()).Validate value
            let! _ = (new 'validator4()).Validate value
            let! _ = (new 'validator5()).Validate value
            let! _ = (new 'validator6()).Validate value
            let! _ = (new 'validator7()).Validate value
            return DomainEntity70 value
        }
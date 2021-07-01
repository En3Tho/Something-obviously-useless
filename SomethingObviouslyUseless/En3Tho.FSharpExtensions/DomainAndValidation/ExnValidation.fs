namespace En3Tho.FSharpExtensions.DomainAndValidation.ExnValidation

type IValidator<'value> =
    abstract member Validate: 'value -> Result<'value, exn>

module Validator =
    type [<Struct>] RefValidator<'validator, 'value when 'validator: not struct
                                                     and 'validator :> IValidator<'value>> private (validator: 'validator) =
        static member CreateFromRef validator = RefValidator<_, _>(validator)
        interface IValidator<'value> with
            member this.Validate value = validator.Validate value

    let fromRef validator = RefValidator<_, _>.CreateFromRef validator

type [<Struct>] DomainEntity<'validator, 'value when 'validator: struct
                                                 and 'validator :> IValidator<'value>>
#if DEBUG
    private (value: 'value, wasValidated: bool) =
    member _.Value =
        if not wasValidated then invalidOp "Value was not properly validated"
        else value

    static member CreateWith (validator: 'validator, value) : Result<DomainEntity<'validator, 'value>, exn> =
        match validator.Validate value with
        | Ok value -> DomainEntity(value, true) |> Ok
        | Error err -> Error err

    static member Create value : Result<DomainEntity<'validator, 'value>, exn> =
        DomainEntity<'validator, 'value>.CreateWith(Unchecked.defaultof<'validator>, value)
#else
    private (value: 'value) =

    member _.Value = value

    static member CreateWith (validator: 'validator, value) : Result<DomainEntity<'validator, 'value>, exn> =
        match validator.Validate value with
        | Ok value -> DomainEntity value |> Ok
        | Error err -> Error err

    static member Create value : Result<DomainEntity<'validator, 'value>, exn> =
        DomainEntity<'validator, 'value>.CreateWith(Unchecked.defaultof<'validator>, value)
#endif

type [<Struct>] DomainEntity<'validator, 'validator2, 'value when 'validator: struct
                                                              and 'validator :> IValidator<'value>
                                                              and 'validator2: struct
                                                              and 'validator2 :> IValidator<'value>>
#if DEBUG
    private (value: 'value, wasValidated: bool) =
    member _.Value =
        if not wasValidated then invalidOp "Value was not properly validated"
        else value

    static member CreateWith (validator: 'validator, validator2: 'validator2, value) : Result<DomainEntity<'validator, 'validator2, 'value>, exn> =
        match validator.Validate value with
        | Ok value ->
            match validator2.Validate value with
            | Ok value -> DomainEntity<_, _, _>(value, true) |> Ok
            | Error err -> Error err
        | Error err -> Error err

    static member Create value : Result<DomainEntity<'validator, 'validator2, 'value>, exn> =
        DomainEntity<'validator, 'validator2, 'value>.CreateWith(Unchecked.defaultof<'validator>, Unchecked.defaultof<'validator2>, value)
#else
    private (value: 'value) =

    member _.Value = value

    static member CreateWith (validator: 'validator, validator2: 'validator2, value) : Result<DomainEntity<'validator, 'validator2, 'value>, exn> =
        match validator.Validate value with
        | Ok value ->
            match validator2.Validate value with
            | Ok value -> DomainEntity<_, _, _>(value) |> Ok
            | Error err -> Error err
        | Error err -> Error err

    static member Create value : Result<DomainEntity<'validator, 'validator2, 'value>, exn> =
        DomainEntity<'validator, 'validator2, 'value>.CreateWith(Unchecked.defaultof<'validator>, Unchecked.defaultof<'validator2>, value)
#endif

type [<Struct>] DomainEntity<'validator, 'validator2, 'validator3, 'validator4, 'validator5, 'validator6, 'validator7, 'value when 'validator: struct
                                                                                                                               and 'validator :> IValidator<'value>
                                                                                                                               and 'validator2: struct
                                                                                                                               and 'validator2 :> IValidator<'value>
                                                                                                                               and 'validator3: struct
                                                                                                                               and 'validator3 :> IValidator<'value>
                                                                                                                               and 'validator4: struct
                                                                                                                               and 'validator4 :> IValidator<'value>
                                                                                                                               and 'validator5: struct
                                                                                                                               and 'validator5 :> IValidator<'value>
                                                                                                                               and 'validator6: struct
                                                                                                                               and 'validator6 :> IValidator<'value>
                                                                                                                               and 'validator7: struct
                                                                                                                               and 'validator7 :> IValidator<'value>>
#if DEBUG
    private (value: 'value, wasValidated: bool) =
    member _.Value =
        if not wasValidated then invalidOp "Value was not properly validated"
        else value

    static member CreateWith (validator: 'validator, validator2: 'validator2, validator3: 'validator3, validator4: 'validator4, validator5: 'validator5, validator6: 'validator6, validator7: 'validator7, value)
        : Result<DomainEntity<'validator, 'validator2, 'validator3, 'validator4, 'validator5, 'validator6, 'validator7, 'value>, exn> =
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
                                    DomainEntity<_, _, _, _, _, _, _, _>(value, true) |> Ok
                                | Error err -> Error err
                            | Error err -> Error err
                        | Error err -> Error err
                    | Error err -> Error err
                | Error err -> Error err
            | Error err -> Error err
        | Error err -> Error err

    static member Create value : Result<DomainEntity<'validator, 'validator2, 'validator3, 'validator4, 'validator5, 'validator6, 'validator7, 'value>, exn> =
        DomainEntity<'validator, 'validator2, 'validator3, 'validator4, 'validator5, 'validator6, 'validator7, 'value>.CreateWith(
            Unchecked.defaultof<'validator>, Unchecked.defaultof<'validator2>, Unchecked.defaultof<'validator3>, Unchecked.defaultof<'validator4>, Unchecked.defaultof<'validator5>, Unchecked.defaultof<'validator6>, Unchecked.defaultof<'validator7>, value)
#else
    private (value: 'value) =

    member _.Value = value

    static member CreateWith (validator: 'validator, validator2: 'validator2, validator3: 'validator3, validator4: 'validator4, validator5: 'validator5, validator6: 'validator6, validator7: 'validator7, value)
        : Result<DomainEntity<'validator, 'validator2, 'validator3, 'validator4, 'validator5, 'validator6, 'validator7, 'value>, exn> =
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
                                    DomainEntity<_, _, _, _, _, _, _, _>(value) |> Ok
                                | Error err -> Error err
                            | Error err -> Error err
                        | Error err -> Error err
                    | Error err -> Error err
                | Error err -> Error err
            | Error err -> Error err
        | Error err -> Error err

    static member Create value : Result<DomainEntity<'validator, 'validator2, 'validator3, 'validator4, 'validator5, 'validator6, 'validator7, 'value>, exn> =
        DomainEntity<'validator, 'validator2, 'validator3, 'validator4, 'validator5, 'validator6, 'validator7, 'value>.CreateWith(
            Unchecked.defaultof<'validator>, Unchecked.defaultof<'validator2>, Unchecked.defaultof<'validator3>, Unchecked.defaultof<'validator4>, Unchecked.defaultof<'validator5>, Unchecked.defaultof<'validator6>, Unchecked.defaultof<'validator7>, value)
#endif

module DomainEntity =
    let map mapFun (entity: DomainEntity<_,_>) = mapFun entity.Value
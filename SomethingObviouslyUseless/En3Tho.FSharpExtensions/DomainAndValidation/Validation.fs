namespace En3Tho.FSharpExtensions.DomainAndValidation

module Object =
    let createNew<'a when 'a: (new: unit -> 'a)> = new 'a()


type IValidator<'value, 'validationError> =
    abstract member Validate: 'value -> Result<'value, 'validationError>

module Validator =
    type [<Struct>] RefValidator<'validator, 'value, 'validationError when 'validator: not struct
                                                                       and 'validator :> IValidator<'value, 'validationError>> private (validator: 'validator) =
        static member CreateFromRef validator = RefValidator<_, _, _>(validator)
        interface IValidator<'value, 'validationError> with
            member this.Validate value = validator.Validate value

    let fromRef validator = RefValidator<_, _, _>.CreateFromRef validator

type [<Struct>] DomainEntity<'validator, 'value, 'validationError when 'validator: struct
                                                                   and 'validator :> IValidator<'value, 'validationError>>
#if DEBUG
    private (value: 'value, wasValidated: bool) =
    member _.Value =
        if not wasValidated then invalidOp "Value was not properly validated"
        else value

    static member CreateWith (validator: 'validator, value) : Result<DomainEntity<'validator, 'value, 'validationError>, 'validationError> =
        match validator.Validate value with
        | Ok value -> DomainEntity(value, true) |> Ok
        | Error err -> Error err

    static member Create value : Result<DomainEntity<'validator, 'value, 'validationError>, 'validationError> =
        DomainEntity<'validator, 'value, 'validationError>.CreateWith(Unchecked.defaultof<'validator>, value)
#else
    private (value: 'value) =

    member _.Value = value

    static member CreateFrom (validator: 'validator, value) : Result<DomainEntity<'validator, 'value, 'validationError>, 'validationError> =
        match validator.Validate value with // Result.map is not used for perf reasons
        | Ok value -> DomainEntity value |> Ok
        | Error err -> Error err

    static member CreateFrom value : Result<DomainEntity<'validator, 'value, 'validationError>, 'validationError> =
        DomainEntity<'validator, 'value, 'validationError>.CreateFrom(Unchecked.defaultof<'validator>, value)
#endif

module DomainEntity =
    let map mapFun (entity: DomainEntity<_,_,_>) = mapFun entity.Value
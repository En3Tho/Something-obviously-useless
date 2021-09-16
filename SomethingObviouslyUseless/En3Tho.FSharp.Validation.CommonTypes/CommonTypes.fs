module En3Tho.FSharp.Validation.CommonTypes

open System
open System.Collections.Generic
open System.Threading.Tasks
open En3Tho.FSharp.Validation

module PlainValue =
    type [<Struct>] Validator<'a> =
         member this.Validate value = Ok value

         interface IValidator<'a> with
             member this.Validate value : EResult<'a> = this.Validate value
             member this.Validate value : AsyncEResult<'a> = this.Validate value |> ValueTask.FromResult

type PlainValue<'a> = DomainEntity10<'a, PlainValue.Validator<'a>>
let inline (|PlainValue|) (value: PlainValue<'a>) = value.Value

module NonNullValue =
    exception ValueIsNull
        
    type [<Struct>] Validator<'a when 'a: not struct> =
        member this.Validate value =
            if Object.ReferenceEquals(value, null) then Error ValueIsNull
            else Ok value

        interface IValidator<'a> with
            member this.Validate value : EResult<'a> = this.Validate value
            member this.Validate value : AsyncEResult<'a> = this.Validate value |> ValueTask.FromResult

type NonNullValue<'a when 'a: not struct> = DomainEntity10<'a, NonNullValue.Validator<'a>>
let inline (|NonNullValue|) (value: NonNullValue<'a>) = value.Value

module NonDefaultValue =
    exception ValueIsDefault

    type [<Struct>] Validator<'a when 'a: struct and 'a: equality> =
        member this.Validate value =
            if value = Unchecked.defaultof<'a> then Error ValueIsDefault
            else Ok value

        interface IValidator<'a> with
            member this.Validate value : EResult<'a> = this.Validate value
            member this.Validate value : AsyncEResult<'a> = this.Validate value |> ValueTask.FromResult

type NonDefaultValue<'a when 'a: struct and 'a: equality> = DomainEntity10<'a, NonDefaultValue.Validator<'a>>
let inline (|NonDefaultValue|) (value: NonDefaultValue<'a>) = value.Value

module NonNegativeValue =
    exception ValueIsNegative
        
    type [<Struct>] Validator<'a when 'a: comparison> =
        member this.Validate value =
            if value < Unchecked.defaultof<_> then Error ValueIsNegative
            else Ok value
        interface IValidator<'a> with
            member this.Validate value : EResult<'a> = this.Validate value
            member this.Validate value : AsyncEResult<'a> = this.Validate value |> ValueTask.FromResult

type NonNegativeValue<'a when 'a: comparison> = DomainEntity10<'a, NonNegativeValue.Validator<'a>>
let inline (|NonNegativeValue|) (value: NonNegativeValue<'a>) = value.Value

module NonEmptyString =
    exception StringIsNull
    exception StringIsEmpty

    type [<Struct>] Validator =
        member this.Validate value =
                if value = null then Error StringIsNull
                elif String.IsNullOrEmpty value then Error StringIsNull
                else Ok value
        interface IValidator<string> with
            member this.Validate value = this.Validate value
            member this.Validate value = this.Validate value |> ValueTask.FromResult

type NonEmptyString = DomainEntity10<string, NonEmptyString.Validator>
let inline (|NonEmptyString|) (value: NonEmptyString) = value.Value

module NonEmptyGuid =
    exception IsEmpty

    type [<Struct>] Validator =
        member this.Validate value =
            if Guid.Empty = value then Error IsEmpty
            else Ok value

        interface IValidator<Guid> with
            member this.Validate value = this.Validate value
            member this.Validate value = this.Validate value |> ValueTask.FromResult

type NonEmptyGuid = DomainEntity10<Guid, NonEmptyGuid.Validator>
let inline (|NonEmptyGuid|) (value: NonEmptyGuid) = value.Value

module NonEmptyArray =
    exception ArrayIsNull
    exception ArrayIsEmpty

    type [<Struct>] Validator<'a> =
        member this.Validate value =
            if isNull value then Error ArrayIsNull
            elif Array.isEmpty value then Error ArrayIsEmpty
            else Ok value

        interface IValidator<'a array> with
            member this.Validate value : EResult<'a array> = this.Validate value
            member this.Validate value : AsyncEResult<'a array> = this.Validate value |> ValueTask.FromResult

type NonEmptyArray<'a> = DomainEntity10<'a array, NonEmptyArray.Validator<'a>>
let inline (|NonEmptyArray|) (value: NonEmptyArray<'a>) = value.Value

module NonEmptyList =
    exception ListIsNull
    exception ListIsEmpty

    type [<Struct>] Validator<'a> =
        member this.Validate value =
            if Object.ReferenceEquals(value, null) then Error ListIsNull
            elif List.isEmpty value then Error ListIsEmpty
            else Ok value

        interface IValidator<'a list> with
            member this.Validate value : EResult<'a list> = this.Validate value
            member this.Validate value : AsyncEResult<'a list> = this.Validate value |> ValueTask.FromResult

type NonEmptyList<'a> = DomainEntity10<'a list, NonEmptyList.Validator<'a>>
let inline (|NonEmptyList|) (value: NonEmptyList<'a>) = value.Value

module NonEmptyCollection =
    exception CollectionIsNull
    exception CollectionIsEmpty

    type [<Struct>] Validator<'a, 'b when 'a :> ICollection<'b>> =
        member this.Validate (value: 'a) =
            if Object.ReferenceEquals(value, null) then Error CollectionIsNull
            elif value.Count = 0 then Error CollectionIsEmpty
            else Ok value

        interface IValidator<'a> with
            member this.Validate value = this.Validate value
            member this.Validate value = this.Validate value |> ValueTask.FromResult

type NonEmptyCollection<'a, 'b when 'a :> ICollection<'b>> = DomainEntity10<'a, NonEmptyCollection.Validator<'a, 'b>>
let inline (|NonEmptyCollection|) (value: NonEmptyCollection<'a, 'b>) = value.Value

module GuidString =
    exception StringIsNotGuidParseable

    type [<Struct>] Validator =
        member this.Validate (value: string) =
            match Guid.TryParse value with
            | true, _ -> Ok value
            | _ -> Error StringIsNotGuidParseable

        interface IValidator<string> with
            member this.Validate value = this.Validate value
            member this.Validate value = this.Validate value |> ValueTask.FromResult

type GuidString = DomainEntity20<string, NonEmptyString.Validator, GuidString.Validator>
let inline (|GuidString|) (value: GuidString) = value.Value

module ValidEnumValue =
    exception ValueIsNotDefined

    type [<Struct>] Validator<'a when 'a: struct and 'a :> Enum and 'a: (new: unit -> 'a)> =
        member this.Validate value =
            if Enum.IsDefined value then Ok value
            else Error ValueIsNotDefined

        interface IValidator<'a> with
            member this.Validate value : EResult<'a> = this.Validate value
            member this.Validate value : AsyncEResult<'a> = this.Validate value |> ValueTask.FromResult

type ValidEnumValue<'a when 'a: struct and 'a :> Enum and 'a: (new: unit -> 'a)> = DomainEntity10<'a, ValidEnumValue.Validator<'a>>
let inline (|ValidEnum|) (value: ValidEnumValue<'a>) = value.Value
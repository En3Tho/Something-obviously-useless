namespace En3Tho.FSharp.Validation.CommonTypes

open System
open System.Collections.Generic
open En3Tho.FSharp.Validation

module PlainValue =
    type [<Struct>] Validator<'a> =
         interface IValidator<'a> with
             member this.Validate value = Ok value
             
type PlainValue<'a> = DomainEntity10<'a, PlainValue.Validator<'a>>

module NonNullValue =
    exception ValueIsNull
        
    type [<Struct>] Validator<'a when 'a: not struct> =
         interface IValidator<'a> with
             member this.Validate value =
                 if Object.ReferenceEquals(value, null) then Error ValueIsNull
                 else Ok value

type NonNullValue<'a when 'a: not struct> = DomainEntity10<'a, NonNullValue.Validator<'a>>

module NonNegativeValue =
    exception ValueIsNegative
        
    type [<Struct>] Validator<'a when 'a: comparison> =
         interface IValidator<'a> with
             member this.Validate value =
                 if value < Unchecked.defaultof<_> then Error ValueIsNegative
                 else Ok value

type NonNegativeValue<'a when 'a: comparison> = DomainEntity10<'a, NonNegativeValue.Validator<'a>>

module NonEmptyString =
    exception StringIsNull
    exception StringIsEmpty

    type [<Struct>] Validator =
        interface IValidator<string> with
            member this.Validate value =
                if value = null then Error StringIsNull
                elif String.IsNullOrEmpty value then Error StringIsNull
                else Ok value

type NonEmptyString = DomainEntity10<string, NonEmptyString.Validator>

module NonEmptyGuid =
    exception IsEmpty

    type [<Struct>] Validator =
         interface IValidator<Guid> with
             member this.Validate value =
                 if Guid.Empty = value then Error IsEmpty
                 else Ok value

type NonEmptyGuid = DomainEntity10<Guid, NonEmptyGuid.Validator>

module NonEmptyArray =
    exception ArrayIsNull
    exception ArrayIsEmpty

    type [<Struct>] Validator<'a> =
        interface IValidator<'a array> with
            member this.Validate value =
                if isNull value then Error ArrayIsNull
                elif Array.isEmpty value then Error ArrayIsEmpty
                else Ok value

type NonEmptyArray<'a> = DomainEntity10<'a array, NonEmptyArray.Validator<'a>>

module NonEmptyList =
    exception ListIsNull
    exception ListIsEmpty

    type [<Struct>] Validator<'a> =
        interface IValidator<'a list> with
            member this.Validate value =
                if Object.ReferenceEquals(value, null) then Error ListIsNull
                elif List.isEmpty value then Error ListIsEmpty
                else Ok value

type NonEmptyList<'a> = DomainEntity10<'a list, NonEmptyList.Validator<'a>>

module NonEmptyCollection =
    exception CollectionIsNull
    exception CollectionIsEmpty

    type [<Struct>] Validator<'a, 'b when 'a :> ICollection<'b>> =
        interface IValidator<'a> with
            member this.Validate value =
                if Object.ReferenceEquals(value, null) then Error CollectionIsNull
                elif value.Count = 0 then Error CollectionIsEmpty
                else Ok value

type NonEmptyCollection<'a, 'b when 'a :> ICollection<'b>> = DomainEntity10<'a, NonEmptyCollection.Validator<'a, 'b>>

module GuidParseableString =
    exception StringIsNotGuidParseable

    type [<Struct>] Validator =
        interface IValidator<string> with
            member this.Validate value =
                match Guid.TryParse value with
                | true, _ -> Ok value
                | _ -> Error StringIsNotGuidParseable

type GuidParseableString = DomainEntity20<string, NonEmptyString.Validator, GuidParseableString.Validator>

module ValidEnumValue =
    exception ValueIsNotDefined

    type [<Struct>] Validator<'a when 'a: struct and 'a :> Enum and 'a: (new: unit -> 'a)> =
        interface IValidator<'a> with
            member this.Validate value =
                if Enum.IsDefined value then Ok value
                else Error ValueIsNotDefined

type ValidEnumValue<'a when 'a: struct and 'a :> Enum and 'a: (new: unit -> 'a)> = DomainEntity10<'a, ValidEnumValue.Validator<'a>>
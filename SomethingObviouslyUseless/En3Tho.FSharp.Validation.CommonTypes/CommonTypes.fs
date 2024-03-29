﻿module En3Tho.FSharp.Validation.CommonTypes

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

type PlainValue<'a> = Validated10<'a, PlainValue.Validator<'a>>
let inline (|PlainValue|) (value: PlainValue<'a>) = value.Value

module NonNullValue =
    type ValueIsNull() = inherit ValidationException(nameof(ValueIsNull))
        
    type [<Struct>] Validator<'a when 'a: not struct> =
        member this.Validate value =
            if Object.ReferenceEquals(value, null) then Error (ValueIsNull() :> exn)
            else Ok value

        interface IValidator<'a> with
            member this.Validate value : EResult<'a> = this.Validate value
            member this.Validate value : AsyncEResult<'a> = this.Validate value |> ValueTask.FromResult

type NonNullValue<'a when 'a: not struct> = Validated10<'a, NonNullValue.Validator<'a>>
let inline (|NonNullValue|) (value: NonNullValue<'a>) = value.Value

module NonDefaultValue =
    type ValueIsDefault() = inherit ValidationException(nameof(ValueIsDefault))

    type [<Struct>] Validator<'a when 'a: struct and 'a: equality> =
        member this.Validate value =
            if value = Unchecked.defaultof<'a> then Error (ValueIsDefault() :> exn)
            else Ok value

        interface IValidator<'a> with
            member this.Validate value : EResult<'a> = this.Validate value
            member this.Validate value : AsyncEResult<'a> = this.Validate value |> ValueTask.FromResult

type NonDefaultValue<'a when 'a: struct and 'a: equality> = Validated10<'a, NonDefaultValue.Validator<'a>>
let inline (|NonDefaultValue|) (value: NonDefaultValue<'a>) = value.Value

module NonNegativeValue =
    type ValueIsNegative() = inherit ValidationException(nameof(ValueIsNegative))
        
    type [<Struct>] Validator<'a when 'a: comparison and 'a: struct> =
        member this.Validate value =
            if value < Unchecked.defaultof<_> then Error (ValueIsNegative() :> exn)
            else Ok value
        interface IValidator<'a> with
            member this.Validate value : EResult<'a> = this.Validate value
            member this.Validate value : AsyncEResult<'a> = this.Validate value |> ValueTask.FromResult

type NonNegativeValue<'a when 'a: comparison and 'a: struct> = Validated10<'a, NonNegativeValue.Validator<'a>>
let inline (|NonNegativeValue|) (value: NonNegativeValue<'a>) = value.Value

module NegativeValue =
    type ValueIsNotNegative() = inherit ValidationException(nameof(ValueIsNotNegative))

    type [<Struct>] Validator<'a when 'a: comparison and 'a: struct> =
        member this.Validate value =
            if value < Unchecked.defaultof<_> then Ok value
            else Error (ValueIsNotNegative() :> exn)
        interface IValidator<'a> with
            member this.Validate value : EResult<'a> = this.Validate value
            member this.Validate value : AsyncEResult<'a> = this.Validate value |> ValueTask.FromResult

type NegativeValue<'a when 'a: comparison and 'a: struct> = Validated10<'a, NonNegativeValue.Validator<'a>>
let inline (|NegativeValue|) (value: NonNegativeValue<'a>) = value.Value

module NonEmptyString =
    type StringIsNull() = inherit ValidationException(nameof(StringIsNull))
    type StringIsEmpty() = inherit ValidationException(nameof(StringIsEmpty))

    type [<Struct>] Validator =
        member this.Validate value =
                if value = null then Error (StringIsNull() :> exn)
                elif String.IsNullOrEmpty value then Error (StringIsNull() :> exn)
                else Ok value
        interface IValidator<string> with
            member this.Validate value = this.Validate value
            member this.Validate value = this.Validate value |> ValueTask.FromResult

type NonEmptyString = Validated10<string, NonEmptyString.Validator>
let inline (|NonEmptyString|) (value: NonEmptyString) = value.Value

module NonEmptyGuid =
    type IsEmpty() = inherit ValidationException(nameof(IsEmpty))

    type [<Struct>] Validator =
        member this.Validate value =
            if Guid.Empty = value then Error (IsEmpty() :> exn)
            else Ok value

        interface IValidator<Guid> with
            member this.Validate value = this.Validate value
            member this.Validate value = this.Validate value |> ValueTask.FromResult

type NonEmptyGuid = Validated10<Guid, NonEmptyGuid.Validator>
let inline (|NonEmptyGuid|) (value: NonEmptyGuid) = value.Value

module NonEmptyArray =
    type ArrayIsNull() = inherit ValidationException(nameof(ArrayIsNull))
    type ArrayIsEmpty() = inherit ValidationException(nameof(ArrayIsEmpty))

    type [<Struct>] Validator<'a> =
        member this.Validate value =
            if isNull value then Error (ArrayIsNull() :> exn)
            elif Array.isEmpty value then Error (ArrayIsEmpty() :> exn)
            else Ok value

        interface IValidator<'a array> with
            member this.Validate value : EResult<'a array> = this.Validate value
            member this.Validate value : AsyncEResult<'a array> = this.Validate value |> ValueTask.FromResult

type NonEmptyArray<'a> = Validated10<'a array, NonEmptyArray.Validator<'a>>
let inline (|NonEmptyArray|) (value: NonEmptyArray<'a>) = value.Value

module NonEmptyList =
    type ListIsNull() = inherit ValidationException(nameof(ListIsNull))
    type ListIsEmpty() = inherit ValidationException(nameof(ListIsEmpty))

    type [<Struct>] Validator<'a> =
        member this.Validate value =
            if Object.ReferenceEquals(value, null) then Error (ListIsNull() :> exn)
            elif List.isEmpty value then Error (ListIsEmpty() :> exn)
            else Ok value

        interface IValidator<'a list> with
            member this.Validate value : EResult<'a list> = this.Validate value
            member this.Validate value : AsyncEResult<'a list> = this.Validate value |> ValueTask.FromResult

type NonEmptyList<'a> = Validated10<'a list, NonEmptyList.Validator<'a>>
let inline (|NonEmptyList|) (value: NonEmptyList<'a>) = value.Value

module NonEmptyCollection =
    type CollectionIsNull() = inherit ValidationException(nameof(CollectionIsNull))
    type CollectionIsEmpty() = inherit ValidationException(nameof(CollectionIsEmpty))

    type [<Struct>] Validator<'a, 'b when 'a :> ICollection<'b>> =
        member this.Validate (value: 'a) =
            if Object.ReferenceEquals(value, null) then Error (CollectionIsNull() :> exn)
            elif value.Count = 0 then Error (CollectionIsEmpty() :> exn)
            else Ok value

        interface IValidator<'a> with
            member this.Validate value = this.Validate value
            member this.Validate value = this.Validate value |> ValueTask.FromResult

type NonEmptyCollection<'a, 'b when 'a :> ICollection<'b>> = Validated10<'a, NonEmptyCollection.Validator<'a, 'b>>
let inline (|NonEmptyCollection|) (value: NonEmptyCollection<'a, 'b>) = value.Value

module GuidString =
    type StringIsNotGuidParseable() = inherit ValidationException(nameof(StringIsNotGuidParseable))

    type [<Struct>] Validator =
        member this.Validate (value: string) =
            match Guid.TryParse value with
            | true, _ -> Ok value
            | _ -> Error (StringIsNotGuidParseable() :> exn)

        interface IValidator<string> with
            member this.Validate value = this.Validate value
            member this.Validate value = this.Validate value |> ValueTask.FromResult

type GuidString = Validated20<string, NonEmptyString.Validator, GuidString.Validator>
let inline (|GuidString|) (value: GuidString) = value.Value

module ValidEnumValue =
    type ValueIsNotDefined() = inherit ValidationException(nameof(ValueIsNotDefined))

    type [<Struct>] Validator<'a when 'a: struct and 'a :> Enum and 'a: (new: unit -> 'a)> =
        member this.Validate value =
            if Enum.IsDefined value then Ok value
            else Error (ValueIsNotDefined() :> exn)

        interface IValidator<'a> with
            member this.Validate value : EResult<'a> = this.Validate value
            member this.Validate value : AsyncEResult<'a> = this.Validate value |> ValueTask.FromResult

type ValidEnumValue<'a when 'a: struct and 'a :> Enum and 'a: (new: unit -> 'a)> = Validated10<'a, ValidEnumValue.Validator<'a>>
let inline (|ValidEnum|) (value: ValidEnumValue<'a>) = value.Value
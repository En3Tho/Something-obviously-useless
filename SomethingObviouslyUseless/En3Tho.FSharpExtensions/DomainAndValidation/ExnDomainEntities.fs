module En3Tho.FSharpExtensions.DomainAndValidation.ExnValidation.DomainEntities

open System
open System.Text.RegularExpressions
open En3Tho.FSharpExtensions.DomainAndValidation.ExnValidation.Validator

type [<Struct>] ValidationSlot<'a> =
    interface IValidator<'a> with
        member this.Validate value = Ok value

module NonEmptyString =
    exception IsNullOrEmpty

    let private validate value =
        if String.IsNullOrEmpty value then Error IsNullOrEmpty
        else Ok value

    type [<Struct>] NonEmptyStringValidator =
        interface IValidator<string> with
            member this.Validate value = validate value

module StringOfMaxLength50 =
    exception LengthIsGreaterThan50

    let private validate (value: string) =
        if value.Length > 50 then Error LengthIsGreaterThan50
        else Ok value

    type [<Struct>] StringOfMaxLength50Validator =
        interface IValidator<string> with
            member this.Validate value = validate value

module StringOfMinLength10 =
    exception LengthIsLesserThan10

    let private validate (value: string) =
        if value.Length > 50 then Error LengthIsLesserThan10
        else Ok value

    type [<Struct>] StringOfMinLength10Validator =
        interface IValidator<string> with
            member this.Validate value = validate value

module OmniUserId =
    exception StringIsNotGuidParseable

    let private validate (value: string) =
        match Guid.TryParse value with
        | true, _ -> Ok value
        | _ -> Error StringIsNotGuidParseable

    type [<Struct>] OmniUserIdValidator =
        interface IValidator<string> with
            member this.Validate value = validate value

module ExistsInSomeCollection =
    exception DoesNotExistsInSomeCollection

    let private validate collection value =
        if collection |> Seq.contains value then Ok value
        else Error DoesNotExistsInSomeCollection

    type ExistsInSomeCollectionValidator(collection) = // injected?
        interface IValidator<string> with
            member this.Validate value = value |> validate collection

module Email =
    exception StringIsEmpty
    exception StringIsNotAnEmail

    let private validate value =
        if String.IsNullOrEmpty value then Error StringIsEmpty
        elif not (Regex.IsMatch(value, "(^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$)")) then Error StringIsNotAnEmail
        else Ok value

    type [<Struct>] EmailValidator =
        interface IValidator<string> with
            member this.Validate value = validate value

module NonNegativeInt =
    exception ValueIsNegative

    let private validate value =
        if value < 0 then Error ValueIsNegative
        else Ok value

    type [<Struct; RequireQualifiedAccess>] NonNegativeIntValidator =
        interface IValidator<int> with
            member this.Validate value = validate value

open ExistsInSomeCollection
open OmniUserId
open NonEmptyString
open Email
open NonNegativeInt
open StringOfMinLength10
open StringOfMaxLength50

// Should only be called with CreateWith. How to constrain?
type ExistsInSomeCollection = DomainEntity<RefValidator<ExistsInSomeCollectionValidator, string>, string>
type OmniUserId = DomainEntity<OmniUserIdValidator, string>

type NonEmptyString = DomainEntity<NonEmptyStringValidator, string>
type NonNegativeInt = DomainEntity<NonNegativeIntValidator, int>

type FirstName = DomainEntity<StringOfMinLength10Validator, StringOfMaxLength50Validator, string>
type LastName = NonEmptyString
type Age = NonNegativeInt
type Email = DomainEntity<EmailValidator, string>

type User = {
    FirstName: FirstName
    LastName: LastName
    Age: Age
    Email: Email option
}
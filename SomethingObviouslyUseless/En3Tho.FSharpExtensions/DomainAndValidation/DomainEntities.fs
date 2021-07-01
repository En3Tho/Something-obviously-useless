module En3Tho.FSharpExtensions.DomainAndValidation.DomainEntities

open System
open System.Text.RegularExpressions
open En3Tho.FSharpExtensions.DomainAndValidation.Validator

module NotEmptyString =
    type NotEmptyStringError =
        | IsNullOrEmpty

    let private validate value =
        if String.IsNullOrEmpty value then Error IsNullOrEmpty
        else Ok value

    type [<Struct>] NotEmptyStringValidator =
        interface IValidator<string, NotEmptyStringError> with
            member this.Validate value = validate value

module StringOfLength50 =
    type StringOfLength50Error =
        | IsNullOrEmpty
        | LengthIsGreaterThan50

    let private validate value =
        if String.IsNullOrEmpty value then Error IsNullOrEmpty
        elif value.Length > 50 then Error LengthIsGreaterThan50
        else Ok value

    type [<Struct>] NotEmptyStringValidator =
        interface IValidator<string, StringOfLength50Error> with
            member this.Validate value = validate value

module OmniUserId =
    type OmniUserIdError =
        | StringIsNotGuidParseable

    let private validate (value: string) =
        match Guid.TryParse value with
        | true, _ -> Ok value
        | _ -> Error StringIsNotGuidParseable

    type [<Struct>] OmniUserIdValidator =
        interface IValidator<string, OmniUserIdError> with
            member this.Validate value = validate value

module ExistsInSomeCollection =
    type ExistsInSomeCollectionError =
        | DoesNotExistsInSomeCollection

    let private validate collection value =
        if collection |> Seq.contains value then Ok value
        else Error DoesNotExistsInSomeCollection

    type ExistsInSomeCollectionValidator(collection) = // injected?
        interface IValidator<string, ExistsInSomeCollectionError> with
            member this.Validate value = value |> validate collection

module Email =
    type EmailError =
        | StringIsEmpty
        | StringIsNotAnEmail

    let private validate value =
        if String.IsNullOrEmpty value then Error StringIsEmpty
        elif not (Regex.IsMatch(value, "(^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$)")) then Error StringIsNotAnEmail
        else Ok value

    type [<Struct>] EmailValidator =
        interface IValidator<string, EmailError> with
            member this.Validate value = validate value

module NonNegativeInt =

    type NonNegativeIntError =
        | ValueIsNegative

    let private validate value =
        if value < 0 then Error ValueIsNegative
        else Ok value

    type [<Struct; RequireQualifiedAccess>] NonNegativeIntValidator =
        interface IValidator<int, NonNegativeIntError> with
            member this.Validate value = validate value

open ExistsInSomeCollection
open OmniUserId
open NotEmptyString
open Email
open NonNegativeInt

// Should only be called with CreateWith. How to constrain?
type ExistsInSomeCollection = DomainEntity<RefValidator<ExistsInSomeCollectionValidator, string, ExistsInSomeCollectionError>, string, ExistsInSomeCollectionError>
type OmniUserId = DomainEntity<OmniUserIdValidator, string, OmniUserIdError>

type NotEmptyString = DomainEntity<NotEmptyStringValidator, string, NotEmptyStringError>
type NonNegativeInt = DomainEntity<NonNegativeIntValidator, int, NonNegativeIntError>

type FirstName = NotEmptyString
type LastName = NotEmptyString
type Age = NonNegativeInt
type Email = DomainEntity<EmailValidator, string, EmailError>

type User = {
    FirstName: FirstName
    LastName: LastName
    Age: Age
    Email: Email option
}
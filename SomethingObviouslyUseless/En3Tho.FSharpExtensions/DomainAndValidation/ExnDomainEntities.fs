module En3Tho.FSharpExtensions.DomainAndValidation.ExnValidation.DomainEntities

open System
open System.Text.RegularExpressions
open En3Tho.FSharpExtensions.DomainAndValidation.ExnValidation

module NonEmptyString =
    exception IsNullOrEmpty

    let private validate value =
        if String.IsNullOrEmpty value then Error IsNullOrEmpty
        else Ok value

    type [<Struct>] Validator =
        interface IValidator<string> with
            member this.Validate value = validate value

module NonEmptyGuid =
    exception IsEmpty
    
    let private validate value =
        if Guid.Empty = value then Error IsEmpty
        else Ok value
        
    type [<Struct>] Validator =
         interface IValidator<Guid> with
             member this.Validate value = validate value
     

module StringOfMaxLength50 =
    exception LengthIsGreaterThan50

    let private validate (value: string) =
        if value.Length > 50 then Error LengthIsGreaterThan50
        else Ok value

    type [<Struct>] Validator =
        interface IValidator<string> with
            member this.Validate value = validate value

module StringOfMinLength10 =
    exception LengthIsLesserThan10

    let private validate (value: string) =
        if value.Length > 50 then Error LengthIsLesserThan10
        else Ok value

    type [<Struct>] Validator =
        interface IValidator<string> with
            member this.Validate value = validate value

module OmniUserId =
    exception StringIsNotGuidParseable

    let private validate (value: string) =
        match Guid.TryParse value with
        | true, _ -> Ok value
        | _ -> Error StringIsNotGuidParseable

    type [<Struct>] Validator =
        interface IValidator<string> with
            member this.Validate value = validate value

module ExistsInSomeCollection =
    exception DoesNotExistsInSomeCollection

    let private validate collection value =
        if collection |> Seq.contains value then Ok value
        else Error DoesNotExistsInSomeCollection

    type Validator(collection) = // injected?
        interface IValidator<string> with
            member this.Validate value = value |> validate collection

module Email =
    exception StringIsEmpty
    exception StringIsNotAnEmail

    let private validate value =
        if String.IsNullOrEmpty value then Error StringIsEmpty
        elif not (Regex.IsMatch(value, "(^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$)")) then Error StringIsNotAnEmail
        else Ok value

    type [<Struct>] Validator =
        interface IValidator<string> with
            member this.Validate value = validate value

module NonNegativeInt =
    exception ValueIsNegative

    let private validate value =
        if value < 0 then Error ValueIsNegative
        else Ok value

    type [<Struct>] Validator =
        interface IValidator<int> with
            member this.Validate value = validate value

// Should only be called with CreateWith. How to constrain?
type ExistsInSomeCollection = DomainEntity01<string, ExistsInSomeCollection.Validator>
type OmniUserId = DomainEntity10<string, OmniUserId.Validator>

type NonEmptyString = DomainEntity10<string, NonEmptyString.Validator>
type NonNegativeInt = DomainEntity10<int, NonNegativeInt.Validator>

type NonEmptyGuid = DomainEntity10<Guid, NonEmptyGuid.Validator>

type FirstName = DomainEntity20<string, StringOfMinLength10.Validator, StringOfMaxLength50.Validator>
type LastName = NonEmptyString
type Age = NonNegativeInt
type Email = DomainEntity10<string, Email.Validator>

type User = {
    FirstName: FirstName
    LastName: LastName
    Age: Age
    Email: Email voption
}

type UserWithId = {
    Id: NonEmptyGuid
    User: User
}

type CreateUserRequest = {
    FirstName: string
    LastName: string
    Age: int
    Email: string voption
}

module User =
    open DomainEntityExtensions
    open ValidateCE
    open ExceptionExtensions
    
    let createFromRequest (request: CreateUserRequest) = validate {
        let! firstName = FirstName.Create request.FirstName
        let! lastName = LastName.Create request.LastName
        let! age = Age.Create request.Age
        let! email = Email.Create request.Email
        return {
            User.FirstName = firstName
            LastName = lastName
            Age = age
            Email = email
        }
    }
    
    let test req =
        match createFromRequest req with
        | Error err ->
            match err.IsOrContains<Email.StringIsNotAnEmail>() with
            | ValueSome err -> raise err
            | _ -> ()
        | _ -> ()
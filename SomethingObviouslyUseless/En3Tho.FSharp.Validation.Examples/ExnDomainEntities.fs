module En3Tho.FSharp.Validation.DomainEntities

open System
open System.Collections.Generic
open System.Text.RegularExpressions
open System.Threading.Tasks
open En3Tho.FSharp.Validation
open En3Tho.FSharp.Validation.CommonTypes
module NonDefaultValue =
    exception ValueIsDefault
    
    let private validate value =
        if value = Unchecked.defaultof<_> then Error ValueIsDefault
        else Ok value
        
    type [<Struct>] Validator<'a when 'a: equality> =
         interface IValidator<'a> with
             member this.Validate value : ER<'a> = validate value // for some reason type inference fails here
             member this.Validate value : ValueTask<EResult<'a>> = validate value |> ValueTask<_> // and here


module StringOfMaxLength50 =
    exception LengthIsGreaterThan50

    let private validate (value: string) =
        if value.Length > 50 then Error LengthIsGreaterThan50
        else Ok value

    type [<Struct>] Validator =
        interface IValidator<string> with
            member this.Validate value = validate value
            member this.Validate value = validate value |> ValueTask<_>

module StringOfMinLength10 =
    exception LengthIsLesserThan10

    let private validate (value: string) =
        if value.Length > 50 then Error LengthIsLesserThan10
        else Ok value

    type [<Struct>] Validator =
        interface IValidator<string> with
            member this.Validate value = validate value
            member this.Validate value = validate value |> ValueTask<_>
module ValueShouldBeUnique =
    exception ValueIsNotUnique

    let private validate collection value =
        if collection |> Seq.contains value then Error ValueIsNotUnique
        else Ok value

    type Validator(collection) =
        interface IValidator<string> with
            member this.Validate value = value |> validate collection
            member this.Validate value = value |> validate collection |> ValueTask<_>

module ValueShouldBeStorageAccepted =
    exception ValueIsNoAcceptedByStorage
    
    let private validate collection value =
        if collection |> Seq.contains value then Error ValueIsNoAcceptedByStorage
        else Ok value

    type Validator<'a when 'a: equality>(collection) =
        interface IValidator<'a> with
            member this.Validate value : EResult<'a> = value |> validate collection
            member this.Validate value = value |> validate collection |> ValueTask<_>

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
            member this.Validate value = validate value |> ValueTask<_>

type OmniUserId = GuidString

type ValueShouldBeUnique = DomainEntity11<string, NonEmptyString.Validator, ValueShouldBeUnique.Validator>

type FirstName = DomainEntity20<string, StringOfMinLength10.Validator, StringOfMaxLength50.Validator>
type LastName = NonEmptyString
type Age = NonNegativeValue<int>
type Email = Validated10<string, Email.Validator>

type DepartmentName = ValueShouldBeUnique
type DepartmentWorkerCount = NonNegativeValue<int>

type User = {
    FirstName: FirstName
    LastName: LastName
    Age: Age
    Email: Email voption
}

type Department = {
    Name: DepartmentName
    WorkerCount: DepartmentWorkerCount
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

type CreateDepartmentRequest = {
    Name: string
    WorkerCount: int
}

open ValidatedExtensions
open ValidateComputationExpression
open ExceptionExtensions    

module User =
    let createFromRequest (request: CreateUserRequest) = eresult {
        let! firstName = FirstName.Try request.FirstName
        let! lastName = LastName.Try request.LastName
        let! age = Age.Try request.Age
        let! email = Email.Try request.Email
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
        
module Department =
    let private departmentNames = [| "dep1"; "dep2"; "dep3" |] // get a list of all department names
    let create (request: CreateDepartmentRequest) = eresult {
        let departmentNameShouldBeUnique = ValueShouldBeUnique.Validator departmentNames
        let! name = DepartmentName.Try (request.Name, departmentNameShouldBeUnique) // this could be async
        let! workerCount = DepartmentWorkerCount.Try request.WorkerCount
        return {
            Department.Name = name
            WorkerCount = workerCount
        }
    }
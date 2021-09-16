namespace MinimalApisWithPipelines.Pipelines

open MinimalApisWithPipelines.ActivePatterns
open MinimalApisWithPipelines.Framework

type CreateUserRequest = {
    Name: string
}

type User = {
    Name: string
}

// ValidationException with member _.ResourceString

exception RequestIsEmpty
exception NameIsEmpty
exception InvalidName // ResourceString ?

type CreateUserFilter() =
    interface IRequestFilter<CreateUserRequest> with
        member _.Handle request =
            match request with
            | Null -> Error RequestIsEmpty
            | { Name = String.IsNullOrEmpty } -> Error NameIsEmpty
            | { Name = String.StartsWith "Igor" | String.StartsWith "Alex" } -> Error InvalidName
            | _ -> Ok request

type CreateUserHandler() =
    interface IRequestHandler<CreateUserRequest, User> with
        member _.Handle request =
            Ok { Name = request.Name }

type CreateUserPipeline = RequestPipeline<CreateUserRequest, CreateUserFilter, CreateUserRequest, CreateUserHandler, User>
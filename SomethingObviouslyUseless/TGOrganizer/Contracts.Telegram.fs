namespace TGOrganizer.Contracts.Telegram

open System
open System.Threading.Tasks
open En3Tho.FSharp.Extensions
open En3Tho.FSharp.Validation
open En3Tho.FSharp.Validation.CommonValidatedTypes
open TGOrganizer.Contracts
open TGOrganizer.Primitives

[<AutoOpen>]
module TelegramTypes =
    type TelegramUserId = NonNegativeValue<int64>

    module TelegramCommandName =
        type CommandNameLengthIsGreaterThan32() = inherit ValidationException(nameof(CommandNameLengthIsGreaterThan32))

        type [<Struct>] Validator =
            member this.Validate (value: string) =
                if value.Length > 32 then Error (CommandNameLengthIsGreaterThan32() :> exn)
                else Ok value

            interface IValidator<string> with
                member this.Validate value = this.Validate value
                member this.Validate value = this.Validate value |> ValueTask.FromResult
                member this.ValidateAggregate value = this.Validate value |> Result.mapError AggregateException
                member this.ValidateAggregate value = this.Validate value |> Result.mapError AggregateException |> ValueTask.FromResult
    type TelegramCommandName = NewCtorValidatorValidated<string, MultiValidator02<string, NonEmptyString.Validator, TelegramCommandName.Validator>>
    let inline (|TelegramCommandName|) (value: NonNullValue<'a>) = value.Value

    module TelegramCommandDescription =
        type DescriptionLengthIsLessThan3() = inherit ValidationException(nameof(DescriptionLengthIsLessThan3))
        type DescriptionLengthIsGreaterThan256() = inherit ValidationException(nameof(DescriptionLengthIsGreaterThan256))

        type [<Struct>] Validator =
            member this.Validate (value: string) =
                if value.Length > 256 then Error (DescriptionLengthIsGreaterThan256() :> exn)
                elif value.Length < 3 then Error (DescriptionLengthIsLessThan3() :> exn)
                else Ok value

            interface IValidator<string> with
                member this.Validate value = this.Validate value
                member this.Validate value = this.Validate value |> ValueTask.FromResult
                member this.ValidateAggregate value = this.Validate value |> Result.mapError AggregateException
                member this.ValidateAggregate value = this.Validate value |> Result.mapError AggregateException |> ValueTask.FromResult
    type TelegramCommandDescription = NewCtorValidatorValidated<string, MultiValidator02<string, NonEmptyString.Validator, TelegramCommandDescription.Validator>>
    let inline (|TelegramCommandDescription|) (value: NonNullValue<'a>) = value.Value

type TelegramUser = {
    Id: NonEmptyGuid
    TelegramId: TelegramUserId
    SystemUser: User
}

type CreateTelegramUserCommand = {
    TelegramId: TelegramUserId
    SystemUser: User
}

type TelegramUserAlreadyExistsException() = inherit ProcessingException(nameof(TelegramUserAlreadyExistsException))
type TelegramUserDoesNotExistException() = inherit ProcessingException(nameof(TelegramUserDoesNotExistException))
type SystemUserAndTelegramIdMismatchException() = inherit ProcessingException(nameof(SystemUserAndTelegramIdMismatchException))

type ITelegramUserStorage =
    abstract CreateUser: command: CreateTelegramUserCommand -> Task<ExnResult<TelegramUser>>
    abstract ChangeUser: user: TelegramUser -> Task<ExnResult<TelegramUser>>
    abstract GetUser: user: User -> Task<ExnResult<TelegramUser>>
    abstract GetUser: userId: TelegramUserId -> Task<ExnResult<TelegramUser>>

type TodoTaskTelegramNotification = {
    Time: ValidDateTimeOffset
    Item: TodoTask
    TelegramUser: TelegramUser
}
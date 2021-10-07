namespace TGOrganizer.Contracts.Telegram

open System.Threading.Tasks
open En3Tho.FSharp.Extensions
open En3Tho.FSharp.Validation
open En3Tho.FSharp.Validation.CommonValidatedTypes
open TGOrganizer.Contracts
open TGOrganizer.Primitives

type TelegramUserId = NonNegativeValue<int64>

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
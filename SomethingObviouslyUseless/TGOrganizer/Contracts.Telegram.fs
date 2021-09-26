namespace TGOrganizer.Contracts.Telegram

open System.Threading.Tasks
open En3Tho.FSharp.Validation
open En3Tho.FSharp.Validation.CommonTypes
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

type TelegramUserAlreadyExistsException() = inherit DomainException(nameof(TelegramUserAlreadyExistsException))
type TelegramUserDoesNotExistException() = inherit DomainException(nameof(TelegramUserDoesNotExistException))
type SystemUserAndTelegramIdMismatchException() = inherit DomainException(nameof(SystemUserAndTelegramIdMismatchException))

type ITelegramUserStorage =
    abstract CreateUser: command: CreateTelegramUserCommand -> Task<EResult<TelegramUser>>
    abstract ChangeUser: user: TelegramUser -> Task<EResult<TelegramUser>>
    abstract GetUser: user: User -> Task<EResult<TelegramUser>>
    abstract GetUser: userId: TelegramUserId -> Task<EResult<TelegramUser>>

type TodoTaskTelegramNotification = {
    Time: ValidDateTimeOffset
    Item: TodoTask
    TelegramUser: TelegramUser
}
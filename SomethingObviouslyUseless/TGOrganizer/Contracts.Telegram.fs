namespace TGOrganizer.Contracts.Telegram

open System.Threading.Tasks
open En3Tho.FSharp.Validation
open En3Tho.FSharp.Validation.CommonTypes
open TGOrganizer.Contracts
open TGOrganizer.Primitives

type TelegramId = NonDefaultValue<int64>

type TelegramUser = {
    Id: NonEmptyGuid
    TelegramId: TelegramId
    SystemUser: User
}

type CreateTelegramUserCommand = {
    TelegramId: TelegramId
    SystemUser: User
}

exception TelegramUserAlreadyExists
exception TelegramUserDoesNotExist

type ITelegramUserStorage =
    abstract CreateUser: command: CreateUserCommand -> Task<EResult<TelegramUser>>
    abstract ChangeUser: user: TelegramUser -> Task<EResult<TelegramUser>>
    abstract GetUser: user: User -> Task<EResult<TelegramUser>>

type TodoTaskTelegramNotification = {
    Time: ValidDateTimeOffset
    Item: TodoTask
    TelegramUser: TelegramUser
}
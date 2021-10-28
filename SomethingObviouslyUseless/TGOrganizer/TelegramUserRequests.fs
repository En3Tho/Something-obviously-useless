module TGOrganizer.TelegramUserRequests

open System.Threading
open System.Threading.Channels
open System.Threading.Tasks
open En3Tho.FSharp.Extensions
open En3Tho.FSharp.Validation.CommonValidatedTypes
open Microsoft.Extensions.Logging
open TGOrganizer.Primitives
open Telegram.Bot
open Telegram.Bot.Types
open Telegram.Bot.Types.ReplyMarkups

let [<Literal>] Next = "Next"
let [<Literal>] GoBack = "GoBack"
let [<Literal>] Cancel = "Cancel"

type UserStateMachineState =
    | ChoosingName
    | ChoosingBody of Name: NonEmptyString
    | ChoosingDate of Name: NonEmptyString * Body: NonEmptyString[] option
    | ChoosingTime of Name: NonEmptyString * Body: NonEmptyString[] option * Date: ValidTimeSpan

type TGUserStateMachine(userId: ChatId) =
    let mutable state = ChoosingName
    member _.Id = userId

let sendTodoTaskChooseNameRequest (chatId: int64) (client: ITelegramBotClient) =
    let id = chatId.ToString()
    let makeMessage msg = id + "_" + msg
    let replyKeyboardMarkup = InlineKeyboardMarkup(inlineKeyboard = [|
        [|
            InlineKeyboardButton.WithCallbackData("Next step", makeMessage Next)
            InlineKeyboardButton.WithCallbackData("Cancel", makeMessage Cancel)
        |]
    |])

    client.SendTextMessageAsync(
        chatId = ChatId.op_Implicit chatId,
        text = "Choose a name for task",
        replyMarkup = replyKeyboardMarkup
    )

let sendTodoTaskChooseBodyRequest (chatId: int64) (client: ITelegramBotClient) =
    let id = chatId.ToString()
    let makeMessage msg = id + "_" + msg
    let replyKeyboardMarkup = InlineKeyboardMarkup(inlineKeyboard = [|
        [|
            InlineKeyboardButton.WithCallbackData("Next step", makeMessage Next)
            InlineKeyboardButton.WithCallbackData("Cancel", makeMessage GoBack)
            InlineKeyboardButton.WithCallbackData("Cancel", makeMessage Cancel)
        |]
    |])

    client.SendTextMessageAsync(
        chatId = ChatId.op_Implicit chatId,
        text = "Provide a body for task",
        replyMarkup = replyKeyboardMarkup
    )

let sendTodoTaskChooseDateRequest (chatId: int64) (client: ITelegramBotClient) =
    let id = chatId.ToString()
    let makeMessage msg = id + "_" + msg
    let replyKeyboardMarkup = InlineKeyboardMarkup(inlineKeyboard = [|
        [|
            InlineKeyboardButton.WithCallbackData("Next step", makeMessage Next)
            InlineKeyboardButton.WithCallbackData("Cancel", makeMessage GoBack)
            InlineKeyboardButton.WithCallbackData("Cancel", makeMessage Cancel)
        |]
    |])

    client.SendTextMessageAsync(
        chatId = ChatId.op_Implicit chatId,
        text = "Choose date for task",
        replyMarkup = replyKeyboardMarkup
    )

let sendTodoTaskChooseTimeRequest (chatId: int64) (client: ITelegramBotClient) =
    let id = chatId.ToString()
    let makeMessage msg = id + "_" + msg
    let replyKeyboardMarkup = InlineKeyboardMarkup(inlineKeyboard = [|
        [|
            InlineKeyboardButton.WithCallbackData("Next step", makeMessage Next)
            InlineKeyboardButton.WithCallbackData("Cancel", makeMessage GoBack)
            InlineKeyboardButton.WithCallbackData("Cancel", makeMessage Cancel)
        |]
    |])
    // let! userResponse = sendUserRequest // ...
    // let tcs = TaskCompletionSource
    // let userActor = ActorManager.GetActor(id)
    // let customMessages = ...
    // let customHandlerEnvelope = { MessageId: Guid; Tcs: TaskCompletionSource voption; }
    // Actor -> 2 types of messages ...
    // CustomHandler | Message
    client.SendTextMessageAsync(
        chatId = ChatId.op_Implicit chatId,
        text = "Choose time for task",
        replyMarkup = replyKeyboardMarkup
    )

type Actor<'message>(logger: ILogger<Actor<'message>>, processMessage: 'message -> Task<unit>, token: CancellationToken) =
    let channel = Channel.CreateUnbounded()
    let writer = channel.Writer
    let reader = channel.Reader
    do ignore ^ task {
        while true do
            if not token.IsCancellationRequested then
                try
                    let! message = reader.ReadAsync(token)
                    do! processMessage message
                with exn ->
                    logger.LogError("Error occured when handling message: {exn}", exn)
    }
    member _.Post message = writer.WriteAsync(message, token)
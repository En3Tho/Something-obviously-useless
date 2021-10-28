namespace TGOrganizer.Implementation

open System.Threading
open System.Threading.Tasks
open Telegram.Bot
open Telegram.Bot.Types
open Telegram.Bot.Types.ReplyMarkups
open TGOrganizer.TelegramApi.ActivePatterns
open En3Tho.FSharp.Extensions

[<AutoOpen>]
module Tasks =
    let unitTask = FSharp.Control.Tasks.Affine.unitTask

type BotId = string

type ITelegramWebHookService =
    abstract ProcessWebhookMessage: id: BotId * update: Update -> Task<unit>

module TelegramTest =

    let sendChatMessage (chatId: int64) message (client: ITelegramBotClient) =
        client.SendTextMessageAsync(ChatId.op_Implicit chatId, message)

    let sendSimpleKeyboard (chatId: int64) (client: ITelegramBotClient) =
        let replyKeyboardMarkup = ReplyKeyboardMarkup(keyboard = [|
            [|
                KeyboardButton("Help me")
                KeyboardButton("Call me ☎️")
            |]
        |], ResizeKeyboard = true)

        client.SendTextMessageAsync(
            chatId = ChatId.op_Implicit chatId,
            text = "Choose a response",
            replyMarkup = replyKeyboardMarkup
        )

    let sendSimpleMultiRowKeyboard (chatId: int64) (client: ITelegramBotClient) =
        let replyKeyboardMarkup = ReplyKeyboardMarkup(keyboard = [|
            [|
                KeyboardButton("Help me")
            |]
            [|
                KeyboardButton("Call me ☎️")
            |]
        |], ResizeKeyboard = true)

        client.SendTextMessageAsync(
            chatId = ChatId.op_Implicit chatId,
            text = "Choose a response",
            replyMarkup = replyKeyboardMarkup
        )

    let sendRequestInformationKeyboard (chatId: int64) (client: ITelegramBotClient) =

        let replyKeyboardMarkup = ReplyKeyboardMarkup(keyboardRow = [|
            KeyboardButton.WithRequestLocation("Share location")
            KeyboardButton.WithRequestContact("Share contact️")
        |])

        client.SendTextMessageAsync(
            chatId = ChatId.op_Implicit chatId,
            text = "Who or Where are you?",
            replyMarkup = replyKeyboardMarkup
        )

    let sendRemoveKeyboard (chatId: int64) (client: ITelegramBotClient) =
        let replyKeyboardMarkup = ReplyKeyboardRemove()

        client.SendTextMessageAsync(
            chatId = ChatId.op_Implicit chatId,
            text = "Removing keyboard",
            replyMarkup = replyKeyboardMarkup
        )

    let sendInlineCallbackKeyboard (chatId: int64) (client: ITelegramBotClient) =
        let replyKeyboardMarkup = InlineKeyboardMarkup(inlineKeyboard = [|
            [|
                InlineKeyboardButton.WithCallbackData("1.1", "11")
                InlineKeyboardButton.WithCallbackData("1.2", "12")
            |]
            [|
                InlineKeyboardButton.WithCallbackData("2.1", "22")
                InlineKeyboardButton.WithCallbackData("2.2", "22")
            |]
        |])

        client.SendTextMessageAsync(
            chatId = ChatId.op_Implicit chatId,
            text = "A message with an inline keyboard markup",
            replyMarkup = replyKeyboardMarkup
        )

    let sendInlineUrlKeyboard (chatId: int64) (client: ITelegramBotClient) =
        let replyKeyboardMarkup = InlineKeyboardMarkup(inlineKeyboardRow = [|
            InlineKeyboardButton.WithUrl("Link to the Repository", "https://github.com/TelegramBots/Telegram.Bot")
        |])

        client.SendTextMessageAsync(
            chatId = ChatId.op_Implicit chatId,
            text = "A message with an inline keyboard markup",
            replyMarkup = replyKeyboardMarkup
        )

    let sendInlineSwitchToInlineKeyboard (chatId: int64) (client: ITelegramBotClient) =
        let replyKeyboardMarkup = InlineKeyboardMarkup(inlineKeyboardRow = [|
            InlineKeyboardButton.WithSwitchInlineQuery("switch_inline_query")
            InlineKeyboardButton.WithSwitchInlineQueryCurrentChat("switch_inline_query_current_chat")
        |])

        client.SendTextMessageAsync(
            chatId = ChatId.op_Implicit chatId,
            text = "A message with an inline keyboard markup",
            replyMarkup = replyKeyboardMarkup
        )

    let handleUpdate(client: ITelegramBotClient) (update: Update) (token: CancellationToken) = task {
        match update with
        | Update.Message (msg & Message.Text (text & String.NotNullOrEmpty)) ->
            let chatId = msg.Chat.Id

            let request =
                match text with
                | "/reply" ->
                    sendChatMessage chatId $"Received {update.Message.Text} via text"
                | "/keyboard" ->
                    sendSimpleKeyboard chatId
                | "/keyboardmulti" ->
                    sendSimpleMultiRowKeyboard chatId
                | "/keyboardrequestinfo" ->
                    sendRequestInformationKeyboard chatId
                | "/inlinecallback" ->
                    sendInlineCallbackKeyboard chatId
                | "/inlineUrl" ->
                    sendInlineUrlKeyboard chatId
                | "/removekeyboard" ->
                    sendRemoveKeyboard chatId
                | "/inlineswitch" ->
                    sendInlineSwitchToInlineKeyboard chatId
                | _ ->
                    sendChatMessage chatId "Unrecognized command"

            do! client |> request :> Task

        | Update.CallbackQuery query ->
            let chatId = query.Message.Chat.Id

            let request =
                match query.Message with
                | msg & Message.Text (text & String.NotNullOrEmpty) ->
                    sendChatMessage chatId $"Received {msg.Text} : {query.Data} via callback query"
                | _ ->
                    sendChatMessage chatId "Unrecognized command"

            do! client |> request :> Task

        | Update.InlineQuery query ->
            printfn $"Received inline query: {query.Query} from User: {query.From.Username}"

        | _ -> ()
    }

type TelegramWebHookService(client: ITelegramBotClient) =

    interface ITelegramWebHookService with
        member this.ProcessWebhookMessage(id, update) = TelegramTest.handleUpdate client update CancellationToken.None
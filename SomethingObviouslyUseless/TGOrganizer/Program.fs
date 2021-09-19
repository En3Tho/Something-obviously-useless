open System
open System.Threading
open System.Threading.Tasks
open En3Tho.FSharp.Extensions
open FSharp.Control.Tasks
open TGOrganizer.TelegramApi.ActivePatterns
open Telegram.Bot
open TGOrganizer.Primitives
open Telegram.Bot.Exceptions
open Telegram.Bot.Types
open Telegram.Bot.Types.Enums
open Telegram.Bot.Extensions.Polling
open Telegram.Bot.Types.ReplyMarkups;

module Telegram =

    [<AbstractClass>]
    type Func() =
        static member FromFun (f: 'a -> 'b) = Func<_,_>(f)
        static member FromFun (f: 'a -> 'b -> 'c) = Func<_,_,_>(f)
        static member FromFun (f: 'a * 'b -> 'c) = Func<_,_,_>(fun a b -> f (a,b))

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

    let handleUpdate(client: ITelegramBotClient) (update: Update) (token: CancellationToken) = unitTask {
        match update with
        | Update.Message (msg & Message.Text (text & String.NotNullOrEmpty)) ->
            let chatId = msg.Chat.Id

            let request =
                match text with
                | String.Equals "/reply" ->
                    sendChatMessage chatId $"Received {update.Message.Text} via text"
                | String.Equals "/keyboard" ->
                    sendSimpleKeyboard chatId
                | String.Equals "/keyboardmulti" ->
                    sendSimpleMultiRowKeyboard chatId
                | String.Equals "/keyboardrequestinfo" ->
                    sendRequestInformationKeyboard chatId
                | String.Equals "/inlinecallback" ->
                    sendInlineCallbackKeyboard chatId
                | String.Equals "/inlineUrl" ->
                    sendInlineUrlKeyboard chatId
                | String.Equals "/removekeyboard" ->
                    sendRemoveKeyboard chatId
                | String.Equals "/inlineswitch" ->
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

    let handleError(client: ITelegramBotClient) (exn: Exception) (token: CancellationToken) = unitTask {
        match exn with
        | :? ApiRequestException as exn -> $"Telegram API Error:\n[{exn.ErrorCode}]\n{exn.Message}"
        | _ -> exn.ToString()
        |> printfn "%s"
    }

    let startBot() = task {
        let bot = TelegramBotClient("1715734966:AAFWYp_atrc9p3jVW5HmwiCHBq6TG6TXLW4")
        let! me = bot.GetMeAsync()
        printfn $"Hello, World! I am user {me.Id} and my name is {me.FirstName}."

        do! bot.DeleteWebhookAsync()

        let cts = new CancellationTokenSource()
        bot.StartReceiving(DefaultUpdateHandler(Func<_,_,_,_> handleUpdate, Func<_,_,_,_> handleError), cts.Token)
        Console.ReadLine() |> ignore
        cts.Cancel()
    }

let generateUpdateActivePatterns() =
    for updateType in Enum.GetNames<UpdateType>() do
        $"""
let inline (|{updateType}|_|) (update: Update) =
    match update.Type with
    | UpdateType.{updateType} -> Some update.{updateType}
    | _ -> None
        """
        |> printfn "%s"

let generateMessageActivePatterns() =
    for messageType in Enum.GetNames<MessageType>() do
        $"""
let inline (|{messageType}|_|) (message: Message) =
    match message.Type with
    | MessageType.{messageType} -> Some message.{messageType}
    | _ -> None
        """
        |> printfn "%s"

[<EntryPoint>]
let main argv =
    Telegram.startBot()
    |> Task.RunSynchronously
    0
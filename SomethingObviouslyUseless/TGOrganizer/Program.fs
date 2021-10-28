open System
open System.Threading
open System.Threading.Tasks
open En3Tho.FSharp.Extensions
open FSharp.Control.Tasks
open TGOrganizer.Implementation
open Telegram.Bot
open Telegram.Bot.Exceptions
open Telegram.Bot.Types.Enums
open Telegram.Bot.Extensions.Polling

module Telegram =

    let handleError(client: ITelegramBotClient) (exn: Exception) (token: CancellationToken) = unitTask {
        match exn with
        | :? ApiRequestException as exn -> $"Telegram API Error:\n[{exn.ErrorCode}]\n{exn.Message}"
        | _ -> exn.ToString()
        |> printfn "%s"
    }

    let startBot() = task {
        let bot = TelegramBotClient("1715734966:AAFWYp_atrc9p3jVW5HmwiCHBq6TG6TXLW4")
        let botId = string bot.BotId
        let! me = bot.GetMeAsync()

        printfn $"Hello, World! I am user {me.Id} and my name is {me.FirstName}."

        let service = TelegramWebHookService(bot) :> ITelegramWebHookService

        do! bot.DeleteWebhookAsync()

        let cts = new CancellationTokenSource()
        let handleUpdate _ update _ =
            service.ProcessWebhookMessage(botId, update) :> Task
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
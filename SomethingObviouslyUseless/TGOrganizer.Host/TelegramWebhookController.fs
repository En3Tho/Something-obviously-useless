namespace TGOrganizer.Host

open Microsoft.AspNetCore.Mvc
open TGOrganizer.Implementation
open Telegram.Bot.Types

module TelegramWebhookController =
    module Routes =
        let [<Literal>] Controller = "tg-organizer"
        let [<Literal>] WebHook = "tg-webhook"

open TelegramWebhookController
[<Route(Routes.Controller)>]
type TelegramWebhookController(service: ITelegramWebHookService) =
    inherit ControllerBase()

    [<Route(Routes.WebHook)>]
    member _.WebHook(botId: string, message: Update) = task {
        do! service.ProcessWebhookMessage(botId, message)
    }
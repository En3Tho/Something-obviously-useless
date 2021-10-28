module TGOrganizer.TelegramButtonUI

open System.Text.Json
open En3Tho.FSharp.Extensions
open En3Tho.FSharp.Validation.CommonValidatedTypes


open TGOrganizer.Contracts
open Telegram.Bot
open Telegram.Bot.Types
open Telegram.Bot.Types.ReplyMarkups

type SessionId = NonDefaultValue<int64> // always positive ?

// SessionId : NonEmptyInt64

type ITelegramButton =
    abstract Description: NonEmptyString
    abstract CallbackQuery: NonEmptyString

module MenuActions =
    let [<Literal>] Register = "/register"
    let [<Literal>] TodoTasks = "/todotasks"
    let [<Literal>] Notifications = "/notifications"
    let [<Literal>] Notes = "/notes"

type UserScreen =
    | Register
    | TodoTasks
    | Notifications
    | Notes
    interface ITelegramButton with
        member this.Description = this |> Union.getName |> NonEmptyString.Make // Culture?
        member this.CallbackQuery = this |> JsonSerializer.Serialize |> NonEmptyString.Make

let getRegisteredUserMainMenu() = [|
        InlineKeyboardButton.WithCallbackData(nameof(TodoTasks), MenuActions.TodoTasks)
        InlineKeyboardButton.WithCallbackData(nameof(Notifications), MenuActions.Notifications)
        InlineKeyboardButton.WithCallbackData(nameof(Notes), MenuActions.Notes)
    |]

let getUnregisteredUserMainMenu() = [|
        InlineKeyboardButton.WithCallbackData(nameof(Register), MenuActions.Register)
    |]

type TodoTaskScreen =
    | Show
    | Create
    | Edit
    | Share

module TodoTaskScreenShow =

    type TodoTasksScreenShowButton =
        | Back
        | Detailed of TodoTask

module TodoTaskScreenCreate =

    type TodoTasksScreenCreateFillBodyStep =
        | Cancel
        | DoneWithTextingBody

    type TodoTasksScreenPickDateStep =
        | Cancel
        | Back
        | DonePicking

    type TodoTasksScreenCreateTimeButton =
        | Cancel
        | Back
        | Schedule

    type TodoTasksScreenCreateScheduleButton =
        | Cancel
        | Back
        | TimePicker

    type TodoTasksScreenCreateScheduleTimePickerButton =
        | Cancel
        | Back
        | Done
        | Recurse

    type TodoTasksScreenCreateScheduleTimePickerRecurseButton =
        | Cancel
        | Back
        | TimePicker

    type TodoTasksScreenCreateScheduleTimePickerRecurseTimePickerButton =
        | Cancel
        | Back
        | Ok

// UserState = MainMenu | CreatingTask of TaskCreationStep | ShowingTasks | ExaminingTask of TaskId

// send create task description
//

module MessageIds =
    let [<Literal>] OnTaskCreation = "OnTaskCreation"

module Messages =
    let [<Literal>] OnTaskCreation = ""

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

module TelegramTodoTaskMaker =
    type TelegramTodoTaskData = {
        Body: string
    }

// Description
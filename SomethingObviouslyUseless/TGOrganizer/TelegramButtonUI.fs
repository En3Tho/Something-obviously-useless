module TGOrganizer.TelegramButtonUI

open System
open System.Collections.Generic
open System.Text.Json
open System.Threading.Tasks
open En3Tho.FSharp.Extensions
open En3Tho.FSharp.Validation.CommonTypes
open FSharp.Control.Tasks

open En3Tho.FSharp.ComputationExpressions.ICollectionBuilder
open En3Tho.FSharp.Validation

open TGOrganizer.Primitives
open TGOrganizer.Contracts
open TGOrganizer.TelegramApi.ActivePatterns
open Telegram.Bot.Types.ReplyMarkups

type SessionId = NonDefaultValue<int64>

// SessionId : NonEmptyInt64

type ITelegramButton =
    abstract Description: NonEmptyString
    abstract CallbackQuery: NonEmptyString

type Screen =
    | TodoTasks
    | Notifications
    | Notes
    interface ITelegramButton with
        member this.Description = this |> Union.getName |> NonEmptyString.Make
        member this.CallbackQuery = this |> JsonSerializer.Serialize |> NonEmptyString.Make

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


// Description
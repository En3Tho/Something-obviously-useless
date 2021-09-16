module TGOrganizer.TelegramButtonUI

open System
open System.Threading.Tasks
open FSharp.Control.Tasks

open En3Tho.FSharp.ComputationExpressions.ICollectionBuilder
open En3Tho.FSharp.Validation

open TGOrganizer.Primitives
open TGOrganizer.Contracts
open TGOrganizer.TelegramApi.ActivePatterns


type Screen =
    | TodoTasks
    | Notifications
    | Notes

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

    type TodoTasksScreenCreateButton =
        | Cancel
        | Body

    type TodoTasksScreenCreateNameButton =
        | Cancel
        | Calendar

    type TodoTasksScreenCreateCalendarButton =
        | Cancel
        | TimePicker

    type TodoTasksScreenCreateTimeButton =
        | Cancel
        | Schedule

    type TodoTasksScreenCreateScheduleButton =
        | Cancel
        | TimePicker

    type TodoTasksScreenCreateScheduleTimePickerButton =
        | Cancel
        | Ok
        | Recurse

    type TodoTasksScreenCreateScheduleTimePickerRecurseButton =
        | Cancel
        | TimePicker

    type TodoTasksScreenCreateScheduleTimePickerRecurseTimePickerButton =
        | Cancel
        | Ok

// Step.ContinueWith(x.ContinueWith(...), y)

type CancellableBacktrackingExecution<'state> =
    | Success of Value: EResult<'state>
    | Cancel
    | Back

type AsyncCancellableBacktrackingExecution<'result> = Task<CancellableBacktrackingExecution<'result>>
type AsyncCancellableBacktrackingExecutionFactory<'result> = 'result -> AsyncCancellableBacktrackingExecution<'result>

type CancellableBacktrackingExecutionRunner<'result>(initial: 'result) =
    let steps = ResizeArray()
    let states = ResizeArray() { initial }

    member this.Yield (yieldResult: AsyncCancellableBacktrackingExecutionFactory<'result>) =
        yieldResult

    member this.Delay f = f

    member this.Run(initialState: 'result, computation) = task {
        states.Add initialState
        return! computation
    }

    member this.Combine(step: AsyncCancellableBacktrackingExecutionFactory<'result>, continuation) = task {
        steps.Add step
        let state = states.TakeLast()

        match! step state with
        | Success (Ok value) ->
            states.Add value
            return! continuation value
        | Success (Error exn) ->
            return Error exn
        | Cancel ->
            return Error (OperationCanceledException() :> exn)
        | Back when steps.Count <= 1 ->
            return Error (OperationCanceledException() :> exn)
        | Back ->
            states.RemoveLast()
            let currentStep = steps.PopLast()
            let prevStep = steps.PopLast()

            return! this.Combine(prevStep, fun value -> task {
                states.Add value
                return! this.Combine(currentStep, continuation)
            })
    }

let tgTodoTaskComputation = [|
    askUserForBody // user state
    askUserForDate // user state
    askUserForTime // user state
    askUserForSchedule // user state
|]

type Telegram

type [<Struct>] TgStringResponse = { Value: string }

let x = OperationCanceledException()
type AsyncTGEResult<'a> = AsyncEResult<'a>



let myResult user = tgUserResponse {
    let! body = askUserForBody user
    let! askFor

}

// let! taskData

module ButtonConverter =
    let x = 0

let getMainMenu (user: User) =
    match user with
    | User.Anonymous ->
        [
            Register
        ]
    | User.Telegram tgUser ->
        [
            ShowTodoTasks
            CreateTodoTask
        ]

let moveToScreen (user: TelegramUser) (newScreen: Screen) (oldScreen: Screen) =
    match oldScreen with
    | _ -> ()
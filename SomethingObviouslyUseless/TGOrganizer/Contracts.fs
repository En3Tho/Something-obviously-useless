namespace TGOrganizer.Contracts

open System.Threading.Tasks
open En3Tho.FSharp.Validation
open En3Tho.FSharp.Validation.CommonTypes
open TGOrganizer.Primitives

type User = {
    Id: NonEmptyGuid
    Login: NonEmptyString
    Name: NonEmptyString
}

type CreateUserCommand = {
    Login: NonEmptyString
    Name: NonEmptyString
}

exception UserAlreadyExists
exception UserDoesNotExist

type IUserStorage =
    abstract member CreateUser: command: CreateUserCommand -> Task<EResult<User>>
    abstract member ChangeUser: user: User -> Task<EResult<User>>

type ScheduleType =
    | RunOnce of Date: ValidDateTimeOffset
    | RunPeriodically of Start: ValidDateTimeOffset * Period: ValidTimeSpan

type State =
    | InProgress
    | Done of Date: ValidDateTimeOffset
    | Removed of Date: ValidDateTimeOffset

type TodoTaskBody = {
    Description: NonEmptyString
}

type TodoTask = {
    Id: NonEmptyGuid
    Body: TodoTaskBody
    Schedule: ScheduleType
    User: User
    State: State
}

type CreateTodoTaskCommand = {
    Body: TodoTaskBody
    Schedule: ScheduleType
}

type ITodoItemEditorService =
    abstract GetTodoItems: user: User -> AsyncEResult<NonNullValue<array<TodoTask>>>
    abstract CreateTodoItem: user: User * command: CreateTodoTaskCommand -> AsyncEResult<TodoTask>
    abstract EditTodoItem: user: User * task: TodoTask -> AsyncEResult<TodoTask>
    abstract RemoveTodoItem: user: User * task: TodoTask -> AsyncEResult<unit>

type TodoItemEditorServiceEvents =
    | TodoItemCreated of Item: TodoTask
    | TodoItemEdited of OldItem: TodoTask * NewItem: TodoTask
    | TodoItemRemoved of Item: TodoTask

exception TodoTaskAlreadyExists of TodoTask: TodoTask
exception TodoTaskDoesNotExist of TodoTask: TodoTask

type ITodoTaskStorage =
    abstract GetTodoItems: user: User -> Task<EResult<NonNullValue<array<TodoTask>>>>
    abstract CreateTodoItem: user: User * command: CreateTodoTaskCommand -> Task<EResult<TodoTask>>
    abstract EditTodoItem: user: User * task: TodoTask -> Task<EResult<TodoTask>>
    abstract RemoveTodoItem: user: User * task: TodoTask -> Task<EResult<unit>>

exception TodoTaskIsAlreadyScheduled of TodoTask: TodoTask
exception TodoTaskScheduleDateAlreadyPassed of TodoTask: TodoTask

type ITodoTaskSchedulingService =
    abstract Schedule: time: ValidDateTimeOffset * task: TodoTask -> AsyncEResult<unit>
    abstract Reschedule: time: ValidDateTimeOffset * task: TodoTask -> AsyncEResult<unit>
    abstract DropScheduling: task: TodoTask -> AsyncEResult<unit>

type TodoItemSchedulingServiceEvents =
    | TodoItemScheduled of Time: ValidDateTimeOffset * TodoTask: TodoTask
    | TodoItemRescheduled of NewTime: ValidDateTimeOffset * TodoTask: TodoTask
    | TodoItemDropped of TodoTask: TodoTask

type TodoTaskNotification = {
    Time: ValidDateTimeOffset
    Item: TodoTask
}

type ITodoTaskNotificationsService =
    abstract SendNotification: notification: TodoTaskNotification -> AsyncEResult<unit>

type ILocalizable =
    abstract ToLocalString: unit -> string

type IEventBus<'a> =
    abstract member Publish: value: 'a -> ValueTask<unit>

type IEventConsumer<'a> =
    abstract member Consume: 'a -> ValueTask<unit>
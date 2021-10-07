namespace TGOrganizer.Contracts

open System.Threading.Tasks
open En3Tho.FSharp.Extensions
open En3Tho.FSharp.Validation
open En3Tho.FSharp.Validation.CommonValidatedTypes
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

type UserAlreadyExistsException() = inherit ProcessingException(nameof(UserAlreadyExistsException))
type UserDoesNotExistException() = inherit ProcessingException(nameof(UserDoesNotExistException))

type IUserStorage =
    abstract member CreateUser: command: CreateUserCommand -> Task<ExnResult<User>>
    abstract member ChangeUser: user: User -> Task<ExnResult<User>>
    abstract member GetUser: userId: NonEmptyGuid -> Task<ExnResult<User>>

type UserStorageEvent =
    | UserCreated of Time: ValidDateTimeOffset * User: User
    | UserChanged of Time: ValidDateTimeOffset * User: User

type ScheduleType =
    | RunOnce
    | RunPeriodically of Period: ValidTimeSpan

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
    abstract GetTodoItems: user: User -> AsyncExnResult<NonNullValue<array<TodoTask>>>
    abstract CreateTodoItem: user: User * command: CreateTodoTaskCommand -> AsyncExnResult<TodoTask>
    abstract EditTodoItem: user: User * task: TodoTask -> AsyncExnResult<TodoTask>
    abstract RemoveTodoItem: user: User * task: TodoTask -> AsyncExnResult<unit>

type TodoItemEditorServiceEvents =
    | TodoItemCreated of Item: TodoTask
    | TodoItemEdited of OldItem: TodoTask * NewItem: TodoTask
    | TodoItemRemoved of Item: TodoTask

type TodoTaskAlreadyExistsException(todoTask: TodoTask) =
    inherit ProcessingException(nameof(TodoTaskAlreadyExistsException))
    member _.TodoTask = todoTask

type TodoTaskDoesNotExistException(todoTask: TodoTask) =
    inherit ProcessingException(nameof(TodoTaskDoesNotExistException))
    member _.TodoTask = todoTask

type ITodoTaskStorage =
    abstract GetTodoItems: user: User -> Task<ExnResult<NonNullValue<array<TodoTask>>>>
    abstract CreateTodoItem: user: User * command: CreateTodoTaskCommand -> Task<ExnResult<TodoTask>>
    abstract EditTodoItem: user: User * task: TodoTask -> Task<ExnResult<TodoTask>>
    abstract RemoveTodoItem: user: User * task: TodoTask -> Task<ExnResult<unit>>

type TodoTaskIsAlreadyScheduledException(todoTask: TodoTask) =
    inherit ProcessingException(nameof(TodoTaskIsAlreadyScheduledException))
    member _.TodoTask = todoTask

type TodoTaskScheduleDateAlreadyPassedException(todoTask: TodoTask) =
    inherit ProcessingException(nameof(TodoTaskScheduleDateAlreadyPassedException))
    member _.TodoTask = todoTask

type ITodoTaskSchedulingService =
    abstract Schedule: time: ValidDateTimeOffset * task: TodoTask -> AsyncExnResult<unit>
    abstract Reschedule: time: ValidDateTimeOffset * task: TodoTask -> AsyncExnResult<unit>
    abstract DropScheduling: task: TodoTask -> AsyncExnResult<unit>

type TodoItemSchedulingServiceEvents =
    | TodoItemScheduled of Time: ValidDateTimeOffset * TodoTask: TodoTask
    | TodoItemRescheduled of NewTime: ValidDateTimeOffset * TodoTask: TodoTask
    | TodoItemDropped of TodoTask: TodoTask

type TodoTaskNotification = {
    Time: ValidDateTimeOffset
    Item: TodoTask
}

type ITodoTaskNotificationsService =
    abstract SendNotification: notification: TodoTaskNotification -> AsyncExnResult<unit>

type ILocalizable =
    abstract ToLocalString: unit -> string

type IEventBus =
    abstract member Publish<'a> : value: 'a -> ValueTask<unit>

type IEventBus<'a> =
    abstract member Publish: value: 'a -> ValueTask<unit>

type IEventConsumer<'a> =
    abstract member Consume: 'a -> ValueTask<unit>
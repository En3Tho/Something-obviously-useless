namespace En3Tho.FSharp.Validation

open System
open System.Runtime.CompilerServices
open System.Runtime.ExceptionServices
open En3Tho.FSharp.Extensions.Core

module EResult =
    let inline unwrap<'a, 'exn when 'exn :> Exception> (result: Result<'a, 'exn>) =
        match result with
        | Ok value -> value
        | Error err -> ExceptionDispatchInfo.Throw err; Unchecked.defaultof<_>

    let inline unwrapWithStackTrace<'a, 'exn when 'exn :> Exception> (result: Result<'a, 'exn>) =
        match result with
        | Ok value -> value
        | Error err ->
            ExceptionDispatchInfo.Throw ^
            if err.StackTrace = null then
                err |> ExceptionDispatchInfo.SetCurrentStackTrace
            else
                err :> exn
            Unchecked.defaultof<_>

    let inline defaultValue<'a, 'exn when 'exn :> Exception> defaultValue (result: Result<'a, 'exn>) =
        match result with
        | Ok value -> value
        | _ -> defaultValue

    let inline defaultWith<'a, 'exn when 'exn :> Exception> defThunk (result: Result<'a, 'exn>) =
        match result with
        | Ok value -> value
        | Error exn -> defThunk exn

    let inline trySetCurrentStackTrace<'a, 'exn when 'exn :> Exception> (result: Result<'a, 'exn>) =
        match result with
        | Error exn when String.IsNullOrEmpty exn.StackTrace ->
            exn |> ExceptionDispatchInfo.SetCurrentStackTrace :?> 'exn |> Error
        | _ -> result

[<AbstractClass; Extension>]
type EResultExtensions() =
    [<Extension>]
    static member Unwrap value =
        EResult.unwrap value

module DomainEntity =
    let map map (entity: DomainEntity10<'a,'b>) = entity.Value |> map |> DomainEntity10<'a,'b>.Try
    let mapUnwrap map (entity: DomainEntity10<'a,'b>) =
        entity.Value |> map |> DomainEntity10<'a,'b>.Try |> EResult.unwrap

[<AutoOpen>]
module DomainEntityExtensions =
    type DomainEntity10<'value, 'validator when 'validator: struct
                                            and 'validator: (new: unit -> 'validator)
                                            and 'validator :> IValidator<'value>> with
        static member Try value =
            match value with
            | ValueNone -> ValueNone |> Ok
            | ValueSome value ->
                match DomainEntity10<'value, 'validator>.Try value with
                | Ok value -> value |> ValueSome |> Ok
                | Error err -> Error err

        member this.MapTry map =
            DomainEntity.map map this

        static member Make value =
            value |> DomainEntity10<'value, 'validator>.Try |> EResult.unwrap

        member this.MapMake map =
            DomainEntity.mapUnwrap map this

[<AutoOpen>]
module ExceptionExtensions =
    type Exception with
        member this.IsOrContains<'a when 'a :> exn>() =
            match this with
            | :? 'a as result -> ValueSome result
            | :? AggregateException as exn ->
                let mutable result = ValueNone
                let enum = exn.InnerExceptions.GetEnumerator()
                while result.IsNone && enum.MoveNext() do
                    result <- enum.Current.IsOrContains<'a>()
                match result with
                | ValueSome _ -> result
                | _ -> exn.InnerException.IsOrContains<'a>()
            | _ ->
                match this.InnerException with
                | null -> ValueNone
                | exn -> exn.IsOrContains<'a>()
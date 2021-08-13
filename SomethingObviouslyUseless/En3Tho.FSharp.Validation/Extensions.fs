namespace En3Tho.FSharp.Validation

open System

module DomainEntityExtensions =
    type DomainEntity10<'value, 'validator when 'validator: struct
                                            and 'validator: (new: unit -> 'validator)
                                            and 'validator :> IValidator<'value>> with
        static member Create value =
            match value with
            | ValueNone -> ValueNone |> Ok
            | ValueSome value ->
                match DomainEntity10<'value, 'validator>.Create value with
                | Ok value -> value |> ValueSome |> Ok
                | Error err -> Error err
                
        static member DangerousCreate value =
            value |> DomainEntity10.Create |> ValidationResult.unwrap

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


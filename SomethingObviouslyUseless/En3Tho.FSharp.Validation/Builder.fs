module En3Tho.FSharp.Validation.ValidateComputationExpression

open System

[<Sealed>]
type EResultBuilder() = // TODO: ValidateAsync
    member inline this.Bind(value: EResult<'a>, next) =
        match value with
        | Ok value -> next value
        | Error exn -> Error exn
        
    member inline this.Bind2(value: EResult<'a>, value2: EResult<'b>, next) =
        match value, value2 with
        | Ok value, Ok value2 -> next (value, value2)
        | Error exn, Error exn2 -> AggregateException(exn, exn2) :> exn |> Error
        | Error exn, _
        | _, Error exn -> Error exn
        
    member inline this.Bind3(value: EResult<'a>, value2: EResult<'b>, value3: EResult<'c>, next) =
        match value, value2, value3 with
        | Ok value, Ok value2, Ok value3 -> next (value, value2, value3)
        | _ -> (seq { // TODO: ExnBuilder
            match value with Error exn -> exn | _ -> ()
            match value2 with Error exn -> exn | _ -> ()
            match value3 with Error exn -> exn | _ -> ()
            } |> AggregateException :> exn |> Error)
        
    member inline this.Bind4(value: EResult<'a>, value2: EResult<'b>, value3: EResult<'c>, value4: EResult<'d>, next) =
        match value, value2, value3, value4 with
        | Ok value, Ok value2, Ok value3, Ok value4 -> next (value, value2, value3, value4)
        | _ -> (seq {
            match value with Error exn -> exn | _ -> ()
            match value2 with Error exn -> exn | _ -> ()
            match value3 with Error exn -> exn | _ -> ()
            match value4 with Error exn -> exn | _ -> ()
            } |> AggregateException :> exn |> Error)
    
    member inline this.Bind5(value: EResult<'a>, value2: EResult<'b>, value3: EResult<'c>, value4: EResult<'d>, value5: EResult<'e>, next) =
        match value, value2, value3, value4, value5 with
        | Ok value, Ok value2, Ok value3, Ok value4, Ok value5 -> next (value, value2, value3, value4, value5)
        | _ -> (seq {
            match value with Error exn -> exn | _ -> ()
            match value2 with Error exn -> exn | _ -> ()
            match value3 with Error exn -> exn | _ -> ()
            match value4 with Error exn -> exn | _ -> ()
            match value5 with Error exn -> exn | _ -> ()
        } |> AggregateException :> exn |> Error)
    
    member inline this.Bind6(value: EResult<'a>, value2: EResult<'b>, value3: EResult<'c>, value4: EResult<'d>, value5: EResult<'e>, value6: EResult<'f>, next) =
        match value, value2, value3, value4, value5, value6 with
        | Ok value, Ok value2, Ok value3, Ok value4, Ok value5, Ok value6 -> next (value, value2, value3, value4, value5, value6)
        | _ -> (seq {
            match value with Error exn -> exn | _ -> ()
            match value2 with Error exn -> exn | _ -> ()
            match value3 with Error exn -> exn | _ -> ()
            match value4 with Error exn -> exn | _ -> ()
            match value5 with Error exn -> exn | _ -> ()
            match value6 with Error exn -> exn | _ -> ()
        } |> AggregateException :> exn |> Error)
    
    member inline this.Bind7(value: EResult<'a>, value2: EResult<'b>, value3: EResult<'c>, value4: EResult<'d>, value5: EResult<'e>, value6: EResult<'f>, value7: EResult<'g>, next) =
        match value, value2, value3, value4, value5, value6, value7 with
        | Ok value, Ok value2, Ok value3, Ok value4, Ok value5, Ok value6, Ok value7 -> next (value, value2, value3, value4, value5, value6, value7)
        | _ -> (seq {
            match value with Error exn -> exn | _ -> ()
            match value2 with Error exn -> exn | _ -> ()
            match value3 with Error exn -> exn | _ -> ()
            match value4 with Error exn -> exn | _ -> ()
            match value5 with Error exn -> exn | _ -> ()
            match value6 with Error exn -> exn | _ -> ()
            match value7 with Error exn -> exn | _ -> ()
        } |> AggregateException :> exn |> Error)

    member inline this.Return(value: 'a) : EResult<'a> = Ok value
    member inline this.Return(exn: exn) : EResult<'a> = Error exn
    member inline this.ReturnFrom(value: EResult<'a>) = value

let eresult = EResultBuilder()
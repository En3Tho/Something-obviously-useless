module En3Tho.FSharp.Validation.ValidateComputationExpression

open System

[<Sealed>]
type ValidateBuilder() = // TODO: ValidateAsync
    member inline this.Bind(value: ValidationResult<'a>, next) =
        match value with
        | Ok value -> next value
        | Error exn -> Error exn
        
    member inline this.Bind2(value: ValidationResult<'a>, value2: ValidationResult<'b>, next) =
        match value, value2 with
        | Ok value, Ok value2 -> next (value, value2)
        | Error exn, Error exn2 -> AggregateException(exn, exn2) :> exn |> Error
        | Error exn, _
        | _, Error exn -> Error exn
        
    member inline this.Bind3(value: ValidationResult<'a>, value2: ValidationResult<'b>, value3: ValidationResult<'c>, next) =
        match value, value2, value3 with
        | Ok value, Ok value2, Ok value3 -> next (value, value2, value3)
        | _ -> (seq { // TODO: ExnBuilder
            match value with Error exn -> exn | _ -> ()
            match value2 with Error exn -> exn | _ -> ()
            match value3 with Error exn -> exn | _ -> ()
            } |> AggregateException :> exn |> Error)
        
    member inline this.Bind4(value: ValidationResult<'a>, value2: ValidationResult<'b>, value3: ValidationResult<'c>, value4: ValidationResult<'d>, next) =
        match value, value2, value3, value4 with
        | Ok value, Ok value2, Ok value3, Ok value4 -> next (value, value2, value3, value4)
        | _ -> (seq {
            match value with Error exn -> exn | _ -> ()
            match value2 with Error exn -> exn | _ -> ()
            match value3 with Error exn -> exn | _ -> ()
            match value4 with Error exn -> exn | _ -> ()
            } |> AggregateException :> exn |> Error)
    
    member inline this.Bind5(value: ValidationResult<'a>, value2: ValidationResult<'b>, value3: ValidationResult<'c>, value4: ValidationResult<'d>, value5: ValidationResult<'e>, next) =
        match value, value2, value3, value4, value5 with
        | Ok value, Ok value2, Ok value3, Ok value4, Ok value5 -> next (value, value2, value3, value4, value5)
        | _ -> (seq {
            match value with Error exn -> exn | _ -> ()
            match value2 with Error exn -> exn | _ -> ()
            match value3 with Error exn -> exn | _ -> ()
            match value4 with Error exn -> exn | _ -> ()
            match value5 with Error exn -> exn | _ -> ()
        } |> AggregateException :> exn |> Error)
    
    member inline this.Bind6(value: ValidationResult<'a>, value2: ValidationResult<'b>, value3: ValidationResult<'c>, value4: ValidationResult<'d>, value5: ValidationResult<'e>, value6: ValidationResult<'f>, next) =
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
    
    member inline this.Bind7(value: ValidationResult<'a>, value2: ValidationResult<'b>, value3: ValidationResult<'c>, value4: ValidationResult<'d>, value5: ValidationResult<'e>, value6: ValidationResult<'f>, value7: ValidationResult<'g>, next) =
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

    member inline this.Return(value: 'a) : ValidationResult<'a> = Ok value
    member inline this.ReturnFrom(value: ValidationResult<'a>) = value

let validate = ValidateBuilder()

    
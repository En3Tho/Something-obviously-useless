module En3Tho.FSharpExtensions.String

open System

let getLastTwoElements (lst: 'a list) =
    match lst with
    | [] | [_] -> invalidOp "Sas"
    | _ ->
        let rec go lst =
            match lst with
            | [x; y] -> x, y
            | _ :: rest -> go rest
            | def -> go def // will never hit this
        go lst

module ActivePatterns =
    let (|OrdinalIgnoreCase|_|) str str2 = if String.Equals(str, str2, StringComparison.OrdinalIgnoreCase) then Some() else None
    let (|InvariantCulture|_|) str str2 = if String.Equals(str, str2, StringComparison.InvariantCulture) then Some() else None
    let (|InvariantCultureIgnoreCase|_|) str str2 = if String.Equals(str, str2, StringComparison.InvariantCultureIgnoreCase) then Some() else None
    let (|CurrentCultureIgnoreCase|_|) str str2 = if String.Equals(str, str2, StringComparison.CurrentCultureIgnoreCase) then Some() else None

let inline defaultValue def str = if String.IsNullOrEmpty str then def else str
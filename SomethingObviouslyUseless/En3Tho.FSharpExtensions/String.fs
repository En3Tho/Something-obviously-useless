module En3Tho.FSharpExtensions.String

open System

let getLastTwoElements (lst: 'a list) =
    let rec scrollToLast2Elements (lst: 'a list) =
        if lst.Length > 2 then scrollToLast2Elements lst.Tail else lst

    match scrollToLast2Elements lst with
    | [pre; last] -> pre, last
    | _ -> invalidOp "Sas"

module ActivePatterns =
    let (|OrdinalIgnoreCase|_|) str str2 = if String.Equals(str, str2, StringComparison.OrdinalIgnoreCase) then Some() else None
    let (|InvariantCulture|_|) str str2 = if String.Equals(str, str2, StringComparison.InvariantCulture) then Some() else None
    let (|InvariantCultureIgnoreCase|_|) str str2 = if String.Equals(str, str2, StringComparison.InvariantCultureIgnoreCase) then Some() else None
    let (|CurrentCultureIgnoreCase|_|) str str2 = if String.Equals(str, str2, StringComparison.CurrentCultureIgnoreCase) then Some() else None

let inline defaultValue def str = if String.IsNullOrEmpty str then def else str
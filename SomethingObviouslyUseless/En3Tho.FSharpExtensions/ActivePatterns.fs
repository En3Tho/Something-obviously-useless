module En3Tho.FSharpExtensions.ActivePatterns

open System

let (^) f x = f x

let Some' = Some()

let inline (|Eq|_|) with' what = if what = with' then Some' else None
let inline (|Neq|_|) with' what = if what <> with' then Some' else None
let inline (|Gt|_|) with' what = if what > with' then Some' else None
let inline (|GtEq|_|) with' what = if what >= with' then Some' else None
let inline (|Lt|_|) with' what = if what < with' then Some' else None
let inline (|LtEq|_|) with' what = if what <= with' then Some' else None

module Validation =
    let inline (|NotNull|) (obj: 'a when 'a: not struct) = if Object.ReferenceEquals(obj, null) then nullArg "Value cannot be null" else obj
    let inline (|Eq|) value obj = if obj = value then obj else invalidArg "" $"Value should be equal to {value}"
    let inline (|Neq|) value obj = if obj <> value then obj else invalidArg "" $"Value should not be equal to {value}"
    let inline (|Gt|) value obj = if obj > value then obj else invalidArg "" $"Value should be greater than {value}"
    let inline (|GtEq|) value obj = if obj >= value then obj else invalidArg "" $"Value should be greater than or equal to {value}"
    let inline (|Lt|) value obj = if obj < value then obj else invalidArg "" $"Value should be less than {value}"
    let inline (|LtEq|) value obj = if obj <= value then obj else invalidArg "" $"Value should be less than or equal to {value}"

let test = function
    | Eq 10
    | Eq 15
    | Eq 20 -> printfn "ok"
    | _ -> ()
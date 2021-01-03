module En3Tho.FSharpExtensions.ActivePatterns

let (^) f x = f x

let Some' = Some()

let inline (|Eq|_|) with' what = if what = with' then Some' else None
let inline (|Neq|_|) with' what = if what <> with' then Some' else None
let inline (|Gt|_|) with' what = if what > with' then Some' else None
let inline (|GtEq|_|) with' what = if what >= with' then Some' else None
let inline (|Lt|_|) with' what = if what < with' then Some' else None
let inline (|LtEq|_|) with' what = if what <= with' then Some' else None

let test = function
    | Eq 10
    | Eq 15
    | Eq 20 -> printfn "ok"
    | _ -> ()
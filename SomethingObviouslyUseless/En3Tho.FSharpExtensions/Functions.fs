module En3Tho.FSharpExtensions.Functions

let inline (&>>) f g = fun x -> f(); g x
let inline (|>>) f g = fun x -> f x |> ignore; g x
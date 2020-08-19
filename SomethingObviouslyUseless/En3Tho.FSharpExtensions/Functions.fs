module En3Tho.FSharpExtensions.Functions
open System

let inline (&>>) f g = fun x -> f(); g x
let inline (|>>) f g = fun x -> f x |> ignore; g x
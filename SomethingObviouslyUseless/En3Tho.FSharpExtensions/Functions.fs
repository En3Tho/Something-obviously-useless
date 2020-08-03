module En3Tho.FSharpExtensions.Functions

let inline (&>>) f g = fun x -> f(); g x
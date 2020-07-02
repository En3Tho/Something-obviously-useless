namespace En3Tho.FSharpExtensions
open System

module Object =
    let inline (===) a b = Object.ReferenceEquals(a, b)
    let inline (!==) a b = not (a === b)
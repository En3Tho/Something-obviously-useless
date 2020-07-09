namespace En3Tho.FSharpExtensions
open System.Linq

module Seq = // TODO: Seq exts
    let toResizeArray = Enumerable.ToList
    let ofType<'a> = Enumerable.OfType<'a>
    let notEmpty = Enumerable.Any
    let count = Enumerable.Count
    let inline toLookup (keySelector : 'a -> 'b) (elementSelector : 'a -> 'c) seq = Enumerable.ToLookup(seq, keySelector, elementSelector)
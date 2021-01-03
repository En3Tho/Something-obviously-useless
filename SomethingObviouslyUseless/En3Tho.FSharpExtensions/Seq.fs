namespace En3Tho.FSharpExtensions
open System
open System.Collections.Generic
open System.Linq
open En3Tho.FSharpExtensions.EqualityComparer

module Seq =
    let intersect left right = Enumerable.Intersect(left, right)
    let intersectBy<'a, 'b when 'b : equality> (map : 'a -> 'b) left right = Enumerable.Intersect(left, right, EqualityComparer<'a>.Create(map))
    let toResizeArray = Enumerable.ToList
    let ofType<'a> = Enumerable.OfType<'a>
    let notEmpty = Enumerable.Any
    let count = Enumerable.Count
    let inline toLookup (keySelector : 'a -> 'b) (elementSelector : 'a -> 'c) seq = Enumerable.ToLookup(seq, keySelector, elementSelector)
namespace En3Tho.FSharpExtensions
open System
open System.Runtime.InteropServices
open Byref.Operatos

module Span = // TODO: span exts
    let inline fromString (x : string) = x.AsSpan()
    let inline fromArray (x : 'a array) = x.AsSpan()
    let inline mapToArray f (x : 'a ReadOnlySpan) =
        let result = Array.zeroCreate x.Length        
        for i = 0 to x.Length do
            result.[i] <- f x.[i]
        result
        
    let inline mapToSpan f (x : 'b Span) (y : 'a ReadOnlySpan) =
        if x.Length < y.Length then invalidArg "length" |> ignore        
        for i = 0 to y.Length do
            x.[i] <- f y.[i]
        x
    
    let fromObject = MemoryMarshal.CreateSpan
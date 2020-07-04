namespace En3Tho.FSharpExtensions
open System
open System.Runtime.InteropServices

module Span = // TODO: span exts
    let inline fromString (x : string) = x.AsSpan()
    let inline fromArray (x : 'a array) = x.AsSpan()
    let fromObject = MemoryMarshal.CreateSpan
module Gists.FSharp.Channels

open System
open System.Threading.Channels
open System.Threading.Tasks

type Work<'a, 'b> = 'a -> ValueTask<'b>
type Container<'a, 'b> = (struct ('a * Work<'a, 'b>))

type Job<'a, 'b> =
    | Result of 'a
    | Continuation of Result: 'a * Next: Work<'a, 'b>

type Executor<'a, 'b>() =
    let channel = Channel.CreateUnbounded<Container<'a, 'b>>()
    do
        for i = 0 to Environment.ProcessorCount - 1 do
            task {
                while true do
                    let! value, job = channel.Reader.ReadAsync()
                    let! result = job value
                    ignore result
            } |> ignore
    member _.Writer = channel.Writer
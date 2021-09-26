open System.Threading.Tasks
open En3Tho.FSharp.Extensions.Core
open PoshRedisViewer
open PoshRedisViewer.Redis

[<EntryPoint>]
let main argv =

    let multiplexer =
        "localhost:6379"
        |> RedisReader.connect None None
        |> Task.RunSynchronously

    UI.runApp(multiplexer)
    0
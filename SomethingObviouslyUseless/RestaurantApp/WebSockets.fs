module RestaurantApp.WebSockets

open System.Text

open System
open System.Net.WebSockets
open System.Threading

let [<Literal>] WSUri = "ws://localhost:10001/webchat_test"

let runner = async {
    let socket = new ClientWebSocket()
    let source = new CancellationTokenSource()
    source.CancelAfter(10000)
    let token = source.Token
    let buffer = Array.zeroCreate 4096
    printf $"{socket.State}"
    printf "Connecting"
    do! socket.ConnectAsync(Uri WSUri, token) |> Async.AwaitTask
    printf "Connected"
    printf $"{socket.State}"
    printf "Sending message"
    do! socket.SendAsync(Encoding.UTF8.GetBytes("status") |> ReadOnlyMemory, WebSocketMessageType.Binary, true, token).AsTask() |> Async.AwaitTask
    printf "Sent message"

    while true do
        printf "Receiving"
        let! result = socket.ReceiveAsync(Memory buffer, token).AsTask() |> Async.AwaitTask
        printf $"%A{result}"
}
namespace PoshRedisViewerModule

open System.Management.Automation
open System.Threading.Tasks
open PoshRedisViewer
open PoshRedisViewer.Redis
open En3Tho.FSharp.Extensions

[<Cmdlet(VerbsCommon.Get, "RedisViewer")>]
type GetRedisViewerCommand() =
    inherit Cmdlet()

    [<Parameter(Position = 0, Mandatory = true)>]
    [<ValidateNotNullOrEmpty>]
    member val ConnectionString = "" with get, set

    member val User = "" with get, set
    member val Password = "" with get, set

    override this.ProcessRecord() =
        let connectionString = this.ConnectionString
        let user = this.User |> Option.ofString
        let password = this.Password |> Option.ofString

        connectionString
        |> RedisReader.connect user password
        |> Task.RunSynchronously
        |> UI.runApp
        |> UI.shutdown
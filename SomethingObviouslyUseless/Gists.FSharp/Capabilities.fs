module Gists.FSharp.Capabilities

open System
open System.Collections.Concurrent
open System.Threading.Tasks
open FSharp.Control.Tasks

type AsyncExnResult<'a> = ValueTask<Result<'a, exn>>

type ICapability =
    abstract Id: Guid

type ICapabilitySupervisor =
    abstract AddCapability: capability: ICapability -> AsyncExnResult<unit>
    abstract RemoveCapability: capability: ICapability -> AsyncExnResult<unit>
    abstract CapabilityExists: capabilityId: Guid -> AsyncExnResult<bool>

type ICapability<'a, 'b> =
    inherit ICapability
    abstract Invoke: supervisor: ICapabilitySupervisor * value: 'a -> AsyncExnResult<'b>

[<AbstractClass>]
type Capability<'a, 'b>() =
    member val Id = Guid.NewGuid()
    abstract Invoke: ICapabilitySupervisor * 'a -> AsyncExnResult<'b>
    interface ICapability<'a, 'b> with
        member this.Id = this.Id
        member this.Invoke(supervisor, value) = vtask {
            match! supervisor.CapabilityExists this.Id with
            | Ok _ -> return! this.Invoke (supervisor, value)
            | Error exn -> return Error exn
        }

type OnlyOnceCapability<'a, 'b>(capability: ICapability<'a, 'b>) =
    inherit Capability<'a, 'b>()

    override this.Invoke(supervisor, value) = vtask {
        match! supervisor.RemoveCapability this with
        | Ok _ -> return! capability.Invoke(supervisor, value)
        | Error exn -> return Error exn
    }

type FuncCapability<'a, 'b>(func: ICapabilitySupervisor * 'a -> AsyncExnResult<'b>, supervisor: ICapabilitySupervisor) =
    inherit Capability<'a, 'b>()

    override this.Invoke(supervisor, value) = func(supervisor, value)

exception CapabilityAlreadyExists
exception CapabilityDoesNotExist

type InMemoryCapabilitySupervisor() =
    let capabilities = ConcurrentDictionary()
    interface ICapabilitySupervisor with
        member this.AddCapability(capability) = vtask {
            if capabilities.TryAdd(capability.Id, capability) then
                return Ok ()
            else
                return Error CapabilityAlreadyExists
        }

        member this.CapabilityExists(capabilityId) = vtask {
            match capabilities.TryGetValue capabilityId with
            | result, _ -> return result |> Ok
        }

        member this.RemoveCapability(capability) = vtask {
            match capabilities.TryRemove capability.Id with
            | true, _ -> return Ok()
            | _ -> return Error CapabilityDoesNotExist
        }

let supervisor = InMemoryCapabilitySupervisor()
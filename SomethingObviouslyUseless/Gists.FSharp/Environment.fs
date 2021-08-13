module Gists.FSharp.Environment

type IEnv<'a> =
    abstract member Value: 'a

module GenericDeps =

    type Environment(dep, dep2) =
        interface IEnv<string> with member this.Value = dep
        interface IEnv<int> with member this.Value = dep2

    let consumeStringEnv (env: #IEnv<string>) value = env.Value |> ignore
    let consumeIntEnv (env: #IEnv<int>) value = env.Value |> ignore
    
    let consumeEnv<'a, 'b when 'a :> IEnv<'b>> (env: 'a) = env.Value
    
    let consumeBothEnvs env =
        consumeStringEnv env ()
        consumeIntEnv env () // The type 'ISomeDep2' does not match the type 'ISomeDep'. Why?
    
    let consumeBothEnvs2 env =
        consumeEnv<_, string> env |> ignore
        consumeEnv<_, int> env |> ignore // type int does not match the type string
    
    Environment("", 0) |> consumeBothEnvs

module NonGenericDeps =

    type IStringEnv = abstract member Value: string

    type IIntEnv = abstract member Value: int

    type Environment(dep, dep2) =
        interface IStringEnv with member this.Value = dep
        interface IIntEnv with member this.Value = dep2

    let consumeStringEnv (env: #IStringEnv) value = env.Value |> ignore
    let consumeIntEnv (env: #IIntEnv) value = env.Value |> ignore
    
    let consumeBothEnvs env = // works ok
        consumeStringEnv env ()
        consumeIntEnv env ()

    Environment("", 0) |> consumeBothEnvs


module DoesntWork =
    type Why<'a when 'a :> IEnv<string> and 'a :> IEnv<int>>(value: 'a) = // Type constraint mismatch. The type ''a' is not compatible with type 'IEnv<int>'
        member _.Value = value
module Benchmarks.FSharp.ComponentBagBenchmark

open System
open System.Collections.Generic
open BenchmarkDotNet.Attributes
open BenchmarkDotNet.Jobs

let inline (^) f x = f x
let inline (|>>) f g = fun x -> f x |> ignore; g x

module Object =
    let inline createNew<'a when 'a: (new : unit -> 'a)> = new 'a()

module Dictionary =
    let inline tryGetValue key (dict: Dictionary<'a, 'b>) =
        match dict.TryGetValue key with
        | true, value -> Some value
        | _ -> None

type ComponentDataProviderNode = ValueTuple<Type, obj>

[<AbstractClass>]
type private ComponentValueDictionary<'TType, 'TKey, 'TValue when 'TKey: equality>() =
    [<DefaultValue>]
    static  val mutable private _KeyValueBag: Dictionary<'TKey, 'TValue>
    static do ComponentValueDictionary<'TType, 'TKey, 'TValue>._KeyValueBag <- Dictionary()
    static member KeyValueBag = ComponentValueDictionary<'TType, 'TKey, 'TValue>._KeyValueBag
    static member val KeyValueBag2 = Dictionary<'TKey, 'TValue>() with get

type ComponentDataProvider() =
    // inmemory/session/local ?

    // inmemory means it won't be put into browser storage and shared between pages
    // session means it will be shared between pages through browser session storage, will be cleared
    // local means it will be shared between pages through browser local storage, won't be cleared

    let dict = Dictionary<obj, LinkedList<ComponentDataProviderNode>>()

    let getComponentDataList obj =
        dict
        |> Dictionary.tryGetValue obj
        |> Option.defaultWith ^ fun () ->
            let list = LinkedList()
            dict.[obj] <- list
            list

    member _.AddData<'a> (list: LinkedList<ComponentDataProviderNode>) (data: 'a) =
        struct (typeof<'a>, data :> obj) |> (LinkedListNode >> list.AddLast |>> id)

    member this.GetData<'a> obj : 'a = // or pass ctor/func as param?
        let list = getComponentDataList obj
        list
        |> Seq.tryFind ^ fun struct (localType, _) -> localType = typeof<'a>
        |> Option.defaultWith ^ fun() -> Object.createNew<'a> |> this.AddData list
        |> fun struct (_, counterData) -> counterData :?> 'a

    member this.GetData2<'TType, 'TKey, 'TValue> key =
        let bag = ComponentValueDictionary<'TType, 'TKey, 'TValue>.KeyValueBag
        match bag |> Dictionary.tryGetValue key with
        | Some value ->
            value
        | None ->
            let value = Object.createNew<'TValue>
            bag.[key] <- value
            value

    member this.GetData4<'TType, 'TKey, 'TValue> key =
        let bag = ComponentValueDictionary<'TType, 'TKey, 'TValue>.KeyValueBag
        match bag.TryGetValue key with
        | true, value ->
            value
        | _ ->
            let value = Object.createNew<'TValue>
            bag.[key] <- value
            value

    member this.GetData3<'TType, 'TKey, 'TValue> (obj: 'TType) (getKey: Func<'TType,'TKey>) =
        let key = getKey.Invoke obj
        match ComponentValueDictionary<'TType, 'TKey, 'TValue>.KeyValueBag |> Dictionary.tryGetValue key with
        | Some value -> value
        | None ->
            let value = Object.createNew<'TValue>
            ComponentValueDictionary<'TType, 'TKey, 'TValue>.KeyValueBag.[key] <- value
            value
    member this.GetData22<'TType, 'TKey, 'TValue> key =
        let bag = ComponentValueDictionary<'TType, 'TKey, 'TValue>.KeyValueBag2
        match bag |> Dictionary.tryGetValue key with
        | Some value ->
            value
        | None ->
            let value = Object.createNew<'TValue>
            bag.[key] <- value
            value

    member this.GetData42<'TType, 'TKey, 'TValue> key =
        let bag = ComponentValueDictionary<'TType, 'TKey, 'TValue>.KeyValueBag2
        match bag.TryGetValue key with
        | true, value ->
            value
        | _ ->
            let value = Object.createNew<'TValue>
            bag.[key] <- value
            value

    member this.GetData32<'TType, 'TKey, 'TValue> (obj: 'TType) (getKey: Func<'TType,'TKey>) =
        let bag = ComponentValueDictionary<'TType, 'TKey, 'TValue>.KeyValueBag2
        let key = getKey.Invoke obj
        match bag |> Dictionary.tryGetValue key with
        | Some value -> value
        | None ->
            let value = Object.createNew<'TValue>
            bag.[key] <- value
            value

type ComponentData() =
    member val Val = 0 with get, set

[<MemoryDiagnoser>]
[<SimpleJob(RuntimeMoniker.Net50)>]
type ValueBag() =
    let componentData = ComponentData(Val = 10)
    let provider = ComponentDataProvider()
    let func = Func<_,_>(fun (c: ComponentData) -> c.Val)

    [<Benchmark>]
    member _.GetData1() =
        let a: ComponentData = provider.GetData(struct (typeof<ComponentData>, componentData.Val))
        ignore a

    [<Benchmark>]
    member _.GetData2() =
        let a: ComponentData = provider.GetData2<ComponentData, int, ComponentData>(componentData.Val)
        ignore a

    [<Benchmark>]
    member _.GetData3() =
        let a: ComponentData = provider.GetData3 componentData func
        ignore a

    [<Benchmark>]
    member _.GetData4() =
        let a: ComponentData = provider.GetData4<ComponentData, int, ComponentData>(componentData.Val)
        ignore a

    [<Benchmark>]
    member _.GetData22() =
        let a: ComponentData = provider.GetData22<ComponentData, int, ComponentData>(componentData.Val)
        ignore a

    [<Benchmark>]
    member _.GetData32() =
        let a: ComponentData = provider.GetData32 componentData func
        ignore a

    [<Benchmark>]
    member _.GetData42() =
        let a: ComponentData = provider.GetData42<ComponentData, int, ComponentData>(componentData.Val)
        ignore a
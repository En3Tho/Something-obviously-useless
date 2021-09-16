module Gists.FSharp.Lua

open System
open System.Collections.Generic
open System.Text
open Gists.FSharp.ComputationExpressions

type LuaString = LuaString
type LuaNumber = LuaNumber
type LuaBool = LuaBool
type LuaFunction<'a, 'b> = | LuaFunction
type LuaNil = LuaNil

[<RequireQualifiedAccess>]
type Const =
    | String of string
    | Number of float
    | NewTable

type LuaOperation =
    | Concat
    | SetVariable
    | ReadVariable
    | ReadTable
    | SetTable
    | NullCheck
    | EmptyCheck
    | NullOrEmptyCheck

[<AbstractClass>]
type LuaValue2() =
    member this.IsNil() = LuaOperation.NullCheck

type LuaString2() = inherit LuaValue2()
type LuaBool2() = inherit LuaValue2()
type LuaNumber2() = inherit LuaValue2()
type LuaFunction2<'a, 'b when 'a :> LuaValue2 and 'b :> LuaValue2>() = inherit LuaValue2()
type LuaFunction2<'a, 'b, 'c when 'a :> LuaValue2 and 'b :> LuaValue2 and 'c :> LuaValue2>() = inherit LuaValue2()
type LuaFunction2<'a, 'b, 'c, 'd when 'a :> LuaValue2 and 'b :> LuaValue2 and 'c :> LuaValue2 and 'd :> LuaValue2>() = inherit LuaValue2()

type LuaTableKey =
    | StringKey of LuaString
    | NumberKey of LuaNumber
    | BoolKey of LuaBool

type LuaValue =
    | StringValue of LuaString
    | NumberValue of LuaNumber
    | BoolValue of LuaBool
    | NilValue of LuaNil
    | TableValue of LuaValue

module Lua =
    let concat ([<ParamArray>] values: LuaValue) = LuaString

module Redis =
    type RedisHashSet = RedisHashSet
    type RedisList = RedisList

type LuaLocal<'a when 'a :> LuaValue2>(name: string, value: 'a) =
    member this.Name = name
    member this.Value = value

type LuaParam<'a when 'a :> LuaValue2>(name: string, value: 'a) =
    member this.Name = name
    member this.Value = value

type LuaBuilder() =
    let sb = StringBuilder()

    let parameters = HashSet()

    member this.Bind<'a>(param: LuaParam<'a>) = ()
    member this.Bind<'a>(param: LuaLocal<'a>) = ()


    member this.Bind(luaString: LuaString) = ()


//lua {
//    let! param1 = LuaParam(LuaString "")
//    lif Lua.isNull param1; lthen
//    do! Lua.If (Lua.IsNull (param1), Then, (), Else ())
//    let! local1 = LuaLocal (LuaString "abc")
//    let! local2 = LuaLocal (LuaString "bcd")
//
//    variable z = Lua.concat(x, y)
//    do! Lua.set z y
//}

//lua {
//    param p1 = LuaString ""
//
//    local l1 = LuaString "abc"
//    local l2 = LuaString "bcd"
//
//    variable z = Lua.concat(x, y)
//    do! Lua.set z y
//}
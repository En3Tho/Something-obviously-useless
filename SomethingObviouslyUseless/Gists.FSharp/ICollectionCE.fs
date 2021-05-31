namespace Gists.FSharp.ComputationExpressions

open System.Collections.Generic

module ICollectionCE =
    type ICollection<'a> with
        member inline this.Yield (value: 'a) = this.Add value // to AnyAdd?
        member inline this.While (moveNext, cexpr) = while moveNext() do cexpr()
        member inline this.For (values, cexpr) = for value in values do cexpr value
        member inline this.Combine (addResult, cexpr) = cexpr()
        member inline this.Zero() = () // matches .Add signature
        member inline this.Delay beforeAdd = beforeAdd
        member inline this.Run cexpr = cexpr(); this

module LuaCE =
    type LuaTypes =
        | LuaNil // special ?
        | LuaBoolean of string
        | LuaNumber of string
        | LuaString of string
        | LuaFunction of string
        | LuaUserdata of string
        | LuaThread of string
        | LuaTable of string

    // CE should return LuaFunction or result?
    // param s = LuaString("s")
    // local i = LuaNumber("i")

module Test =
    open ICollectionCE
    let test1234 =
        let list = List()
        list {
            let mutable x = 10
            while x > 0 do
                yield x
                x <- x - 1
            yield 1
            yield 2
            yield 3
            yield 4
        }
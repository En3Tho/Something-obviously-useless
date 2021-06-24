namespace Gists.FSharp.ComputationExpressions

open System.Collections.Generic
open System.Text

module StringBuilderCE =
    type StringBuilder with
        member inline this.Yield (value: string) = this.Append value |> ignore
        member inline this.YieldFrom (value: string) = this.AppendLine value |> ignore
        member inline this.While (moveNext, cexpr) = while moveNext() do cexpr()
        member inline this.For (values, cexpr) = for value in values do cexpr value
        member inline this.Combine (appendResult, cexpr) = cexpr()
        member inline this.Zero() = () // matches .Append |> ignore signature
        member inline this.Delay beforeAdd = beforeAdd
        member inline this.Run cexpr = cexpr(); this

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
    open StringBuilderCE
    let test1234 =
        let list = List() {
            let mutable x = 10
            while x > 0 do
                yield x
                x <- x - 1
            yield 1
            yield 2
            yield 3
            yield 4
        }
        list

    let test12345 =
        let sb = StringBuilder()
        sb {
            match 10 with
            | 10 -> "2"
            | _ -> ()
            if true then "1"
            "2"
            "3"
            if 1 = 1 then
                "2"
                "3"
                "4"
            else
                "5"
                "6"
                "7"
        }
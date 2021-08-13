namespace En3Tho.FSharp.Extensions.ComputationExpressions

open System
open System.Collections.Generic
open System.Text

type RunExpression = unit -> unit
type WhileExpression = unit -> unit
type ForExpression<'a> = 'a -> unit

module StringBuilderExtensionBuilder =
    type StringBuilder with
        member inline this.Yield (value: string) = this.Append value |> ignore        
        member inline this.While (moveNext, whileExpr: WhileExpression) = while moveNext() do whileExpr()
        member inline this.For (values, forExpr: ForExpression<_>) = for value in values do forExpr value
        member inline this.Combine (appendResult, cexpr) = cexpr()
        member inline this.Zero() = () // matches .Append |> ignore signature
        member inline this.Delay beforeAdd = beforeAdd
        member inline this.Run (runExpr: RunExpression) = runExpr(); this

module ThreadLocalCachedStringBuilder =
    type StringBuilderCache() =
        static let [<Literal>] BuilderMaxSize = 360
        
        [<ThreadStatic; DefaultValue(false)>]
        static val mutable private builder: StringBuilder
        
        static member Acquire() = // TODO: safe builder
            match StringBuilderCache.builder with
            | null as builder
            | builder when builder.Capacity > BuilderMaxSize ->
                let builder = StringBuilder(BuilderMaxSize)
                StringBuilderCache.builder <- builder
                builder
            | builder ->
                builder.Clear()
    
    type [<Struct; NoEquality; NoComparison>] ThreadLocalCachedStringBuilder<'a>(builder: StringBuilder) =
        member this.Builder = builder
        member inline this.Yield (value: string) = this.Builder.Append value |> ignore
        member inline this.While (moveNext, whileExpr: WhileExpression) = while moveNext() do whileExpr()
        member inline this.For (values, forExpr: ForExpression<_>) = for value in values do forExpr value
        member inline this.Combine (appendResult, cexpr) = cexpr()
        member inline this.Zero() = () // matches .Append |> ignore signature
        member inline this.Delay beforeAdd = beforeAdd
        member inline this.Run (runExpr: RunExpression) =
            runExpr()
            this.Builder.ToString()
            
    let stringBuilder<'a> = ThreadLocalCachedStringBuilder<'a>(StringBuilderCache.Acquire())
    
module ICollectionCE =
    type ICollection<'a> with
        member inline this.Yield (value: 'a) = this.Add value // to AnyAdd?
        member inline this.YieldFrom (values: 'a seq) = for value in values do this.Add value
        member inline this.While (moveNext, whileExpr: WhileExpression) = while moveNext() do whileExpr()
        member inline this.For (values, forExpr: ForExpression<_>) = for value in values do forExpr value
        member inline this.Combine (addResult, cexpr) = cexpr()
        member inline this.Zero() = () // matches .Add signature
        member inline this.Delay beforeAdd = beforeAdd
        member inline this.Run (runExpr: RunExpression) = runExpr(); this




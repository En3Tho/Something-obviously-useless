namespace En3Tho.FSharpExtensions.ComputationExpressions

open System.Collections.Generic
open System.Text

type RunExpression = unit -> unit
type WhileExpression = unit -> unit
type ForExpression<'a> = 'a -> unit

module StringBuilderCE =
    type StringBuilder with
        member inline this.Yield (value: string) = this.Append value |> ignore
        member inline this.YieldFrom (value: string) = this.AppendLine value |> ignore
        member inline this.While (moveNext, whileExpr: WhileExpression) = while moveNext() do whileExpr()
        member inline this.For (values, forExpr: ForExpression<_>) = for value in values do forExpr value
        member inline this.Combine (appendResult, cexpr) = cexpr()
        member inline this.Zero() = () // matches .Append |> ignore signature
        member inline this.Delay beforeAdd = beforeAdd
        member inline this.Run (runExpr: RunExpression) = runExpr(); this

module ICollectionCE =
    type ICollection<'a> with
        member inline this.Yield (value: 'a) = this.Add value // to AnyAdd?
        member inline this.While (moveNext, whileExpr: WhileExpression) = while moveNext() do whileExpr()
        member inline this.For (values, forExpr: ForExpression<_>) = for value in values do forExpr value
        member inline this.Combine (addResult, cexpr) = cexpr()
        member inline this.Zero() = () // matches .Add signature
        member inline this.Delay beforeAdd = beforeAdd
        member inline this.Run (runExpr: RunExpression) = runExpr(); this
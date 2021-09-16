module En3Tho.FSharp.ComputationExpressions.ThreadLocalCacheBasedBuilders

open System
open System.Collections.Immutable
open En3Tho.FSharp.Extensions.Byref.Operators

type [<Struct>] ArenaItem<'a> = Value of 'a
type SimpleNonThreadSafeArena<'a>(capacity, ctor) =
    let items = Array.zeroCreate<ArenaItem<'a>> capacity
    let mutable index = 0
    member _.Rent() =
        if uint index >= uint items.Length then
            ctor()
        else
            let value = &items.[index]
            if Object.ReferenceEquals(value, null) then
                value <- ctor()
            &index +<- 1
            value

    member _.Clear() =
        index <- 0

type ImmutableArrayBuilder<'a> = System.Collections.Immutable.ImmutableArray.Builder<'a>
[<AbstractClass>]
type ImmutableArrayBuilderCache<'a>() =
    
    static let [<Literal>] BuilderMaxSize = 360
    
    [<ThreadStatic; DefaultValue(false)>]
    static val mutable private builder: ImmutableArrayBuilder<'a>
    
    [<ThreadStatic; DefaultValue(false)>]
    static val mutable private depth: int
    
    static member Acquire() =
        let builder = ImmutableArrayBuilderCache<'a>.builder
        if Object.ReferenceEquals(builder, null)
            || builder.Capacity > BuilderMaxSize then
            let builder = ImmutableArray.CreateBuilder(BuilderMaxSize)
            ImmutableArrayBuilderCache<'a>.builder <- builder
            builder
        else
            builder.Count <- 0
            builder
type [<NoEquality; NoComparison; Struct>] BlockBuilder<'a>(builder: ImmutableArrayBuilder<'a>) =
    member this.Builder = builder
    member inline this.Yield (value: 'a) =
        this.Builder.Add value
    member inline this.YieldFrom (values: 'a seq) =
        for value in values do this.Builder.Add value
        
    member inline this.While (moveNext, whileExpr) =
        while moveNext() do whileExpr()

    member inline this.For (values: 'b seq, forExpr) =
        for value in values do forExpr value
        
    member inline this.Combine (_, cexpr) = cexpr()
    
    member inline this.Zero() = () // matches .Add signature
    member inline this.Delay beforeAdd = beforeAdd        

    member inline this.Run runExpr =
        runExpr()
        this.Builder.ToImmutableArray()
        
type System.Collections.Immutable.ImmutableArray.Builder<'a> with
    member this.ToResizeArray() =
        let count = this.Count
        let lst = ResizeArray(count)
        for i = 0 to count - 1 do                
            lst.Add this.[i]
        lst

type [<NoEquality; NoComparison; Struct>] ResizeArrayBuilder<'a>(builder: ImmutableArrayBuilder<'a>) =
    member this.Builder = builder
    member inline this.Yield (value: 'a) =
        this.Builder.Add value
    member inline this.YieldFrom (values: 'a seq) =
        for value in values do this.Builder.Add value
        
    member inline this.While (moveNext, whileExpr) =
        while moveNext() do whileExpr()

    member inline this.For (values: 'b seq, forExpr) =
        for value in values do forExpr value
        
    member inline this.Combine (_, cexpr) = cexpr()
    
    member inline this.Zero() = () // matches .Add signature
    member inline this.Delay beforeAdd = beforeAdd        

    member inline this.Run runExpr =
        runExpr()
        this.Builder.ToResizeArray()
        
type [<NoEquality; NoComparison; Struct>] ArrayBuilder<'a>(builder: ImmutableArrayBuilder<'a>) =
    member this.Builder = builder
    member inline this.Yield (value: 'a) =
        this.Builder.Add value
    member inline this.YieldFrom (values: 'a seq) =
        for value in values do this.Builder.Add value
        
    member inline this.While (moveNext, whileExpr) =
        while moveNext() do whileExpr()

    member inline this.For (values: 'b seq, forExpr) =
        for value in values do forExpr value
        
    member inline this.Combine (_, cexpr) = cexpr()
    
    member inline this.Zero() = () // matches .Add signature
    member inline this.Delay beforeAdd = beforeAdd        

    member inline this.Run runExpr =
        runExpr()
        this.Builder.ToArray()
       
let rsz<'a> = ResizeArrayBuilder<'a>(ImmutableArrayBuilderCache<'a>.Acquire())
    
let block<'a> = BlockBuilder<'a>(ImmutableArrayBuilderCache<'a>.Acquire())
    
let arr<'a> = ArrayBuilder<'a>(ImmutableArrayBuilderCache<'a>.Acquire())    
 

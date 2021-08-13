module En3Tho.FSharp.ComputationExpressions.ArrayPoolBasedBuilders

open System
open System.Buffers
open System.Collections.Immutable
open En3Tho.FSharp.Extensions.Core
open En3Tho.FSharp.Extensions.Byref.Operators

module ArrayPoolList =
    type ArrayPool<'a> with
        member this.ReRent (array: 'a[] byref, newLength) =
            let newArray = this.Rent newLength
            Array.Copy(array, newArray, array.Length)
            this.Return array
            array <- newArray
    
    let [<Literal>] private InitialSize = 256
    let [<Literal>] private GrowMultiplier = 2
    type [<NoComparison;NoEquality>] ArrayPoolList<'a>() =
        let mutable array = ArrayPool.Shared.Rent InitialSize
        let mutable count = 0
        member inline private this.UnsafeAdd value =
            array.[count] <- value
            &count +<- 1
        
        member private this.EnsureArray() =
            if count = array.Length then              
                ArrayPool.Shared.ReRent(&array, array.Length * 2)
        
        member this.Count = count
        
        member this.Add value =
            this.EnsureArray()
            this.UnsafeAdd value
        
        member this.Dispose() =
            if not ^ Object.ReferenceEquals(array, null) then
                ArrayPool.Shared.Return array
        
        member this.CopyTo(memory: 'a Span) =
            Memory(array, 0, count).Span.CopyTo(memory)
        
        member this.GetArray() = if Object.ReferenceEquals(array, null) then [||] else array
        
        interface IDisposable with
            member this.Dispose() = this.Dispose()
    
    
open ArrayPoolList
    
type ArrayPoolList<'a> with
    member this.ToImmutableArray() =
        ImmutableArray.Create(this.GetArray(), 0, this.Count)
    
type [<NoEquality; NoComparison; Struct>] BlockBuilder<'a>(builder: ArrayPoolList<'a>) =
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
        try
            runExpr()
            this.Builder.ToImmutableArray()
        finally
            this.Builder.Dispose()
            
type ArrayPoolList<'a> with
    member this.ToResizeArray() =
        let count = this.Count
        if count = 0 then ResizeArray()
        else
        let array = this.GetArray()
        let lst = ResizeArray(count)
        let last = array.[count - 1] // check if it actually helps
        for i = 0 to count - 2 do                
            lst.Add array.[i]
        lst.Add last
        lst

type [<NoEquality; NoComparison; Struct>] ResizeArrayBuilder<'a>(builder: ArrayPoolList<'a>) =
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
        try
            runExpr()
            this.Builder.ToResizeArray()
        finally
            this.Builder.Dispose()
    
type ArrayPoolList<'a> with
    member this.ToArray() =
        match this.GetArray() with
        | [||] as result -> result
        | source ->
            let count = this.Count
            let result = Array.zeroCreate count
            Array.Copy(source, result, count)
            result
            
type [<NoEquality; NoComparison; Struct>] ArrayBuilder<'a>(builder: ArrayPoolList<'a>) =
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
        try
            runExpr()
            this.Builder.ToArray()
        finally
            this.Builder.Dispose()
           
let rsz<'a> = ResizeArrayBuilder<'a>(new ArrayPoolList<'a>())
        
let block<'a> = BlockBuilder<'a>(new ArrayPoolList<'a>())
    
let arr<'a> = ArrayBuilder<'a>(new ArrayPoolList<'a>())
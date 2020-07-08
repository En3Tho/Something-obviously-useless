module En3Tho.ILEqualityComparer.Tests.DefaultBehaviourTests.SimpleTypesTests

open En3Tho.ILEqualityComparer
open Xunit

type SimpleTypesClass =
    val IntField : int
    val CharField : char
    val BoolField : bool
    val LongField : int64
    new(intVal, charVal, boolVal, longVal) = { IntField = intVal; CharField = charVal; BoolField = boolVal; LongField = longVal}

let SimpleTypesClass1() = SimpleTypesClass(10, '0', false, 10L)
let SimpleTypesClass2() = SimpleTypesClass(10, '0', true, 10L)

[<Fact>]
let ``Similar SimpleTypesClass objects should be structurally equal``() =
    let comparer = ILEqualityComparer<SimpleTypesClass>.Default
    let obj1 = SimpleTypesClass1()
    let obj2 = SimpleTypesClass1()
    comparer.Equals(obj1, obj2) |> Assert.True

[<Fact>]
let ``Similar SimpleTypesClass objects should produce same hashcode``() =
    let comparer = ILEqualityComparer<SimpleTypesClass>.Default
    let obj1 = SimpleTypesClass1()
    let obj2 = SimpleTypesClass1()
    comparer.GetHashCode obj1 = comparer.GetHashCode obj2 |> Assert.True
    
[<Fact>]
let ``Different SimpleTypesClass objects should not be structurally equal``() =
    let comparer = ILEqualityComparer<SimpleTypesClass>.Default
    let obj1 = SimpleTypesClass1()
    let obj2 = SimpleTypesClass2()
    comparer.Equals(obj1, obj2) |> Assert.False

[<Fact>]
let ``Different SimpleTypesClass objects should not produce same hashcode``() =
    let comparer = ILEqualityComparer<SimpleTypesClass>.Default
    let obj1 = SimpleTypesClass1()
    let obj2 = SimpleTypesClass2()
    comparer.GetHashCode obj1 = comparer.GetHashCode obj2 |> Assert.False
    
[<Struct>]
[<NoEquality>]
[<NoComparison>]
type SimpleTypesStruct =
    val IntField : int
    val CharField : char
    val BoolField : bool
    val LongField : int64
    new(intVal, charVal, boolVal, longVal) = { IntField = intVal; CharField = charVal; BoolField = boolVal; LongField = longVal}

let SimpleTypesStruct1() = SimpleTypesStruct(10, '0', false, 10L)
let SimpleTypesStruct2() = SimpleTypesStruct(10, '0', true, 10L)

[<Fact>]
let ``Similar SimpleTypesStruct objects should be structurally equal``() =
    let comparer = ILEqualityComparer<SimpleTypesStruct>.Default
    let obj1 = SimpleTypesStruct1()
    let obj2 = SimpleTypesStruct1()
    comparer.Equals(obj1, obj2) |> Assert.True

[<Fact>]    
let ``Similar SimpleTypesStruct objects should produce same hashcode``() =
    let comparer = ILEqualityComparer<SimpleTypesStruct>.Default
    let obj1 = SimpleTypesStruct1()
    let obj2 = SimpleTypesStruct1()
    comparer.GetHashCode obj1 = comparer.GetHashCode obj2 |> Assert.True
    
[<Fact>]
let ``Different SimpleTypesStruct objects should not be structurally equal``() =
    let comparer = ILEqualityComparer<SimpleTypesStruct>.Default
    let obj1 = SimpleTypesStruct1()
    let obj2 = SimpleTypesStruct2()
    comparer.Equals(obj1, obj2) |> Assert.False

[<Fact>]    
let ``Different SimpleTypesStruct objects should not produce same hashcode``() =
    let comparer = ILEqualityComparer<SimpleTypesStruct>.Default
    let obj1 = SimpleTypesStruct1()
    let obj2 = SimpleTypesStruct2()
    comparer.GetHashCode obj1 = comparer.GetHashCode obj2 |> Assert.False
module En3Tho.ILEqualityComparer.Tests.DefaultBehaviourTests.NestedMembersWithSimpleTypesTests

open En3Tho.ILEqualityComparer
open Xunit

[<AllowNullLiteral>]
type SimpleTypesClass =
    val IntField : int
    val CharField : char
    val BoolField : bool
    val LongField : int64
    new(intVal, charVal, boolVal, longVal) = { IntField = intVal; CharField = charVal; BoolField = boolVal; LongField = longVal}

let SimpleTypesClass1() = SimpleTypesClass(10, '0', false, 10L)
let SimpleTypesClass2() = SimpleTypesClass(10, '0', true, 10L)

type NestedMembersSimpleTypesClass =
    val SimpleTypesClassField : SimpleTypesClass
    val IntField : int
    val CharField : char
    val BoolField : bool
    val LongField : int64
    new(intVal, charVal, boolVal, longVal, stcVal) = { IntField = intVal; CharField = charVal; BoolField = boolVal; LongField = longVal; SimpleTypesClassField = stcVal }

let NestedMembersSimpleTypesClass1() = NestedMembersSimpleTypesClass(10, '0', false, 10L, SimpleTypesClass1())
let NestedMembersSimpleTypesClass2() = NestedMembersSimpleTypesClass(10, '0', false, 10L, SimpleTypesClass2())

[<Fact>]
let ``Similar NestedMembersSimpleTypesClass objects should be structurally equal``() =
    let comparer = ILEqualityComparer<NestedMembersSimpleTypesClass>.Default
    let obj1 = NestedMembersSimpleTypesClass1()
    let obj2 = NestedMembersSimpleTypesClass1()
    comparer.Equals(obj1, obj2) |> Assert.True

[<Fact>]
let ``Similar NestedMembersSimpleTypesClass objects should produce same hashcode``() =
    let comparer = ILEqualityComparer<NestedMembersSimpleTypesClass>.Default
    let obj1 = NestedMembersSimpleTypesClass1()
    let obj2 = NestedMembersSimpleTypesClass1()
    comparer.GetHashCode obj1 = comparer.GetHashCode obj2 |> Assert.True
    
[<Fact>]
let ``Different NestedMembersSimpleTypesClass objects should not be structurally equal``() =
    let comparer = ILEqualityComparer<NestedMembersSimpleTypesClass>.Default
    let obj1 = NestedMembersSimpleTypesClass1()
    let obj2 = NestedMembersSimpleTypesClass2()
    comparer.Equals(obj1, obj2) |> Assert.False

[<Fact>]
let ``Different NestedMembersSimpleTypesClass objects should not produce same hashcode``() =
    let comparer = ILEqualityComparer<NestedMembersSimpleTypesClass>.Default
    let obj1 = NestedMembersSimpleTypesClass1()
    let obj2 = NestedMembersSimpleTypesClass2()
    comparer.GetHashCode obj1 = comparer.GetHashCode obj2 |> Assert.False
    
type Nested2MembersSimpleTypesClass =
    val NestedMembersSimpleTypesClassField : NestedMembersSimpleTypesClass
    val IntField : int
    val CharField : char
    val BoolField : bool
    val LongField : int64
    new(intVal, charVal, boolVal, longVal, nmstcVal) = { IntField = intVal; CharField = charVal; BoolField = boolVal; LongField = longVal; NestedMembersSimpleTypesClassField = nmstcVal }
    
let Nested2MembersSimpleTypesClass1() = Nested2MembersSimpleTypesClass(10, '0', false, 10L, NestedMembersSimpleTypesClass1())
let Nested2MembersSimpleTypesClass2() = Nested2MembersSimpleTypesClass(10, '0', false, 10L, NestedMembersSimpleTypesClass2())

[<Fact>]
let ``Similar Nested2MembersSimpleTypesClass objects should be structurally equal``() =
    let comparer = ILEqualityComparer<Nested2MembersSimpleTypesClass>.Default
    let obj1 = Nested2MembersSimpleTypesClass1()
    let obj2 = Nested2MembersSimpleTypesClass1()
    comparer.Equals(obj1, obj2) |> Assert.True

[<Fact>]
let ``Similar Nested2MembersSimpleTypesClass objects should produce same hashcode``() =
    let comparer = ILEqualityComparer<Nested2MembersSimpleTypesClass>.Default
    let obj1 = Nested2MembersSimpleTypesClass1()
    let obj2 = Nested2MembersSimpleTypesClass1()
    comparer.GetHashCode obj1 = comparer.GetHashCode obj2 |> Assert.True
    
[<Fact>]
let ``Different Nested2MembersSimpleTypesClass objects should not be structurally equal``() =
    let comparer = ILEqualityComparer<Nested2MembersSimpleTypesClass>.Default
    let obj1 = Nested2MembersSimpleTypesClass1()
    let obj2 = Nested2MembersSimpleTypesClass2()
    comparer.Equals(obj1, obj2) |> Assert.False

[<Fact>]
let ``Different Nested2MembersSimpleTypesClass objects should not produce same hashcode``() =
    let comparer = ILEqualityComparer<Nested2MembersSimpleTypesClass>.Default
    let obj1 = Nested2MembersSimpleTypesClass1()
    let obj2 = Nested2MembersSimpleTypesClass2()
    comparer.GetHashCode obj1 = comparer.GetHashCode obj2 |> Assert.False
    
// -- null -- //

let NestedMembersSimpleTypesClass3() = NestedMembersSimpleTypesClass(10, '0', false, 10L, null)
let Nested2MembersSimpleTypesClass3() = Nested2MembersSimpleTypesClass(10, '0', false, 10L, NestedMembersSimpleTypesClass3())
    
[<Fact>]
let ``Similar Nested2MembersSimpleTypesClass objects with nulls should be structurally equal``() =
    let comparer = ILEqualityComparer<Nested2MembersSimpleTypesClass>.Default
    let obj1 = Nested2MembersSimpleTypesClass3()
    let obj2 = Nested2MembersSimpleTypesClass3()
    comparer.Equals(obj1, obj2) |> Assert.True

[<Fact>]
let ``Similar Nested2MembersSimpleTypesClass objects with nulls should produce same hashcode``() =
    let comparer = ILEqualityComparer<Nested2MembersSimpleTypesClass>.Default
    let obj1 = Nested2MembersSimpleTypesClass3()
    let obj2 = Nested2MembersSimpleTypesClass3()
    comparer.GetHashCode obj1 = comparer.GetHashCode obj2 |> Assert.True
    
[<Fact>]
let ``Different Nested2MembersSimpleTypesClass objects with nulls should not be structurally equal``() =
    let comparer = ILEqualityComparer<Nested2MembersSimpleTypesClass>.Default
    let obj1 = Nested2MembersSimpleTypesClass1()
    let obj2 = Nested2MembersSimpleTypesClass3()
    comparer.Equals(obj1, obj2) |> Assert.False

[<Fact>]
let ``Different Nested2MembersSimpleTypesClass objects with nulls should not produce same hashcode``() =
    let comparer = ILEqualityComparer<Nested2MembersSimpleTypesClass>.Default
    let obj1 = Nested2MembersSimpleTypesClass2()
    let obj2 = Nested2MembersSimpleTypesClass3()
    comparer.GetHashCode obj1 = comparer.GetHashCode obj2 |> Assert.False
    
[<Struct>]
[<NoEquality>]
[<NoComparison>]
type NestedMembersSimpleTypesStruct =
    val SimpleTypesClassField : SimpleTypesClass
    val IntField : int
    val CharField : char
    val BoolField : bool
    val LongField : int64
    new(intVal, charVal, boolVal, longVal, stcVal) = { IntField = intVal; CharField = charVal; BoolField = boolVal; LongField = longVal; SimpleTypesClassField = stcVal }

let NestedMembersSimpleTypesStruct1() = NestedMembersSimpleTypesStruct(10, '0', false, 10L, SimpleTypesClass1())
let NestedMembersSimpleTypesStruct2() = NestedMembersSimpleTypesStruct(10, '0', false, 10L, SimpleTypesClass2())

[<Fact>]
let ``Similar NestedMembersSimpleTypesStruct objects should be structurally equal``() =
    let comparer = ILEqualityComparer<NestedMembersSimpleTypesStruct>.Default
    let obj1 = NestedMembersSimpleTypesStruct1()
    let obj2 = NestedMembersSimpleTypesStruct1()
    comparer.Equals(obj1, obj2) |> Assert.True

[<Fact>]
let ``Similar NestedMembersSimpleTypesStruct objects should produce same hashcode``() =
    let comparer = ILEqualityComparer<NestedMembersSimpleTypesStruct>.Default
    let obj1 = NestedMembersSimpleTypesStruct1()
    let obj2 = NestedMembersSimpleTypesStruct1()
    comparer.GetHashCode obj1 = comparer.GetHashCode obj2 |> Assert.True
    
[<Fact>]
let ``Different NestedMembersSimpleTypesStruct objects should not be structurally equal``() =
    let comparer = ILEqualityComparer<NestedMembersSimpleTypesStruct>.Default
    let obj1 = NestedMembersSimpleTypesStruct1()
    let obj2 = NestedMembersSimpleTypesStruct2()
    comparer.Equals(obj1, obj2) |> Assert.False

[<Fact>]
let ``Different NestedMembersSimpleTypesStruct objects should not produce same hashcode``() =
    let comparer = ILEqualityComparer<NestedMembersSimpleTypesStruct>.Default
    let obj1 = NestedMembersSimpleTypesStruct1()
    let obj2 = NestedMembersSimpleTypesStruct2()
    comparer.GetHashCode obj1 = comparer.GetHashCode obj2 |> Assert.False
    
[<Struct>]
[<NoEquality>]
[<NoComparison>]
type Nested2MembersSimpleTypesStruct =
    val NestedMembersSimpleTypesClassField : NestedMembersSimpleTypesClass
    val IntField : int
    val CharField : char
    val BoolField : bool
    val LongField : int64
    new(intVal, charVal, boolVal, longVal, nmstcVal) = { IntField = intVal; CharField = charVal; BoolField = boolVal; LongField = longVal; NestedMembersSimpleTypesClassField = nmstcVal }
    
let Nested2MembersSimpleTypesStruct1() = Nested2MembersSimpleTypesStruct(10, '0', false, 10L, NestedMembersSimpleTypesClass1())
let Nested2MembersSimpleTypesStruct2() = Nested2MembersSimpleTypesStruct(10, '0', false, 10L, NestedMembersSimpleTypesClass2())

[<Fact>]
let ``Similar Nested2MembersSimpleTypesStruct objects should be structurally equal``() =
    let comparer = ILEqualityComparer<Nested2MembersSimpleTypesStruct>.Default
    let obj1 = Nested2MembersSimpleTypesStruct1()
    let obj2 = Nested2MembersSimpleTypesStruct1()
    comparer.Equals(obj1, obj2) |> Assert.True

[<Fact>]
let ``Similar Nested2MembersSimpleTypesStruct objects should produce same hashcode``() =
    let comparer = ILEqualityComparer<Nested2MembersSimpleTypesStruct>.Default
    let obj1 = Nested2MembersSimpleTypesStruct1()
    let obj2 = Nested2MembersSimpleTypesStruct1()
    comparer.GetHashCode obj1 = comparer.GetHashCode obj2 |> Assert.True
    
[<Fact>]
let ``Different Nested2MembersSimpleTypesStruct objects should not be structurally equal``() =
    let comparer = ILEqualityComparer<Nested2MembersSimpleTypesStruct>.Default
    let obj1 = Nested2MembersSimpleTypesStruct1()
    let obj2 = Nested2MembersSimpleTypesStruct2()
    comparer.Equals(obj1, obj2) |> Assert.False

[<Fact>]
let ``Different Nested2MembersSimpleTypesStruct objects should not produce same hashcode``() =
    let comparer = ILEqualityComparer<Nested2MembersSimpleTypesStruct>.Default
    let obj1 = Nested2MembersSimpleTypesStruct1()
    let obj2 = Nested2MembersSimpleTypesStruct2()
    comparer.GetHashCode obj1 = comparer.GetHashCode obj2 |> Assert.False
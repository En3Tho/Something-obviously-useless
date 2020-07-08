module En3Tho.ILEqualityComparer.Tests.DefaultBehaviourTests.MultiMembersTests

open En3Tho.ILEqualityComparer
open Xunit

[<AllowNullLiteral>]
type SimpleTypesClass =
    val IntField : int
    val CharField : char
    val BoolField : bool
    val LongField : int64
    new(intVal, charVal, boolVal, longVal) = { IntField = intVal; CharField = charVal; BoolField = boolVal; LongField = longVal }

let SimpleTypesClass1() = SimpleTypesClass(10, '0', false, 10L)
let SimpleTypesClass2() = SimpleTypesClass(10, '0', true, 10L)

type MultiMemberClassSimpleTypesClass =
    val SimpleTypesClassField1 : SimpleTypesClass
    val SimpleTypesClassField2 : SimpleTypesClass
    val SimpleTypesClassField3 : SimpleTypesClass
    new(stcVal1, stcVal2, stcVal3) = { SimpleTypesClassField1 = stcVal1; SimpleTypesClassField2 = stcVal2; SimpleTypesClassField3 = stcVal3 }

let MultiMemberClassSimpleTypesClass1() = MultiMemberClassSimpleTypesClass(SimpleTypesClass1(), SimpleTypesClass1(), SimpleTypesClass1())
let MultiMemberClassSimpleTypesClass2() = MultiMemberClassSimpleTypesClass(SimpleTypesClass1(), SimpleTypesClass1(), SimpleTypesClass2())

[<Fact>]
let ``Similar MultiMemberClassSimpleTypesClass objects should be structurally equal``() =
    let comparer = ILEqualityComparer<MultiMemberClassSimpleTypesClass>.Default
    let obj1 = MultiMemberClassSimpleTypesClass1()
    let obj2 = MultiMemberClassSimpleTypesClass1()
    comparer.Equals(obj1, obj2) |> Assert.True

[<Fact>]
let ``Similar MultiMemberClassSimpleTypesClass objects should produce same hashcode``() =
    let comparer = ILEqualityComparer<MultiMemberClassSimpleTypesClass>.Default
    let obj1 = MultiMemberClassSimpleTypesClass1()
    let obj2 = MultiMemberClassSimpleTypesClass1()
    comparer.GetHashCode obj1 = comparer.GetHashCode obj2 |> Assert.True
    
[<Fact>]
let ``Different MultiMemberClassSimpleTypesClass objects should not be structurally equal``() =
    let comparer = ILEqualityComparer<MultiMemberClassSimpleTypesClass>.Default
    let obj1 = MultiMemberClassSimpleTypesClass1()
    let obj2 = MultiMemberClassSimpleTypesClass2()
    comparer.Equals(obj1, obj2) |> Assert.False

[<Fact>]
let ``Different MultiMemberClassSimpleTypesClass objects should not produce same hashcode``() =
    let comparer = ILEqualityComparer<MultiMemberClassSimpleTypesClass>.Default
    let obj1 = MultiMemberClassSimpleTypesClass1()
    let obj2 = MultiMemberClassSimpleTypesClass2()
    comparer.GetHashCode obj1 = comparer.GetHashCode obj2 |> Assert.False
    
// -- null -- //
let MultiMemberClassSimpleTypesClass3() = MultiMemberClassSimpleTypesClass(SimpleTypesClass1(), SimpleTypesClass1(), null)

[<Fact>]
let ``Similar MultiMemberClassSimpleTypesClass objects with nulls should be structurally equal``() =
    let comparer = ILEqualityComparer<MultiMemberClassSimpleTypesClass>.Default
    let obj1 = MultiMemberClassSimpleTypesClass3()
    let obj2 = MultiMemberClassSimpleTypesClass3()
    comparer.Equals(obj1, obj2) |> Assert.True

[<Fact>]
let ``Similar MultiMemberClassSimpleTypesClass objects with nulls should produce same hashcode``() =
    let comparer = ILEqualityComparer<MultiMemberClassSimpleTypesClass>.Default
    let obj1 = MultiMemberClassSimpleTypesClass3()
    let obj2 = MultiMemberClassSimpleTypesClass3()
    comparer.GetHashCode obj1 = comparer.GetHashCode obj2 |> Assert.True
    
[<Fact>]
let ``Different MultiMemberClassSimpleTypesClass objects with nulls should not be structurally equal``() =
    let comparer = ILEqualityComparer<MultiMemberClassSimpleTypesClass>.Default
    let obj1 = MultiMemberClassSimpleTypesClass2()
    let obj2 = MultiMemberClassSimpleTypesClass3()
    comparer.Equals(obj1, obj2) |> Assert.False

[<Fact>]
let ``Different MultiMemberClassSimpleTypesClass objects with nulls should not produce same hashcode``() =
    let comparer = ILEqualityComparer<MultiMemberClassSimpleTypesClass>.Default
    let obj1 = MultiMemberClassSimpleTypesClass2()
    let obj2 = MultiMemberClassSimpleTypesClass3()
    comparer.GetHashCode obj1 = comparer.GetHashCode obj2 |> Assert.False
    
[<Struct>]
type SimpleTypesStruct =
    val IntField : int
    val CharField : char
    val BoolField : bool
    val LongField : int64
    new(intVal, charVal, boolVal, longVal) = { IntField = intVal; CharField = charVal; BoolField = boolVal; LongField = longVal }

let SimpleTypesStruct1() = SimpleTypesStruct(10, '0', false, 10L)
let SimpleTypesStruct2() = SimpleTypesStruct(10, '0', true, 10L)

[<Struct>]
type MultiMemberStructSimpleTypesStruct =
    val SimpleTypesStructField1 : SimpleTypesStruct
    val SimpleTypesStructField2 : SimpleTypesStruct
    val SimpleTypesStructField3 : SimpleTypesStruct    
    new(stcVal1, stcVal2, stcVal3) = { SimpleTypesStructField1 = stcVal1; SimpleTypesStructField2 = stcVal2; SimpleTypesStructField3 = stcVal3 }

let MultiMemberStructSimpleTypesStruct1() = MultiMemberStructSimpleTypesStruct(SimpleTypesStruct1(), SimpleTypesStruct1(), SimpleTypesStruct1())
let MultiMemberStructSimpleTypesStruct2() = MultiMemberStructSimpleTypesStruct(SimpleTypesStruct1(), SimpleTypesStruct1(), SimpleTypesStruct2())

[<Fact>]
let ``Similar MultiMemberStructSimpleTypesStruct objects should be structurally equal``() =
    let comparer = ILEqualityComparer<MultiMemberStructSimpleTypesStruct>.Default
    let obj1 = MultiMemberStructSimpleTypesStruct1()
    let obj2 = MultiMemberStructSimpleTypesStruct1()
    comparer.Equals(obj1, obj2) |> Assert.True

[<Fact>]
let ``Similar MultiMemberStructSimpleTypesStruct objects should produce same hashcode``() =
    let comparer = ILEqualityComparer<MultiMemberStructSimpleTypesStruct>.Default
    let obj1 = MultiMemberStructSimpleTypesStruct1()
    let obj2 = MultiMemberStructSimpleTypesStruct1()
    comparer.GetHashCode obj1 = comparer.GetHashCode obj2 |> Assert.True
    
[<Fact>]
let ``Different MultiMemberStructSimpleTypesStruct objects should not be structurally equal``() =
    let comparer = ILEqualityComparer<MultiMemberStructSimpleTypesStruct>.Default
    let obj1 = MultiMemberStructSimpleTypesStruct1()
    let obj2 = MultiMemberStructSimpleTypesStruct2()
    comparer.Equals(obj1, obj2) |> Assert.False

[<Fact>]
let ``Different MultiMemberStructSimpleTypesStruct objects should not produce same hashcode``() =
    let comparer = ILEqualityComparer<MultiMemberStructSimpleTypesStruct>.Default
    let obj1 = MultiMemberStructSimpleTypesStruct1()
    let obj2 = MultiMemberStructSimpleTypesStruct2()
    comparer.GetHashCode obj1 = comparer.GetHashCode obj2 |> Assert.False
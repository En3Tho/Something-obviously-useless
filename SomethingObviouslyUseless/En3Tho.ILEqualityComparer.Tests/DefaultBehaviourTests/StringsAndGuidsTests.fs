module En3Tho.ILEqualityComparer.Tests.DefaultBehaviourTests.StringsAndGuidsTests

open System
open En3Tho.ILEqualityComparer
open Xunit

type GuidsAndStringsClass =
    val StringField : string
    val private _stringProp : string
    val GuidField : Guid
    val private _guidProp : Guid
    member x.StringProp with get() = x._stringProp
    member x.GuidProp with get() = x._guidProp
    new(strF, strP, guidF, guidP) = { StringField = strF; _stringProp = strP; GuidField = guidF; _guidProp = guidP }

let GuidsAndStringsClass1() = GuidsAndStringsClass("123", "456", Guid.Empty, Guid.Empty)
let GuidsAndStringsClass2() = GuidsAndStringsClass("124", "456", Guid.Empty, Guid.Empty)
    
[<Fact>]
let ``Similar GuidsAndStringsClass objects should be structurally equal``() =
    let comparer = ILEqualityComparer<GuidsAndStringsClass>.Default
    let obj1 = GuidsAndStringsClass1()
    let obj2 = GuidsAndStringsClass1()
    comparer.Equals(obj1, obj2) |> Assert.True

[<Fact>]
let ``Similar GuidsAndStringsClass objects should produce same hashcode``() =
    let comparer = ILEqualityComparer<GuidsAndStringsClass>.Default
    let obj1 = GuidsAndStringsClass1()
    let obj2 = GuidsAndStringsClass1()
    comparer.GetHashCode obj1 = comparer.GetHashCode obj2 |> Assert.True

[<Fact>]
let ``Different GuidsAndStringsClass objects should not be structurally equal``() =
    let comparer = ILEqualityComparer<GuidsAndStringsClass>.Default
    let obj1 = GuidsAndStringsClass1()
    let obj2 = GuidsAndStringsClass2()
    comparer.Equals(obj1, obj2) |> Assert.False

[<Fact>]
let ``Different GuidsAndStringsClass objects should not produce same hashcode``() =
    let comparer = ILEqualityComparer<GuidsAndStringsClass>.Default
    let obj1 = GuidsAndStringsClass1()
    let obj2 = GuidsAndStringsClass2()
    comparer.GetHashCode obj1 = comparer.GetHashCode obj2 |> Assert.False
    
// -- nulls -- //

let GuidsAndStringsClass3() = GuidsAndStringsClass(null, null, Guid.Empty, Guid.Empty)
let GuidsAndStringsClass4() = GuidsAndStringsClass("789", null, Guid.Empty, Guid.Empty)

[<Fact>]
let ``Similar GuidsAndStringsClass objects with nulls should be structurally equal``() =
    let comparer = ILEqualityComparer<GuidsAndStringsClass>.Default
    let obj1 = GuidsAndStringsClass3()
    let obj2 = GuidsAndStringsClass3()
    comparer.Equals(obj1, obj2) |> Assert.True

[<Fact>]
let ``Similar GuidsAndStringsClass objects with nulls should produce same hashcode``() =
    let comparer = ILEqualityComparer<GuidsAndStringsClass>.Default
    let obj1 = GuidsAndStringsClass3()
    let obj2 = GuidsAndStringsClass3()
    comparer.GetHashCode obj1 = comparer.GetHashCode obj2 |> Assert.True

[<Fact>]
let ``Different GuidsAndStringsClass objects with nulls should not be structurally equal``() =
    let comparer = ILEqualityComparer<GuidsAndStringsClass>.Default
    let obj1 = GuidsAndStringsClass3()
    let obj2 = GuidsAndStringsClass4()
    comparer.Equals(obj1, obj2) |> Assert.False

[<Fact>]
let ``Different GuidsAndStringsClass objects with nulls should not produce same hashcode``() =
    let comparer = ILEqualityComparer<GuidsAndStringsClass>.Default
    let obj1 = GuidsAndStringsClass3()
    let obj2 = GuidsAndStringsClass4()
    comparer.GetHashCode obj1 = comparer.GetHashCode obj2 |> Assert.False

[<Struct>]
[<NoEquality>]
[<NoComparison>]
type GuidsAndStringsStruct =
    val StringField : string
    val private _stringProp : string
    val GuidField : Guid
    val private _guidProp : Guid
    member x.StringProp with get() = x._stringProp
    member x.GuidProp with get() = x._guidProp
    new(strF, strP, guidF, guidP) = { StringField = strF; _stringProp = strP; GuidField = guidF; _guidProp = guidP }

let GuidsAndStringsStruct1() = GuidsAndStringsStruct("123", "456", Guid.Empty, Guid.Empty)
let GuidsAndStringsStruct2() = GuidsAndStringsStruct("124", "456", Guid.Empty, Guid.Empty)
    
[<Fact>]
let ``Similar GuidsAndStringsStruct objects should be structurally equal``() =
    let comparer = ILEqualityComparer<GuidsAndStringsStruct>.Default
    let obj1 = GuidsAndStringsStruct1()
    let obj2 = GuidsAndStringsStruct1()
    comparer.Equals(obj1, obj2) |> Assert.True

[<Fact>]
let ``Similar GuidsAndStringsStruct objects should produce same hashcode``() =
    let comparer = ILEqualityComparer<GuidsAndStringsStruct>.Default
    let obj1 = GuidsAndStringsStruct1()
    let obj2 = GuidsAndStringsStruct1()
    comparer.GetHashCode obj1 = comparer.GetHashCode obj2 |> Assert.True
    
[<Fact>]
let ``Different GuidsAndStringsStruct objects should not be structurally equal``() =
    let comparer = ILEqualityComparer<GuidsAndStringsStruct>.Default
    let obj1 = GuidsAndStringsStruct1()
    let obj2 = GuidsAndStringsStruct2()
    comparer.Equals(obj1, obj2) |> Assert.False

[<Fact>]
let ``Different GuidsAndStringsStruct objects should not produce same hashcode``() =
    let comparer = ILEqualityComparer<GuidsAndStringsStruct>.Default
    let obj1 = GuidsAndStringsStruct1()
    let obj2 = GuidsAndStringsStruct2()
    comparer.GetHashCode obj1 = comparer.GetHashCode obj2 |> Assert.False
    
// -- nulls -- //

let GuidsAndStringsStruct3() = GuidsAndStringsStruct(null, null, Guid.Empty, Guid.Empty)
let GuidsAndStringsStruct4() = GuidsAndStringsStruct("789", null, Guid.Empty, Guid.Empty)

[<Fact>]
let ``Similar GuidsAndStringsStruct objects with nulls should be structurally equal``() =
    let comparer = ILEqualityComparer<GuidsAndStringsStruct>.Default
    let obj1 = GuidsAndStringsStruct3()
    let obj2 = GuidsAndStringsStruct3()
    comparer.Equals(obj1, obj2) |> Assert.True

[<Fact>]
let ``Similar GuidsAndStringsStruct objects with nulls should produce same hashcode``() =
    let comparer = ILEqualityComparer<GuidsAndStringsStruct>.Default
    let obj1 = GuidsAndStringsStruct3()
    let obj2 = GuidsAndStringsStruct3()
    comparer.GetHashCode obj1 = comparer.GetHashCode obj2 |> Assert.True

[<Fact>]
let ``Different GuidsAndStringsStruct objects with nulls should not be structurally equal``() =
    let comparer = ILEqualityComparer<GuidsAndStringsStruct>.Default
    let obj1 = GuidsAndStringsStruct3()
    let obj2 = GuidsAndStringsStruct4()
    comparer.Equals(obj1, obj2) |> Assert.False

[<Fact>]
let ``Different GuidsAndStringsStruct objects with nulls should not produce same hashcode``() =
    let comparer = ILEqualityComparer<GuidsAndStringsStruct>.Default
    let obj1 = GuidsAndStringsStruct3()
    let obj2 = GuidsAndStringsStruct4()
    comparer.GetHashCode obj1 = comparer.GetHashCode obj2 |> Assert.False
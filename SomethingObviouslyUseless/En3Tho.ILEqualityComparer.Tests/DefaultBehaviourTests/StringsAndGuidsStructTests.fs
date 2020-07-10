module En3Tho.ILEqualityComparer.Tests.DefaultBehaviourTests.StringsAndGuidsStructTests

open Xunit
open En3Tho.ILEqualityComparer
open En3Tho.ILEqualityComparer.Tests.Assets.TestObjects
    
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
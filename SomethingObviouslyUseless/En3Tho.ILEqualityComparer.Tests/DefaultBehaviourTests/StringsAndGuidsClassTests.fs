module En3Tho.ILEqualityComparer.Tests.DefaultBehaviourTests.StringsAndGuidsClassTests

open Xunit
open En3Tho.ILEqualityComparer
open En3Tho.ILEqualityComparer.Tests.Assets.TestObjects

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
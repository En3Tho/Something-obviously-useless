module En3Tho.ILEqualityComparer.Tests.DefaultBehaviourTests.SimpleTypesClassTests

open Xunit
open En3Tho.ILEqualityComparer
open En3Tho.ILEqualityComparer.Tests.Assets.TestObjects

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
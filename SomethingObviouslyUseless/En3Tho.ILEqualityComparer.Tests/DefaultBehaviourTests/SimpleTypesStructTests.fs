module En3Tho.ILEqualityComparer.Tests.DefaultBehaviourTests.SimpleTypesStructTests

open Xunit
open En3Tho.ILEqualityComparer
open En3Tho.ILEqualityComparer.Tests.Assets.TestObjects

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
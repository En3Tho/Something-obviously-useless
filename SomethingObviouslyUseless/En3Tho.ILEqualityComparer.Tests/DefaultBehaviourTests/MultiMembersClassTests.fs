module En3Tho.ILEqualityComparer.Tests.DefaultBehaviourTests.MultiMembersClassTests

open Xunit
open En3Tho.ILEqualityComparer
open En3Tho.ILEqualityComparer.Tests.Assets.TestObjects

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
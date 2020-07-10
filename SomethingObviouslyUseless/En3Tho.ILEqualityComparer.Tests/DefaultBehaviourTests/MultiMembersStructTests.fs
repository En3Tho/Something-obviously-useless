module En3Tho.ILEqualityComparer.Tests.DefaultBehaviourTests.MultiMembersStructTests

open Xunit
open En3Tho.ILEqualityComparer
open En3Tho.ILEqualityComparer.Tests.Assets.TestObjects

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
module En3Tho.ILEqualityComparer.Tests.DefaultBehaviourTests.NestedMembersWithSimpleTypesStructTests

open Xunit
open En3Tho.ILEqualityComparer
open En3Tho.ILEqualityComparer.Tests.Assets.TestObjects

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
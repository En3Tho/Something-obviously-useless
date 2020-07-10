module En3Tho.ILEqualityComparer.Tests.DefaultBehaviourTests.NestedMembersWithSimpleTypesClassTests

open Xunit
open En3Tho.ILEqualityComparer
open En3Tho.ILEqualityComparer.Tests.Assets.TestObjects

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
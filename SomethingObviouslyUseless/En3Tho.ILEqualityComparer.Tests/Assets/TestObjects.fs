module En3Tho.ILEqualityComparer.Tests.Assets.TestObjects

open System

[<AllowNullLiteral>]
type SimpleTypesClass =
    val IntField : int
    val CharField : char
    val BoolField : bool
    val LongField : int64
    new(intVal, charVal, boolVal, longVal) = { IntField = intVal; CharField = charVal; BoolField = boolVal; LongField = longVal }

let SimpleTypesClass1() = SimpleTypesClass(10, '0', false, 10L)
let SimpleTypesClass2() = SimpleTypesClass(10, '0', true, 10L)

[<Struct>]
[<NoEquality>]
[<NoComparison>]
type SimpleTypesStruct =
    val IntField : int
    val CharField : char
    val BoolField : bool
    val LongField : int64
    new(intVal, charVal, boolVal, longVal) = { IntField = intVal; CharField = charVal; BoolField = boolVal; LongField = longVal }

let SimpleTypesStruct1() = SimpleTypesStruct(10, '0', false, 10L)
let SimpleTypesStruct2() = SimpleTypesStruct(10, '0', true, 10L)

[<AllowNullLiteral>]
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
let GuidsAndStringsClass3() = GuidsAndStringsClass(null, null, Guid.Empty, Guid.Empty)
let GuidsAndStringsClass4() = GuidsAndStringsClass("789", null, Guid.Empty, Guid.Empty)

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
let GuidsAndStringsStruct3() = GuidsAndStringsStruct(null, null, Guid.Empty, Guid.Empty)
let GuidsAndStringsStruct4() = GuidsAndStringsStruct("789", null, Guid.Empty, Guid.Empty)

type NestedMembersSimpleTypesClass =
    val SimpleTypesClassField : SimpleTypesClass
    val IntField : int
    val CharField : char
    val BoolField : bool
    val LongField : int64
    new(intVal, charVal, boolVal, longVal, stcVal) = { IntField = intVal; CharField = charVal; BoolField = boolVal; LongField = longVal; SimpleTypesClassField = stcVal }

let NestedMembersSimpleTypesClass1() = NestedMembersSimpleTypesClass(10, '0', false, 10L, SimpleTypesClass1())
let NestedMembersSimpleTypesClass2() = NestedMembersSimpleTypesClass(10, '0', false, 10L, SimpleTypesClass2())
let NestedMembersSimpleTypesClass3() = NestedMembersSimpleTypesClass(10, '0', false, 10L, null)

type Nested2MembersSimpleTypesClass =
    val NestedMembersSimpleTypesClassField : NestedMembersSimpleTypesClass
    val IntField : int
    val CharField : char
    val BoolField : bool
    val LongField : int64
    new(intVal, charVal, boolVal, longVal, nmstcVal) = { IntField = intVal; CharField = charVal; BoolField = boolVal; LongField = longVal; NestedMembersSimpleTypesClassField = nmstcVal }
    
let Nested2MembersSimpleTypesClass1() = Nested2MembersSimpleTypesClass(10, '0', false, 10L, NestedMembersSimpleTypesClass1())
let Nested2MembersSimpleTypesClass2() = Nested2MembersSimpleTypesClass(10, '0', false, 10L, NestedMembersSimpleTypesClass2())
let Nested2MembersSimpleTypesClass3() = Nested2MembersSimpleTypesClass(10, '0', false, 10L, NestedMembersSimpleTypesClass3())

[<Struct>]
[<NoEquality>]
[<NoComparison>]
type NestedMembersSimpleTypesStruct =
    val SimpleTypesClassField : SimpleTypesClass
    val IntField : int
    val CharField : char
    val BoolField : bool
    val LongField : int64
    new(intVal, charVal, boolVal, longVal, stcVal) = { IntField = intVal; CharField = charVal; BoolField = boolVal; LongField = longVal; SimpleTypesClassField = stcVal }

let NestedMembersSimpleTypesStruct1() = NestedMembersSimpleTypesStruct(10, '0', false, 10L, SimpleTypesClass1())
let NestedMembersSimpleTypesStruct2() = NestedMembersSimpleTypesStruct(10, '0', false, 10L, SimpleTypesClass2())

[<Struct>]
[<NoEquality>]
[<NoComparison>]
type Nested2MembersSimpleTypesStruct =
    val NestedMembersSimpleTypesClassField : NestedMembersSimpleTypesClass
    val IntField : int
    val CharField : char
    val BoolField : bool
    val LongField : int64
    new(intVal, charVal, boolVal, longVal, nmstcVal) = { IntField = intVal; CharField = charVal; BoolField = boolVal; LongField = longVal; NestedMembersSimpleTypesClassField = nmstcVal }
    
let Nested2MembersSimpleTypesStruct1() = Nested2MembersSimpleTypesStruct(10, '0', false, 10L, NestedMembersSimpleTypesClass1())
let Nested2MembersSimpleTypesStruct2() = Nested2MembersSimpleTypesStruct(10, '0', false, 10L, NestedMembersSimpleTypesClass2())

type MultiMemberClassSimpleTypesClass =
    val SimpleTypesClassField1 : SimpleTypesClass
    val SimpleTypesClassField2 : SimpleTypesClass
    val SimpleTypesClassField3 : SimpleTypesClass
    new(stcVal1, stcVal2, stcVal3) = { SimpleTypesClassField1 = stcVal1; SimpleTypesClassField2 = stcVal2; SimpleTypesClassField3 = stcVal3 }

let MultiMemberClassSimpleTypesClass1() = MultiMemberClassSimpleTypesClass(SimpleTypesClass1(), SimpleTypesClass1(), SimpleTypesClass1())
let MultiMemberClassSimpleTypesClass2() = MultiMemberClassSimpleTypesClass(SimpleTypesClass1(), SimpleTypesClass1(), SimpleTypesClass2())
let MultiMemberClassSimpleTypesClass3() = MultiMemberClassSimpleTypesClass(SimpleTypesClass1(), SimpleTypesClass1(), null)

[<Struct>]
type MultiMemberStructSimpleTypesStruct =
    val SimpleTypesStructField1 : SimpleTypesStruct
    val SimpleTypesStructField2 : SimpleTypesStruct
    val SimpleTypesStructField3 : SimpleTypesStruct    
    new(stcVal1, stcVal2, stcVal3) = { SimpleTypesStructField1 = stcVal1; SimpleTypesStructField2 = stcVal2; SimpleTypesStructField3 = stcVal3 }

let MultiMemberStructSimpleTypesStruct1() = MultiMemberStructSimpleTypesStruct(SimpleTypesStruct1(), SimpleTypesStruct1(), SimpleTypesStruct1())
let MultiMemberStructSimpleTypesStruct2() = MultiMemberStructSimpleTypesStruct(SimpleTypesStruct1(), SimpleTypesStruct1(), SimpleTypesStruct2())
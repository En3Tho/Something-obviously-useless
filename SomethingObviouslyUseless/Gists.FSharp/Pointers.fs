module Gists.FSharp.Pointers

open System.Runtime.CompilerServices
open Microsoft.FSharp.NativeInterop

type Person = { Name: string; Age: int }

type i8ptr = nativeptr<int8>
type i16ptr = nativeptr<int16>
type i32ptr = nativeptr<int32>
type i64ptr = nativeptr<int64>

type ui8ptr = nativeptr<uint8>
type ui16ptr = nativeptr<uint16>
type ui32ptr = nativeptr<uint32>
type ui64ptr = nativeptr<uint64>

type f64ptr = nativeptr<float>
type f32ptr = nativeptr<float32>

type bptr = nativeptr<bool>
type cptr = nativeptr<char>


#nowarn "9"
#nowarn "42"

let inline cast< ^a, ^b> (a: ^a): ^b = (# "" a: ^b #)

let inline conv< ^a> a = (# "" a: ^a #)

let test() =
    let i = 10
    let g = conv<int64> i
    g

let inline (~~) a = cast a
let inline (~%) a = NativePtr.get a 0

let getFixedAddressOf (person: Person) =
    use agePtr = fixed &person.Age
    NativePtr.set agePtr 0 1
    NativePtr.get agePtr 0

let getNonFixedAddressOf (person: Person) =
    let mutable person = person
    let personPtr = Unsafe.AsPointer &person
    let ptr: i32ptr = ~~personPtr
    let value = %ptr
    let ptr2: i32ptr = cast<voidptr, _> (cast ptr)

    NativePtr.set ptr 0 1
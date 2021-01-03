module Gists.FSharp.Pointers

open System.Runtime.CompilerServices
open Microsoft.FSharp.NativeInterop

type Person = { Name: string; Age: int }

#nowarn "9"

let getFixedAddressOf (person: Person) =
    use agePtr = fixed &person.Age
    NativePtr.set agePtr 0 1
    NativePtr.get agePtr 0

let getNonFixedAddressOf (person: Person) =
    let mutable person = person
    let mutable personPtr = Unsafe.AsPointer &person
    NativePtr.set personPtr 0 1
namespace En3Tho.FSharpExtensions
open System

module Object =
    let inline (&==) (a : ^a when ^a : null) b = Object.ReferenceEquals(a, b)
    let inline (&!=) (a : ^a when ^a : null) b = not (Object.ReferenceEquals(a, b))
    
    let inline (==) a b =
      (^a : (static member op_Equality : 'a * 'a -> bool) (a, b))
      
    let inline (!=) a b = not (a == b)
    
    let inline private callIEquatableEquals<'a when 'a :> IEquatable<'a>> (a : 'a) (b : 'a) = a.Equals(b)
    
    let inline (===) a b = callIEquatableEquals a b
    
    let inline (!==) a b = not (a == b)
    
    let inline defaultValue def obj = if obj &== null then def else obj
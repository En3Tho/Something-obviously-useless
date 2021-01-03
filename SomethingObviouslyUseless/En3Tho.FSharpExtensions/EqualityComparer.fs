module En3Tho.FSharpExtensions.EqualityComparer

open System.Collections.Generic

[<Sealed>]
type private MapEqualityComparer<'a, 'b when 'b : equality>(map : 'a -> 'b) =
    inherit EqualityComparer<'a>()
    override this.Equals(x, y) = map x = map y
    override this.GetHashCode obj = map obj |> hash

[<Sealed>]
type private DelegateEqualityComparer<'a>(eq, ghc) =
    inherit EqualityComparer<'a>()
    override this.Equals(x, y) = eq x y
    override this.GetHashCode obj = ghc obj

type EqualityComparer<'a> with
    static member Create(eq, ghc) = DelegateEqualityComparer(eq, ghc) :> EqualityComparer<'a>
    static member Create<'b when 'b : equality>(map : 'a -> 'b) = MapEqualityComparer(map) :> EqualityComparer<'a>
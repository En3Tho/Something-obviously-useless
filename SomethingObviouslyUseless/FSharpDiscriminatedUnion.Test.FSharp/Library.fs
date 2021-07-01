namespace FSharpDiscriminatedUnion.Test.FSharp

type UnionToConsume =
    | A of Value: int
    | B of Value: string
    | C of Value: int64
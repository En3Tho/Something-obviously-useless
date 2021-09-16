namespace MinimalApisWithPipelines.ActivePatterns

open System

module Option =
    let someObj = Some()
    let ofBool x = if x then someObj else None

[<AutoOpen>]
module TopLevel =
    let inline isNull (obj: 'a when 'a : not struct) = Object.ReferenceEquals(obj, null)
    let inline isNotNull (obj: 'a when 'a : not struct) = obj |> isNull |> not
    let inline (|NotNull|) (obj: 'a when 'a : not struct) =
        if isNull obj then nullArg "Value is null"
        else obj
    let inline (|Null|_|) obj =  obj |> isNull |> Option.ofBool
    let inline (|NotNull|_|) obj =  obj |> isNull |> not |> Option.ofBool

module String =
    let inline (|IsNullOrEmpty|_|) str =
        String.IsNullOrEmpty str |> Option.ofBool

    let inline (|StartsWith|_|) (value: string) (str: string) =
        str.StartsWith(value, StringComparison.Ordinal) |> Option.ofBool

    let inline (|StartsWithIgnoreCase|_|) (value: string) (str: string) =
        str.StartsWith(value, StringComparison.OrdinalIgnoreCase) |> Option.ofBool

    let inline (|StartsWithChar|_|) (value: char) (str: string) =
        str.StartsWith(value) |> Option.ofBool
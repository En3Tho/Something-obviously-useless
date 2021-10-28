module RestaurantApp.RoslynActivePatterns

open System
open System.Reflection
open System.Text
open En3Tho.FSharp.Extensions
open Microsoft.CodeAnalysis

let generatePropertyActivePatterns(type': Type) =
    match type'.Name with
    | name when name.Contains("<") || name.Contains(">") -> None
    | _ ->
        match type'.GetProperties(BindingFlags.Public ||| BindingFlags.Instance) with
        | [||] -> None
        | properties ->
            let indent = "    "
            let getPropertyFunctionCode(propInfo: PropertyInfo) =
                $"let inline {propInfo.Name} a = (^a: (member {propInfo.Name}: {propInfo.PropertyType}) a)"

            let getPropertyActivePatternCode(propInfo: PropertyInfo) =
                $"let inline (|{propInfo.Name}|) a = (^a: (member {propInfo.Name}: {propInfo.PropertyType}) a)"

            StringBuilder() {
                $"module {type'.Name} ="; Environment.NewLine

                for property in properties do
                    indent; getPropertyFunctionCode property; Environment.NewLine

                for property in properties do
                    indent; getPropertyActivePatternCode property; Environment.NewLine
            } |> string |> Some

let generateActivePatterns() =
    let assembly = typeof<IMethodSymbol>.Assembly
    let allTypes = assembly.GetTypes()
    printfn $"Count of types in {assembly.FullName}: {allTypes.Length}"
    allTypes
    |> Seq.filter (fun type' -> type'.IsPublic && type'.IsInterface)
    |> Seq.sortBy (fun type' -> type'.Name)
    |> Seq.map generatePropertyActivePatterns
    |> Seq.choose id
    |> Seq.iter (printfn "%s")
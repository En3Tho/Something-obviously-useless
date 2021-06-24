namespace AutoDecoratorGeneratorFSharp.SymbolHelpers

open System
open AutoDecoratorGeneratorFSharp.Core
open Microsoft.CodeAnalysis

module Symbol =
    let equalsTo (symbol1: ISymbol) symbol2 = symbol1.Equals(symbol2, SymbolEqualityComparer.Default)
    let equalsToNullability (symbol1: ISymbol) symbol2 = symbol1.Equals(symbol2, SymbolEqualityComparer.IncludeNullability)

    let (|HasAttribute|_|) attributeName (symbol: ISymbol) =
        symbol.GetAttributes()
        |> Seq.tryFind ^ fun attribute -> attribute.AttributeClass.ToDisplayString() = attributeName

    let (|IsCtor|_|) (symbol: ISymbol) =
        match symbol with
        | :? IMethodSymbol as symbol -> symbol.Name = ".ctor"
        | _ -> false
        |> Option.ofBool

    let (|IsStaticProperty|_|) (symbol: ISymbol) =
        match symbol with
        | :? IPropertySymbol as symbol -> symbol.IsStatic
        | _ -> false
        |> Option.ofBool

    let (|IsStaticMethod|_|) (symbol: ISymbol) =
        match symbol with
        | :? IMethodSymbol as symbol -> symbol.IsStatic
        | _ -> false
        |> Option.ofBool

    let (|EqualsTo|_|) symbol2 symbol1 = symbol1 |> equalsTo symbol2 |> Option.ofBool
    let (|EqualsToNullable|_|) symbol2 symbol1 = symbol1 |> equalsToNullability symbol2 |> Option.ofBool

module PropertySymbol =
    let hasSameSignatureAs (symbol2: IPropertySymbol) (symbol1: IPropertySymbol) =
        symbol1.Name.Equals(symbol2.Name, StringComparison.Ordinal)
        && Symbol.equalsTo symbol1.Type symbol2.Type

    let isImplementedExplicitlyByInterface (symbol: IPropertySymbol) =
        symbol.ExplicitInterfaceImplementations.Length > 0

    let (|IsIndexerProperty|_|) (symbol: IPropertySymbol) =
        symbol.Parameters.Length > 0 |> Option.ofBool

module MethodSymbol =
    let hasSameSignatureAs (symbol2: IMethodSymbol) (symbol1: IMethodSymbol) =
        symbol1.Name.Equals(symbol2.Name, StringComparison.Ordinal)
        && symbol1.ReturnType |> Symbol.equalsTo symbol2.ReturnType
        && symbol1.Parameters |> Seq.identicalBy Symbol.equalsTo symbol2.Parameters

    let isGetterOrSetterOf (propertySymbol: IPropertySymbol) (methodSymbol: IMethodSymbol) =
        match methodSymbol with
        | Symbol.EqualsTo propertySymbol.GetMethod
        | Symbol.EqualsTo propertySymbol.SetMethod -> true
        | _ -> false

    let isImplementedExplicitlyByInterface (methodSymbol: IMethodSymbol) =
        methodSymbol.ExplicitInterfaceImplementations.Length > 0

module SymbolEquality =

    let areSameProperties (decorated: ISymbol) (overriden: ISymbol) =
        match decorated, overriden with
        | :? IPropertySymbol as decorated, (:? IPropertySymbol as overriden) ->
            decorated |> PropertySymbol.hasSameSignatureAs overriden
        | _ -> false

    let areSameMethods (decorated: ISymbol) (overriden: ISymbol) =
        match decorated, overriden with
        | :? IMethodSymbol as decorated, (:? IMethodSymbol as overriden) ->
            decorated |> MethodSymbol.hasSameSignatureAs overriden
        | _ -> false
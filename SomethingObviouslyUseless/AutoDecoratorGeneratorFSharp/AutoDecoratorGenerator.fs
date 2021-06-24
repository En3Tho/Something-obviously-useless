namespace AutoDecoratorGeneratorFSharp

open AutoDecoratorGeneratorFSharp.SourceGeneration
open Microsoft.CodeAnalysis
open Microsoft.CodeAnalysis.CSharp.Syntax

open AutoDecoratorGeneratorFSharp.Core

type DecoratedAttributeFieldsSyntaxReceiver() =
    let decoratedFields = ResizeArray()

    let (|IsFieldDeclarationSyntax|_|) (node: SyntaxNode) =
        match node with
        | :? FieldDeclarationSyntax as syntax -> Some syntax
        | _ -> None

    let (|ContainsFieldWithDecoratedAttribute|_|) (context: GeneratorSyntaxContext) (syntax: FieldDeclarationSyntax) =
        if syntax.AttributeLists.Count = 0 then None
        else
            syntax.Declaration.Variables
            |> Seq.map context.SemanticModel.GetDeclaredSymbol
            |> Seq.ofType<IFieldSymbol>
            |> Seq.tryFind ^ fun field ->
                field.GetAttributes()
                |> Seq.exists ^ fun ad ->
                    ad.AttributeClass <> null
                    && ad.AttributeClass.ToDisplayString() = RawSources.DecorateAttributeName

    let onVisitSyntaxNode (context: GeneratorSyntaxContext) =
        match context.Node with
        | IsFieldDeclarationSyntax (ContainsFieldWithDecoratedAttribute context field) ->
            decoratedFields.Add field
        | _ -> ()

    member _.Fields = decoratedFields

    interface ISyntaxContextReceiver with
        member this.OnVisitSyntaxNode(syntaxNode) = onVisitSyntaxNode syntaxNode

module AutoDecoratedGenerator =
    let initialize (context: GeneratorInitializationContext) = ()
    let execute (context: GeneratorExecutionContext) = ()
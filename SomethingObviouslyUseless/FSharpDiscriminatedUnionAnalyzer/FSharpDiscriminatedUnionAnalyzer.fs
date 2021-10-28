namespace FSharpDiscriminatedUnionAnalyzer

open System.Diagnostics
open Microsoft.CodeAnalysis.Diagnostics
open Microsoft.CodeAnalysis
open System.Collections.Immutable
open Microsoft.CodeAnalysis.Operations
open FSharp.Reflection

module DiagnosticCreator =
    let createDiagnostic (context: OperationAnalysisContext) (descriptor: DiagnosticDescriptor) =
        Diagnostic.Create(descriptor, context.Operation.Syntax.GetLocation())
        |> context.ReportDiagnostic

module Operation =
    let equalsAs<'a when 'a :> IOperation and 'a: equality> (target: IOperation) (value: IOperation) =
        match target, value with
        | :? 'a as typedTarget, (:? 'a as typedValue)
            when typedTarget = typedValue -> true
        | _ -> false

module TypeChecker =
    let isFSharpDUType (typeSymbol: ITypeSymbol) = // this won't include struct DU's as they are too specific
        true

    let getFSharpDUCases (typeSymbol: ITypeSymbol) = ()

    let (|FSharpDUType|_|) = isFSharpDUType >> Option.ofBool

module SwitchCaseAnalysis =
    let rule = DiagnosticDescriptor("FSDU0002", "Property self reference detected by F#", "Property self reference detected by F#. Potentially a bug.", "SelfAssignment F#",
                                    DiagnosticSeverity.Warning, true, null, null, array.Empty<string>())
    let analyze (context: OperationAnalysisContext) =
#if DEBUG_DU_ANALYZER
        if not Debugger.IsAttached then
            Debugger.Launch() |> ignore
#endif
        let operation = context.Operation :?> ISwitchCaseOperation

        // check if switch target is FSharpDU type
        match operation.Type with
        | :? ITypePatternOperation as operation ->
            match operation.InputType with
            | TypeChecker.FSharpDUType as duType ->
                // get cases
                // check for completeness
                // if not complete
                    // get missing cases
                    // report diagnostics and code fixes
                // else
                    // check for default case
                    // if exists then report diagnostic and code fix
                ()
            | _ -> ()
        | _ -> ()

//        match context.ContainingSymbol with
//        | :? IMethodSymbol as methodSymbol
//            when methodSymbol.AssociatedSymbol.Equals(operation.Property, SymbolEqualityComparer.Default) -> DiagnosticCreator.createDiagnostic context rule
//        | _ -> ()

module SwitchExpressionAnalysis =
    let rule =  DiagnosticDescriptor("FSDU0003", "Property self compound assignment detected by F#", "Property self compound assignment detected by F#. Change this to a method.", "SelfAssignment F#",
                                     DiagnosticSeverity.Warning, true, null, null, array.Empty<string>());
    let analyze (context: OperationAnalysisContext) =
#if DEBUG_DU_ANALYZER
        if not Debugger.IsAttached then
            Debugger.Launch() |> ignore
#endif
        let operation = context.Operation :?> ISwitchExpressionOperation

        match operation.Type with
        | :? ITypePatternOperation as operation ->
            match operation.InputType with
            | TypeChecker.FSharpDUType as duType ->
                ()
            | _ -> ()
        | _ -> ()

//        match operation.Target, operation.Value with
//        | target, value when target |> Operation.equalsAs<IPropertyReferenceOperation> value -> DiagnosticCreator.createDiagnostic context rule
//        | _ -> ()

module FSharpDiscriminatedUnionAnalysis =
    module Rules =
        let rule1 =  DiagnosticDescriptor("FSDU0003", "Property self compound assignment detected by F#", "Property self compound assignment detected by F#. Change this to a method.", "SelfAssignment F#",
                                         DiagnosticSeverity.Warning, true, null, null, array.Empty<string>())

[<DiagnosticAnalyzer(LanguageNames.CSharp)>]
type FSharpDiscriminatedUnionAnalyzer() =
    inherit DiagnosticAnalyzer()

    override this.SupportedDiagnostics =
        ImmutableArray.Create(SwitchExpressionAnalysis.rule, SwitchCaseAnalysis.rule)

    override this.Initialize (context: AnalysisContext) =
#if DEBUG_DU_ANALYZER
        if not Debugger.IsAttached then
            Debugger.Launch() |> ignore
#endif
        context.EnableConcurrentExecution();
        context.ConfigureGeneratedCodeAnalysis(GeneratedCodeAnalysisFlags.Analyze ||| GeneratedCodeAnalysisFlags.ReportDiagnostics);
        context.RegisterOperationAction(SwitchExpressionAnalysis.analyze, OperationKind.SwitchExpression)
        context.RegisterOperationAction(SwitchCaseAnalysis.analyze, OperationKind.SwitchCase)
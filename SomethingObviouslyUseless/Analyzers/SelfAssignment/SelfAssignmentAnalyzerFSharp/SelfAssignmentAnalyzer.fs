namespace SelfAssignmentAnalyzerFSharp

open Microsoft.CodeAnalysis.Diagnostics
open Microsoft.CodeAnalysis
open System.Collections.Immutable
open Microsoft.CodeAnalysis.Operations

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

module SimpleAssignmentAnalysis =
    let rule = DiagnosticDescriptor("SAFS0001", "Self assignment detected by F#", "Redundant self assignment detected by F#.", "SelfAssignment F#",
                                    DiagnosticSeverity.Warning, true, null, null, array.Empty<string>())        
    let analyze (context : OperationAnalysisContext) =
        let operation = context.Operation :?> ISimpleAssignmentOperation
        
        match operation.Target, operation.Value with
        | target, value when target |> Operation.equalsAs<IPropertyReferenceOperation> value -> DiagnosticCreator.createDiagnostic context rule
        | target, value when target |> Operation.equalsAs<IParameterReferenceOperation> value -> DiagnosticCreator.createDiagnostic context rule
        | target, value when target |> Operation.equalsAs<IFieldReferenceOperation> value ->  DiagnosticCreator.createDiagnostic context rule
        | _ -> ()

module PropertyReferenceAnalysis =
    let rule = DiagnosticDescriptor("SAFS0002", "Property self reference detected by F#", "Property self reference detected by F#. Potentially a bug.", "SelfAssignment F#",
                                    DiagnosticSeverity.Warning, true, null, null, array.Empty<string>())
    let analyze (context : OperationAnalysisContext) =
        let operation = context.Operation :?> IPropertyReferenceOperation
    
        match context.ContainingSymbol with
        | :? IMethodSymbol as methodSymbol
            when methodSymbol.AssociatedSymbol.Equals(operation.Property, SymbolEqualityComparer.Default) -> DiagnosticCreator.createDiagnostic context rule
        | _ -> ()

module CompoundAssignmentAnalysis =
    let rule =  DiagnosticDescriptor("SAFS0003", "Property self compound assignment detected by F#", "Property self compound assignment detected by F#. Change this to a method.", "SelfAssignment F#",
                                     DiagnosticSeverity.Warning, true, null, null, array.Empty<string>());        
    let analyze (context : OperationAnalysisContext) =
        let operation = context.Operation :?> ICompoundAssignmentOperation
    
        match operation.Target, operation.Value with
        | target, value when target |> Operation.equalsAs<IPropertyReferenceOperation> value -> DiagnosticCreator.createDiagnostic context rule
        | _ -> ()

[<DiagnosticAnalyzer(LanguageNames.CSharp)>]
type SelfAssignmentAnalyzerFSharp() =
    inherit DiagnosticAnalyzer()

    override this.SupportedDiagnostics =
               ImmutableArray.Create(SimpleAssignmentAnalysis.rule, CompoundAssignmentAnalysis.rule, PropertyReferenceAnalysis.rule)   

    override this.Initialize (context : AnalysisContext) =
        context.EnableConcurrentExecution();
        context.ConfigureGeneratedCodeAnalysis(GeneratedCodeAnalysisFlags.Analyze ||| GeneratedCodeAnalysisFlags.ReportDiagnostics);
        context.RegisterOperationAction(SimpleAssignmentAnalysis.analyze, OperationKind.SimpleAssignment)
        context.RegisterOperationAction(CompoundAssignmentAnalysis.analyze, OperationKind.CompoundAssignment)
        context.RegisterOperationAction(PropertyReferenceAnalysis.analyze, OperationKind.PropertyReference)
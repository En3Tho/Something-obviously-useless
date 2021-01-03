namespace SelfAssignmentAnalyzerFSharp

open Microsoft.CodeAnalysis.Diagnostics
open Microsoft.CodeAnalysis
open System.Collections.Immutable
open Microsoft.CodeAnalysis.Operations

module DiagnosticCreator =    
    let createDiagnostic (context : OperationAnalysisContext) (rule : DiagnosticDescriptor) =
        Diagnostic.Create(rule, context.Operation.Syntax.GetLocation())
        |> context.ReportDiagnostic

module Matcher =
    let isMatch<'a when 'a :> IOperation and 'a : equality>  (target : IOperation) (value : IOperation) =
        match target, value with
        | (:? 'a as typedTarget), (:? 'a as typedValue)
            when typedTarget = typedValue -> true
        | _ -> false

module SimpleAssignmentAnalysis =
    let rule = DiagnosticDescriptor("SAFS0001", "Self assignment detected by F#", "Redundant self assignment detected by F#.", "SelfAssignment F#",
                                    DiagnosticSeverity.Warning, true, null, null, array.Empty<string>())        
    let analyze (context : OperationAnalysisContext) =
        let operation = context.Operation :?> ISimpleAssignmentOperation
        
        match operation.Target, operation.Value with
        | t, v when Matcher.isMatch<IPropertyReferenceOperation> t v ->  DiagnosticCreator.createDiagnostic context rule
        | t, v when Matcher.isMatch<IParameterReferenceOperation> t v ->  DiagnosticCreator.createDiagnostic context rule
        | t, v when Matcher.isMatch<IFieldReferenceOperation> t v ->  DiagnosticCreator.createDiagnostic context rule
        | _ -> ()

module PropertyReferenceAnalysis =
    let rule = DiagnosticDescriptor("SAFS0002", "Property self reference detected by F#", "Property self reference detected by F#. Potentially a bug.", "SelfAssignment F#",
                                    DiagnosticSeverity.Warning, true, null, null, array.Empty<string>())    
    let analyze (context : OperationAnalysisContext) =
        let operation = context.Operation :?> IPropertyReferenceOperation
    
        match context.ContainingSymbol with
        | (:? IMethodSymbol as methodSymbol)
            when methodSymbol.AssociatedSymbol = (operation.Property :> ISymbol) -> DiagnosticCreator.createDiagnostic context rule
        | _ -> ()

module CompoundAssignmentAnalysis =
    let rule =  DiagnosticDescriptor("SAFS0003", "Property self compound assignment detected by F#", "Property self compound assignment detected by F#. Change this to a method.", "SelfAssignment F#",
                                     DiagnosticSeverity.Warning, true, null, null, array.Empty<string>());        
    let analyze (context : OperationAnalysisContext) =
        let operation = context.Operation :?> ICompoundAssignmentOperation
    
        match operation.Target, operation.Value with
        | t, v when Matcher.isMatch<IPropertyReferenceOperation> t v -> DiagnosticCreator.createDiagnostic context rule              
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
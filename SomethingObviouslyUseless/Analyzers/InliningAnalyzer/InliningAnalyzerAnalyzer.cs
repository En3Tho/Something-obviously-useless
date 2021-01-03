using System;
using System.Collections.Immutable;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Diagnostics;
using Microsoft.CodeAnalysis.Operations;

namespace InliningAnalyzer
{
    [DiagnosticAnalyzer(LanguageNames.CSharp)]
    public class InliningAnalyzerAnalyzer : DiagnosticAnalyzer
    {
        public const string DiagnosticId = ""; // TODO: add
        private const string Title = ""; // TODO: add
        private const string MessageFormat = ""; // TODO: add
        private const string Category = "";     // TODO: add
        private const string InliningMethodToken = "RoslynInliningMethod"; // TODO: to keyword "inline" in method declaration or maybe try to inline anything that gets single func or action passed in
        
        private static readonly DiagnosticDescriptor InliningRule =
            new DiagnosticDescriptor(DiagnosticId, Title, MessageFormat, Category, DiagnosticSeverity.Warning, true);

        public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics => ImmutableArray.Create(InliningRule);
        
        public override void Initialize(AnalysisContext context)
        {
            context.EnableConcurrentExecution();
            context.ConfigureGeneratedCodeAnalysis(GeneratedCodeAnalysisFlags.Analyze | GeneratedCodeAnalysisFlags.ReportDiagnostics);
            context.RegisterOperationAction(AnalyzeInliningPossibility, OperationKind.MethodReference);
        }

        private static void AnalyzeInliningPossibility(OperationAnalysisContext context)
        {
            var operation = (IMethodReferenceOperation)context.Operation;
            if (operation.Method.Name.Contains(InliningMethodToken))
            {
                context.ReportDiagnostic(Diagnostic.Create(InliningRule, operation.Syntax.GetLocation()));
            }
        }
    }
}
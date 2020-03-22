using System.Collections.Immutable;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Diagnostics;
using Microsoft.CodeAnalysis.Operations;

namespace SelfAssignmentAnalyzer
{
    [DiagnosticAnalyzer(LanguageNames.CSharp)]
    public class SelfAssignmentAnalyzer : DiagnosticAnalyzer
    {
        private const string Category = "SelfAssignment";

        private static readonly DiagnosticDescriptor SimpleSelfAssignmentRule = new DiagnosticDescriptor("SACS0001", "Self assignment detected by C#.", "Redundant self assignment detected by C#.", Category, DiagnosticSeverity.Warning, true);
        private static readonly DiagnosticDescriptor PropertySelfReferenceRule = new DiagnosticDescriptor("SACS0002", "Property self reference detected by C#.", "Property self reference detected by C#. Potentially a bug.", Category, DiagnosticSeverity.Warning, true);
        private static readonly DiagnosticDescriptor PropertySelfCompoundAssignmentRule = new DiagnosticDescriptor("SACS0003", "Property self compound assignment detected by C#.", "Property self compound assignment detected by C#. Change this to a method", Category, DiagnosticSeverity.Warning, true);

        public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics =>
            ImmutableArray.Create(SimpleSelfAssignmentRule, PropertySelfReferenceRule, PropertySelfCompoundAssignmentRule);

        public override void Initialize(AnalysisContext context)
        {
            context.RegisterOperationAction(AnalyzeSimpleAssignment, OperationKind.SimpleAssignment);
            context.RegisterOperationAction(AnalyzeCompoundAssignment, OperationKind.CompoundAssignment);
            context.RegisterOperationAction(AnalyzePropertyReference, OperationKind.PropertyReference);
        }

        private static bool IsMatch<T>(IOperation target, IOperation value)
            => target is T tTarget && value is T tValue && tTarget.Equals(tValue);
        
        private static void AnalyzeSimpleAssignment(OperationAnalysisContext context)
        {
            var operation = (ISimpleAssignmentOperation)context.Operation;

            if (IsMatch<IParameterReferenceOperation>(operation.Target, operation.Value)
             || IsMatch<IPropertyReferenceOperation>(operation.Target, operation.Value)
             || IsMatch<IFieldReferenceOperation>(operation.Target, operation.Value))
            {
                var diagnostic = Diagnostic.Create(SimpleSelfAssignmentRule, operation.Syntax.GetLocation());
                context.ReportDiagnostic(diagnostic);
            }
        }

        private static void AnalyzeCompoundAssignment(OperationAnalysisContext context)
        {
            var operation = (ICompoundAssignmentOperation)context.Operation;

            if (IsMatch<IParameterReferenceOperation>(operation.Target, operation.Value))
            {
                var diagnostic = Diagnostic.Create(PropertySelfCompoundAssignmentRule, operation.Syntax.GetLocation());
                context.ReportDiagnostic(diagnostic);
            }
        }

        private static void AnalyzePropertyReference(OperationAnalysisContext context)
        {
            var operation = (IPropertyReferenceOperation)context.Operation;

            if (context.ContainingSymbol is IMethodSymbol methodSymbol
                && methodSymbol.AssociatedSymbol is IPropertySymbol property
                && operation.Property.Equals(property))
            {
                var diagnostic = Diagnostic.Create(PropertySelfReferenceRule, operation.Syntax.GetLocation());
                context.ReportDiagnostic(diagnostic);
            }
        }
    }
}

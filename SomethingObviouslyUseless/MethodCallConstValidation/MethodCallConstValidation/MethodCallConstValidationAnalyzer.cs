using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Diagnostics;
using Microsoft.CodeAnalysis.FlowAnalysis;
using Microsoft.CodeAnalysis.Operations;

namespace MethodCallConstValidation
{
    [DiagnosticAnalyzer(LanguageNames.CSharp)]
    public class MethodCallConstValidationAnalyzer : DiagnosticAnalyzer
    {
        public const string DiagnosticId = "MethodCallConstValidation";

        // You can change these strings in the Resources.resx file. If you do not want your analyzer to be localize-able, you can use regular strings for Title and MessageFormat.
        // See https://github.com/dotnet/roslyn/blob/master/docs/analyzers/Localizing%20Analyzers.md for more on localization
        private static readonly LocalizableString Title = new LocalizableResourceString(nameof(Resources.AnalyzerTitle), Resources.ResourceManager, typeof(Resources));
        private static readonly LocalizableString MessageFormat = new LocalizableResourceString(nameof(Resources.AnalyzerMessageFormat), Resources.ResourceManager, typeof(Resources));
        private static readonly LocalizableString Description = new LocalizableResourceString(nameof(Resources.AnalyzerDescription), Resources.ResourceManager, typeof(Resources));
        private const string Category = "Naming";

        private static DiagnosticDescriptor Rule = new DiagnosticDescriptor(DiagnosticId, Title, MessageFormat, Category, DiagnosticSeverity.Warning, isEnabledByDefault: true, description: Description);

        public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics { get { return ImmutableArray.Create(Rule); } }

        public override void Initialize(AnalysisContext context)
        {
            context.RegisterOperationAction(AnalyzeMethodReference, OperationKind.MethodReference);
        }

        private static void AnalyzeMethodReference(OperationAnalysisContext context)
        {
            var operation = (IMethodReferenceOperation)context.Operation;
            var parameters = operation.Method.Parameters;
            var throwsException = CanThrowExceptionOnParameterCondition(operation); // 
            var caller = operation.Parent; // if not null check caller's parameters
        }

        private static bool CanThrowExceptionOnParameterCondition(IMethodReferenceOperation operation)
        {
            return false;
        }

        private static bool CanReturnOnParameterCondition(IMethodReferenceOperation operation)
        {

        }
    }
}

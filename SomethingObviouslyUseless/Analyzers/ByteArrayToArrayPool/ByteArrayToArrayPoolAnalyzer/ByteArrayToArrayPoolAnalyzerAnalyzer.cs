using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Diagnostics;
using Microsoft.CodeAnalysis.Operations;
using System;
using System.Collections.Immutable;
using System.Linq;
using System.Reflection;

namespace ByteArrayToArrayPoolAnalyzer
{
    [DiagnosticAnalyzer(LanguageNames.CSharp)]
    public class ByteArrayToArrayPoolAnalyzerAnalyzer : DiagnosticAnalyzer
    {
        public const string DiagnosticId = "ByteArrayToArrayPoolAnalyzer";

        private static readonly LocalizableString Title = new LocalizableResourceString(nameof(Resources.AnalyzerTitle), Resources.ResourceManager, typeof(Resources));
        private static readonly LocalizableString MessageFormat = new LocalizableResourceString(nameof(Resources.AnalyzerMessageFormat), Resources.ResourceManager, typeof(Resources));
        private static readonly LocalizableString Description = new LocalizableResourceString(nameof(Resources.AnalyzerDescription), Resources.ResourceManager, typeof(Resources));
        private const string Category = "Best practices";

        private static readonly DiagnosticDescriptor Rule = new DiagnosticDescriptor(DiagnosticId, Title, MessageFormat, Category, DiagnosticSeverity.Warning, isEnabledByDefault: true, description: Description);

        public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics => ImmutableArray.Create(Rule);

        public override void Initialize(AnalysisContext context)
        {
            context.EnableConcurrentExecution();
            context.ConfigureGeneratedCodeAnalysis(GeneratedCodeAnalysisFlags.Analyze | GeneratedCodeAnalysisFlags.ReportDiagnostics);
            context.RegisterOperationAction(AnalyzeArrayCreation, OperationKind.ArrayCreation);
        }

        public void AnalyzeArrayCreation(OperationAnalysisContext context)
        {
            var op = (IArrayCreationOperation)context.Operation;

            if (op.DimensionSizes.Length == 1 && op.DimensionSizes[0].ConstantValue.HasValue // check that our array is const
                && op.DimensionSizes[0].ConstantValue.Value is int value && value > 10) // not sure if there can be something other than integer after const check
            {
                var diagnostic = Diagnostic.Create(Rule, op.Syntax.GetLocation());
                context.ReportDiagnostic(diagnostic);
            }
        }
    }
}

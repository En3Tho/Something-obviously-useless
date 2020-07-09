using System.Collections.Immutable;
using System.Composition;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CodeActions;
using Microsoft.CodeAnalysis.CodeFixes;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Editing;
using Microsoft.CodeAnalysis.Operations;

namespace InliningAnalyzer
{
    [ExportCodeFixProvider(LanguageNames.CSharp, Name = nameof(InliningAnalyzerCodeFixProvider)), Shared]
    public class InliningAnalyzerCodeFixProvider : CodeFixProvider
    {
        private const string Title = ""; // TODO: add
        public override ImmutableArray<string> FixableDiagnosticIds { get; } = ImmutableArray.Create(InliningAnalyzerAnalyzer.DiagnosticId);

        public override Task RegisterCodeFixesAsync(CodeFixContext context)
        {
            var diagnostic = context.Diagnostics.First();

            context.RegisterCodeFix(
                CodeAction.Create(
                    title: Title,
                    createChangedDocument: c => InlineMethod(context.Document, diagnostic, c),
                    equivalenceKey: Title),
                diagnostic);
            
            return Task.CompletedTask;
        }

        private static async Task<Document> InlineMethod(Document document, Diagnostic diagnostic, CancellationToken cancellationToken)
        {            
            var root = await document.GetSyntaxRootAsync(cancellationToken);
            var originalExpression = root.FindNode(diagnostic.Location.SourceSpan);
            var semanticModel = await document.GetSemanticModelAsync(cancellationToken);

            // array type
            var operation = (IMethodReferenceOperation)semanticModel.GetOperation(originalExpression);
            // var typeSymbol = (IArrayTypeSymbol)operation.Type;
            // var elementType = typeSymbol.ElementType;
            //
            var generator = SyntaxGenerator.GetGenerator(document);
            // TODO:
            // 1) find referenced method body
            // 2) Get span of that body
            // 3) find Func/Action invocation inside that span
            // 4) Swap with method body / func/action call / lambda converted to a method body
            // 5) swap whole reference operation syntax node with new inlined one
            // 6) add new keyword and compiler rules
            // 7) add auto inlining on build
            // 8) first pull request :)
            
            // // ArrayPool<T>.Shared.Rent
            // var arrayPool = generator.GenericName("ArrayPool", elementType);
            // var callShared = generator.MemberAccessExpression(arrayPool, "Shared");
            // var callRent = generator.MemberAccessExpression(callShared, "Rent");
            //
            // // const argument
            // // note that we switch to SyntaxFactory here
            // var constantValue = SyntaxFactory.Literal((int)operation.DimensionSizes[0].ConstantValue.Value);
            // var constantExpression = SyntaxFactory.LiteralExpression(SyntaxKind.NumericLiteralExpression, constantValue);
            // var argumentExpression = SyntaxFactory.Argument(constantExpression);
            //
            // // ArrayPool<T>.Shared.Rent(const) invocation
            // var invocationExpression = generator.InvocationExpression(callRent, argumentExpression);

            return document.WithSyntaxRoot(root.ReplaceNode(originalExpression, generator.InvocationExpression(null)));
        }
    }
}
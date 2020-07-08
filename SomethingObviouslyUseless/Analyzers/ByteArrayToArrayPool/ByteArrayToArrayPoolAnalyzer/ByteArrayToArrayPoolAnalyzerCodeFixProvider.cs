using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CodeActions;
using Microsoft.CodeAnalysis.CodeFixes;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Editing;
using Microsoft.CodeAnalysis.Operations;
using System.Collections.Immutable;
using System.Composition;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ByteArrayToArrayPoolAnalyzer
{
    [ExportCodeFixProvider(LanguageNames.CSharp, Name = nameof(ByteArrayToArrayPoolAnalyzerCodeFixProvider)), Shared]
    public class ByteArrayToArrayPoolAnalyzerCodeFixProvider : CodeFixProvider
    {
        private const string Title = "Use ArrayPool";

        public sealed override ImmutableArray<string> FixableDiagnosticIds { get; } =
            ImmutableArray.Create(ByteArrayToArrayPoolAnalyzerAnalyzer.DiagnosticId);

        public sealed override FixAllProvider GetFixAllProvider()
        {
            return WellKnownFixAllProviders.BatchFixer;
        }

        public sealed override Task RegisterCodeFixesAsync(CodeFixContext context)
        {
            var diagnostic = context.Diagnostics.First();

            context.RegisterCodeFix(
                CodeAction.Create(
                    title: Title,
                    createChangedDocument: c => UseArrayPool(context.Document, diagnostic, c),
                    equivalenceKey: Title),
                diagnostic);

            return Task.CompletedTask;
        }

        private async Task<Document> UseArrayPool(Document document, Diagnostic diagnostic, CancellationToken cancellationToken)
        {            
            var root = await document.GetSyntaxRootAsync(cancellationToken);
            var originalExpression = root.FindNode(diagnostic.Location.SourceSpan);
            var semanticModel = await document.GetSemanticModelAsync(cancellationToken);

            // array type
            var operation = (IArrayCreationOperation)semanticModel.GetOperation(originalExpression);
            var typeSymbol = (IArrayTypeSymbol)operation.Type;
            var elementType = typeSymbol.ElementType;

            var generator = SyntaxGenerator.GetGenerator(document);

            // ArrayPool<T>.Shared.Rent
            var arrayPool = generator.GenericName("ArrayPool", elementType);
            var callShared = generator.MemberAccessExpression(arrayPool, "Shared");
            var callRent = generator.MemberAccessExpression(callShared, "Rent");

            // const argument
            // note that we switch to SyntaxFactory here
            var constantValue = SyntaxFactory.Literal((int)operation.DimensionSizes[0].ConstantValue.Value);
            var constantExpression = SyntaxFactory.LiteralExpression(SyntaxKind.NumericLiteralExpression, constantValue);
            var argumentExpression = SyntaxFactory.Argument(constantExpression);

            // ArrayPool<T>.Shared.Rent(const) invocation
            var invocationExpression = generator.InvocationExpression(callRent, argumentExpression);

            return document.WithSyntaxRoot(root.ReplaceNode(originalExpression, invocationExpression));
        }
    }
}

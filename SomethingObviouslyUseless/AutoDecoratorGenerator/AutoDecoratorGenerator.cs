// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Text;

#nullable enable

namespace AutoDecoratorGenerator
{
    internal static class Diagnostics
    {

    }

    internal static class GeneratedTypeChecks
    {
        public static bool CheckClassIsNotStatic(INamedTypeSymbol symbol, GeneratorExecutionContext context)
        {
            if (symbol.IsStatic)
            {
                context.ReportDiagnostic(null); // TODO: Diagnostic
                return false;
            }

            return true;
        }

        public static bool CheckClassIsPartial(INamedTypeSymbol symbol, GeneratorExecutionContext context)
        {
            if (symbol.IsStatic)
            {
                context.ReportDiagnostic(null); // TODO: Diagnostic
                return false;
            }

            return true;
        }

        public static bool CheckClassIsPublicOrInternal(INamedTypeSymbol symbol, GeneratorExecutionContext context)
        {
            switch (symbol.DeclaredAccessibility)
            {
                case Accessibility.Internal:
                case Accessibility.Public:
                    return true;
                default:
                    context.ReportDiagnostic(null); // TODO: Diagnostic
                    return false;
            }
        }

        public static bool CheckClassIsTopLevel(INamedTypeSymbol symbol, GeneratorExecutionContext context)
        {
            if (!symbol.ContainingSymbol.Equals(symbol.ContainingNamespace, SymbolEqualityComparer.Default))
            {
                context.ReportDiagnostic(null); // TODO: Diagnostic
                return false;
            }
            return true;
        }
    }

    public static class GeneratedMembersChecks
    {

    }

    [Generator]
    public class AutoDecoratorGenerator : ISourceGenerator
    {
        public void Initialize(GeneratorInitializationContext context)
        {
            context.RegisterForSyntaxNotifications(() => new DecoratedAttributeFieldsSyntaxReceiver());

            // Register the attribute source
            context.RegisterForPostInitialization(generatorPostInitializationContext =>
            {
                generatorPostInitializationContext.AddSource(nameof(RawSources.DecorateAttributeName), RawSources.DecorateAttribute);
                generatorPostInitializationContext.AddSource(nameof(RawSources.OverrideAttributeName), RawSources.OverrideAttribute);
            });
        }

        public void Execute(GeneratorExecutionContext context)
        {
#if DEBUG_AUTODECORATOR_GENERATOR
            if (!Debugger.IsAttached)
                Debugger.Launch();
#endif

            if (context.SyntaxContextReceiver is not DecoratedAttributeFieldsSyntaxReceiver receiver)
                return;

            // This is to please NRT. Attribute will always be present
            if (context.Compilation.GetTypeByMetadataName(RawSources.DecorateAttributeName) is not INamespaceOrTypeSymbol decorateSymbol)
                return;

            // This is to please NRT. Attribute will always be present
            if (context.Compilation.GetTypeByMetadataName(RawSources.OverrideAttributeName) is not INamespaceOrTypeSymbol overrideSymbol)
                return;

            var sw = Stopwatch.StartNew();
            foreach (var fieldSymbol in receiver.Fields)
            {
                // TODO: Group by type via foreach (IGrouping<INamedTypeSymbol, IFieldSymbol> group in receiver.Fields.GroupBy(f => f.ContainingType))
                // and check if there are conflicting fields or types
                // check if class is partial
                // check if class is public or internal
                // check if class is not static
                // check for conflicting fields
                var classSource = GeneratePartialClassSource(fieldSymbol.ContainingType, fieldSymbol, decorateSymbol, overrideSymbol, context);
                classSource.AppendLine($"// Source was generated in: {sw.Elapsed}");
                context.AddSource($"{fieldSymbol.ContainingType.Name}_AutoDecorated.cs", SourceText.From(classSource.ToString(), Encoding.UTF8));
            }
        }

        private StringBuilder GeneratePartialClassSource(INamedTypeSymbol classSymbol, IFieldSymbol fieldSymbol, ISymbol decorateSymbol, ISymbol overrideSymbol, GeneratorExecutionContext context)
        {
            // TODO: find a way to issue proper diagnostics

            if (!classSymbol.ContainingSymbol.Equals(classSymbol.ContainingNamespace, SymbolEqualityComparer.Default))
            {
                return new StringBuilder(); // TODO: issue a diagnostic that it must be top level
            }

            var namespaceName = classSymbol.ContainingNamespace.ToDisplayString();

            // Get methods and properties with OverrideSymbol

            var decoratedType = fieldSymbol.Type;

            var decoratedClassMembers = decoratedType.GetMembers(); // GetInterfaces ? Etc
            var classClassMembers = classSymbol.GetMembers();       // GetInterfaces ? Etc

            var decoratedInterfaces = decoratedType.Interfaces;

            var overridenMembers =
                classClassMembers
                   .AsEnumerable()
                   .Where(member => member.GetAttributes()
                                          .AsEnumerable()
                                          .Any(attribute => attribute.AttributeClass?.Equals(overrideSymbol, SymbolEqualityComparer.Default) ?? false))
                   .ToArray();

            // Check for validity

            var validOverridenMembers =
                overridenMembers
                   .Where(member => OverridenMethodHasMatchingMethodInDecorated(member, decoratedClassMembers)
                                 || OverridenMethodHasMatchingPropertyInDecorated(member, decoratedClassMembers))
                   .ToArray();

            // TODO: Add diagnostics

            // Now get members to Generate

            var membersToGenerate =
                decoratedClassMembers
                    .AsEnumerable()
                    .Where(member =>
                    {
                        var isNotValid =
                            SymbolIsConstructor(member)
                         || SymbolIsStaticMethod(member)
                         || SymbolIsStaticProperty(member)
                         || validOverridenMembers.Any(overriden => MatchMembersAsProperties(member, overriden)
                                                                || MatchMembersAsMethods(member, overriden));
                        return !isNotValid;
                    })
                    .ToArray();

            var propertiesToGenerate =
                membersToGenerate
                   .OfType<IPropertySymbol>()
                   .ToArray();

            var methodsToGenerate =
                membersToGenerate
                   .OfType<IMethodSymbol>()
                   .Where(method => !propertiesToGenerate.Any(property => IsMethodSameAsProperty(method, property)))
                   .ToArray();

            // TODO: Pass source through

            StringBuilder source = new($@"
namespace {namespaceName}
{{
    {GetUsingDeclarationsFromInterfacesOfDecoratedObjects(decoratedInterfaces)}

    {GetAccessibilityDisplayString(classSymbol.DeclaredAccessibility)} {GetPartialTypeClassificationSource(classSymbol)} {classSymbol.ToDisplayString(SymbolDisplayFormats.TypeNameAndGenericsFormat)}
        {(classSymbol.IsRefLikeType ? "" : $": {string.Join("," + Environment.NewLine, decoratedInterfaces.Select(GetInterfaceName))}")}
    {{
");

            foreach (var memberSymbol in propertiesToGenerate)
            {
                ProcessMember(source, fieldSymbol, memberSymbol);
            }

            foreach (var memberSymbol in methodsToGenerate)
            {
                ProcessMember(source, fieldSymbol, memberSymbol);
            }

            source.AppendLine("} }");
            return source;
        }

        private static string GetAccessibilityDisplayString(Accessibility accessibility)
        {
            return accessibility switch
            {
                Accessibility.Internal => "internal",
                Accessibility.Public   => "public",
                _                      => throw new NotSupportedException("Works only with public or internal classes")
            };
        }

        private static string GetUsingDeclarationsFromInterfacesOfDecoratedObjects(IEnumerable<INamedTypeSymbol> interfaces)
        {
            var namespaces = interfaces.Select(i => $"using {i.ContainingNamespace.ToDisplayString()};").Distinct();
            return string.Join(Environment.NewLine, namespaces);
        }

        private static bool IsMethodSameAsProperty(IMethodSymbol methodSymbol, IPropertySymbol propertySymbol)
        {
            if (methodSymbol.Equals(propertySymbol.SetMethod, SymbolEqualityComparer.Default))
                return true;

            if (methodSymbol.Equals(propertySymbol.GetMethod, SymbolEqualityComparer.Default))
                return true;

            return false;
        }

        private static void ProcessMember(StringBuilder source, IFieldSymbol fieldSymbol, ISymbol memberSymbol)
        {
            var fieldName = fieldSymbol.Name;

            switch (memberSymbol)
            {
                case IMethodSymbol method:
                    var isMethodFromInterface = IsMethodExplicitlyImplementedByInterface(method);
                    var methodSource = $"{GetMethodDeclarationSource(method)} {GetMethodImplementationSource(method, fieldName, isMethodFromInterface)}";
                    source.Append(methodSource);
                    source.AppendLine(";");
                    break;

                // Not every property is reported as IsIndexer = true, this is a workaround for https://github.com/dotnet/roslyn/issues/53911
                case IPropertySymbol { Parameters: { Length: > 0 } } indexerProperty:
                    var isIndexedFromInterface = IsPropertyExplicitlyImplementedByInterface(indexerProperty);
                    var indexedPropertySource =
                        $"{GetIndexerPropertyDeclarationSource(indexerProperty)} {GetIndexerPropertyImplementationSource(indexerProperty, fieldName, isIndexedFromInterface)}";
                    source.AppendLine(indexedPropertySource);
                    break;

                case IPropertySymbol property:
                    var isFromInterface = IsPropertyExplicitlyImplementedByInterface(property);
                    var propertySource = $"{GetPropertyDeclarationSource(property)} {GetPropertyImplementationSource(property, fieldName, isFromInterface)}";
                    source.AppendLine(propertySource);
                    break;
            }
        }

        private static string GetPartialTypeClassificationSource(INamedTypeSymbol symbol)
        {
            if (!symbol.IsValueType)
                return symbol.IsRecord
                    ? "partial record"
                    : "partial class";

            return symbol.IsRefLikeType
                ? "ref partial struct"
                : "partial struct";
        }

        private static bool IsPropertyExplicitlyImplementedByInterface(IPropertySymbol propertySymbol)
        {
            return propertySymbol.ExplicitInterfaceImplementations.Length > 0;
        }

        private static bool IsMethodExplicitlyImplementedByInterface(IMethodSymbol methodSymbol)
        {
            return methodSymbol.ExplicitInterfaceImplementations.Length > 0;
        }

        private static string GetInterfaceName(INamedTypeSymbol INamedTypeSymbol)
        {
            return INamedTypeSymbol.ToDisplayString();
        }

        private static string GetPropertyDeclarationSource(IPropertySymbol propertySymbol)
        {
            var accessibility = propertySymbol.DeclaredAccessibility;

            var format = accessibility == Accessibility.Public
                ? SymbolDisplayFormats.PropertyDeclarationFormat
                : SymbolDisplayFormats.ExplicitInterfacePropertyDeclarationFormat;

            return propertySymbol.ToDisplayString(format);
        }

        private static string GetIndexerPropertyDeclarationSource(IPropertySymbol propertySymbol)
        {
            // Workaround as some "Item" properties are not reported as indexers
            // https://github.com/dotnet/roslyn/issues/53911
            return GetPropertyDeclarationSource(propertySymbol).Replace("Item[", "this[");
        }

        private static string GetPropertyImplementationSource(IPropertySymbol propertySymbol, string decoratedFieldName, bool isExplicitlyFromInterface)
        {
            var interfaceCastSource = isExplicitlyFromInterface
                ? $"({propertySymbol.ExplicitInterfaceImplementations[0].ContainingType.ToDisplayString()})" // TODO extract interface name
                : "";

            var propertyName = propertySymbol.ToDisplayString(SymbolDisplayFormats.NameOnlyFormat);

            var getBodySource =
                propertySymbol.GetMethod is not null
                    ? $"get => ({interfaceCastSource}{decoratedFieldName}).{propertyName};"
                    : "";

            var setBodySource =
                propertySymbol.SetMethod is not null
                    ? $"set => ({interfaceCastSource}{decoratedFieldName}).{propertyName} = value;"
                    : "";

            return $"{{ {getBodySource} {setBodySource} }}";
        }

        private static string GetIndexerPropertyImplementationSource(IPropertySymbol propertySymbol, string decoratedFieldName, bool isExplicitlyFromInterface)
        {
            var parametersNamesOnly = propertySymbol.Parameters.Select(param => $"{param.Name}");

            var parameterNamesOnlyString = string.Join(", ", parametersNamesOnly);

            var interfaceCastSource = isExplicitlyFromInterface
                ? $"({propertySymbol.ExplicitInterfaceImplementations[0].ContainingType.ToDisplayString()})" // TODO extract interface name
                : "";

            var getBodySource =
                propertySymbol.GetMethod is not null
                    ? $"get => ({interfaceCastSource}{decoratedFieldName})[{parameterNamesOnlyString}];"
                    : "";

            var setBodySource =
                propertySymbol.SetMethod is not null
                    ? $"set => ({interfaceCastSource}{decoratedFieldName})[{parameterNamesOnlyString}] = value;"
                    : "";


            return $"{{ {getBodySource} {setBodySource} }} ";
        }


        private static string GetMethodDeclarationSource(IMethodSymbol methodSymbol)
        {
            var accessibility = methodSymbol.DeclaredAccessibility;

            var format = accessibility == Accessibility.Public // TODO: Internal?
                ? SymbolDisplayFormats.MethodDeclarationFormat
                : SymbolDisplayFormats.ExplicitInterfaceMethodDeclarationFormat;

            return methodSymbol.ToDisplayString(format);
        }

        private static string GetMethodImplementationSource(IMethodSymbol methodSymbol, string decoratedFieldName, bool isFromInterface)
        {
            var interfaceCastSource = isFromInterface
                ? $"({methodSymbol.ExplicitInterfaceImplementations[0].ContainingType.ToDisplayString()})"
                : "";

            var parameters = string.Join(", ", methodSymbol.Parameters.Select(param => $"{GetRefKindString(param.RefKind)} {param.Name}"));

            return $"=> ({interfaceCastSource}{decoratedFieldName}).{methodSymbol.ToDisplayString(SymbolDisplayFormats.NameOnlyFormat)}({parameters})";
        }

        private static string GetRefKindString(RefKind refKind) => refKind switch
        {
            RefKind.None => "",
            RefKind.In   => "in", // TODO: RefReadonly = In
            RefKind.Ref  => "ref",
            RefKind.Out  => "out",
            _            => throw new NotSupportedException($"Unexpected enum type: {refKind.ToString()}")
        };

        private static bool SymbolIsConstructor(ISymbol symbol) => symbol is IMethodSymbol { Name: ".ctor" };
        private static bool SymbolIsStaticMethod(ISymbol symbol) => symbol is IMethodSymbol { IsStatic: true };
        private static bool SymbolIsStaticProperty(ISymbol symbol) => symbol is IPropertySymbol { IsStatic: true };

        private static bool MatchMembersAsProperties(ISymbol fromDecorated, ISymbol fromOverriden)
        {
            if (fromDecorated is not IPropertySymbol decoratedProp
             || fromOverriden is not IPropertySymbol overridenProp)
                return false;

            if (!decoratedProp.Name.Equals(overridenProp.Name, StringComparison.Ordinal))
                return false;

            if (!decoratedProp.Type.Equals(overridenProp.Type, SymbolEqualityComparer.Default))
                return false;
            //context.ReportDiagnostic(null); // TODO: Diagnostics

            return true;
        }

        private static bool MatchMembersAsMethods(ISymbol fromDecorated, ISymbol fromOverriden)
        {
            if (fromDecorated is not IMethodSymbol decoratedMethod
             || fromOverriden is not IMethodSymbol overridenMethod)
                return false;

            if (!decoratedMethod.Name.Equals(overridenMethod.Name, StringComparison.Ordinal))
                return false;

            if (!decoratedMethod.ReturnType.Equals(overridenMethod.ReturnType, SymbolEqualityComparer.Default))
                return false;

            var decoratedParams = decoratedMethod.Parameters;
            var overridenParams = overridenMethod.Parameters;

            if (decoratedParams.Length != overridenParams.Length)
                return false;

            for (var i = 0; i < decoratedParams.Length; i++)
            {
                if (decoratedParams[i].Equals(overridenParams[i], SymbolEqualityComparer.Default))
                    return false;
            }

            return true;
        }

        private static bool OverridenMethodHasMatchingMethodInDecorated(ISymbol fromDecorated, IEnumerable<ISymbol> fromOverriden) =>
            fromOverriden.Any(symbol => MatchMembersAsMethods(fromDecorated, symbol));

        private static bool OverridenMethodHasMatchingPropertyInDecorated(ISymbol fromDecorated, IEnumerable<ISymbol> fromOverriden) =>
            fromOverriden.Any(symbol => MatchMembersAsProperties(fromDecorated, symbol));
    }

    /// <summary>
    /// Created on demand before each generation pass
    /// </summary>
    internal class DecoratedAttributeFieldsSyntaxReceiver : ISyntaxContextReceiver
    {
        public List<IFieldSymbol> Fields { get; } = new();

        /// <summary>
        /// Called for every syntax node in the compilation, we can inspect the nodes and save any information useful for generation
        /// </summary>
        public void OnVisitSyntaxNode(GeneratorSyntaxContext context)
        {
#if DEBUG_AUTODECORATOR_GENERATOR
            if (!Debugger.IsAttached)
                Debugger.Launch();
#endif

            // any field with at least one attribute is a candidate for property generation
            if (context.Node is FieldDeclarationSyntax { AttributeLists: { Count: > 0 } } fieldDeclarationSyntax)
            {
                foreach (var variable in fieldDeclarationSyntax.Declaration.Variables)
                {
                    // Get the symbol being declared by the field, and keep it if its annotated
                    if (context.SemanticModel.GetDeclaredSymbol(variable) is IFieldSymbol fieldSymbol
                     && fieldSymbol.GetAttributes().Any(ad => ad.AttributeClass?.ToDisplayString() == RawSources.DecorateAttributeName))
                    {
                        Fields.Add(fieldSymbol);
                        break;
                    }
                }
            }
        }
    }
}

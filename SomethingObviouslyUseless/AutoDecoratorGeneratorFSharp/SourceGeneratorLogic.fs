namespace AutoDecoratorGeneratorFSharp.SourceGeneration

open Microsoft.CodeAnalysis

module RawSources =
    let [<Literal>] DecorateAttributeSource = @"
using System;

namespace AutoDecorated
{
    /// <summary>
    /// Placed on a field of a class or struct to indicate a decoration base
    /// </summary>
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    public sealed class DecorateAttribute : Attribute { }
}
"
    let [<Literal>] DecorateAttributeName = ""
    let [<Literal>] OverrideAttributeSource = ""
    let [<Literal>] OverrideAttributeName = ""

[<AbstractClass>]
type DisplayFormats =
    static member PropertyDeclarationFormat =
        SymbolDisplayFormat(
            globalNamespaceStyle = SymbolDisplayGlobalNamespaceStyle.Omitted,
            typeQualificationStyle = SymbolDisplayTypeQualificationStyle.NameAndContainingTypesAndNamespaces,
            genericsOptions = (SymbolDisplayGenericsOptions.IncludeTypeParameters
                           ||| SymbolDisplayGenericsOptions.IncludeTypeConstraints
                           ||| SymbolDisplayGenericsOptions.IncludeVariance),
            memberOptions = (SymbolDisplayMemberOptions.IncludeAccessibility
                         ||| SymbolDisplayMemberOptions.IncludeParameters
                         ||| SymbolDisplayMemberOptions.IncludeExplicitInterface
                         ||| SymbolDisplayMemberOptions.IncludeType
                         ||| SymbolDisplayMemberOptions.IncludeModifiers
                         ||| SymbolDisplayMemberOptions.IncludeExplicitInterface
                         ||| SymbolDisplayMemberOptions.IncludeConstantValue),
            delegateStyle = SymbolDisplayDelegateStyle.NameAndSignature,
            extensionMethodStyle = SymbolDisplayExtensionMethodStyle.InstanceMethod,
            parameterOptions = (SymbolDisplayParameterOptions.IncludeName
                            ||| SymbolDisplayParameterOptions.IncludeType
                            ||| SymbolDisplayParameterOptions.IncludeDefaultValue
                            ||| SymbolDisplayParameterOptions.IncludeParamsRefOut),
            propertyStyle = SymbolDisplayPropertyStyle.NameOnly,
            localOptions = SymbolDisplayLocalOptions.IncludeType,
            kindOptions = SymbolDisplayKindOptions.IncludeNamespaceKeyword,
            miscellaneousOptions = SymbolDisplayMiscellaneousOptions.UseSpecialTypes
        )

    
    static member NameOnlyFormat =
        SymbolDisplayFormat(
            propertyStyle = SymbolDisplayPropertyStyle.NameOnly
        )

    static member TypeNameAndGenericsFormat =
        SymbolDisplayFormat(
            globalNamespaceStyle = SymbolDisplayGlobalNamespaceStyle.Omitted,
            typeQualificationStyle = SymbolDisplayTypeQualificationStyle.NameOnly,
            genericsOptions = (SymbolDisplayGenericsOptions.IncludeTypeParameters
                           ||| SymbolDisplayGenericsOptions.IncludeTypeConstraints
                           ||| SymbolDisplayGenericsOptions.IncludeVariance),
            memberOptions = (SymbolDisplayMemberOptions.IncludeParameters
                         ||| SymbolDisplayMemberOptions.IncludeExplicitInterface
                         ||| SymbolDisplayMemberOptions.IncludeType
                         ||| SymbolDisplayMemberOptions.IncludeModifiers
                         ||| SymbolDisplayMemberOptions.IncludeExplicitInterface
                         ||| SymbolDisplayMemberOptions.IncludeConstantValue),
            delegateStyle = SymbolDisplayDelegateStyle.NameAndSignature,
            extensionMethodStyle = SymbolDisplayExtensionMethodStyle.InstanceMethod,
            parameterOptions = (SymbolDisplayParameterOptions.IncludeName
                            ||| SymbolDisplayParameterOptions.IncludeType
                            ||| SymbolDisplayParameterOptions.IncludeDefaultValue
                            ||| SymbolDisplayParameterOptions.IncludeParamsRefOut),
            propertyStyle = SymbolDisplayPropertyStyle.NameOnly,
            localOptions = SymbolDisplayLocalOptions.IncludeType,
            kindOptions = SymbolDisplayKindOptions.IncludeNamespaceKeyword,
            miscellaneousOptions = SymbolDisplayMiscellaneousOptions.UseSpecialTypes
        )

    static member ExplicitInterfacePropertyDeclarationFormat =
        SymbolDisplayFormat(
            globalNamespaceStyle = SymbolDisplayGlobalNamespaceStyle.Omitted,
            typeQualificationStyle = SymbolDisplayTypeQualificationStyle.NameAndContainingTypesAndNamespaces,
            genericsOptions = (SymbolDisplayGenericsOptions.IncludeTypeParameters
                           ||| SymbolDisplayGenericsOptions.IncludeTypeConstraints
                           ||| SymbolDisplayGenericsOptions.IncludeVariance),
            memberOptions = (SymbolDisplayMemberOptions.IncludeParameters
                         ||| SymbolDisplayMemberOptions.IncludeExplicitInterface
                         ||| SymbolDisplayMemberOptions.IncludeType
                         ||| SymbolDisplayMemberOptions.IncludeModifiers
                         ||| SymbolDisplayMemberOptions.IncludeExplicitInterface
                         ||| SymbolDisplayMemberOptions.IncludeConstantValue),
            delegateStyle = SymbolDisplayDelegateStyle.NameAndSignature,
            extensionMethodStyle = SymbolDisplayExtensionMethodStyle.InstanceMethod,
            parameterOptions = (SymbolDisplayParameterOptions.IncludeName
                            ||| SymbolDisplayParameterOptions.IncludeType
                            ||| SymbolDisplayParameterOptions.IncludeDefaultValue
                            ||| SymbolDisplayParameterOptions.IncludeParamsRefOut),
            propertyStyle = SymbolDisplayPropertyStyle.NameOnly,
            localOptions = SymbolDisplayLocalOptions.IncludeType,
            kindOptions = SymbolDisplayKindOptions.IncludeNamespaceKeyword,
            miscellaneousOptions = SymbolDisplayMiscellaneousOptions.UseSpecialTypes
        )

    static member MethodDeclarationFormat =
        SymbolDisplayFormat(
            globalNamespaceStyle = SymbolDisplayGlobalNamespaceStyle.Omitted,
            typeQualificationStyle = SymbolDisplayTypeQualificationStyle.NameAndContainingTypesAndNamespaces,
            genericsOptions = (SymbolDisplayGenericsOptions.IncludeTypeParameters
                           ||| SymbolDisplayGenericsOptions.IncludeTypeConstraints
                           ||| SymbolDisplayGenericsOptions.IncludeVariance),
            memberOptions = (SymbolDisplayMemberOptions.IncludeAccessibility
                         ||| SymbolDisplayMemberOptions.IncludeParameters
                         ||| SymbolDisplayMemberOptions.IncludeExplicitInterface
                         ||| SymbolDisplayMemberOptions.IncludeType
                         ||| SymbolDisplayMemberOptions.IncludeModifiers
                         ||| SymbolDisplayMemberOptions.IncludeExplicitInterface
                         ||| SymbolDisplayMemberOptions.IncludeConstantValue),
            delegateStyle = SymbolDisplayDelegateStyle.NameAndSignature,
            extensionMethodStyle = SymbolDisplayExtensionMethodStyle.InstanceMethod,
            parameterOptions = (SymbolDisplayParameterOptions.IncludeName
                            ||| SymbolDisplayParameterOptions.IncludeType
                            ||| SymbolDisplayParameterOptions.IncludeDefaultValue
                            ||| SymbolDisplayParameterOptions.IncludeParamsRefOut),
            propertyStyle = SymbolDisplayPropertyStyle.NameOnly,
            localOptions = SymbolDisplayLocalOptions.IncludeType,
            kindOptions = SymbolDisplayKindOptions.IncludeNamespaceKeyword,
            miscellaneousOptions = SymbolDisplayMiscellaneousOptions.UseSpecialTypes
        )

    static member ExplicitInterfaceMethodDeclarationFormat =
        SymbolDisplayFormat(
            globalNamespaceStyle = SymbolDisplayGlobalNamespaceStyle.Omitted,
            typeQualificationStyle = SymbolDisplayTypeQualificationStyle.NameAndContainingTypesAndNamespaces,
            genericsOptions = (SymbolDisplayGenericsOptions.IncludeTypeParameters
                           ||| SymbolDisplayGenericsOptions.IncludeTypeConstraints
                           ||| SymbolDisplayGenericsOptions.IncludeVariance),
            memberOptions = (SymbolDisplayMemberOptions.IncludeParameters
                         ||| SymbolDisplayMemberOptions.IncludeExplicitInterface
                         ||| SymbolDisplayMemberOptions.IncludeType
                         ||| SymbolDisplayMemberOptions.IncludeModifiers
                         ||| SymbolDisplayMemberOptions.IncludeExplicitInterface
                         ||| SymbolDisplayMemberOptions.IncludeConstantValue),
            delegateStyle = SymbolDisplayDelegateStyle.NameAndSignature,
            extensionMethodStyle = SymbolDisplayExtensionMethodStyle.InstanceMethod,
            parameterOptions = (SymbolDisplayParameterOptions.IncludeName
                            ||| SymbolDisplayParameterOptions.IncludeType
                            ||| SymbolDisplayParameterOptions.IncludeDefaultValue
                            ||| SymbolDisplayParameterOptions.IncludeParamsRefOut),
            propertyStyle = SymbolDisplayPropertyStyle.NameOnly,
            localOptions = SymbolDisplayLocalOptions.IncludeType,
            kindOptions = SymbolDisplayKindOptions.IncludeNamespaceKeyword,
            miscellaneousOptions = SymbolDisplayMiscellaneousOptions.UseSpecialTypes
        )

module PrettyPrinting =
    let getInterfaceName (symbol: INamedTypeSymbol) = symbol.ToDisplayString()
    
    let getPropertyDeclarationSource (propertySymbol: IPropertySymbol ) =
            let format =
                match propertySymbol.DeclaredAccessibility with
                | Accessibility.Public -> DisplayFormats.PropertyDeclarationFormat
                | _ -> DisplayFormats.ExplicitInterfacePropertyDeclarationFormat
                
            propertySymbol.ToDisplayString(format);

    // Workaround as some "Item" properties are not reported as indexers
    // https://github.com/dotnet/roslyn/issues/53911
    let getIndexerPropertyDeclarationSource (propertySymbol: IPropertySymbol ) =
        getPropertyDeclarationSource(propertySymbol).Replace("Item[", "this[");

type GenerationError =
    | OverridenMethodIsNotFound of Method: IMethodSymbol
    | OverridenPropertyIsNotFound of Property: IPropertySymbol
    | OverrideAttributeIsMissingOnProperty of Property: IPropertySymbol
    | OverrideAttributeIsMissingOnMethod of Method: IMethodSymbol
    | TypeIsStatic of Type: INamedTypeSymbol
    | TypeIsNotPartial of Type: INamedTypeSymbol
    | TypeCannotBeDecoratorOfRefStruct of Type: INamedTypeSymbol
    | TypeIsNotPublicOrInternal

type GeneratedSource = StringBuilder

type GenerationResult = Result<GeneratedSource, GenerationError>

module SourceGeneratorLogic =
    let initialize (context: GeneratorInitializationContext) = ()
    let execute (context: GeneratorExecutionContext) = ()
using Microsoft.CodeAnalysis;

namespace AutoDecoratorGenerator
{
    internal static class SymbolDisplayFormats
    {
        // TODO: Clear out unnecessary options

        public static SymbolDisplayFormat PropertyDeclarationFormat { get; } = new(
            globalNamespaceStyle: SymbolDisplayGlobalNamespaceStyle.Omitted,
            typeQualificationStyle: SymbolDisplayTypeQualificationStyle.NameAndContainingTypesAndNamespaces,
            genericsOptions: SymbolDisplayGenericsOptions.IncludeTypeParameters
                           | SymbolDisplayGenericsOptions.IncludeTypeConstraints
                           | SymbolDisplayGenericsOptions.IncludeVariance,
            memberOptions: SymbolDisplayMemberOptions.IncludeAccessibility
                         | SymbolDisplayMemberOptions.IncludeParameters
                         | SymbolDisplayMemberOptions.IncludeExplicitInterface
                         | SymbolDisplayMemberOptions.IncludeType
                         | SymbolDisplayMemberOptions.IncludeModifiers
                         | SymbolDisplayMemberOptions.IncludeExplicitInterface
                         | SymbolDisplayMemberOptions.IncludeConstantValue,
            delegateStyle: SymbolDisplayDelegateStyle.NameAndSignature,
            extensionMethodStyle: SymbolDisplayExtensionMethodStyle.InstanceMethod,
            parameterOptions: SymbolDisplayParameterOptions.IncludeName
                            | SymbolDisplayParameterOptions.IncludeType
                            | SymbolDisplayParameterOptions.IncludeDefaultValue
                            | SymbolDisplayParameterOptions.IncludeParamsRefOut,
            propertyStyle: SymbolDisplayPropertyStyle.NameOnly,
            localOptions: SymbolDisplayLocalOptions.IncludeType,
            kindOptions: SymbolDisplayKindOptions.IncludeNamespaceKeyword,
            miscellaneousOptions: SymbolDisplayMiscellaneousOptions.UseSpecialTypes
        );

        public static SymbolDisplayFormat NameOnlyFormat { get; } = new(
            propertyStyle: SymbolDisplayPropertyStyle.NameOnly
        );

        public static SymbolDisplayFormat TypeNameAndGenericsFormat { get; } = new(
            globalNamespaceStyle: SymbolDisplayGlobalNamespaceStyle.Omitted,
            typeQualificationStyle: SymbolDisplayTypeQualificationStyle.NameOnly,
            genericsOptions: SymbolDisplayGenericsOptions.IncludeTypeParameters
                           | SymbolDisplayGenericsOptions.IncludeTypeConstraints
                           | SymbolDisplayGenericsOptions.IncludeVariance,
            memberOptions: SymbolDisplayMemberOptions.IncludeParameters
                         | SymbolDisplayMemberOptions.IncludeExplicitInterface
                         | SymbolDisplayMemberOptions.IncludeType
                         | SymbolDisplayMemberOptions.IncludeModifiers
                         | SymbolDisplayMemberOptions.IncludeExplicitInterface
                         | SymbolDisplayMemberOptions.IncludeConstantValue,
            delegateStyle: SymbolDisplayDelegateStyle.NameAndSignature,
            extensionMethodStyle: SymbolDisplayExtensionMethodStyle.InstanceMethod,
            parameterOptions: SymbolDisplayParameterOptions.IncludeName
                            | SymbolDisplayParameterOptions.IncludeType
                            | SymbolDisplayParameterOptions.IncludeDefaultValue
                            | SymbolDisplayParameterOptions.IncludeParamsRefOut,
            propertyStyle: SymbolDisplayPropertyStyle.NameOnly,
            localOptions: SymbolDisplayLocalOptions.IncludeType,
            kindOptions: SymbolDisplayKindOptions.IncludeNamespaceKeyword,
            miscellaneousOptions: SymbolDisplayMiscellaneousOptions.UseSpecialTypes
        );

        public static SymbolDisplayFormat ExplicitInterfacePropertyDeclarationFormat { get; } = new(
            globalNamespaceStyle: SymbolDisplayGlobalNamespaceStyle.Omitted,
            typeQualificationStyle: SymbolDisplayTypeQualificationStyle.NameAndContainingTypesAndNamespaces,
            genericsOptions: SymbolDisplayGenericsOptions.IncludeTypeParameters
                           | SymbolDisplayGenericsOptions.IncludeTypeConstraints
                           | SymbolDisplayGenericsOptions.IncludeVariance,
            memberOptions: SymbolDisplayMemberOptions.IncludeParameters
                         | SymbolDisplayMemberOptions.IncludeExplicitInterface
                         | SymbolDisplayMemberOptions.IncludeType
                         | SymbolDisplayMemberOptions.IncludeModifiers
                         | SymbolDisplayMemberOptions.IncludeExplicitInterface
                         | SymbolDisplayMemberOptions.IncludeConstantValue,
            delegateStyle: SymbolDisplayDelegateStyle.NameAndSignature,
            extensionMethodStyle: SymbolDisplayExtensionMethodStyle.InstanceMethod,
            parameterOptions: SymbolDisplayParameterOptions.IncludeName
                            | SymbolDisplayParameterOptions.IncludeType
                            | SymbolDisplayParameterOptions.IncludeDefaultValue
                            | SymbolDisplayParameterOptions.IncludeParamsRefOut,
            propertyStyle: SymbolDisplayPropertyStyle.NameOnly,
            localOptions: SymbolDisplayLocalOptions.IncludeType,
            kindOptions: SymbolDisplayKindOptions.IncludeNamespaceKeyword,
            miscellaneousOptions: SymbolDisplayMiscellaneousOptions.UseSpecialTypes
        );

        public static SymbolDisplayFormat MethodDeclarationFormat { get; } = new(
            globalNamespaceStyle: SymbolDisplayGlobalNamespaceStyle.Omitted,
            typeQualificationStyle: SymbolDisplayTypeQualificationStyle.NameAndContainingTypesAndNamespaces,
            genericsOptions: SymbolDisplayGenericsOptions.IncludeTypeParameters
                           | SymbolDisplayGenericsOptions.IncludeTypeConstraints
                           | SymbolDisplayGenericsOptions.IncludeVariance,
            memberOptions: SymbolDisplayMemberOptions.IncludeAccessibility
                         | SymbolDisplayMemberOptions.IncludeParameters
                         | SymbolDisplayMemberOptions.IncludeExplicitInterface
                         | SymbolDisplayMemberOptions.IncludeType
                         | SymbolDisplayMemberOptions.IncludeModifiers
                         | SymbolDisplayMemberOptions.IncludeExplicitInterface
                         | SymbolDisplayMemberOptions.IncludeConstantValue,
            delegateStyle: SymbolDisplayDelegateStyle.NameAndSignature,
            extensionMethodStyle: SymbolDisplayExtensionMethodStyle.InstanceMethod,
            parameterOptions: SymbolDisplayParameterOptions.IncludeName
                            | SymbolDisplayParameterOptions.IncludeType
                            | SymbolDisplayParameterOptions.IncludeDefaultValue
                            | SymbolDisplayParameterOptions.IncludeParamsRefOut,
            propertyStyle: SymbolDisplayPropertyStyle.NameOnly,
            localOptions: SymbolDisplayLocalOptions.IncludeType,
            kindOptions: SymbolDisplayKindOptions.IncludeNamespaceKeyword,
            miscellaneousOptions: SymbolDisplayMiscellaneousOptions.UseSpecialTypes
        );

        public static SymbolDisplayFormat ExplicitInterfaceMethodDeclarationFormat { get; } = new(
            globalNamespaceStyle: SymbolDisplayGlobalNamespaceStyle.Omitted,
            typeQualificationStyle: SymbolDisplayTypeQualificationStyle.NameAndContainingTypesAndNamespaces,
            genericsOptions: SymbolDisplayGenericsOptions.IncludeTypeParameters
                           | SymbolDisplayGenericsOptions.IncludeTypeConstraints
                           | SymbolDisplayGenericsOptions.IncludeVariance,
            memberOptions: SymbolDisplayMemberOptions.IncludeParameters
                         | SymbolDisplayMemberOptions.IncludeExplicitInterface
                         | SymbolDisplayMemberOptions.IncludeType
                         | SymbolDisplayMemberOptions.IncludeModifiers
                         | SymbolDisplayMemberOptions.IncludeExplicitInterface
                         | SymbolDisplayMemberOptions.IncludeConstantValue,
            delegateStyle: SymbolDisplayDelegateStyle.NameAndSignature,
            extensionMethodStyle: SymbolDisplayExtensionMethodStyle.InstanceMethod,
            parameterOptions: SymbolDisplayParameterOptions.IncludeName
                            | SymbolDisplayParameterOptions.IncludeType
                            | SymbolDisplayParameterOptions.IncludeDefaultValue
                            | SymbolDisplayParameterOptions.IncludeParamsRefOut,
            propertyStyle: SymbolDisplayPropertyStyle.NameOnly,
            localOptions: SymbolDisplayLocalOptions.IncludeType,
            kindOptions: SymbolDisplayKindOptions.IncludeNamespaceKeyword,
            miscellaneousOptions: SymbolDisplayMiscellaneousOptions.UseSpecialTypes
        );
    }
}
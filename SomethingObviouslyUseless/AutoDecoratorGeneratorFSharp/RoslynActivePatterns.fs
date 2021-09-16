namespace AutoDecoratorGeneratorFSharp.RoslynActivePatterns

module IAddressOfOperation =
    let inline Reference a = (^a: (member Reference: ^b) a)
    let inline (|Reference|) a = (^a: (member Reference: ^b) a)

module IAliasSymbol =
    let inline Target a = (^a: (member Target: ^b) a)
    let inline (|Target|) a = (^a: (member Target: ^b) a)

module IAnonymousFunctionOperation =
    let inline Symbol a = (^a: (member Symbol: ^b) a)
    let inline Body a = (^a: (member Body: ^b) a)
    let inline (|Symbol|) a = (^a: (member Symbol: ^b) a)
    let inline (|Body|) a = (^a: (member Body: ^b) a)

module IAnonymousObjectCreationOperation =
    let inline Initializers a = (^a: (member Initializers: ^b) a)
    let inline (|Initializers|) a = (^a: (member Initializers: ^b) a)

module IArgumentOperation =
    let inline ArgumentKind a = (^a: (member ArgumentKind: ^b) a)
    let inline Parameter a = (^a: (member Parameter: ^b) a)
    let inline Value a = (^a: (member Value: ^b) a)
    let inline InConversion a = (^a: (member InConversion: ^b) a)
    let inline OutConversion a = (^a: (member OutConversion: ^b) a)
    let inline (|ArgumentKind|) a = (^a: (member ArgumentKind: ^b) a)
    let inline (|Parameter|) a = (^a: (member Parameter: ^b) a)
    let inline (|Value|) a = (^a: (member Value: ^b) a)
    let inline (|InConversion|) a = (^a: (member InConversion: ^b) a)
    let inline (|OutConversion|) a = (^a: (member OutConversion: ^b) a)

module IArrayCreationOperation =
    let inline DimensionSizes a = (^a: (member DimensionSizes: ^b) a)
    let inline Initializer a = (^a: (member Initializer: ^b) a)
    let inline (|DimensionSizes|) a = (^a: (member DimensionSizes: ^b) a)
    let inline (|Initializer|) a = (^a: (member Initializer: ^b) a)

module IArrayElementReferenceOperation =
    let inline ArrayReference a = (^a: (member ArrayReference: ^b) a)
    let inline Indices a = (^a: (member Indices: ^b) a)
    let inline (|ArrayReference|) a = (^a: (member ArrayReference: ^b) a)
    let inline (|Indices|) a = (^a: (member Indices: ^b) a)

module IArrayInitializerOperation =
    let inline ElementValues a = (^a: (member ElementValues: ^b) a)
    let inline (|ElementValues|) a = (^a: (member ElementValues: ^b) a)

module IArrayTypeSymbol =
    let inline Rank a = (^a: (member Rank: ^b) a)
    let inline IsSZArray a = (^a: (member IsSZArray: ^b) a)
    let inline LowerBounds a = (^a: (member LowerBounds: ^b) a)
    let inline Sizes a = (^a: (member Sizes: ^b) a)
    let inline ElementType a = (^a: (member ElementType: ^b) a)
    let inline ElementNullableAnnotation a = (^a: (member ElementNullableAnnotation: ^b) a)
    let inline CustomModifiers a = (^a: (member CustomModifiers: ^b) a)
    let inline (|Rank|) a = (^a: (member Rank: ^b) a)
    let inline (|IsSZArray|) a = (^a: (member IsSZArray: ^b) a)
    let inline (|LowerBounds|) a = (^a: (member LowerBounds: ^b) a)
    let inline (|Sizes|) a = (^a: (member Sizes: ^b) a)
    let inline (|ElementType|) a = (^a: (member ElementType: ^b) a)
    let inline (|ElementNullableAnnotation|) a = (^a: (member ElementNullableAnnotation: ^b) a)
    let inline (|CustomModifiers|) a = (^a: (member CustomModifiers: ^b) a)

module IAssemblySymbol =
    let inline IsInteractive a = (^a: (member IsInteractive: ^b) a)
    let inline Identity a = (^a: (member Identity: ^b) a)
    let inline GlobalNamespace a = (^a: (member GlobalNamespace: ^b) a)
    let inline Modules a = (^a: (member Modules: ^b) a)
    let inline TypeNames a = (^a: (member TypeNames: ^b) a)
    let inline NamespaceNames a = (^a: (member NamespaceNames: ^b) a)
    let inline MightContainExtensionMethods a = (^a: (member MightContainExtensionMethods: ^b) a)
    let inline (|IsInteractive|) a = (^a: (member IsInteractive: ^b) a)
    let inline (|Identity|) a = (^a: (member Identity: ^b) a)
    let inline (|GlobalNamespace|) a = (^a: (member GlobalNamespace: ^b) a)
    let inline (|Modules|) a = (^a: (member Modules: ^b) a)
    let inline (|TypeNames|) a = (^a: (member TypeNames: ^b) a)
    let inline (|NamespaceNames|) a = (^a: (member NamespaceNames: ^b) a)
    let inline (|MightContainExtensionMethods|) a = (^a: (member MightContainExtensionMethods: ^b) a)

module IAssignmentOperation =
    let inline Target a = (^a: (member Target: ^b) a)
    let inline Value a = (^a: (member Value: ^b) a)
    let inline (|Target|) a = (^a: (member Target: ^b) a)
    let inline (|Value|) a = (^a: (member Value: ^b) a)

module IAwaitOperation =
    let inline Operation a = (^a: (member Operation: ^b) a)
    let inline (|Operation|) a = (^a: (member Operation: ^b) a)

module IBinaryOperation =
    let inline OperatorKind a = (^a: (member OperatorKind: ^b) a)
    let inline LeftOperand a = (^a: (member LeftOperand: ^b) a)
    let inline RightOperand a = (^a: (member RightOperand: ^b) a)
    let inline IsLifted a = (^a: (member IsLifted: ^b) a)
    let inline IsChecked a = (^a: (member IsChecked: ^b) a)
    let inline IsCompareText a = (^a: (member IsCompareText: ^b) a)
    let inline OperatorMethod a = (^a: (member OperatorMethod: ^b) a)
    let inline (|OperatorKind|) a = (^a: (member OperatorKind: ^b) a)
    let inline (|LeftOperand|) a = (^a: (member LeftOperand: ^b) a)
    let inline (|RightOperand|) a = (^a: (member RightOperand: ^b) a)
    let inline (|IsLifted|) a = (^a: (member IsLifted: ^b) a)
    let inline (|IsChecked|) a = (^a: (member IsChecked: ^b) a)
    let inline (|IsCompareText|) a = (^a: (member IsCompareText: ^b) a)
    let inline (|OperatorMethod|) a = (^a: (member OperatorMethod: ^b) a)

module IBinaryPatternOperation =
    let inline OperatorKind a = (^a: (member OperatorKind: ^b) a)
    let inline LeftPattern a = (^a: (member LeftPattern: ^b) a)
    let inline RightPattern a = (^a: (member RightPattern: ^b) a)
    let inline (|OperatorKind|) a = (^a: (member OperatorKind: ^b) a)
    let inline (|LeftPattern|) a = (^a: (member LeftPattern: ^b) a)
    let inline (|RightPattern|) a = (^a: (member RightPattern: ^b) a)

module IBlockOperation =
    let inline Operations a = (^a: (member Operations: ^b) a)
    let inline Locals a = (^a: (member Locals: ^b) a)
    let inline (|Operations|) a = (^a: (member Operations: ^b) a)
    let inline (|Locals|) a = (^a: (member Locals: ^b) a)

module IBranchOperation =
    let inline Target a = (^a: (member Target: ^b) a)
    let inline BranchKind a = (^a: (member BranchKind: ^b) a)
    let inline (|Target|) a = (^a: (member Target: ^b) a)
    let inline (|BranchKind|) a = (^a: (member BranchKind: ^b) a)

module ICaseClauseOperation =
    let inline CaseKind a = (^a: (member CaseKind: ^b) a)
    let inline Label a = (^a: (member Label: ^b) a)
    let inline (|CaseKind|) a = (^a: (member CaseKind: ^b) a)
    let inline (|Label|) a = (^a: (member Label: ^b) a)

module ICatchClauseOperation =
    let inline ExceptionDeclarationOrExpression a = (^a: (member ExceptionDeclarationOrExpression: ^b) a)
    let inline ExceptionType a = (^a: (member ExceptionType: ^b) a)
    let inline Locals a = (^a: (member Locals: ^b) a)
    let inline Filter a = (^a: (member Filter: ^b) a)
    let inline Handler a = (^a: (member Handler: ^b) a)
    let inline (|ExceptionDeclarationOrExpression|) a = (^a: (member ExceptionDeclarationOrExpression: ^b) a)
    let inline (|ExceptionType|) a = (^a: (member ExceptionType: ^b) a)
    let inline (|Locals|) a = (^a: (member Locals: ^b) a)
    let inline (|Filter|) a = (^a: (member Filter: ^b) a)
    let inline (|Handler|) a = (^a: (member Handler: ^b) a)

module ICoalesceOperation =
    let inline Value a = (^a: (member Value: ^b) a)
    let inline WhenNull a = (^a: (member WhenNull: ^b) a)
    let inline ValueConversion a = (^a: (member ValueConversion: ^b) a)
    let inline (|Value|) a = (^a: (member Value: ^b) a)
    let inline (|WhenNull|) a = (^a: (member WhenNull: ^b) a)
    let inline (|ValueConversion|) a = (^a: (member ValueConversion: ^b) a)

module ICollectionElementInitializerOperation =
    let inline AddMethod a = (^a: (member AddMethod: ^b) a)
    let inline Arguments a = (^a: (member Arguments: ^b) a)
    let inline IsDynamic a = (^a: (member IsDynamic: ^b) a)
    let inline (|AddMethod|) a = (^a: (member AddMethod: ^b) a)
    let inline (|Arguments|) a = (^a: (member Arguments: ^b) a)
    let inline (|IsDynamic|) a = (^a: (member IsDynamic: ^b) a)

module ICompilationUnitSyntax =
    let inline EndOfFileToken a = (^a: (member EndOfFileToken: ^b) a)
    let inline (|EndOfFileToken|) a = (^a: (member EndOfFileToken: ^b) a)

module ICompoundAssignmentOperation =
    let inline InConversion a = (^a: (member InConversion: ^b) a)
    let inline OutConversion a = (^a: (member OutConversion: ^b) a)
    let inline OperatorKind a = (^a: (member OperatorKind: ^b) a)
    let inline IsLifted a = (^a: (member IsLifted: ^b) a)
    let inline IsChecked a = (^a: (member IsChecked: ^b) a)
    let inline OperatorMethod a = (^a: (member OperatorMethod: ^b) a)
    let inline (|InConversion|) a = (^a: (member InConversion: ^b) a)
    let inline (|OutConversion|) a = (^a: (member OutConversion: ^b) a)
    let inline (|OperatorKind|) a = (^a: (member OperatorKind: ^b) a)
    let inline (|IsLifted|) a = (^a: (member IsLifted: ^b) a)
    let inline (|IsChecked|) a = (^a: (member IsChecked: ^b) a)
    let inline (|OperatorMethod|) a = (^a: (member OperatorMethod: ^b) a)

module IConditionalAccessOperation =
    let inline Operation a = (^a: (member Operation: ^b) a)
    let inline WhenNotNull a = (^a: (member WhenNotNull: ^b) a)
    let inline (|Operation|) a = (^a: (member Operation: ^b) a)
    let inline (|WhenNotNull|) a = (^a: (member WhenNotNull: ^b) a)

module IConditionalOperation =
    let inline Condition a = (^a: (member Condition: ^b) a)
    let inline WhenTrue a = (^a: (member WhenTrue: ^b) a)
    let inline WhenFalse a = (^a: (member WhenFalse: ^b) a)
    let inline IsRef a = (^a: (member IsRef: ^b) a)
    let inline (|Condition|) a = (^a: (member Condition: ^b) a)
    let inline (|WhenTrue|) a = (^a: (member WhenTrue: ^b) a)
    let inline (|WhenFalse|) a = (^a: (member WhenFalse: ^b) a)
    let inline (|IsRef|) a = (^a: (member IsRef: ^b) a)

module IConstantPatternOperation =
    let inline Value a = (^a: (member Value: ^b) a)
    let inline (|Value|) a = (^a: (member Value: ^b) a)

module IConstructorBodyOperation =
    let inline Locals a = (^a: (member Locals: ^b) a)
    let inline Initializer a = (^a: (member Initializer: ^b) a)
    let inline (|Locals|) a = (^a: (member Locals: ^b) a)
    let inline (|Initializer|) a = (^a: (member Initializer: ^b) a)

module IConversionOperation =
    let inline Operand a = (^a: (member Operand: ^b) a)
    let inline OperatorMethod a = (^a: (member OperatorMethod: ^b) a)
    let inline Conversion a = (^a: (member Conversion: ^b) a)
    let inline IsTryCast a = (^a: (member IsTryCast: ^b) a)
    let inline IsChecked a = (^a: (member IsChecked: ^b) a)
    let inline (|Operand|) a = (^a: (member Operand: ^b) a)
    let inline (|OperatorMethod|) a = (^a: (member OperatorMethod: ^b) a)
    let inline (|Conversion|) a = (^a: (member Conversion: ^b) a)
    let inline (|IsTryCast|) a = (^a: (member IsTryCast: ^b) a)
    let inline (|IsChecked|) a = (^a: (member IsChecked: ^b) a)

module IDeclarationExpressionOperation =
    let inline Expression a = (^a: (member Expression: ^b) a)
    let inline (|Expression|) a = (^a: (member Expression: ^b) a)

module IDeclarationPatternOperation =
    let inline MatchedType a = (^a: (member MatchedType: ^b) a)
    let inline MatchesNull a = (^a: (member MatchesNull: ^b) a)
    let inline DeclaredSymbol a = (^a: (member DeclaredSymbol: ^b) a)
    let inline (|MatchedType|) a = (^a: (member MatchedType: ^b) a)
    let inline (|MatchesNull|) a = (^a: (member MatchesNull: ^b) a)
    let inline (|DeclaredSymbol|) a = (^a: (member DeclaredSymbol: ^b) a)

module IDelegateCreationOperation =
    let inline Target a = (^a: (member Target: ^b) a)
    let inline (|Target|) a = (^a: (member Target: ^b) a)

module IDiscardOperation =
    let inline DiscardSymbol a = (^a: (member DiscardSymbol: ^b) a)
    let inline (|DiscardSymbol|) a = (^a: (member DiscardSymbol: ^b) a)

module IDiscardSymbol =
    let inline Type a = (^a: (member Type: ^b) a)
    let inline NullableAnnotation a = (^a: (member NullableAnnotation: ^b) a)
    let inline (|Type|) a = (^a: (member Type: ^b) a)
    let inline (|NullableAnnotation|) a = (^a: (member NullableAnnotation: ^b) a)

module IDynamicIndexerAccessOperation =
    let inline Operation a = (^a: (member Operation: ^b) a)
    let inline Arguments a = (^a: (member Arguments: ^b) a)
    let inline (|Operation|) a = (^a: (member Operation: ^b) a)
    let inline (|Arguments|) a = (^a: (member Arguments: ^b) a)

module IDynamicInvocationOperation =
    let inline Operation a = (^a: (member Operation: ^b) a)
    let inline Arguments a = (^a: (member Arguments: ^b) a)
    let inline (|Operation|) a = (^a: (member Operation: ^b) a)
    let inline (|Arguments|) a = (^a: (member Arguments: ^b) a)

module IDynamicMemberReferenceOperation =
    let inline Instance a = (^a: (member Instance: ^b) a)
    let inline MemberName a = (^a: (member MemberName: ^b) a)
    let inline TypeArguments a = (^a: (member TypeArguments: ^b) a)
    let inline ContainingType a = (^a: (member ContainingType: ^b) a)
    let inline (|Instance|) a = (^a: (member Instance: ^b) a)
    let inline (|MemberName|) a = (^a: (member MemberName: ^b) a)
    let inline (|TypeArguments|) a = (^a: (member TypeArguments: ^b) a)
    let inline (|ContainingType|) a = (^a: (member ContainingType: ^b) a)

module IDynamicObjectCreationOperation =
    let inline Initializer a = (^a: (member Initializer: ^b) a)
    let inline Arguments a = (^a: (member Arguments: ^b) a)
    let inline (|Initializer|) a = (^a: (member Initializer: ^b) a)
    let inline (|Arguments|) a = (^a: (member Arguments: ^b) a)

module IErrorTypeSymbol =
    let inline CandidateSymbols a = (^a: (member CandidateSymbols: ^b) a)
    let inline CandidateReason a = (^a: (member CandidateReason: ^b) a)
    let inline (|CandidateSymbols|) a = (^a: (member CandidateSymbols: ^b) a)
    let inline (|CandidateReason|) a = (^a: (member CandidateReason: ^b) a)

module IEventAssignmentOperation =
    let inline EventReference a = (^a: (member EventReference: ^b) a)
    let inline HandlerValue a = (^a: (member HandlerValue: ^b) a)
    let inline Adds a = (^a: (member Adds: ^b) a)
    let inline (|EventReference|) a = (^a: (member EventReference: ^b) a)
    let inline (|HandlerValue|) a = (^a: (member HandlerValue: ^b) a)
    let inline (|Adds|) a = (^a: (member Adds: ^b) a)

module IEventReferenceOperation =
    let inline Event a = (^a: (member Event: ^b) a)
    let inline (|Event|) a = (^a: (member Event: ^b) a)

module IEventSymbol =
    let inline Type a = (^a: (member Type: ^b) a)
    let inline NullableAnnotation a = (^a: (member NullableAnnotation: ^b) a)
    let inline IsWindowsRuntimeEvent a = (^a: (member IsWindowsRuntimeEvent: ^b) a)
    let inline AddMethod a = (^a: (member AddMethod: ^b) a)
    let inline RemoveMethod a = (^a: (member RemoveMethod: ^b) a)
    let inline RaiseMethod a = (^a: (member RaiseMethod: ^b) a)
    let inline OriginalDefinition a = (^a: (member OriginalDefinition: ^b) a)
    let inline OverriddenEvent a = (^a: (member OverriddenEvent: ^b) a)
    let inline ExplicitInterfaceImplementations a = (^a: (member ExplicitInterfaceImplementations: ^b) a)
    let inline (|Type|) a = (^a: (member Type: ^b) a)
    let inline (|NullableAnnotation|) a = (^a: (member NullableAnnotation: ^b) a)
    let inline (|IsWindowsRuntimeEvent|) a = (^a: (member IsWindowsRuntimeEvent: ^b) a)
    let inline (|AddMethod|) a = (^a: (member AddMethod: ^b) a)
    let inline (|RemoveMethod|) a = (^a: (member RemoveMethod: ^b) a)
    let inline (|RaiseMethod|) a = (^a: (member RaiseMethod: ^b) a)
    let inline (|OriginalDefinition|) a = (^a: (member OriginalDefinition: ^b) a)
    let inline (|OverriddenEvent|) a = (^a: (member OverriddenEvent: ^b) a)
    let inline (|ExplicitInterfaceImplementations|) a = (^a: (member ExplicitInterfaceImplementations: ^b) a)

module IExpressionStatementOperation =
    let inline Operation a = (^a: (member Operation: ^b) a)
    let inline (|Operation|) a = (^a: (member Operation: ^b) a)

module IFieldInitializerOperation =
    let inline InitializedFields a = (^a: (member InitializedFields: ^b) a)
    let inline (|InitializedFields|) a = (^a: (member InitializedFields: ^b) a)

module IFieldReferenceOperation =
    let inline Field a = (^a: (member Field: ^b) a)
    let inline IsDeclaration a = (^a: (member IsDeclaration: ^b) a)
    let inline (|Field|) a = (^a: (member Field: ^b) a)
    let inline (|IsDeclaration|) a = (^a: (member IsDeclaration: ^b) a)

module IFieldSymbol =
    let inline AssociatedSymbol a = (^a: (member AssociatedSymbol: ^b) a)
    let inline IsConst a = (^a: (member IsConst: ^b) a)
    let inline IsReadOnly a = (^a: (member IsReadOnly: ^b) a)
    let inline IsVolatile a = (^a: (member IsVolatile: ^b) a)
    let inline IsFixedSizeBuffer a = (^a: (member IsFixedSizeBuffer: ^b) a)
    let inline Type a = (^a: (member Type: ^b) a)
    let inline NullableAnnotation a = (^a: (member NullableAnnotation: ^b) a)
    let inline HasConstantValue a = (^a: (member HasConstantValue: ^b) a)
    let inline ConstantValue a = (^a: (member ConstantValue: ^b) a)
    let inline CustomModifiers a = (^a: (member CustomModifiers: ^b) a)
    let inline OriginalDefinition a = (^a: (member OriginalDefinition: ^b) a)
    let inline CorrespondingTupleField a = (^a: (member CorrespondingTupleField: ^b) a)
    let inline IsExplicitlyNamedTupleElement a = (^a: (member IsExplicitlyNamedTupleElement: ^b) a)
    let inline (|AssociatedSymbol|) a = (^a: (member AssociatedSymbol: ^b) a)
    let inline (|IsConst|) a = (^a: (member IsConst: ^b) a)
    let inline (|IsReadOnly|) a = (^a: (member IsReadOnly: ^b) a)
    let inline (|IsVolatile|) a = (^a: (member IsVolatile: ^b) a)
    let inline (|IsFixedSizeBuffer|) a = (^a: (member IsFixedSizeBuffer: ^b) a)
    let inline (|Type|) a = (^a: (member Type: ^b) a)
    let inline (|NullableAnnotation|) a = (^a: (member NullableAnnotation: ^b) a)
    let inline (|HasConstantValue|) a = (^a: (member HasConstantValue: ^b) a)
    let inline (|ConstantValue|) a = (^a: (member ConstantValue: ^b) a)
    let inline (|CustomModifiers|) a = (^a: (member CustomModifiers: ^b) a)
    let inline (|OriginalDefinition|) a = (^a: (member OriginalDefinition: ^b) a)
    let inline (|CorrespondingTupleField|) a = (^a: (member CorrespondingTupleField: ^b) a)
    let inline (|IsExplicitlyNamedTupleElement|) a = (^a: (member IsExplicitlyNamedTupleElement: ^b) a)

module IFlowAnonymousFunctionOperation =
    let inline Symbol a = (^a: (member Symbol: ^b) a)
    let inline (|Symbol|) a = (^a: (member Symbol: ^b) a)

module IFlowCaptureOperation =
    let inline Id a = (^a: (member Id: ^b) a)
    let inline Value a = (^a: (member Value: ^b) a)
    let inline (|Id|) a = (^a: (member Id: ^b) a)
    let inline (|Value|) a = (^a: (member Value: ^b) a)

module IFlowCaptureReferenceOperation =
    let inline Id a = (^a: (member Id: ^b) a)
    let inline (|Id|) a = (^a: (member Id: ^b) a)

module IForEachLoopOperation =
    let inline LoopControlVariable a = (^a: (member LoopControlVariable: ^b) a)
    let inline Collection a = (^a: (member Collection: ^b) a)
    let inline NextVariables a = (^a: (member NextVariables: ^b) a)
    let inline IsAsynchronous a = (^a: (member IsAsynchronous: ^b) a)
    let inline (|LoopControlVariable|) a = (^a: (member LoopControlVariable: ^b) a)
    let inline (|Collection|) a = (^a: (member Collection: ^b) a)
    let inline (|NextVariables|) a = (^a: (member NextVariables: ^b) a)
    let inline (|IsAsynchronous|) a = (^a: (member IsAsynchronous: ^b) a)

module IForLoopOperation =
    let inline Before a = (^a: (member Before: ^b) a)
    let inline ConditionLocals a = (^a: (member ConditionLocals: ^b) a)
    let inline Condition a = (^a: (member Condition: ^b) a)
    let inline AtLoopBottom a = (^a: (member AtLoopBottom: ^b) a)
    let inline (|Before|) a = (^a: (member Before: ^b) a)
    let inline (|ConditionLocals|) a = (^a: (member ConditionLocals: ^b) a)
    let inline (|Condition|) a = (^a: (member Condition: ^b) a)
    let inline (|AtLoopBottom|) a = (^a: (member AtLoopBottom: ^b) a)

module IForToLoopOperation =
    let inline LoopControlVariable a = (^a: (member LoopControlVariable: ^b) a)
    let inline InitialValue a = (^a: (member InitialValue: ^b) a)
    let inline LimitValue a = (^a: (member LimitValue: ^b) a)
    let inline StepValue a = (^a: (member StepValue: ^b) a)
    let inline IsChecked a = (^a: (member IsChecked: ^b) a)
    let inline NextVariables a = (^a: (member NextVariables: ^b) a)
    let inline (|LoopControlVariable|) a = (^a: (member LoopControlVariable: ^b) a)
    let inline (|InitialValue|) a = (^a: (member InitialValue: ^b) a)
    let inline (|LimitValue|) a = (^a: (member LimitValue: ^b) a)
    let inline (|StepValue|) a = (^a: (member StepValue: ^b) a)
    let inline (|IsChecked|) a = (^a: (member IsChecked: ^b) a)
    let inline (|NextVariables|) a = (^a: (member NextVariables: ^b) a)

module IFunctionPointerTypeSymbol =
    let inline Signature a = (^a: (member Signature: ^b) a)
    let inline (|Signature|) a = (^a: (member Signature: ^b) a)

module IIncrementOrDecrementOperation =
    let inline IsPostfix a = (^a: (member IsPostfix: ^b) a)
    let inline IsLifted a = (^a: (member IsLifted: ^b) a)
    let inline IsChecked a = (^a: (member IsChecked: ^b) a)
    let inline Target a = (^a: (member Target: ^b) a)
    let inline OperatorMethod a = (^a: (member OperatorMethod: ^b) a)
    let inline (|IsPostfix|) a = (^a: (member IsPostfix: ^b) a)
    let inline (|IsLifted|) a = (^a: (member IsLifted: ^b) a)
    let inline (|IsChecked|) a = (^a: (member IsChecked: ^b) a)
    let inline (|Target|) a = (^a: (member Target: ^b) a)
    let inline (|OperatorMethod|) a = (^a: (member OperatorMethod: ^b) a)

module IInstanceReferenceOperation =
    let inline ReferenceKind a = (^a: (member ReferenceKind: ^b) a)
    let inline (|ReferenceKind|) a = (^a: (member ReferenceKind: ^b) a)

module IInterpolatedStringOperation =
    let inline Parts a = (^a: (member Parts: ^b) a)
    let inline (|Parts|) a = (^a: (member Parts: ^b) a)

module IInterpolatedStringTextOperation =
    let inline Text a = (^a: (member Text: ^b) a)
    let inline (|Text|) a = (^a: (member Text: ^b) a)

module IInterpolationOperation =
    let inline Expression a = (^a: (member Expression: ^b) a)
    let inline Alignment a = (^a: (member Alignment: ^b) a)
    let inline FormatString a = (^a: (member FormatString: ^b) a)
    let inline (|Expression|) a = (^a: (member Expression: ^b) a)
    let inline (|Alignment|) a = (^a: (member Alignment: ^b) a)
    let inline (|FormatString|) a = (^a: (member FormatString: ^b) a)

module IInvocationOperation =
    let inline TargetMethod a = (^a: (member TargetMethod: ^b) a)
    let inline Instance a = (^a: (member Instance: ^b) a)
    let inline IsVirtual a = (^a: (member IsVirtual: ^b) a)
    let inline Arguments a = (^a: (member Arguments: ^b) a)
    let inline (|TargetMethod|) a = (^a: (member TargetMethod: ^b) a)
    let inline (|Instance|) a = (^a: (member Instance: ^b) a)
    let inline (|IsVirtual|) a = (^a: (member IsVirtual: ^b) a)
    let inline (|Arguments|) a = (^a: (member Arguments: ^b) a)

module IIsNullOperation =
    let inline Operand a = (^a: (member Operand: ^b) a)
    let inline (|Operand|) a = (^a: (member Operand: ^b) a)

module IIsPatternOperation =
    let inline Value a = (^a: (member Value: ^b) a)
    let inline Pattern a = (^a: (member Pattern: ^b) a)
    let inline (|Value|) a = (^a: (member Value: ^b) a)
    let inline (|Pattern|) a = (^a: (member Pattern: ^b) a)

module IIsTypeOperation =
    let inline ValueOperand a = (^a: (member ValueOperand: ^b) a)
    let inline TypeOperand a = (^a: (member TypeOperand: ^b) a)
    let inline IsNegated a = (^a: (member IsNegated: ^b) a)
    let inline (|ValueOperand|) a = (^a: (member ValueOperand: ^b) a)
    let inline (|TypeOperand|) a = (^a: (member TypeOperand: ^b) a)
    let inline (|IsNegated|) a = (^a: (member IsNegated: ^b) a)

module ILabelSymbol =
    let inline ContainingMethod a = (^a: (member ContainingMethod: ^b) a)
    let inline (|ContainingMethod|) a = (^a: (member ContainingMethod: ^b) a)

module ILabeledOperation =
    let inline Label a = (^a: (member Label: ^b) a)
    let inline Operation a = (^a: (member Operation: ^b) a)
    let inline (|Label|) a = (^a: (member Label: ^b) a)
    let inline (|Operation|) a = (^a: (member Operation: ^b) a)

module ILocalFunctionOperation =
    let inline Symbol a = (^a: (member Symbol: ^b) a)
    let inline Body a = (^a: (member Body: ^b) a)
    let inline IgnoredBody a = (^a: (member IgnoredBody: ^b) a)
    let inline (|Symbol|) a = (^a: (member Symbol: ^b) a)
    let inline (|Body|) a = (^a: (member Body: ^b) a)
    let inline (|IgnoredBody|) a = (^a: (member IgnoredBody: ^b) a)

module ILocalReferenceOperation =
    let inline Local a = (^a: (member Local: ^b) a)
    let inline IsDeclaration a = (^a: (member IsDeclaration: ^b) a)
    let inline (|Local|) a = (^a: (member Local: ^b) a)
    let inline (|IsDeclaration|) a = (^a: (member IsDeclaration: ^b) a)

module ILocalSymbol =
    let inline Type a = (^a: (member Type: ^b) a)
    let inline NullableAnnotation a = (^a: (member NullableAnnotation: ^b) a)
    let inline IsConst a = (^a: (member IsConst: ^b) a)
    let inline IsRef a = (^a: (member IsRef: ^b) a)
    let inline RefKind a = (^a: (member RefKind: ^b) a)
    let inline HasConstantValue a = (^a: (member HasConstantValue: ^b) a)
    let inline ConstantValue a = (^a: (member ConstantValue: ^b) a)
    let inline IsFunctionValue a = (^a: (member IsFunctionValue: ^b) a)
    let inline IsFixed a = (^a: (member IsFixed: ^b) a)
    let inline (|Type|) a = (^a: (member Type: ^b) a)
    let inline (|NullableAnnotation|) a = (^a: (member NullableAnnotation: ^b) a)
    let inline (|IsConst|) a = (^a: (member IsConst: ^b) a)
    let inline (|IsRef|) a = (^a: (member IsRef: ^b) a)
    let inline (|RefKind|) a = (^a: (member RefKind: ^b) a)
    let inline (|HasConstantValue|) a = (^a: (member HasConstantValue: ^b) a)
    let inline (|ConstantValue|) a = (^a: (member ConstantValue: ^b) a)
    let inline (|IsFunctionValue|) a = (^a: (member IsFunctionValue: ^b) a)
    let inline (|IsFixed|) a = (^a: (member IsFixed: ^b) a)

module ILockOperation =
    let inline LockedValue a = (^a: (member LockedValue: ^b) a)
    let inline Body a = (^a: (member Body: ^b) a)
    let inline (|LockedValue|) a = (^a: (member LockedValue: ^b) a)
    let inline (|Body|) a = (^a: (member Body: ^b) a)

module ILoopOperation =
    let inline LoopKind a = (^a: (member LoopKind: ^b) a)
    let inline Body a = (^a: (member Body: ^b) a)
    let inline Locals a = (^a: (member Locals: ^b) a)
    let inline ContinueLabel a = (^a: (member ContinueLabel: ^b) a)
    let inline ExitLabel a = (^a: (member ExitLabel: ^b) a)
    let inline (|LoopKind|) a = (^a: (member LoopKind: ^b) a)
    let inline (|Body|) a = (^a: (member Body: ^b) a)
    let inline (|Locals|) a = (^a: (member Locals: ^b) a)
    let inline (|ContinueLabel|) a = (^a: (member ContinueLabel: ^b) a)
    let inline (|ExitLabel|) a = (^a: (member ExitLabel: ^b) a)

module IMemberInitializerOperation =
    let inline InitializedMember a = (^a: (member InitializedMember: ^b) a)
    let inline Initializer a = (^a: (member Initializer: ^b) a)
    let inline (|InitializedMember|) a = (^a: (member InitializedMember: ^b) a)
    let inline (|Initializer|) a = (^a: (member Initializer: ^b) a)

module IMemberReferenceOperation =
    let inline Instance a = (^a: (member Instance: ^b) a)
    let inline Member a = (^a: (member Member: ^b) a)
    let inline (|Instance|) a = (^a: (member Instance: ^b) a)
    let inline (|Member|) a = (^a: (member Member: ^b) a)

module IMethodBodyBaseOperation =
    let inline BlockBody a = (^a: (member BlockBody: ^b) a)
    let inline ExpressionBody a = (^a: (member ExpressionBody: ^b) a)
    let inline (|BlockBody|) a = (^a: (member BlockBody: ^b) a)
    let inline (|ExpressionBody|) a = (^a: (member ExpressionBody: ^b) a)


module IMethodReferenceOperation =
    let inline Method a = (^a: (member Method: ^b) a)
    let inline IsVirtual a = (^a: (member IsVirtual: ^b) a)
    let inline (|Method|) a = (^a: (member Method: ^b) a)
    let inline (|IsVirtual|) a = (^a: (member IsVirtual: ^b) a)

module IMethodSymbol =
    let inline MethodKind a = (^a: (member MethodKind: ^b) a)
    let inline Arity a = (^a: (member Arity: ^b) a)
    let inline IsGenericMethod a = (^a: (member IsGenericMethod: ^b) a)
    let inline IsExtensionMethod a = (^a: (member IsExtensionMethod: ^b) a)
    let inline IsAsync a = (^a: (member IsAsync: ^b) a)
    let inline IsVararg a = (^a: (member IsVararg: ^b) a)
    let inline IsCheckedBuiltin a = (^a: (member IsCheckedBuiltin: ^b) a)
    let inline HidesBaseMethodsByName a = (^a: (member HidesBaseMethodsByName: ^b) a)
    let inline ReturnsVoid a = (^a: (member ReturnsVoid: ^b) a)
    let inline ReturnsByRef a = (^a: (member ReturnsByRef: ^b) a)
    let inline ReturnsByRefReadonly a = (^a: (member ReturnsByRefReadonly: ^b) a)
    let inline RefKind a = (^a: (member RefKind: ^b) a)
    let inline ReturnType a = (^a: (member ReturnType: ^b) a)
    let inline ReturnNullableAnnotation a = (^a: (member ReturnNullableAnnotation: ^b) a)
    let inline TypeArguments a = (^a: (member TypeArguments: ^b) a)
    let inline TypeArgumentNullableAnnotations a = (^a: (member TypeArgumentNullableAnnotations: ^b) a)
    let inline TypeParameters a = (^a: (member TypeParameters: ^b) a)
    let inline Parameters a = (^a: (member Parameters: ^b) a)
    let inline ConstructedFrom a = (^a: (member ConstructedFrom: ^b) a)
    let inline IsReadOnly a = (^a: (member IsReadOnly: ^b) a)
    let inline IsInitOnly a = (^a: (member IsInitOnly: ^b) a)
    let inline OriginalDefinition a = (^a: (member OriginalDefinition: ^b) a)
    let inline OverriddenMethod a = (^a: (member OverriddenMethod: ^b) a)
    let inline ReceiverType a = (^a: (member ReceiverType: ^b) a)
    let inline ReceiverNullableAnnotation a = (^a: (member ReceiverNullableAnnotation: ^b) a)
    let inline ReducedFrom a = (^a: (member ReducedFrom: ^b) a)
    let inline ExplicitInterfaceImplementations a = (^a: (member ExplicitInterfaceImplementations: ^b) a)
    let inline ReturnTypeCustomModifiers a = (^a: (member ReturnTypeCustomModifiers: ^b) a)
    let inline RefCustomModifiers a = (^a: (member RefCustomModifiers: ^b) a)
    let inline CallingConvention a = (^a: (member CallingConvention: ^b) a)
    let inline UnmanagedCallingConventionTypes a = (^a: (member UnmanagedCallingConventionTypes: ^b) a)
    let inline AssociatedSymbol a = (^a: (member AssociatedSymbol: ^b) a)
    let inline PartialDefinitionPart a = (^a: (member PartialDefinitionPart: ^b) a)
    let inline PartialImplementationPart a = (^a: (member PartialImplementationPart: ^b) a)
    let inline MethodImplementationFlags a = (^a: (member MethodImplementationFlags: ^b) a)
    let inline IsPartialDefinition a = (^a: (member IsPartialDefinition: ^b) a)
    let inline AssociatedAnonymousDelegate a = (^a: (member AssociatedAnonymousDelegate: ^b) a)
    let inline IsConditional a = (^a: (member IsConditional: ^b) a)
    let inline (|MethodKind|) a = (^a: (member MethodKind: ^b) a)
    let inline (|Arity|) a = (^a: (member Arity: ^b) a)
    let inline (|IsGenericMethod|) a = (^a: (member IsGenericMethod: ^b) a)
    let inline (|IsExtensionMethod|) a = (^a: (member IsExtensionMethod: ^b) a)
    let inline (|IsAsync|) a = (^a: (member IsAsync: ^b) a)
    let inline (|IsVararg|) a = (^a: (member IsVararg: ^b) a)
    let inline (|IsCheckedBuiltin|) a = (^a: (member IsCheckedBuiltin: ^b) a)
    let inline (|HidesBaseMethodsByName|) a = (^a: (member HidesBaseMethodsByName: ^b) a)
    let inline (|ReturnsVoid|) a = (^a: (member ReturnsVoid: ^b) a)
    let inline (|ReturnsByRef|) a = (^a: (member ReturnsByRef: ^b) a)
    let inline (|ReturnsByRefReadonly|) a = (^a: (member ReturnsByRefReadonly: ^b) a)
    let inline (|RefKind|) a = (^a: (member RefKind: ^b) a)
    let inline (|ReturnType|) a = (^a: (member ReturnType: ^b) a)
    let inline (|ReturnNullableAnnotation|) a = (^a: (member ReturnNullableAnnotation: ^b) a)
    let inline (|TypeArguments|) a = (^a: (member TypeArguments: ^b) a)
    let inline (|TypeArgumentNullableAnnotations|) a = (^a: (member TypeArgumentNullableAnnotations: ^b) a)
    let inline (|TypeParameters|) a = (^a: (member TypeParameters: ^b) a)
    let inline (|Parameters|) a = (^a: (member Parameters: ^b) a)
    let inline (|ConstructedFrom|) a = (^a: (member ConstructedFrom: ^b) a)
    let inline (|IsReadOnly|) a = (^a: (member IsReadOnly: ^b) a)
    let inline (|IsInitOnly|) a = (^a: (member IsInitOnly: ^b) a)
    let inline (|OriginalDefinition|) a = (^a: (member OriginalDefinition: ^b) a)
    let inline (|OverriddenMethod|) a = (^a: (member OverriddenMethod: ^b) a)
    let inline (|ReceiverType|) a = (^a: (member ReceiverType: ^b) a)
    let inline (|ReceiverNullableAnnotation|) a = (^a: (member ReceiverNullableAnnotation: ^b) a)
    let inline (|ReducedFrom|) a = (^a: (member ReducedFrom: ^b) a)
    let inline (|ExplicitInterfaceImplementations|) a = (^a: (member ExplicitInterfaceImplementations: ^b) a)
    let inline (|ReturnTypeCustomModifiers|) a = (^a: (member ReturnTypeCustomModifiers: ^b) a)
    let inline (|RefCustomModifiers|) a = (^a: (member RefCustomModifiers: ^b) a)
    let inline (|CallingConvention|) a = (^a: (member CallingConvention: ^b) a)
    let inline (|UnmanagedCallingConventionTypes|) a = (^a: (member UnmanagedCallingConventionTypes: ^b) a)
    let inline (|AssociatedSymbol|) a = (^a: (member AssociatedSymbol: ^b) a)
    let inline (|PartialDefinitionPart|) a = (^a: (member PartialDefinitionPart: ^b) a)
    let inline (|PartialImplementationPart|) a = (^a: (member PartialImplementationPart: ^b) a)
    let inline (|MethodImplementationFlags|) a = (^a: (member MethodImplementationFlags: ^b) a)
    let inline (|IsPartialDefinition|) a = (^a: (member IsPartialDefinition: ^b) a)
    let inline (|AssociatedAnonymousDelegate|) a = (^a: (member AssociatedAnonymousDelegate: ^b) a)
    let inline (|IsConditional|) a = (^a: (member IsConditional: ^b) a)

module IModuleSymbol =
    let inline GlobalNamespace a = (^a: (member GlobalNamespace: ^b) a)
    let inline ReferencedAssemblies a = (^a: (member ReferencedAssemblies: ^b) a)
    let inline ReferencedAssemblySymbols a = (^a: (member ReferencedAssemblySymbols: ^b) a)
    let inline (|GlobalNamespace|) a = (^a: (member GlobalNamespace: ^b) a)
    let inline (|ReferencedAssemblies|) a = (^a: (member ReferencedAssemblies: ^b) a)
    let inline (|ReferencedAssemblySymbols|) a = (^a: (member ReferencedAssemblySymbols: ^b) a)

module INameOfOperation =
    let inline Argument a = (^a: (member Argument: ^b) a)
    let inline (|Argument|) a = (^a: (member Argument: ^b) a)

module INamedTypeSymbol =
    let inline Arity a = (^a: (member Arity: ^b) a)
    let inline IsGenericType a = (^a: (member IsGenericType: ^b) a)
    let inline IsUnboundGenericType a = (^a: (member IsUnboundGenericType: ^b) a)
    let inline IsScriptClass a = (^a: (member IsScriptClass: ^b) a)
    let inline IsImplicitClass a = (^a: (member IsImplicitClass: ^b) a)
    let inline IsComImport a = (^a: (member IsComImport: ^b) a)
    let inline MemberNames a = (^a: (member MemberNames: ^b) a)
    let inline TypeParameters a = (^a: (member TypeParameters: ^b) a)
    let inline TypeArguments a = (^a: (member TypeArguments: ^b) a)
    let inline TypeArgumentNullableAnnotations a = (^a: (member TypeArgumentNullableAnnotations: ^b) a)
    let inline OriginalDefinition a = (^a: (member OriginalDefinition: ^b) a)
    let inline DelegateInvokeMethod a = (^a: (member DelegateInvokeMethod: ^b) a)
    let inline EnumUnderlyingType a = (^a: (member EnumUnderlyingType: ^b) a)
    let inline ConstructedFrom a = (^a: (member ConstructedFrom: ^b) a)
    let inline InstanceConstructors a = (^a: (member InstanceConstructors: ^b) a)
    let inline StaticConstructors a = (^a: (member StaticConstructors: ^b) a)
    let inline Constructors a = (^a: (member Constructors: ^b) a)
    let inline AssociatedSymbol a = (^a: (member AssociatedSymbol: ^b) a)
    let inline MightContainExtensionMethods a = (^a: (member MightContainExtensionMethods: ^b) a)
    let inline TupleUnderlyingType a = (^a: (member TupleUnderlyingType: ^b) a)
    let inline TupleElements a = (^a: (member TupleElements: ^b) a)
    let inline IsSerializable a = (^a: (member IsSerializable: ^b) a)
    let inline NativeIntegerUnderlyingType a = (^a: (member NativeIntegerUnderlyingType: ^b) a)
    let inline (|Arity|) a = (^a: (member Arity: ^b) a)
    let inline (|IsGenericType|) a = (^a: (member IsGenericType: ^b) a)
    let inline (|IsUnboundGenericType|) a = (^a: (member IsUnboundGenericType: ^b) a)
    let inline (|IsScriptClass|) a = (^a: (member IsScriptClass: ^b) a)
    let inline (|IsImplicitClass|) a = (^a: (member IsImplicitClass: ^b) a)
    let inline (|IsComImport|) a = (^a: (member IsComImport: ^b) a)
    let inline (|MemberNames|) a = (^a: (member MemberNames: ^b) a)
    let inline (|TypeParameters|) a = (^a: (member TypeParameters: ^b) a)
    let inline (|TypeArguments|) a = (^a: (member TypeArguments: ^b) a)
    let inline (|TypeArgumentNullableAnnotations|) a = (^a: (member TypeArgumentNullableAnnotations: ^b) a)
    let inline (|OriginalDefinition|) a = (^a: (member OriginalDefinition: ^b) a)
    let inline (|DelegateInvokeMethod|) a = (^a: (member DelegateInvokeMethod: ^b) a)
    let inline (|EnumUnderlyingType|) a = (^a: (member EnumUnderlyingType: ^b) a)
    let inline (|ConstructedFrom|) a = (^a: (member ConstructedFrom: ^b) a)
    let inline (|InstanceConstructors|) a = (^a: (member InstanceConstructors: ^b) a)
    let inline (|StaticConstructors|) a = (^a: (member StaticConstructors: ^b) a)
    let inline (|Constructors|) a = (^a: (member Constructors: ^b) a)
    let inline (|AssociatedSymbol|) a = (^a: (member AssociatedSymbol: ^b) a)
    let inline (|MightContainExtensionMethods|) a = (^a: (member MightContainExtensionMethods: ^b) a)
    let inline (|TupleUnderlyingType|) a = (^a: (member TupleUnderlyingType: ^b) a)
    let inline (|TupleElements|) a = (^a: (member TupleElements: ^b) a)
    let inline (|IsSerializable|) a = (^a: (member IsSerializable: ^b) a)
    let inline (|NativeIntegerUnderlyingType|) a = (^a: (member NativeIntegerUnderlyingType: ^b) a)

module INamespaceOrTypeSymbol =
    let inline IsNamespace a = (^a: (member IsNamespace: ^b) a)
    let inline IsType a = (^a: (member IsType: ^b) a)
    let inline (|IsNamespace|) a = (^a: (member IsNamespace: ^b) a)
    let inline (|IsType|) a = (^a: (member IsType: ^b) a)

module INamespaceSymbol =
    let inline IsGlobalNamespace a = (^a: (member IsGlobalNamespace: ^b) a)
    let inline NamespaceKind a = (^a: (member NamespaceKind: ^b) a)
    let inline ContainingCompilation a = (^a: (member ContainingCompilation: ^b) a)
    let inline ConstituentNamespaces a = (^a: (member ConstituentNamespaces: ^b) a)
    let inline (|IsGlobalNamespace|) a = (^a: (member IsGlobalNamespace: ^b) a)
    let inline (|NamespaceKind|) a = (^a: (member NamespaceKind: ^b) a)
    let inline (|ContainingCompilation|) a = (^a: (member ContainingCompilation: ^b) a)
    let inline (|ConstituentNamespaces|) a = (^a: (member ConstituentNamespaces: ^b) a)

module INegatedPatternOperation =
    let inline Pattern a = (^a: (member Pattern: ^b) a)
    let inline (|Pattern|) a = (^a: (member Pattern: ^b) a)

module IObjectCreationOperation =
    let inline Constructor a = (^a: (member Constructor: ^b) a)
    let inline Initializer a = (^a: (member Initializer: ^b) a)
    let inline Arguments a = (^a: (member Arguments: ^b) a)
    let inline (|Constructor|) a = (^a: (member Constructor: ^b) a)
    let inline (|Initializer|) a = (^a: (member Initializer: ^b) a)
    let inline (|Arguments|) a = (^a: (member Arguments: ^b) a)

module IObjectOrCollectionInitializerOperation =
    let inline Initializers a = (^a: (member Initializers: ^b) a)
    let inline (|Initializers|) a = (^a: (member Initializers: ^b) a)

module IOperation =
    let inline Parent a = (^a: (member Parent: ^b) a)
    let inline Kind a = (^a: (member Kind: ^b) a)
    let inline Syntax a = (^a: (member Syntax: ^b) a)
    let inline Type a = (^a: (member Type: ^b) a)
    let inline ConstantValue a = (^a: (member ConstantValue: ^b) a)
    let inline Children a = (^a: (member Children: ^b) a)
    let inline Language a = (^a: (member Language: ^b) a)
    let inline IsImplicit a = (^a: (member IsImplicit: ^b) a)
    let inline SemanticModel a = (^a: (member SemanticModel: ^b) a)
    let inline (|Parent|) a = (^a: (member Parent: ^b) a)
    let inline (|Kind|) a = (^a: (member Kind: ^b) a)
    let inline (|Syntax|) a = (^a: (member Syntax: ^b) a)
    let inline (|Type|) a = (^a: (member Type: ^b) a)
    let inline (|ConstantValue|) a = (^a: (member ConstantValue: ^b) a)
    let inline (|Children|) a = (^a: (member Children: ^b) a)
    let inline (|Language|) a = (^a: (member Language: ^b) a)
    let inline (|IsImplicit|) a = (^a: (member IsImplicit: ^b) a)
    let inline (|SemanticModel|) a = (^a: (member SemanticModel: ^b) a)

module IParameterInitializerOperation =
    let inline Parameter a = (^a: (member Parameter: ^b) a)
    let inline (|Parameter|) a = (^a: (member Parameter: ^b) a)

module IParameterReferenceOperation =
    let inline Parameter a = (^a: (member Parameter: ^b) a)
    let inline (|Parameter|) a = (^a: (member Parameter: ^b) a)

module IParameterSymbol =
    let inline RefKind a = (^a: (member RefKind: ^b) a)
    let inline IsParams a = (^a: (member IsParams: ^b) a)
    let inline IsOptional a = (^a: (member IsOptional: ^b) a)
    let inline IsThis a = (^a: (member IsThis: ^b) a)
    let inline IsDiscard a = (^a: (member IsDiscard: ^b) a)
    let inline Type a = (^a: (member Type: ^b) a)
    let inline NullableAnnotation a = (^a: (member NullableAnnotation: ^b) a)
    let inline CustomModifiers a = (^a: (member CustomModifiers: ^b) a)
    let inline RefCustomModifiers a = (^a: (member RefCustomModifiers: ^b) a)
    let inline Ordinal a = (^a: (member Ordinal: ^b) a)
    let inline HasExplicitDefaultValue a = (^a: (member HasExplicitDefaultValue: ^b) a)
    let inline ExplicitDefaultValue a = (^a: (member ExplicitDefaultValue: ^b) a)
    let inline OriginalDefinition a = (^a: (member OriginalDefinition: ^b) a)
    let inline (|RefKind|) a = (^a: (member RefKind: ^b) a)
    let inline (|IsParams|) a = (^a: (member IsParams: ^b) a)
    let inline (|IsOptional|) a = (^a: (member IsOptional: ^b) a)
    let inline (|IsThis|) a = (^a: (member IsThis: ^b) a)
    let inline (|IsDiscard|) a = (^a: (member IsDiscard: ^b) a)
    let inline (|Type|) a = (^a: (member Type: ^b) a)
    let inline (|NullableAnnotation|) a = (^a: (member NullableAnnotation: ^b) a)
    let inline (|CustomModifiers|) a = (^a: (member CustomModifiers: ^b) a)
    let inline (|RefCustomModifiers|) a = (^a: (member RefCustomModifiers: ^b) a)
    let inline (|Ordinal|) a = (^a: (member Ordinal: ^b) a)
    let inline (|HasExplicitDefaultValue|) a = (^a: (member HasExplicitDefaultValue: ^b) a)
    let inline (|ExplicitDefaultValue|) a = (^a: (member ExplicitDefaultValue: ^b) a)
    let inline (|OriginalDefinition|) a = (^a: (member OriginalDefinition: ^b) a)

module IParenthesizedOperation =
    let inline Operand a = (^a: (member Operand: ^b) a)
    let inline (|Operand|) a = (^a: (member Operand: ^b) a)

module IPatternCaseClauseOperation =
    let inline Label a = (^a: (member Label: ^b) a)
    let inline Pattern a = (^a: (member Pattern: ^b) a)
    let inline Guard a = (^a: (member Guard: ^b) a)
    let inline (|Label|) a = (^a: (member Label: ^b) a)
    let inline (|Pattern|) a = (^a: (member Pattern: ^b) a)
    let inline (|Guard|) a = (^a: (member Guard: ^b) a)

module IPatternOperation =
    let inline InputType a = (^a: (member InputType: ^b) a)
    let inline NarrowedType a = (^a: (member NarrowedType: ^b) a)
    let inline (|InputType|) a = (^a: (member InputType: ^b) a)
    let inline (|NarrowedType|) a = (^a: (member NarrowedType: ^b) a)

module IPointerTypeSymbol =
    let inline PointedAtType a = (^a: (member PointedAtType: ^b) a)
    let inline CustomModifiers a = (^a: (member CustomModifiers: ^b) a)
    let inline (|PointedAtType|) a = (^a: (member PointedAtType: ^b) a)
    let inline (|CustomModifiers|) a = (^a: (member CustomModifiers: ^b) a)

module IPropertyInitializerOperation =
    let inline InitializedProperties a = (^a: (member InitializedProperties: ^b) a)
    let inline (|InitializedProperties|) a = (^a: (member InitializedProperties: ^b) a)

module IPropertyReferenceOperation =
    let inline Property a = (^a: (member Property: ^b) a)
    let inline Arguments a = (^a: (member Arguments: ^b) a)
    let inline (|Property|) a = (^a: (member Property: ^b) a)
    let inline (|Arguments|) a = (^a: (member Arguments: ^b) a)

module IPropertySubpatternOperation =
    let inline Member a = (^a: (member Member: ^b) a)
    let inline Pattern a = (^a: (member Pattern: ^b) a)
    let inline (|Member|) a = (^a: (member Member: ^b) a)
    let inline (|Pattern|) a = (^a: (member Pattern: ^b) a)

module IPropertySymbol =
    let inline IsIndexer a = (^a: (member IsIndexer: ^b) a)
    let inline IsReadOnly a = (^a: (member IsReadOnly: ^b) a)
    let inline IsWriteOnly a = (^a: (member IsWriteOnly: ^b) a)
    let inline IsWithEvents a = (^a: (member IsWithEvents: ^b) a)
    let inline ReturnsByRef a = (^a: (member ReturnsByRef: ^b) a)
    let inline ReturnsByRefReadonly a = (^a: (member ReturnsByRefReadonly: ^b) a)
    let inline RefKind a = (^a: (member RefKind: ^b) a)
    let inline Type a = (^a: (member Type: ^b) a)
    let inline NullableAnnotation a = (^a: (member NullableAnnotation: ^b) a)
    let inline Parameters a = (^a: (member Parameters: ^b) a)
    let inline GetMethod a = (^a: (member GetMethod: ^b) a)
    let inline SetMethod a = (^a: (member SetMethod: ^b) a)
    let inline OriginalDefinition a = (^a: (member OriginalDefinition: ^b) a)
    let inline OverriddenProperty a = (^a: (member OverriddenProperty: ^b) a)
    let inline ExplicitInterfaceImplementations a = (^a: (member ExplicitInterfaceImplementations: ^b) a)
    let inline RefCustomModifiers a = (^a: (member RefCustomModifiers: ^b) a)
    let inline TypeCustomModifiers a = (^a: (member TypeCustomModifiers: ^b) a)
    let inline (|IsIndexer|) a = (^a: (member IsIndexer: ^b) a)
    let inline (|IsReadOnly|) a = (^a: (member IsReadOnly: ^b) a)
    let inline (|IsWriteOnly|) a = (^a: (member IsWriteOnly: ^b) a)
    let inline (|IsWithEvents|) a = (^a: (member IsWithEvents: ^b) a)
    let inline (|ReturnsByRef|) a = (^a: (member ReturnsByRef: ^b) a)
    let inline (|ReturnsByRefReadonly|) a = (^a: (member ReturnsByRefReadonly: ^b) a)
    let inline (|RefKind|) a = (^a: (member RefKind: ^b) a)
    let inline (|Type|) a = (^a: (member Type: ^b) a)
    let inline (|NullableAnnotation|) a = (^a: (member NullableAnnotation: ^b) a)
    let inline (|Parameters|) a = (^a: (member Parameters: ^b) a)
    let inline (|GetMethod|) a = (^a: (member GetMethod: ^b) a)
    let inline (|SetMethod|) a = (^a: (member SetMethod: ^b) a)
    let inline (|OriginalDefinition|) a = (^a: (member OriginalDefinition: ^b) a)
    let inline (|OverriddenProperty|) a = (^a: (member OverriddenProperty: ^b) a)
    let inline (|ExplicitInterfaceImplementations|) a = (^a: (member ExplicitInterfaceImplementations: ^b) a)
    let inline (|RefCustomModifiers|) a = (^a: (member RefCustomModifiers: ^b) a)
    let inline (|TypeCustomModifiers|) a = (^a: (member TypeCustomModifiers: ^b) a)

module IRaiseEventOperation =
    let inline EventReference a = (^a: (member EventReference: ^b) a)
    let inline Arguments a = (^a: (member Arguments: ^b) a)
    let inline (|EventReference|) a = (^a: (member EventReference: ^b) a)
    let inline (|Arguments|) a = (^a: (member Arguments: ^b) a)

module IRangeCaseClauseOperation =
    let inline MinimumValue a = (^a: (member MinimumValue: ^b) a)
    let inline MaximumValue a = (^a: (member MaximumValue: ^b) a)
    let inline (|MinimumValue|) a = (^a: (member MinimumValue: ^b) a)
    let inline (|MaximumValue|) a = (^a: (member MaximumValue: ^b) a)

module IRangeOperation =
    let inline LeftOperand a = (^a: (member LeftOperand: ^b) a)
    let inline RightOperand a = (^a: (member RightOperand: ^b) a)
    let inline IsLifted a = (^a: (member IsLifted: ^b) a)
    let inline Method a = (^a: (member Method: ^b) a)
    let inline (|LeftOperand|) a = (^a: (member LeftOperand: ^b) a)
    let inline (|RightOperand|) a = (^a: (member RightOperand: ^b) a)
    let inline (|IsLifted|) a = (^a: (member IsLifted: ^b) a)
    let inline (|Method|) a = (^a: (member Method: ^b) a)

module IReDimClauseOperation =
    let inline Operand a = (^a: (member Operand: ^b) a)
    let inline DimensionSizes a = (^a: (member DimensionSizes: ^b) a)
    let inline (|Operand|) a = (^a: (member Operand: ^b) a)
    let inline (|DimensionSizes|) a = (^a: (member DimensionSizes: ^b) a)

module IReDimOperation =
    let inline Clauses a = (^a: (member Clauses: ^b) a)
    let inline Preserve a = (^a: (member Preserve: ^b) a)
    let inline (|Clauses|) a = (^a: (member Clauses: ^b) a)
    let inline (|Preserve|) a = (^a: (member Preserve: ^b) a)

module IRecursivePatternOperation =
    let inline MatchedType a = (^a: (member MatchedType: ^b) a)
    let inline DeconstructSymbol a = (^a: (member DeconstructSymbol: ^b) a)
    let inline DeconstructionSubpatterns a = (^a: (member DeconstructionSubpatterns: ^b) a)
    let inline PropertySubpatterns a = (^a: (member PropertySubpatterns: ^b) a)
    let inline DeclaredSymbol a = (^a: (member DeclaredSymbol: ^b) a)
    let inline (|MatchedType|) a = (^a: (member MatchedType: ^b) a)
    let inline (|DeconstructSymbol|) a = (^a: (member DeconstructSymbol: ^b) a)
    let inline (|DeconstructionSubpatterns|) a = (^a: (member DeconstructionSubpatterns: ^b) a)
    let inline (|PropertySubpatterns|) a = (^a: (member PropertySubpatterns: ^b) a)
    let inline (|DeclaredSymbol|) a = (^a: (member DeclaredSymbol: ^b) a)

module IRelationalCaseClauseOperation =
    let inline Value a = (^a: (member Value: ^b) a)
    let inline Relation a = (^a: (member Relation: ^b) a)
    let inline (|Value|) a = (^a: (member Value: ^b) a)
    let inline (|Relation|) a = (^a: (member Relation: ^b) a)

module IRelationalPatternOperation =
    let inline OperatorKind a = (^a: (member OperatorKind: ^b) a)
    let inline Value a = (^a: (member Value: ^b) a)
    let inline (|OperatorKind|) a = (^a: (member OperatorKind: ^b) a)
    let inline (|Value|) a = (^a: (member Value: ^b) a)

module IReturnOperation =
    let inline ReturnedValue a = (^a: (member ReturnedValue: ^b) a)
    let inline (|ReturnedValue|) a = (^a: (member ReturnedValue: ^b) a)

module ISimpleAssignmentOperation =
    let inline IsRef a = (^a: (member IsRef: ^b) a)
    let inline (|IsRef|) a = (^a: (member IsRef: ^b) a)

module ISingleValueCaseClauseOperation =
    let inline Value a = (^a: (member Value: ^b) a)
    let inline (|Value|) a = (^a: (member Value: ^b) a)

module ISizeOfOperation =
    let inline TypeOperand a = (^a: (member TypeOperand: ^b) a)
    let inline (|TypeOperand|) a = (^a: (member TypeOperand: ^b) a)

module ISkippedTokensTriviaSyntax =
    let inline Tokens a = (^a: (member Tokens: ^b) a)
    let inline (|Tokens|) a = (^a: (member Tokens: ^b) a)

module ISourceAssemblySymbol =
    let inline Compilation a = (^a: (member Compilation: ^b) a)
    let inline (|Compilation|) a = (^a: (member Compilation: ^b) a)

module IStaticLocalInitializationSemaphoreOperation =
    let inline Local a = (^a: (member Local: ^b) a)
    let inline (|Local|) a = (^a: (member Local: ^b) a)


module IStructuredTriviaSyntax =
    let inline ParentTrivia a = (^a: (member ParentTrivia: ^b) a)
    let inline (|ParentTrivia|) a = (^a: (member ParentTrivia: ^b) a)

module ISwitchCaseOperation =
    let inline Clauses a = (^a: (member Clauses: ^b) a)
    let inline Body a = (^a: (member Body: ^b) a)
    let inline Locals a = (^a: (member Locals: ^b) a)
    let inline (|Clauses|) a = (^a: (member Clauses: ^b) a)
    let inline (|Body|) a = (^a: (member Body: ^b) a)
    let inline (|Locals|) a = (^a: (member Locals: ^b) a)

module ISwitchExpressionArmOperation =
    let inline Pattern a = (^a: (member Pattern: ^b) a)
    let inline Guard a = (^a: (member Guard: ^b) a)
    let inline Value a = (^a: (member Value: ^b) a)
    let inline Locals a = (^a: (member Locals: ^b) a)
    let inline (|Pattern|) a = (^a: (member Pattern: ^b) a)
    let inline (|Guard|) a = (^a: (member Guard: ^b) a)
    let inline (|Value|) a = (^a: (member Value: ^b) a)
    let inline (|Locals|) a = (^a: (member Locals: ^b) a)

module ISwitchExpressionOperation =
    let inline Value a = (^a: (member Value: ^b) a)
    let inline Arms a = (^a: (member Arms: ^b) a)
    let inline (|Value|) a = (^a: (member Value: ^b) a)
    let inline (|Arms|) a = (^a: (member Arms: ^b) a)

module ISwitchOperation =
    let inline Locals a = (^a: (member Locals: ^b) a)
    let inline Value a = (^a: (member Value: ^b) a)
    let inline Cases a = (^a: (member Cases: ^b) a)
    let inline ExitLabel a = (^a: (member ExitLabel: ^b) a)
    let inline (|Locals|) a = (^a: (member Locals: ^b) a)
    let inline (|Value|) a = (^a: (member Value: ^b) a)
    let inline (|Cases|) a = (^a: (member Cases: ^b) a)
    let inline (|ExitLabel|) a = (^a: (member ExitLabel: ^b) a)

module ISymbol =
    let inline Kind a = (^a: (member Kind: ^b) a)
    let inline Language a = (^a: (member Language: ^b) a)
    let inline Name a = (^a: (member Name: ^b) a)
    let inline MetadataName a = (^a: (member MetadataName: ^b) a)
    let inline ContainingSymbol a = (^a: (member ContainingSymbol: ^b) a)
    let inline ContainingAssembly a = (^a: (member ContainingAssembly: ^b) a)
    let inline ContainingModule a = (^a: (member ContainingModule: ^b) a)
    let inline ContainingType a = (^a: (member ContainingType: ^b) a)
    let inline ContainingNamespace a = (^a: (member ContainingNamespace: ^b) a)
    let inline IsDefinition a = (^a: (member IsDefinition: ^b) a)
    let inline IsStatic a = (^a: (member IsStatic: ^b) a)
    let inline IsVirtual a = (^a: (member IsVirtual: ^b) a)
    let inline IsOverride a = (^a: (member IsOverride: ^b) a)
    let inline IsAbstract a = (^a: (member IsAbstract: ^b) a)
    let inline IsSealed a = (^a: (member IsSealed: ^b) a)
    let inline IsExtern a = (^a: (member IsExtern: ^b) a)
    let inline IsImplicitlyDeclared a = (^a: (member IsImplicitlyDeclared: ^b) a)
    let inline CanBeReferencedByName a = (^a: (member CanBeReferencedByName: ^b) a)
    let inline Locations a = (^a: (member Locations: ^b) a)
    let inline DeclaringSyntaxReferences a = (^a: (member DeclaringSyntaxReferences: ^b) a)
    let inline DeclaredAccessibility a = (^a: (member DeclaredAccessibility: ^b) a)
    let inline OriginalDefinition a = (^a: (member OriginalDefinition: ^b) a)
    let inline HasUnsupportedMetadata a = (^a: (member HasUnsupportedMetadata: ^b) a)
    let inline (|Kind|) a = (^a: (member Kind: ^b) a)
    let inline (|Language|) a = (^a: (member Language: ^b) a)
    let inline (|Name|) a = (^a: (member Name: ^b) a)
    let inline (|MetadataName|) a = (^a: (member MetadataName: ^b) a)
    let inline (|ContainingSymbol|) a = (^a: (member ContainingSymbol: ^b) a)
    let inline (|ContainingAssembly|) a = (^a: (member ContainingAssembly: ^b) a)
    let inline (|ContainingModule|) a = (^a: (member ContainingModule: ^b) a)
    let inline (|ContainingType|) a = (^a: (member ContainingType: ^b) a)
    let inline (|ContainingNamespace|) a = (^a: (member ContainingNamespace: ^b) a)
    let inline (|IsDefinition|) a = (^a: (member IsDefinition: ^b) a)
    let inline (|IsStatic|) a = (^a: (member IsStatic: ^b) a)
    let inline (|IsVirtual|) a = (^a: (member IsVirtual: ^b) a)
    let inline (|IsOverride|) a = (^a: (member IsOverride: ^b) a)
    let inline (|IsAbstract|) a = (^a: (member IsAbstract: ^b) a)
    let inline (|IsSealed|) a = (^a: (member IsSealed: ^b) a)
    let inline (|IsExtern|) a = (^a: (member IsExtern: ^b) a)
    let inline (|IsImplicitlyDeclared|) a = (^a: (member IsImplicitlyDeclared: ^b) a)
    let inline (|CanBeReferencedByName|) a = (^a: (member CanBeReferencedByName: ^b) a)
    let inline (|Locations|) a = (^a: (member Locations: ^b) a)
    let inline (|DeclaringSyntaxReferences|) a = (^a: (member DeclaringSyntaxReferences: ^b) a)
    let inline (|DeclaredAccessibility|) a = (^a: (member DeclaredAccessibility: ^b) a)
    let inline (|OriginalDefinition|) a = (^a: (member OriginalDefinition: ^b) a)
    let inline (|HasUnsupportedMetadata|) a = (^a: (member HasUnsupportedMetadata: ^b) a)

module ISymbolInitializerOperation =
    let inline Locals a = (^a: (member Locals: ^b) a)
    let inline Value a = (^a: (member Value: ^b) a)
    let inline (|Locals|) a = (^a: (member Locals: ^b) a)
    let inline (|Value|) a = (^a: (member Value: ^b) a)

module IThrowOperation =
    let inline Exception a = (^a: (member Exception: ^b) a)
    let inline (|Exception|) a = (^a: (member Exception: ^b) a)

module ITranslatedQueryOperation =
    let inline Operation a = (^a: (member Operation: ^b) a)
    let inline (|Operation|) a = (^a: (member Operation: ^b) a)

module ITryOperation =
    let inline Body a = (^a: (member Body: ^b) a)
    let inline Catches a = (^a: (member Catches: ^b) a)
    let inline Finally a = (^a: (member Finally: ^b) a)
    let inline ExitLabel a = (^a: (member ExitLabel: ^b) a)
    let inline (|Body|) a = (^a: (member Body: ^b) a)
    let inline (|Catches|) a = (^a: (member Catches: ^b) a)
    let inline (|Finally|) a = (^a: (member Finally: ^b) a)
    let inline (|ExitLabel|) a = (^a: (member ExitLabel: ^b) a)

module ITupleBinaryOperation =
    let inline OperatorKind a = (^a: (member OperatorKind: ^b) a)
    let inline LeftOperand a = (^a: (member LeftOperand: ^b) a)
    let inline RightOperand a = (^a: (member RightOperand: ^b) a)
    let inline (|OperatorKind|) a = (^a: (member OperatorKind: ^b) a)
    let inline (|LeftOperand|) a = (^a: (member LeftOperand: ^b) a)
    let inline (|RightOperand|) a = (^a: (member RightOperand: ^b) a)

module ITupleOperation =
    let inline Elements a = (^a: (member Elements: ^b) a)
    let inline NaturalType a = (^a: (member NaturalType: ^b) a)
    let inline (|Elements|) a = (^a: (member Elements: ^b) a)
    let inline (|NaturalType|) a = (^a: (member NaturalType: ^b) a)

module ITypeOfOperation =
    let inline TypeOperand a = (^a: (member TypeOperand: ^b) a)
    let inline (|TypeOperand|) a = (^a: (member TypeOperand: ^b) a)

module ITypeParameterObjectCreationOperation =
    let inline Initializer a = (^a: (member Initializer: ^b) a)
    let inline (|Initializer|) a = (^a: (member Initializer: ^b) a)

module ITypeParameterSymbol =
    let inline Ordinal a = (^a: (member Ordinal: ^b) a)
    let inline Variance a = (^a: (member Variance: ^b) a)
    let inline TypeParameterKind a = (^a: (member TypeParameterKind: ^b) a)
    let inline DeclaringMethod a = (^a: (member DeclaringMethod: ^b) a)
    let inline DeclaringType a = (^a: (member DeclaringType: ^b) a)
    let inline HasReferenceTypeConstraint a = (^a: (member HasReferenceTypeConstraint: ^b) a)
    let inline ReferenceTypeConstraintNullableAnnotation a = (^a: (member ReferenceTypeConstraintNullableAnnotation: ^b) a)
    let inline HasValueTypeConstraint a = (^a: (member HasValueTypeConstraint: ^b) a)
    let inline HasUnmanagedTypeConstraint a = (^a: (member HasUnmanagedTypeConstraint: ^b) a)
    let inline HasNotNullConstraint a = (^a: (member HasNotNullConstraint: ^b) a)
    let inline HasConstructorConstraint a = (^a: (member HasConstructorConstraint: ^b) a)
    let inline ConstraintTypes a = (^a: (member ConstraintTypes: ^b) a)
    let inline ConstraintNullableAnnotations a = (^a: (member ConstraintNullableAnnotations: ^b) a)
    let inline OriginalDefinition a = (^a: (member OriginalDefinition: ^b) a)
    let inline ReducedFrom a = (^a: (member ReducedFrom: ^b) a)
    let inline (|Ordinal|) a = (^a: (member Ordinal: ^b) a)
    let inline (|Variance|) a = (^a: (member Variance: ^b) a)
    let inline (|TypeParameterKind|) a = (^a: (member TypeParameterKind: ^b) a)
    let inline (|DeclaringMethod|) a = (^a: (member DeclaringMethod: ^b) a)
    let inline (|DeclaringType|) a = (^a: (member DeclaringType: ^b) a)
    let inline (|HasReferenceTypeConstraint|) a = (^a: (member HasReferenceTypeConstraint: ^b) a)
    let inline (|ReferenceTypeConstraintNullableAnnotation|) a = (^a: (member ReferenceTypeConstraintNullableAnnotation: ^b) a)
    let inline (|HasValueTypeConstraint|) a = (^a: (member HasValueTypeConstraint: ^b) a)
    let inline (|HasUnmanagedTypeConstraint|) a = (^a: (member HasUnmanagedTypeConstraint: ^b) a)
    let inline (|HasNotNullConstraint|) a = (^a: (member HasNotNullConstraint: ^b) a)
    let inline (|HasConstructorConstraint|) a = (^a: (member HasConstructorConstraint: ^b) a)
    let inline (|ConstraintTypes|) a = (^a: (member ConstraintTypes: ^b) a)
    let inline (|ConstraintNullableAnnotations|) a = (^a: (member ConstraintNullableAnnotations: ^b) a)
    let inline (|OriginalDefinition|) a = (^a: (member OriginalDefinition: ^b) a)
    let inline (|ReducedFrom|) a = (^a: (member ReducedFrom: ^b) a)

module ITypePatternOperation =
    let inline MatchedType a = (^a: (member MatchedType: ^b) a)
    let inline (|MatchedType|) a = (^a: (member MatchedType: ^b) a)

module ITypeSymbol =
    let inline TypeKind a = (^a: (member TypeKind: ^b) a)
    let inline BaseType a = (^a: (member BaseType: ^b) a)
    let inline Interfaces a = (^a: (member Interfaces: ^b) a)
    let inline AllInterfaces a = (^a: (member AllInterfaces: ^b) a)
    let inline IsReferenceType a = (^a: (member IsReferenceType: ^b) a)
    let inline IsValueType a = (^a: (member IsValueType: ^b) a)
    let inline IsAnonymousType a = (^a: (member IsAnonymousType: ^b) a)
    let inline IsTupleType a = (^a: (member IsTupleType: ^b) a)
    let inline IsNativeIntegerType a = (^a: (member IsNativeIntegerType: ^b) a)
    let inline OriginalDefinition a = (^a: (member OriginalDefinition: ^b) a)
    let inline SpecialType a = (^a: (member SpecialType: ^b) a)
    let inline IsRefLikeType a = (^a: (member IsRefLikeType: ^b) a)
    let inline IsUnmanagedType a = (^a: (member IsUnmanagedType: ^b) a)
    let inline IsReadOnly a = (^a: (member IsReadOnly: ^b) a)
    let inline IsRecord a = (^a: (member IsRecord: ^b) a)
    let inline NullableAnnotation a = (^a: (member NullableAnnotation: ^b) a)
    let inline (|TypeKind|) a = (^a: (member TypeKind: ^b) a)
    let inline (|BaseType|) a = (^a: (member BaseType: ^b) a)
    let inline (|Interfaces|) a = (^a: (member Interfaces: ^b) a)
    let inline (|AllInterfaces|) a = (^a: (member AllInterfaces: ^b) a)
    let inline (|IsReferenceType|) a = (^a: (member IsReferenceType: ^b) a)
    let inline (|IsValueType|) a = (^a: (member IsValueType: ^b) a)
    let inline (|IsAnonymousType|) a = (^a: (member IsAnonymousType: ^b) a)
    let inline (|IsTupleType|) a = (^a: (member IsTupleType: ^b) a)
    let inline (|IsNativeIntegerType|) a = (^a: (member IsNativeIntegerType: ^b) a)
    let inline (|OriginalDefinition|) a = (^a: (member OriginalDefinition: ^b) a)
    let inline (|SpecialType|) a = (^a: (member SpecialType: ^b) a)
    let inline (|IsRefLikeType|) a = (^a: (member IsRefLikeType: ^b) a)
    let inline (|IsUnmanagedType|) a = (^a: (member IsUnmanagedType: ^b) a)
    let inline (|IsReadOnly|) a = (^a: (member IsReadOnly: ^b) a)
    let inline (|IsRecord|) a = (^a: (member IsRecord: ^b) a)
    let inline (|NullableAnnotation|) a = (^a: (member NullableAnnotation: ^b) a)

module IUnaryOperation =
    let inline OperatorKind a = (^a: (member OperatorKind: ^b) a)
    let inline Operand a = (^a: (member Operand: ^b) a)
    let inline IsLifted a = (^a: (member IsLifted: ^b) a)
    let inline IsChecked a = (^a: (member IsChecked: ^b) a)
    let inline OperatorMethod a = (^a: (member OperatorMethod: ^b) a)
    let inline (|OperatorKind|) a = (^a: (member OperatorKind: ^b) a)
    let inline (|Operand|) a = (^a: (member Operand: ^b) a)
    let inline (|IsLifted|) a = (^a: (member IsLifted: ^b) a)
    let inline (|IsChecked|) a = (^a: (member IsChecked: ^b) a)
    let inline (|OperatorMethod|) a = (^a: (member OperatorMethod: ^b) a)

module IUsingDeclarationOperation =
    let inline DeclarationGroup a = (^a: (member DeclarationGroup: ^b) a)
    let inline IsAsynchronous a = (^a: (member IsAsynchronous: ^b) a)
    let inline (|DeclarationGroup|) a = (^a: (member DeclarationGroup: ^b) a)
    let inline (|IsAsynchronous|) a = (^a: (member IsAsynchronous: ^b) a)

module IUsingOperation =
    let inline Resources a = (^a: (member Resources: ^b) a)
    let inline Body a = (^a: (member Body: ^b) a)
    let inline Locals a = (^a: (member Locals: ^b) a)
    let inline IsAsynchronous a = (^a: (member IsAsynchronous: ^b) a)
    let inline (|Resources|) a = (^a: (member Resources: ^b) a)
    let inline (|Body|) a = (^a: (member Body: ^b) a)
    let inline (|Locals|) a = (^a: (member Locals: ^b) a)
    let inline (|IsAsynchronous|) a = (^a: (member IsAsynchronous: ^b) a)

module IVariableDeclarationGroupOperation =
    let inline Declarations a = (^a: (member Declarations: ^b) a)
    let inline (|Declarations|) a = (^a: (member Declarations: ^b) a)

module IVariableDeclarationOperation =
    let inline Declarators a = (^a: (member Declarators: ^b) a)
    let inline Initializer a = (^a: (member Initializer: ^b) a)
    let inline IgnoredDimensions a = (^a: (member IgnoredDimensions: ^b) a)
    let inline (|Declarators|) a = (^a: (member Declarators: ^b) a)
    let inline (|Initializer|) a = (^a: (member Initializer: ^b) a)
    let inline (|IgnoredDimensions|) a = (^a: (member IgnoredDimensions: ^b) a)

module IVariableDeclaratorOperation =
    let inline Symbol a = (^a: (member Symbol: ^b) a)
    let inline Initializer a = (^a: (member Initializer: ^b) a)
    let inline IgnoredArguments a = (^a: (member IgnoredArguments: ^b) a)
    let inline (|Symbol|) a = (^a: (member Symbol: ^b) a)
    let inline (|Initializer|) a = (^a: (member Initializer: ^b) a)
    let inline (|IgnoredArguments|) a = (^a: (member IgnoredArguments: ^b) a)

module IWhileLoopOperation =
    let inline Condition a = (^a: (member Condition: ^b) a)
    let inline ConditionIsTop a = (^a: (member ConditionIsTop: ^b) a)
    let inline ConditionIsUntil a = (^a: (member ConditionIsUntil: ^b) a)
    let inline IgnoredCondition a = (^a: (member IgnoredCondition: ^b) a)
    let inline (|Condition|) a = (^a: (member Condition: ^b) a)
    let inline (|ConditionIsTop|) a = (^a: (member ConditionIsTop: ^b) a)
    let inline (|ConditionIsUntil|) a = (^a: (member ConditionIsUntil: ^b) a)
    let inline (|IgnoredCondition|) a = (^a: (member IgnoredCondition: ^b) a)

module IWithOperation =
    let inline Operand a = (^a: (member Operand: ^b) a)
    let inline CloneMethod a = (^a: (member CloneMethod: ^b) a)
    let inline Initializer a = (^a: (member Initializer: ^b) a)
    let inline (|Operand|) a = (^a: (member Operand: ^b) a)
    let inline (|CloneMethod|) a = (^a: (member CloneMethod: ^b) a)
    let inline (|Initializer|) a = (^a: (member Initializer: ^b) a)
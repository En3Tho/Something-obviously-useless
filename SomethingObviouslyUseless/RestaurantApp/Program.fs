// Learn more about F# at http://docs.microsoft.com/dotnet/fsharp

open System
open System.Collections.Immutable
open System.ComponentModel
open System.Reflection
open System.Reflection.Emit
open System.Runtime.CompilerServices
open System.Text
open System.Text.Json
open System.Text.Json.Serialization
open System.Threading.Tasks
open En3Tho.FSharp.Extensions
open En3Tho.FSharp.GSeq
open En3Tho.FSharp.ComputationExpressions.ResultBuilder
open En3Tho.FSharp.Validation
open En3Tho.FSharp.Validation.CommonValidatedTypes
open FSharp.Reflection

module Seq =
    let toBlock seq =
        ImmutableArray.CreateRange seq

module Restaurant =
    type Name = NonEmptyString // generate active pattern via source generator
    let (|Name|) (value: Name) = value.Value

    type WaiterCode = NonNegativeValue<int>
    let (|WaiterCode|) (value: WaiterCode) = value.Value

    type Waiter = {
        Name: Name
        WaiterCode: WaiterCode
    }
    
    type ItemCode = NonNegativeValue<int>
    let (|ItemCode|) (value: ItemCode) = value.Value

    type ItemOriginAndCode =
        | Bar of ItemCode
        | Kitchen of ItemCode
        | Other of ItemCode
    
    type Price = NonNegativeValue<decimal>
    let (|Price|) (value: Price) = value.Value

    type RestaurantItem = {
        OriginAndCode: ItemOriginAndCode
        Name: Name
        Price: Price
    }
    
    type DailyGuestCode = NonNegativeValue<int>
    let (|DailyGuestCode|) (value: DailyGuestCode) = value.Value

    type NotEmptyBlock<'a> = NonEmptyCollection<ImmutableArray<'a>, 'a>
    let (|NotEmptyBlock|) (value: NotEmptyBlock<'a>) = value.Value

    type GuestOrder = {
        GuestCode: DailyGuestCode
        OrderedItems: RestaurantItem NotEmptyBlock voption
    }

    type GuestOrders = GuestOrder NotEmptyBlock
    let (|GuestOrders|) (value: GuestOrders) = value.Value

    type TableOrder = {
        GuestOrders: GuestOrders
        Waiter: Waiter
    }

    type Table = {
        TableOrder: TableOrder voption
    }
    
    type Menu = {
        AvailableItems: RestaurantItem NotEmptyBlock
    }
    
    type Restaurant = {
        Menu: Menu
        Tables: Table NotEmptyBlock
        Waiters: Waiter NotEmptyBlock
    }
    
    let createOrder (guestCode: int) items = eresult {
        let! guestCode = DailyGuestCode.Try guestCode
        return {
            GuestOrder.GuestCode = guestCode
            OrderedItems = items
        }
    }
    
    let addGuestOrder order (tableOrder: TableOrder) = eresult {
        let! guestOrders =
            tableOrder.GuestOrders.MapTry ^ fun block ->
                block.Add order
        return {
            tableOrder with
              GuestOrders = guestOrders
        }
    }
        
    let removeGuestOrder order (tableOrder: TableOrder) = eresult {
        let! guestOrders =
            tableOrder.GuestOrders.MapTry ^ fun block ->
                block
                |> GSeq.ofBlock
                |> GSeq.filter (fun x -> x.GuestCode <> order.GuestCode)
                |> GSeq.toBlock
        return {
            tableOrder with
              GuestOrders = guestOrders
        }
    }
    
module RestaurantItems =
    open Restaurant
    
    let tea = EResult.unwrap ^ eresult {
        let! name = Name.Try "Tea"
        let! originAndCode = ItemCode.Try 1 |> Result.map Bar
        let! price = Price.Try 10m
        return {
            RestaurantItem.Name = name
            OriginAndCode = originAndCode
            Price = price
        }
    }
    
    let coffee = EResult.unwrap ^ eresult {
        let! name = Name.Try "Coffee"
        let! originAndCode = ItemCode.Try 1 |> Result.map Bar
        let! price = Price.Try 15m
        return {
            RestaurantItem.Name = name
            OriginAndCode = originAndCode
            Price = price
        }
    }
    
    let hookah = EResult.unwrap ^ eresult {
        let! name = Name.Try "Hookah"
        let! originAndCode = ItemCode.Try 1 |> Result.map Other
        let! price = Price.Try 50m
        return {
            RestaurantItem.Name = name
            OriginAndCode = originAndCode
            Price = price
        }
    }

type Assets = NonNegativeValue<int>
type Liabilities = NonNegativeValue<int>
type Equities = NonNegativeValue<int>
type BalanceSheet = PlainValue<int>

type [<Struct>] AccountingBalanceData = {
    Assets: Assets
    Liabilities: Liabilities
    Equities: Equities
    BalanceSheet: BalanceSheet
}

module AccountingBalance =
    type DomainException<'a>(message, value) = inherit Exception($"Message: {message}; Value: {value}") // TODO: Read about globalization and write converters for http

    type SumOfParametersIsNotZero2<'a>(value) =
        inherit DomainException<'a>("Sum of parameters is not zero", value)

    exception SumOfParametersIsNotZero

    type [<Struct>] Validator =

        member this.Validate (value: AccountingBalanceData) =
            if value.Assets.Value + value.Liabilities.Value + value.Equities.Value + value.BalanceSheet.Value = 0 then Ok value
            else SumOfParametersIsNotZero2(value) :> exn |> Error

        interface IValidator<AccountingBalanceData> with
            member this.Validate value = this.Validate value
            member this.Validate value = this.Validate value |> ValueTask<_>
            member this.ValidateAggregate(value: AccountingBalanceData) = this.Validate value |> Result.mapError AggregateException
            member this.ValidateAggregate(value: AccountingBalanceData) = this.Validate value |> Result.mapError AggregateException |> ValueTask<_>

type AccountingBalance = NewCtorValidatorValidated<AccountingBalanceData, AccountingBalance.Validator>

[<NoEquality; NoComparison>]
type A =
    | A of int * int
    | B of Data: string

type Foo = struct
    end

and [<AbstractClass>] Bar() =
    abstract bar: foo: byref<Foo> -> unit

and [<AbstractClass; Sealed>] private BarImpl() =
        static member bar (foo: byref<Foo>) : unit = BarImpl.bar &foo

let bar =
    { new Bar() with
        override x.bar (foo: byref<Foo>) =
            x.bar(&foo) }

let bar2 =  { new Bar() with
       override x.bar (foo: byref<Foo>) =
           BarImpl.bar &foo } // tail call here

module Bar =
    let rec bar (foo: byref<Foo>) : unit = bar &foo

let bar3 = { new Bar() with
     override x.bar (foo: byref<Foo>) =
            Bar.bar &foo }  // tail call here

type Bar4() =
    inherit Bar()
    override x.bar (foo: byref<Foo>) = x.bar &foo

type IConvertible<'a> =
    abstract Convert: unit -> 'a
    abstract SetValuesFrom: 'a -> unit
    abstract SetValuesTo: 'a -> 'a

[<AbstractClass; Sealed>]
type Convertible<'a> =
    static member Convert (value: #IConvertible<'a>) = value.Convert()
    static member SetValuesFrom (value: #IConvertible<'a>, data: 'a) = value.SetValuesFrom(data)
    static member SetValuesTo (value: #IConvertible<'a>, data: 'a) = value.SetValuesTo(data)

type internal ConvertibleMock() =
    interface IConvertible<ConvertibleMock> with
        member this.Convert() = this
        member this.SetValuesFrom(value) = ()
        member this.SetValuesTo(value) = value

type [<CLIMutable; Struct>] UnionJsonSerializationEnvelope<'union, 'proxy when 'proxy :> IConvertible<'union>> = {
    mutable Tag: string
    mutable Body: 'proxy
} with
    interface IConvertible<'union> with
        member this.Convert() = this.Body.Convert()
        member this.SetValuesFrom(value: 'union) = this.Body.SetValuesFrom(value)
        member this.SetValuesTo(value: 'union) = this.Body.SetValuesTo(value)

type [<CLIMutable; Struct>] UnionJsonDeserializationEnvelope = {
    mutable Tag: string
    mutable Body: JsonElement
}

type [<CLIMutable; Struct>] PolymorphicExceptionTypeConvertibleBasedJsonEnvelope<'exn, 'proxy when 'exn :> exn and 'proxy :> IConvertible<'exn>> = {
    mutable Tag: string
    mutable Body: 'proxy
    mutable Exception: 'exn
} with
    interface IConvertible<'exn> with
        member this.Convert() = this.Body.Convert()
        member this.SetValuesFrom(value: 'exn) = this.Body.SetValuesFrom(value)
        member this.SetValuesTo(value: 'exn) = this.Body.SetValuesTo(value)

type ILGenChecker(ilGenerator: ILGenerator) =

    let mutable check = 0

    member private _.RefEquals() = typeof<Object>.GetMethod("ReferenceEquals")

    member private _.WriteLine<'a>() =
        typeof<Console>.GetMethod("WriteLine", [| typeof<'a> |])

    member this.EmitCheck() =
        ilGenerator.Emit(OpCodes.Ldc_I4, check)
        ilGenerator.Emit(OpCodes.Call, this.WriteLine<int>())
        check <- check + 1

    member this.EmitBoxNullCheck(objType: Type) = // to method?
        ilGenerator.Emit(OpCodes.Box, objType)
        ilGenerator.Emit(OpCodes.Ldnull)
        ilGenerator.Emit(OpCodes.Call, this.RefEquals())
        ilGenerator.Emit(OpCodes.Call, this.WriteLine<bool>())

    member this.EmitBoxWriteLine(objType: Type) = // to method?
        ilGenerator.Emit(OpCodes.Box, objType)
        ilGenerator.Emit(OpCodes.Ldnull)
        ilGenerator.Emit(OpCodes.Call, this.WriteLine<obj>())

type JsonProxyUnionTypeDeserializer<'result> = delegate of Utf8JsonReader byref * value: 'result * JsonSerializerOptions -> unit
type JsonProxyUnionTypeSerializer<'result> = delegate of Utf8JsonWriter * value: 'result * JsonSerializerOptions -> 'result

module ILGeneratorBuilder =

    type Label = Label
    type Local = Local of Type
    type Param = Param of Type

    // let! lb = Label

    // let! x = local<int> // local(typeof<int>)

    // param x(typeof<int>)
    // local y(typeof<int>)

    // label z

    type ILGeneratorArg =
        | Mark of Label
        | Jump of Label

    let inline emit value collection =
        ( ^a: (member Emit: ^b -> ^c) collection, value)

    [<AbstractClass;Extension>]
    type ILGeneratorExtensions() =
        [<Extension; EditorBrowsable(EditorBrowsableState.Never)>]
        static member inline Yield(collection, value: 'b) : CollectionCode = fun() -> emit value collection |> ignore
        [<Extension; EditorBrowsable(EditorBrowsableState.Never)>]
        static member inline YieldFrom(collection, values: 'b seq) : CollectionCode = fun() -> for value in values do emit value collection |> ignore


open ILGeneratorBuilder
module ProxyTypeGenerator =

    let [<Literal>] DynamicAssemblyName = "DynamicUnionCaseProxiesAssembly"
    let [<Literal>] DynamicModuleName = "DynamicUnionCaseProxiesModule"

    let makeModuleBuilder() =
        let assemblyName = AssemblyName(DynamicAssemblyName)
        let assemblyBuilder = AssemblyBuilder.DefineDynamicAssembly(assemblyName, AssemblyBuilderAccess.Run)
        assemblyBuilder, assemblyBuilder.DefineDynamicModule(DynamicModuleName)

    let internal assemblyBuilder, moduleBuilder = makeModuleBuilder()

    let makeStructProxyTypeBuilder (moduleBuilder: ModuleBuilder) (type': Type) =
        moduleBuilder.DefineType($"{type'.FullName}.Proxy", TypeAttributes.Public, typeof<ValueType>)

    let generateExceptionTypeProxyBody moduleBuilder (baseType: Type) (caseType: Type) (ctor: MethodInfo) (properties: PropertyInfo[]) =
        () // TODO

    let generateUnionTypeProxyBody moduleBuilder (baseType: Type) (derivedType: Type) (ctor: MethodInfo) (properties: PropertyInfo[]) =
        let proxyTypeBuilder = makeStructProxyTypeBuilder moduleBuilder derivedType

        let fields =
            properties
            |> Array.map ^ fun propInfo ->
                proxyTypeBuilder.DefineField(propInfo.Name, propInfo.PropertyType, FieldAttributes.Public)

        let duConvertibleInterface = typedefof<IConvertible<_>>.MakeGenericType(baseType)
        proxyTypeBuilder.AddInterfaceImplementation(duConvertibleInterface)

        let convertible = Unchecked.defaultof<IConvertible<_>>

        do
            let builder = proxyTypeBuilder.DefineMethod(nameof convertible.Convert, MethodAttributes.Public ||| MethodAttributes.Virtual, baseType, [||])
            let ilGen = builder.GetILGenerator()

            for field in fields do
                ilGen.Emit(OpCodes.Ldarg_0)
                ilGen.Emit(OpCodes.Ldfld, field)

            ilGen.Emit(OpCodes.Call, ctor)
            ilGen.Emit(OpCodes.Castclass, baseType)
            ilGen.Emit(OpCodes.Ret)

            proxyTypeBuilder.DefineMethodOverride(builder, duConvertibleInterface.GetMethod(nameof convertible.Convert))

        do
            let builder = proxyTypeBuilder.DefineMethod(nameof convertible.SetValuesFrom, MethodAttributes.Public ||| MethodAttributes.Virtual, null, [| baseType |])
            let ilGen = builder.GetILGenerator()

            ilGen.DeclareLocal(derivedType) |> ignore

            ilGen {
                OpCodes.Ldarg_1
                // LdArg_1 OpCodes.Ldarg_1
                // CastClass(derivedType)
                // Stloc_0
            } |> ignore

            ilGen.Emit(OpCodes.Ldarg_1)
            ilGen.Emit(OpCodes.Castclass, derivedType)
            ilGen.Emit(OpCodes.Stloc_0)

            (properties, fields)
            ||> Array.iter2 ^ fun property field ->
                ilGen.Emit(OpCodes.Ldarg_0)
                ilGen.Emit(OpCodes.Ldloc_0)
                ilGen.Emit(OpCodes.Call, property.GetMethod)
                ilGen.Emit(OpCodes.Stfld, field)

            ilGen.Emit(OpCodes.Ret)

            proxyTypeBuilder.DefineMethodOverride(builder, duConvertibleInterface.GetMethod(nameof convertible.SetValuesFrom))

        do
            let method = proxyTypeBuilder.DefineMethod(nameof convertible.SetValuesTo, MethodAttributes.Public ||| MethodAttributes.Virtual, baseType, [| baseType |])
            let ilGen = method.GetILGenerator() // simplified ilgen with compile time checking?

            ilGen.Emit(OpCodes.Ldarg_1)
            ilGen.Emit(OpCodes.Ret)

            proxyTypeBuilder.DefineMethodOverride(method, duConvertibleInterface.GetMethod(nameof convertible.SetValuesTo))

        proxyTypeBuilder.CreateType()

    let getUnionCaseCtor (baseType: Type) (caseType: Type) =
        let mainCtor = baseType.GetMethod($"New{caseType.Name}", BindingFlags.Public ||| BindingFlags.Static)
        match mainCtor with
        | null ->
            baseType.GetMethod($"get{caseType.Name}", BindingFlags.Public ||| BindingFlags.Static)
        | _ -> mainCtor

    let generateUnionTypeProxies<'a> moduleBuilder =

        let baseType = typeof<'a>
        if not ^ FSharpType.IsUnion baseType then
            invalidOp "Provided type is not union type"

        let caseTypes =
            baseType.Assembly.GetTypes()
            |> Array.filter ^ fun type' ->
                type'.BaseType = baseType

        baseType
        |> FSharpType.GetUnionCases
        |> Array.map ^ fun case ->
            let caseType = caseTypes.[case.Tag]
            let unionCaseCtor = getUnionCaseCtor baseType caseType
            generateUnionTypeProxyBody moduleBuilder baseType caseType unionCaseCtor (case.GetFields())

    let makeEnvelopeType (baseType: Type) (proxyType: Type) =
        typedefof<UnionJsonSerializationEnvelope<_,_>>.MakeGenericType(baseType, proxyType)

module JsonProxyUnionTypeFactory =
    [<AbstractClass; Sealed>]
    type internal Serializer() =

        // 'result is case type ?
        static member Serialize<'result, 'proxy when 'proxy :> IConvertible<'result> and 'proxy: (new: unit -> 'proxy)>(writer: Utf8JsonWriter, value: 'result, options: JsonSerializerOptions) =
            let proxy = new 'proxy()
            proxy.SetValuesFrom(value)
            let envelope: UnionJsonSerializationEnvelope<_,_> = { Tag = Union.getName value; Body = proxy }
            JsonSerializer.Serialize(writer, envelope, options)

        static member Deserialize<'result, 'myCaseProxy, 'myOtherCaseProxy when 'myCaseProxy :> IConvertible<'result>
                                                                            and 'myOtherCaseProxy :> IConvertible<'result>>
            (reader: Utf8JsonReader byref, options: JsonSerializerOptions) =

            match reader.Read() with
            | false ->
                Unchecked.defaultof<_>
            | _ ->
                let mutable result = Unchecked.defaultof<'result>

                // tryDeserialize()
                let name = "" // read string
                match name with
                | "MyCase" -> JsonSerializer.Deserialize<'myCaseProxy>(&reader, options).Convert()
                | _ -> JsonSerializer.Deserialize<'myOtherCaseProxy>(&reader, options).Convert()

    let makeSerializer<'result> (proxyType: Type) = ()
    let makeDeserializer<'result> (proxyType: Type) = ()

[<AbstractClass; Sealed>]
type internal UnionCaseMutableProxies<'a when 'a : not struct>() =

    [<DefaultValue(false)>]
    static val mutable private proxies: Type array
    [<DefaultValue(false)>]
    static val mutable private Serializers: JsonProxyUnionTypeSerializer<'a> array
    [<DefaultValue(false)>]
    static val mutable private Deserializers: JsonProxyUnionTypeDeserializer<'a> array

    static do
        UnionCaseMutableProxies<'a>.proxies <- ProxyTypeGenerator.generateUnionTypeProxies<'a> ProxyTypeGenerator.moduleBuilder

    static member Proxies = UnionCaseMutableProxies<'a>.proxies


// These should be generated case by case
type ProxyTypeUnionCaseConverter<'result, 'proxy when 'result: not struct // tcase
                                              and 'proxy: (new: unit -> 'proxy)
                                              and 'proxy :> IConvertible<'result>>
    () =
    inherit JsonConverter<'result>()

    let factories = Array.zeroCreate<JsonProxyUnionTypeDeserializer<'result>>

    override this.CanConvert(typeToConvert) =
        FSharpType.IsUnion typeToConvert

    override this.Write(writer, value, options) =
        let mutable proxy = new 'proxy()
        proxy.SetValuesFrom(value)
        JsonSerializer.Serialize(writer, proxy, options)

    override this.Read(reader, typeToConvert, options) =
        match reader.TokenType with
        | JsonTokenType.StartObject ->
            match reader.Read(), reader.TokenType with
            | true, JsonTokenType.String ->
                let unionTypeName = reader.GetString()
                // read tag. find proper factory by type and call it
                let proxy = JsonSerializer.Deserialize<'proxy>(&reader, options) // Delegate<'result>(&reader, options) =>
                Convertible.Convert(proxy)
            | _ -> Unchecked.defaultof<_>
        | _ ->
            Unchecked.defaultof<_>


//type ProxyTypeExceptionConverter<'result, 'converter, 'proxy when 'converter :> JsonConverter<'proxy>
//                                                              and 'result :> exn
//                                                              and 'proxy: (new: unit -> 'proxy)
//                                                              and 'proxy :> IConvertible<'result>>
//    (proxyConverter: 'converter) =
//    inherit JsonConverter<'result>()
//
//    override this.Write(writer, value, options) =
//        let mutable proxy = new 'proxy()
//        proxy.SetValuesFrom(value)
//        proxyConverter.Write(writer, proxy, options)
//    override this.Read(reader, typeToConvert, options) =
//        let basicExn: 'result = Unchecked.defaultof<_> // read via simple
//        let proxy = proxyConverter.Read(&reader, typeToConvert, options)
//        Convertible.SetValuesTo(proxy, basicExn)

// type UnionConverterFactory

type FSharpDiscriminatedUnionFactory() =
    inherit JsonConverterFactory()

    override this.CreateConverter(typeToConvert, options) =

        let converterTypeDef = typedefof<ProxyTypeUnionCaseConverter<ConvertibleMock,ConvertibleMock>>
        // get union by type and create converter
        failwith "sas"

    override this.CanConvert(typeToConvert) =
        not typeToConvert.IsValueType // always a base type?
        && FSharpType.IsUnion typeToConvert // deal with options?

type [<CLIMutable; Struct>] ExceptionEnvelope = {
    Tag: string
    Exception: Exception
}

type PolymorphicExceptionConverter() =
    inherit JsonConverter<Exception>()

    override this.CanConvert(typeToConvert) =
        typeToConvert.IsAbstract && FSharpType.IsUnion typeToConvert // FSharpOnlySupports

    override this.Write(writer, value, options) =
        writer.WriteStartObject()
        writer.WriteString("Tag", value.GetType().FullName)

        writer.WriteStartObject("Body")

        writer.WriteEndObject()

        let converter = options.GetConverter(value.GetType())

        writer.WriteEndObject()

    override this.Read(reader, typeToConvert, options) =
        if not (reader.Read()) then Unchecked.defaultof<_>
        else
            Unchecked.defaultof<_>


type DU =
    | A of Item1: int * int
    | B of string
    | C

type [<Struct>] AProxy =
    val mutable Item1: int
    val mutable Item2: int
    member this.SetValuesFrom(a: DU) =
        let (A(item1, item2)) = a
        this.Item1 <- item1
        this.Item2 <- item2

module Test =
    let test (a: DU, options) =
        let mutable proxy = AProxy()
        proxy.SetValuesFrom(a)
        JsonSerializer.Serialize(proxy, options)

exception MyExn of Tag: int * Value: int

type MyCustomExn(message, innerException: exn, value: int) =
    inherit exn(message, innerException)
    new (message, value) = MyCustomExn(message, null, value)
    member _.Value = value

type MyCustomType = {
    Name: string
    Age: int
}

type MyCustomData = {
    Tag: string
    Body: {|
        Name: string
        Age: int
    |}
}

[<Extension>]
type Utf8JsonReaderExtensions() =

    [<Extension>]
    static member TryReadToken(reader: Utf8JsonReader byref, token: JsonTokenType outref) =
        if reader.Read() then
            token <- reader.TokenType
            true
        else
            false

type MyCustomConverter() =
    inherit JsonConverter<MyCustomType>()

    override this.Write(writer, value, options) =
        let data: MyCustomData = {
             Tag = "MyCustomType"
             Body = {| Name = value.Name; Age = value.Age |}
        }
        JsonSerializer.Serialize(writer, data, options)

    override this.Read(reader, typeToConvert, options) =
        match reader.TryReadToken() with
        | true, JsonTokenType.PropertyName ->
            if reader.ValueSpan.SequenceEqual(Span.op_Implicit (Encoding.UTF8.GetBytes("Tag").AsSpan())) then
                match reader.TryReadToken() with
                | true, JsonTokenType.String ->
                    if reader.ValueSpan.SequenceEqual(Span.op_Implicit (Encoding.UTF8.GetBytes("MyCustomType").AsSpan())) then
                        printfn $"{reader.TokenType} - {reader.GetString()}"
                | _ -> ()
        | _ -> ()

        match reader.TryReadToken(), reader.TryReadToken() with
        | (true, JsonTokenType.PropertyName), (true, JsonTokenType.String) ->
            printfn $"{reader.TokenType} - {reader.GetString()}"
        | _ ->
            ()

        while reader.Read() do
            match reader.TokenType with
            | JsonTokenType.PropertyName
            | JsonTokenType.String ->
                printfn $"{reader.TokenType} - {reader.GetString()}"
            | JsonTokenType.Number ->
                printfn $"{reader.TokenType} - {reader.GetDouble()}"
            | _ ->
                printfn $"{reader.TokenType}"
        Unchecked.defaultof<_>

[<EntryPoint>]
let main argv =

    let a = A(5, 10)
    let b = B("string")

    let funcs: Func<string, DU>[] = Unchecked.defaultof<_>

    let printObjectsProperties value =
        let type' = value.GetType()
        printfn $"{type'.Name}"
        FSharpType.IsUnion type'
        |> printfn "Is union: %b"
        type'.GetProperties()
        |> Seq.iter (printfn "%O")

        printfn "Case fields"
        type'
        |> FSharpType.GetUnionCases
        |> Seq.iter ^ fun case ->
            printfn $"Case: {case.Name}"
            case.GetFields()
            |> Seq.iter (printfn "%O")

    [ a; b ]
    |> Seq.iter printObjectsProperties

    UnionCaseMutableProxies<DU>.Proxies
    |> Array.iter ^ fun type' ->
        printfn $"{type'.FullName}"
        type'.GetFields()
        |> Array.iter (printfn "%O")
        type'.GetMethods()
        |> Array.iter (printfn "%O")

//    UnionCaseMutableProxies<DU>.Proxies
//    |> Array.iter ^ fun proxyType ->
//
//        let conv = Activator.CreateInstance(proxyType) :?> IConvertible<DU>
//        conv.SetValuesFrom(A(1, 2))
//
//        conv
//        |> printfn "%O"

    let jsonOptions = JsonSerializerOptions()
    jsonOptions.Converters.Add(MyCustomConverter())

    let q = JsonSerializer.Serialize({ Name = ""; Age = 0 }, jsonOptions)
    let w = JsonSerializer.Deserialize<MyCustomType>(q, jsonOptions)

    let zzz = true || false

    let job value =
        printfn $"%b{value}"
        value

    let qqq = job true & job false

//    let str = MyCustomExn("Custom exception", 10) |> JsonSerializer.Serialize
//    let exn = str |> JsonSerializer.Deserialize<MyCustomExn>
//
//    printfn $"{str}"
//    printfn $"{exn.Value}"
//    printfn $"{exn}"
//
//    let str = MyExn(1, 2) |> JsonSerializer.Serialize
//    let exn = str |> JsonSerializer.Deserialize<MyExn>
//
//    printfn $"{str}"
//    printfn $"{exn.Tag} {exn.Value}"
//    printfn $"{exn}"

//    let createAccountingBalance() =
//        ValidationResult.trySetCurrentStackTrace ^ validate {
//            let! assets = Assets.Create 1
//            let! liabilities = Liabilities.Create 0
//            let! equities = Equities.Create 0
//            let! balanceSheet = BalanceSheet.Create 0
//            return! AccountingBalance.Create { Assets = assets; Liabilities =  liabilities; Equities = equities; BalanceSheet = balanceSheet }
//        }
//
//    let accountingBalance = createAccountingBalance() |> ValidationResult.unwrap

    0 // return an integer exit code
// Learn more about F# at http://docs.microsoft.com/dotnet/fsharp

open System
open System.Collections.Immutable
open System.Reflection
open System.Reflection.Emit
open System.Text.Json.Serialization
open System.Threading.Tasks
open En3Tho.FSharp.Extensions
open En3Tho.FSharp.GSeq
open En3Tho.FSharp.Validation
open En3Tho.FSharp.Validation.CommonTypes
open En3Tho.FSharp.Validation.ValidateComputationExpression
open FSharp.Reflection
open RestaurantApp

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
    
    let createOrder guestCode items = eresult {
        let! guestCode = DailyGuestCode.Try guestCode
        return {
            GuestOrder.GuestCode = guestCode
            OrderedItems = items
        }
    }
    
    let addGuestOrder order (tableOrder: TableOrder) = eresult {
        let! guestOrders =
            tableOrder.GuestOrders
            |> DomainEntity.map ^ fun block ->
                block.Add order
        return {
            tableOrder with
              GuestOrders = guestOrders
        }
    }
        
    let removeGuestOrder order (tableOrder: TableOrder) = eresult {
        let! guestOrders =
            tableOrder.GuestOrders
            |> DomainEntity.map ^ fun block ->
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

    let validate (value: AccountingBalanceData) =
        if value.Assets.Value + value.Liabilities.Value + value.Equities.Value + value.BalanceSheet.Value = 0 then Ok value
        else SumOfParametersIsNotZero2(value) :> exn |> Error

    type [<Struct>] Validator =
        interface IValidator<AccountingBalanceData> with
            member this.Validate value = validate value
            member this.Validate value = validate value |> ValueTask<_>

type AccountingBalance = DomainEntity10<AccountingBalanceData, AccountingBalance.Validator>

[<NoEquality; NoComparison>]
type A =
    | A of int * int
    | B of Data: string

module private ChoiGoiRecFunc =
    let rec udodo (z: int byref) = udodo &z

type ChoiGoi() =
    member this.Udodo(z: int byref) : unit =
        this.Udodo(&z)

    member this.Udodo2 (z: int byref) = ChoiGoiRecFunc.udodo &z

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

[<AbstractClass; Sealed>]
type private UnionCaseMutableProxies<'a>() =
    static let [<Literal>] DynamicAssemblyName = "DynamicUnionCaseProxiesAssembly"
    static let [<Literal>] DynamicModuleName = "DynamicUnionCaseProxiesModule"

    [<DefaultValue>]
    static val mutable private Proxies: Type array

    [<DefaultValue>]
    static val mutable private ModuleBuilder: ModuleBuilder

    let makeModuleBuilder() =
        let assemblyName = AssemblyName(DynamicAssemblyName)
        let assemblyBuilder = AssemblyBuilder.DefineDynamicAssembly(assemblyName, AssemblyBuilderAccess.Run)
        assemblyBuilder.DefineDynamicModule(DynamicModuleName)

    let makeStructProxyTypeBuilder (moduleBuilder: ModuleBuilder) (type': Type) =
        moduleBuilder.DefineType($"{type'.Name}Proxy", TypeAttributes.Public, typeof<ValueType>)

    let generateProxyFromProperties (type': Type) (properties: PropertyInfo[]) =
        let proxyTypeBuilder = makeStructProxyTypeBuilder UnionCaseMutableProxies<'a>.ModuleBuilder type'

        let unionCaseCtor = typeof<'a>.GetMethod($"New{type'.Name}", BindingFlags.Public ||| BindingFlags.Static)

        properties
        |> Seq.iter ^ fun propInfo ->
            let field = proxyTypeBuilder.DefineField(propInfo.Name, propInfo.DeclaringType, FieldAttributes.Public)
            ignore field

    let generateProxies() =
        let type' = typeof<'a>
        ()

[<CLIMutable; Struct>]
type DiscriminatedUnionEnvelope<'a> = {
    Tag: int
    Body: 'a
}

type FSharpDiscriminatedUnionEnvelopeConverter<'a>() =
    inherit JsonConverter<DiscriminatedUnionEnvelope<'a>>()

    override this.CanConvert(typeToConvert) =
        FSharpType.IsUnion typeToConvert

    override this.Write(writer, value, options) =
        failwith "todo"

    override this.Read(reader, typeToConvert, options) =
        failwith "todo"

type FSharpDiscriminatedUnionConverter<'a>() =
    inherit JsonConverter<'a>()

    override this.CanConvert(typeToConvert) =
        typeToConvert.IsAbstract && FSharpType.IsUnion typeToConvert // FSharpOnlySupports

    override this.Write(writer, value, options) =
        writer.WriteStartObject()
        writer.WriteNumber("Tag", Union.getTag value)
        writer.WriteStartObject()

        let converter = options.GetConverter(value.GetType())

        writer.WriteEndObject()

    override this.Read(reader, typeToConvert, options) =
        failwith "todo"

open Restaurant

[<EntryPoint>]
let main argv =

    let mutable a = Foo()
    bar2.bar(&a)
    //RoslynActivePatterns.generateActivePatterns()

//    let a = A(5, 10)
//    let b = B("string")
//
//    let printObjectsProperties value =
//        let type' = value.GetType()
//        printfn $"{type'.Name}"
//        FSharpType.IsUnion type'
//        |> printfn "Is union: %b"
//        type'.GetProperties()
//        |> Seq.iter (printfn "%O")
//
//        printfn "Case fields"
//        type'
//        |> FSharpType.GetUnionCases
//        |> Seq.iter ^ fun case ->
//            printfn $"Case: {case.Name}"
//            case.GetFields()
//            |> Seq.iter (printfn "%O")
//
//    [ a; b ]
//    |> Seq.iter printObjectsProperties

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
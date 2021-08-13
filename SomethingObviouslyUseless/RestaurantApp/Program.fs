// Learn more about F# at http://docs.microsoft.com/dotnet/fsharp

open System.Collections.Generic
open System.Collections.Immutable
open En3Tho.FSharp.GSeq
open En3Tho.FSharp.Validation
open En3Tho.FSharp.Validation.CommonTypes
open En3Tho.FSharp.Extensions.Core
open En3Tho.FSharp.Validation.ValidateComputationExpression

module Seq =
    let toBlock seq =
        ImmutableArray.CreateRange seq

module Restaurant =
    type Name = NonEmptyString
    type WaiterCode = NonNegativeValue<int>
    type Waiter = {
        Name: Name
        WaiterCode: WaiterCode
    }
    
    type ItemCode = NonNegativeValue<int>
    type ItemOriginAndCode =
        | Bar of ItemCode
        | Kitchen of ItemCode 
        | Other of ItemCode
    
    type Price = NonNegativeValue<decimal>
    type RestaurantItem = {
        OriginAndCode: ItemOriginAndCode
        Name: Name
        Price: Price
    }
    
    type DailyGuestCode = NonNegativeValue<int>
    type AtLeastOne<'a> = NonEmptyCollection<ImmutableArray<'a>, 'a>
    
    type GuestOrder = {
        GuestCode: DailyGuestCode
        OrderedItems: RestaurantItem AtLeastOne voption
    }
    
    type TableOrder = {
        GuestOrders: GuestOrder AtLeastOne
        Waiter: Waiter
    }
    
    type Table = {
        TableOrder: TableOrder voption
    }
    
    type Menu = {
        AvailableItems: RestaurantItem AtLeastOne
    }
    
    type Restaurant = {
        Menu: Menu
        Tables: Table AtLeastOne
        Waiters: Waiter AtLeastOne
    }
    
    let createOrder guestCode items = validate {
        let! guestCode = DailyGuestCode.Create guestCode
        return {
            GuestOrder.GuestCode = guestCode
            OrderedItems = items
        }
    }
    
    let addGuestOrder order (tableOrder: TableOrder) = validate {
        let! guestOrders =
            tableOrder.GuestOrders
            |> DomainEntity.update ^ fun block ->
                block.Add order
        return {
            tableOrder with
              GuestOrders = guestOrders
        }
    }
        
    let removeGuestOrder order (tableOrder: TableOrder) = validate {
        let! guestOrders =
            tableOrder.GuestOrders
            |> DomainEntity.update ^ fun block ->
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
    
    let tea = ValidationResult.unwrap ^ validate {
        let! name = Name.Create "Tea"
        let! originAndCode = ItemCode.Create 1 |> Result.map Bar
        let! price = Price.Create 10m
        return {
            RestaurantItem.Name = name
            OriginAndCode = originAndCode
            Price = price
        }
    }
    
    let coffee = ValidationResult.unwrap ^ validate {
        let! name = Name.Create "Coffee"
        let! originAndCode = ItemCode.Create 1 |> Result.map Bar
        let! price = Price.Create 15m
        return {
            RestaurantItem.Name = name
            OriginAndCode = originAndCode
            Price = price
        }
    }
    
    let hookah = ValidationResult.unwrap ^ validate {
        let! name = Name.Create "Hookah"
        let! originAndCode = ItemCode.Create 1 |> Result.map Other
        let! price = Price.Create 50m
        return {
            RestaurantItem.Name = name
            OriginAndCode = originAndCode
            Price = price
        }
    }

open Restaurant

type Assets = NonNegativeValue<int>
type Liabilities = NonNegativeValue<int>
type Equities = NonNegativeValue<int>
type BalanceSheet = PlainValue<int>
type AccountingBalanceData = (struct (Assets * Liabilities * Equities * BalanceSheet))

module AccountingBalance =
    exception SumOfParametersIsNotZero
    let validate ((assets, liabilities, equities, balanceSheet): AccountingBalanceData as values) =
        if assets.Value + liabilities.Value + equities.Value + balanceSheet.Value = 0 then Ok values
        else Error SumOfParametersIsNotZero

    type [<Struct>] Validator =
        interface IValidator<AccountingBalanceData> with
            member this.Validate value = validate value

type AccountingBalance = DomainEntity10<AccountingBalanceData, AccountingBalance.Validator>

type [<Struct>] AccountingBalanceData2 = {
    Assets: Assets
    Liabilities: Liabilities
    Equities: Equities
    BalanceSheet: BalanceSheet
}

module AccountingBalance2 =
    exception SumOfParametersIsNotZero
    let validate (value: AccountingBalanceData2) =
        if value.Assets.Value + value.Liabilities.Value + value.Equities.Value + value.BalanceSheet.Value = 0 then Ok value
        else Error SumOfParametersIsNotZero

    type [<Struct>] Validator =
        interface IValidator<AccountingBalanceData2> with
            member this.Validate value = validate value

type AccountingBalance2 = DomainEntity10<AccountingBalanceData2, AccountingBalance2.Validator>

module AccountingBalance3 =
    exception SumOfParametersIsNotZero
    type [<Struct>] AccountingBalance = private {
        Assets: Assets
        Liabilities: Liabilities
        Equities: Equities
        BalanceSheet: BalanceSheet
    } with
        static member Create assets liabilities equities balanceSheet = validate {
            let result = Ok { // for type inference
                AccountingBalance.Assets = assets
                Liabilities = liabilities
                Equities = equities
                BalanceSheet = balanceSheet
            }
            if assets.Value + liabilities.Value + equities.Value + balanceSheet.Value = 0 then
                return result
            else
                return Error SumOfParametersIsNotZero
        }

type AccountingBalance3 = AccountingBalance3.AccountingBalance

let accountingBalance = ValidationResult.unwrap ^ validate {
    let! assets = Assets.Create 0
    let! liabilities = Liabilities.Create 0
    let! equities = Equities.Create 0
    let! balanceSheet = BalanceSheet.Create 0
    return! AccountingBalance3.Create assets liabilities equities balanceSheet
}

[<EntryPoint>]
let main argv =

//    let hookah = validate {
//        let! name = Name.Create ""
//        and! originAndCode = ItemCode.Create -1 |> Result.map Other
//        and! price = Price.Create -1m
//        return {
//            RestaurantItem.Name = name
//            OriginAndCode = originAndCode
//            Price = price
//        }
//    }
//
//    match hookah with
//    | Ok item ->
//        printfn $"{item}"
//    | Error err ->
//        printfn $"{err}"

    let values = [| 1; 2; 3; 4; 5 |]
    let shouldBeEqual (f1: 'a -> 'b seq) (f2: 'a -> 'b seq) values =
        let seq1 = (f1 values).GetEnumerator()
        let seq2 = (f2 values).GetEnumerator()

        let mutable goNext = true
        let mutable equals = true
        while goNext do
            match seq1.MoveNext(), seq2.MoveNext() with
            | true, true -> printfn $"{seq1.Current} - {seq2.Current}"
            | false, true -> printfn $"None - {seq2.Current}"; equals <- false
            | true, false -> printfn $"{seq1.Current} - None"; equals <- false
            | _ ->
                printfn "Done."
                goNext <- false

        printfn $"Equals: {equals}"
        
    values |> shouldBeEqual
                  (fun x -> x |> Seq.where (fun x -> x <> 2) |> Seq.map string |> Seq.take 2)
                  (fun x -> x |> GSeq.ofArray |> GSeq.filter (fun x -> x <> 2) |> GSeq.map string |> GSeq.take 2 |> GSeq.toSeq)

    0 // return an integer exit code
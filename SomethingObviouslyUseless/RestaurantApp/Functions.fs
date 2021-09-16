module RestaurantApp.Functions

open System

type BusinessObject = {
    Value: int
}

module BusinessLogic =
    let processObj logTrace logErr obj = {
        obj with Value = obj.Value + 1
    }

    let getProcessSaveObj logTrace logErr getObj saveObj =
        getObj()
        |> processObj logTrace logErr
        |> saveObj

type IDB =
    abstract member GetObject: unit -> BusinessObject
    abstract member SaveObject: BusinessObject -> unit

type ILogger =
    abstract member LogTrace: obj -> unit
    abstract member LogError: obj -> unit

module BusinessLogic2 =
    let processObj (logger: ILogger) obj = {
        obj with Value = obj.Value + 1
    }

    let getProcessSaveObj (logger: ILogger) (db: IDB) =
        db.GetObject()
        |> processObj logger
        |> db.SaveObject

type DB() =
    member _.GetObject() = { Value = 0 }
    member _.SaveObject(obj: BusinessObject) = ()

type Notifications() =
    member _.SendUpdateNotification(obj: BusinessObject) = ()

type SomeType(db: DB, notifications: Notifications) =
    member _.GetProcessSaveObj() =
        let logTrace = ignore
        let logError = ignore
        let saveObj x =
            db.SaveObject x
            notifications.SendUpdateNotification x

        BusinessLogic.getProcessSaveObj logTrace logError db.GetObject saveObj
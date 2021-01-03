namespace En3Tho.FSharpExtensions

//module Option =
//    type Option<'a> with
//        static member IfThenElse (value, ifTrue, ifFalse, option) =
//            if option |> Option.contains value then ifTrue else ifFalse
//
//        static member IfThenElse (value, ifTrue, ifFalse, option) =
//            if option |> Option.contains value then ifTrue else ifFalse()
//
//        static member IfThenElse (value, ifTrue, ifFalse, option) =
//            if option |> Option.contains value then ifTrue() else ifFalse
//
//        static member IfThenElse (value, ifTrue, ifFalse, option) =
//            if option |> Option.contains value then ifTrue() else ifFalse()
//
//        static member IfThenElse (value, ifTrue, ifFalse, option) =
//            if option |> Option.exists value then ifTrue else ifFalse
//
//        static member IfThenElse (thunk, ifTrue, ifFalse, option) =
//            if option |> Option.exists thunk then ifTrue() else ifFalse()
//
//        static member IfThenElse (thunk, ifTrue, ifFalse, option) =
//            if option |> Option.exists thunk then ifTrue else ifFalse()
//
//        static member IfThenElse (thunk, ifTrue, ifFalse, option) =
//            if option |> Option.exists thunk then ifTrue() else ifFalse
//
//    let inline ifThenElse (value : ^a) (ifTrue : ^b) (ifFalse : ^b) (option : ^a option) =
//        Option.IfThenElse(value, ifTrue, ifFalse, option)
//
//    let test() =
//        let opt = Some true
//        let test1 = opt |> ifThenElse true 1 2
//        let test2 = opt |> ifThenElse (fun _ -> true) 1 2
//        let test3 = opt |> ifThenElse true (fun() -> 1) (fun() -> 2)
//        1
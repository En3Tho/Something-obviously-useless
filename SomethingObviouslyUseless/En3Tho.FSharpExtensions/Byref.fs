namespace En3Tho.FSharpExtensions

module Byref =
    module Operatos =
        let inline inc (a : 'a byref) = a <- a + LanguagePrimitives.GenericOne
        let inline dec (a : 'a byref) = a <- a - LanguagePrimitives.GenericOne
        let inline neg (a : 'a byref) = a <- (~-)a
        let inline (+<-) (a : 'a byref) v = a <- a + v
        let inline (-<-) (a : 'a byref) v = a <- a - v
        let inline (/<-) (a : 'a byref) v = a <- a / v
        let inline (%<-) (a : 'a byref) v = a <- a % v
        let inline ( *<- ) (a : 'a byref) v = a <- a * v
        let inline (~~~) (a : 'a byref) = a <- ~~~a
        let inline (&&&<-) (a : 'a byref) v = a <- a &&& v
        let inline (|||<-) (a : 'a byref) v = a <- a ||| v
        let inline (^^^<-) (a : 'a byref) v = a <- a ^^^ v
        let inline (<<<<-) (a : 'a byref) v = a <- a <<< v
        let inline (>>><-) (a : 'a byref) v = a <- a >>> v
        let inline (&&<-) (a : bool byref) v = a <- a && v
        let inline (||<-) (a : bool byref) v = a <- a || v
        let inline ( **<- ) (a : 'a byref) v = a <- a ** v
        
    module Setters =
        let inline setv (a : 'a byref) v = a <- v
        let inline setfn (a : 'a byref) f v = a <- f v
        let inline seti (a : 'a byref) v _ = a <- v
        let inline setTrue (a : bool byref) _ = a <- true
        let inline setFalse (a : bool byref) _ = a <- false
        let inline setZero (a : int byref) _ = a <- 0
        let inline setOne (a : int byref) _ = a <- 1
        let inline setMinusOne (a : int byref) _ = a <- -1
        let inline setParse (a : 'a byref) v = a <- (^a : (static member Parse : string -> 'a) (v))
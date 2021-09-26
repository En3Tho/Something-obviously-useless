module Gists.FSharp.Stuff

open System.Collections.Generic
open System.Linq

let convertTo<'col, 'elem when 'col :> ICollection<'elem> and 'col: (new: unit -> 'col)> seq =
    let collection = new 'col()
    for value in seq do collection.Add value
    collection

let test() =
    let data = Enumerable.Range(0, 20)
    let set: HashSet<_> = data |> convertTo
    let linkedList: LinkedList<_> = data |> convertTo
    let list: ResizeArray<_> = data |> convertTo
    ()



//public static ICollection<A> To<T, A>(this IEnumerable<A> xs)
//            where T : ICollection<A>, new()
//        {
//            var ta = new T();
//            foreach(var x in xs) {
//                ta.Add(x);
//            }
//            return ta;
//        }
//
//        public static void Test()
//        {
//            var data = Enumerable.Range(0, 20);
//
//            var set = data.To<HashSet<int>, int>(); // sorcery!
//
//            var linkedList = data.To<LinkedList<int>, int>();
//
//            var list = data.To<List<int>, int>();
//        }
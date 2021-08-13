// using System;
// using System.Collections.Generic;
// using System.Runtime.CompilerServices;
// using BenchmarkDotNet.Attributes;
// using En3Tho.ValueTupleExtensions;
// using En3Tho.ValueTupleExtensions.LinqLikeExtensions;
//
// namespace Benchmarks.BenchmarkDotNet
// {
//     [MemoryDiagnoser]
//     public class ContainsBenchmark
//     {
//         public enum S
//         {
//             A, B, C, D, E, F, G, H
//         }
//         
//         [Params(12)]
//         public int Value { get; set; }
//
//         [Benchmark]
//         public void ContainsAny()
//         {
//             (12, 2323, 35453).ContainsAny((231, 22, 222));
//         }
//         
//         [Benchmark]
//         public void ContainsEnum2()
//         {
//             (S.A, S.B).Contains(S.C);
//         }
//         
//         [Benchmark]
//         public void ContainsEnum7()
//         {
//             (S.A, S.B, S.C, S.D, S.E, S.F, S.G).Contains(S.H);
//         }
//         
//         [Benchmark]
//         public void ContainsAnyEnum()
//         {
//             (S.C, S.B, S.C).ContainsAny((S.A, S.B));
//         }
//     }
// }
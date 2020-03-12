﻿using System;
using BenchmarkDotNet.Attributes;
using Benchmarks.Classes;
using ExtensionsAndStuff.ValueTupleExtensions;

namespace Benchmarks
{
    [MemoryDiagnoser]
    public class ContainsBenchmark
    {
        public enum S
        {
            A,B,C
        }
        
        [Params(12)]
        public int Value { get; set; }

        [Benchmark]
        public void ContainsAny()
        {
            (12, 2323, 35453).ContainsAny((231, 22, 222));
        }
        
        [Benchmark]
        public void ContainsEnum()
        {
            (S.A, S.B).Contains(S.C);
        }
        
        [Benchmark]
        public void ContainsAnyEnum()
        {
            (S.C, S.B, S.C).ContainsAny((S.A, S.B));
        }
    }
}
﻿using System;
using System.Collections.Generic;
using System.Text;
using BenchmarkDotNet.Attributes;
using ExtensionsAndStuff.ValueTupleExtensions;

namespace Benchmarks.Benchmarks
{
    [MemoryDiagnoser]
    public class ValueTupleSorting
    {
        [Benchmark]
        public void SortArray()
        {
            var ar = new int[] { 22, 118, 453, 671, -123, -2113, 2323 };
            Array.Sort(ar);
        }        

        [Benchmark]
        public void SortSingleInline()
        {
            var result = (22, 118, 453, 671, -123, -2113, 2323).Sort(Comparer<int>.Default);
        }

        [Benchmark]
        public void SortByDoubleInline()
        {
            var result = (22, 118, 453, 671, -123, -2113, 2323).Sort(x => x);
        }
    }
}
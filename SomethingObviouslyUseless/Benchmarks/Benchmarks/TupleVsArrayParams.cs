﻿using System.Collections.Generic;
using System.Runtime.InteropServices;
using BenchmarkDotNet.Attributes;
using Benchmarks.Classes;
using En3Tho.ValueTupleExtensions;
using ExtensionsAndStuff.ReferenceStackAllocation;
using ExtensionsAndStuff.RefStructs.SpanList;

namespace Benchmarks.Benchmarks
{
    [MemoryDiagnoser]
    public class TupleVsArrayParams
    {
        public ParamsHolder Holder { get; } = new ParamsHolder();

        [Benchmark]
        public void CallParamsClass()
        {
            Holder.ParamsClass(new object(), new object(), new object(), new object(), new object(), new object(), new object());
        }

        [Benchmark]
        public void CallParamsTuple()
        {
            Holder.ParamsTuple((new object(), new object(), new object(), new object(), new object(), new object(), new object()).AsSpan());
        }

        [Benchmark]
        public void CallParamsTuple2()
        {
            var t = (new object(), new object(), new object(), new object(), new object(), new object(), new object());            
            Holder.ParamsTuple(MemoryMarshal.CreateSpan(ref t.Item1, 7));
        }

        [Benchmark]
        public void CallParamsSpanList()
        {
            var list = new SpanList<object>(StackAlloc.Alloc64<object>().AsSpan());
            list.Add(new object());
            list.Add(new object());
            list.Add(new object());
            list.Add(new object());
            list.Add(new object());
            list.Add(new object());
            list.Add(new object());

            Holder.ParamsTuple(list.Slice());
        }

        public void Tst()
        {
            var list = new List<object>();            
        }
    }
}
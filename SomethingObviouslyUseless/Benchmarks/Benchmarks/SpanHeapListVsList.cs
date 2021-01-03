using System;
using System.Collections.Generic;
using System.Text;
using BenchmarkDotNet.Attributes;
using ExtensionsAndStuff.ReferenceStackAllocation;
using ExtensionsAndStuff.RefStructs;
using ExtensionsAndStuff.RefStructs.SpanList;

namespace Benchmarks.BenchmarkDotNet
{
    [MemoryDiagnoser]
    public class SpanHeapListVsList
    {
        [Params(10, 50, 100, 1000)]
        public int Count { get; set; }
        public object[] Objects { get; set; }

        [GlobalSetup]
        public void GlobalSetup()
        {
            Objects = new object[Count];
            for (int i = 0; i < Objects.Length; i++)
            {
                Objects[i] = new object();
            }
        }

        [Benchmark]
        public void List()
        {
            var list = new List<object>(64);
            foreach (var item in Objects)
            {
                list.Add(item);
            }
        }

        [Benchmark]
        public void MiniList()
        {
            var list = new MiniList<object>();
            foreach (var item in Objects)
            {
                list.Add(item);
            }
        }

        [Benchmark]
        public void SpanHeapList()
        {
            var list = new SpanHeapList<object>(ReferenceStackAlloc.Alloc64<object>().AsSpan());
            foreach (var item in Objects)
            {
                list.Add(item);
            }
        }
    }
}

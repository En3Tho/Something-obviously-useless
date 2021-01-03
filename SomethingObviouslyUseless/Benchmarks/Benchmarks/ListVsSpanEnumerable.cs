using System.Collections.Generic;
using System.Linq;
using BenchmarkDotNet.Attributes;
using Benchmarks.Classes;
using ExtensionsAndStuff.ReferenceStackAllocation;
using ExtensionsAndStuff.RefStructs.SpanList;
using ExtensionsAndStuff.Unsafe.SpanHeapListExtensions;

namespace Benchmarks.BenchmarkDotNet
{
    [MemoryDiagnoser]
    public class ListVsSpanEnumerable
    {
        [Params(10, 50, 100, 1000)]
        public int Count { get; set; }
        public A[] Array { get; set; }

        [GlobalSetup]
        public void GlobalSetup()
        {
            Array = new A[Count];
            for (int i = 0; i < Array.Length; i++)
            {
                Array[i] = new A { Num =  i };    
            }
        }

        [Benchmark]
        public int BenchList()
        {
            var list = new List<A>(64);
            for (int i = 0; i < Array.Length; i++)
            {
                if (i % 2 == 0)
                    list.Add(Array[i]);
            }
        
            return list.Max(x => x.Num);
        }

        [Benchmark]
        public int BenchSpanHeapList()
        {
            var list = new SpanHeapList<A>(ReferenceStackAlloc.Alloc64<A>().AsSpan());
            for (int i = 0; i < Array.Length; i++)
            {
                if (i % 2 == 0)
                    list.Add(Array[i]);
            }

            return list.AsEnumerable().Max(x => x.Num);
        }
    }
}
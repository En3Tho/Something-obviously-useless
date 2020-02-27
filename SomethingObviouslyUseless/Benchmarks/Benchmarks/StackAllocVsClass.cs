using System;
using BenchmarkDotNet.Attributes;
using ExtensionsAndStuff.ReferenceStackAllocation;

namespace Benchmarks.Benchmarks
{
    [MemoryDiagnoser]
    public class StackAllocVsClass
    {
        [Benchmark]
        public void CreateObjectsArray()
        {
            var arr = new object[64];
            var span = arr.AsSpan();
            for (int i = 0; i < span.Length; i++)
            {
                span[i] = new object();
            }
        }

        [Benchmark]
        public void CreateObjectsStack()
        {
            var span = StackAlloc.AllocSpan64<object>();
            for (int i = 0; i < span.Length; i++)
            {
                span[i] = new object();
            }
        }
    }
}
using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using En3Tho.HelperClasses.StackAlloc;
using ExtensionsAndStuff.ReferenceStackAllocation;
using ExtensionsAndStuff.RefStructs.SpanList;

namespace Benchmarks.BenchmarkDotNet
{
    [MemoryDiagnoser]
    [SimpleJob(RuntimeMoniker.NetCoreApp31)]
    [SimpleJob(RuntimeMoniker.NetCoreApp50)]
    [SimpleJob(RuntimeMoniker.CoreRt50)]
    public class StackAllocVsClass
    {
        private readonly object _value = new ();
        
        [Benchmark]
        public object CreateObjectsArray()
        {
            var arr = new object[64];
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = _value;
            }

            return arr[^1];
        }

        [Benchmark]
        public object CreateObjectsStack()
        {
            var span = ReferenceStackAlloc.Alloc64<object>().AsSpan();
            for (int i = 0; i < span.Length; i++)
            {
                span[i] = _value;
            }

            return span[^1];
        }
        
        [Benchmark]
        public object CreateObjectsStackList64()
        {
            var stacklist = StackList<object>.Create64();
            for (int i = 0; i < stacklist.Length; i++)
            {
                stacklist.Add(_value);
            }

            return stacklist[63];
        }
    }
}
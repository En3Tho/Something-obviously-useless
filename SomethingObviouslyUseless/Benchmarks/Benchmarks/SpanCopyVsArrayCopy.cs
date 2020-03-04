using System;
using System.Runtime.CompilerServices;
using BenchmarkDotNet.Attributes;

namespace Benchmarks.Benchmarks
{
    [MemoryDiagnoser]
    public class SpanCopyVsArrayCopy
    {
        [Params(10, 50, 100, 1000)] public int Count { get; set; }
        public object[] From { get; set; }
        public object[] To { get; set; }

        [GlobalSetup]
        public void GlobalSetup()
        {
            From = new object[Count];
            To = new object[Count];
            for (int i = 0; i < Count; i++)
            {
                From[i] = new object();
            }
        }

        [Benchmark]
        public void ArrayCopy()
        {
            Array.Copy(From, 0, To, 0, From.Length);
        }

        [Benchmark]
        public void SpanCopy()
        {
            From.AsSpan().CopyTo(To);
        }
    }
}
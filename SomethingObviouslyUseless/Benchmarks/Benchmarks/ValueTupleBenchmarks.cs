using System;
using System.Collections.Generic;
using BenchmarkDotNet.Attributes;
using ExtensionsAndStuff.ValueTupleExtensions;

namespace Benchmarks.Benchmarks
{
    [MemoryDiagnoser]
    public class ValueTupleBenchmarks
    {
        [Params(10, 100, 1000)]
        public int Count { get; set; }

        public int[] Array1 { get; set; }
        public int[] Array2 { get; set; }
        public int[] Array3 { get; set; }

        public (ICollection<int>, ICollection<int>, ICollection<int>) AsCollection { get; set; }

        [GlobalSetup]
        public void GlobalSetup()
        {
            Array1 = new int[Count];
            Array2 = new int[Count];
            Array3 = new int[Count];         
            AsCollection = (Array1, Array2, Array3).As<ICollection<int>>();
        }

        [Benchmark]
        public int[] TestTupleToArrayAsCollection()
        {
            return AsCollection.ToArray();
        }

        [Benchmark]
        public int[] TestTupleToArray()
        {
            return (Array1, Array2, Array3).ToArray();
        }

        [Benchmark]
        public int[] TestToArrayReference()
        {
            var result = new int[Array1.Length + Array2.Length + Array3.Length];

            Array.Copy(Array1, 0, result, 0, Array1.Length); var count = Array1.Length;
            Array.Copy(Array2, 0, result, count, Array2.Length); count += Array2.Length;
            Array.Copy(Array3, 0, result, count, Array3.Length);

            return result;
        }
    }
}

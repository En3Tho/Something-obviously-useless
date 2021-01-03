using System.Runtime.CompilerServices;
using BenchmarkDotNet.Attributes;
using VT7 = System.ValueTuple<int, int, int, int, int, int, int>;
using VT8 = System.ValueTuple<int, int, int, int, int, int, int, System.ValueTuple<int>>;
using VT16 = System.ValueTuple<int, int, int, int, int, int, int, System.ValueTuple<int, int, int, int, int, int, int, System.ValueTuple<int, int>>>;

namespace Benchmarks.BenchmarkDotNet
{
    [MemoryDiagnoser]
    public class ValueTupleLengthBenchmark
    {
        public VT7 T7 = (5, 5, 5, 5, 5, 5, 5);
        public VT8 T8 = (5, 5, 5, 5, 5, 5, 5, 5);
        public VT16 T16 = (5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5);

        public int Length<T>(T vt) where T : struct, ITuple
        {
            return vt.Length;
        }

        [Benchmark]
        public int T7Value() => T7.Item7;
        
        [Benchmark]
        public int T8Value() => T8.Item8;
        
        [Benchmark]
        public int T16Value() => T16.Item16;
            
        [Benchmark]
        public int LengthBenchmark7() => Length(T7);

        [Benchmark]
        public int LengthBenchmark8() => Length(T8);

        [Benchmark]
        public int LengthBenchmark16() => Length(T16);
    }
}
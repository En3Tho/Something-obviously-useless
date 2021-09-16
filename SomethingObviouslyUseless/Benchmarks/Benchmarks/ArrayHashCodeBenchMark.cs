using System;
using System.Runtime.InteropServices;
using BenchmarkDotNet.Attributes;

namespace Benchmarks.Benchmarks
{
    [MemoryDiagnoser]
    public class ArrayHashCodeBenchmark
    {
        [Params(5, 10, 16, 30, 63, 64, 100)]
        public int Count { get; set; }

        public byte[] Values { get; set; }

        [GlobalSetup]
        public void GlobalSetup()
        {
            Values = new byte[Count];
            new Random().NextBytes(Values);
        }

        public static int CalculateHash(ReadOnlyMemory<byte> obj)
        {
            var hashCode = new HashCode();
            var reminder = obj.Length % 4;
            var length = Math.Min(obj.Length - reminder, 64);
            foreach (var intValue in MemoryMarshal.Cast<byte, int>(obj.Span[..length]))
                hashCode.Add(intValue);

            if (length != 64 && reminder > 0)
                foreach (var byteValue in obj.Span[^reminder..])
                    hashCode.Add(byteValue);

            return hashCode.ToHashCode();
        }

        public static int CalculateHash2(ReadOnlyMemory<byte> obj)
        {
            var hashCode = new HashCode();
            Span<byte> bytes = stackalloc byte[64];
            obj.Span[..Math.Min(obj.Length, 64)].CopyTo(bytes);

            foreach (var intValue in MemoryMarshal.Cast<byte, int>(bytes))
                hashCode.Add(intValue);

            return hashCode.ToHashCode();
        }

        [Benchmark]
        public int TestCalcHash() => CalculateHash(Values);

        [Benchmark]
        public int TestCalcHash2() => CalculateHash2(Values);
    }
}
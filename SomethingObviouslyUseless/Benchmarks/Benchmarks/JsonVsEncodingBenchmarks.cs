using System;
using System.Buffers;
using System.Text;
using System.Text.Json;
using BenchmarkDotNet.Attributes;

namespace Benchmarks.Benchmarks
{
    [MemoryDiagnoser]
    public class JsonVsEncodingBenchmarks
    {
        public const string Abc = "AbcAbcAbcAbcAbc®®®®®®®®®®®®®®®";

        private static readonly ArrayBufferWriter<byte> _bufferWriter = new();
        private static readonly Utf8JsonWriter _writer = new(_bufferWriter);

        [Benchmark]
        public int JsonSerialize()
        {
            JsonSerializer.Serialize(_writer, Abc);
            _writer.Reset();
            _bufferWriter.Clear();
            return _writer.BytesPending;
        }

        [Benchmark]
        public int GetBytes()
        {
            Span<byte> span = stackalloc byte[Encoding.UTF8.GetByteCount(Abc)];
            Encoding.UTF8.GetBytes(Abc, span);
            return span.Length;
        }
    }
}
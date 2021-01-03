using System;
using System.Buffers;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.Json;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using En3Tho.HelperClasses;
using En3Tho.HelperClasses.Json;

namespace Benchmarks.Benchmarks
{
    [MemoryDiagnoser]
    [SimpleJob(RuntimeMoniker.NetCoreApp31)]
    [SimpleJob(RuntimeMoniker.NetCoreApp50)]
    public class JsonBenchmarks
    {
        public static readonly Sos Sos = new();
        public static readonly StringBuilder StringBuilder = new();
        public static readonly StringBuilder StringBuilder2 = new();
        public static readonly StringBuilderBufferWriter StringBuilderBufferWriter = new(StringBuilder);
        public static readonly ArrayBufferWriter<byte> ArrayBufferWriter = new();

        [Benchmark]
        public Sos BenchJsonStringBuilder()
        {
            var writer = new Utf8JsonWriter(StringBuilderBufferWriter);
            for (int i = 0; i < 100; i++)
            {
                JsonSerializer.Serialize(writer, Sos);
                writer.Reset();
            }

            StringBuilder.Clear();
            return Sos;
        }

        [Benchmark]
        public Sos BenchJsonStringBuilderSingle()
        {
            var writer = new Utf8JsonWriter(StringBuilderBufferWriter);
            JsonSerializer.Serialize(writer, Sos);
            writer.Reset();
            StringBuilder.Clear();
            return Sos;
        }

        [Benchmark]
        public Sos BenchJsonString()
        {
            for (int i = 0; i < 100; i++)
                JsonSerializer.Serialize(Sos);

            return Sos;
        }

        [Benchmark]
        public Sos BenchJsonStringSingle()
        {
            JsonSerializer.Serialize(Sos);
            return Sos;
        }

        [Benchmark]
        public Sos BenchJsonStringWithBuilder()
        {
            for (int i = 0; i < 100; i++)
                StringBuilder2.Append(JsonSerializer.Serialize(Sos));
            StringBuilder2.Clear();
            return Sos;
        }

        [Benchmark]
        public Sos BenchJsonBytes()
        {
            for (int i = 0; i < 100; i++)
                JsonSerializer.SerializeToUtf8Bytes(Sos);

            return Sos;
        }

        [Benchmark]
        public Sos BenchJsonBytesBuffer()
        {
            var writer = new Utf8JsonWriter(ArrayBufferWriter);
            for (int i = 0; i < 100; i++)
            {
                JsonSerializer.Serialize(writer, Sos);
                writer.Reset();
            }
            ArrayBufferWriter.Clear();
            return Sos;
        }

        [Benchmark]
        public Sos BenchJsonBytesSingle()
        {
            JsonSerializer.SerializeToUtf8Bytes(Sos);
            return Sos;
        }
    }

    public class Sos
    {
        public string Name1 { get; } = "sdadsaskjasdajksdsjkaыфвывфҐы№№є]ВЋ}±±’ЛV#C#9CN:ҐQ:У“ГђВфЕЕРРЉ";
        public string Name2 { get; } = "sdadsaskjasdajksdsjkaыфвывфҐы№№є]ВЋ}±±’ЛV#C#9CN:ҐQ:У“ГђВфЕЕРРЉ";
        public string Name3 { get; } = "sdadsaskjasdajksdsjkaыфвывфҐы№№є]ВЋ}±±’ЛV#C#9CN:ҐQ:У“ГђВфЕЕРРЉ";
        public string Name4 { get; } = "sdadsaskjasdajksdsjkaыфвывфҐы№№є]ВЋ}±±’ЛV#C#9CN:ҐQ:У“ГђВфЕЕРРЉ";
        public string Name5 { get; } = "sdadsaskjasdajksdsjkaыфвывфҐы№№є]ВЋ}±±’ЛV#C#9CN:ҐQ:У“ГђВфЕЕРРЉ";
        public long Value1 { get; } = long.MaxValue;
        public long Value2 { get; } = long.MaxValue - 1;
        public long Value3 { get; } = long.MaxValue - 2;
        public long Value4 { get; } = long.MaxValue - 3;
        public long Value5 { get; } = long.MaxValue - 4;
    }
}
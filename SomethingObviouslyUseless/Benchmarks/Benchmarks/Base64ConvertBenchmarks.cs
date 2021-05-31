using System;
using System.Buffers;
using System.Globalization;
using System.Text;
using BenchmarkDotNet;
using BenchmarkDotNet.Attributes;

namespace Benchmarks
{
    [GcServer(true)]
    [MemoryDiagnoser]
    [MarkdownExporterAttribute.GitHub]
    public class Base64ConvertBenchmarks
    {
        private const char base64PadCharacter = '=';

        private static string doubleBase64PadCharacter =
            string.Format(CultureInfo.InvariantCulture, "{0}{0}", base64PadCharacter);

        private const char base64Character62 = '+';
        private const char base64Character63 = '/';
        private const char base64UrlCharacter62 = '-';
        private const char base64UrlCharacter63 = '_';

        public static string Encode(byte[] arg)
        {
            if (arg == null)
            {
                throw new ArgumentNullException(nameof(arg));
            }

            string s = Convert.ToBase64String(arg.AsSpan());
            s = s.Split(base64PadCharacter)[0];                     // Remove any trailing padding
            s = s.Replace(base64Character62, base64UrlCharacter62); // 62nd char of encoding
            s = s.Replace(base64Character63, base64UrlCharacter63); // 63rd char of encoding

            return s;
        }

        public static string EncodeAP2(byte[] arg)
        {
            if (arg == null)
            {
                throw new ArgumentNullException(nameof(arg));
            }

            char[] buffer = null;
            try
            {
                buffer = ArrayPool<char>.Shared.Rent(arg.Length);
                var charsWritten = Convert.ToBase64CharArray(arg, 0, arg.Length, buffer, 0);
                var bufferSpan = buffer.AsSpan(0, charsWritten);

                ReadOnlySpan<char> charsToFind = stackalloc char[] { base64PadCharacter, base64Character62, base64Character63 };
                int indexOfChar;
                int length = 0;

                while ((indexOfChar = bufferSpan.IndexOfAny(charsToFind)) >= 0)
                {
                    switch (bufferSpan[indexOfChar])
                    {
                        case base64PadCharacter:
                            return new string(buffer.AsSpan(0, length));
                        case base64Character62:
                            bufferSpan[indexOfChar] = base64UrlCharacter62;
                            break;
                        case base64Character63:
                            bufferSpan[indexOfChar] = base64UrlCharacter63;
                            break;
                    }
                    length += indexOfChar;
                    bufferSpan = bufferSpan.Slice(indexOfChar + 1);
                }

                return new string(buffer.AsSpan(0, length + bufferSpan.Length));
            }
            finally
            {
                if (buffer != null)
                    ArrayPool<char>.Shared.Return(buffer);
            }
        }

        public static string EncodeAP(byte[] arg)
        {
            if (arg == null)
            {
                throw new ArgumentNullException(nameof(arg));
            }

            char[] buffer = null;
            try
            {
                buffer = ArrayPool<char>.Shared.Rent(arg.Length);
                var charsWritten = Convert.ToBase64CharArray(arg, 0, arg.Length, buffer, 0);

                int i = 0;
                while (i < charsWritten)
                {
                    if (buffer[i] == base64PadCharacter)
                        break;
                    if (buffer[i] == base64Character62)
                        buffer[i] = base64UrlCharacter62;
                    else if (buffer[i] == base64Character63)
                        buffer[i] = base64UrlCharacter63;
                    i++;
                }

                ReadOnlySpan<char> stringSpan = buffer.AsSpan(0, i);
                return new string(stringSpan);
            }
            finally
            {
                if (buffer != null)
                    ArrayPool<char>.Shared.Return(buffer);
            }
        }

        public static readonly byte[] data =
            Encoding.UTF8.GetBytes(
                "{ASBCAsdkjhaskdjfhksjrg192836198amnksjASBCAsdkjhaskdjfhksjrg192836198amnksjndk1ukljansd98quew79r8672345lkjwnedflkxjmdvlkASBCAsdkjhaskdjfhksjrg192836198amnksjndk1ukljansd98quew79r8672345lkjwnedflkxjmdvlkASBCAsdkjhaskdjfhksjrg192836198amnksjndk1ukljansd98quew79r8672345lkjwnedflkxjmdvlkndk1ukljansd98quew79r8672345lkjwnedflkxjmdvlk}");

        [Benchmark]
        public string Encode() =>
            Encode(data);

        [Benchmark]
        public string EncodeAP() =>
            EncodeAP(data);

        [Benchmark]
        public string EncodeAP2() =>
            EncodeAP2(data);
    }
}
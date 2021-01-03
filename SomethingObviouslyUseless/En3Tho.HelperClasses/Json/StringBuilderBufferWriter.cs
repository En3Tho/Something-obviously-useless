#if !NETSTANDARD2_0

using System;
using System.Buffers;
using System.Text;

namespace En3Tho.HelperClasses.Json
{
    public sealed class StringBuilderBufferWriter : IBufferWriter<byte>, IDisposable
    {
        public StringBuilder Builder { get; }
        private byte[] _buffer;

        public StringBuilderBufferWriter(StringBuilder builder)
        {
            Builder = builder;
            _buffer = ArrayPool<byte>.Shared.Rent(256);
        }

        private void EnsureCapacity(int sizeHint)
        {
            if (sizeHint > _buffer.Length)
            {
                ArrayPool<byte>.Shared.Return(_buffer);
                _buffer = ArrayPool<byte>.Shared.Rent(sizeHint);
            }
        }

        public void Advance(int count)
        {
            if (count < 512)
            {
                Span<char> chars = stackalloc char[count];
                var written = Encoding.UTF8.GetChars(_buffer.AsSpan(0, count), chars);
                Builder.Append(chars.Slice(0, written));
            }
            else
            {
                var chars = ArrayPool<char>.Shared.Rent(count);
                var written = Encoding.UTF8.GetChars(_buffer.AsSpan(0, count), chars);
                Builder.Append(chars.AsSpan(0, written));
                ArrayPool<char>.Shared.Return(chars);
            }
        }

        public Memory<byte> GetMemory(int sizeHint = 0)
        {
            EnsureCapacity(sizeHint);
            return new Memory<byte>(_buffer);
        }

        public Span<byte> GetSpan(int sizeHint = 0)
        {
            EnsureCapacity(sizeHint);
            return new Span<byte>(_buffer);
        }

        public void Dispose()
        {
            ArrayPool<byte>.Shared.Return(_buffer);
        }
    }
}

#endif
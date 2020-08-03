using System;
using System.Runtime.CompilerServices;

namespace En3Tho.PlayGround.GameOfLife
{
    public readonly ref struct GameOfLifeBitsView
    {
        private readonly Span<byte> _span;
        private readonly int _iWidth;
        private readonly int _iStart;
        public int Length { get; }

        public GameOfLifeBitsView(Span<byte> span, int globalWidth)
        {
            _iWidth = globalWidth - 2;
            _iStart = globalWidth + 1;
            _span = span;
            Length = (span.Length / globalWidth - 2) * _iWidth * 8;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private (int byteIndex, int bitIndex) ComputeIndices(int index)
        {
            var byteIndex = index >> 3;
            return (_iStart + byteIndex + byteIndex / _iWidth * 2, index % 8);
        }

        public int this[int index]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                var (byteIndex, bitIndex) = ComputeIndices(index);
                return _span[byteIndex] >> bitIndex & 1;
            }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                var (byteIndex, bitIndex) = ComputeIndices(index);
                var mask = value << bitIndex;
                _span[byteIndex] = (byte)(_span[byteIndex] & ~mask | mask);
            }
        }
    }
}
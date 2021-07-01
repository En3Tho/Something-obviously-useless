using System;
using System.Runtime.CompilerServices;

namespace En3Tho.PlayGround.GameOfLife
{
    public readonly ref struct GameOfLifeBitsView
    {
        private readonly Span<byte> _span;
        private readonly int _innerWidth;
        private readonly int _innerStart;
        public int Length { get; }

        public GameOfLifeBitsView(Span<byte> span, int outerWidth)
        {
            _innerWidth = outerWidth - 2;
            _innerStart = outerWidth + 1;
            _span = span;
            Length = (span.Length / outerWidth - 2) * _innerWidth * 8;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private (int byteIndex, int bitIndex) ComputeIndices(int index)
        {
            var byteIndex = Math.DivRem(index, 8, out var remainder);
            return (_innerStart + byteIndex + byteIndex / _innerWidth * 2, remainder);
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
using System.Collections;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace En3Tho.HelperClasses.Views
{
    public readonly ref struct DoubleRankBitArrayView
    {
        public readonly BitArray Values;
        public readonly int Width;
        public readonly int Height;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public DoubleRankBitArrayView(BitArray values, int width)
        {
            Values = values;
            Width = width;
            Height = values.Length / width;
            Debug.Assert(values.Count == Height * Width);
        }

        public bool this[int row, int column]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => Values[row * Width + column];
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set => Values[row * Width + column] = value;
        }
    }
}
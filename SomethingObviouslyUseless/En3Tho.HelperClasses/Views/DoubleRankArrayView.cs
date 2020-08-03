using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace En3Tho.HelperClasses.Views
{
    public readonly ref struct DoubleRankArrayView<T>
    {
        public readonly T[] Values;
        public readonly int Width;
        public readonly int Height;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public DoubleRankArrayView(T[] values, int width)
        {
            Values = values;
            Width = width;
            Height = values.Length / width;
            Debug.Assert(values.Length == Height * Width);
        }

#if !NETSTANDARD2_0
        public Span<T> GetRow(int row) => new Span<T>(Values, row * Width, Width); 
#endif

        public ref T this[int row, int column]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => ref Values[row * Width + column];
        }
    }
}
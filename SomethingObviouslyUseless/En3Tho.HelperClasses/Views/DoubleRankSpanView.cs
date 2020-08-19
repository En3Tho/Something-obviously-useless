using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace En3Tho.HelperClasses.Views
{
    public readonly ref struct DoubleRankSpanView<T>
    {
        public readonly Span<T> Values;
        public readonly int Width;
        public readonly int Height;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public DoubleRankSpanView(T[] values, int width)
        {
            Values = values;
            Width = width;
            Height = values.Length / width;
            Debug.Assert(values.Length == Height * Width);
        }

        public Span<T> GetRow(int row) => Values.Slice(row * Width, Height);
        
        public ref T this[int row, int column]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => ref Values[row * Width + column];
        }
    }
}
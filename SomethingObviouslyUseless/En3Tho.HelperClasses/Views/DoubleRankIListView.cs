using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace En3Tho.HelperClasses.Views
{
    public readonly ref struct DoubleRankIListView<T>
    {
        public readonly IList<T> Values;
        public readonly int Width;
        public readonly int Height;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public DoubleRankIListView(IList<T> values, int width)
        {
            Values = values;
            Width = width;
            Height = values.Count / width;
            Debug.Assert(values.Count == Height * Width);
        }

        public T this[int row, int column]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => Values[row * Width + column];
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set => Values[row * Width + column] = value;
        }
    }
}
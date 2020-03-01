using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace ExtensionsAndStuff.RefStructs.SpanList
{
    public static class SpanListEx
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Span<T> SliceToCount<T>(this SpanHeapList<T> list) where T : class
            => list.Span.Slice(0, list.Count);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Span<T> SliceToCount<T>(this SpanList<T> list) where T : class
           => list.Span.Slice(0, list.Count);
    }
}

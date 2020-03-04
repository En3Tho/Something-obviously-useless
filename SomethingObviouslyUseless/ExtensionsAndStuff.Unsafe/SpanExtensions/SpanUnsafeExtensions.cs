using System;
using System.Runtime.CompilerServices;

namespace ExtensionsAndStuff.Unsafe.SpanExtensions
{
    public static class SpanUnsafeExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SpanEnumerable<T> AsEnumerable<T>(this Span<T> span) => new SpanEnumerable<T>(span);
    }
}
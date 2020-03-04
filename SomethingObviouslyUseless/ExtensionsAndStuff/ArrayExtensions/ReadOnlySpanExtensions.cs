using System;
using System.Runtime.CompilerServices;

namespace ExtensionsAndStuff.ArrayExtensions
{
    public static class ReadOnlySpanExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ReadOnlySpan<T> AsReadOnlySpan<T>(this T[] array)
        {
            return new ReadOnlySpan<T>(array);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ReadOnlySpan<T> AsReadOnlySpan<T>(this T[] array, int start, int length)
        {
            return new ReadOnlySpan<T>(array, start, length);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ReadOnlySpan<T> AsReadOnlySpan<T>(this T[] array, int start)
        {
            return new ReadOnlySpan<T>(array, start, array.Length - start);
        }
    }
}
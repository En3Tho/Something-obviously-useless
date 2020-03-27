using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using static ExtensionsAndStuff.ThrowHelper;

namespace ExtensionsAndStuff.CollectionExtensions
{
    public static class ArrayExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T[] CreateCopy<T>(this T[] array, int start = 0, int count = 0)
        {
            if (count == 0)
                return Array.Empty<T>();

            if ((uint)start + (uint)count > (uint)array.Length)
                ThrowArgumentOutOfRangeException("Start + count > length");

            var copy = new T[count];
            Array.Copy(array, start, copy, 0, count);
            return copy;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ReadOnlySpan<T> AsReadOnlySpan<T>(this T[] array) => new ReadOnlySpan<T>(array);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ReadOnlySpan<T> AsReadOnlySpan<T>(this T[] array, int start, int length) => new ReadOnlySpan<T>(array, start, length);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ReadOnlySpan<T> AsReadOnlySpan<T>(this T[] array, int start) => new ReadOnlySpan<T>(array, start, array.Length - start);
    }
}
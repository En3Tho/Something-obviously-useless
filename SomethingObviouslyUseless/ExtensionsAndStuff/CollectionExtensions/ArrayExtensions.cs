using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using static ExtensionsAndStuff.ThrowHelper;

namespace ExtensionsAndStuff.CollectionExtensions
{
    public static class ArrayExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T[] Slice<T>(this T[] array, int start = 0, int count = 0) => array.AsSpan().Slice(start, count).ToArray();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ReadOnlySpan<T> AsReadOnlySpan<T>(this T[] array) => new ReadOnlySpan<T>(array);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ReadOnlySpan<T> AsReadOnlySpan<T>(this T[] array, int start, int length) => new ReadOnlySpan<T>(array, start, length);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ReadOnlySpan<T> AsReadOnlySpan<T>(this T[] array, int start) => new ReadOnlySpan<T>(array, start, array.Length - start);
    }
}
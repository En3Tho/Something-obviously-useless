using System;
using System.Runtime.CompilerServices;

namespace En3Tho.ValueTupleExtensions.LinqLikeExtensions
{
    public static partial class ValueTupleLinqLikeExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T Aggregate<T>(this (T v1, T v2, T v3, T v4, T v5, T v6, T v7) tuple, Func<T, T, T> func)
            => func(tuple.v7, func(tuple.v6, func(tuple.v5, func(tuple.v4, func(tuple.v3, func(tuple.v1, tuple.v2))))));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T Aggregate<T>(this (T v1, T v2, T v3, T v4, T v5, T v6) tuple, Func<T, T, T> func)
            => func(tuple.v6, func(tuple.v5, func(tuple.v4, func(tuple.v3, func(tuple.v1, tuple.v2)))));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T Aggregate<T>(this (T v1, T v2, T v3, T v4, T v5) tuple, Func<T, T, T> func)
            => func(tuple.v5, func(tuple.v4, func(tuple.v3, func(tuple.v1, tuple.v2))));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T Aggregate<T>(this (T v1, T v2, T v3, T v4) tuple, Func<T, T, T> func)
            => func(tuple.v4, func(tuple.v3, func(tuple.v1, tuple.v2)));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T Aggregate<T>(this (T v1, T v2, T v3) tuple, Func<T, T, T> func)
            => func(tuple.v3, func(tuple.v1, tuple.v2));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T Aggregate<T>(this (T v1, T v2) tuple, Func<T, T, T> func)
            => func(tuple.v1, tuple.v2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static U Aggregate<T, U>(this (T v1, T v2, T v3, T v4, T v5, T v6, T v7) tuple, Func<T, U, U> func, U value)
            => func(tuple.v7, func(tuple.v6, func(tuple.v5, func(tuple.v4, func(tuple.v3, func(tuple.v2, func(tuple.v1, value)))))));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static U Aggregate<T, U>(this (T v1, T v2, T v3, T v4, T v5, T v6) tuple, Func<T, U, U> func, U value)
            => func(tuple.v6, func(tuple.v5, func(tuple.v4, func(tuple.v3, func(tuple.v2, func(tuple.v1, value))))));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static U Aggregate<T, U>(this (T v1, T v2, T v3, T v4, T v5) tuple, Func<T, U, U> func, U value)
            => func(tuple.v5, func(tuple.v4, func(tuple.v3, func(tuple.v2, func(tuple.v1, value)))));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static U Aggregate<T, U>(this (T v1, T v2, T v3, T v4) tuple, Func<T, U, U> func, U value)
            => func(tuple.v4, func(tuple.v3, func(tuple.v2, func(tuple.v1, value))));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static U Aggregate<T, U>(this (T v1, T v2, T v3) tuple, Func<T, U, U> func, U value)
            => func(tuple.v3, func(tuple.v2, func(tuple.v1, value)));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static U Aggregate<T, U>(this (T v1, T v2) tuple, Func<T, U, U> func, U value)
            => func(tuple.v2, func(tuple.v1, value));
    }
}
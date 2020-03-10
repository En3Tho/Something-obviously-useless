﻿using System;
using System.Runtime.CompilerServices;

namespace ExtensionsAndStuff.ValueTupleExtensions
{
    public static partial class MiscellaneousExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (U, U, U, U, U, U, U) Select<T, U>(this (T v1, T v2, T v3, T v4, T v5, T v6, T v7) tuple, Func<T, U> func)
            => (func(tuple.v1),
                func(tuple.v2),
                func(tuple.v3),
                func(tuple.v4),
                func(tuple.v5),
                func(tuple.v6),
                func(tuple.v7));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (U, U, U, U, U, U) Select<T, U>(this (T v1, T v2, T v3, T v4, T v5, T v6) tuple, Func<T, U> func)
            => (func(tuple.v1),
                func(tuple.v2),
                func(tuple.v3),
                func(tuple.v4),
                func(tuple.v5),
                func(tuple.v6));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (U, U, U, U, U) Select<T, U>(this (T v1, T v2, T v3, T v4, T v5) tuple, Func<T, U> func)
            => (func(tuple.v1),
                func(tuple.v2),
                func(tuple.v3),
                func(tuple.v4),
                func(tuple.v5));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (U, U, U, U) Select<T, U>(this (T v1, T v2, T v3, T v4) tuple, Func<T, U> func)
            => (func(tuple.v1),
                func(tuple.v2),
                func(tuple.v3),
                func(tuple.v4));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (U, U, U) Select<T, U>(this (T v1, T v2, T v3) tuple, Func<T, U> func)
            => (func(tuple.v1),
                func(tuple.v2),
                func(tuple.v3));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (U, U) Select<T, U>(this (T v1, T v2) tuple, Func<T, U> func)
            => (func(tuple.v1),
                func(tuple.v2));
    }
}

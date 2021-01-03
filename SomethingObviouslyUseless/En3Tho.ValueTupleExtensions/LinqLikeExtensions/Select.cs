using System;
using System.Runtime.CompilerServices;

namespace En3Tho.ValueTupleExtensions.LinqLikeExtensions
{
    public static partial class ValueTupleLinqLikeExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (U, U, U, U, U, U, U) Select<T, U>(in this (T v1, T v2, T v3, T v4, T v5, T v6, T v7) tuple, Func<T, U> func)
            => (func(tuple.v1),
                func(tuple.v2),
                func(tuple.v3),
                func(tuple.v4),
                func(tuple.v5),
                func(tuple.v6),
                func(tuple.v7));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (U, U, U, U, U, U) Select<T, U>(in this (T v1, T v2, T v3, T v4, T v5, T v6) tuple, Func<T, U> func)
            => (func(tuple.v1),
                func(tuple.v2),
                func(tuple.v3),
                func(tuple.v4),
                func(tuple.v5),
                func(tuple.v6));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (U, U, U, U, U) Select<T, U>(in this (T v1, T v2, T v3, T v4, T v5) tuple, Func<T, U> func)
            => (func(tuple.v1),
                func(tuple.v2),
                func(tuple.v3),
                func(tuple.v4),
                func(tuple.v5));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (U, U, U, U) Select<T, U>(in this (T v1, T v2, T v3, T v4) tuple, Func<T, U> func)
            => (func(tuple.v1),
                func(tuple.v2),
                func(tuple.v3),
                func(tuple.v4));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (U, U, U) Select<T, U>(in this (T v1, T v2, T v3) tuple, Func<T, U> func)
            => (func(tuple.v1),
                func(tuple.v2),
                func(tuple.v3));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (U, U) Select<T, U>(in this (T v1, T v2) tuple, Func<T, U> func)
            => (func(tuple.v1),
                func(tuple.v2));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (TOut1, TOut2, TOut3, TOut4, TOut5, TOut6, TOut7) Select<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TOut1, TOut2, TOut3, TOut4, TOut5, TOut6, TOut7>(
            this (TIn1 v1, TIn2 v2, TIn3 v3, TIn4 v4, TIn5 v5, TIn6 v6, TIn7 v7) tuple, Func<TIn1, TOut1> func1, Func<TIn2, TOut2> func2, Func<TIn3, TOut3> func3, Func<TIn4, TOut4> func4,
            Func<TIn5, TOut5> func5, Func<TIn6, TOut6> func6, Func<TIn7, TOut7> func7)
            => (func1(tuple.v1),
                func2(tuple.v2),
                func3(tuple.v3),
                func4(tuple.v4),
                func5(tuple.v5),
                func6(tuple.v6),
                func7(tuple.v7));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (TOut1, TOut2, TOut3, TOut4, TOut5, TOut6) Select<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TOut1, TOut2, TOut3, TOut4, TOut5, TOut6>(
            this (TIn1 v1, TIn2 v2, TIn3 v3, TIn4 v4, TIn5 v5, TIn6 v6) tuple, Func<TIn1, TOut1> func1, Func<TIn2, TOut2> func2, Func<TIn3, TOut3> func3, Func<TIn4, TOut4> func4,
            Func<TIn5, TOut5> func5, Func<TIn6, TOut6> func6)
            => (func1(tuple.v1),
                func2(tuple.v2),
                func3(tuple.v3),
                func4(tuple.v4),
                func5(tuple.v5),
                func6(tuple.v6));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (TOut1, TOut2, TOut3, TOut4, TOut5) Select<TIn1, TIn2, TIn3, TIn4, TIn5, TOut1, TOut2, TOut3, TOut4, TOut5>(
            this (TIn1 v1, TIn2 v2, TIn3 v3, TIn4 v4, TIn5 v5) tuple, Func<TIn1, TOut1> func1, Func<TIn2, TOut2> func2, Func<TIn3, TOut3> func3, Func<TIn4, TOut4> func4,
            Func<TIn5, TOut5> func5)
            => (func1(tuple.v1),
                func2(tuple.v2),
                func3(tuple.v3),
                func4(tuple.v4),
                func5(tuple.v5));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (TOut1, TOut2, TOut3, TOut4) Select<TIn1, TIn2, TIn3, TIn4, TOut1, TOut2, TOut3, TOut4>(
            this (TIn1 v1, TIn2 v2, TIn3 v3, TIn4 v4) tuple, Func<TIn1, TOut1> func1, Func<TIn2, TOut2> func2, Func<TIn3, TOut3> func3, Func<TIn4, TOut4> func4)
            => (func1(tuple.v1),
                func2(tuple.v2),
                func3(tuple.v3),
                func4(tuple.v4));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (TOut1, TOut2, TOut3) Select<TIn1, TIn2, TIn3, TOut1, TOut2, TOut3>(
            this (TIn1 v1, TIn2 v2, TIn3 v3) tuple, Func<TIn1, TOut1> func1, Func<TIn2, TOut2> func2, Func<TIn3, TOut3> func3)
            => (func1(tuple.v1),
                func2(tuple.v2),
                func3(tuple.v3));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (TOut1, TOut2) Select<TIn1, TIn2, TOut1, TOut2>(
            this (TIn1 v1, TIn2 v2) tuple, Func<TIn1, TOut1> func1, Func<TIn2, TOut2> func2)
            => (func1(tuple.v1),
                func2(tuple.v2));
    }
}
using System;
using System.Runtime.CompilerServices;
using static En3Tho.ValueTupleExtensions.ThrowHelper;

namespace En3Tho.ValueTupleExtensions.LinqLikeExtensions
{
    public static partial class ValueTupleLinqLikeExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (T, T, T, T, T, T, T) ShouldNot<T>(this (T v1, T v2, T v3, T v4, T v5, T v6, T v7) tuple, Func<T, bool> func, string message = ShouldOrShouldNotErrorMessage)
        {
            if (func(tuple.v1)) ThrowInvalidOperationException(message, nameof(tuple.v1));
            if (func(tuple.v2)) ThrowInvalidOperationException(message, nameof(tuple.v2));
            if (func(tuple.v3)) ThrowInvalidOperationException(message, nameof(tuple.v3));
            if (func(tuple.v4)) ThrowInvalidOperationException(message, nameof(tuple.v4));
            if (func(tuple.v5)) ThrowInvalidOperationException(message, nameof(tuple.v5));
            if (func(tuple.v6)) ThrowInvalidOperationException(message, nameof(tuple.v6));
            if (func(tuple.v7)) ThrowInvalidOperationException(message, nameof(tuple.v7));
            return tuple;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (T, T, T, T, T, T) ShouldNot<T>(this (T v1, T v2, T v3, T v4, T v5, T v6) tuple, Func<T, bool> func, string message = ShouldOrShouldNotErrorMessage)
        {
            if (func(tuple.v1)) ThrowInvalidOperationException(message, nameof(tuple.v1));
            if (func(tuple.v2)) ThrowInvalidOperationException(message, nameof(tuple.v2));
            if (func(tuple.v3)) ThrowInvalidOperationException(message, nameof(tuple.v3));
            if (func(tuple.v4)) ThrowInvalidOperationException(message, nameof(tuple.v4));
            if (func(tuple.v5)) ThrowInvalidOperationException(message, nameof(tuple.v5));
            if (func(tuple.v6)) ThrowInvalidOperationException(message, nameof(tuple.v6));
            return tuple;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (T, T, T, T, T) ShouldNot<T>(this (T v1, T v2, T v3, T v4, T v5) tuple, Func<T, bool> func, string message = ShouldOrShouldNotErrorMessage)
        {
            if (func(tuple.v1)) ThrowInvalidOperationException(message, nameof(tuple.v1));
            if (func(tuple.v2)) ThrowInvalidOperationException(message, nameof(tuple.v2));
            if (func(tuple.v3)) ThrowInvalidOperationException(message, nameof(tuple.v3));
            if (func(tuple.v4)) ThrowInvalidOperationException(message, nameof(tuple.v4));
            if (func(tuple.v5)) ThrowInvalidOperationException(message, nameof(tuple.v5));
            return tuple;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (T, T, T, T) ShouldNot<T>(this (T v1, T v2, T v3, T v4) tuple, Func<T, bool> func, string message = ShouldOrShouldNotErrorMessage)
        {
            if (func(tuple.v1)) ThrowInvalidOperationException(message, nameof(tuple.v1));
            if (func(tuple.v2)) ThrowInvalidOperationException(message, nameof(tuple.v2));
            if (func(tuple.v3)) ThrowInvalidOperationException(message, nameof(tuple.v3));
            if (func(tuple.v4)) ThrowInvalidOperationException(message, nameof(tuple.v4));
            return tuple;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (T, T, T) ShouldNot<T>(this (T v1, T v2, T v3) tuple, Func<T, bool> func, string message = ShouldOrShouldNotErrorMessage)
        {
            if (func(tuple.v1)) ThrowInvalidOperationException(message, nameof(tuple.v1));
            if (func(tuple.v2)) ThrowInvalidOperationException(message, nameof(tuple.v2));
            if (func(tuple.v3)) ThrowInvalidOperationException(message, nameof(tuple.v3));
            return tuple;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (T, T) ShouldNot<T>(this (T v1, T v2) tuple, Func<T, bool> func, string message = ShouldOrShouldNotErrorMessage)
        {
            if (func(tuple.v1)) ThrowInvalidOperationException(message, nameof(tuple.v1));
            if (func(tuple.v2)) ThrowInvalidOperationException(message, nameof(tuple.v2));
            return tuple;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (T1, T2, T3, T4, T5, T6, T7) ShouldNot<T1, T2, T3, T4, T5, T6, T7>(this (T1 v1, T2 v2, T3 v3, T4 v4, T5 v5, T6 v6, T7 v7) tuple, Func<T1, bool> func1, Func<T2, bool> func2,
            Func<T3, bool> func3, Func<T4, bool> func4, Func<T5, bool> func5, Func<T6, bool> func6, Func<T7, bool> func7, string message = ShouldOrShouldNotErrorMessage)
        {
            if (func1(tuple.v1)) ThrowInvalidOperationException(message, nameof(tuple.v1));
            if (func2(tuple.v2)) ThrowInvalidOperationException(message, nameof(tuple.v2));
            if (func3(tuple.v3)) ThrowInvalidOperationException(message, nameof(tuple.v3));
            if (func4(tuple.v4)) ThrowInvalidOperationException(message, nameof(tuple.v4));
            if (func5(tuple.v5)) ThrowInvalidOperationException(message, nameof(tuple.v5));
            if (func6(tuple.v6)) ThrowInvalidOperationException(message, nameof(tuple.v6));
            if (func7(tuple.v7)) ThrowInvalidOperationException(message, nameof(tuple.v7));
            return tuple;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (T1, T2, T3, T4, T5, T6) ShouldNot<T1, T2, T3, T4, T5, T6>(this (T1 v1, T2 v2, T3 v3, T4 v4, T5 v5, T6 v6) tuple, Func<T1, bool> func1, Func<T2, bool> func2,
            Func<T3, bool> func3, Func<T4, bool> func4, Func<T5, bool> func5, Func<T6, bool> func6, string message = ShouldOrShouldNotErrorMessage)
        {
            if (func1(tuple.v1)) ThrowInvalidOperationException(message, nameof(tuple.v1));
            if (func2(tuple.v2)) ThrowInvalidOperationException(message, nameof(tuple.v2));
            if (func3(tuple.v3)) ThrowInvalidOperationException(message, nameof(tuple.v3));
            if (func4(tuple.v4)) ThrowInvalidOperationException(message, nameof(tuple.v4));
            if (func5(tuple.v5)) ThrowInvalidOperationException(message, nameof(tuple.v5));
            if (func6(tuple.v6)) ThrowInvalidOperationException(message, nameof(tuple.v6));
            return tuple;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (T1, T2, T3, T4, T5) ShouldNot<T1, T2, T3, T4, T5>(this (T1 v1, T2 v2, T3 v3, T4 v4, T5 v5) tuple, Func<T1, bool> func1, Func<T2, bool> func2,
            Func<T3, bool> func3, Func<T4, bool> func4, Func<T5, bool> func5, string message = ShouldOrShouldNotErrorMessage)
        {
            if (func1(tuple.v1)) ThrowInvalidOperationException(message, nameof(tuple.v1));
            if (func2(tuple.v2)) ThrowInvalidOperationException(message, nameof(tuple.v2));
            if (func3(tuple.v3)) ThrowInvalidOperationException(message, nameof(tuple.v3));
            if (func4(tuple.v4)) ThrowInvalidOperationException(message, nameof(tuple.v4));
            if (func5(tuple.v5)) ThrowInvalidOperationException(message, nameof(tuple.v5));
            return tuple;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (T1, T2, T3, T4) ShouldNot<T1, T2, T3, T4>(this (T1 v1, T2 v2, T3 v3, T4 v4) tuple, Func<T1, bool> func1, Func<T2, bool> func2,
            Func<T3, bool> func3, Func<T4, bool> func4, string message = ShouldOrShouldNotErrorMessage)
        {
            if (func1(tuple.v1)) ThrowInvalidOperationException(message, nameof(tuple.v1));
            if (func2(tuple.v2)) ThrowInvalidOperationException(message, nameof(tuple.v2));
            if (func3(tuple.v3)) ThrowInvalidOperationException(message, nameof(tuple.v3));
            if (func4(tuple.v4)) ThrowInvalidOperationException(message, nameof(tuple.v4));
            return tuple;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (T1, T2, T3) ShouldNot<T1, T2, T3>(this (T1 v1, T2 v2, T3 v3) tuple, Func<T1, bool> func1, Func<T2, bool> func2, Func<T3, bool> func3,
            string message = ShouldOrShouldNotErrorMessage)
        {
            if (func1(tuple.v1)) ThrowInvalidOperationException(message, nameof(tuple.v1));
            if (func2(tuple.v2)) ThrowInvalidOperationException(message, nameof(tuple.v2));
            if (func3(tuple.v3)) ThrowInvalidOperationException(message, nameof(tuple.v3));
            return tuple;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (T1, T2) ShouldNot<T1, T2>(this (T1 v1, T2 v2) tuple, Func<T1, bool> func1, Func<T2, bool> func2, string message = ShouldOrShouldNotErrorMessage)
        {
            if (func1(tuple.v1)) ThrowInvalidOperationException(message, nameof(tuple.v1));
            if (func2(tuple.v2)) ThrowInvalidOperationException(message, nameof(tuple.v2));
            return tuple;
        }
    }
}
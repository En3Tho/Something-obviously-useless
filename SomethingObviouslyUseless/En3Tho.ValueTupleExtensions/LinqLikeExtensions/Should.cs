using System;
using System.Runtime.CompilerServices;
using static En3Tho.HelperClasses.ThrowHelper;

namespace En3Tho.ValueTupleExtensions
{
    public static partial class ValueTupleLinqLikeExtensions
    {
        private const string ShouldOrShouldNotErrorMessage = "Condition not met.";

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (T, T, T, T, T, T, T) Should<T>(this (T v1, T v2, T v3, T v4, T v5, T v6, T v7) tuple, Func<T, bool> func, string message = ShouldOrShouldNotErrorMessage)
        {
            if (!func(tuple.v1)) ThrowInvalidOperationException(message, nameof(tuple.v1));
            if (!func(tuple.v2)) ThrowInvalidOperationException(message, nameof(tuple.v2));
            if (!func(tuple.v3)) ThrowInvalidOperationException(message, nameof(tuple.v3));
            if (!func(tuple.v4)) ThrowInvalidOperationException(message, nameof(tuple.v4));
            if (!func(tuple.v5)) ThrowInvalidOperationException(message, nameof(tuple.v5));
            if (!func(tuple.v6)) ThrowInvalidOperationException(message, nameof(tuple.v6));
            if (!func(tuple.v7)) ThrowInvalidOperationException(message, nameof(tuple.v7));
            return tuple;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (T, T, T, T, T, T) Should<T>(this (T v1, T v2, T v3, T v4, T v5, T v6) tuple, Func<T, bool> func, string message = ShouldOrShouldNotErrorMessage)
        {
            if (!func(tuple.v1)) ThrowInvalidOperationException(message, nameof(tuple.v1));
            if (!func(tuple.v2)) ThrowInvalidOperationException(message, nameof(tuple.v2));
            if (!func(tuple.v3)) ThrowInvalidOperationException(message, nameof(tuple.v3));
            if (!func(tuple.v4)) ThrowInvalidOperationException(message, nameof(tuple.v4));
            if (!func(tuple.v5)) ThrowInvalidOperationException(message, nameof(tuple.v5));
            if (!func(tuple.v6)) ThrowInvalidOperationException(message, nameof(tuple.v6));
            return tuple;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (T, T, T, T, T) Should<T>(this (T v1, T v2, T v3, T v4, T v5) tuple, Func<T, bool> func, string message = ShouldOrShouldNotErrorMessage)
        {
            if (func(tuple.v1)) ThrowInvalidOperationException(message, nameof(tuple.v1));
            if (func(tuple.v2)) ThrowInvalidOperationException(message, nameof(tuple.v2));
            if (func(tuple.v3)) ThrowInvalidOperationException(message, nameof(tuple.v3));
            if (func(tuple.v4)) ThrowInvalidOperationException(message, nameof(tuple.v4));
            if (func(tuple.v5)) ThrowInvalidOperationException(message, nameof(tuple.v5));
            return tuple;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (T, T, T, T) Should<T>(this (T v1, T v2, T v3, T v4) tuple, Func<T, bool> func, string message = ShouldOrShouldNotErrorMessage)
        {
            if (func(tuple.v1)) ThrowInvalidOperationException(message, nameof(tuple.v1));
            if (func(tuple.v2)) ThrowInvalidOperationException(message, nameof(tuple.v2));
            if (func(tuple.v3)) ThrowInvalidOperationException(message, nameof(tuple.v3));
            if (func(tuple.v4)) ThrowInvalidOperationException(message, nameof(tuple.v4));
            return tuple;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (T, T, T) Should<T>(this (T v1, T v2, T v3) tuple, Func<T, bool> func, string message = ShouldOrShouldNotErrorMessage)
        {
            if (func(tuple.v1)) ThrowInvalidOperationException(message, nameof(tuple.v1));
            if (func(tuple.v2)) ThrowInvalidOperationException(message, nameof(tuple.v2));
            if (func(tuple.v3)) ThrowInvalidOperationException(message, nameof(tuple.v3));
            return tuple;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (T, T) Should<T>(this (T v1, T v2) tuple, Func<T, bool> func, string message = ShouldOrShouldNotErrorMessage)
        {
            if (func(tuple.v1)) ThrowInvalidOperationException(message, nameof(tuple.v1));
            if (func(tuple.v2)) ThrowInvalidOperationException(message, nameof(tuple.v2));
            return tuple;
        }
    }
}
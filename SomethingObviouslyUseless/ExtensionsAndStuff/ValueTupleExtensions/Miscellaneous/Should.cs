using System;
using System.Runtime.CompilerServices;

namespace ExtensionsAndStuff.ValueTupleExtensions
{
    public static partial class MiscellaneousExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (T, T, T, T, T, T, T) Should<T>(this (T v1, T v2, T v3, T v4, T v5, T v6, T v7) tuple, Func<T, bool> func)
        {
            if (!func(tuple.v1)) ValueTupleValidationException.Throw(nameof(tuple.v1));
            if (!func(tuple.v2)) ValueTupleValidationException.Throw(nameof(tuple.v2));
            if (!func(tuple.v3)) ValueTupleValidationException.Throw(nameof(tuple.v3));
            if (!func(tuple.v4)) ValueTupleValidationException.Throw(nameof(tuple.v4));
            if (!func(tuple.v5)) ValueTupleValidationException.Throw(nameof(tuple.v5));
            if (!func(tuple.v6)) ValueTupleValidationException.Throw(nameof(tuple.v6));
            if (!func(tuple.v7)) ValueTupleValidationException.Throw(nameof(tuple.v7));
            return tuple;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (T, T, T, T, T, T) Should<T>(this (T v1, T v2, T v3, T v4, T v5, T v6) tuple, Func<T, bool> func)
        {
            if (!func(tuple.v1)) ValueTupleValidationException.Throw(nameof(tuple.v1));
            if (!func(tuple.v2)) ValueTupleValidationException.Throw(nameof(tuple.v2));
            if (!func(tuple.v3)) ValueTupleValidationException.Throw(nameof(tuple.v3));
            if (!func(tuple.v4)) ValueTupleValidationException.Throw(nameof(tuple.v4));
            if (!func(tuple.v5)) ValueTupleValidationException.Throw(nameof(tuple.v5));
            if (!func(tuple.v6)) ValueTupleValidationException.Throw(nameof(tuple.v6));
            return tuple;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (T, T, T, T, T) Should<T>(this (T v1, T v2, T v3, T v4, T v5) tuple, Func<T, bool> func)
        {
            if (func(tuple.v1)) ValueTupleValidationException.Throw(nameof(tuple.v1));
            if (func(tuple.v2)) ValueTupleValidationException.Throw(nameof(tuple.v2));
            if (func(tuple.v3)) ValueTupleValidationException.Throw(nameof(tuple.v3));
            if (func(tuple.v4)) ValueTupleValidationException.Throw(nameof(tuple.v4));
            if (func(tuple.v5)) ValueTupleValidationException.Throw(nameof(tuple.v5));
            return tuple;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (T, T, T, T) Should<T>(this (T v1, T v2, T v3, T v4) tuple, Func<T, bool> func)
        {
            if (func(tuple.v1)) ValueTupleValidationException.Throw(nameof(tuple.v1));
            if (func(tuple.v2)) ValueTupleValidationException.Throw(nameof(tuple.v2));
            if (func(tuple.v3)) ValueTupleValidationException.Throw(nameof(tuple.v3));
            if (func(tuple.v4)) ValueTupleValidationException.Throw(nameof(tuple.v4));
            return tuple;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (T, T, T) Should<T>(this (T v1, T v2, T v3) tuple, Func<T, bool> func)
        {
            if (func(tuple.v1)) ValueTupleValidationException.Throw(nameof(tuple.v1));
            if (func(tuple.v2)) ValueTupleValidationException.Throw(nameof(tuple.v2));
            if (func(tuple.v3)) ValueTupleValidationException.Throw(nameof(tuple.v3));
            return tuple;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (T, T) Should<T>(this (T v1, T v2) tuple, Func<T, bool> func)
        {
            if (func(tuple.v1)) ValueTupleValidationException.Throw(nameof(tuple.v1));
            if (func(tuple.v2)) ValueTupleValidationException.Throw(nameof(tuple.v2));
            return tuple;
        }
    }
}
using System;
using System.Runtime.CompilerServices;
using static En3Tho.HelperClasses.ThrowHelper;

namespace En3Tho.ValueTupleExtensions
{
    public static class ValueTupleNullCheckExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (T1, T2) NullCheck<T1, T2>(this (T1, T2) value)
        {
            value.Item1 ??= ThrowArgumentNullException(value.Item1, nameof(value.Item1));
            value.Item2 ??= ThrowArgumentNullException(value.Item2, nameof(value.Item2));
            return value;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (T1, T2, T3) NullCheck<T1, T2, T3>(this (T1, T2, T3) value)
        {
            value.Item1 ??= ThrowArgumentNullException(value.Item1, nameof(value.Item1));
            value.Item2 ??= ThrowArgumentNullException(value.Item2, nameof(value.Item2));
            value.Item3 ??= ThrowArgumentNullException(value.Item3, nameof(value.Item3));
            return value;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (T1, T2, T3, T4) NullCheck<T1, T2, T3, T4>(this (T1, T2, T3, T4) value)
        {
            value.Item1 ??= ThrowArgumentNullException(value.Item1, nameof(value.Item1));
            value.Item2 ??= ThrowArgumentNullException(value.Item2, nameof(value.Item2));
            value.Item3 ??= ThrowArgumentNullException(value.Item3, nameof(value.Item3));
            value.Item4 ??= ThrowArgumentNullException(value.Item4, nameof(value.Item4));
            return value;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (T1, T2, T3, T4, T5) NullCheck<T1, T2, T3, T4, T5>(this (T1, T2, T3, T4, T5) value)
        {
            value.Item1 ??= ThrowArgumentNullException(value.Item1, nameof(value.Item1));
            value.Item2 ??= ThrowArgumentNullException(value.Item2, nameof(value.Item2));
            value.Item3 ??= ThrowArgumentNullException(value.Item3, nameof(value.Item3));
            value.Item4 ??= ThrowArgumentNullException(value.Item4, nameof(value.Item4));
            value.Item5 ??= ThrowArgumentNullException(value.Item5, nameof(value.Item5));
            return value;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (T1, T2, T3, T4, T5, T6) NullCheck<T1, T2, T3, T4, T5, T6>(this (T1, T2, T3, T4, T5, T6) value)
        {
            value.Item1 ??= ThrowArgumentNullException(value.Item1, nameof(value.Item1));
            value.Item2 ??= ThrowArgumentNullException(value.Item2, nameof(value.Item2));
            value.Item3 ??= ThrowArgumentNullException(value.Item3, nameof(value.Item3));
            value.Item4 ??= ThrowArgumentNullException(value.Item4, nameof(value.Item4));
            value.Item5 ??= ThrowArgumentNullException(value.Item5, nameof(value.Item5));
            value.Item6 ??= ThrowArgumentNullException(value.Item6, nameof(value.Item6));
            return value;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (T1, T2, T3, T4, T5, T6, T7) NullCheck<T1, T2, T3, T4, T5, T6, T7>(this (T1, T2, T3, T4, T5, T6, T7) value)
        {
            value.Item1 ??= ThrowArgumentNullException(value.Item1, nameof(value.Item1));
            value.Item2 ??= ThrowArgumentNullException(value.Item2, nameof(value.Item2));
            value.Item3 ??= ThrowArgumentNullException(value.Item3, nameof(value.Item3));
            value.Item4 ??= ThrowArgumentNullException(value.Item4, nameof(value.Item4));
            value.Item5 ??= ThrowArgumentNullException(value.Item5, nameof(value.Item5));
            value.Item6 ??= ThrowArgumentNullException(value.Item6, nameof(value.Item6));
            value.Item7 ??= ThrowArgumentNullException(value.Item7, nameof(value.Item7));
            return value;
        }
    }
}
using System;
using ExtensionsAndStuff.HelperClasses;

namespace ExtensionsAndStuff.ValueTupleExtensions
{
    public static class NullCheckExtensions
    {
        public static T NullCheck<T>(this T value)
            where T : class
        {
            return value ?? ThrowHelper.ThrowArgumentNullException(value, nameof(value));
        }

        public static (T1, T2) NullCheck<T1, T2>(this (T1, T2) value)
            where T1 : class where T2 : class
        {
            value.Item1 ??= ThrowHelper.ThrowArgumentNullException(value.Item1, nameof(value.Item1));
            value.Item2 ??= ThrowHelper.ThrowArgumentNullException(value.Item2, nameof(value.Item2));
            return value;
        }

        public static (T1, T2, T3) NullCheck<T1, T2, T3>(this (T1, T2, T3) value)
            where T1 : class where T2 : class where T3 : class
        {
            value.Item1 ??= ThrowHelper.ThrowArgumentNullException(value.Item1, nameof(value.Item1));
            value.Item2 ??= ThrowHelper.ThrowArgumentNullException(value.Item2, nameof(value.Item2));
            value.Item3 ??= ThrowHelper.ThrowArgumentNullException(value.Item3, nameof(value.Item3));
            return value;
        }

        public static (T1, T2, T3, T4) NullCheck<T1, T2, T3, T4>(this (T1, T2, T3, T4) value)
            where T1 : class where T2 : class where T3 : class where T4 : class
        {
            value.Item1 ??= ThrowHelper.ThrowArgumentNullException(value.Item1, nameof(value.Item1));
            value.Item2 ??= ThrowHelper.ThrowArgumentNullException(value.Item2, nameof(value.Item2));
            value.Item3 ??= ThrowHelper.ThrowArgumentNullException(value.Item3, nameof(value.Item3));
            value.Item4 ??= ThrowHelper.ThrowArgumentNullException(value.Item4, nameof(value.Item4));
            return value;
        }

        public static (T1, T2, T3, T4, T5) NullCheck<T1, T2, T3, T4, T5>(this (T1, T2, T3, T4, T5) value)
            where T1 : class where T2 : class where T3 : class where T4 : class where T5 : class
        {
            value.Item1 ??= ThrowHelper.ThrowArgumentNullException(value.Item1, nameof(value.Item1));
            value.Item2 ??= ThrowHelper.ThrowArgumentNullException(value.Item2, nameof(value.Item2));
            value.Item3 ??= ThrowHelper.ThrowArgumentNullException(value.Item3, nameof(value.Item3));
            value.Item4 ??= ThrowHelper.ThrowArgumentNullException(value.Item4, nameof(value.Item4));
            value.Item5 ??= ThrowHelper.ThrowArgumentNullException(value.Item5, nameof(value.Item5));
            return value;
        }

        public static (T1, T2, T3, T4, T5, T6) NullCheck<T1, T2, T3, T4, T5, T6>(this (T1, T2, T3, T4, T5, T6) value)
            where T1 : class where T2 : class where T3 : class where T4 : class where T5 : class where T6 : class
        {
            value.Item1 ??= ThrowHelper.ThrowArgumentNullException(value.Item1, nameof(value.Item1));
            value.Item2 ??= ThrowHelper.ThrowArgumentNullException(value.Item2, nameof(value.Item2));
            value.Item3 ??= ThrowHelper.ThrowArgumentNullException(value.Item3, nameof(value.Item3));
            value.Item4 ??= ThrowHelper.ThrowArgumentNullException(value.Item4, nameof(value.Item4));
            value.Item5 ??= ThrowHelper.ThrowArgumentNullException(value.Item5, nameof(value.Item5));
            value.Item6 ??= ThrowHelper.ThrowArgumentNullException(value.Item6, nameof(value.Item6));
            return value;
        }

        public static (T1, T2, T3, T4, T5, T6, T7) NullCheck<T1, T2, T3, T4, T5, T6, T7>(this (T1, T2, T3, T4, T5, T6, T7) value)
            where T1 : class where T2 : class where T3 : class where T4 : class where T5 : class where T6 : class where T7 : class
        {
            value.Item1 ??= ThrowHelper.ThrowArgumentNullException(value.Item1, nameof(value.Item1));
            value.Item2 ??= ThrowHelper.ThrowArgumentNullException(value.Item2, nameof(value.Item2));
            value.Item3 ??= ThrowHelper.ThrowArgumentNullException(value.Item3, nameof(value.Item3));
            value.Item4 ??= ThrowHelper.ThrowArgumentNullException(value.Item4, nameof(value.Item4));
            value.Item5 ??= ThrowHelper.ThrowArgumentNullException(value.Item5, nameof(value.Item5));
            value.Item6 ??= ThrowHelper.ThrowArgumentNullException(value.Item6, nameof(value.Item6));
            value.Item7 ??= ThrowHelper.ThrowArgumentNullException(value.Item7, nameof(value.Item7));
            return value;
        }
    }
}
using System.Runtime.CompilerServices;
using static En3Tho.ValueTupleExtensions.ThrowHelper;

namespace En3Tho.ValueTupleExtensions.OtherExtensions
{
    public static class ValueTupleNullCheckExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (T1, T2) NullCheck<T1, T2>(this (T1, T2) value, string nameOf1 = "Item1", string nameOf2 = "Item2")
        {
            value.Item1 ??= ThrowArgumentNullException(value.Item1, nameOf1);
            value.Item2 ??= ThrowArgumentNullException(value.Item2, nameOf2);
            return value;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (T1, T2, T3) NullCheck<T1, T2, T3>(this (T1, T2, T3) value, string nameOf1 = "Item1", string nameOf2 = "Item2",
            string nameOf3 = "Item3")
        {
            value.Item1 ??= ThrowArgumentNullException(value.Item1, nameOf1);
            value.Item2 ??= ThrowArgumentNullException(value.Item2, nameOf2);
            value.Item3 ??= ThrowArgumentNullException(value.Item3, nameOf3);
            return value;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (T1, T2, T3, T4) NullCheck<T1, T2, T3, T4>(this (T1, T2, T3, T4) value, string nameOf1 = "Item1", string nameOf2 = "Item2",
            string nameOf3 = "Item3", string nameOf4 = "Item4")
        {
            value.Item1 ??= ThrowArgumentNullException(value.Item1, nameOf1);
            value.Item2 ??= ThrowArgumentNullException(value.Item2, nameOf2);
            value.Item3 ??= ThrowArgumentNullException(value.Item3, nameOf3);
            value.Item4 ??= ThrowArgumentNullException(value.Item4, nameOf4);
            return value;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (T1, T2, T3, T4, T5) NullCheck<T1, T2, T3, T4, T5>(this (T1, T2, T3, T4, T5) value, string nameOf1 = "Item1", string nameOf2 = "Item2",
            string nameOf3 = "Item3", string nameOf4 = "Item4", string nameOf5 = "Item5")
        {
            value.Item1 ??= ThrowArgumentNullException(value.Item1, nameOf1);
            value.Item2 ??= ThrowArgumentNullException(value.Item2, nameOf2);
            value.Item3 ??= ThrowArgumentNullException(value.Item3, nameOf3);
            value.Item4 ??= ThrowArgumentNullException(value.Item4, nameOf4);
            value.Item5 ??= ThrowArgumentNullException(value.Item5, nameOf5);
            return value;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (T1, T2, T3, T4, T5, T6) NullCheck<T1, T2, T3, T4, T5, T6>(this (T1, T2, T3, T4, T5, T6) value, string nameOf1 = "Item1", string nameOf2 = "Item2",
            string nameOf3 = "Item3", string nameOf4 = "Item4", string nameOf5 = "Item5", string nameOf6 = "Item6")
        {
            value.Item1 ??= ThrowArgumentNullException(value.Item1, nameOf1);
            value.Item2 ??= ThrowArgumentNullException(value.Item2, nameOf2);
            value.Item3 ??= ThrowArgumentNullException(value.Item3, nameOf3);
            value.Item4 ??= ThrowArgumentNullException(value.Item4, nameOf4);
            value.Item5 ??= ThrowArgumentNullException(value.Item5, nameOf5);
            value.Item6 ??= ThrowArgumentNullException(value.Item6, nameOf6);
            return value;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (T1, T2, T3, T4, T5, T6, T7) NullCheck<T1, T2, T3, T4, T5, T6, T7>(this (T1, T2, T3, T4, T5, T6, T7) value, string nameOf1 = "Item1", string nameOf2 = "Item2",
            string nameOf3 = "Item3", string nameOf4 = "Item4", string nameOf5 = "Item5", string nameOf6 = "Item6", string nameOf7 = "Item7")
        {
            value.Item1 ??= ThrowArgumentNullException(value.Item1, nameOf1);
            value.Item2 ??= ThrowArgumentNullException(value.Item2, nameOf2);
            value.Item3 ??= ThrowArgumentNullException(value.Item3, nameOf3);
            value.Item4 ??= ThrowArgumentNullException(value.Item4, nameOf4);
            value.Item5 ??= ThrowArgumentNullException(value.Item5, nameOf5);
            value.Item6 ??= ThrowArgumentNullException(value.Item6, nameOf6);
            value.Item7 ??= ThrowArgumentNullException(value.Item7, nameOf7);
            return value;
        }
    }
}
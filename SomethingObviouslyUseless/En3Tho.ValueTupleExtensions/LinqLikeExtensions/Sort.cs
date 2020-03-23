using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using static En3Tho.HelperClasses.MiscHelper;

namespace En3Tho.ValueTupleExtensions.LinqLikeExtensions
{
    public static partial class ValueTupleLinqLikeExtensions
    {
#region SortByValue

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (T, T, T, T, T, T, T) Sort<T>(this (T, T, T, T, T, T, T) tuple, IComparer<T>? comparer = null)
            => SortInternal(ref tuple, comparer ?? Comparer<T>.Default, 1);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (T, T, T, T, T, T) Sort<T>(this (T, T, T, T, T, T) tuple, IComparer<T>? comparer = null)
            => SortInternal(ref tuple, comparer ?? Comparer<T>.Default, 1);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (T, T, T, T, T) Sort<T>(this (T, T, T, T, T) tuple, IComparer<T>? comparer = null)
            => SortInternal(ref tuple, comparer ?? Comparer<T>.Default, 1);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (T, T, T, T) Sort<T>(this (T, T, T, T) tuple, IComparer<T>? comparer = null)
            => SortInternal(ref tuple, comparer ?? Comparer<T>.Default, 1);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (T, T, T) Sort<T>(this (T, T, T) tuple, IComparer<T>? comparer = null)
            => SortInternal(ref tuple, comparer ?? Comparer<T>.Default, 1);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (T, T) Sort<T>(this (T, T) tuple, IComparer<T>? comparer = null)
            => SortInternal(ref tuple, comparer ?? Comparer<T>.Default, 1);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (T, T, T, T, T, T, T) Sort<T>(this (T, T, T, T, T, T, T) tuple) where T : IComparable<T>
            => SortInternal(ref tuple, 1);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (T, T, T, T, T, T) Sort<T>(this (T, T, T, T, T, T) tuple) where T : IComparable<T>
            => SortInternal(ref tuple, 1);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (T, T, T, T, T) Sort<T>(this (T, T, T, T, T) tuple) where T : IComparable<T>
            => SortInternal(ref tuple, 1);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (T, T, T, T) Sort<T>(this (T, T, T, T) tuple) where T : IComparable<T>
            => SortInternal(ref tuple, 1);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (T, T, T, T, T, T, T) SortByDescending<T>(this (T, T, T, T, T, T, T) tuple, IComparer<T> comparer)
            => SortInternal(ref tuple, comparer, -1);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (T, T, T, T, T, T) SortByDescending<T>(this (T, T, T, T, T, T) tuple, IComparer<T> comparer)
            => SortInternal(ref tuple, comparer, -1);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (T, T, T, T, T) SortByDescending<T>(this (T, T, T, T, T) tuple, IComparer<T> comparer)
            => SortInternal(ref tuple, comparer, -1);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (T, T, T, T) SortByDescending<T>(this (T, T, T, T) tuple, IComparer<T> comparer)
            => SortInternal(ref tuple, comparer, -1);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (T, T, T) SortByDescending<T>(this (T, T, T) tuple, IComparer<T> comparer)
            => SortInternal(ref tuple, comparer, -1);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (T, T) SortByDescending<T>(this (T, T) tuple, IComparer<T> comparer)
            => SortInternal(ref tuple, comparer, -1);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (T, T, T, T, T, T, T) SortByDescending<T>(this (T, T, T, T, T, T, T) tuple) where T : IComparable<T>
            => SortInternal(ref tuple, -1);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (T, T, T, T, T, T) SortByDescending<T>(this (T, T, T, T, T, T) tuple) where T : IComparable<T>
            => SortInternal(ref tuple, -1);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (T, T, T, T, T) SortByDescending<T>(this (T, T, T, T, T) tuple) where T : IComparable<T>
            => SortInternal(ref tuple, -1);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (T, T, T, T) SortByDescending<T>(this (T, T, T, T) tuple) where T : IComparable<T>
            => SortInternal(ref tuple, -1);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (T, T, T) SortByDescending<T>(this (T, T, T) tuple) where T : IComparable<T>
            => SortInternal(ref tuple, -1);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (T, T) SortByDescending<T>(this (T, T) tuple) where T : IComparable<T>
            => SortInternal(ref tuple, -1);

#endregion

#region SortByFunc

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (T, T, T, T, T, T, T) Sort<T, U>(this (T, T, T, T, T, T, T) tuple, Func<T, U> getter, IComparer<U>? comparer = null)
        {
            var unsortedValues = (getter(tuple.Item1), getter(tuple.Item2), getter(tuple.Item3), getter(tuple.Item4), getter(tuple.Item5), getter(tuple.Item6), getter(tuple.Item7));
            return SortInternal(ref tuple, ref unsortedValues, comparer ?? Comparer<U>.Default, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (T, T, T, T, T, T, T) Sort<T, U>(this (T, T, T, T, T, T, T) tuple, Func<T, U> getter) where U : IComparable<U>
        {
            var unsortedValues = (getter(tuple.Item1), getter(tuple.Item2), getter(tuple.Item3), getter(tuple.Item4), getter(tuple.Item5), getter(tuple.Item6), getter(tuple.Item7));
            return SortInternal(ref tuple, ref unsortedValues, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (T, T, T, T, T, T) Sort<T, U>(this (T, T, T, T, T, T) tuple, Func<T, U> getter, IComparer<U>? comparer = null)
        {
            var unsortedValues = (getter(tuple.Item1), getter(tuple.Item2), getter(tuple.Item3), getter(tuple.Item4), getter(tuple.Item5), getter(tuple.Item6));
            return SortInternal(ref tuple, ref unsortedValues, comparer ?? Comparer<U>.Default, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (T, T, T, T, T, T) Sort<T, U>(this (T, T, T, T, T, T) tuple, Func<T, U> getter) where U : IComparable<U>
        {
            var unsortedValues = (getter(tuple.Item1), getter(tuple.Item2), getter(tuple.Item3), getter(tuple.Item4), getter(tuple.Item5), getter(tuple.Item6));
            return SortInternal(ref tuple, ref unsortedValues, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (T, T, T, T, T) Sort<T, U>(this (T, T, T, T, T) tuple, Func<T, U> getter, IComparer<U>? comparer = null)
        {
            var unsortedValues = (getter(tuple.Item1), getter(tuple.Item2), getter(tuple.Item3), getter(tuple.Item4), getter(tuple.Item5));
            return SortInternal(ref tuple, ref unsortedValues, comparer ?? Comparer<U>.Default, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (T, T, T, T, T) Sort<T, U>(this (T, T, T, T, T) tuple, Func<T, U> getter) where U : IComparable<U>
        {
            var unsortedValues = (getter(tuple.Item1), getter(tuple.Item2), getter(tuple.Item3), getter(tuple.Item4), getter(tuple.Item5));
            return SortInternal(ref tuple, ref unsortedValues, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (T, T, T, T) Sort<T, U>(this (T, T, T, T) tuple, Func<T, U> getter, IComparer<U>? comparer = null)
        {
            var unsortedValues = (getter(tuple.Item1), getter(tuple.Item2), getter(tuple.Item3), getter(tuple.Item4));
            return SortInternal(ref tuple, ref unsortedValues, comparer ?? Comparer<U>.Default, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (T, T, T, T) Sort<T, U>(this (T, T, T, T) tuple, Func<T, U> getter) where U : IComparable<U>
        {
            var unsortedValues = (getter(tuple.Item1), getter(tuple.Item2), getter(tuple.Item3), getter(tuple.Item4));
            return SortInternal(ref tuple, ref unsortedValues, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (T, T, T) Sort<T, U>(this (T, T, T) tuple, Func<T, U> getter, IComparer<U>? comparer = null)
        {
            var unsortedValues = (getter(tuple.Item1), getter(tuple.Item2), getter(tuple.Item3));
            return SortInternal(ref tuple, ref unsortedValues, comparer ?? Comparer<U>.Default, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (T, T, T) Sort<T, U>(this (T, T, T) tuple, Func<T, U> getter) where U : IComparable<U>
        {
            var unsortedValues = (getter(tuple.Item1), getter(tuple.Item2), getter(tuple.Item3));
            return SortInternal(ref tuple, ref unsortedValues, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (T, T) Sort<T, U>(this (T, T) tuple, Func<T, U> getter, IComparer<U>? comparer = null)
        {
            var unsortedValues = (getter(tuple.Item1), getter(tuple.Item2));
            return SortInternal(ref tuple, ref unsortedValues, comparer ?? Comparer<U>.Default, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (T, T) Sort<T, U>(this (T, T) tuple, Func<T, U> getter) where U : IComparable<U>
        {
            var unsortedValues = (getter(tuple.Item1), getter(tuple.Item2));
            return SortInternal(ref tuple, ref unsortedValues, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (T, T, T, T, T, T, T) SortByDescending<T, U>(this (T, T, T, T, T, T, T) tuple, Func<T, U> getter, IComparer<U>? comparer = null)
        {
            var unsortedValues = (getter(tuple.Item1), getter(tuple.Item2), getter(tuple.Item3), getter(tuple.Item4), getter(tuple.Item5), getter(tuple.Item6), getter(tuple.Item7));
            return SortInternal(ref tuple, ref unsortedValues, comparer ?? Comparer<U>.Default, -1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (T, T, T, T, T, T, T) SortByDescending<T, U>(this (T, T, T, T, T, T, T) tuple, Func<T, U> getter) where U : IComparable<U>
        {
            var unsortedValues = (getter(tuple.Item1), getter(tuple.Item2), getter(tuple.Item3), getter(tuple.Item4), getter(tuple.Item5), getter(tuple.Item6), getter(tuple.Item7));
            return SortInternal(ref tuple, ref unsortedValues, -1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (T, T, T, T, T, T) SortByDescending<T, U>(this (T, T, T, T, T, T) tuple, Func<T, U> getter, IComparer<U>? comparer = null)
        {
            var unsortedValues = (getter(tuple.Item1), getter(tuple.Item2), getter(tuple.Item3), getter(tuple.Item4), getter(tuple.Item5), getter(tuple.Item6));
            return SortInternal(ref tuple, ref unsortedValues, comparer ?? Comparer<U>.Default, -1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (T, T, T, T, T, T) SortByDescending<T, U>(this (T, T, T, T, T, T) tuple, Func<T, U> getter) where U : IComparable<U>
        {
            var unsortedValues = (getter(tuple.Item1), getter(tuple.Item2), getter(tuple.Item3), getter(tuple.Item4), getter(tuple.Item5), getter(tuple.Item6));
            return SortInternal(ref tuple, ref unsortedValues, -1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (T, T, T, T, T) SortByDescending<T, U>(this (T, T, T, T, T) tuple, Func<T, U> getter, IComparer<U>? comparer = null)
        {
            var unsortedValues = (getter(tuple.Item1), getter(tuple.Item2), getter(tuple.Item3), getter(tuple.Item4), getter(tuple.Item5));
            return SortInternal(ref tuple, ref unsortedValues, comparer ?? Comparer<U>.Default, -1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (T, T, T, T, T) SortByDescending<T, U>(this (T, T, T, T, T) tuple, Func<T, U> getter) where U : IComparable<U>
        {
            var unsortedValues = (getter(tuple.Item1), getter(tuple.Item2), getter(tuple.Item3), getter(tuple.Item4), getter(tuple.Item5));
            return SortInternal(ref tuple, ref unsortedValues, -1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (T, T, T, T) SortByDescending<T, U>(this (T, T, T, T) tuple, Func<T, U> getter, IComparer<U>? comparer = null)
        {
            var unsortedValues = (getter(tuple.Item1), getter(tuple.Item2), getter(tuple.Item3), getter(tuple.Item4));
            return SortInternal(ref tuple, ref unsortedValues, comparer ?? Comparer<U>.Default, -1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (T, T, T, T) SortByDescending<T, U>(this (T, T, T, T) tuple, Func<T, U> getter) where U : IComparable<U>
        {
            var unsortedValues = (getter(tuple.Item1), getter(tuple.Item2), getter(tuple.Item3), getter(tuple.Item4));
            return SortInternal(ref tuple, ref unsortedValues, -1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (T, T, T) SortByDescending<T, U>(this (T, T, T) tuple, Func<T, U> getter, IComparer<U>? comparer = null)
        {
            var unsortedValues = (getter(tuple.Item1), getter(tuple.Item2), getter(tuple.Item3));
            return SortInternal(ref tuple, ref unsortedValues, comparer ?? Comparer<U>.Default, -1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (T, T, T) SortByDescending<T, U>(this (T, T, T) tuple, Func<T, U> getter) where U : IComparable<U>
        {
            var unsortedValues = (getter(tuple.Item1), getter(tuple.Item2), getter(tuple.Item3));
            return SortInternal(ref tuple, ref unsortedValues, -1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (T, T) SortByDescending<T, U>(this (T, T) tuple, Func<T, U> getter, IComparer<U>? comparer = null)
        {
            var unsortedValues = (getter(tuple.Item1), getter(tuple.Item2));
            return SortInternal(ref tuple, ref unsortedValues, comparer ?? Comparer<U>.Default, -1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (T, T) SortByDescending<T, U>(this (T, T) tuple, Func<T, U> getter) where U : IComparable<U>
        {
            var unsortedValues = (getter(tuple.Item1), getter(tuple.Item2));
            return SortInternal(ref tuple, ref unsortedValues, -1);
        }

#endregion

#region SortInternalSingleTuple

        private static (T, T, T, T, T, T, T) SortInternal<T>(ref (T, T, T, T, T, T, T) tuple, int comparison) where T : IComparable<T>
        {
            (T i0, T i1, T i2, T i3, T i4, T i5, T i6) result = tuple;

            if (result.i1.CompareTo(result.i2) == comparison) Swap(ref result.i1, ref result.i2);
            if (result.i3.CompareTo(result.i4) == comparison) Swap(ref result.i3, ref result.i4);
            if (result.i5.CompareTo(result.i6) == comparison) Swap(ref result.i5, ref result.i6);
            if (result.i0.CompareTo(result.i2) == comparison) Swap(ref result.i0, ref result.i2);
            if (result.i3.CompareTo(result.i5) == comparison) Swap(ref result.i3, ref result.i5);
            if (result.i4.CompareTo(result.i6) == comparison) Swap(ref result.i4, ref result.i6);
            if (result.i0.CompareTo(result.i1) == comparison) Swap(ref result.i0, ref result.i1);
            if (result.i4.CompareTo(result.i5) == comparison) Swap(ref result.i4, ref result.i5);
            if (result.i2.CompareTo(result.i6) == comparison) Swap(ref result.i2, ref result.i6);
            if (result.i0.CompareTo(result.i4) == comparison) Swap(ref result.i0, ref result.i4);
            if (result.i1.CompareTo(result.i5) == comparison) Swap(ref result.i1, ref result.i5);
            if (result.i0.CompareTo(result.i3) == comparison) Swap(ref result.i0, ref result.i3);
            if (result.i2.CompareTo(result.i5) == comparison) Swap(ref result.i2, ref result.i5);
            if (result.i1.CompareTo(result.i3) == comparison) Swap(ref result.i1, ref result.i3);
            if (result.i2.CompareTo(result.i4) == comparison) Swap(ref result.i2, ref result.i4);
            if (result.i2.CompareTo(result.i3) == comparison) Swap(ref result.i2, ref result.i3);

            return result;
        }

        private static (T, T, T, T, T, T, T) SortInternal<T>(ref (T, T, T, T, T, T, T) tuple, IComparer<T> comparer, int comparison)
        {
            (T i0, T i1, T i2, T i3, T i4, T i5, T i6) result = tuple;

            if (comparer.Compare(result.i1, result.i2) == comparison) Swap(ref result.i1, ref result.i2);
            if (comparer.Compare(result.i3, result.i4) == comparison) Swap(ref result.i3, ref result.i4);
            if (comparer.Compare(result.i5, result.i6) == comparison) Swap(ref result.i5, ref result.i6);
            if (comparer.Compare(result.i0, result.i2) == comparison) Swap(ref result.i0, ref result.i2);
            if (comparer.Compare(result.i3, result.i5) == comparison) Swap(ref result.i3, ref result.i5);
            if (comparer.Compare(result.i4, result.i6) == comparison) Swap(ref result.i4, ref result.i6);
            if (comparer.Compare(result.i0, result.i1) == comparison) Swap(ref result.i0, ref result.i1);
            if (comparer.Compare(result.i4, result.i5) == comparison) Swap(ref result.i4, ref result.i5);
            if (comparer.Compare(result.i2, result.i6) == comparison) Swap(ref result.i2, ref result.i6);
            if (comparer.Compare(result.i0, result.i4) == comparison) Swap(ref result.i0, ref result.i4);
            if (comparer.Compare(result.i1, result.i5) == comparison) Swap(ref result.i1, ref result.i5);
            if (comparer.Compare(result.i0, result.i3) == comparison) Swap(ref result.i0, ref result.i3);
            if (comparer.Compare(result.i2, result.i5) == comparison) Swap(ref result.i2, ref result.i5);
            if (comparer.Compare(result.i1, result.i3) == comparison) Swap(ref result.i1, ref result.i3);
            if (comparer.Compare(result.i2, result.i4) == comparison) Swap(ref result.i2, ref result.i4);
            if (comparer.Compare(result.i2, result.i3) == comparison) Swap(ref result.i2, ref result.i3);

            return result;
        }

        private static (T, T, T, T, T, T) SortInternal<T>(ref (T, T, T, T, T, T) tuple, IComparer<T> comparer, int comparison)
        {
            (T i0, T i1, T i2, T i3, T i4, T i5) result = tuple;

            if (comparer.Compare(result.i1, result.i2) == comparison) Swap(ref result.i1, ref result.i2);
            if (comparer.Compare(result.i4, result.i5) == comparison) Swap(ref result.i4, ref result.i5);
            if (comparer.Compare(result.i0, result.i2) == comparison) Swap(ref result.i0, ref result.i2);
            if (comparer.Compare(result.i3, result.i5) == comparison) Swap(ref result.i3, ref result.i5);
            if (comparer.Compare(result.i0, result.i1) == comparison) Swap(ref result.i0, ref result.i1);
            if (comparer.Compare(result.i3, result.i4) == comparison) Swap(ref result.i3, ref result.i4);
            if (comparer.Compare(result.i2, result.i5) == comparison) Swap(ref result.i2, ref result.i5);
            if (comparer.Compare(result.i0, result.i3) == comparison) Swap(ref result.i0, ref result.i3);
            if (comparer.Compare(result.i1, result.i4) == comparison) Swap(ref result.i1, ref result.i4);
            if (comparer.Compare(result.i2, result.i4) == comparison) Swap(ref result.i2, ref result.i4);
            if (comparer.Compare(result.i1, result.i3) == comparison) Swap(ref result.i1, ref result.i3);
            if (comparer.Compare(result.i2, result.i3) == comparison) Swap(ref result.i2, ref result.i3);

            return result;
        }

        private static (T, T, T, T, T, T) SortInternal<T>(ref (T, T, T, T, T, T) tuple, int comparison) where T : IComparable<T>
        {
            (T i0, T i1, T i2, T i3, T i4, T i5) result = tuple;

            if (result.i1.CompareTo(result.i2) == comparison) Swap(ref result.i1, ref result.i2);
            if (result.i4.CompareTo(result.i5) == comparison) Swap(ref result.i4, ref result.i5);
            if (result.i0.CompareTo(result.i2) == comparison) Swap(ref result.i0, ref result.i2);
            if (result.i3.CompareTo(result.i5) == comparison) Swap(ref result.i3, ref result.i5);
            if (result.i0.CompareTo(result.i1) == comparison) Swap(ref result.i0, ref result.i1);
            if (result.i3.CompareTo(result.i4) == comparison) Swap(ref result.i3, ref result.i4);
            if (result.i2.CompareTo(result.i5) == comparison) Swap(ref result.i2, ref result.i5);
            if (result.i0.CompareTo(result.i3) == comparison) Swap(ref result.i0, ref result.i3);
            if (result.i1.CompareTo(result.i4) == comparison) Swap(ref result.i1, ref result.i4);
            if (result.i2.CompareTo(result.i4) == comparison) Swap(ref result.i2, ref result.i4);
            if (result.i1.CompareTo(result.i3) == comparison) Swap(ref result.i1, ref result.i3);
            if (result.i2.CompareTo(result.i3) == comparison) Swap(ref result.i2, ref result.i3);

            return result;
        }

        private static (T, T, T, T, T) SortInternal<T>(ref (T, T, T, T, T) tuple, IComparer<T> comparer, int comparison)
        {
            (T i0, T i1, T i2, T i3, T i4) result = tuple;

            if (comparer.Compare(result.i0, result.i1) == comparison) Swap(ref result.i0, ref result.i1);
            if (comparer.Compare(result.i3, result.i4) == comparison) Swap(ref result.i3, ref result.i4);
            if (comparer.Compare(result.i2, result.i4) == comparison) Swap(ref result.i2, ref result.i4);
            if (comparer.Compare(result.i2, result.i3) == comparison) Swap(ref result.i2, ref result.i3);
            if (comparer.Compare(result.i1, result.i4) == comparison) Swap(ref result.i1, ref result.i4);
            if (comparer.Compare(result.i0, result.i3) == comparison) Swap(ref result.i0, ref result.i3);
            if (comparer.Compare(result.i0, result.i2) == comparison) Swap(ref result.i0, ref result.i2);
            if (comparer.Compare(result.i1, result.i3) == comparison) Swap(ref result.i1, ref result.i3);
            if (comparer.Compare(result.i1, result.i2) == comparison) Swap(ref result.i1, ref result.i2);

            return result;
        }

        private static (T, T, T, T, T) SortInternal<T>(ref (T, T, T, T, T) tuple, int comparison) where T : IComparable<T>
        {
            (T i0, T i1, T i2, T i3, T i4) result = tuple;

            if (result.i0.CompareTo(result.i1) == comparison) Swap(ref result.i0, ref result.i1);
            if (result.i3.CompareTo(result.i4) == comparison) Swap(ref result.i3, ref result.i4);
            if (result.i2.CompareTo(result.i4) == comparison) Swap(ref result.i2, ref result.i4);
            if (result.i2.CompareTo(result.i3) == comparison) Swap(ref result.i2, ref result.i3);
            if (result.i1.CompareTo(result.i4) == comparison) Swap(ref result.i1, ref result.i4);
            if (result.i0.CompareTo(result.i3) == comparison) Swap(ref result.i0, ref result.i3);
            if (result.i0.CompareTo(result.i2) == comparison) Swap(ref result.i0, ref result.i2);
            if (result.i1.CompareTo(result.i3) == comparison) Swap(ref result.i1, ref result.i3);
            if (result.i1.CompareTo(result.i2) == comparison) Swap(ref result.i1, ref result.i2);

            return result;
        }

        private static (T, T, T, T) SortInternal<T>(ref (T, T, T, T) tuple, IComparer<T> comparer, int comparison)
        {
            (T i0, T i1, T i2, T i3) result = tuple;

            if (comparer.Compare(result.i0, result.i1) == comparison) Swap(ref result.i0, ref result.i1);
            if (comparer.Compare(result.i2, result.i3) == comparison) Swap(ref result.i2, ref result.i3);
            if (comparer.Compare(result.i0, result.i2) == comparison) Swap(ref result.i0, ref result.i2);
            if (comparer.Compare(result.i1, result.i3) == comparison) Swap(ref result.i1, ref result.i3);
            if (comparer.Compare(result.i1, result.i2) == comparison) Swap(ref result.i1, ref result.i2);

            return result;
        }

        private static (T, T, T, T) SortInternal<T>(ref (T, T, T, T) tuple, int comparison) where T : IComparable<T>
        {
            (T i0, T i1, T i2, T i3) result = tuple;

            if (result.i0.CompareTo(result.i1) == comparison) Swap(ref result.i0, ref result.i1);
            if (result.i2.CompareTo(result.i3) == comparison) Swap(ref result.i2, ref result.i3);
            if (result.i0.CompareTo(result.i2) == comparison) Swap(ref result.i0, ref result.i2);
            if (result.i1.CompareTo(result.i3) == comparison) Swap(ref result.i1, ref result.i3);
            if (result.i1.CompareTo(result.i2) == comparison) Swap(ref result.i1, ref result.i2);

            return result;
        }

        private static (T, T, T) SortInternal<T>(ref (T, T, T) tuple, IComparer<T> comparer, int comparison)
        {
            (T i0, T i1, T i2) result = tuple;
            if (comparer.Compare(result.i1, result.i2) == comparison) Swap(ref result.i1, ref result.i2);
            if (comparer.Compare(result.i0, result.i2) == comparison) Swap(ref result.i0, ref result.i2);
            if (comparer.Compare(result.i0, result.i1) == comparison) Swap(ref result.i0, ref result.i1);
            return result;
        }

        private static (T, T, T) SortInternal<T>(ref (T, T, T) tuple, int comparison) where T : IComparable<T>
        {
            (T i0, T i1, T i2) result = tuple;
            if (result.i1.CompareTo(result.i2) == comparison) Swap(ref result.i1, ref result.i2);
            if (result.i0.CompareTo(result.i2) == comparison) Swap(ref result.i0, ref result.i2);
            if (result.i0.CompareTo(result.i1) == comparison) Swap(ref result.i0, ref result.i1);
            return result;
        }

        private static (T, T) SortInternal<T>(ref (T, T) tuple, IComparer<T> comparer, int comparison)
        {
            (T i0, T i1) result = tuple;
            if (comparer.Compare(result.i0, result.i1) == comparison) Swap(ref result.i0, ref result.i1);
            return result;
        }

        private static (T, T) SortInternal<T>(ref (T, T) tuple, int comparison) where T : IComparable<T>
        {
            (T i0, T i1) result = tuple;
            if (result.i0.CompareTo(result.i1) == comparison) Swap(ref result.i0, ref result.i1);
            return result;
        }

#endregion

#region SortInternalDoubleTuple

        private static (T, T, T, T, T, T, T) SortInternal<T, U>(ref (T, T, T, T, T, T, T) values, ref (U i0, U i1, U i2, U i3, U i4, U i5, U i6) references, IComparer<U> comparer, int comparison)
        {
            (T i0, T i1, T i2, T i3, T i4, T i5, T i6) result = values;

            if (comparer.Compare(references.i1, references.i2) == comparison)
            {
                Swap(ref result.i1, ref result.i2);
                Swap(ref references.i1, ref references.i2);
            }

            if (comparer.Compare(references.i3, references.i4) == comparison)
            {
                Swap(ref result.i3, ref result.i4);
                Swap(ref references.i3, ref references.i4);
            }

            if (comparer.Compare(references.i5, references.i6) == comparison)
            {
                Swap(ref result.i5, ref result.i6);
                Swap(ref references.i5, ref references.i6);
            }

            if (comparer.Compare(references.i0, references.i2) == comparison)
            {
                Swap(ref result.i0, ref result.i2);
                Swap(ref references.i0, ref references.i2);
            }

            if (comparer.Compare(references.i3, references.i5) == comparison)
            {
                Swap(ref result.i3, ref result.i5);
                Swap(ref references.i3, ref references.i5);
            }

            if (comparer.Compare(references.i4, references.i6) == comparison)
            {
                Swap(ref result.i4, ref result.i6);
                Swap(ref references.i4, ref references.i6);
            }

            if (comparer.Compare(references.i0, references.i1) == comparison)
            {
                Swap(ref result.i0, ref result.i1);
                Swap(ref references.i0, ref references.i1);
            }

            if (comparer.Compare(references.i4, references.i5) == comparison)
            {
                Swap(ref result.i4, ref result.i5);
                Swap(ref references.i4, ref references.i5);
            }

            if (comparer.Compare(references.i2, references.i6) == comparison)
            {
                Swap(ref result.i2, ref result.i6);
                Swap(ref references.i2, ref references.i6);
            }

            if (comparer.Compare(references.i0, references.i4) == comparison)
            {
                Swap(ref result.i0, ref result.i4);
                Swap(ref references.i0, ref references.i4);
            }

            if (comparer.Compare(references.i1, references.i5) == comparison)
            {
                Swap(ref result.i1, ref result.i5);
                Swap(ref references.i1, ref references.i5);
            }

            if (comparer.Compare(references.i0, references.i3) == comparison)
            {
                Swap(ref result.i0, ref result.i3);
                Swap(ref references.i0, ref references.i3);
            }

            if (comparer.Compare(references.i2, references.i5) == comparison)
            {
                Swap(ref result.i2, ref result.i5);
                Swap(ref references.i2, ref references.i5);
            }

            if (comparer.Compare(references.i1, references.i3) == comparison)
            {
                Swap(ref result.i1, ref result.i3);
                Swap(ref references.i1, ref references.i3);
            }

            if (comparer.Compare(references.i2, references.i4) == comparison)
            {
                Swap(ref result.i2, ref result.i4);
                Swap(ref references.i2, ref references.i4);
            }

            if (comparer.Compare(references.i2, references.i3) == comparison)
            {
                Swap(ref result.i2, ref result.i3);
                Swap(ref references.i2, ref references.i3);
            }

            return result;
        }

        private static (T, T, T, T, T, T, T) SortInternal<T, U>(ref (T, T, T, T, T, T, T) values, ref (U i0, U i1, U i2, U i3, U i4, U i5, U i6) references, int comparison) where U : IComparable<U>
        {
            (T i0, T i1, T i2, T i3, T i4, T i5, T i6) result = values;

            if (references.i1.CompareTo(references.i2) == comparison)
            {
                Swap(ref result.i1, ref result.i2);
                Swap(ref references.i1, ref references.i2);
            }

            if (references.i3.CompareTo(references.i4) == comparison)
            {
                Swap(ref result.i3, ref result.i4);
                Swap(ref references.i3, ref references.i4);
            }

            if (references.i5.CompareTo(references.i6) == comparison)
            {
                Swap(ref result.i5, ref result.i6);
                Swap(ref references.i5, ref references.i6);
            }

            if (references.i0.CompareTo(references.i2) == comparison)
            {
                Swap(ref result.i0, ref result.i2);
                Swap(ref references.i0, ref references.i2);
            }

            if (references.i3.CompareTo(references.i5) == comparison)
            {
                Swap(ref result.i3, ref result.i5);
                Swap(ref references.i3, ref references.i5);
            }

            if (references.i4.CompareTo(references.i6) == comparison)
            {
                Swap(ref result.i4, ref result.i6);
                Swap(ref references.i4, ref references.i6);
            }

            if (references.i0.CompareTo(references.i1) == comparison)
            {
                Swap(ref result.i0, ref result.i1);
                Swap(ref references.i0, ref references.i1);
            }

            if (references.i4.CompareTo(references.i5) == comparison)
            {
                Swap(ref result.i4, ref result.i5);
                Swap(ref references.i4, ref references.i5);
            }

            if (references.i2.CompareTo(references.i6) == comparison)
            {
                Swap(ref result.i2, ref result.i6);
                Swap(ref references.i2, ref references.i6);
            }

            if (references.i0.CompareTo(references.i4) == comparison)
            {
                Swap(ref result.i0, ref result.i4);
                Swap(ref references.i0, ref references.i4);
            }

            if (references.i1.CompareTo(references.i5) == comparison)
            {
                Swap(ref result.i1, ref result.i5);
                Swap(ref references.i1, ref references.i5);
            }

            if (references.i0.CompareTo(references.i3) == comparison)
            {
                Swap(ref result.i0, ref result.i3);
                Swap(ref references.i0, ref references.i3);
            }

            if (references.i2.CompareTo(references.i5) == comparison)
            {
                Swap(ref result.i2, ref result.i5);
                Swap(ref references.i2, ref references.i5);
            }

            if (references.i1.CompareTo(references.i3) == comparison)
            {
                Swap(ref result.i1, ref result.i3);
                Swap(ref references.i1, ref references.i3);
            }

            if (references.i2.CompareTo(references.i4) == comparison)
            {
                Swap(ref result.i2, ref result.i4);
                Swap(ref references.i2, ref references.i4);
            }

            if (references.i2.CompareTo(references.i3) == comparison)
            {
                Swap(ref result.i2, ref result.i3);
                Swap(ref references.i2, ref references.i3);
            }

            return result;
        }

        private static (T, T, T, T, T, T) SortInternal<T, U>(ref (T, T, T, T, T, T) tuple, ref (U i0, U i1, U i2, U i3, U i4, U i5) references, IComparer<U> comparer, int comparison)
        {
            (T i0, T i1, T i2, T i3, T i4, T i5) result = tuple;

            if (comparer.Compare(references.i1, references.i2) == comparison)
            {
                Swap(ref result.i1, ref result.i2);
                Swap(ref references.i1, ref references.i2);
            }

            if (comparer.Compare(references.i4, references.i5) == comparison)
            {
                Swap(ref result.i4, ref result.i5);
                Swap(ref references.i4, ref references.i5);
            }

            if (comparer.Compare(references.i0, references.i2) == comparison)
            {
                Swap(ref result.i0, ref result.i2);
                Swap(ref references.i0, ref references.i2);
            }

            if (comparer.Compare(references.i3, references.i5) == comparison)
            {
                Swap(ref result.i3, ref result.i5);
                Swap(ref references.i3, ref references.i5);
            }

            if (comparer.Compare(references.i0, references.i1) == comparison)
            {
                Swap(ref result.i0, ref result.i1);
                Swap(ref references.i0, ref references.i1);
            }

            if (comparer.Compare(references.i3, references.i4) == comparison)
            {
                Swap(ref result.i3, ref result.i4);
                Swap(ref references.i3, ref references.i4);
            }

            if (comparer.Compare(references.i2, references.i5) == comparison)
            {
                Swap(ref result.i2, ref result.i5);
                Swap(ref references.i2, ref references.i5);
            }

            if (comparer.Compare(references.i0, references.i3) == comparison)
            {
                Swap(ref result.i0, ref result.i3);
                Swap(ref references.i0, ref references.i3);
            }

            if (comparer.Compare(references.i1, references.i4) == comparison)
            {
                Swap(ref result.i1, ref result.i4);
                Swap(ref references.i1, ref references.i4);
            }

            if (comparer.Compare(references.i2, references.i4) == comparison)
            {
                Swap(ref result.i2, ref result.i4);
                Swap(ref references.i2, ref references.i4);
            }

            if (comparer.Compare(references.i1, references.i3) == comparison)
            {
                Swap(ref result.i1, ref result.i3);
                Swap(ref references.i1, ref references.i3);
            }

            if (comparer.Compare(references.i2, references.i3) == comparison)
            {
                Swap(ref result.i2, ref result.i3);
                Swap(ref references.i2, ref references.i3);
            }

            return result;
        }

        private static (T, T, T, T, T, T) SortInternal<T, U>(ref (T, T, T, T, T, T) tuple, ref (U i0, U i1, U i2, U i3, U i4, U i5) references, int comparison) where U : IComparable<U>
        {
            (T i0, T i1, T i2, T i3, T i4, T i5) result = tuple;

            if (references.i1.CompareTo(references.i2) == comparison)
            {
                Swap(ref result.i1, ref result.i2);
                Swap(ref references.i1, ref references.i2);
            }

            if (references.i4.CompareTo(references.i5) == comparison)
            {
                Swap(ref result.i4, ref result.i5);
                Swap(ref references.i4, ref references.i5);
            }

            if (references.i0.CompareTo(references.i2) == comparison)
            {
                Swap(ref result.i0, ref result.i2);
                Swap(ref references.i0, ref references.i2);
            }

            if (references.i3.CompareTo(references.i5) == comparison)
            {
                Swap(ref result.i3, ref result.i5);
                Swap(ref references.i3, ref references.i5);
            }

            if (references.i0.CompareTo(references.i1) == comparison)
            {
                Swap(ref result.i0, ref result.i1);
                Swap(ref references.i0, ref references.i1);
            }

            if (references.i3.CompareTo(references.i4) == comparison)
            {
                Swap(ref result.i3, ref result.i4);
                Swap(ref references.i3, ref references.i4);
            }

            if (references.i2.CompareTo(references.i5) == comparison)
            {
                Swap(ref result.i2, ref result.i5);
                Swap(ref references.i2, ref references.i5);
            }

            if (references.i0.CompareTo(references.i3) == comparison)
            {
                Swap(ref result.i0, ref result.i3);
                Swap(ref references.i0, ref references.i3);
            }

            if (references.i1.CompareTo(references.i4) == comparison)
            {
                Swap(ref result.i1, ref result.i4);
                Swap(ref references.i1, ref references.i4);
            }

            if (references.i2.CompareTo(references.i4) == comparison)
            {
                Swap(ref result.i2, ref result.i4);
                Swap(ref references.i2, ref references.i4);
            }

            if (references.i1.CompareTo(references.i3) == comparison)
            {
                Swap(ref result.i1, ref result.i3);
                Swap(ref references.i1, ref references.i3);
            }

            if (references.i2.CompareTo(references.i3) == comparison)
            {
                Swap(ref result.i2, ref result.i3);
                Swap(ref references.i2, ref references.i3);
            }

            return result;
        }

        private static (T, T, T, T, T) SortInternal<T, U>(ref (T, T, T, T, T) tuple, ref (U i0, U i1, U i2, U i3, U i4) references, IComparer<U> comparer, int comparison)
        {
            (T i0, T i1, T i2, T i3, T i4) result = tuple;

            if (comparer.Compare(references.i0, references.i1) == comparison)
            {
                Swap(ref result.i0, ref result.i1);
                Swap(ref references.i0, ref references.i1);
            }

            if (comparer.Compare(references.i3, references.i4) == comparison)
            {
                Swap(ref result.i3, ref result.i4);
                Swap(ref references.i3, ref references.i4);
            }

            if (comparer.Compare(references.i2, references.i4) == comparison)
            {
                Swap(ref result.i2, ref result.i4);
                Swap(ref references.i2, ref references.i4);
            }

            if (comparer.Compare(references.i2, references.i3) == comparison)
            {
                Swap(ref result.i2, ref result.i3);
                Swap(ref references.i2, ref references.i3);
            }

            if (comparer.Compare(references.i1, references.i4) == comparison)
            {
                Swap(ref result.i1, ref result.i4);
                Swap(ref references.i1, ref references.i4);
            }

            if (comparer.Compare(references.i0, references.i3) == comparison)
            {
                Swap(ref result.i0, ref result.i3);
                Swap(ref references.i0, ref references.i3);
            }

            if (comparer.Compare(references.i0, references.i2) == comparison)
            {
                Swap(ref result.i0, ref result.i2);
                Swap(ref references.i0, ref references.i2);
            }

            if (comparer.Compare(references.i1, references.i3) == comparison)
            {
                Swap(ref result.i1, ref result.i3);
                Swap(ref references.i1, ref references.i3);
            }

            if (comparer.Compare(references.i1, references.i2) == comparison)
            {
                Swap(ref result.i1, ref result.i2);
                Swap(ref references.i1, ref references.i2);
            }

            return result;
        }

        private static (T, T, T, T, T) SortInternal<T, U>(ref (T, T, T, T, T) tuple, ref (U i0, U i1, U i2, U i3, U i4) references, int comparison) where U : IComparable<U>
        {
            (T i0, T i1, T i2, T i3, T i4) result = tuple;

            if (references.i0.CompareTo(references.i1) == comparison)
            {
                Swap(ref result.i0, ref result.i1);
                Swap(ref references.i0, ref references.i1);
            }

            if (references.i3.CompareTo(references.i4) == comparison)
            {
                Swap(ref result.i3, ref result.i4);
                Swap(ref references.i3, ref references.i4);
            }

            if (references.i2.CompareTo(references.i4) == comparison)
            {
                Swap(ref result.i2, ref result.i4);
                Swap(ref references.i2, ref references.i4);
            }

            if (references.i2.CompareTo(references.i3) == comparison)
            {
                Swap(ref result.i2, ref result.i3);
                Swap(ref references.i2, ref references.i3);
            }

            if (references.i1.CompareTo(references.i4) == comparison)
            {
                Swap(ref result.i1, ref result.i4);
                Swap(ref references.i1, ref references.i4);
            }

            if (references.i0.CompareTo(references.i3) == comparison)
            {
                Swap(ref result.i0, ref result.i3);
                Swap(ref references.i0, ref references.i3);
            }

            if (references.i0.CompareTo(references.i2) == comparison)
            {
                Swap(ref result.i0, ref result.i2);
                Swap(ref references.i0, ref references.i2);
            }

            if (references.i1.CompareTo(references.i3) == comparison)
            {
                Swap(ref result.i1, ref result.i3);
                Swap(ref references.i1, ref references.i3);
            }

            if (references.i1.CompareTo(references.i2) == comparison)
            {
                Swap(ref result.i1, ref result.i2);
                Swap(ref references.i1, ref references.i2);
            }

            return result;
        }

        private static (T, T, T, T) SortInternal<T, U>(ref (T, T, T, T) tuple, ref (U i0, U i1, U i2, U i3) references, IComparer<U> comparer, int comparison)
        {
            (T i0, T i1, T i2, T i3) result = tuple;

            if (comparer.Compare(references.i0, references.i1) == comparison)
            {
                Swap(ref result.i0, ref result.i1);
                Swap(ref references.i0, ref references.i1);
            }

            if (comparer.Compare(references.i2, references.i3) == comparison)
            {
                Swap(ref result.i2, ref result.i3);
                Swap(ref references.i2, ref references.i3);
            }

            if (comparer.Compare(references.i0, references.i2) == comparison)
            {
                Swap(ref result.i0, ref result.i2);
                Swap(ref references.i0, ref references.i2);
            }

            if (comparer.Compare(references.i1, references.i3) == comparison)
            {
                Swap(ref result.i1, ref result.i3);
                Swap(ref references.i1, ref references.i3);
            }

            if (comparer.Compare(references.i1, references.i2) == comparison)
            {
                Swap(ref result.i1, ref result.i2);
                Swap(ref references.i1, ref references.i2);
            }

            return result;
        }

        private static (T, T, T, T) SortInternal<T, U>(ref (T, T, T, T) tuple, ref (U i0, U i1, U i2, U i3) references, int comparison) where U : IComparable<U>
        {
            (T i0, T i1, T i2, T i3) result = tuple;

            if (references.i0.CompareTo(references.i1) == comparison)
            {
                Swap(ref result.i0, ref result.i1);
                Swap(ref references.i0, ref references.i1);
            }

            if (references.i2.CompareTo(references.i3) == comparison)
            {
                Swap(ref result.i2, ref result.i3);
                Swap(ref references.i2, ref references.i3);
            }

            if (references.i0.CompareTo(references.i2) == comparison)
            {
                Swap(ref result.i0, ref result.i2);
                Swap(ref references.i0, ref references.i2);
            }

            if (references.i1.CompareTo(references.i3) == comparison)
            {
                Swap(ref result.i1, ref result.i3);
                Swap(ref references.i1, ref references.i3);
            }

            if (references.i1.CompareTo(references.i2) == comparison)
            {
                Swap(ref result.i1, ref result.i2);
                Swap(ref references.i1, ref references.i2);
            }

            return result;
        }

        private static (T, T, T) SortInternal<T, U>(ref (T, T, T) tuple, ref (U i0, U i1, U i2) references, IComparer<U> comparer, int comparison)
        {
            (T i0, T i1, T i2) result = tuple;
            if (comparer.Compare(references.i1, references.i2) == comparison)
            {
                Swap(ref result.i1, ref result.i2);
                Swap(ref references.i1, ref references.i2);
            }

            if (comparer.Compare(references.i0, references.i2) == comparison)
            {
                Swap(ref result.i0, ref result.i2);
                Swap(ref references.i0, ref references.i2);
            }

            if (comparer.Compare(references.i0, references.i1) == comparison)
            {
                Swap(ref result.i0, ref result.i1);
                Swap(ref references.i0, ref references.i1);
            }

            return result;
        }

        private static (T, T, T) SortInternal<T, U>(ref (T, T, T) tuple, ref (U i0, U i1, U i2) references, int comparison) where U : IComparable<U>
        {
            (T i0, T i1, T i2) result = tuple;
            if (references.i1.CompareTo(references.i2) == comparison)
            {
                Swap(ref result.i1, ref result.i2);
                Swap(ref references.i1, ref references.i2);
            }

            if (references.i0.CompareTo(references.i2) == comparison)
            {
                Swap(ref result.i0, ref result.i2);
                Swap(ref references.i0, ref references.i2);
            }

            if (references.i0.CompareTo(references.i1) == comparison)
            {
                Swap(ref result.i0, ref result.i1);
                Swap(ref references.i0, ref references.i1);
            }

            return result;
        }

        private static (T, T) SortInternal<T, U>(ref (T, T) tuple, ref (U i0, U i1) references, IComparer<U> comparer, int comparison)
        {
            (T i0, T i1) result = tuple;
            if (comparer.Compare(references.i0, references.i1) == comparison)
            {
                Swap(ref result.i0, ref result.i1);
                Swap(ref references.i0, ref references.i1);
            }

            return result;
        }

        private static (T, T) SortInternal<T, U>(ref (T, T) tuple, ref (U i0, U i1) references, int comparison) where U : IComparable<U>
        {
            (T i0, T i1) result = tuple;
            if (references.i0.CompareTo(references.i1) == comparison)
            {
                Swap(ref result.i0, ref result.i1);
                Swap(ref references.i0, ref references.i1);
            }

            return result;
        }

#endregion
    }
}
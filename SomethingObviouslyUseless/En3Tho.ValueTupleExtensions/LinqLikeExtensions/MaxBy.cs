using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace En3Tho.ValueTupleExtensions.LinqLikeExtensions
{
    public static partial class ValueTupleLinqLikeExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T MaxBy<T, U>(in this (T v1, T v2, T v3, T v4, T v5, T v6, T v7) tuple, Func<T, U> map) where U : IComparable<U>
        {
            var result = tuple.v1;
            U vNext;
            var vCurrent = map(tuple.v1);
            if ((vNext = map(tuple.v2)).CompareTo(vCurrent) >= 0)
            {
                result = tuple.v2;
                vCurrent = vNext;
            }

            if ((vNext = map(tuple.v3)).CompareTo(vCurrent) >= 0)
            {
                result = tuple.v3;
                vCurrent = vNext;
            }

            if ((vNext = map(tuple.v4)).CompareTo(vCurrent) >= 0)
            {
                result = tuple.v4;
                vCurrent = vNext;
            }

            if ((vNext = map(tuple.v5)).CompareTo(vCurrent) >= 0)
            {
                result = tuple.v5;
                vCurrent = vNext;
            }

            if ((vNext = map(tuple.v6)).CompareTo(vCurrent) >= 0)
            {
                result = tuple.v6;
                vCurrent = vNext;
            }

            return map(tuple.v7).CompareTo(vCurrent) >= 0 ? tuple.v7 : result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T MaxBy<T, U>(in this (T v1, T v2, T v3, T v4, T v5, T v6) tuple, Func<T, U> map) where U : IComparable<U>
        {
            var result = tuple.v1;
            U vNext;
            var vCurrent = map(tuple.v1);
            if ((vNext = map(tuple.v2)).CompareTo(vCurrent) >= 0)
            {
                result = tuple.v2;
                vCurrent = vNext;
            }

            if ((vNext = map(tuple.v3)).CompareTo(vCurrent) >= 0)
            {
                result = tuple.v3;
                vCurrent = vNext;
            }

            if ((vNext = map(tuple.v4)).CompareTo(vCurrent) >= 0)
            {
                result = tuple.v4;
                vCurrent = vNext;
            }

            if ((vNext = map(tuple.v5)).CompareTo(vCurrent) >= 0)
            {
                result = tuple.v5;
                vCurrent = vNext;
            }

            return map(tuple.v6).CompareTo(vCurrent) >= 0 ? tuple.v6 : result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T MaxBy<T, U>(in this (T v1, T v2, T v3, T v4, T v5) tuple, Func<T, U> map) where U : IComparable<U>
        {
            var result = tuple.v1;
            U vNext;
            var vCurrent = map(tuple.v1);
            if ((vNext = map(tuple.v2)).CompareTo(vCurrent) >= 0)
            {
                result = tuple.v2;
                vCurrent = vNext;
            }

            if ((vNext = map(tuple.v3)).CompareTo(vCurrent) >= 0)
            {
                result = tuple.v3;
                vCurrent = vNext;
            }

            if ((vNext = map(tuple.v4)).CompareTo(vCurrent) >= 0)
            {
                result = tuple.v4;
                vCurrent = vNext;
            }

            return map(tuple.v5).CompareTo(vCurrent) >= 0 ? tuple.v5 : result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T MaxBy<T, U>(in this (T v1, T v2, T v3, T v4) tuple, Func<T, U> map) where U : IComparable<U>
        {
            var result = tuple.v1;
            U vNext;
            var vCurrent = map(tuple.v1);
            if ((vNext = map(tuple.v2)).CompareTo(vCurrent) >= 0)
            {
                result = tuple.v2;
                vCurrent = vNext;
            }

            if ((vNext = map(tuple.v3)).CompareTo(vCurrent) >= 0)
            {
                result = tuple.v3;
                vCurrent = vNext;
            }

            return map(tuple.v4).CompareTo(vCurrent) >= 0 ? tuple.v4 : result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T MaxBy<T, U>(in this (T v1, T v2, T v3) tuple, Func<T, U> map) where U : IComparable<U>
        {
            var result = tuple.v1;
            U vNext;
            var vCurrent = map(tuple.v1);
            if ((vNext = map(tuple.v2)).CompareTo(vCurrent) >= 0)
            {
                result = tuple.v2;
                vCurrent = vNext;
            }

            return map(tuple.v3).CompareTo(vCurrent) >= 0 ? tuple.v3 : result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T MaxBy<T, U>(in this (T v1, T v2) tuple, Func<T, U> map) where U : IComparable<U>
        {
            return map(tuple.v1).CompareTo(map(tuple.v2)) >= 0 ? tuple.v1 : tuple.v2;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T MaxBy<T, U>(in this (T v1, T v2, T v3, T v4, T v5, T v6, T v7) tuple, Func<T, U> map, IComparer<U>? comparer = default)        
        {
            comparer ??= Comparer<U>.Default;
            var result = tuple.v1;
            U vNext;
            var vCurrent = map(tuple.v1);
            if (comparer.Compare(vNext = map(tuple.v2), vCurrent) >= 0)
            {
                result = tuple.v2;
                vCurrent = vNext;
            }

            if (comparer.Compare(vNext = map(tuple.v3), vCurrent) >= 0)
            {
                result = tuple.v3;
                vCurrent = vNext;
            }

            if (comparer.Compare(vNext = map(tuple.v4), vCurrent) >= 0)
            {
                result = tuple.v4;
                vCurrent = vNext;
            }

            if (comparer.Compare(vNext = map(tuple.v5), vCurrent) >= 0)
            {
                result = tuple.v5;
                vCurrent = vNext;
            }

            if (comparer.Compare(vNext = map(tuple.v6), vCurrent) >= 0)
            {
                result = tuple.v6;
                vCurrent = vNext;
            }

            return comparer.Compare(map(tuple.v7),vCurrent) >= 0 ? tuple.v7 : result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T MaxBy<T, U>(in this (T v1, T v2, T v3, T v4, T v5, T v6) tuple, Func<T, U> map, IComparer<U>? comparer = default)        
        {
            comparer ??= Comparer<U>.Default;
            var result = tuple.v1;
            U vNext;
            var vCurrent = map(tuple.v1);
            if (comparer.Compare(vNext = map(tuple.v2), vCurrent) >= 0)
            {
                result = tuple.v2;
                vCurrent = vNext;
            }

            if (comparer.Compare(vNext = map(tuple.v3), vCurrent) >= 0)
            {
                result = tuple.v3;
                vCurrent = vNext;
            }

            if (comparer.Compare(vNext = map(tuple.v4), vCurrent) >= 0)
            {
                result = tuple.v4;
                vCurrent = vNext;
            }

            if (comparer.Compare(vNext = map(tuple.v5), vCurrent) >= 0)
            {
                result = tuple.v5;
                vCurrent = vNext;
            }

            return comparer.Compare(map(tuple.v6),vCurrent) >= 0 ? tuple.v6 : result;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T MaxBy<T, U>(in this (T v1, T v2, T v3, T v4, T v5) tuple, Func<T, U> map, IComparer<U>? comparer = default)        
        {
            comparer ??= Comparer<U>.Default;
            var result = tuple.v1;
            U vNext;
            var vCurrent = map(tuple.v1);
            if (comparer.Compare(vNext = map(tuple.v2), vCurrent) >= 0)
            {
                result = tuple.v2;
                vCurrent = vNext;
            }

            if (comparer.Compare(vNext = map(tuple.v3), vCurrent) >= 0)
            {
                result = tuple.v3;
                vCurrent = vNext;
            }

            if (comparer.Compare(vNext = map(tuple.v4), vCurrent) >= 0)
            {
                result = tuple.v4;
                vCurrent = vNext;
            }

            return comparer.Compare(map(tuple.v5),vCurrent) >= 0 ? tuple.v5 : result;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T MaxBy<T, U>(in this (T v1, T v2, T v3, T v4) tuple, Func<T, U> map, IComparer<U>? comparer = default)        
        {
            comparer ??= Comparer<U>.Default;
            var result = tuple.v1;
            U vNext;
            var vCurrent = map(tuple.v1);
            if (comparer.Compare(vNext = map(tuple.v2), vCurrent) >= 0)
            {
                result = tuple.v2;
                vCurrent = vNext;
            }

            if (comparer.Compare(vNext = map(tuple.v3), vCurrent) >= 0)
            {
                result = tuple.v3;
                vCurrent = vNext;
            }

            return comparer.Compare(map(tuple.v4),vCurrent) >= 0 ? tuple.v4 : result;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T MaxBy<T, U>(in this (T v1, T v2, T v3) tuple, Func<T, U> map, IComparer<U>? comparer = default)        
        {
            comparer ??= Comparer<U>.Default;
            var result = tuple.v1;
            U vNext;
            var vCurrent = map(tuple.v1);
            if (comparer.Compare(vNext = map(tuple.v2), vCurrent) >= 0)
            {
                result = tuple.v2;
                vCurrent = vNext;
            }

            return comparer.Compare(map(tuple.v3),vCurrent) >= 0 ? tuple.v3 : result;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T MaxBy<T, U>(in this (T v1, T v2) tuple, Func<T, U> map, IComparer<U>? comparer = default)        
        {
            comparer ??= Comparer<U>.Default;
            return comparer.Compare(map(tuple.v1),map(tuple.v2)) >= 0 ? tuple.v1 : tuple.v2;
        }
    }
}
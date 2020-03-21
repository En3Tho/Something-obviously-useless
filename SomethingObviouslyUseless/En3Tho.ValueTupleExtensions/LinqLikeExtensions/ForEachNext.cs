using System;
using System.Runtime.CompilerServices;

namespace En3Tho.ValueTupleExtensions.LinqLikeExtensions
{
    public static partial class MiscellaneousExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (T, T, T, T, T, T, T) ForEachNext<T>(this (T v1, T v2, T v3, T v4, T v5, T v6, T v7) tuple, Action<T> action)
        {
            action(tuple.v1);
            action(tuple.v2);
            action(tuple.v3);
            action(tuple.v4);
            action(tuple.v5);
            action(tuple.v6);
            action(tuple.v7);
            return tuple;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (T, T, T, T, T, T) ForEachNext<T>(this (T v1, T v2, T v3, T v4, T v5, T v6) tuple, Action<T> action)
        {
            action(tuple.v1);
            action(tuple.v2);
            action(tuple.v3);
            action(tuple.v4);
            action(tuple.v5);
            action(tuple.v6);
            return tuple;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (T, T, T, T, T) ForEachNext<T>(this (T v1, T v2, T v3, T v4, T v5) tuple, Action<T> action)
        {
            action(tuple.v1);
            action(tuple.v2);
            action(tuple.v3);
            action(tuple.v4);
            action(tuple.v5);
            return tuple;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (T, T, T, T) ForEachNext<T>(this (T v1, T v2, T v3, T v4) tuple, Action<T> action)
        {
            action(tuple.v1);
            action(tuple.v2);
            action(tuple.v3);
            action(tuple.v4);
            return tuple;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (T, T, T) ForEachNext<T>(this (T v1, T v2, T v3) tuple, Action<T> action)
        {
            action(tuple.v1);
            action(tuple.v2);
            action(tuple.v3);
            return tuple;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (T, T) ForEachNext<T>(this (T v1, T v2) tuple, Action<T> action)
        {
            action(tuple.v1);
            action(tuple.v2);
            return tuple;
        }
    }
}
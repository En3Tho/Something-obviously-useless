using System;
using System.Runtime.CompilerServices;

namespace ExtensionsAndStuff.ValueTupleExtensions
{
    public static partial class MiscellaneousExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T FirstOrDefault<T>(this (T v1, T v2, T v3, T v4, T v5, T v6, T v7) tuple, Func<T, bool> func)
        {
            if (func(tuple.v1)) return tuple.v1;
            if (func(tuple.v1)) return tuple.v2;
            if (func(tuple.v1)) return tuple.v3;
            if (func(tuple.v1)) return tuple.v4;
            if (func(tuple.v1)) return tuple.v5;
            if (func(tuple.v1)) return tuple.v6;
            if (func(tuple.v1)) return tuple.v7;
#pragma warning disable CS8653
            return default;
#pragma warning restore
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T FirstOrDefault<T>(this (T v1, T v2, T v3, T v4, T v5, T v6) tuple, Func<T, bool> func)
        {
            if (func(tuple.v1)) return tuple.v1;
            if (func(tuple.v1)) return tuple.v2;
            if (func(tuple.v1)) return tuple.v3;
            if (func(tuple.v1)) return tuple.v4;
            if (func(tuple.v1)) return tuple.v5;
            if (func(tuple.v1)) return tuple.v6;
#pragma warning disable CS8653
            return default;
#pragma warning restore
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T FirstOrDefault<T>(this (T v1, T v2, T v3, T v4, T v5) tuple, Func<T, bool> func)
        {
            if (func(tuple.v1)) return tuple.v1;
            if (func(tuple.v1)) return tuple.v2;
            if (func(tuple.v1)) return tuple.v3;
            if (func(tuple.v1)) return tuple.v4;
            if (func(tuple.v1)) return tuple.v5;
#pragma warning disable CS8653
            return default;
#pragma warning restore
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T FirstOrDefault<T>(this (T v1, T v2, T v3, T v4) tuple, Func<T, bool> func)
        {
            if (func(tuple.v1)) return tuple.v1;
            if (func(tuple.v1)) return tuple.v2;
            if (func(tuple.v1)) return tuple.v3;
            if (func(tuple.v1)) return tuple.v4;
#pragma warning disable CS8653
            return default;
#pragma warning restore
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T FirstOrDefault<T>(this (T v1, T v2, T v3) tuple, Func<T, bool> func)
        {
            if (func(tuple.v1)) return tuple.v1;
            if (func(tuple.v1)) return tuple.v2;
            if (func(tuple.v1)) return tuple.v3;
#pragma warning disable CS8653
            return default;
#pragma warning restore
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T FirstOrDefault<T>(this (T v1, T v2) tuple, Func<T, bool> func)
        {
            if (func(tuple.v1)) return tuple.v1;
            if (func(tuple.v1)) return tuple.v2;
#pragma warning disable CS8653
            return default;
#pragma warning restore
        }
    }
}

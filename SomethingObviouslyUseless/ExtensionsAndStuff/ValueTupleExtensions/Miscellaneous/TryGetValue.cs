using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace ExtensionsAndStuff.ValueTupleExtensions
{
    public static partial class MiscellaneousExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetValue<T>(this (T v1, T v2, T v3, T v4, T v5, T v6, T v7) tuple, Func<T, bool> func, [MaybeNullWhen(false)] out T value)
        {
            if (func(tuple.v1))
            {
                value = tuple.v1;
                return true;
            }

            if (func(tuple.v2))
            {
                value = tuple.v2;
                return true;
            }

            if (func(tuple.v3))
            {
                value = tuple.v3;
                return true;
            }

            if (func(tuple.v4))
            {
                value = tuple.v4;
                return true;
            }

            if (func(tuple.v5))
            {
                value = tuple.v5;
                return true;
            }

            if (func(tuple.v6))
            {
                value = tuple.v6;
                return true;
            }

            if (func(tuple.v7))
            {
                value = tuple.v7;
                return true;
            }

#pragma warning disable CS8653
            value = default;
#pragma warning restore
            return false;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetValue<T>(this (T v1, T v2, T v3, T v4, T v5, T v6) tuple, Func<T, bool> func, [MaybeNullWhen(false)] out T value)
        {
            if (func(tuple.v1))
            {
                value = tuple.v1;
                return true;
            }

            if (func(tuple.v2))
            {
                value = tuple.v2;
                return true;
            }

            if (func(tuple.v3))
            {
                value = tuple.v3;
                return true;
            }

            if (func(tuple.v4))
            {
                value = tuple.v4;
                return true;
            }

            if (func(tuple.v5))
            {
                value = tuple.v5;
                return true;
            }

            if (func(tuple.v6))
            {
                value = tuple.v6;
                return true;
            }

#pragma warning disable CS8653
            value = default;
#pragma warning restore
            return false;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetValue<T>(this (T v1, T v2, T v3, T v4, T v5) tuple, Func<T, bool> func, [MaybeNullWhen(false)] out T value)
        {
            if (func(tuple.v1))
            {
                value = tuple.v1;
                return true;
            }

            if (func(tuple.v2))
            {
                value = tuple.v2;
                return true;
            }

            if (func(tuple.v3))
            {
                value = tuple.v3;
                return true;
            }

            if (func(tuple.v4))
            {
                value = tuple.v4;
                return true;
            }

            if (func(tuple.v5))
            {
                value = tuple.v5;
                return true;
            }

#pragma warning disable CS8653
            value = default;
#pragma warning restore
            return false;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetValue<T>(this (T v1, T v2, T v3, T v4) tuple, Func<T, bool> func, [MaybeNullWhen(false)] out T value)
        {
            if (func(tuple.v1))
            {
                value = tuple.v1;
                return true;
            }

            if (func(tuple.v2))
            {
                value = tuple.v2;
                return true;
            }

            if (func(tuple.v3))
            {
                value = tuple.v3;
                return true;
            }

            if (func(tuple.v4))
            {
                value = tuple.v4;
                return true;
            }

#pragma warning disable CS8653
            value = default;
#pragma warning restore
            return false;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetValue<T>(this (T v1, T v2, T v3) tuple, Func<T, bool> func, [MaybeNullWhen(false)] out T value)
        {
            if (func(tuple.v1))
            {
                value = tuple.v1;
                return true;
            }

            if (func(tuple.v2))
            {
                value = tuple.v2;
                return true;
            }

            if (func(tuple.v3))
            {
                value = tuple.v3;
                return true;
            }

#pragma warning disable CS8653
            value = default;
#pragma warning restore
            return false;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetValue<T>(this (T v1, T v2) tuple, Func<T, bool> func, [MaybeNullWhen(false)] out T value)
        {
            if (func(tuple.v1))
            {
                value = tuple.v1;
                return true;
            }

            if (func(tuple.v2))
            {
                value = tuple.v2;
                return true;
            }

#pragma warning disable CS8653
            value = default;
#pragma warning restore
            return false;
        }
    }
}

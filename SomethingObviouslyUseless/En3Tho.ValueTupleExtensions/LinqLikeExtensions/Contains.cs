using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace En3Tho.ValueTupleExtensions.LinqLikeExtensions
{
    public static partial class ValueTupleLinqLikeExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool ContainsInternal<T>(ref (T v1, T v2, T v3, T v4, T v5, T v6, T v7) tuple, T value) where T : IEquatable<T>
            => value.Equals(tuple.v1)
            || value.Equals(tuple.v2)
            || value.Equals(tuple.v3)
            || value.Equals(tuple.v4)
            || value.Equals(tuple.v5)
            || value.Equals(tuple.v6)
            || value.Equals(tuple.v7);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool ContainsInternal<T>(ref (T v1, T v2, T v3, T v4, T v5, T v6) tuple, T value) where T : IEquatable<T>
            => value.Equals(tuple.v1)
            || value.Equals(tuple.v2)
            || value.Equals(tuple.v3)
            || value.Equals(tuple.v4)
            || value.Equals(tuple.v5)
            || value.Equals(tuple.v6);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool ContainsInternal<T>(ref (T v1, T v2, T v3, T v4, T v5) tuple, T value) where T : IEquatable<T>
            => value.Equals(tuple.v1)
            || value.Equals(tuple.v2)
            || value.Equals(tuple.v3)
            || value.Equals(tuple.v4)
            || value.Equals(tuple.v5);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool ContainsInternal<T>(ref (T v1, T v2, T v3, T v4) tuple, T value) where T : IEquatable<T>
            => value.Equals(tuple.v1)
            || value.Equals(tuple.v2)
            || value.Equals(tuple.v3)
            || value.Equals(tuple.v4);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool ContainsInternal<T>(ref (T v1, T v2, T v3) tuple, T value) where T : IEquatable<T>
            => value.Equals(tuple.v1)
            || value.Equals(tuple.v2)
            || value.Equals(tuple.v3);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool ContainsInternal<T>(ref (T v1, T v2) tuple, T value) where T : IEquatable<T>
            => value.Equals(tuple.v1)
            || value.Equals(tuple.v2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool ContainsInternal<T>(ref (T v1, T v2, T v3, T v4, T v5, T v6, T v7) tuple, T value, IEqualityComparer<T> comparer)
            => comparer.Equals(value, tuple.v1)
            || comparer.Equals(value, tuple.v2)
            || comparer.Equals(value, tuple.v3)
            || comparer.Equals(value, tuple.v4)
            || comparer.Equals(value, tuple.v5)
            || comparer.Equals(value, tuple.v6)
            || comparer.Equals(value, tuple.v7);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool ContainsInternal<T>(ref (T v1, T v2, T v3, T v4, T v5, T v6) tuple, T value, IEqualityComparer<T> comparer)
            => comparer.Equals(value, tuple.v1)
            || comparer.Equals(value, tuple.v2)
            || comparer.Equals(value, tuple.v3)
            || comparer.Equals(value, tuple.v4)
            || comparer.Equals(value, tuple.v5)
            || comparer.Equals(value, tuple.v6);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool ContainsInternal<T>(ref (T v1, T v2, T v3, T v4, T v5) tuple, T value, IEqualityComparer<T> comparer)
            => comparer.Equals(value, tuple.v1)
            || comparer.Equals(value, tuple.v2)
            || comparer.Equals(value, tuple.v3)
            || comparer.Equals(value, tuple.v4)
            || comparer.Equals(value, tuple.v5);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool ContainsInternal<T>(ref (T v1, T v2, T v3, T v4) tuple, T value, IEqualityComparer<T> comparer)
            => comparer.Equals(value, tuple.v1)
            || comparer.Equals(value, tuple.v2)
            || comparer.Equals(value, tuple.v3)
            || comparer.Equals(value, tuple.v4);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool ContainsInternal<T>(ref (T v1, T v2, T v3) tuple, T value, IEqualityComparer<T> comparer)
            => comparer.Equals(value, tuple.v1)
            || comparer.Equals(value, tuple.v2)
            || comparer.Equals(value, tuple.v3);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool ContainsInternal<T>(ref (T v1, T v2) tuple, T value, IEqualityComparer<T> comparer)
            => comparer.Equals(value, tuple.v1)
            || comparer.Equals(value, tuple.v2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Contains<T>(this (T v1, T v2, T v3, T v4, T v5, T v6, T v7) tuple, T value) where T : IEquatable<T>
            => ContainsInternal(ref tuple, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Contains<T>(this (T v1, T v2, T v3, T v4, T v5, T v6) tuple, T value) where T : IEquatable<T>
            => ContainsInternal(ref tuple, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Contains<T>(this (T v1, T v2, T v3, T v4, T v5) tuple, T value) where T : IEquatable<T>
            => ContainsInternal(ref tuple, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Contains<T>(this (T v1, T v2, T v3, T v4) tuple, T value) where T : IEquatable<T>
            => ContainsInternal(ref tuple, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Contains<T>(this (T v1, T v2, T v3) tuple, T value) where T : IEquatable<T>
            => ContainsInternal(ref tuple, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Contains<T>(this (T v1, T v2) tuple, T value) where T : IEquatable<T>
            => ContainsInternal(ref tuple, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Contains<T>(this (T v1, T v2, T v3, T v4, T v5, T v6, T v7) tuple, T value, IEqualityComparer<T>? comparer = null)
            => ContainsInternal(ref tuple, value, comparer ?? EqualityComparer<T>.Default);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Contains<T>(this (T v1, T v2, T v3, T v4, T v5, T v6) tuple, T value, IEqualityComparer<T>? comparer = null)
            => ContainsInternal(ref tuple, value, comparer ?? EqualityComparer<T>.Default);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Contains<T>(this (T v1, T v2, T v3, T v4, T v5) tuple, T value, IEqualityComparer<T>? comparer = null)
            => ContainsInternal(ref tuple, value, comparer ?? EqualityComparer<T>.Default);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Contains<T>(this (T v1, T v2, T v3, T v4) tuple, T value, IEqualityComparer<T>? comparer = null)
            => ContainsInternal(ref tuple, value, comparer ?? EqualityComparer<T>.Default);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Contains<T>(this (T v1, T v2, T v3) tuple, T value, IEqualityComparer<T>? comparer = null)
            => ContainsInternal(ref tuple, value, comparer ?? EqualityComparer<T>.Default);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Contains<T>(this (T v1, T v2) tuple, T value, IEqualityComparer<T>? comparer = null)
            => ContainsInternal(ref tuple, value, comparer ?? EqualityComparer<T>.Default);
    }
}
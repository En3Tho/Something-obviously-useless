using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace ExtensionsAndStuff.ValueTupleExtensions
{
    public static partial class MiscellaneousExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool ContainsAny<T>(this (T v1, T v2, T v3, T v4, T v5, T v6, T v7) tuple, (T v1, T v2, T v3, T v4, T v5, T v6, T v7) other) where T : IEquatable<T>
            => ContainsInternal(ref tuple, other.v1)
               || ContainsInternal(ref tuple, other.v2)
               || ContainsInternal(ref tuple, other.v3)
               || ContainsInternal(ref tuple, other.v4)
               || ContainsInternal(ref tuple, other.v5)
               || ContainsInternal(ref tuple, other.v6)
               || ContainsInternal(ref tuple, other.v7);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool ContainsAny<T>(this (T v1, T v2, T v3, T v4, T v5, T v6, T v7) tuple, (T v1, T v2, T v3, T v4, T v5, T v6) other) where T : IEquatable<T>
            => ContainsInternal(ref tuple, other.v1)
               || ContainsInternal(ref tuple, other.v2)
               || ContainsInternal(ref tuple, other.v3)
               || ContainsInternal(ref tuple, other.v4)
               || ContainsInternal(ref tuple, other.v5)
               || ContainsInternal(ref tuple, other.v6);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool ContainsAny<T>(this (T v1, T v2, T v3, T v4, T v5, T v6) tuple, (T v1, T v2, T v3, T v4, T v5, T v6, T v7) other) where T : IEquatable<T>
            => ContainsInternal(ref other, tuple.v1)
               || ContainsInternal(ref other, tuple.v2)
               || ContainsInternal(ref other, tuple.v3)
               || ContainsInternal(ref other, tuple.v4)
               || ContainsInternal(ref other, tuple.v5)
               || ContainsInternal(ref other, tuple.v6);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool ContainsAny<T>(this (T v1, T v2, T v3, T v4, T v5, T v6, T v7) tuple, (T v1, T v2, T v3, T v4, T v5) other) where T : IEquatable<T>
            => ContainsInternal(ref tuple, other.v1)
               || ContainsInternal(ref tuple, other.v2)
               || ContainsInternal(ref tuple, other.v3)
               || ContainsInternal(ref tuple, other.v4)
               || ContainsInternal(ref tuple, other.v5);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool ContainsAny<T>(this (T v1, T v2, T v3, T v4, T v5) tuple, (T v1, T v2, T v3, T v4, T v5, T v6, T v7) other) where T : IEquatable<T>
            => ContainsInternal(ref other, tuple.v1)
               || ContainsInternal(ref other, tuple.v2)
               || ContainsInternal(ref other, tuple.v3)
               || ContainsInternal(ref other, tuple.v4)
               || ContainsInternal(ref other, tuple.v5);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool ContainsAny<T>(this (T v1, T v2, T v3, T v4, T v5, T v6, T v7) tuple, (T v1, T v2, T v3, T v4) other) where T : IEquatable<T>
            => ContainsInternal(ref tuple, other.v1)
               || ContainsInternal(ref tuple, other.v2)
               || ContainsInternal(ref tuple, other.v3)
               || ContainsInternal(ref tuple, other.v4);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool ContainsAny<T>(this (T v1, T v2, T v3, T v4) tuple, (T v1, T v2, T v3, T v4, T v5, T v6, T v7) other) where T : IEquatable<T>
            => ContainsInternal(ref other, tuple.v1)
               || ContainsInternal(ref other, tuple.v2)
               || ContainsInternal(ref other, tuple.v3)
               || ContainsInternal(ref other, tuple.v4);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool ContainsAny<T>(this (T v1, T v2, T v3, T v4, T v5, T v6, T v7) tuple, (T v1, T v2, T v3) other) where T : IEquatable<T>
            => ContainsInternal(ref tuple, other.v1)
               || ContainsInternal(ref tuple, other.v2)
               || ContainsInternal(ref tuple, other.v3);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool ContainsAny<T>(this (T v1, T v2, T v3) tuple, (T v1, T v2, T v3, T v4, T v5, T v6, T v7) other) where T : IEquatable<T>
            => ContainsInternal(ref other, tuple.v1)
               || ContainsInternal(ref other, tuple.v2)
               || ContainsInternal(ref other, tuple.v3);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool ContainsAny<T>(this (T v1, T v2, T v3, T v4, T v5, T v6, T v7) tuple, (T v1, T v2) other) where T : IEquatable<T>
            => ContainsInternal(ref tuple, other.v1)
               || ContainsInternal(ref tuple, other.v2);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool ContainsAny<T>(this (T v1, T v2) tuple, (T v1, T v2, T v3, T v4, T v5, T v6, T v7) other) where T : IEquatable<T>
            => ContainsInternal(ref other, tuple.v1)
               || ContainsInternal(ref other, tuple.v2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool ContainsAny<T>(this (T v1, T v2, T v3, T v4, T v5, T v6) tuple, (T v1, T v2, T v3, T v4, T v5, T v6) other) where T : IEquatable<T>
            => ContainsInternal(ref tuple, other.v1)
               || ContainsInternal(ref tuple, other.v2)
               || ContainsInternal(ref tuple, other.v3)
               || ContainsInternal(ref tuple, other.v4)
               || ContainsInternal(ref tuple, other.v5)
               || ContainsInternal(ref tuple, other.v6);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool ContainsAny<T>(this (T v1, T v2, T v3, T v4, T v5, T v6) tuple, (T v1, T v2, T v3, T v4, T v5) other) where T : IEquatable<T>
            => ContainsInternal(ref tuple, other.v1)
               || ContainsInternal(ref tuple, other.v2)
               || ContainsInternal(ref tuple, other.v3)
               || ContainsInternal(ref tuple, other.v4)
               || ContainsInternal(ref tuple, other.v5);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool ContainsAny<T>(this (T v1, T v2, T v3, T v4, T v5) tuple, (T v1, T v2, T v3, T v4, T v5, T v6) other) where T : IEquatable<T>
            => ContainsInternal(ref other, tuple.v1)
               || ContainsInternal(ref other, tuple.v2)
               || ContainsInternal(ref other, tuple.v3)
               || ContainsInternal(ref other, tuple.v4)
               || ContainsInternal(ref other, tuple.v5);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool ContainsAny<T>(this (T v1, T v2, T v3, T v4, T v5, T v6) tuple, (T v1, T v2, T v3, T v4) other) where T : IEquatable<T>
            => ContainsInternal(ref tuple, other.v1)
               || ContainsInternal(ref tuple, other.v2)
               || ContainsInternal(ref tuple, other.v3)
               || ContainsInternal(ref tuple, other.v4);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool ContainsAny<T>(this (T v1, T v2, T v3, T v4) tuple, (T v1, T v2, T v3, T v4, T v5, T v6) other) where T : IEquatable<T>
            => ContainsInternal(ref other, tuple.v1)
               || ContainsInternal(ref other, tuple.v2)
               || ContainsInternal(ref other, tuple.v3)
               || ContainsInternal(ref other, tuple.v4);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool ContainsAny<T>(this (T v1, T v2, T v3, T v4, T v5, T v6) tuple, (T v1, T v2, T v3) other) where T : IEquatable<T>
            => ContainsInternal(ref tuple, other.v1)
               || ContainsInternal(ref tuple, other.v2)
               || ContainsInternal(ref tuple, other.v3);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool ContainsAny<T>(this (T v1, T v2, T v3) tuple, (T v1, T v2, T v3, T v4, T v5, T v6) other) where T : IEquatable<T>
            => ContainsInternal(ref other, tuple.v1)
               || ContainsInternal(ref other, tuple.v2)
               || ContainsInternal(ref other, tuple.v3);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool ContainsAny<T>(this (T v1, T v2, T v3, T v4, T v5, T v6) tuple, (T v1, T v2) other) where T : IEquatable<T>
            => ContainsInternal(ref tuple, other.v1)
               || ContainsInternal(ref tuple, other.v2);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool ContainsAny<T>(this (T v1, T v2) tuple, (T v1, T v2, T v3, T v4, T v5, T v6) other) where T : IEquatable<T>
            => ContainsInternal(ref other, tuple.v1)
               || ContainsInternal(ref other, tuple.v2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool ContainsAny<T>(this (T v1, T v2, T v3, T v4, T v5) tuple, (T v1, T v2, T v3, T v4, T v5) other) where T : IEquatable<T>
            => ContainsInternal(ref tuple, other.v1)
               || ContainsInternal(ref tuple, other.v2)
               || ContainsInternal(ref tuple, other.v3)
               || ContainsInternal(ref tuple, other.v4)
               || ContainsInternal(ref tuple, other.v5);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool ContainsAny<T>(this (T v1, T v2, T v3, T v4, T v5) tuple, (T v1, T v2, T v3, T v4) other) where T : IEquatable<T>
            => ContainsInternal(ref tuple, other.v1)
               || ContainsInternal(ref tuple, other.v2)
               || ContainsInternal(ref tuple, other.v3)
               || ContainsInternal(ref tuple, other.v4);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool ContainsAny<T>(this (T v1, T v2, T v3, T v4) tuple, (T v1, T v2, T v3, T v4, T v5) other) where T : IEquatable<T>
            => ContainsInternal(ref other, tuple.v1)
               || ContainsInternal(ref other, tuple.v2)
               || ContainsInternal(ref other, tuple.v3)
               || ContainsInternal(ref other, tuple.v4);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool ContainsAny<T>(this (T v1, T v2, T v3, T v4, T v5) tuple, (T v1, T v2, T v3) other) where T : IEquatable<T>
            => ContainsInternal(ref tuple, other.v1)
               || ContainsInternal(ref tuple, other.v2)
               || ContainsInternal(ref tuple, other.v3);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool ContainsAny<T>(this (T v1, T v2, T v3) tuple, (T v1, T v2, T v3, T v4, T v5) other) where T : IEquatable<T>
            => ContainsInternal(ref other, tuple.v1)
               || ContainsInternal(ref other, tuple.v2)
               || ContainsInternal(ref other, tuple.v3);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool ContainsAny<T>(this (T v1, T v2, T v3, T v4, T v5) tuple, (T v1, T v2) other) where T : IEquatable<T>
            => ContainsInternal(ref tuple, other.v1)
               || ContainsInternal(ref tuple, other.v2);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool ContainsAny<T>(this (T v1, T v2) tuple, (T v1, T v2, T v3, T v4, T v5) other) where T : IEquatable<T>
            => ContainsInternal(ref other, tuple.v1)
               || ContainsInternal(ref other, tuple.v2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool ContainsAny<T>(this (T v1, T v2, T v3, T v4) tuple, (T v1, T v2, T v3, T v4) other) where T : IEquatable<T>
            => ContainsInternal(ref tuple, other.v1)
               || ContainsInternal(ref tuple, other.v2)
               || ContainsInternal(ref tuple, other.v3)
               || ContainsInternal(ref tuple, other.v4);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool ContainsAny<T>(this (T v1, T v2, T v3, T v4) tuple, (T v1, T v2, T v3) other) where T : IEquatable<T>
            => ContainsInternal(ref tuple, other.v1)
               || ContainsInternal(ref tuple, other.v2)
               || ContainsInternal(ref tuple, other.v3);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool ContainsAny<T>(this (T v1, T v2, T v3) tuple, (T v1, T v2, T v3, T v4) other) where T : IEquatable<T>
            => ContainsInternal(ref other, tuple.v1)
               || ContainsInternal(ref other, tuple.v2)
               || ContainsInternal(ref other, tuple.v3);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool ContainsAny<T>(this (T v1, T v2, T v3, T v4) tuple, (T v1, T v2) other) where T : IEquatable<T>
            => ContainsInternal(ref tuple, other.v1)
               || ContainsInternal(ref tuple, other.v2);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool ContainsAny<T>(this (T v1, T v2) tuple, (T v1, T v2, T v3, T v4) other) where T : IEquatable<T>
            => ContainsInternal(ref other, tuple.v1)
               || ContainsInternal(ref other, tuple.v2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool ContainsAny<T>(this (T v1, T v2, T v3) tuple, (T v1, T v2, T v3) other) where T : IEquatable<T>
            => ContainsInternal(ref tuple, other.v1)
               || ContainsInternal(ref tuple, other.v2)
               || ContainsInternal(ref tuple, other.v3);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool ContainsAny<T>(this (T v1, T v2, T v3) tuple, (T v1, T v2) other) where T : IEquatable<T>
            => ContainsInternal(ref tuple, other.v1)
               || ContainsInternal(ref tuple, other.v2);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool ContainsAny<T>(this (T v1, T v2) tuple, (T v1, T v2, T v3) other) where T : IEquatable<T>
            => ContainsInternal(ref other, tuple.v1)
               || ContainsInternal(ref other, tuple.v2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool ContainsAny<T>(this (T v1, T v2, T v3, T v4, T v5, T v6, T v7) tuple, (T v1, T v2, T v3, T v4, T v5, T v6, T v7) other, IEqualityComparer<T>? comparer = null)
        {
            comparer ??= EqualityComparer<T>.Default;
            return ContainsInternal(ref tuple, other.v1, comparer)
                   || ContainsInternal(ref tuple, other.v2, comparer)
                   || ContainsInternal(ref tuple, other.v3, comparer)
                   || ContainsInternal(ref tuple, other.v4, comparer)
                   || ContainsInternal(ref tuple, other.v5, comparer)
                   || ContainsInternal(ref tuple, other.v6, comparer)
                   || ContainsInternal(ref tuple, other.v7, comparer);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool ContainsAny<T>(this (T v1, T v2, T v3, T v4, T v5, T v6, T v7) tuple, (T v1, T v2, T v3, T v4, T v5, T v6) other, IEqualityComparer<T>? comparer = null)
        {
            comparer ??= EqualityComparer<T>.Default;
            return ContainsInternal(ref tuple, other.v1, comparer)
                   || ContainsInternal(ref tuple, other.v2, comparer)
                   || ContainsInternal(ref tuple, other.v3, comparer)
                   || ContainsInternal(ref tuple, other.v4, comparer)
                   || ContainsInternal(ref tuple, other.v5, comparer)
                   || ContainsInternal(ref tuple, other.v6, comparer);
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool ContainsAny<T>(this (T v1, T v2, T v3, T v4, T v5, T v6) tuple, (T v1, T v2, T v3, T v4, T v5, T v6, T v7) other, IEqualityComparer<T>? comparer = null)
        {
            comparer ??= EqualityComparer<T>.Default;
            return ContainsInternal(ref other, tuple.v1, comparer)
                   || ContainsInternal(ref other, tuple.v2, comparer)
                   || ContainsInternal(ref other, tuple.v3, comparer)
                   || ContainsInternal(ref other, tuple.v4, comparer)
                   || ContainsInternal(ref other, tuple.v5, comparer)
                   || ContainsInternal(ref other, tuple.v6, comparer);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool ContainsAny<T>(this (T v1, T v2, T v3, T v4, T v5, T v6, T v7) tuple, (T v1, T v2, T v3, T v4, T v5) other, IEqualityComparer<T>? comparer = null)
        {
            comparer ??= EqualityComparer<T>.Default;
            return ContainsInternal(ref tuple, other.v1, comparer)
                   || ContainsInternal(ref tuple, other.v2, comparer)
                   || ContainsInternal(ref tuple, other.v3, comparer)
                   || ContainsInternal(ref tuple, other.v4, comparer)
                   || ContainsInternal(ref tuple, other.v5, comparer);
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool ContainsAny<T>(this (T v1, T v2, T v3, T v4, T v5) tuple, (T v1, T v2, T v3, T v4, T v5, T v6, T v7) other, IEqualityComparer<T>? comparer = null)
        {
            comparer ??= EqualityComparer<T>.Default;
            return ContainsInternal(ref other, tuple.v1, comparer)
                   || ContainsInternal(ref other, tuple.v2, comparer)
                   || ContainsInternal(ref other, tuple.v3, comparer)
                   || ContainsInternal(ref other, tuple.v4, comparer)
                   || ContainsInternal(ref other, tuple.v5, comparer);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool ContainsAny<T>(this (T v1, T v2, T v3, T v4, T v5, T v6, T v7) tuple, (T v1, T v2, T v3, T v4) other, IEqualityComparer<T>? comparer = null)
        {
            comparer ??= EqualityComparer<T>.Default;
            return ContainsInternal(ref tuple, other.v1, comparer)
                   || ContainsInternal(ref tuple, other.v2, comparer)
                   || ContainsInternal(ref tuple, other.v3, comparer)
                   || ContainsInternal(ref tuple, other.v4, comparer);
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool ContainsAny<T>(this (T v1, T v2, T v3, T v4) tuple, (T v1, T v2, T v3, T v4, T v5, T v6, T v7) other, IEqualityComparer<T>? comparer = null)
        {
            comparer ??= EqualityComparer<T>.Default;
            return ContainsInternal(ref other, tuple.v1, comparer)
                   || ContainsInternal(ref other, tuple.v2, comparer)
                   || ContainsInternal(ref other, tuple.v3, comparer)
                   || ContainsInternal(ref other, tuple.v4, comparer);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool ContainsAny<T>(this (T v1, T v2, T v3, T v4, T v5, T v6, T v7) tuple, (T v1, T v2, T v3) other, IEqualityComparer<T>? comparer = null)
        {
            comparer ??= EqualityComparer<T>.Default;
            return ContainsInternal(ref tuple, other.v1, comparer)
                   || ContainsInternal(ref tuple, other.v2, comparer)
                   || ContainsInternal(ref tuple, other.v3, comparer);
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool ContainsAny<T>(this (T v1, T v2, T v3) tuple, (T v1, T v2, T v3, T v4, T v5, T v6, T v7) other, IEqualityComparer<T>? comparer = null)
        {
            comparer ??= EqualityComparer<T>.Default;
            return ContainsInternal(ref other, tuple.v1, comparer)
                   || ContainsInternal(ref other, tuple.v2, comparer)
                   || ContainsInternal(ref other, tuple.v3, comparer);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool ContainsAny<T>(this (T v1, T v2, T v3, T v4, T v5, T v6, T v7) tuple, (T v1, T v2) other, IEqualityComparer<T>? comparer = null)
        {
            comparer ??= EqualityComparer<T>.Default;
            return ContainsInternal(ref tuple, other.v1, comparer)
                   || ContainsInternal(ref tuple, other.v2, comparer);
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool ContainsAny<T>(this (T v1, T v2) tuple, (T v1, T v2, T v3, T v4, T v5, T v6, T v7) other, IEqualityComparer<T>? comparer = null)
        {
            comparer ??= EqualityComparer<T>.Default;
            return ContainsInternal(ref other, tuple.v1, comparer)
                   || ContainsInternal(ref other, tuple.v2, comparer);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool ContainsAny<T>(this (T v1, T v2, T v3, T v4, T v5, T v6) tuple, (T v1, T v2, T v3, T v4, T v5, T v6) other, IEqualityComparer<T>? comparer = null)
        {
            comparer ??= EqualityComparer<T>.Default;
            return ContainsInternal(ref tuple, other.v1, comparer)
                   || ContainsInternal(ref tuple, other.v2, comparer)
                   || ContainsInternal(ref tuple, other.v3, comparer)
                   || ContainsInternal(ref tuple, other.v4, comparer)
                   || ContainsInternal(ref tuple, other.v5, comparer)
                   || ContainsInternal(ref tuple, other.v6, comparer);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool ContainsAny<T>(this (T v1, T v2, T v3, T v4, T v5, T v6) tuple, (T v1, T v2, T v3, T v4, T v5) other, IEqualityComparer<T>? comparer = null)
        {
            comparer ??= EqualityComparer<T>.Default;
            return ContainsInternal(ref tuple, other.v1, comparer)
                   || ContainsInternal(ref tuple, other.v2, comparer)
                   || ContainsInternal(ref tuple, other.v3, comparer)
                   || ContainsInternal(ref tuple, other.v4, comparer)
                   || ContainsInternal(ref tuple, other.v5, comparer);
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool ContainsAny<T>(this (T v1, T v2, T v3, T v4, T v5) tuple, (T v1, T v2, T v3, T v4, T v5, T v6) other, IEqualityComparer<T>? comparer = null)
        {
            comparer ??= EqualityComparer<T>.Default;
            return ContainsInternal(ref other, tuple.v1, comparer)
                   || ContainsInternal(ref other, tuple.v2, comparer)
                   || ContainsInternal(ref other, tuple.v3, comparer)
                   || ContainsInternal(ref other, tuple.v4, comparer)
                   || ContainsInternal(ref other, tuple.v5, comparer);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool ContainsAny<T>(this (T v1, T v2, T v3, T v4, T v5, T v6) tuple, (T v1, T v2, T v3, T v4) other, IEqualityComparer<T>? comparer = null)
        {
            comparer ??= EqualityComparer<T>.Default;
            return ContainsInternal(ref tuple, other.v1, comparer)
                   || ContainsInternal(ref tuple, other.v2, comparer)
                   || ContainsInternal(ref tuple, other.v3, comparer)
                   || ContainsInternal(ref tuple, other.v4, comparer);
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool ContainsAny<T>(this (T v1, T v2, T v3, T v4) tuple, (T v1, T v2, T v3, T v4, T v5, T v6) other, IEqualityComparer<T>? comparer = null)
        {
            comparer ??= EqualityComparer<T>.Default;
            return ContainsInternal(ref other, tuple.v1, comparer)
                   || ContainsInternal(ref other, tuple.v2, comparer)
                   || ContainsInternal(ref other, tuple.v3, comparer)
                   || ContainsInternal(ref other, tuple.v4, comparer);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool ContainsAny<T>(this (T v1, T v2, T v3, T v4, T v5, T v6) tuple, (T v1, T v2, T v3) other, IEqualityComparer<T>? comparer = null)
        {
            comparer ??= EqualityComparer<T>.Default;
            return ContainsInternal(ref tuple, other.v1, comparer)
                   || ContainsInternal(ref tuple, other.v2, comparer)
                   || ContainsInternal(ref tuple, other.v3, comparer);
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool ContainsAny<T>(this (T v1, T v2, T v3) tuple, (T v1, T v2, T v3, T v4, T v5, T v6) other, IEqualityComparer<T>? comparer = null)
        {
            comparer ??= EqualityComparer<T>.Default;
            return ContainsInternal(ref other, tuple.v1, comparer)
                   || ContainsInternal(ref other, tuple.v2, comparer)
                   || ContainsInternal(ref other, tuple.v3, comparer);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool ContainsAny<T>(this (T v1, T v2, T v3, T v4, T v5, T v6) tuple, (T v1, T v2) other, IEqualityComparer<T>? comparer = null)
        {
            comparer ??= EqualityComparer<T>.Default;
            return ContainsInternal(ref tuple, other.v1, comparer)
                   || ContainsInternal(ref tuple, other.v2, comparer);
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool ContainsAny<T>(this (T v1, T v2) tuple, (T v1, T v2, T v3, T v4, T v5, T v6) other, IEqualityComparer<T>? comparer = null)
        {
            comparer ??= EqualityComparer<T>.Default;
            return ContainsInternal(ref other, tuple.v1, comparer)
                   || ContainsInternal(ref other, tuple.v2, comparer);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool ContainsAny<T>(this (T v1, T v2, T v3, T v4, T v5) tuple, (T v1, T v2, T v3, T v4, T v5) other, IEqualityComparer<T>? comparer = null)
        {
            comparer ??= EqualityComparer<T>.Default;
            return ContainsInternal(ref tuple, other.v1, comparer)
                   || ContainsInternal(ref tuple, other.v2, comparer)
                   || ContainsInternal(ref tuple, other.v3, comparer)
                   || ContainsInternal(ref tuple, other.v4, comparer)
                   || ContainsInternal(ref tuple, other.v5, comparer);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool ContainsAny<T>(this (T v1, T v2, T v3, T v4, T v5) tuple, (T v1, T v2, T v3, T v4) other, IEqualityComparer<T>? comparer = null)
        {
            comparer ??= EqualityComparer<T>.Default;
            return ContainsInternal(ref tuple, other.v1, comparer)
                   || ContainsInternal(ref tuple, other.v2, comparer)
                   || ContainsInternal(ref tuple, other.v3, comparer)
                   || ContainsInternal(ref tuple, other.v4, comparer);
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool ContainsAny<T>(this (T v1, T v2, T v3, T v4) tuple, (T v1, T v2, T v3, T v4, T v5) other, IEqualityComparer<T>? comparer = null)
        {
            comparer ??= EqualityComparer<T>.Default;
            return ContainsInternal(ref other, tuple.v1, comparer)
                   || ContainsInternal(ref other, tuple.v2, comparer)
                   || ContainsInternal(ref other, tuple.v3, comparer)
                   || ContainsInternal(ref other, tuple.v4, comparer);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool ContainsAny<T>(this (T v1, T v2, T v3, T v4, T v5) tuple, (T v1, T v2, T v3) other, IEqualityComparer<T>? comparer = null)
        {
            comparer ??= EqualityComparer<T>.Default;
            return ContainsInternal(ref tuple, other.v1, comparer)
                   || ContainsInternal(ref tuple, other.v2, comparer)
                   || ContainsInternal(ref tuple, other.v3, comparer);
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool ContainsAny<T>(this (T v1, T v2, T v3) tuple, (T v1, T v2, T v3, T v4, T v5) other, IEqualityComparer<T>? comparer = null)
        {
            comparer ??= EqualityComparer<T>.Default;
            return ContainsInternal(ref other, tuple.v1, comparer)
                   || ContainsInternal(ref other, tuple.v2, comparer)
                   || ContainsInternal(ref other, tuple.v3, comparer);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool ContainsAny<T>(this (T v1, T v2, T v3, T v4, T v5) tuple, (T v1, T v2) other, IEqualityComparer<T>? comparer = null)
        {
            comparer ??= EqualityComparer<T>.Default;
            return ContainsInternal(ref tuple, other.v1, comparer)
                   || ContainsInternal(ref tuple, other.v2, comparer);
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool ContainsAny<T>(this (T v1, T v2) tuple, (T v1, T v2, T v3, T v4, T v5) other, IEqualityComparer<T>? comparer = null)
        {
            comparer ??= EqualityComparer<T>.Default;
            return ContainsInternal(ref other, tuple.v1, comparer)
                   || ContainsInternal(ref other, tuple.v2, comparer);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool ContainsAny<T>(this (T v1, T v2, T v3, T v4) tuple, (T v1, T v2, T v3, T v4) other, IEqualityComparer<T>? comparer = null)
        {
            comparer ??= EqualityComparer<T>.Default;
            return ContainsInternal(ref tuple, other.v1, comparer)
                   || ContainsInternal(ref tuple, other.v2, comparer)
                   || ContainsInternal(ref tuple, other.v3, comparer)
                   || ContainsInternal(ref tuple, other.v4, comparer);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool ContainsAny<T>(this (T v1, T v2, T v3, T v4) tuple, (T v1, T v2, T v3) other, IEqualityComparer<T>? comparer = null)
        {
            comparer ??= EqualityComparer<T>.Default;
            return ContainsInternal(ref tuple, other.v1, comparer)
                   || ContainsInternal(ref tuple, other.v2, comparer)
                   || ContainsInternal(ref tuple, other.v3, comparer);
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool ContainsAny<T>(this (T v1, T v2, T v3) tuple, (T v1, T v2, T v3, T v4) other, IEqualityComparer<T>? comparer = null)
        {
            comparer ??= EqualityComparer<T>.Default;
            return ContainsInternal(ref other, tuple.v1, comparer)
                   || ContainsInternal(ref other, tuple.v2, comparer)
                   || ContainsInternal(ref other, tuple.v3, comparer);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool ContainsAny<T>(this (T v1, T v2, T v3, T v4) tuple, (T v1, T v2) other, IEqualityComparer<T>? comparer = null)
        {
            comparer ??= EqualityComparer<T>.Default;
            return ContainsInternal(ref tuple, other.v1, comparer)
                   || ContainsInternal(ref tuple, other.v2, comparer);
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool ContainsAny<T>(this (T v1, T v2) tuple, (T v1, T v2, T v3, T v4) other, IEqualityComparer<T>? comparer = null)
        {
            comparer ??= EqualityComparer<T>.Default;
            return ContainsInternal(ref other, tuple.v1, comparer)
                   || ContainsInternal(ref other, tuple.v2, comparer);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool ContainsAny<T>(this (T v1, T v2, T v3) tuple, (T v1, T v2, T v3) other, IEqualityComparer<T>? comparer = null)
        {
            comparer ??= EqualityComparer<T>.Default;
            return ContainsInternal(ref tuple, other.v1, comparer)
                   || ContainsInternal(ref tuple, other.v2, comparer)
                   || ContainsInternal(ref tuple, other.v3, comparer);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool ContainsAny<T>(this (T v1, T v2, T v3) tuple, (T v1, T v2) other, IEqualityComparer<T>? comparer = null)
        {
            comparer ??= EqualityComparer<T>.Default;
            return ContainsInternal(ref tuple, other.v1, comparer)
                   || ContainsInternal(ref tuple, other.v2, comparer);
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool ContainsAny<T>(this (T v1, T v2) tuple, (T v1, T v2, T v3) other, IEqualityComparer<T>? comparer = null)
        {
            comparer ??= EqualityComparer<T>.Default;
            return ContainsInternal(ref other, tuple.v1, comparer)
                   || ContainsInternal(ref other, tuple.v2, comparer);
        }
    }
}

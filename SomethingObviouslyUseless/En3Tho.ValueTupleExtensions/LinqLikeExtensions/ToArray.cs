using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace En3Tho.ValueTupleExtensions.LinqLikeExtensions
{
    public static partial class ValueTupleLinqLikeExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T[] ToArray<T>(this (ICollection<T> v1, ICollection<T> v2, ICollection<T> v3, ICollection<T> v4, ICollection<T> v5, ICollection<T> v6, ICollection<T> v7) tuple)
        {
            var count = tuple.v1.Count + tuple.v2.Count + tuple.v3.Count + tuple.v4.Count + tuple.v5.Count + tuple.v6.Count + tuple.v7.Count;
            if (count == 0) return Array.Empty<T>();
            var result = new T[count];
            count = 0;
            tuple.v1.CopyTo(result, count);
            count += tuple.v1.Count;
            tuple.v2.CopyTo(result, count);
            count += tuple.v2.Count;
            tuple.v3.CopyTo(result, count);
            count += tuple.v3.Count;
            tuple.v4.CopyTo(result, count);
            count += tuple.v4.Count;
            tuple.v5.CopyTo(result, count);
            count += tuple.v5.Count;
            tuple.v6.CopyTo(result, count);
            count += tuple.v6.Count;
            tuple.v7.CopyTo(result, count);
            return result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T[] ToArray<T>(this (ICollection<T> v1, ICollection<T> v2, ICollection<T> v3, ICollection<T> v4, ICollection<T> v5, ICollection<T> v6) tuple)
        {
            var count = tuple.v1.Count + tuple.v2.Count + tuple.v3.Count + tuple.v4.Count + tuple.v5.Count + tuple.v6.Count;
            if (count == 0) return Array.Empty<T>();
            var result = new T[count];
            count = 0;
            tuple.v1.CopyTo(result, count);
            count += tuple.v1.Count;
            tuple.v2.CopyTo(result, count);
            count += tuple.v2.Count;
            tuple.v3.CopyTo(result, count);
            count += tuple.v3.Count;
            tuple.v4.CopyTo(result, count);
            count += tuple.v4.Count;
            tuple.v5.CopyTo(result, count);
            count += tuple.v5.Count;
            tuple.v6.CopyTo(result, count);
            return result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T[] ToArray<T>(this (ICollection<T> v1, ICollection<T> v2, ICollection<T> v3, ICollection<T> v4, ICollection<T> v5) tuple)
        {
            var count = tuple.v1.Count + tuple.v2.Count + tuple.v3.Count + tuple.v4.Count + tuple.v5.Count;
            if (count == 0) return Array.Empty<T>();
            var result = new T[count];
            count = 0;
            tuple.v1.CopyTo(result, 0);
            count += tuple.v1.Count;
            tuple.v2.CopyTo(result, count);
            count += tuple.v2.Count;
            tuple.v3.CopyTo(result, count);
            count += tuple.v3.Count;
            tuple.v4.CopyTo(result, count);
            count += tuple.v4.Count;
            tuple.v5.CopyTo(result, count);
            return result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T[] ToArray<T>(this (ICollection<T> v1, ICollection<T> v2, ICollection<T> v3, ICollection<T> v4) tuple)
        {
            var count = tuple.v1.Count + tuple.v2.Count + tuple.v3.Count + tuple.v4.Count;
            if (count == 0) return Array.Empty<T>();
            var result = new T[count];
            count = 0;
            tuple.v1.CopyTo(result, count);
            count += tuple.v1.Count;
            tuple.v2.CopyTo(result, count);
            count += tuple.v2.Count;
            tuple.v3.CopyTo(result, count);
            count += tuple.v3.Count;
            tuple.v4.CopyTo(result, count);
            return result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T[] ToArray<T>(this (ICollection<T> v1, ICollection<T> v2, ICollection<T> v3) tuple)
        {
            var count = tuple.v1.Count + tuple.v2.Count + tuple.v3.Count;
            if (count == 0) return Array.Empty<T>();
            var result = new T[count];

            count = 0;
            tuple.v1.CopyTo(result, count);
            count += tuple.v1.Count;
            tuple.v2.CopyTo(result, count);
            count += tuple.v2.Count;
            tuple.v3.CopyTo(result, count);
            return result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T[] ToArray<T>(this (ICollection<T> v1, ICollection<T> v2) tuple)
        {
            var count = tuple.v1.Count + tuple.v2.Count;
            if (count == 0) return Array.Empty<T>();
            var result = new T[count];

            tuple.v1.CopyTo(result, 0);
            tuple.v2.CopyTo(result, tuple.v1.Count);
            return result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T[] ToArray<T>(this (T[] v1, T[] v2, T[] v3, T[] v4, T[] v5, T[] v6, T[] v7) tuple)
        {
            var length = tuple.v1.Length + tuple.v2.Length + tuple.v3.Length + tuple.v4.Length + tuple.v5.Length + tuple.v6.Length + tuple.v7.Length;
            if (length == 0) return Array.Empty<T>();
            var result = new T[length];

            length = 0;
            Array.Copy(tuple.v1, 0, result, 0, tuple.v1.Length);
            length += tuple.v1.Length;
            Array.Copy(tuple.v2, 0, result, length, tuple.v2.Length);
            length += tuple.v2.Length;
            Array.Copy(tuple.v3, 0, result, length, tuple.v3.Length);
            length += tuple.v3.Length;
            Array.Copy(tuple.v4, 0, result, length, tuple.v4.Length);
            length += tuple.v4.Length;
            Array.Copy(tuple.v5, 0, result, length, tuple.v5.Length);
            length += tuple.v5.Length;
            Array.Copy(tuple.v6, 0, result, length, tuple.v6.Length);
            length += tuple.v6.Length;
            Array.Copy(tuple.v7, 0, result, length, tuple.v7.Length);
            return result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T[] ToArray<T>(this (T[] v1, T[] v2, T[] v3, T[] v4, T[] v5, T[] v6) tuple)
        {
            var length = tuple.v1.Length + tuple.v2.Length + tuple.v3.Length + tuple.v4.Length + tuple.v5.Length + tuple.v6.Length;
            if (length == 0) return Array.Empty<T>();
            var result = new T[length];

            length = 0;
            Array.Copy(tuple.v1, 0, result, 0, tuple.v1.Length);
            length += tuple.v1.Length;
            Array.Copy(tuple.v2, 0, result, length, tuple.v2.Length);
            length += tuple.v2.Length;
            Array.Copy(tuple.v3, 0, result, length, tuple.v3.Length);
            length += tuple.v3.Length;
            Array.Copy(tuple.v4, 0, result, length, tuple.v4.Length);
            length += tuple.v4.Length;
            Array.Copy(tuple.v5, 0, result, length, tuple.v5.Length);
            length += tuple.v5.Length;
            Array.Copy(tuple.v6, 0, result, length, tuple.v6.Length);
            return result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T[] ToArray<T>(this (T[] v1, T[] v2, T[] v3, T[] v4, T[] v5) tuple)
        {
            var length = tuple.v1.Length + tuple.v2.Length + tuple.v3.Length + tuple.v4.Length + tuple.v5.Length;
            if (length == 0) return Array.Empty<T>();
            var result = new T[length];

            length = 0;
            Array.Copy(tuple.v1, 0, result, 0, tuple.v1.Length);
            length += tuple.v1.Length;
            Array.Copy(tuple.v2, 0, result, length, tuple.v2.Length);
            length += tuple.v2.Length;
            Array.Copy(tuple.v3, 0, result, length, tuple.v3.Length);
            length += tuple.v3.Length;
            Array.Copy(tuple.v4, 0, result, length, tuple.v4.Length);
            length += tuple.v4.Length;
            Array.Copy(tuple.v5, 0, result, length, tuple.v5.Length);
            return result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T[] ToArray<T>(this (T[] v1, T[] v2, T[] v3, T[] v4) tuple)
        {
            var length = tuple.v1.Length + tuple.v2.Length + tuple.v3.Length + tuple.v4.Length;
            if (length == 0) return Array.Empty<T>();
            var result = new T[length];

            length = 0;
            Array.Copy(tuple.v1, 0, result, 0, tuple.v1.Length);
            length += tuple.v1.Length;
            Array.Copy(tuple.v2, 0, result, length, tuple.v2.Length);
            length += tuple.v2.Length;
            Array.Copy(tuple.v3, 0, result, length, tuple.v3.Length);
            length += tuple.v3.Length;
            Array.Copy(tuple.v4, 0, result, length, tuple.v4.Length);
            return result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T[] ToArray<T>(this (T[] v1, T[] v2, T[] v3) tuple)
        {
            var length = tuple.v1.Length + tuple.v2.Length + tuple.v3.Length;
            if (length == 0) return Array.Empty<T>();
            var result = new T[length];

            length = 0;
            Array.Copy(tuple.v1, 0, result, 0, tuple.v1.Length);
            length += tuple.v1.Length;
            Array.Copy(tuple.v2, 0, result, length, tuple.v2.Length);
            length += tuple.v2.Length;
            Array.Copy(tuple.v3, 0, result, length, tuple.v3.Length);
            return result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T[] ToArray<T>(this (T[] v1, T[] v2) tuple)
        {
            var length = tuple.v1.Length + tuple.v2.Length;
            if (length == 0) return Array.Empty<T>();
            var result = new T[length];

            Array.Copy(tuple.v1, 0, result, 0, tuple.v1.Length);
            Array.Copy(tuple.v2, 0, result, tuple.v1.Length, tuple.v2.Length);
            return result;
        }
    }
}
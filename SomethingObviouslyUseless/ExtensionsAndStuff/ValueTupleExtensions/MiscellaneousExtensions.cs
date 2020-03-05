using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Intrinsics;
using ExtensionsAndStuff.HelperClasses;

namespace ExtensionsAndStuff.ValueTupleExtensions
{
    public static class MiscellaneousExtensions
    {
        #region Should

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (T, T, T, T, T, T, T) Should<T>(this (T v1, T v2, T v3, T v4, T v5, T v6, T v7) tuple, Func<T, bool> func)
        {
            if (!func(tuple.v1)) ValueTupleValidationException.Throw(nameof(tuple.v1));
            if (!func(tuple.v2)) ValueTupleValidationException.Throw(nameof(tuple.v2));
            if (!func(tuple.v3)) ValueTupleValidationException.Throw(nameof(tuple.v3));
            if (!func(tuple.v4)) ValueTupleValidationException.Throw(nameof(tuple.v4));
            if (!func(tuple.v5)) ValueTupleValidationException.Throw(nameof(tuple.v5));
            if (!func(tuple.v6)) ValueTupleValidationException.Throw(nameof(tuple.v6));
            if (!func(tuple.v7)) ValueTupleValidationException.Throw(nameof(tuple.v7));
            return tuple;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (T, T, T, T, T, T) Should<T>(this (T v1, T v2, T v3, T v4, T v5, T v6) tuple, Func<T, bool> func)
        {
            if (!func(tuple.v1)) ValueTupleValidationException.Throw(nameof(tuple.v1));
            if (!func(tuple.v2)) ValueTupleValidationException.Throw(nameof(tuple.v2));
            if (!func(tuple.v3)) ValueTupleValidationException.Throw(nameof(tuple.v3));
            if (!func(tuple.v4)) ValueTupleValidationException.Throw(nameof(tuple.v4));
            if (!func(tuple.v5)) ValueTupleValidationException.Throw(nameof(tuple.v5));
            if (!func(tuple.v6)) ValueTupleValidationException.Throw(nameof(tuple.v6));
            return tuple;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (T, T, T, T, T) Should<T>(this (T v1, T v2, T v3, T v4, T v5) tuple, Func<T, bool> func)
        {
            if (func(tuple.v1)) ValueTupleValidationException.Throw(nameof(tuple.v1));
            if (func(tuple.v2)) ValueTupleValidationException.Throw(nameof(tuple.v2));
            if (func(tuple.v3)) ValueTupleValidationException.Throw(nameof(tuple.v3));
            if (func(tuple.v4)) ValueTupleValidationException.Throw(nameof(tuple.v4));
            if (func(tuple.v5)) ValueTupleValidationException.Throw(nameof(tuple.v5));
            return tuple;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (T, T, T, T) Should<T>(this (T v1, T v2, T v3, T v4) tuple, Func<T, bool> func)
        {
            if (func(tuple.v1)) ValueTupleValidationException.Throw(nameof(tuple.v1));
            if (func(tuple.v2)) ValueTupleValidationException.Throw(nameof(tuple.v2));
            if (func(tuple.v3)) ValueTupleValidationException.Throw(nameof(tuple.v3));
            if (func(tuple.v4)) ValueTupleValidationException.Throw(nameof(tuple.v4));
            return tuple;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (T, T, T) Should<T>(this (T v1, T v2, T v3) tuple, Func<T, bool> func)
        {
            if (func(tuple.v1)) ValueTupleValidationException.Throw(nameof(tuple.v1));
            if (func(tuple.v2)) ValueTupleValidationException.Throw(nameof(tuple.v2));
            if (func(tuple.v3)) ValueTupleValidationException.Throw(nameof(tuple.v3));
            return tuple;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (T, T) Should<T>(this (T v1, T v2) tuple, Func<T, bool> func)
        {
            if (func(tuple.v1)) ValueTupleValidationException.Throw(nameof(tuple.v1));
            if (func(tuple.v2)) ValueTupleValidationException.Throw(nameof(tuple.v2));
            return tuple;
        }

        #endregion

        #region ShouldNot

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (T, T, T, T, T, T, T) ShouldNot<T>(this (T v1, T v2, T v3, T v4, T v5, T v6, T v7) tuple, Func<T, bool> func)
        {
            if (func(tuple.v1)) ValueTupleValidationException.Throw(nameof(tuple.v1));
            if (func(tuple.v2)) ValueTupleValidationException.Throw(nameof(tuple.v2));
            if (func(tuple.v3)) ValueTupleValidationException.Throw(nameof(tuple.v3));
            if (func(tuple.v4)) ValueTupleValidationException.Throw(nameof(tuple.v4));
            if (func(tuple.v5)) ValueTupleValidationException.Throw(nameof(tuple.v5));
            if (func(tuple.v6)) ValueTupleValidationException.Throw(nameof(tuple.v6));
            if (func(tuple.v7)) ValueTupleValidationException.Throw(nameof(tuple.v7));
            return tuple;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (T, T, T, T, T, T) ShouldNot<T>(this (T v1, T v2, T v3, T v4, T v5, T v6) tuple, Func<T, bool> func)
        {
            if (func(tuple.v1)) ValueTupleValidationException.Throw(nameof(tuple.v1));
            if (func(tuple.v2)) ValueTupleValidationException.Throw(nameof(tuple.v2));
            if (func(tuple.v3)) ValueTupleValidationException.Throw(nameof(tuple.v3));
            if (func(tuple.v4)) ValueTupleValidationException.Throw(nameof(tuple.v4));
            if (func(tuple.v5)) ValueTupleValidationException.Throw(nameof(tuple.v5));
            if (func(tuple.v6)) ValueTupleValidationException.Throw(nameof(tuple.v6));
            return tuple;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (T, T, T, T, T) ShouldNot<T>(this (T v1, T v2, T v3, T v4, T v5) tuple, Func<T, bool> func)
        {
            if (func(tuple.v1)) ValueTupleValidationException.Throw(nameof(tuple.v1));
            if (func(tuple.v2)) ValueTupleValidationException.Throw(nameof(tuple.v2));
            if (func(tuple.v3)) ValueTupleValidationException.Throw(nameof(tuple.v3));
            if (func(tuple.v4)) ValueTupleValidationException.Throw(nameof(tuple.v4));
            if (func(tuple.v5)) ValueTupleValidationException.Throw(nameof(tuple.v5));
            return tuple;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (T, T, T, T) ShouldNot<T>(this (T v1, T v2, T v3, T v4) tuple, Func<T, bool> func)
        {
            if (func(tuple.v1)) ValueTupleValidationException.Throw(nameof(tuple.v1));
            if (func(tuple.v2)) ValueTupleValidationException.Throw(nameof(tuple.v2));
            if (func(tuple.v3)) ValueTupleValidationException.Throw(nameof(tuple.v3));
            if (func(tuple.v4)) ValueTupleValidationException.Throw(nameof(tuple.v4));
            return tuple;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (T, T, T) ShouldNot<T>(this (T v1, T v2, T v3) tuple, Func<T, bool> func)
        {
            if (func(tuple.v1)) ValueTupleValidationException.Throw(nameof(tuple.v1));
            if (func(tuple.v2)) ValueTupleValidationException.Throw(nameof(tuple.v2));
            if (func(tuple.v3)) ValueTupleValidationException.Throw(nameof(tuple.v3));
            return tuple;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (T, T) ShouldNot<T>(this (T v1, T v2) tuple, Func<T, bool> func)
        {
            if (func(tuple.v1)) ValueTupleValidationException.Throw(nameof(tuple.v1));
            if (func(tuple.v2)) ValueTupleValidationException.Throw(nameof(tuple.v2));
            return tuple;
        }

        #endregion

        #region Contains

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Contains<T>(this (T v1, T v2, T v3, T v4, T v5, T v6, T v7) tuple, T value) where T : IEquatable<T>
            => value.Equals(tuple.v1)
               || value.Equals(tuple.v2)
               || value.Equals(tuple.v3)
               || value.Equals(tuple.v4)
               || value.Equals(tuple.v5)
               || value.Equals(tuple.v6)
               || value.Equals(tuple.v7);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Contains<T>(this (T v1, T v2, T v3, T v4, T v5, T v6) tuple, T value) where T : IEquatable<T>
            => value.Equals(tuple.v1)
               || value.Equals(tuple.v2)
               || value.Equals(tuple.v3)
               || value.Equals(tuple.v4)
               || value.Equals(tuple.v5)
               || value.Equals(tuple.v6);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Contains<T>(this (T v1, T v2, T v3, T v4, T v5) tuple, T value) where T : IEquatable<T>
            => value.Equals(tuple.v1)
               || value.Equals(tuple.v2)
               || value.Equals(tuple.v3)
               || value.Equals(tuple.v4)
               || value.Equals(tuple.v5);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Contains<T>(this (T v1, T v2, T v3, T v4) tuple, T value) where T : IEquatable<T>
            => value.Equals(tuple.v1)
               || value.Equals(tuple.v2)
               || value.Equals(tuple.v3)
               || value.Equals(tuple.v4);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Contains<T>(this (T v1, T v2, T v3) tuple, T value) where T : IEquatable<T>
            => value.Equals(tuple.v1)
               || value.Equals(tuple.v2)
               || value.Equals(tuple.v3);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Contains<T>(this (T v1, T v2) tuple, T value) where T : IEquatable<T>
            => value.Equals(tuple.v1)
               || value.Equals(tuple.v2);

        #endregion

        #region ForEach

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ForEach<T>(this (T v1, T v2, T v3, T v4, T v5, T v6, T v7) tuple, Action<T> action)
        {
            action(tuple.v1);
            action(tuple.v2);
            action(tuple.v3);
            action(tuple.v4);
            action(tuple.v5);
            action(tuple.v6);
            action(tuple.v7);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ForEach<T>(this (T v1, T v2, T v3, T v4, T v5, T v6) tuple, Action<T> action)
        {
            action(tuple.v1);
            action(tuple.v2);
            action(tuple.v3);
            action(tuple.v4);
            action(tuple.v5);
            action(tuple.v6);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ForEach<T>(this (T v1, T v2, T v3, T v4, T v5) tuple, Action<T> action)
        {
            action(tuple.v1);
            action(tuple.v2);
            action(tuple.v3);
            action(tuple.v4);
            action(tuple.v5);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ForEach<T>(this (T v1, T v2, T v3, T v4) tuple, Action<T> action)
        {
            action(tuple.v1);
            action(tuple.v2);
            action(tuple.v3);
            action(tuple.v4);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ForEach<T>(this (T v1, T v2, T v3) tuple, Action<T> action)
        {
            action(tuple.v1);
            action(tuple.v2);
            action(tuple.v3);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ForEach<T>(this (T v1, T v2) tuple, Action<T> action)
        {
            action(tuple.v1);
            action(tuple.v2);
        }

        #endregion

        #region Select

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (U, U, U, U, U, U, U) Select<T, U>(this (T v1, T v2, T v3, T v4, T v5, T v6, T v7) tuple, Func<T, U> func)
            => (func(tuple.v1),
                func(tuple.v2),
                func(tuple.v3),
                func(tuple.v4),
                func(tuple.v5),
                func(tuple.v6),
                func(tuple.v7));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (U, U, U, U, U, U) Select<T, U>(this (T v1, T v2, T v3, T v4, T v5, T v6) tuple, Func<T, U> func)
            => (func(tuple.v1),
                func(tuple.v2),
                func(tuple.v3),
                func(tuple.v4),
                func(tuple.v5),
                func(tuple.v6));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (U, U, U, U, U) Select<T, U>(this (T v1, T v2, T v3, T v4, T v5) tuple, Func<T, U> func)
            => (func(tuple.v1),
                func(tuple.v2),
                func(tuple.v3),
                func(tuple.v4),
                func(tuple.v5));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (U, U, U, U) Select<T, U>(this (T v1, T v2, T v3, T v4) tuple, Func<T, U> func)
            => (func(tuple.v1),
                func(tuple.v2),
                func(tuple.v3),
                func(tuple.v4));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (U, U, U) Select<T, U>(this (T v1, T v2, T v3) tuple, Func<T, U> func)
            => (func(tuple.v1),
                func(tuple.v2),
                func(tuple.v3));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (U, U) Select<T, U>(this (T v1, T v2) tuple, Func<T, U> func)
            => (func(tuple.v1),
                func(tuple.v2));

        #endregion

        #region Concat

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (T, T, T) Concat<T>(this (T v1, T v2) tuple, T value)
            => (tuple.v1, tuple.v2, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (T, T, T, T) Concat<T>(this (T v1, T v2, T v3) tuple, T value)
            => (tuple.v1, tuple.v2, tuple.v3, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (T, T, T, T, T) Concat<T>(this (T v1, T v2, T v3, T v4) tuple, T value)
            => (tuple.v1, tuple.v2, tuple.v3, tuple.v4, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (T, T, T, T, T, T) Concat<T>(this (T v1, T v2, T v3, T v4, T v5) tuple, T value)
            => (tuple.v1, tuple.v2, tuple.v3, tuple.v4, tuple.v5, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (T, T, T, T, T, T, T) Concat<T>(this (T v1, T v2, T v3, T v4, T v5, T v6) tuple, T value)
            => (tuple.v1, tuple.v2, tuple.v3, tuple.v4, tuple.v5, tuple.v6, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (T, T, T, T) Concat<T>(this (T v1, T v2) tuple, (T v1, T v2) other)
            => (tuple.v1, tuple.v2, other.v1, other.v2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (T, T, T, T, T) Concat<T>(this (T v1, T v2, T v3) tuple, (T v1, T v2) other)
            => (tuple.v1, tuple.v2, tuple.v3, other.v1, other.v2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (T, T, T, T, T) Concat<T>(this (T v1, T v2) tuple, (T v1, T v2, T v3) other)
            => (tuple.v1, tuple.v2, other.v1, other.v2, other.v3);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (T, T, T, T, T, T) Concat<T>(this (T v1, T v2, T v3) tuple, (T v1, T v2, T v3) other)
            => (tuple.v1, tuple.v2, tuple.v3, other.v1, other.v2, other.v3);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (T, T, T, T, T, T) Concat<T>(this (T v1, T v2, T v3, T v4) tuple, (T v1, T v2) other)
            => (tuple.v1, tuple.v2, tuple.v3, tuple.v4, other.v1, other.v2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (T, T, T, T, T, T) Concat<T>(this (T v1, T v2) tuple, (T v1, T v2, T v3, T v4) other)
            => (tuple.v1, tuple.v2, other.v1, other.v2, other.v3, other.v4);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (T, T, T, T, T, T, T) Concat<T>(this (T v1, T v2, T v3, T v4, T v5) tuple, (T v1, T v2) other)
            => (tuple.v1, tuple.v2, tuple.v3, tuple.v4, tuple.v5, other.v1, other.v2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (T, T, T, T, T, T, T) Concat<T>(this (T v1, T v2) tuple, (T v1, T v2, T v3, T v4, T v5) other)
            => (tuple.v1, tuple.v2, other.v1, other.v2, other.v3, other.v4, other.v5);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (T, T, T, T, T, T, T) Concat<T>(this (T v1, T v2, T v3, T v4) tuple, (T v1, T v2, T v3) other)
            => (tuple.v1, tuple.v2, tuple.v3, tuple.v4, other.v1, other.v2, other.v3);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (T, T, T, T, T, T, T) Concat<T>(this (T v1, T v2, T v3) tuple, (T v1, T v2, T v3, T v4) other)
            => (tuple.v1, tuple.v2, tuple.v3, other.v1, other.v2, other.v3, other.v4);

        #endregion

        #region Any

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Any<T>(this (T v1, T v2, T v3, T v4, T v5, T v6, T v7) tuple, Func<T, bool> func)
            => func(tuple.v1)
               || func(tuple.v2)
               || func(tuple.v3)
               || func(tuple.v4)
               || func(tuple.v5)
               || func(tuple.v6)
               || func(tuple.v7);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Any<T>(this (T v1, T v2, T v3, T v4, T v5, T v6) tuple, Func<T, bool> func)
            => func(tuple.v1)
               || func(tuple.v2)
               || func(tuple.v3)
               || func(tuple.v4)
               || func(tuple.v5)
               || func(tuple.v6);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Any<T>(this (T v1, T v2, T v3, T v4, T v5) tuple, Func<T, bool> func)
            => func(tuple.v1)
               || func(tuple.v2)
               || func(tuple.v3)
               || func(tuple.v4)
               || func(tuple.v5);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Any<T>(this (T v1, T v2, T v3, T v4) tuple, Func<T, bool> func)
            => func(tuple.v1)
               || func(tuple.v2)
               || func(tuple.v3)
               || func(tuple.v4);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Any<T>(this (T v1, T v2, T v3) tuple, Func<T, bool> func)
            => func(tuple.v1)
               || func(tuple.v2)
               || func(tuple.v3);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Any<T>(this (T v1, T v2) tuple, Func<T, bool> func)
            => func(tuple.v1)
               || func(tuple.v2);

        #endregion

        #region All

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool All<T>(this (T v1, T v2, T v3, T v4, T v5, T v6, T v7) tuple, Func<T, bool> func)
            => func(tuple.v1)
               && func(tuple.v2)
               && func(tuple.v3)
               && func(tuple.v4)
               && func(tuple.v5)
               && func(tuple.v6)
               && func(tuple.v7);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool All<T>(this (T v1, T v2, T v3, T v4, T v5, T v6) tuple, Func<T, bool> func)
            => func(tuple.v1)
               && func(tuple.v2)
               && func(tuple.v3)
               && func(tuple.v4)
               && func(tuple.v5)
               && func(tuple.v6);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool All<T>(this (T v1, T v2, T v3, T v4, T v5) tuple, Func<T, bool> func)
            => func(tuple.v1)
               && func(tuple.v2)
               && func(tuple.v3)
               && func(tuple.v4)
               && func(tuple.v5);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool All<T>(this (T v1, T v2, T v3, T v4) tuple, Func<T, bool> func)
            => func(tuple.v1)
               && func(tuple.v2)
               && func(tuple.v3)
               && func(tuple.v4);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool All<T>(this (T v1, T v2, T v3) tuple, Func<T, bool> func)
            => func(tuple.v1)
               && func(tuple.v2)
               && func(tuple.v3);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool All<T>(this (T v1, T v2) tuple, Func<T, bool> func)
            => func(tuple.v1)
               && func(tuple.v2);

        #endregion

        #region Aggregate

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T Aggregate<T>(this (T v1, T v2, T v3, T v4, T v5, T v6, T v7) tuple, Func<T, T, T> func)
            => func(tuple.v7, func(tuple.v6, func(tuple.v5, func(tuple.v4, func(tuple.v3, func(tuple.v1, tuple.v2))))));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T Aggregate<T>(this (T v1, T v2, T v3, T v4, T v5, T v6) tuple, Func<T, T, T> func)
            => func(tuple.v6, func(tuple.v5, func(tuple.v4, func(tuple.v3, func(tuple.v1, tuple.v2)))));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T Aggregate<T>(this (T v1, T v2, T v3, T v4, T v5) tuple, Func<T, T, T> func)
            => func(tuple.v5, func(tuple.v4, func(tuple.v3, func(tuple.v1, tuple.v2))));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T Aggregate<T>(this (T v1, T v2, T v3, T v4) tuple, Func<T, T, T> func)
            => func(tuple.v4, func(tuple.v3, func(tuple.v1, tuple.v2)));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T Aggregate<T>(this (T v1, T v2, T v3) tuple, Func<T, T, T> func)
            => func(tuple.v3, func(tuple.v1, tuple.v2));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T Aggregate<T>(this (T v1, T v2) tuple, Func<T, T, T> func)
            => func(tuple.v1, tuple.v2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static U Aggregate<T, U>(this (T v1, T v2, T v3, T v4, T v5, T v6, T v7) tuple, Func<T, U, U> func, U value)
            => func(tuple.v7, func(tuple.v6, func(tuple.v5, func(tuple.v4, func(tuple.v3, func(tuple.v2, func(tuple.v1, value)))))));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static U Aggregate<T, U>(this (T v1, T v2, T v3, T v4, T v5, T v6) tuple, Func<T, U, U> func, U value)
            => func(tuple.v6, func(tuple.v5, func(tuple.v4, func(tuple.v3, func(tuple.v2, func(tuple.v1, value))))));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static U Aggregate<T, U>(this (T v1, T v2, T v3, T v4, T v5) tuple, Func<T, U, U> func, U value)
            => func(tuple.v5, func(tuple.v4, func(tuple.v3, func(tuple.v2, func(tuple.v1, value)))));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static U Aggregate<T, U>(this (T v1, T v2, T v3, T v4) tuple, Func<T, U, U> func, U value)
            => func(tuple.v4, func(tuple.v3, func(tuple.v2, func(tuple.v1, value))));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static U Aggregate<T, U>(this (T v1, T v2, T v3) tuple, Func<T, U, U> func, U value)
            => func(tuple.v3, func(tuple.v2, func(tuple.v1, value)));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static U Aggregate<T, U>(this (T v1, T v2) tuple, Func<T, U, U> func, U value)
            => func(tuple.v2, func(tuple.v1, value));

        #endregion

        #region ToEnumerable

        public static IEnumerable<T> AsEnumerable<T>(this (T v1, T v2, T v3, T v4, T v5, T v6, T v7) tuple)
        {
            yield return tuple.v1;
            yield return tuple.v2;
            yield return tuple.v3;
            yield return tuple.v4;
            yield return tuple.v5;
            yield return tuple.v6;
            yield return tuple.v7;
        }

        public static IEnumerable<T> AsEnumerable<T>(this (T v1, T v2, T v3, T v4, T v5, T v6) tuple)
        {
            yield return tuple.v1;
            yield return tuple.v2;
            yield return tuple.v3;
            yield return tuple.v4;
            yield return tuple.v5;
            yield return tuple.v6;
        }

        public static IEnumerable<T> AsEnumerable<T>(this (T v1, T v2, T v3, T v4, T v5) tuple)
        {
            yield return tuple.v1;
            yield return tuple.v2;
            yield return tuple.v3;
            yield return tuple.v4;
            yield return tuple.v5;
        }

        public static IEnumerable<T> AsEnumerable<T>(this (T v1, T v2, T v3, T v4) tuple)
        {
            yield return tuple.v1;
            yield return tuple.v2;
            yield return tuple.v3;
            yield return tuple.v4;
        }

        public static IEnumerable<T> AsEnumerable<T>(this (T v1, T v2, T v3) tuple)
        {
            yield return tuple.v1;
            yield return tuple.v2;
            yield return tuple.v3;
        }

        public static IEnumerable<T> AsEnumerable<T>(this (T v1, T v2) tuple)
        {
            yield return tuple.v1;
            yield return tuple.v2;
        }

        #endregion

        #region FirstOrDefault

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

        #endregion

        #region LastOrDefault

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T LastOrDefault<T>(this (T v1, T v2, T v3, T v4, T v5, T v6, T v7) tuple, Func<T, bool> func)
        {
            if (func(tuple.v1)) return tuple.v7;
            if (func(tuple.v1)) return tuple.v6;
            if (func(tuple.v1)) return tuple.v5;
            if (func(tuple.v1)) return tuple.v4;
            if (func(tuple.v1)) return tuple.v3;
            if (func(tuple.v1)) return tuple.v2;
            if (func(tuple.v1)) return tuple.v1;
#pragma warning disable CS8653
            return default;
#pragma warning restore
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T LastOrDefault<T>(this (T v1, T v2, T v3, T v4, T v5, T v6) tuple, Func<T, bool> func)
        {
            if (func(tuple.v1)) return tuple.v6;
            if (func(tuple.v1)) return tuple.v5;
            if (func(tuple.v1)) return tuple.v4;
            if (func(tuple.v1)) return tuple.v3;
            if (func(tuple.v1)) return tuple.v2;
            if (func(tuple.v1)) return tuple.v1;
#pragma warning disable CS8653
            return default;
#pragma warning restore
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T LastOrDefault<T>(this (T v1, T v2, T v3, T v4, T v5) tuple, Func<T, bool> func)
        {
            if (func(tuple.v1)) return tuple.v5;
            if (func(tuple.v1)) return tuple.v4;
            if (func(tuple.v1)) return tuple.v3;
            if (func(tuple.v1)) return tuple.v2;
            if (func(tuple.v1)) return tuple.v1;
#pragma warning disable CS8653
            return default;
#pragma warning restore
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T LastOrDefault<T>(this (T v1, T v2, T v3, T v4) tuple, Func<T, bool> func)
        {
            if (func(tuple.v1)) return tuple.v4;
            if (func(tuple.v1)) return tuple.v3;
            if (func(tuple.v1)) return tuple.v2;
            if (func(tuple.v1)) return tuple.v1;
#pragma warning disable CS8653
            return default;
#pragma warning restore
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T LastOrDefault<T>(this (T v1, T v2, T v3) tuple, Func<T, bool> func)
        {
            if (func(tuple.v1)) return tuple.v3;
            if (func(tuple.v1)) return tuple.v2;
            if (func(tuple.v1)) return tuple.v1;
#pragma warning disable CS8653
            return default;
#pragma warning restore
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T LastOrDefault<T>(this (T v1, T v2) tuple, Func<T, bool> func)
        {
            if (func(tuple.v1)) return tuple.v2;
            if (func(tuple.v1)) return tuple.v1;
#pragma warning disable CS8653
            return default;
#pragma warning restore
        }

        #endregion

        #region TryGetValue

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

        #endregion

        #region AsArray

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T[] AsArray<T>(this (T v1, T v2, T v3, T v4, T v5, T v6, T v7) tuple)
            => new T[] {tuple.v1, tuple.v2, tuple.v3, tuple.v4, tuple.v5, tuple.v6, tuple.v7};

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T[] AsArray<T>(this (T v1, T v2, T v3, T v4, T v5, T v6) tuple)
            => new T[] {tuple.v1, tuple.v2, tuple.v3, tuple.v4, tuple.v5, tuple.v6};

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T[] AsArray<T>(this (T v1, T v2, T v3, T v4, T v5) tuple)
            => new T[] {tuple.v1, tuple.v2, tuple.v3, tuple.v4, tuple.v5};

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T[] AsArray<T>(this (T v1, T v2, T v3, T v4) tuple)
            => new T[] {tuple.v1, tuple.v2, tuple.v3, tuple.v4};

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T[] AsArray<T>(this (T v1, T v2, T v3) tuple)
            => new T[] {tuple.v1, tuple.v2, tuple.v3};

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T[] AsArray<T>(this (T v1, T v2) tuple)
            => new T[] {tuple.v1, tuple.v2};

        #endregion

        #region ToArray

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

        #endregion

        #region Min
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Min(this (int v1, int v2, int v3, int v4, int v5, int v6, int v7) tuple)
        {
            var num = tuple.v1 < tuple.v2 ? tuple.v1 : tuple.v2;
            if (num > tuple.v3) num = tuple.v3;
            if (num > tuple.v4) num = tuple.v4;
            if (num > tuple.v5) num = tuple.v5;
            if (num > tuple.v6) num = tuple.v6;
            return num > tuple.v7 ? tuple.v7 : num;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Min(this (int v1, int v2, int v3, int v4, int v5, int v6) tuple)
        {
            var num = tuple.v1 < tuple.v2 ? tuple.v1 : tuple.v2;
            if (num > tuple.v3) num = tuple.v3;
            if (num > tuple.v4) num = tuple.v4;
            if (num > tuple.v5) num = tuple.v5;
            return num > tuple.v6 ? tuple.v6 : num;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Min(this (int v1, int v2, int v3, int v4, int v5) tuple)
        {
            var num = tuple.v1 > tuple.v2 ? tuple.v1 : tuple.v2;
            if (num > tuple.v3) num = tuple.v3;
            if (num > tuple.v4) num = tuple.v4;
            return num > tuple.v5 ? tuple.v5 : num;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Min(this (int v1, int v2, int v3, int v4) tuple)
        {
            var num = tuple.v1 > tuple.v2 ? tuple.v1 : tuple.v2;
            if (num > tuple.v3) num = tuple.v3;
            return num > tuple.v4 ? tuple.v4 : num;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Min(this (int v1, int v2, int v3) tuple)
        {
            var num = tuple.v1 > tuple.v2 ? tuple.v1 : tuple.v2;
            return num > tuple.v3 ? tuple.v3 : num;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Min(this (int v1, int v2) tuple)
        {
            return tuple.v1 < tuple.v2 ? tuple.v1 : tuple.v2;
        }
        
        // TODO: primitiveTypes
        
        #endregion

        #region Max

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Max(this (int v1, int v2, int v3, int v4, int v5, int v6, int v7) tuple)
        {
            var num = tuple.v1 > tuple.v2 ? tuple.v1 : tuple.v2;
            if (num < tuple.v3) num = tuple.v3;
            if (num < tuple.v4) num = tuple.v4;
            if (num < tuple.v5) num = tuple.v5;
            if (num < tuple.v6) num = tuple.v6;
            return num < tuple.v7 ? tuple.v7 : num;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Max(this (int v1, int v2, int v3, int v4, int v5, int v6) tuple)
        {
            var num = tuple.v1 > tuple.v2 ? tuple.v1 : tuple.v2;
            if (num < tuple.v3) num = tuple.v3;
            if (num < tuple.v4) num = tuple.v4;
            if (num < tuple.v5) num = tuple.v5;
            return num < tuple.v6 ? tuple.v6 : num;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Max(this (int v1, int v2, int v3, int v4, int v5) tuple)
        {
            var num = tuple.v1 > tuple.v2 ? tuple.v1 : tuple.v2;
            if (num < tuple.v3) num = tuple.v3;
            if (num < tuple.v4) num = tuple.v4;
            return num < tuple.v5 ? tuple.v5 : num;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Max(this (int v1, int v2, int v3, int v4) tuple)
        {
            var num = tuple.v1 > tuple.v2 ? tuple.v1 : tuple.v2;
            if (num < tuple.v3) num = tuple.v3;
            return num < tuple.v4 ? tuple.v4 : num;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Max(this (int v1, int v2, int v3) tuple)
        {
            var num = tuple.v1 > tuple.v2 ? tuple.v1 : tuple.v2;
            return num < tuple.v3 ? tuple.v3 : num;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Max(this (int v1, int v2) tuple)
        {
            return tuple.v1 > tuple.v2 ? tuple.v1 : tuple.v2;
        }

        // TODO: primitiveTypes
        
        #endregion

        #region Sum

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Sum(this (int v1, int v2, int v3, int v4, int v5, int v6, int v7) tuple)
            => tuple.v1 + tuple.v2 + tuple.v3 + tuple.v4 + tuple.v5 + tuple.v6 + tuple.v7;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Sum(this (int v1, int v2, int v3, int v4, int v5, int v6) tuple)
            => tuple.v1 + tuple.v2 + tuple.v3 + tuple.v4 + tuple.v5 + tuple.v6;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Sum(this (int v1, int v2, int v3, int v4, int v5) tuple)
            => tuple.v1 + tuple.v2 + tuple.v3 + tuple.v4 + tuple.v5;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Sum(this (int v1, int v2, int v3, int v4) tuple)
            => tuple.v1 + tuple.v2 + tuple.v3 + tuple.v4;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Sum(this (int v1, int v2, int v3) tuple)
            => tuple.v1 + tuple.v2 + tuple.v3;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Sum(this (int v1, int v2) tuple)
            => tuple.v1 + tuple.v2;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint Sum(this (uint v1, uint v2, uint v3, uint v4, uint v5, uint v6, uint v7) tuple)
            => tuple.v1 + tuple.v2 + tuple.v3 + tuple.v4 + tuple.v5 + tuple.v6 + tuple.v7;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint Sum(this (uint v1, uint v2, uint v3, uint v4, uint v5, uint v6) tuple)
            => tuple.v1 + tuple.v2 + tuple.v3 + tuple.v4 + tuple.v5 + tuple.v6;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint Sum(this (uint v1, uint v2, uint v3, uint v4, uint v5) tuple)
            => tuple.v1 + tuple.v2 + tuple.v3 + tuple.v4 + tuple.v5;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint Sum(this (uint v1, uint v2, uint v3, uint v4) tuple)
            => tuple.v1 + tuple.v2 + tuple.v3 + tuple.v4;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint Sum(this (uint v1, uint v2, uint v3) tuple)
            => tuple.v1 + tuple.v2 + tuple.v3;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint Sum(this (uint v1, uint v2) tuple)
            => tuple.v1 + tuple.v2;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long Sum(this (long v1, int v2, int v3, int v4, int v5, int v6, int v7) tuple)
            => tuple.v1 + tuple.v2 + tuple.v3 + tuple.v4 + tuple.v5 + tuple.v6 + tuple.v7;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long Sum(this (long v1, int v2, int v3, int v4, int v5, int v6) tuple)
            => tuple.v1 + tuple.v2 + tuple.v3 + tuple.v4 + tuple.v5 + tuple.v6;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long Sum(this (long v1, int v2, int v3, int v4, int v5) tuple)
            => tuple.v1 + tuple.v2 + tuple.v3 + tuple.v4 + tuple.v5;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long Sum(this (long v1, int v2, int v3, int v4) tuple)
            => tuple.v1 + tuple.v2 + tuple.v3 + tuple.v4;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long Sum(this (long v1, int v2, int v3) tuple)
            => tuple.v1 + tuple.v2 + tuple.v3;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long Sum(this (long v1, int v2) tuple)
            => tuple.v1 + tuple.v2;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong Sum(this (ulong v1, uint v2, uint v3, uint v4, uint v5, uint v6, uint v7) tuple)
            => tuple.v1 + tuple.v2 + tuple.v3 + tuple.v4 + tuple.v5 + tuple.v6 + tuple.v7;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong Sum(this (ulong v1, uint v2, uint v3, uint v4, uint v5, uint v6) tuple)
            => tuple.v1 + tuple.v2 + tuple.v3 + tuple.v4 + tuple.v5 + tuple.v6;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong Sum(this (ulong v1, uint v2, uint v3, uint v4, uint v5) tuple)
            => tuple.v1 + tuple.v2 + tuple.v3 + tuple.v4 + tuple.v5;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong Sum(this (ulong v1, uint v2, uint v3, uint v4) tuple)
            => tuple.v1 + tuple.v2 + tuple.v3 + tuple.v4;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong Sum(this (ulong v1, uint v2, uint v3) tuple)
            => tuple.v1 + tuple.v2 + tuple.v3;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong Sum(this (ulong v1, uint v2) tuple)
            => tuple.v1 + tuple.v2;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Sum(this (short v1, short v2, short v3, short v4, short v5, short v6, short v7) tuple)
            => tuple.v1 + tuple.v2 + tuple.v3 + tuple.v4 + tuple.v5 + tuple.v6 + tuple.v7;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Sum(this (short v1, short v2, short v3, short v4, short v5, short v6) tuple)
            => tuple.v1 + tuple.v2 + tuple.v3 + tuple.v4 + tuple.v5 + tuple.v6;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Sum(this (short v1, short v2, short v3, short v4, short v5) tuple)
            => tuple.v1 + tuple.v2 + tuple.v3 + tuple.v4 + tuple.v5;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Sum(this (short v1, short v2, short v3, short v4) tuple)
            => tuple.v1 + tuple.v2 + tuple.v3 + tuple.v4;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Sum(this (short v1, short v2, short v3) tuple)
            => tuple.v1 + tuple.v2 + tuple.v3;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Sum(this (short v1, short v2) tuple)
            => tuple.v1 + tuple.v2;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Sum(this (ushort v1, ushort v2, ushort v3, ushort v4, ushort v5, ushort v6, ushort v7) tuple)
            => tuple.v1 + tuple.v2 + tuple.v3 + tuple.v4 + tuple.v5 + tuple.v6 + tuple.v7;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Sum(this (ushort v1, ushort v2, ushort v3, ushort v4, ushort v5, ushort v6) tuple)
            => tuple.v1 + tuple.v2 + tuple.v3 + tuple.v4 + tuple.v5 + tuple.v6;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Sum(this (ushort v1, ushort v2, ushort v3, ushort v4, ushort v5) tuple)
            => tuple.v1 + tuple.v2 + tuple.v3 + tuple.v4 + tuple.v5;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Sum(this (ushort v1, ushort v2, ushort v3, ushort v4) tuple)
            => tuple.v1 + tuple.v2 + tuple.v3 + tuple.v4;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Sum(this (ushort v1, ushort v2, ushort v3) tuple)
            => tuple.v1 + tuple.v2 + tuple.v3;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Sum(this (ushort v1, ushort v2) tuple)
            => tuple.v1 + tuple.v2;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Sum(this (byte v1, byte v2, byte v3, byte v4, byte v5, byte v6, byte v7) tuple)
            => tuple.v1 + tuple.v2 + tuple.v3 + tuple.v4 + tuple.v5 + tuple.v6 + tuple.v7;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Sum(this (byte v1, byte v2, byte v3, byte v4, byte v5, byte v6) tuple)
            => tuple.v1 + tuple.v2 + tuple.v3 + tuple.v4 + tuple.v5 + tuple.v6;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Sum(this (byte v1, byte v2, byte v3, byte v4, byte v5) tuple)
            => tuple.v1 + tuple.v2 + tuple.v3 + tuple.v4 + tuple.v5;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Sum(this (byte v1, byte v2, byte v3, byte v4) tuple)
            => tuple.v1 + tuple.v2 + tuple.v3 + tuple.v4;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Sum(this (byte v1, byte v2, byte v3) tuple)
            => tuple.v1 + tuple.v2 + tuple.v3;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Sum(this (byte v1, byte v2) tuple)
            => tuple.v1 + tuple.v2;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Sum(this (sbyte v1, sbyte v2, sbyte v3, sbyte v4, sbyte v5, sbyte v6, sbyte v7) tuple)
            => tuple.v1 + tuple.v2 + tuple.v3 + tuple.v4 + tuple.v5 + tuple.v6 + tuple.v7;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Sum(this (sbyte v1, sbyte v2, sbyte v3, sbyte v4, sbyte v5, sbyte v6) tuple)
            => tuple.v1 + tuple.v2 + tuple.v3 + tuple.v4 + tuple.v5 + tuple.v6;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Sum(this (sbyte v1, sbyte v2, sbyte v3, sbyte v4, sbyte v5) tuple)
            => tuple.v1 + tuple.v2 + tuple.v3 + tuple.v4 + tuple.v5;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Sum(this (sbyte v1, sbyte v2, sbyte v3, sbyte v4) tuple)
            => tuple.v1 + tuple.v2 + tuple.v3 + tuple.v4;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Sum(this (sbyte v1, sbyte v2, sbyte v3) tuple)
            => tuple.v1 + tuple.v2 + tuple.v3;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Sum(this (sbyte v1, sbyte v2) tuple)
            => tuple.v1 + tuple.v2;

        #endregion

        #region Cast

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (TOut, TOut, TOut, TOut, TOut, TOut, TOut) Cast<TIn, TOut>(this (TIn v1, TIn v2, TIn v3, TIn v4, TIn v5, TIn v6, TIn v7) tuple) where TIn : class
            => ((TOut) (object) tuple.v1, (TOut) (object) tuple.v2, (TOut) (object) tuple.v3, (TOut) (object) tuple.v4, (TOut) (object) tuple.v5, (TOut) (object) tuple.v6, (TOut) (object) tuple.v7);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (TOut, TOut, TOut, TOut, TOut, TOut) Cast<TIn, TOut>(this (TIn v1, TIn v2, TIn v3, TIn v4, TIn v5, TIn v6) tuple) where TIn : class
            => ((TOut) (object) tuple.v1, (TOut) (object) tuple.v2, (TOut) (object) tuple.v3, (TOut) (object) tuple.v4, (TOut) (object) tuple.v5, (TOut) (object) tuple.v6);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (TOut, TOut, TOut, TOut, TOut) Cast<TIn, TOut>(this (TIn v1, TIn v2, TIn v3, TIn v4, TIn v5) tuple) where TIn : class
            => ((TOut) (object) tuple.v1, (TOut) (object) tuple.v2, (TOut) (object) tuple.v3, (TOut) (object) tuple.v4, (TOut) (object) tuple.v5);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (TOut, TOut, TOut, TOut) Cast<TIn, TOut>(this (TIn v1, TIn v2, TIn v3, TIn v4) tuple) where TIn : class
            => ((TOut) (object) tuple.v1, (TOut) (object) tuple.v2, (TOut) (object) tuple.v3, (TOut) (object) tuple.v4);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (TOut, TOut, TOut) Cast<TIn, TOut>(this (TIn v1, TIn v2, TIn v3) tuple) where TIn : class
            => ((TOut) (object) tuple.v1, (TOut) (object) tuple.v2, (TOut) (object) tuple.v3);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (TOut, TOut) Cast<TIn, TOut>(this (TIn v1, TIn v2) tuple) where TIn : class
            => ((TOut) (object) tuple.v1, (TOut) (object) tuple.v2);

        #endregion

        #region As

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (TOut?, TOut?, TOut?, TOut?, TOut?, TOut?, TOut?) As<TIn, TOut>(this (TIn v1, TIn v2, TIn v3, TIn v4, TIn v5, TIn v6, TIn v7) tuple) where TOut : class where TIn : class
            => (tuple.v1 as TOut, tuple.v2 as TOut, tuple.v3 as TOut, tuple.v4 as TOut, tuple.v5 as TOut, tuple.v6 as TOut, tuple.v7 as TOut);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (TOut?, TOut?, TOut?, TOut?, TOut?, TOut?) As<TIn, TOut>(this (TIn v1, TIn v2, TIn v3, TIn v4, TIn v5, TIn v6) tuple) where TOut : class where TIn : class
            => (tuple.v1 as TOut, tuple.v2 as TOut, tuple.v3 as TOut, tuple.v4 as TOut, tuple.v5 as TOut, tuple.v6 as TOut);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (TOut?, TOut?, TOut?, TOut?, TOut?) As<TIn, TOut>(this (TIn v1, TIn v2, TIn v3, TIn v4, TIn v5) tuple) where TOut : class where TIn : class
            => (tuple.v1 as TOut, tuple.v2 as TOut, tuple.v3 as TOut, tuple.v4 as TOut, tuple.v5 as TOut);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (TOut?, TOut?, TOut?, TOut?) As<TIn, TOut>(this (TIn v1, TIn v2, TIn v3, TIn v4) tuple) where TOut : class where TIn : class
            => (tuple.v1 as TOut, tuple.v2 as TOut, tuple.v3 as TOut, tuple.v4 as TOut);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (TOut?, TOut?, TOut?) As<TIn, TOut>(this (TIn v1, TIn v2, TIn v3) tuple) where TOut : class where TIn : class
            => (tuple.v1 as TOut, tuple.v2 as TOut, tuple.v3 as TOut);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (TOut?, TOut?) As<TIn, TOut>(this (TIn v1, TIn v2) tuple) where TOut : class where TIn : class
            => (tuple.v1 as TOut, tuple.v2 as TOut);

        #endregion
    }
}
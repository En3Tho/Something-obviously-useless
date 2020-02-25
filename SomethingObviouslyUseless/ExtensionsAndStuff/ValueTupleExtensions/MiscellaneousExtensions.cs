using System;
using System.Collections.Generic;

namespace ExtensionsAndStuff.ValueTupleExtensions
{
    public static class MiscellaneousExtensions
    {
        #region Validate

        public static void Validate<T>(this (T value1, T value2, T value3, T value4, T value5, T value6, T value7) tuple, Func<T, bool> func)
        {
            if (func(tuple.value1)) ValueTupleValidationException.Throw(nameof(tuple.value1));
            if (func(tuple.value2)) ValueTupleValidationException.Throw(nameof(tuple.value2));
            if (func(tuple.value3)) ValueTupleValidationException.Throw(nameof(tuple.value3));
            if (func(tuple.value4)) ValueTupleValidationException.Throw(nameof(tuple.value4));
            if (func(tuple.value5)) ValueTupleValidationException.Throw(nameof(tuple.value5));
            if (func(tuple.value6)) ValueTupleValidationException.Throw(nameof(tuple.value6));
            if (func(tuple.value7)) ValueTupleValidationException.Throw(nameof(tuple.value7));
        }

        public static void Validate<T>(this (T value1, T value2, T value3, T value4, T value5, T value6) tuple, Func<T, bool> func)
        {
            if (func(tuple.value1)) ValueTupleValidationException.Throw(nameof(tuple.value1));
            if (func(tuple.value2)) ValueTupleValidationException.Throw(nameof(tuple.value2));
            if (func(tuple.value3)) ValueTupleValidationException.Throw(nameof(tuple.value3));
            if (func(tuple.value4)) ValueTupleValidationException.Throw(nameof(tuple.value4));
            if (func(tuple.value5)) ValueTupleValidationException.Throw(nameof(tuple.value5));
            if (func(tuple.value6)) ValueTupleValidationException.Throw(nameof(tuple.value6));
        }

        public static void Validate<T>(this (T value1, T value2, T value3, T value4, T value5) tuple, Func<T, bool> func)
        {
            if (func(tuple.value1)) ValueTupleValidationException.Throw(nameof(tuple.value1));
            if (func(tuple.value2)) ValueTupleValidationException.Throw(nameof(tuple.value2));
            if (func(tuple.value3)) ValueTupleValidationException.Throw(nameof(tuple.value3));
            if (func(tuple.value4)) ValueTupleValidationException.Throw(nameof(tuple.value4));
            if (func(tuple.value5)) ValueTupleValidationException.Throw(nameof(tuple.value5));
        }

        public static void Validate<T>(this (T value1, T value2, T value3, T value4) tuple, Func<T, bool> func)
        {
            if (func(tuple.value1)) ValueTupleValidationException.Throw(nameof(tuple.value1));
            if (func(tuple.value2)) ValueTupleValidationException.Throw(nameof(tuple.value2));
            if (func(tuple.value3)) ValueTupleValidationException.Throw(nameof(tuple.value3));
            if (func(tuple.value4)) ValueTupleValidationException.Throw(nameof(tuple.value4));
        }

        public static void Validate<T>(this (T value1, T value2, T value3) tuple, Func<T, bool> func)
        {
            if (func(tuple.value1)) ValueTupleValidationException.Throw(nameof(tuple.value1));
            if (func(tuple.value2)) ValueTupleValidationException.Throw(nameof(tuple.value2));
            if (func(tuple.value3)) ValueTupleValidationException.Throw(nameof(tuple.value3));

        }
        public static void Validate<T>(this (T value1, T value2) tuple, Func<T, bool> func)
        {
            if (func(tuple.value1)) ValueTupleValidationException.Throw(nameof(tuple.value1));
            if (func(tuple.value2)) ValueTupleValidationException.Throw(nameof(tuple.value2));
        }

        #endregion

        #region ShouldNot

        public static (T, T, T, T, T, T, T) ShouldNot<T>(this (T value1, T value2, T value3, T value4, T value5, T value6, T value7) tuple, Func<T, bool> func)
        {
            tuple.Validate(func);
            return tuple;
        }

        public static (T, T, T, T, T, T) ShouldNot<T>(this (T value1, T value2, T value3, T value4, T value5, T value6) tuple, Func<T, bool> func)
        {
            tuple.Validate(func);
            return tuple;
        }

        public static (T, T, T, T, T) ShouldNot<T>(this (T value1, T value2, T value3, T value4, T value5) tuple, Func<T, bool> func)
        {
            tuple.Validate(func);
            return tuple;
        }

        public static (T, T, T, T) ShouldNot<T>(this (T value1, T value2, T value3, T value4) tuple, Func<T, bool> func)
        {
            tuple.Validate(func);
            return tuple;
        }

        public static (T, T, T) ShouldNot<T>(this (T value1, T value2, T value3) tuple, Func<T, bool> func)
        {
            tuple.Validate(func);
            return tuple;

        }
        public static (T, T) ShouldNot<T>(this (T value1, T value2) tuple, Func<T, bool> func)
        {
            tuple.Validate(func);
            return tuple;
        }

        #endregion

        #region Contains

        public static bool Contains<T>(this (T value1, T value2, T value3, T value4, T value5, T value6, T value7) tuple, T value)
                => tuple.value1.Equals(value)
                || tuple.value2.Equals(value)
                || tuple.value3.Equals(value)
                || tuple.value4.Equals(value)
                || tuple.value5.Equals(value)
                || tuple.value6.Equals(value)
                || tuple.value7.Equals(value);

        public static bool Contains<T>(this (T value1, T value2, T value3, T value4, T value5, T value6) tuple, T value)
               => tuple.value1.Equals(value)
               || tuple.value2.Equals(value)
               || tuple.value3.Equals(value)
               || tuple.value4.Equals(value)
               || tuple.value5.Equals(value)
               || tuple.value6.Equals(value);

        public static bool Contains<T>(this (T value1, T value2, T value3, T value4, T value5) tuple, T value)
               => tuple.value1.Equals(value)
               || tuple.value2.Equals(value)
               || tuple.value3.Equals(value)
               || tuple.value4.Equals(value)
               || tuple.value5.Equals(value);

        public static bool Contains<T>(this (T value1, T value2, T value3, T value4) tuple, T value)
              => tuple.value1.Equals(value)
              || tuple.value2.Equals(value)
              || tuple.value3.Equals(value)
              || tuple.value4.Equals(value);

        public static bool Contains<T>(this (T value1, T value2, T value3) tuple, T value)
              => tuple.value1.Equals(value)
              || tuple.value2.Equals(value)
              || tuple.value3.Equals(value);

        public static bool Contains<T>(this (T value1, T value2) tuple, T value)
              => tuple.value1.Equals(value)
              || tuple.value2.Equals(value);

        #endregion

        #region ForEach

        public static void ForEach<T>(this (T value1, T value2, T value3, T value4, T value5, T value6, T value7) tuple, Action<T> action)
        {
            action(tuple.value1);
            action(tuple.value2);
            action(tuple.value3);
            action(tuple.value4);
            action(tuple.value5);
            action(tuple.value6);
            action(tuple.value7);
        }

        public static void ForEach<T>(this (T value1, T value2, T value3, T value4, T value5, T value6) tuple, Action<T> action)
        {
            action(tuple.value1);
            action(tuple.value2);
            action(tuple.value3);
            action(tuple.value4);
            action(tuple.value5);
            action(tuple.value6);
        }

        public static void ForEach<T>(this (T value1, T value2, T value3, T value4, T value5) tuple, Action<T> action)
        {
            action(tuple.value1);
            action(tuple.value2);
            action(tuple.value3);
            action(tuple.value4);
            action(tuple.value5);
        }

        public static void ForEach<T>(this (T value1, T value2, T value3, T value4) tuple, Action<T> action)
        {
            action(tuple.value1);
            action(tuple.value2);
            action(tuple.value3);
            action(tuple.value4);
        }

        public static void ForEach<T>(this (T value1, T value2, T value3) tuple, Action<T> action)
        {
            action(tuple.value1);
            action(tuple.value2);
            action(tuple.value3);
        }

        public static void ForEach<T>(this (T value1, T value2) tuple, Action<T> action)
        {
            action(tuple.value1);
            action(tuple.value2);
        }

        #endregion

        #region Select

        public static (U, U, U, U, U, U, U) Select<T, U>(this (T value1, T value2, T value3, T value4, T value5, T value6, T value7) tuple, Func<T, U> func)
            => (func(tuple.value1),
                func(tuple.value2),
                func(tuple.value3),
                func(tuple.value4),
                func(tuple.value5),
                func(tuple.value6),
                func(tuple.value7));

        public static (U, U, U, U, U, U) Select<T, U>(this (T value1, T value2, T value3, T value4, T value5, T value6) tuple, Func<T, U> func)
            => (func(tuple.value1),
                func(tuple.value2),
                func(tuple.value3),
                func(tuple.value4),
                func(tuple.value5),
                func(tuple.value6));

        public static (U, U, U, U, U) Select<T, U>(this (T value1, T value2, T value3, T value4, T value5) tuple, Func<T, U> func)
            => (func(tuple.value1),
                func(tuple.value2),
                func(tuple.value3),
                func(tuple.value4),
                func(tuple.value5));

        public static (U, U, U, U) Select<T, U>(this (T value1, T value2, T value3, T value4) tuple, Func<T, U> func)
            => (func(tuple.value1),
                func(tuple.value2),
                func(tuple.value3),
                func(tuple.value4));

        public static (U, U, U) Select<T, U>(this (T value1, T value2, T value3) tuple, Func<T, U> func)
            => (func(tuple.value1),
                func(tuple.value2),
                func(tuple.value3));

        public static (U, U) Select<T, U>(this (T value1, T value2) tuple, Func<T, U> func)
            => (func(tuple.value1),
                func(tuple.value2));

        #endregion

        #region Concat

        public static (T, T, T) Concat<T>(this (T value1, T value2) tuple, T value)
            => (tuple.value1, tuple.value2, value);

        public static (T, T, T, T) Concat<T>(this (T value1, T value2, T value3) tuple, T value)
            => (tuple.value1, tuple.value2, tuple.value3, value);

        public static (T, T, T, T, T) Concat<T>(this (T value1, T value2, T value3, T value4) tuple, T value)
            => (tuple.value1, tuple.value2, tuple.value3, tuple.value4, value);

        public static (T, T, T, T, T, T) Concat<T>(this (T value1, T value2, T value3, T value4, T value5) tuple, T value)
           => (tuple.value1, tuple.value2, tuple.value3, tuple.value4, tuple.value5, value);

        public static (T, T, T, T, T, T, T) Concat<T>(this (T value1, T value2, T value3, T value4, T value5, T value6) tuple, T value)
           => (tuple.value1, tuple.value2, tuple.value3, tuple.value4, tuple.value5, tuple.value6, value);

        public static (T, T, T, T) Concat<T>(this (T value1, T value2) tuple, (T value1, T value2) other)
            => (tuple.value1, tuple.value2, other.value1, other.value2);

        public static (T, T, T, T, T) Concat<T>(this (T value1, T value2, T value3) tuple, (T value1, T value2) other)
            => (tuple.value1, tuple.value2, tuple.value3, other.value1, other.value2);

        public static (T, T, T, T, T) Concat<T>(this (T value1, T value2) tuple, (T value1, T value2, T value3) other)
            => (tuple.value1, tuple.value2, other.value1, other.value2, other.value3);

        public static (T, T, T, T, T, T) Concat<T>(this (T value1, T value2, T value3) tuple, (T value1, T value2, T value3) other)
            => (tuple.value1, tuple.value2, tuple.value3, other.value1, other.value2, other.value3);

        public static (T, T, T, T, T, T) Concat<T>(this (T value1, T value2, T value3, T value4) tuple, (T value1, T value2) other)
            => (tuple.value1, tuple.value2, tuple.value3, tuple.value4, other.value1, other.value2);

        public static (T, T, T, T, T, T) Concat<T>(this (T value1, T value2) tuple, (T value1, T value2, T value3, T value4) other)
            => (tuple.value1, tuple.value2, other.value1, other.value2, other.value3, other.value4);

        public static (T, T, T, T, T, T, T) Concat<T>(this (T value1, T value2, T value3, T value4, T value5) tuple, (T value1, T value2) other)
            => (tuple.value1, tuple.value2, tuple.value3, tuple.value4, tuple.value5, other.value1, other.value2);

        public static (T, T, T, T, T, T, T) Concat<T>(this (T value1, T value2) tuple, (T value1, T value2, T value3, T value4, T value5) other)
            => (tuple.value1, tuple.value2, other.value1, other.value2, other.value3, other.value4, other.value5);

        public static (T, T, T, T, T, T, T) Concat<T>(this (T value1, T value2, T value3, T value4) tuple, (T value1, T value2, T value3) other)
            => (tuple.value1, tuple.value2, tuple.value3, tuple.value4, other.value1, other.value2, other.value3);

        public static (T, T, T, T, T, T, T) Concat<T>(this (T value1, T value2, T value3) tuple, (T value1, T value2, T value3, T value4) other)
            => (tuple.value1, tuple.value2, tuple.value3, other.value1, other.value2, other.value3, other.value4);

        #endregion

        #region Any

        public static bool Any<T>(this (T value1, T value2, T value3, T value4, T value5, T value6, T value7) tuple, Func<T, bool> func)
               => func(tuple.value1)
               || func(tuple.value2)
               || func(tuple.value3)
               || func(tuple.value4)
               || func(tuple.value5)
               || func(tuple.value6)
               || func(tuple.value7);

        public static bool Any<T>(this (T value1, T value2, T value3, T value4, T value5, T value6) tuple, Func<T, bool> func)
               => func(tuple.value1)
               || func(tuple.value2)
               || func(tuple.value3)
               || func(tuple.value4)
               || func(tuple.value5)
               || func(tuple.value6);

        public static bool Any<T>(this (T value1, T value2, T value3, T value4, T value5) tuple, Func<T, bool> func)
              => func(tuple.value1)
              || func(tuple.value2)
              || func(tuple.value3)
              || func(tuple.value4)
              || func(tuple.value5);

        public static bool Any<T>(this (T value1, T value2, T value3, T value4) tuple, Func<T, bool> func)
              => func(tuple.value1)
              || func(tuple.value2)
              || func(tuple.value3)
              || func(tuple.value4);

        public static bool Any<T>(this (T value1, T value2, T value3) tuple, Func<T, bool> func)
              => func(tuple.value1)
              || func(tuple.value2)
              || func(tuple.value3);

        public static bool Any<T>(this (T value1, T value2) tuple, Func<T, bool> func)
             => func(tuple.value1)
             || func(tuple.value2);

        #endregion

        #region All

        public static bool All<T>(this (T value1, T value2, T value3, T value4, T value5, T value6, T value7) tuple, Func<T, bool> func)
               => func(tuple.value1)
               && func(tuple.value2)
               && func(tuple.value3)
               && func(tuple.value4)
               && func(tuple.value5)
               && func(tuple.value6)
               && func(tuple.value7);

        public static bool All<T>(this (T value1, T value2, T value3, T value4, T value5, T value6) tuple, Func<T, bool> func)
               => func(tuple.value1)
               && func(tuple.value2)
               && func(tuple.value3)
               && func(tuple.value4)
               && func(tuple.value5)
               && func(tuple.value6);

        public static bool All<T>(this (T value1, T value2, T value3, T value4, T value5) tuple, Func<T, bool> func)
              => func(tuple.value1)
              && func(tuple.value2)
              && func(tuple.value3)
              && func(tuple.value4)
              && func(tuple.value5);

        public static bool All<T>(this (T value1, T value2, T value3, T value4) tuple, Func<T, bool> func)
              => func(tuple.value1)
              && func(tuple.value2)
              && func(tuple.value3)
              && func(tuple.value4);

        public static bool All<T>(this (T value1, T value2, T value3) tuple, Func<T, bool> func)
              => func(tuple.value1)
              && func(tuple.value2)
              && func(tuple.value3);

        public static bool All<T>(this (T value1, T value2) tuple, Func<T, bool> func)
             => func(tuple.value1)
             && func(tuple.value2);

        #endregion

        #region Aggregate

        public static T Aggregate<T>(this (T value1, T value2, T value3, T value4, T value5, T value6, T value7) tuple, Func<T, T, T> func)
            => func(tuple.value7, func(tuple.value6, func(tuple.value5, func(tuple.value4, func(tuple.value3, func(tuple.value1, tuple.value2))))));

        public static T Aggregate<T>(this (T value1, T value2, T value3, T value4, T value5, T value6) tuple, Func<T, T, T> func)
            => func(tuple.value6, func(tuple.value5, func(tuple.value4, func(tuple.value3, func(tuple.value1, tuple.value2)))));

        public static T Aggregate<T>(this (T value1, T value2, T value3, T value4, T value5) tuple, Func<T, T, T> func)
            => func(tuple.value5, func(tuple.value4, func(tuple.value3, func(tuple.value1, tuple.value2))));

        public static T Aggregate<T>(this (T value1, T value2, T value3, T value4) tuple, Func<T, T, T> func)
            => func(tuple.value4, func(tuple.value3, func(tuple.value1, tuple.value2)));

        public static T Aggregate<T>(this (T value1, T value2, T value3) tuple, Func<T, T, T> func)
            => func(tuple.value3, func(tuple.value1, tuple.value2));

        public static T Aggregate<T>(this (T value1, T value2) tuple, Func<T, T, T> func)
           => func(tuple.value1, tuple.value2);

        public static U Aggregate<T, U>(this (T value1, T value2, T value3, T value4, T value5, T value6, T value7) tuple, Func<T, U, U> func, U value)
            => func(tuple.value7, func(tuple.value6, func(tuple.value5, func(tuple.value4, func(tuple.value3, func(tuple.value2, func(tuple.value1, value)))))));

        public static U Aggregate<T, U>(this (T value1, T value2, T value3, T value4, T value5, T value6) tuple, Func<T, U, U> func, U value)
            => func(tuple.value6, func(tuple.value5, func(tuple.value4, func(tuple.value3, func(tuple.value2, func(tuple.value1, value))))));

        public static U Aggregate<T, U>(this (T value1, T value2, T value3, T value4, T value5) tuple, Func<T, U, U> func, U value)
            => func(tuple.value5, func(tuple.value4, func(tuple.value3, func(tuple.value2, func(tuple.value1, value)))));

        public static U Aggregate<T, U>(this (T value1, T value2, T value3, T value4) tuple, Func<T, U, U> func, U value)
            => func(tuple.value4, func(tuple.value3, func(tuple.value2, func(tuple.value1, value))));

        public static U Aggregate<T, U>(this (T value1, T value2, T value3) tuple, Func<T, U, U> func, U value)
            => func(tuple.value3, func(tuple.value2, func(tuple.value1, value)));

        public static U Aggregate<T, U>(this (T value1, T value2) tuple, Func<T, U, U> func, U value)
            => func(tuple.value2, func(tuple.value1, value));

        #endregion

        #region AsEnumerable

        public static IEnumerable<T> AsEnumerable<T>(this (T value1, T value2, T value3, T value4, T value5, T value6, T value7) tuple)
        {
            yield return tuple.value1;
            yield return tuple.value2;
            yield return tuple.value3;
            yield return tuple.value4;
            yield return tuple.value5;
            yield return tuple.value6;
            yield return tuple.value7;
        }

        public static IEnumerable<T> AsEnumerable<T>(this (T value1, T value2, T value3, T value4, T value5, T value6) tuple)
        {
            yield return tuple.value1;
            yield return tuple.value2;
            yield return tuple.value3;
            yield return tuple.value4;
            yield return tuple.value5;
            yield return tuple.value6;
        }

        public static IEnumerable<T> AsEnumerable<T>(this (T value1, T value2, T value3, T value4, T value5) tuple)
        {
            yield return tuple.value1;
            yield return tuple.value2;
            yield return tuple.value3;
            yield return tuple.value4;
            yield return tuple.value5;
        }

        public static IEnumerable<T> AsEnumerable<T>(this (T value1, T value2, T value3, T value4) tuple)
        {
            yield return tuple.value1;
            yield return tuple.value2;
            yield return tuple.value3;
            yield return tuple.value4;
        }

        public static IEnumerable<T> AsEnumerable<T>(this (T value1, T value2, T value3) tuple)
        {
            yield return tuple.value1;
            yield return tuple.value2;
            yield return tuple.value3;
        }

        public static IEnumerable<T> AsEnumerable<T>(this (T value1, T value2) tuple)
        {
            yield return tuple.value1;
            yield return tuple.value2;
        }

        #endregion

        #region TryGetValue

        public static bool TryGetValue<T>(this (T value1, T value2, T value3, T value4, T value5, T value6, T value7) tuple, Func<T, bool> func, out T value)
        {
            if (func(tuple.value1)) { value = tuple.value1; return true; }
            if (func(tuple.value2)) { value = tuple.value2; return true; }
            if (func(tuple.value3)) { value = tuple.value3; return true; }
            if (func(tuple.value4)) { value = tuple.value4; return true; }
            if (func(tuple.value5)) { value = tuple.value5; return true; }
            if (func(tuple.value6)) { value = tuple.value6; return true; }
            if (func(tuple.value7)) { value = tuple.value7; return true; }

            value = default;
            return false;
        }

        public static bool TryGetValue<T>(this (T value1, T value2, T value3, T value4, T value5, T value6) tuple, Func<T, bool> func, out T value)
        {
            if (func(tuple.value1)) { value = tuple.value1; return true; }
            if (func(tuple.value2)) { value = tuple.value2; return true; }
            if (func(tuple.value3)) { value = tuple.value3; return true; }
            if (func(tuple.value4)) { value = tuple.value4; return true; }
            if (func(tuple.value5)) { value = tuple.value5; return true; }
            if (func(tuple.value6)) { value = tuple.value6; return true; }

            value = default;
            return false;
        }

        public static bool TryGetValue<T>(this (T value1, T value2, T value3, T value4, T value5) tuple, Func<T, bool> func, out T value)
        {
            if (func(tuple.value1)) { value = tuple.value1; return true; }
            if (func(tuple.value2)) { value = tuple.value2; return true; }
            if (func(tuple.value3)) { value = tuple.value3; return true; }
            if (func(tuple.value4)) { value = tuple.value4; return true; }
            if (func(tuple.value5)) { value = tuple.value5; return true; }

            value = default;
            return false;
        }

        public static bool TryGetValue<T>(this (T value1, T value2, T value3, T value4) tuple, Func<T, bool> func, out T value)
        {
            if (func(tuple.value1)) { value = tuple.value1; return true; }
            if (func(tuple.value2)) { value = tuple.value2; return true; }
            if (func(tuple.value3)) { value = tuple.value3; return true; }
            if (func(tuple.value4)) { value = tuple.value4; return true; }

            value = default;
            return false;
        }

        public static bool TryGetValue<T>(this (T value1, T value2, T value3) tuple, Func<T, bool> func, out T value)
        {
            if (func(tuple.value1)) { value = tuple.value1; return true; }
            if (func(tuple.value2)) { value = tuple.value2; return true; }
            if (func(tuple.value3)) { value = tuple.value3; return true; }

            value = default;
            return false;
        }

        public static bool TryGetValue<T>(this (T value1, T value2) tuple, Func<T, bool> func, out T value)
        {
            if (func(tuple.value1)) { value = tuple.value1; return true; }
            if (func(tuple.value2)) { value = tuple.value2; return true; }

            value = default;
            return false;
        }

        #endregion

        #region AsArray

        public static T[] AsArray<T>(this (T value1, T value2, T value3, T value4, T value5, T value6, T value7) tuple)
            => new T[] { tuple.value1, tuple.value2, tuple.value3, tuple.value4, tuple.value5, tuple.value6, tuple.value7 };

        public static T[] AsArray<T>(this (T value1, T value2, T value3, T value4, T value5, T value6) tuple)
            => new T[] { tuple.value1, tuple.value2, tuple.value3, tuple.value4, tuple.value5, tuple.value6 };

        public static T[] AsArray<T>(this (T value1, T value2, T value3, T value4, T value5) tuple)
            => new T[] { tuple.value1, tuple.value2, tuple.value3, tuple.value4, tuple.value5 };

        public static T[] AsArray<T>(this (T value1, T value2, T value3, T value4) tuple)
            => new T[] { tuple.value1, tuple.value2, tuple.value3, tuple.value4 };

        public static T[] AsArray<T>(this (T value1, T value2, T value3) tuple)
            => new T[] { tuple.value1, tuple.value2, tuple.value3 };

        public static T[] AsArray<T>(this (T value1, T value2) tuple)
            => new T[] { tuple.value1, tuple.value2 };

        #endregion

        #region ToArray

        public static T[] ToArray<T>(this (ICollection<T> value1, ICollection<T> value2, ICollection<T> value3, ICollection<T> value4, ICollection<T> value5, ICollection<T> value6, ICollection<T> value7) tuple)
        {
            var count = (tuple.value1.Count, tuple.value2.Count, tuple.value3.Count, tuple.value4.Count, tuple.value5.Count, tuple.value6.Count, tuple.value7.Count).Sum();
            if (count == 0) return Array.Empty<T>();
            T[] result = new T[count];

            tuple.value1.CopyTo(result, 0); count = tuple.value1.Count;
            tuple.value2.CopyTo(result, count); count += tuple.value2.Count;
            tuple.value3.CopyTo(result, count); count += tuple.value3.Count;
            tuple.value4.CopyTo(result, count); count += tuple.value4.Count;
            tuple.value5.CopyTo(result, count); count += tuple.value5.Count;
            tuple.value6.CopyTo(result, count); count += tuple.value6.Count;
            tuple.value7.CopyTo(result, count);
            return result;
        }

        public static T[] ToArray<T>(this (ICollection<T> value1, ICollection<T> value2, ICollection<T> value3, ICollection<T> value4, ICollection<T> value5, ICollection<T> value6) tuple)
        {
            var count = (tuple.value1.Count, tuple.value2.Count, tuple.value3.Count, tuple.value4.Count, tuple.value5.Count, tuple.value6.Count).Sum();
            if (count == 0) return Array.Empty<T>();
            T[] result = new T[count];

            tuple.value1.CopyTo(result, 0); count = tuple.value1.Count;
            tuple.value2.CopyTo(result, count); count += tuple.value2.Count;
            tuple.value3.CopyTo(result, count); count += tuple.value3.Count;
            tuple.value4.CopyTo(result, count); count += tuple.value4.Count;
            tuple.value5.CopyTo(result, count); count += tuple.value5.Count;
            tuple.value6.CopyTo(result, count);
            return result;
        }

        public static T[] ToArray<T>(this (ICollection<T> value1, ICollection<T> value2, ICollection<T> value3, ICollection<T> value4, ICollection<T> value5) tuple)
        {
            var count = (tuple.value1.Count, tuple.value2.Count, tuple.value3.Count, tuple.value4.Count, tuple.value5.Count).Sum();
            if (count == 0) return Array.Empty<T>();
            T[] result = new T[count];

            tuple.value1.CopyTo(result, 0); count = tuple.value1.Count;
            tuple.value2.CopyTo(result, count); count += tuple.value2.Count;
            tuple.value3.CopyTo(result, count); count += tuple.value3.Count;
            tuple.value4.CopyTo(result, count); count += tuple.value4.Count;
            tuple.value5.CopyTo(result, count);
            return result;
        }

        public static T[] ToArray<T>(this (ICollection<T> value1, ICollection<T> value2, ICollection<T> value3, ICollection<T> value4) tuple)
        {
            var count = (tuple.value1.Count, tuple.value2.Count, tuple.value3.Count, tuple.value4.Count).Sum();
            if (count == 0) return Array.Empty<T>();
            T[] result = new T[count];

            tuple.value1.CopyTo(result, 0); count = tuple.value1.Count;
            tuple.value2.CopyTo(result, count); count += tuple.value2.Count;
            tuple.value3.CopyTo(result, count); count += tuple.value3.Count;
            tuple.value4.CopyTo(result, count);
            return result;
        }

        public static T[] ToArray<T>(this (ICollection<T> value1, ICollection<T> value2, ICollection<T> value3) tuple)
        {
            var count = (tuple.value1.Count, tuple.value2.Count, tuple.value3.Count).Sum();
            if (count == 0) return Array.Empty<T>();
            T[] result = new T[count];

            tuple.value1.CopyTo(result, 0); count = tuple.value1.Count;
            tuple.value2.CopyTo(result, count); count += tuple.value2.Count;
            tuple.value3.CopyTo(result, count);
            return result;
        }

        public static T[] ToArray<T>(this (ICollection<T> value1, ICollection<T> value2) tuple)
        {
            var count = (tuple.value1.Count, tuple.value2.Count).Sum();
            if (count == 0) return Array.Empty<T>();
            T[] result = new T[count];

            tuple.value1.CopyTo(result, 0);
            tuple.value2.CopyTo(result, tuple.value1.Count);
            return result;
        }

        public static T[] ToArray<T>(this (T[] value1, T[] value2, T[] value3, T[] value4, T[] value5, T[] value6, T[] value7) tuple)
        {
            var length = (tuple.value1.Length, tuple.value2.Length, tuple.value3.Length, tuple.value4.Length, tuple.value5.Length, tuple.value6.Length, tuple.value7.Length).Sum();
            if (length == 0) return Array.Empty<T>();
            T[] result = new T[length];

            Array.Copy(tuple.value1, 0, result, 0, tuple.value1.Length); length = tuple.value1.Length;
            Array.Copy(tuple.value2, 0, result, length, tuple.value2.Length); length += tuple.value2.Length;
            Array.Copy(tuple.value3, 0, result, length, tuple.value3.Length); length += tuple.value3.Length;
            Array.Copy(tuple.value4, 0, result, length, tuple.value4.Length); length += tuple.value4.Length;
            Array.Copy(tuple.value5, 0, result, length, tuple.value5.Length); length += tuple.value5.Length;
            Array.Copy(tuple.value6, 0, result, length, tuple.value6.Length); length += tuple.value6.Length;
            Array.Copy(tuple.value7, 0, result, length, tuple.value7.Length);
            return result;
        }

        public static T[] ToArray<T>(this (T[] value1, T[] value2, T[] value3, T[] value4, T[] value5, T[] value6) tuple)
        {
            var length = (tuple.value1.Length, tuple.value2.Length, tuple.value3.Length, tuple.value4.Length, tuple.value5.Length, tuple.value6.Length).Sum();
            if (length == 0) return Array.Empty<T>();
            T[] result = new T[length];

            Array.Copy(tuple.value1, 0, result, 0, tuple.value1.Length); length = tuple.value1.Length;
            Array.Copy(tuple.value2, 0, result, length, tuple.value2.Length); length += tuple.value2.Length;
            Array.Copy(tuple.value3, 0, result, length, tuple.value3.Length); length += tuple.value3.Length;
            Array.Copy(tuple.value4, 0, result, length, tuple.value4.Length); length += tuple.value4.Length;
            Array.Copy(tuple.value5, 0, result, length, tuple.value5.Length); length += tuple.value5.Length;
            Array.Copy(tuple.value6, 0, result, length, tuple.value6.Length);
            return result;
        }

        public static T[] ToArray<T>(this (T[] value1, T[] value2, T[] value3, T[] value4, T[] value5) tuple)
        {
            var length = (tuple.value1.Length, tuple.value2.Length, tuple.value3.Length, tuple.value4.Length, tuple.value5.Length).Sum();
            if (length == 0) return Array.Empty<T>();
            T[] result = new T[length];

            Array.Copy(tuple.value1, 0, result, 0, tuple.value1.Length); length = tuple.value1.Length;
            Array.Copy(tuple.value2, 0, result, length, tuple.value2.Length); length += tuple.value2.Length;
            Array.Copy(tuple.value3, 0, result, length, tuple.value3.Length); length += tuple.value3.Length;
            Array.Copy(tuple.value4, 0, result, length, tuple.value4.Length); length += tuple.value4.Length;
            Array.Copy(tuple.value5, 0, result, length, tuple.value5.Length);
            return result;
        }

        public static T[] ToArray<T>(this (T[] value1, T[] value2, T[] value3, T[] value4) tuple)
        {
            var length = (tuple.value1.Length, tuple.value2.Length, tuple.value3.Length, tuple.value4.Length).Sum();
            if (length == 0) return Array.Empty<T>();
            T[] result = new T[length];

            Array.Copy(tuple.value1, 0, result, 0, tuple.value1.Length); length = tuple.value1.Length;
            Array.Copy(tuple.value2, 0, result, length, tuple.value2.Length); length += tuple.value2.Length;
            Array.Copy(tuple.value3, 0, result, length, tuple.value3.Length); length += tuple.value3.Length;
            Array.Copy(tuple.value4, 0, result, length, tuple.value4.Length);
            return result;
        }

        public static T[] ToArray<T>(this (T[] value1, T[] value2, T[] value3) tuple)
        {
            var length = (tuple.value1.Length, tuple.value2.Length, tuple.value3.Length).Sum();
            if (length == 0) return Array.Empty<T>();
            T[] result = new T[length];

            Array.Copy(tuple.value1, 0, result, 0, tuple.value1.Length); length = tuple.value1.Length;
            Array.Copy(tuple.value2, 0, result, length, tuple.value2.Length); length += tuple.value2.Length;
            Array.Copy(tuple.value3, 0, result, length, tuple.value3.Length);
            return result;
        }

        public static T[] ToArray<T>(this (T[] value1, T[] value2) tuple)
        {
            var length = (tuple.value1.Length, tuple.value2.Length).Sum();
            if (length == 0) return Array.Empty<T>();
            T[] result = new T[length];

            Array.Copy(tuple.value1, 0, result, 0, tuple.value1.Length); length = tuple.value1.Length;
            Array.Copy(tuple.value2, 0, result, length, tuple.value2.Length);
            return result;
        }

        #endregion        

        #region Sum

        public static int Sum(this (int value1, int value2, int value3, int value4, int value5, int value6, int value7) tuple)
            => tuple.value1 + tuple.value2 + tuple.value3 + tuple.value4 + tuple.value5 + tuple.value6 + tuple.value7;

        public static int Sum(this (int value1, int value2, int value3, int value4, int value5, int value6) tuple)
            => tuple.value1 + tuple.value2 + tuple.value3 + tuple.value4 + tuple.value5 + tuple.value6;

        public static int Sum(this (int value1, int value2, int value3, int value4, int value5) tuple)
            => tuple.value1 + tuple.value2 + tuple.value3 + tuple.value4 + tuple.value5;

        public static int Sum(this (int value1, int value2, int value3, int value4) tuple)
            => tuple.value1 + tuple.value2 + tuple.value3 + tuple.value4;

        public static int Sum(this (int value1, int value2, int value3) tuple)
            => tuple.value1 + tuple.value2 + tuple.value3;

        public static int Sum(this (int value1, int value2) tuple)
            => tuple.value1 + tuple.value2;

        public static uint Sum(this (uint value1, uint value2, uint value3, uint value4, uint value5, uint value6, uint value7) tuple)
            => tuple.value1 + tuple.value2 + tuple.value3 + tuple.value4 + tuple.value5 + tuple.value6 + tuple.value7;

        public static uint Sum(this (uint value1, uint value2, uint value3, uint value4, uint value5, uint value6) tuple)
            => tuple.value1 + tuple.value2 + tuple.value3 + tuple.value4 + tuple.value5 + tuple.value6;

        public static uint Sum(this (uint value1, uint value2, uint value3, uint value4, uint value5) tuple)
            => tuple.value1 + tuple.value2 + tuple.value3 + tuple.value4 + tuple.value5;

        public static uint Sum(this (uint value1, uint value2, uint value3, uint value4) tuple)
            => tuple.value1 + tuple.value2 + tuple.value3 + tuple.value4;

        public static uint Sum(this (uint value1, uint value2, uint value3) tuple)
            => tuple.value1 + tuple.value2 + tuple.value3;

        public static uint Sum(this (uint value1, uint value2) tuple)
            => tuple.value1 + tuple.value2;

        public static long Sum(this (long value1, int value2, int value3, int value4, int value5, int value6, int value7) tuple)
            => tuple.value1 + tuple.value2 + tuple.value3 + tuple.value4 + tuple.value5 + tuple.value6 + tuple.value7;

        public static long Sum(this (long value1, int value2, int value3, int value4, int value5, int value6) tuple)
            => tuple.value1 + tuple.value2 + tuple.value3 + tuple.value4 + tuple.value5 + tuple.value6;

        public static long Sum(this (long value1, int value2, int value3, int value4, int value5) tuple)
            => tuple.value1 + tuple.value2 + tuple.value3 + tuple.value4 + tuple.value5;

        public static long Sum(this (long value1, int value2, int value3, int value4) tuple)
            => tuple.value1 + tuple.value2 + tuple.value3 + tuple.value4;

        public static long Sum(this (long value1, int value2, int value3) tuple)
            => tuple.value1 + tuple.value2 + tuple.value3;

        public static long Sum(this (long value1, int value2) tuple)
            => tuple.value1 + tuple.value2;

        public static ulong Sum(this (ulong value1, uint value2, uint value3, uint value4, uint value5, uint value6, uint value7) tuple)
            => tuple.value1 + tuple.value2 + tuple.value3 + tuple.value4 + tuple.value5 + tuple.value6 + tuple.value7;

        public static ulong Sum(this (ulong value1, uint value2, uint value3, uint value4, uint value5, uint value6) tuple)
            => tuple.value1 + tuple.value2 + tuple.value3 + tuple.value4 + tuple.value5 + tuple.value6;

        public static ulong Sum(this (ulong value1, uint value2, uint value3, uint value4, uint value5) tuple)
            => tuple.value1 + tuple.value2 + tuple.value3 + tuple.value4 + tuple.value5;

        public static ulong Sum(this (ulong value1, uint value2, uint value3, uint value4) tuple)
            => tuple.value1 + tuple.value2 + tuple.value3 + tuple.value4;

        public static ulong Sum(this (ulong value1, uint value2, uint value3) tuple)
            => tuple.value1 + tuple.value2 + tuple.value3;

        public static ulong Sum(this (ulong value1, uint value2) tuple)
            => tuple.value1 + tuple.value2;

        public static int Sum(this (short value1, short value2, short value3, short value4, short value5, short value6, short value7) tuple)
            => tuple.value1 + tuple.value2 + tuple.value3 + tuple.value4 + tuple.value5 + tuple.value6 + tuple.value7;

        public static int Sum(this (short value1, short value2, short value3, short value4, short value5, short value6) tuple)
            => tuple.value1 + tuple.value2 + tuple.value3 + tuple.value4 + tuple.value5 + tuple.value6;

        public static int Sum(this (short value1, short value2, short value3, short value4, short value5) tuple)
            => tuple.value1 + tuple.value2 + tuple.value3 + tuple.value4 + tuple.value5;

        public static int Sum(this (short value1, short value2, short value3, short value4) tuple)
            => tuple.value1 + tuple.value2 + tuple.value3 + tuple.value4;

        public static int Sum(this (short value1, short value2, short value3) tuple)
            => tuple.value1 + tuple.value2 + tuple.value3;

        public static int Sum(this (short value1, short value2) tuple)
            => tuple.value1 + tuple.value2;

        public static int Sum(this (ushort value1, ushort value2, ushort value3, ushort value4, ushort value5, ushort value6, ushort value7) tuple)
            => tuple.value1 + tuple.value2 + tuple.value3 + tuple.value4 + tuple.value5 + tuple.value6 + tuple.value7;

        public static int Sum(this (ushort value1, ushort value2, ushort value3, ushort value4, ushort value5, ushort value6) tuple)
            => tuple.value1 + tuple.value2 + tuple.value3 + tuple.value4 + tuple.value5 + tuple.value6;

        public static int Sum(this (ushort value1, ushort value2, ushort value3, ushort value4, ushort value5) tuple)
            => tuple.value1 + tuple.value2 + tuple.value3 + tuple.value4 + tuple.value5;

        public static int Sum(this (ushort value1, ushort value2, ushort value3, ushort value4) tuple)
            => tuple.value1 + tuple.value2 + tuple.value3 + tuple.value4;

        public static int Sum(this (ushort value1, ushort value2, ushort value3) tuple)
            => tuple.value1 + tuple.value2 + tuple.value3;

        public static int Sum(this (ushort value1, ushort value2) tuple)
            => tuple.value1 + tuple.value2;

        public static int Sum(this (byte value1, byte value2, byte value3, byte value4, byte value5, byte value6, byte value7) tuple)
            => tuple.value1 + tuple.value2 + tuple.value3 + tuple.value4 + tuple.value5 + tuple.value6 + tuple.value7;

        public static int Sum(this (byte value1, byte value2, byte value3, byte value4, byte value5, byte value6) tuple)
            => tuple.value1 + tuple.value2 + tuple.value3 + tuple.value4 + tuple.value5 + tuple.value6;

        public static int Sum(this (byte value1, byte value2, byte value3, byte value4, byte value5) tuple)
            => tuple.value1 + tuple.value2 + tuple.value3 + tuple.value4 + tuple.value5;

        public static int Sum(this (byte value1, byte value2, byte value3, byte value4) tuple)
            => tuple.value1 + tuple.value2 + tuple.value3 + tuple.value4;

        public static int Sum(this (byte value1, byte value2, byte value3) tuple)
            => tuple.value1 + tuple.value2 + tuple.value3;

        public static int Sum(this (byte value1, byte value2) tuple)
            => tuple.value1 + tuple.value2;

        public static int Sum(this (sbyte value1, sbyte value2, sbyte value3, sbyte value4, sbyte value5, sbyte value6, sbyte value7) tuple)
            => tuple.value1 + tuple.value2 + tuple.value3 + tuple.value4 + tuple.value5 + tuple.value6 + tuple.value7;

        public static int Sum(this (sbyte value1, sbyte value2, sbyte value3, sbyte value4, sbyte value5, sbyte value6) tuple)
            => tuple.value1 + tuple.value2 + tuple.value3 + tuple.value4 + tuple.value5 + tuple.value6;

        public static int Sum(this (sbyte value1, sbyte value2, sbyte value3, sbyte value4, sbyte value5) tuple)
            => tuple.value1 + tuple.value2 + tuple.value3 + tuple.value4 + tuple.value5;

        public static int Sum(this (sbyte value1, sbyte value2, sbyte value3, sbyte value4) tuple)
            => tuple.value1 + tuple.value2 + tuple.value3 + tuple.value4;

        public static int Sum(this (sbyte value1, sbyte value2, sbyte value3) tuple)
            => tuple.value1 + tuple.value2 + tuple.value3;

        public static int Sum(this (sbyte value1, sbyte value2) tuple)
            => tuple.value1 + tuple.value2;

        #endregion

        #region Cast

        public static (T, T, T, T, T, T, T) Cast<T, U>(this (U value1, U value2, U value3, U value4, U value5, U value6, U value7) tuple)
            => ((T)(object)tuple.value1, (T)(object)tuple.value2, (T)(object)tuple.value3, (T)(object)tuple.value4, (T)(object)tuple.value5, (T)(object)tuple.value6, (T)(object)tuple.value7);

        public static (T, T, T, T, T, T) Cast<T, U>(this (U value1, U value2, U value3, U value4, U value5, U value6) tuple)
            => ((T)(object)tuple.value1, (T)(object)tuple.value2, (T)(object)tuple.value3, (T)(object)tuple.value4, (T)(object)tuple.value5, (T)(object)tuple.value6);

        public static (T, T, T, T, T) Cast<T, U>(this (U value1, U value2, U value3, U value4, U value5) tuple)
            => ((T)(object)tuple.value1, (T)(object)tuple.value2, (T)(object)tuple.value3, (T)(object)tuple.value4, (T)(object)tuple.value5);

        public static (T, T, T, T) Cast<T, U>(this (U value1, U value2, U value3, U value4) tuple)
            => ((T)(object)tuple.value1, (T)(object)tuple.value2, (T)(object)tuple.value3, (T)(object)tuple.value4);

        public static (T, T, T) Cast<T, U>(this (U value1, U value2, U value3) tuple)
            => ((T)(object)tuple.value1, (T)(object)tuple.value2, (T)(object)tuple.value3);

        public static (T, T) Cast<T, U>(this (U value1, U value2) tuple)
           => ((T)(object)tuple.value1, (T)(object)tuple.value2);

        #endregion

        #region As

        public static (T, T, T, T, T, T, T) As<U, T>(this (U value1, U value2, U value3, U value4, U value5, U value6, U value7) tuple) where T : class
            => (tuple.value1 as T, tuple.value2 as T, tuple.value3 as T, tuple.value4 as T, tuple.value5 as T, tuple.value6 as T, tuple.value7 as T);

        public static (T, T, T, T, T, T) As<U, T>(this (U value1, U value2, U value3, U value4, U value5, U value6) tuple) where T : class
            => (tuple.value1 as T, tuple.value2 as T, tuple.value3 as T, tuple.value4 as T, tuple.value5 as T, tuple.value6 as T);

        public static (T, T, T, T, T) As<U, T>(this (U value1, U value2, U value3, U value4, U value5) tuple) where T : class
            => (tuple.value1 as T, tuple.value2 as T, tuple.value3 as T, tuple.value4 as T, tuple.value5 as T);

        public static (T, T, T, T) As<U, T>(this (U value1, U value2, U value3, U value4) tuple) where T : class
            => (tuple.value1 as T, tuple.value2 as T, tuple.value3 as T, tuple.value4 as T);

        public static (T, T, T) As<U, T>(this (U value1, U value2, U value3) tuple) where T : class
            => (tuple.value1 as T, tuple.value2 as T, tuple.value3 as T);

        public static (T, T) As<U, T>(this (U value1, U value2) tuple) where T : class
            => (tuple.value1 as T, tuple.value2 as T);

        #endregion
    }
}

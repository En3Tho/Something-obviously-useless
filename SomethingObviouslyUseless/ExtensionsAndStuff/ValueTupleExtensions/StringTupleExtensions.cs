using System;
using System.Runtime.CompilerServices;

namespace ExtensionsAndStuff.ValueTupleExtensions
{
    public static class StringTupleExtensions
    {
        #region StringEqualsAny

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool EqualsAny(this string s, (string, string, string, string, string, string, string) tuple, StringComparison comparison = StringComparison.Ordinal)
        {
            return s.Equals(tuple.Item1, comparison)
                   || s.Equals(tuple.Item2, comparison)
                   || s.Equals(tuple.Item3, comparison)
                   || s.Equals(tuple.Item4, comparison)
                   || s.Equals(tuple.Item5, comparison)
                   || s.Equals(tuple.Item6, comparison)
                   || s.Equals(tuple.Item7, comparison);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool EqualsAny(this string s, (string, string, string, string, string, string) tuple, StringComparison comparison = StringComparison.Ordinal)
        {
            return s.Equals(tuple.Item1, comparison)
                   || s.Equals(tuple.Item2, comparison)
                   || s.Equals(tuple.Item3, comparison)
                   || s.Equals(tuple.Item4, comparison)
                   || s.Equals(tuple.Item5, comparison)
                   || s.Equals(tuple.Item6, comparison);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool EqualsAny(this string s, (string, string, string, string, string) tuple, StringComparison comparison = StringComparison.Ordinal)
        {
            return s.Equals(tuple.Item1, comparison)
                   || s.Equals(tuple.Item2, comparison)
                   || s.Equals(tuple.Item3, comparison)
                   || s.Equals(tuple.Item4, comparison)
                   || s.Equals(tuple.Item5, comparison);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool EqualsAny(this string s, (string, string, string, string) tuple, StringComparison comparison = StringComparison.Ordinal)
        {
            return s.Equals(tuple.Item1, comparison)
                   || s.Equals(tuple.Item2, comparison)
                   || s.Equals(tuple.Item3, comparison)
                   || s.Equals(tuple.Item4, comparison);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool EqualsAny(this string s, (string, string, string) tuple, StringComparison comparison = StringComparison.Ordinal)
        {
            return s.Equals(tuple.Item1, comparison)
                   || s.Equals(tuple.Item2, comparison)
                   || s.Equals(tuple.Item3, comparison);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool EqualsAny(this string s, (string, string) tuple, StringComparison comparison = StringComparison.Ordinal)
        {
            return s.Equals(tuple.Item1, comparison)
                   || s.Equals(tuple.Item2, comparison);
        }

        #endregion

        #region StringTupleEqualsStringTuple

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Equals(this (string, string, string, string, string, string, string) tuple, (string, string, string, string, string, string, string) tuple2,
            StringComparison comparison = StringComparison.Ordinal)
        {
            return tuple.Item1.Equals(tuple2.Item1, comparison)
                   || tuple.Item2.Equals(tuple2.Item2, comparison)
                   || tuple.Item3.Equals(tuple2.Item3, comparison)
                   || tuple.Item4.Equals(tuple2.Item4, comparison)
                   || tuple.Item5.Equals(tuple2.Item5, comparison)
                   || tuple.Item6.Equals(tuple2.Item6, comparison)
                   || tuple.Item7.Equals(tuple2.Item7, comparison);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Equals(this (string, string, string, string, string, string) tuple, (string, string, string, string, string, string) tuple2,
            StringComparison comparison = StringComparison.Ordinal)
        {
            return tuple.Item1.Equals(tuple2.Item1, comparison)
                   || tuple.Item2.Equals(tuple2.Item2, comparison)
                   || tuple.Item3.Equals(tuple2.Item3, comparison)
                   || tuple.Item4.Equals(tuple2.Item4, comparison)
                   || tuple.Item5.Equals(tuple2.Item5, comparison)
                   || tuple.Item6.Equals(tuple2.Item6, comparison);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Equals(this (string, string, string, string, string) tuple, (string, string, string, string, string) tuple2, StringComparison comparison = StringComparison.Ordinal)
        {
            return tuple.Item1.Equals(tuple2.Item1, comparison)
                   || tuple.Item2.Equals(tuple2.Item2, comparison)
                   || tuple.Item3.Equals(tuple2.Item3, comparison)
                   || tuple.Item4.Equals(tuple2.Item4, comparison)
                   || tuple.Item5.Equals(tuple2.Item5, comparison);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Equals(this (string, string, string, string) tuple, (string, string, string, string) tuple2, StringComparison comparison = StringComparison.Ordinal)
        {
            return tuple.Item1.Equals(tuple2.Item1, comparison)
                   || tuple.Item2.Equals(tuple2.Item2, comparison)
                   || tuple.Item3.Equals(tuple2.Item3, comparison)
                   || tuple.Item4.Equals(tuple2.Item4, comparison);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Equals(this (string, string, string) tuple, (string, string, string) tuple2, StringComparison comparison = StringComparison.Ordinal)
        {
            return tuple.Item1.Equals(tuple2.Item1, comparison)
                   || tuple.Item2.Equals(tuple2.Item2, comparison)
                   || tuple.Item3.Equals(tuple2.Item3, comparison);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Equals(this (string, string) tuple, (string, string) tuple2, StringComparison comparison = StringComparison.Ordinal)
        {
            return tuple.Item1.Equals(tuple2.Item1, comparison)
                   || tuple.Item2.Equals(tuple2.Item2, comparison);
        }

        #endregion

        #region StringStartsWithAny

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool StartsWithAny(this string s, (string, string, string, string, string, string, string) tuple, StringComparison comparison = StringComparison.Ordinal)
        {
            return s.StartsWith(tuple.Item1, comparison)
                   || s.StartsWith(tuple.Item2, comparison)
                   || s.StartsWith(tuple.Item3, comparison)
                   || s.StartsWith(tuple.Item4, comparison)
                   || s.StartsWith(tuple.Item5, comparison)
                   || s.StartsWith(tuple.Item6, comparison)
                   || s.StartsWith(tuple.Item7, comparison);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool StartsWithAny(this string s, (string, string, string, string, string, string) tuple, StringComparison comparison = StringComparison.Ordinal)
        {
            return s.StartsWith(tuple.Item1, comparison)
                   || s.StartsWith(tuple.Item2, comparison)
                   || s.StartsWith(tuple.Item3, comparison)
                   || s.StartsWith(tuple.Item4, comparison)
                   || s.StartsWith(tuple.Item5, comparison)
                   || s.StartsWith(tuple.Item6, comparison);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool StartsWithAny(this string s, (string, string, string, string, string) tuple, StringComparison comparison = StringComparison.Ordinal)
        {
            return s.StartsWith(tuple.Item1, comparison)
                   || s.StartsWith(tuple.Item2, comparison)
                   || s.StartsWith(tuple.Item3, comparison)
                   || s.StartsWith(tuple.Item4, comparison)
                   || s.StartsWith(tuple.Item5, comparison);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool StartsWithAny(this string s, (string, string, string, string) tuple, StringComparison comparison = StringComparison.Ordinal)
        {
            return s.StartsWith(tuple.Item1, comparison)
                   || s.StartsWith(tuple.Item2, comparison)
                   || s.StartsWith(tuple.Item3, comparison)
                   || s.StartsWith(tuple.Item4, comparison);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool StartsWithAny(this string s, (string, string, string) tuple, StringComparison comparison = StringComparison.Ordinal)
        {
            return s.StartsWith(tuple.Item1, comparison)
                   || s.StartsWith(tuple.Item2, comparison)
                   || s.StartsWith(tuple.Item3, comparison);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool StartsWithAny(this string s, (string, string) tuple, StringComparison comparison = StringComparison.Ordinal)
        {
            return s.StartsWith(tuple.Item1, comparison)
                   || s.StartsWith(tuple.Item2, comparison);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool StartsWithAny(this string s, (char, char, char, char, char, char, char) tuple)
        {
            return s.StartsWith(tuple.Item1)
                   || s.StartsWith(tuple.Item2)
                   || s.StartsWith(tuple.Item3)
                   || s.StartsWith(tuple.Item4)
                   || s.StartsWith(tuple.Item5)
                   || s.StartsWith(tuple.Item6)
                   || s.StartsWith(tuple.Item7);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool StartsWithAny(this string s, (char, char, char, char, char, char) tuple)
        {
            return s.StartsWith(tuple.Item1)
                   || s.StartsWith(tuple.Item2)
                   || s.StartsWith(tuple.Item3)
                   || s.StartsWith(tuple.Item4)
                   || s.StartsWith(tuple.Item5)
                   || s.StartsWith(tuple.Item6);
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool StartsWithAny(this string s, (char, char, char, char, char) tuple)
        {
            return s.StartsWith(tuple.Item1)
                   || s.StartsWith(tuple.Item2)
                   || s.StartsWith(tuple.Item3)
                   || s.StartsWith(tuple.Item4)
                   || s.StartsWith(tuple.Item5);
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool StartsWithAny(this string s, (char, char, char, char) tuple)
        {
            return s.StartsWith(tuple.Item1)
                   || s.StartsWith(tuple.Item2)
                   || s.StartsWith(tuple.Item3)
                   || s.StartsWith(tuple.Item4);
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool StartsWithAny(this string s, (char, char, char) tuple)
        {
            return s.StartsWith(tuple.Item1)
                   || s.StartsWith(tuple.Item2)
                   || s.StartsWith(tuple.Item3);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool StartsWithAny(this string s, (char, char) tuple)
        {
            return s.StartsWith(tuple.Item1)
                   || s.StartsWith(tuple.Item2);
        }

        #endregion

        #region StringEndsWithAny

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool EndsWithAny(this string s, (string, string, string, string, string, string, string) tuple, StringComparison comparison = StringComparison.Ordinal)
        {
            return s.EndsWith(tuple.Item1, comparison)
                   || s.EndsWith(tuple.Item2, comparison)
                   || s.EndsWith(tuple.Item3, comparison)
                   || s.EndsWith(tuple.Item4, comparison)
                   || s.EndsWith(tuple.Item5, comparison)
                   || s.EndsWith(tuple.Item6, comparison)
                   || s.EndsWith(tuple.Item7, comparison);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool EndsWithAny(this string s, (string, string, string, string, string, string) tuple, StringComparison comparison = StringComparison.Ordinal)
        {
            return s.EndsWith(tuple.Item1, comparison)
                   || s.EndsWith(tuple.Item2, comparison)
                   || s.EndsWith(tuple.Item3, comparison)
                   || s.EndsWith(tuple.Item4, comparison)
                   || s.EndsWith(tuple.Item5, comparison)
                   || s.EndsWith(tuple.Item6, comparison);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool EndsWithAny(this string s, (string, string, string, string, string) tuple, StringComparison comparison = StringComparison.Ordinal)
        {
            return s.EndsWith(tuple.Item1, comparison)
                   || s.EndsWith(tuple.Item2, comparison)
                   || s.EndsWith(tuple.Item3, comparison)
                   || s.EndsWith(tuple.Item4, comparison)
                   || s.EndsWith(tuple.Item5, comparison);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool EndsWithAny(this string s, (string, string, string, string) tuple, StringComparison comparison = StringComparison.Ordinal)
        {
            return s.EndsWith(tuple.Item1, comparison)
                   || s.EndsWith(tuple.Item2, comparison)
                   || s.EndsWith(tuple.Item3, comparison)
                   || s.EndsWith(tuple.Item4, comparison);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool EndsWithAny(this string s, (string, string, string) tuple, StringComparison comparison = StringComparison.Ordinal)
        {
            return s.EndsWith(tuple.Item1, comparison)
                   || s.EndsWith(tuple.Item2, comparison)
                   || s.EndsWith(tuple.Item3, comparison);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool EndsWithAny(this string s, (string, string) tuple, StringComparison comparison = StringComparison.Ordinal)
        {
            return s.EndsWith(tuple.Item1, comparison)
                   || s.EndsWith(tuple.Item2, comparison);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool EndsWithAny(this string s, (char, char, char, char, char, char, char) tuple)
        {
            return s.EndsWith(tuple.Item1)
                   || s.EndsWith(tuple.Item2)
                   || s.EndsWith(tuple.Item3)
                   || s.EndsWith(tuple.Item4)
                   || s.EndsWith(tuple.Item5)
                   || s.EndsWith(tuple.Item6)
                   || s.EndsWith(tuple.Item7);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool EndsWithAny(this string s, (char, char, char, char, char, char) tuple)
        {
            return s.EndsWith(tuple.Item1)
                   || s.EndsWith(tuple.Item2)
                   || s.EndsWith(tuple.Item3)
                   || s.EndsWith(tuple.Item4)
                   || s.EndsWith(tuple.Item5)
                   || s.EndsWith(tuple.Item6);
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool EndsWithAny(this string s, (char, char, char, char, char) tuple)
        {
            return s.EndsWith(tuple.Item1)
                   || s.EndsWith(tuple.Item2)
                   || s.EndsWith(tuple.Item3)
                   || s.EndsWith(tuple.Item4)
                   || s.EndsWith(tuple.Item5);
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool EndsWithAny(this string s, (char, char, char, char) tuple)
        {
            return s.EndsWith(tuple.Item1)
                   || s.EndsWith(tuple.Item2)
                   || s.EndsWith(tuple.Item3)
                   || s.EndsWith(tuple.Item4);
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool EndsWithAny(this string s, (char, char, char) tuple)
        {
            return s.EndsWith(tuple.Item1)
                   || s.EndsWith(tuple.Item2)
                   || s.EndsWith(tuple.Item3);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool EndsWithAny(this string s, (char, char) tuple)
        {
            return s.EndsWith(tuple.Item1)
                   || s.EndsWith(tuple.Item2);
        }
        
        #endregion

        #region ContainedByAny

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool ContainedByAny(this string s, (string, string, string, string, string, string, string) tuple, StringComparison comparison = StringComparison.Ordinal)
        {
            return tuple.Item1.Contains(s, comparison)
                   || tuple.Item2.Contains(s, comparison)
                   || tuple.Item3.Contains(s, comparison)
                   || tuple.Item4.Contains(s, comparison)
                   || tuple.Item5.Contains(s, comparison)
                   || tuple.Item6.Contains(s, comparison)
                   || tuple.Item7.Contains(s, comparison);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool ContainedByAny(this string s, (string, string, string, string, string, string) tuple, StringComparison comparison = StringComparison.Ordinal)
        {
            return tuple.Item1.Contains(s, comparison)
                   || tuple.Item2.Contains(s, comparison)
                   || tuple.Item3.Contains(s, comparison)
                   || tuple.Item4.Contains(s, comparison)
                   || tuple.Item5.Contains(s, comparison)
                   || tuple.Item6.Contains(s, comparison);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool ContainedByAny(this string s, (string, string, string, string, string) tuple, StringComparison comparison = StringComparison.Ordinal)
        {
            return tuple.Item1.Contains(s, comparison)
                   || tuple.Item2.Contains(s, comparison)
                   || tuple.Item3.Contains(s, comparison)
                   || tuple.Item4.Contains(s, comparison)
                   || tuple.Item5.Contains(s, comparison);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool ContainedByAny(this string s, (string, string, string, string) tuple, StringComparison comparison = StringComparison.Ordinal)
        {
            return tuple.Item1.Contains(s, comparison)
                   || tuple.Item2.Contains(s, comparison)
                   || tuple.Item3.Contains(s, comparison)
                   || tuple.Item4.Contains(s, comparison);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool ContainedByAny(this string s, (string, string, string) tuple, StringComparison comparison = StringComparison.Ordinal)
        {
            return tuple.Item1.Contains(s, comparison)
                   || tuple.Item2.Contains(s, comparison)
                   || tuple.Item3.Contains(s, comparison);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool ContainedByAny(this string s, (string, string) tuple, StringComparison comparison = StringComparison.Ordinal)
        {
            return tuple.Item1.Contains(s, comparison)
                   || tuple.Item2.Contains(s, comparison);
        }

        #endregion
    }
}
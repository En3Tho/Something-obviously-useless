using System;
using System.Runtime.CompilerServices;

namespace En3Tho.ValueTupleExtensions
{
    public static partial class StringToValueTupleExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool EqualsAny(this string s, (string, string, string, string, string, string, string) tuple, StringComparison comparison = StringComparison.Ordinal) 
            => s.Equals(tuple.Item1, comparison)
               || s.Equals(tuple.Item2, comparison)
               || s.Equals(tuple.Item3, comparison)
               || s.Equals(tuple.Item4, comparison)
               || s.Equals(tuple.Item5, comparison)
               || s.Equals(tuple.Item6, comparison)
               || s.Equals(tuple.Item7, comparison);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool EqualsAny(this string s, (string, string, string, string, string, string) tuple, StringComparison comparison = StringComparison.Ordinal) 
            => s.Equals(tuple.Item1, comparison)
               || s.Equals(tuple.Item2, comparison)
               || s.Equals(tuple.Item3, comparison)
               || s.Equals(tuple.Item4, comparison)
               || s.Equals(tuple.Item5, comparison)
               || s.Equals(tuple.Item6, comparison);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool EqualsAny(this string s, (string, string, string, string, string) tuple, StringComparison comparison = StringComparison.Ordinal)
            => s.Equals(tuple.Item1, comparison)
               || s.Equals(tuple.Item2, comparison)
               || s.Equals(tuple.Item3, comparison)
               || s.Equals(tuple.Item4, comparison)
               || s.Equals(tuple.Item5, comparison);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool EqualsAny(this string s, (string, string, string, string) tuple, StringComparison comparison = StringComparison.Ordinal)
            => s.Equals(tuple.Item1, comparison)
               || s.Equals(tuple.Item2, comparison)
               || s.Equals(tuple.Item3, comparison)
               || s.Equals(tuple.Item4, comparison);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool EqualsAny(this string s, (string, string, string) tuple, StringComparison comparison = StringComparison.Ordinal)
            => s.Equals(tuple.Item1, comparison)
               || s.Equals(tuple.Item2, comparison)
               || s.Equals(tuple.Item3, comparison);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool EqualsAny(this string s, (string, string) tuple, StringComparison comparison = StringComparison.Ordinal)
            => s.Equals(tuple.Item1, comparison)
               || s.Equals(tuple.Item2, comparison);
    }
}
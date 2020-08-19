using System;
using System.Runtime.CompilerServices;

namespace En3Tho.ValueTupleExtensions.StringExtensions
{
    public static partial class StringToValueTupleExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool ContainsAny(this string s, (string, string, string, string, string, string, string) tuple, StringComparison comparison = StringComparison.Ordinal)
#if !NETSTANDARD2_0
            => s.Contains(tuple.Item1, comparison)
            || s.Contains(tuple.Item2, comparison)
            || s.Contains(tuple.Item3, comparison)
            || s.Contains(tuple.Item4, comparison)
            || s.Contains(tuple.Item5, comparison)
            || s.Contains(tuple.Item6, comparison)
            || s.Contains(tuple.Item7, comparison);
#else
            => s.IndexOf(tuple.Item1, comparison) > -1
            || s.IndexOf(tuple.Item2, comparison) > -1
            || s.IndexOf(tuple.Item3, comparison) > -1
            || s.IndexOf(tuple.Item4, comparison) > -1
            || s.IndexOf(tuple.Item5, comparison) > -1
            || s.IndexOf(tuple.Item6, comparison) > -1
            || s.IndexOf(tuple.Item7, comparison) > -1;
#endif

#if !NETSTANDARD2_0
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool ContainsAny(this string s, (char, char, char, char, char, char, char) tuple, StringComparison comparison = StringComparison.Ordinal)
            => s.Contains(tuple.Item1, comparison)
            || s.Contains(tuple.Item2, comparison)
            || s.Contains(tuple.Item3, comparison)
            || s.Contains(tuple.Item4, comparison)
            || s.Contains(tuple.Item5, comparison)
            || s.Contains(tuple.Item6, comparison)
            || s.Contains(tuple.Item7, comparison);
#endif

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool ContainsAny(this string s, (string, string, string, string, string, string) tuple, StringComparison comparison = StringComparison.Ordinal)
#if !NETSTANDARD2_0
            => s.Contains(tuple.Item1, comparison)
            || s.Contains(tuple.Item2, comparison)
            || s.Contains(tuple.Item3, comparison)
            || s.Contains(tuple.Item4, comparison)
            || s.Contains(tuple.Item5, comparison)
            || s.Contains(tuple.Item6, comparison);
#else
            => s.IndexOf(tuple.Item1, comparison) > -1
            || s.IndexOf(tuple.Item2, comparison) > -1
            || s.IndexOf(tuple.Item3, comparison) > -1
            || s.IndexOf(tuple.Item4, comparison) > -1
            || s.IndexOf(tuple.Item5, comparison) > -1
            || s.IndexOf(tuple.Item6, comparison) > -1;
#endif

#if !NETSTANDARD2_0
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool ContainsAny(this string s, (char, char, char, char, char, char) tuple, StringComparison comparison = StringComparison.Ordinal)
            => s.Contains(tuple.Item1, comparison)
            || s.Contains(tuple.Item2, comparison)
            || s.Contains(tuple.Item3, comparison)
            || s.Contains(tuple.Item4, comparison)
            || s.Contains(tuple.Item5, comparison)
            || s.Contains(tuple.Item6, comparison);
#endif

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool ContainsAny(this string s, (string, string, string, string, string) tuple, StringComparison comparison = StringComparison.Ordinal)
#if !NETSTANDARD2_0
            => s.Contains(tuple.Item1, comparison)
            || s.Contains(tuple.Item2, comparison)
            || s.Contains(tuple.Item3, comparison)
            || s.Contains(tuple.Item4, comparison)
            || s.Contains(tuple.Item5, comparison);
#else
            => s.IndexOf(tuple.Item1, comparison) > -1
            || s.IndexOf(tuple.Item2, comparison) > -1
            || s.IndexOf(tuple.Item3, comparison) > -1
            || s.IndexOf(tuple.Item4, comparison) > -1
            || s.IndexOf(tuple.Item5, comparison) > -1;
#endif

#if !NETSTANDARD2_0
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool ContainsAny(this string s, (char, char, char, char, char) tuple, StringComparison comparison = StringComparison.Ordinal)
            => s.Contains(tuple.Item1, comparison)
            || s.Contains(tuple.Item2, comparison)
            || s.Contains(tuple.Item3, comparison)
            || s.Contains(tuple.Item4, comparison)
            || s.Contains(tuple.Item5, comparison);
#endif

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool ContainsAny(this string s, (string, string, string, string) tuple, StringComparison comparison = StringComparison.Ordinal)
#if !NETSTANDARD2_0
            => s.Contains(tuple.Item1, comparison)
            || s.Contains(tuple.Item2, comparison)
            || s.Contains(tuple.Item3, comparison)
            || s.Contains(tuple.Item4, comparison);
#else
            => s.IndexOf(tuple.Item1, comparison) > -1
            || s.IndexOf(tuple.Item2, comparison) > -1
            || s.IndexOf(tuple.Item3, comparison) > -1
            || s.IndexOf(tuple.Item4, comparison) > -1;
#endif

#if !NETSTANDARD2_0
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool ContainsAny(this string s, (char, char, char, char) tuple, StringComparison comparison = StringComparison.Ordinal)
            => s.Contains(tuple.Item1, comparison)
            || s.Contains(tuple.Item2, comparison)
            || s.Contains(tuple.Item3, comparison)
            || s.Contains(tuple.Item4, comparison);
#endif

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool ContainsAny(this string s, (string, string, string) tuple, StringComparison comparison = StringComparison.Ordinal)
#if !NETSTANDARD2_0
            => s.Contains(tuple.Item1, comparison)
            || s.Contains(tuple.Item2, comparison)
            || s.Contains(tuple.Item3, comparison);
#else
            => s.IndexOf(tuple.Item1, comparison) > -1
            || s.IndexOf(tuple.Item2, comparison) > -1
            || s.IndexOf(tuple.Item3, comparison) > -1;
#endif

#if !NETSTANDARD2_0
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool ContainsAny(this string s, (char, char, char) tuple, StringComparison comparison = StringComparison.Ordinal)
            => s.Contains(tuple.Item1, comparison)
            || s.Contains(tuple.Item2, comparison)
            || s.Contains(tuple.Item3, comparison);
#endif

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool ContainsAny(this string s, (string, string) tuple, StringComparison comparison = StringComparison.Ordinal)
#if !NETSTANDARD2_0
            => s.Contains(tuple.Item1, comparison)
            || s.Contains(tuple.Item2, comparison);
#else
            => s.IndexOf(tuple.Item1, comparison) > -1
            || s.IndexOf(tuple.Item2, comparison) > -1;
#endif

#if !NETSTANDARD2_0
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool ContainsAny(this string s, (char, char) tuple, StringComparison comparison = StringComparison.Ordinal)
            => s.Contains(tuple.Item1, comparison)
            || s.Contains(tuple.Item2, comparison);
#endif
    }
}
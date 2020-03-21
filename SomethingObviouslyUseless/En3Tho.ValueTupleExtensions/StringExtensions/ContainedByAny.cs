using System;
using System.Runtime.CompilerServices;

namespace En3Tho.ValueTupleExtensions.StringExtensions
{
    public static partial class StringToValueTupleExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool ContainedByAny(this string s, (string, string, string, string, string, string, string) tuple, StringComparison comparison = StringComparison.Ordinal)
#if !NETSTANDARD2_0
            => tuple.Item1.Contains(s, comparison)
            || tuple.Item2.Contains(s, comparison)
            || tuple.Item3.Contains(s, comparison)
            || tuple.Item4.Contains(s, comparison)
            || tuple.Item5.Contains(s, comparison)
            || tuple.Item6.Contains(s, comparison)
            || tuple.Item7.Contains(s, comparison);
#else
            => tuple.Item1.IndexOf(s, comparison) > -1
            || tuple.Item2.IndexOf(s, comparison) > -1
            || tuple.Item3.IndexOf(s, comparison) > -1
            || tuple.Item4.IndexOf(s, comparison) > -1
            || tuple.Item5.IndexOf(s, comparison) > -1
            || tuple.Item6.IndexOf(s, comparison) > -1
            || tuple.Item7.IndexOf(s, comparison) > -1;
#endif

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
#if !NETSTANDARD2_0
        public static bool ContainedByAny(this char c, (string, string, string, string, string, string, string) tuple, StringComparison comparison = StringComparison.Ordinal)
            => tuple.Item1.Contains(c, comparison)
            || tuple.Item2.Contains(c, comparison)
            || tuple.Item3.Contains(c, comparison)
            || tuple.Item4.Contains(c, comparison)
            || tuple.Item5.Contains(c, comparison)
            || tuple.Item6.Contains(c, comparison)
            || tuple.Item7.Contains(c, comparison);
#else
        public static bool ContainedByAny(this char c, (string, string, string, string, string, string, string) tuple)
            => tuple.Item1.IndexOf(c) > -1
            || tuple.Item2.IndexOf(c) > -1
            || tuple.Item3.IndexOf(c) > -1
            || tuple.Item4.IndexOf(c) > -1
            || tuple.Item5.IndexOf(c) > -1
            || tuple.Item6.IndexOf(c) > -1
            || tuple.Item7.IndexOf(c) > -1;
#endif

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool ContainedByAny(this string s, (string, string, string, string, string, string) tuple, StringComparison comparison = StringComparison.Ordinal)
#if !NETSTANDARD2_0
            => tuple.Item1.Contains(s, comparison)
            || tuple.Item2.Contains(s, comparison)
            || tuple.Item3.Contains(s, comparison)
            || tuple.Item4.Contains(s, comparison)
            || tuple.Item5.Contains(s, comparison)
            || tuple.Item6.Contains(s, comparison);
#else
            => tuple.Item1.IndexOf(s, comparison) > -1
            || tuple.Item2.IndexOf(s, comparison) > -1
            || tuple.Item3.IndexOf(s, comparison) > -1
            || tuple.Item4.IndexOf(s, comparison) > -1
            || tuple.Item5.IndexOf(s, comparison) > -1
            || tuple.Item6.IndexOf(s, comparison) > -1;
#endif

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
#if !NETSTANDARD2_0
        public static bool ContainedByAny(this char c, (string, string, string, string, string, string) tuple, StringComparison comparison = StringComparison.Ordinal)
            => tuple.Item1.Contains(c, comparison)
            || tuple.Item2.Contains(c, comparison)
            || tuple.Item3.Contains(c, comparison)
            || tuple.Item4.Contains(c, comparison)
            || tuple.Item5.Contains(c, comparison)
            || tuple.Item6.Contains(c, comparison);
#else
        public static bool ContainedByAny(this char c, (string, string, string, string, string, string) tuple)
            => tuple.Item1.IndexOf(c) > -1
            || tuple.Item2.IndexOf(c) > -1
            || tuple.Item3.IndexOf(c) > -1
            || tuple.Item4.IndexOf(c) > -1
            || tuple.Item5.IndexOf(c) > -1
            || tuple.Item6.IndexOf(c) > -1;
#endif

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool ContainedByAny(this string s, (string, string, string, string, string) tuple, StringComparison comparison = StringComparison.Ordinal)
#if !NETSTANDARD2_0
            => tuple.Item1.Contains(s, comparison)
            || tuple.Item2.Contains(s, comparison)
            || tuple.Item3.Contains(s, comparison)
            || tuple.Item4.Contains(s, comparison)
            || tuple.Item5.Contains(s, comparison);
#else
            => tuple.Item1.IndexOf(s, comparison) > -1
            || tuple.Item2.IndexOf(s, comparison) > -1
            || tuple.Item3.IndexOf(s, comparison) > -1
            || tuple.Item4.IndexOf(s, comparison) > -1
            || tuple.Item5.IndexOf(s, comparison) > -1;
#endif

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
#if !NETSTANDARD2_0
        public static bool ContainedByAny(this char c, (string, string, string, string, string) tuple, StringComparison comparison = StringComparison.Ordinal)
            => tuple.Item1.Contains(c, comparison)
            || tuple.Item2.Contains(c, comparison)
            || tuple.Item3.Contains(c, comparison)
            || tuple.Item4.Contains(c, comparison)
            || tuple.Item5.Contains(c, comparison);
#else
        public static bool ContainedByAny(this char c, (string, string, string, string, string) tuple)
            => tuple.Item1.IndexOf(c) > -1
            || tuple.Item2.IndexOf(c) > -1
            || tuple.Item3.IndexOf(c) > -1
            || tuple.Item4.IndexOf(c) > -1
            || tuple.Item5.IndexOf(c) > -1;
#endif

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool ContainedByAny(this string s, (string, string, string, string) tuple, StringComparison comparison = StringComparison.Ordinal)
#if !NETSTANDARD2_0
            => tuple.Item1.Contains(s, comparison)
            || tuple.Item2.Contains(s, comparison)
            || tuple.Item3.Contains(s, comparison)
            || tuple.Item4.Contains(s, comparison);
#else
            => tuple.Item1.IndexOf(s, comparison) > -1
            || tuple.Item2.IndexOf(s, comparison) > -1
            || tuple.Item3.IndexOf(s, comparison) > -1
            || tuple.Item4.IndexOf(s, comparison) > -1;
#endif

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
#if !NETSTANDARD2_0
        public static bool ContainedByAny(this char c, (string, string, string, string) tuple, StringComparison comparison = StringComparison.Ordinal)
            => tuple.Item1.Contains(c, comparison)
            || tuple.Item2.Contains(c, comparison)
            || tuple.Item3.Contains(c, comparison)
            || tuple.Item4.Contains(c, comparison);
#else
        public static bool ContainedByAny(this char c, (string, string, string, string) tuple)
            => tuple.Item1.IndexOf(c) > -1
            || tuple.Item2.IndexOf(c) > -1
            || tuple.Item3.IndexOf(c) > -1
            || tuple.Item4.IndexOf(c) > -1;
#endif

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool ContainedByAny(this string s, (string, string, string) tuple, StringComparison comparison = StringComparison.Ordinal)
#if !NETSTANDARD2_0
            => tuple.Item1.Contains(s, comparison)
            || tuple.Item2.Contains(s, comparison)
            || tuple.Item3.Contains(s, comparison);
#else
            => tuple.Item1.IndexOf(s, comparison) > -1
            || tuple.Item2.IndexOf(s, comparison) > -1
            || tuple.Item3.IndexOf(s, comparison) > -1;
#endif

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
#if !NETSTANDARD2_0
        public static bool ContainedByAny(this char c, (string, string, string) tuple, StringComparison comparison = StringComparison.Ordinal)
            => tuple.Item1.Contains(c, comparison)
            || tuple.Item2.Contains(c, comparison)
            || tuple.Item3.Contains(c, comparison);
#else
        public static bool ContainedByAny(this char c, (string, string, string) tuple)
            => tuple.Item1.IndexOf(c) > -1
            || tuple.Item2.IndexOf(c) > -1
            || tuple.Item3.IndexOf(c) > -1;
#endif

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool ContainedByAny(this string s, (string, string) tuple, StringComparison comparison = StringComparison.Ordinal)
#if !NETSTANDARD2_0
            => tuple.Item1.Contains(s, comparison)
            || tuple.Item2.Contains(s, comparison);
#else
            => tuple.Item1.IndexOf(s, comparison) > -1
            || tuple.Item2.IndexOf(s, comparison) > -1;
#endif

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
#if !NETSTANDARD2_0
        public static bool ContainedByAny(this char c, (string, string) tuple, StringComparison comparison = StringComparison.Ordinal)
            => tuple.Item1.Contains(c, comparison)
            || tuple.Item2.Contains(c, comparison);
#else
        public static bool ContainedByAny(this char c, (string, string) tuple)
            => tuple.Item1.IndexOf(c) > -1
            || tuple.Item2.IndexOf(c) > -1;
#endif
    }
}
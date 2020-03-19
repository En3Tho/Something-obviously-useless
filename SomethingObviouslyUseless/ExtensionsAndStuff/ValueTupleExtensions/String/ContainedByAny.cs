using System;
using System.Runtime.CompilerServices;

namespace ExtensionsAndStuff.ValueTupleExtensions
{
    public static partial class StringTupleExtensions
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
        public static bool ContainedByAny(this string s, (string, string) tuple, StringComparison comparison = StringComparison.Ordinal)
#if !NETSTANDARD2_0
            => tuple.Item1.Contains(s, comparison)
               || tuple.Item2.Contains(s, comparison);
#else
            => tuple.Item1.IndexOf(s, comparison) > -1
               || tuple.Item2.IndexOf(s, comparison) > -1;
#endif
    }
}
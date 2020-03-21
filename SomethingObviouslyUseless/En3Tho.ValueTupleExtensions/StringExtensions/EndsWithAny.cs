using System;
using System.Runtime.CompilerServices;

namespace En3Tho.ValueTupleExtensions
{
    public static partial class StringToValueTupleExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool EndsWithAny(this string s, (string, string, string, string, string, string, string) tuple, StringComparison comparison = StringComparison.Ordinal)
            => s.EndsWith(tuple.Item1, comparison)
               || s.EndsWith(tuple.Item2, comparison)
               || s.EndsWith(tuple.Item3, comparison)
               || s.EndsWith(tuple.Item4, comparison)
               || s.EndsWith(tuple.Item5, comparison)
               || s.EndsWith(tuple.Item6, comparison)
               || s.EndsWith(tuple.Item7, comparison);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool EndsWithAny(this string s, (string, string, string, string, string, string) tuple, StringComparison comparison = StringComparison.Ordinal)
            => s.EndsWith(tuple.Item1, comparison)
               || s.EndsWith(tuple.Item2, comparison)
               || s.EndsWith(tuple.Item3, comparison)
               || s.EndsWith(tuple.Item4, comparison)
               || s.EndsWith(tuple.Item5, comparison)
               || s.EndsWith(tuple.Item6, comparison);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool EndsWithAny(this string s, (string, string, string, string, string) tuple, StringComparison comparison = StringComparison.Ordinal) 
            => s.EndsWith(tuple.Item1, comparison)
               || s.EndsWith(tuple.Item2, comparison)
               || s.EndsWith(tuple.Item3, comparison)
               || s.EndsWith(tuple.Item4, comparison)
               || s.EndsWith(tuple.Item5, comparison);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool EndsWithAny(this string s, (string, string, string, string) tuple, StringComparison comparison = StringComparison.Ordinal) 
            => s.EndsWith(tuple.Item1, comparison)
               || s.EndsWith(tuple.Item2, comparison)
               || s.EndsWith(tuple.Item3, comparison)
               || s.EndsWith(tuple.Item4, comparison);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool EndsWithAny(this string s, (string, string, string) tuple, StringComparison comparison = StringComparison.Ordinal) 
            => s.EndsWith(tuple.Item1, comparison)
               || s.EndsWith(tuple.Item2, comparison)
               || s.EndsWith(tuple.Item3, comparison);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool EndsWithAny(this string s, (string, string) tuple, StringComparison comparison = StringComparison.Ordinal) 
            => s.EndsWith(tuple.Item1, comparison)
               || s.EndsWith(tuple.Item2, comparison);

#if !NETSTANDARD2_0
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool EndsWithAny(this string s, (char, char, char, char, char, char, char) tuple) 
            => s.EndsWith(tuple.Item1)
               || s.EndsWith(tuple.Item2)
               || s.EndsWith(tuple.Item3)
               || s.EndsWith(tuple.Item4)
               || s.EndsWith(tuple.Item5)
               || s.EndsWith(tuple.Item6)
               || s.EndsWith(tuple.Item7);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool EndsWithAny(this string s, (char, char, char, char, char, char) tuple)
            => s.EndsWith(tuple.Item1)
               || s.EndsWith(tuple.Item2)
               || s.EndsWith(tuple.Item3)
               || s.EndsWith(tuple.Item4)
               || s.EndsWith(tuple.Item5)
               || s.EndsWith(tuple.Item6);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool EndsWithAny(this string s, (char, char, char, char, char) tuple)
            => s.EndsWith(tuple.Item1)
               || s.EndsWith(tuple.Item2)
               || s.EndsWith(tuple.Item3)
               || s.EndsWith(tuple.Item4)
               || s.EndsWith(tuple.Item5);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool EndsWithAny(this string s, (char, char, char, char) tuple)
            => s.EndsWith(tuple.Item1)
               || s.EndsWith(tuple.Item2)
               || s.EndsWith(tuple.Item3)
               || s.EndsWith(tuple.Item4);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool EndsWithAny(this string s, (char, char, char) tuple)
            => s.EndsWith(tuple.Item1)
               || s.EndsWith(tuple.Item2)
               || s.EndsWith(tuple.Item3);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool EndsWithAny(this string s, (char, char) tuple)
            => s.EndsWith(tuple.Item1)
               || s.EndsWith(tuple.Item2);
#endif
    }
}
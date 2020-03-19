using System;
using System.Runtime.CompilerServices;

namespace ExtensionsAndStuff.ValueTupleExtensions
{
    public static partial class StringTupleExtensions
    {      
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool StartsWithAny(this string s, (string, string, string, string, string, string, string) tuple, StringComparison comparison = StringComparison.Ordinal)
            => s.StartsWith(tuple.Item1, comparison)
               || s.StartsWith(tuple.Item2, comparison)
               || s.StartsWith(tuple.Item3, comparison)
               || s.StartsWith(tuple.Item4, comparison)
               || s.StartsWith(tuple.Item5, comparison)
               || s.StartsWith(tuple.Item6, comparison)
               || s.StartsWith(tuple.Item7, comparison);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool StartsWithAny(this string s, (string, string, string, string, string, string) tuple, StringComparison comparison = StringComparison.Ordinal)
            => s.StartsWith(tuple.Item1, comparison)
               || s.StartsWith(tuple.Item2, comparison)
               || s.StartsWith(tuple.Item3, comparison)
               || s.StartsWith(tuple.Item4, comparison)
               || s.StartsWith(tuple.Item5, comparison)
               || s.StartsWith(tuple.Item6, comparison);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool StartsWithAny(this string s, (string, string, string, string, string) tuple, StringComparison comparison = StringComparison.Ordinal) 
            => s.StartsWith(tuple.Item1, comparison)
               || s.StartsWith(tuple.Item2, comparison)
               || s.StartsWith(tuple.Item3, comparison)
               || s.StartsWith(tuple.Item4, comparison)
               || s.StartsWith(tuple.Item5, comparison);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool StartsWithAny(this string s, (string, string, string, string) tuple, StringComparison comparison = StringComparison.Ordinal) 
            => s.StartsWith(tuple.Item1, comparison)
               || s.StartsWith(tuple.Item2, comparison)
               || s.StartsWith(tuple.Item3, comparison)
               || s.StartsWith(tuple.Item4, comparison);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool StartsWithAny(this string s, (string, string, string) tuple, StringComparison comparison = StringComparison.Ordinal) 
            => s.StartsWith(tuple.Item1, comparison)
               || s.StartsWith(tuple.Item2, comparison)
               || s.StartsWith(tuple.Item3, comparison);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool StartsWithAny(this string s, (string, string) tuple, StringComparison comparison = StringComparison.Ordinal) 
            => s.StartsWith(tuple.Item1, comparison)
               || s.StartsWith(tuple.Item2, comparison);

#if !NETSTANDARD2_0

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool StartsWithAny(this string s, (char, char, char, char, char, char, char) tuple) 
            => s.StartsWith(tuple.Item1)
               || s.StartsWith(tuple.Item2)
               || s.StartsWith(tuple.Item3)
               || s.StartsWith(tuple.Item4)
               || s.StartsWith(tuple.Item5)
               || s.StartsWith(tuple.Item6)
               || s.StartsWith(tuple.Item7);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool StartsWithAny(this string s, (char, char, char, char, char, char) tuple) 
            => s.StartsWith(tuple.Item1)
               || s.StartsWith(tuple.Item2)
               || s.StartsWith(tuple.Item3)
               || s.StartsWith(tuple.Item4)
               || s.StartsWith(tuple.Item5)
               || s.StartsWith(tuple.Item6);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool StartsWithAny(this string s, (char, char, char, char, char) tuple)
            => s.StartsWith(tuple.Item1)
               || s.StartsWith(tuple.Item2)
               || s.StartsWith(tuple.Item3)
               || s.StartsWith(tuple.Item4)
               || s.StartsWith(tuple.Item5);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool StartsWithAny(this string s, (char, char, char, char) tuple) 
            => s.StartsWith(tuple.Item1)
               || s.StartsWith(tuple.Item2)
               || s.StartsWith(tuple.Item3)
               || s.StartsWith(tuple.Item4);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool StartsWithAny(this string s, (char, char, char) tuple) 
            => s.StartsWith(tuple.Item1)
               || s.StartsWith(tuple.Item2)
               || s.StartsWith(tuple.Item3);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool StartsWithAny(this string s, (char, char) tuple) 
            => s.StartsWith(tuple.Item1)
               || s.StartsWith(tuple.Item2);
#endif
    }
}
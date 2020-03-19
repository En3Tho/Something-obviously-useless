using System;
using System.Runtime.CompilerServices;

namespace ExtensionsAndStuff.ValueTupleExtensions
{
    public static partial class StringTupleExtensions
    {       
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Equals(this (string, string, string, string, string, string, string) tuple, (string, string, string, string, string, string, string) tuple2, StringComparison comparison)
            => tuple.Item1.Equals(tuple2.Item1, comparison)
               && tuple.Item2.Equals(tuple2.Item2, comparison)
               && tuple.Item3.Equals(tuple2.Item3, comparison)
               && tuple.Item4.Equals(tuple2.Item4, comparison)
               && tuple.Item5.Equals(tuple2.Item5, comparison)
               && tuple.Item6.Equals(tuple2.Item6, comparison)
               && tuple.Item7.Equals(tuple2.Item7, comparison);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Equals(this (string, string, string, string, string, string) tuple, (string, string, string, string, string, string) tuple2, StringComparison comparison)
            => tuple.Item1.Equals(tuple2.Item1, comparison)
               && tuple.Item2.Equals(tuple2.Item2, comparison)
               && tuple.Item3.Equals(tuple2.Item3, comparison)
               && tuple.Item4.Equals(tuple2.Item4, comparison)
               && tuple.Item5.Equals(tuple2.Item5, comparison)
               && tuple.Item6.Equals(tuple2.Item6, comparison);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Equals(this (string, string, string, string, string) tuple, (string, string, string, string, string) tuple2, StringComparison comparison)
            => tuple.Item1.Equals(tuple2.Item1, comparison)
               && tuple.Item2.Equals(tuple2.Item2, comparison)
               && tuple.Item3.Equals(tuple2.Item3, comparison)
               && tuple.Item4.Equals(tuple2.Item4, comparison)
               && tuple.Item5.Equals(tuple2.Item5, comparison);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Equals(this (string, string, string, string) tuple, (string, string, string, string) tuple2, StringComparison comparison) 
            => tuple.Item1.Equals(tuple2.Item1, comparison)
               && tuple.Item2.Equals(tuple2.Item2, comparison)
               && tuple.Item3.Equals(tuple2.Item3, comparison)
               && tuple.Item4.Equals(tuple2.Item4, comparison);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Equals(this (string, string, string) tuple, (string, string, string) tuple2, StringComparison comparison) 
            => tuple.Item1.Equals(tuple2.Item1, comparison)
               && tuple.Item2.Equals(tuple2.Item2, comparison)
               && tuple.Item3.Equals(tuple2.Item3, comparison);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Equals(this (string, string) tuple, (string, string) tuple2, StringComparison comparison)
            => tuple.Item1.Equals(tuple2.Item1, comparison)
               && tuple.Item2.Equals(tuple2.Item2, comparison);
    }
}
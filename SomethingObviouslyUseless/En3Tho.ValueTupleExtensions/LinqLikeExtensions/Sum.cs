using System.Runtime.CompilerServices;

namespace En3Tho.ValueTupleExtensions
{
    public static partial class ValueTupleLinqLikeExtensions
    {
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

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static decimal Sum(this (decimal v1, decimal v2, decimal v3, decimal v4, decimal v5, decimal v6, decimal v7) tuple)
            => tuple.v1 + tuple.v2 + tuple.v3 + tuple.v4 + tuple.v5 + tuple.v6 + tuple.v7;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static decimal Sum(this (decimal v1, decimal v2, decimal v3, decimal v4, decimal v5, decimal v6) tuple)
            => tuple.v1 + tuple.v2 + tuple.v3 + tuple.v4 + tuple.v5 + tuple.v6;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static decimal Sum(this (decimal v1, decimal v2, decimal v3, decimal v4, decimal v5) tuple)
            => tuple.v1 + tuple.v2 + tuple.v3 + tuple.v4 + tuple.v5;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static decimal Sum(this (decimal v1, decimal v2, decimal v3, decimal v4) tuple)
            => tuple.v1 + tuple.v2 + tuple.v3 + tuple.v4;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static decimal Sum(this (decimal v1, decimal v2, decimal v3) tuple)
            => tuple.v1 + tuple.v2 + tuple.v3;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static decimal Sum(this (decimal v1, decimal v2) tuple)
            => tuple.v1 + tuple.v2;
    }
}

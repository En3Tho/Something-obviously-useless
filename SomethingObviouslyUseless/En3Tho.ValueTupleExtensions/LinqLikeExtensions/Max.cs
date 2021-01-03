using System.Runtime.CompilerServices;

namespace En3Tho.ValueTupleExtensions.LinqLikeExtensions
{
    public static partial class ValueTupleLinqLikeExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Max(in this (int v1, int v2, int v3, int v4, int v5, int v6, int v7) tuple)
        {
            var num = tuple.v1 > tuple.v2 ? tuple.v1 : tuple.v2;
            if (num < tuple.v3) num = tuple.v3;
            if (num < tuple.v4) num = tuple.v4;
            if (num < tuple.v5) num = tuple.v5;
            if (num < tuple.v6) num = tuple.v6;
            return num < tuple.v7 ? tuple.v7 : num;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Max(in this (int v1, int v2, int v3, int v4, int v5, int v6) tuple)
        {
            var num = tuple.v1 > tuple.v2 ? tuple.v1 : tuple.v2;
            if (num < tuple.v3) num = tuple.v3;
            if (num < tuple.v4) num = tuple.v4;
            if (num < tuple.v5) num = tuple.v5;
            return num < tuple.v6 ? tuple.v6 : num;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Max(in this (int v1, int v2, int v3, int v4, int v5) tuple)
        {
            var num = tuple.v1 > tuple.v2 ? tuple.v1 : tuple.v2;
            if (num < tuple.v3) num = tuple.v3;
            if (num < tuple.v4) num = tuple.v4;
            return num < tuple.v5 ? tuple.v5 : num;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Max(in this (int v1, int v2, int v3, int v4) tuple)
        {
            var num = tuple.v1 > tuple.v2 ? tuple.v1 : tuple.v2;
            if (num < tuple.v3) num = tuple.v3;
            return num < tuple.v4 ? tuple.v4 : num;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Max(in this (int v1, int v2, int v3) tuple)
        {
            var num = tuple.v1 > tuple.v2 ? tuple.v1 : tuple.v2;
            return num < tuple.v3 ? tuple.v3 : num;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Max(in this (int v1, int v2) tuple)
        {
            return tuple.v1 > tuple.v2 ? tuple.v1 : tuple.v2;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint Max(in this (uint v1, uint v2, uint v3, uint v4, uint v5, uint v6, uint v7) tuple)
        {
            var num = tuple.v1 > tuple.v2 ? tuple.v1 : tuple.v2;
            if (num < tuple.v3) num = tuple.v3;
            if (num < tuple.v4) num = tuple.v4;
            if (num < tuple.v5) num = tuple.v5;
            if (num < tuple.v6) num = tuple.v6;
            return num < tuple.v7 ? tuple.v7 : num;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint Max(in this (uint v1, uint v2, uint v3, uint v4, uint v5, uint v6) tuple)
        {
            var num = tuple.v1 > tuple.v2 ? tuple.v1 : tuple.v2;
            if (num < tuple.v3) num = tuple.v3;
            if (num < tuple.v4) num = tuple.v4;
            if (num < tuple.v5) num = tuple.v5;
            return num < tuple.v6 ? tuple.v6 : num;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint Max(in this (uint v1, uint v2, uint v3, uint v4, uint v5) tuple)
        {
            var num = tuple.v1 > tuple.v2 ? tuple.v1 : tuple.v2;
            if (num < tuple.v3) num = tuple.v3;
            if (num < tuple.v4) num = tuple.v4;
            return num < tuple.v5 ? tuple.v5 : num;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint Max(in this (uint v1, uint v2, uint v3, uint v4) tuple)
        {
            var num = tuple.v1 > tuple.v2 ? tuple.v1 : tuple.v2;
            if (num < tuple.v3) num = tuple.v3;
            return num < tuple.v4 ? tuple.v4 : num;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint Max(in this (uint v1, uint v2, uint v3) tuple)
        {
            var num = tuple.v1 > tuple.v2 ? tuple.v1 : tuple.v2;
            return num < tuple.v3 ? tuple.v3 : num;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint Max(in this (uint v1, uint v2) tuple)
        {
            return tuple.v1 > tuple.v2 ? tuple.v1 : tuple.v2;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long Max(in this (long v1, long v2, long v3, long v4, long v5, long v6, long v7) tuple)
        {
            var num = tuple.v1 > tuple.v2 ? tuple.v1 : tuple.v2;
            if (num < tuple.v3) num = tuple.v3;
            if (num < tuple.v4) num = tuple.v4;
            if (num < tuple.v5) num = tuple.v5;
            if (num < tuple.v6) num = tuple.v6;
            return num < tuple.v7 ? tuple.v7 : num;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long Max(in this (long v1, long v2, long v3, long v4, long v5, long v6) tuple)
        {
            var num = tuple.v1 > tuple.v2 ? tuple.v1 : tuple.v2;
            if (num < tuple.v3) num = tuple.v3;
            if (num < tuple.v4) num = tuple.v4;
            if (num < tuple.v5) num = tuple.v5;
            return num < tuple.v6 ? tuple.v6 : num;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long Max(in this (long v1, long v2, long v3, long v4, long v5) tuple)
        {
            var num = tuple.v1 > tuple.v2 ? tuple.v1 : tuple.v2;
            if (num < tuple.v3) num = tuple.v3;
            if (num < tuple.v4) num = tuple.v4;
            return num < tuple.v5 ? tuple.v5 : num;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long Max(in this (long v1, long v2, long v3, long v4) tuple)
        {
            var num = tuple.v1 > tuple.v2 ? tuple.v1 : tuple.v2;
            if (num < tuple.v3) num = tuple.v3;
            return num < tuple.v4 ? tuple.v4 : num;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long Max(in this (long v1, long v2, long v3) tuple)
        {
            var num = tuple.v1 > tuple.v2 ? tuple.v1 : tuple.v2;
            return num < tuple.v3 ? tuple.v3 : num;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long Max(in this (long v1, long v2) tuple)
        {
            return tuple.v1 > tuple.v2 ? tuple.v1 : tuple.v2;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong Max(in this (ulong v1, ulong v2, ulong v3, ulong v4, ulong v5, ulong v6, ulong v7) tuple)
        {
            var num = tuple.v1 > tuple.v2 ? tuple.v1 : tuple.v2;
            if (num < tuple.v3) num = tuple.v3;
            if (num < tuple.v4) num = tuple.v4;
            if (num < tuple.v5) num = tuple.v5;
            if (num < tuple.v6) num = tuple.v6;
            return num < tuple.v7 ? tuple.v7 : num;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong Max(in this (ulong v1, ulong v2, ulong v3, ulong v4, ulong v5, ulong v6) tuple)
        {
            var num = tuple.v1 > tuple.v2 ? tuple.v1 : tuple.v2;
            if (num < tuple.v3) num = tuple.v3;
            if (num < tuple.v4) num = tuple.v4;
            if (num < tuple.v5) num = tuple.v5;
            return num < tuple.v6 ? tuple.v6 : num;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong Max(in this (ulong v1, ulong v2, ulong v3, ulong v4, ulong v5) tuple)
        {
            var num = tuple.v1 > tuple.v2 ? tuple.v1 : tuple.v2;
            if (num < tuple.v3) num = tuple.v3;
            if (num < tuple.v4) num = tuple.v4;
            return num < tuple.v5 ? tuple.v5 : num;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong Max(in this (ulong v1, ulong v2, ulong v3, ulong v4) tuple)
        {
            var num = tuple.v1 > tuple.v2 ? tuple.v1 : tuple.v2;
            if (num < tuple.v3) num = tuple.v3;
            return num < tuple.v4 ? tuple.v4 : num;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong Max(in this (ulong v1, ulong v2, ulong v3) tuple)
        {
            var num = tuple.v1 > tuple.v2 ? tuple.v1 : tuple.v2;
            return num < tuple.v3 ? tuple.v3 : num;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong Max(in this (ulong v1, ulong v2) tuple)
        {
            return tuple.v1 > tuple.v2 ? tuple.v1 : tuple.v2;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short Max(in this (short v1, short v2, short v3, short v4, short v5, short v6, short v7) tuple)
        {
            var num = tuple.v1 > tuple.v2 ? tuple.v1 : tuple.v2;
            if (num < tuple.v3) num = tuple.v3;
            if (num < tuple.v4) num = tuple.v4;
            if (num < tuple.v5) num = tuple.v5;
            if (num < tuple.v6) num = tuple.v6;
            return num < tuple.v7 ? tuple.v7 : num;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short Max(in this (short v1, short v2, short v3, short v4, short v5, short v6) tuple)
        {
            var num = tuple.v1 > tuple.v2 ? tuple.v1 : tuple.v2;
            if (num < tuple.v3) num = tuple.v3;
            if (num < tuple.v4) num = tuple.v4;
            if (num < tuple.v5) num = tuple.v5;
            return num < tuple.v6 ? tuple.v6 : num;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short Max(in this (short v1, short v2, short v3, short v4, short v5) tuple)
        {
            var num = tuple.v1 > tuple.v2 ? tuple.v1 : tuple.v2;
            if (num < tuple.v3) num = tuple.v3;
            if (num < tuple.v4) num = tuple.v4;
            return num < tuple.v5 ? tuple.v5 : num;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short Max(in this (short v1, short v2, short v3, short v4) tuple)
        {
            var num = tuple.v1 > tuple.v2 ? tuple.v1 : tuple.v2;
            if (num < tuple.v3) num = tuple.v3;
            return num < tuple.v4 ? tuple.v4 : num;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short Max(in this (short v1, short v2, short v3) tuple)
        {
            var num = tuple.v1 > tuple.v2 ? tuple.v1 : tuple.v2;
            return num < tuple.v3 ? tuple.v3 : num;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short Max(in this (short v1, short v2) tuple)
        {
            return tuple.v1 > tuple.v2 ? tuple.v1 : tuple.v2;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort Max(in this (ushort v1, ushort v2, ushort v3, ushort v4, ushort v5, ushort v6, ushort v7) tuple)
        {
            var num = tuple.v1 > tuple.v2 ? tuple.v1 : tuple.v2;
            if (num < tuple.v3) num = tuple.v3;
            if (num < tuple.v4) num = tuple.v4;
            if (num < tuple.v5) num = tuple.v5;
            if (num < tuple.v6) num = tuple.v6;
            return num < tuple.v7 ? tuple.v7 : num;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort Max(in this (ushort v1, ushort v2, ushort v3, ushort v4, ushort v5, ushort v6) tuple)
        {
            var num = tuple.v1 > tuple.v2 ? tuple.v1 : tuple.v2;
            if (num < tuple.v3) num = tuple.v3;
            if (num < tuple.v4) num = tuple.v4;
            if (num < tuple.v5) num = tuple.v5;
            return num < tuple.v6 ? tuple.v6 : num;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort Max(in this (ushort v1, ushort v2, ushort v3, ushort v4, ushort v5) tuple)
        {
            var num = tuple.v1 > tuple.v2 ? tuple.v1 : tuple.v2;
            if (num < tuple.v3) num = tuple.v3;
            if (num < tuple.v4) num = tuple.v4;
            return num < tuple.v5 ? tuple.v5 : num;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort Max(in this (ushort v1, ushort v2, ushort v3, ushort v4) tuple)
        {
            var num = tuple.v1 > tuple.v2 ? tuple.v1 : tuple.v2;
            if (num < tuple.v3) num = tuple.v3;
            return num < tuple.v4 ? tuple.v4 : num;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort Max(in this (ushort v1, ushort v2, ushort v3) tuple)
        {
            var num = tuple.v1 > tuple.v2 ? tuple.v1 : tuple.v2;
            return num < tuple.v3 ? tuple.v3 : num;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort Max(in this (ushort v1, ushort v2) tuple)
        {
            return tuple.v1 > tuple.v2 ? tuple.v1 : tuple.v2;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte Max(in this (byte v1, byte v2, byte v3, byte v4, byte v5, byte v6, byte v7) tuple)
        {
            var num = tuple.v1 > tuple.v2 ? tuple.v1 : tuple.v2;
            if (num < tuple.v3) num = tuple.v3;
            if (num < tuple.v4) num = tuple.v4;
            if (num < tuple.v5) num = tuple.v5;
            if (num < tuple.v6) num = tuple.v6;
            return num < tuple.v7 ? tuple.v7 : num;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte Max(in this (byte v1, byte v2, byte v3, byte v4, byte v5, byte v6) tuple)
        {
            var num = tuple.v1 > tuple.v2 ? tuple.v1 : tuple.v2;
            if (num < tuple.v3) num = tuple.v3;
            if (num < tuple.v4) num = tuple.v4;
            if (num < tuple.v5) num = tuple.v5;
            return num < tuple.v6 ? tuple.v6 : num;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte Max(in this (byte v1, byte v2, byte v3, byte v4, byte v5) tuple)
        {
            var num = tuple.v1 > tuple.v2 ? tuple.v1 : tuple.v2;
            if (num < tuple.v3) num = tuple.v3;
            if (num < tuple.v4) num = tuple.v4;
            return num < tuple.v5 ? tuple.v5 : num;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte Max(in this (byte v1, byte v2, byte v3, byte v4) tuple)
        {
            var num = tuple.v1 > tuple.v2 ? tuple.v1 : tuple.v2;
            if (num < tuple.v3) num = tuple.v3;
            return num < tuple.v4 ? tuple.v4 : num;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte Max(in this (byte v1, byte v2, byte v3) tuple)
        {
            var num = tuple.v1 > tuple.v2 ? tuple.v1 : tuple.v2;
            return num < tuple.v3 ? tuple.v3 : num;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte Max(in this (byte v1, byte v2) tuple)
        {
            return tuple.v1 > tuple.v2 ? tuple.v1 : tuple.v2;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte Max(in this (sbyte v1, sbyte v2, sbyte v3, sbyte v4, sbyte v5, sbyte v6, sbyte v7) tuple)
        {
            var num = tuple.v1 > tuple.v2 ? tuple.v1 : tuple.v2;
            if (num < tuple.v3) num = tuple.v3;
            if (num < tuple.v4) num = tuple.v4;
            if (num < tuple.v5) num = tuple.v5;
            if (num < tuple.v6) num = tuple.v6;
            return num < tuple.v7 ? tuple.v7 : num;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte Max(in this (sbyte v1, sbyte v2, sbyte v3, sbyte v4, sbyte v5, sbyte v6) tuple)
        {
            var num = tuple.v1 > tuple.v2 ? tuple.v1 : tuple.v2;
            if (num < tuple.v3) num = tuple.v3;
            if (num < tuple.v4) num = tuple.v4;
            if (num < tuple.v5) num = tuple.v5;
            return num < tuple.v6 ? tuple.v6 : num;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte Max(in this (sbyte v1, sbyte v2, sbyte v3, sbyte v4, sbyte v5) tuple)
        {
            var num = tuple.v1 > tuple.v2 ? tuple.v1 : tuple.v2;
            if (num < tuple.v3) num = tuple.v3;
            if (num < tuple.v4) num = tuple.v4;
            return num < tuple.v5 ? tuple.v5 : num;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte Max(in this (sbyte v1, sbyte v2, sbyte v3, sbyte v4) tuple)
        {
            var num = tuple.v1 > tuple.v2 ? tuple.v1 : tuple.v2;
            if (num < tuple.v3) num = tuple.v3;
            return num < tuple.v4 ? tuple.v4 : num;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte Max(in this (sbyte v1, sbyte v2, sbyte v3) tuple)
        {
            var num = tuple.v1 > tuple.v2 ? tuple.v1 : tuple.v2;
            return num < tuple.v3 ? tuple.v3 : num;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte Max(in this (sbyte v1, sbyte v2) tuple)
        {
            return tuple.v1 > tuple.v2 ? tuple.v1 : tuple.v2;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Max(in this (float v1, float v2, float v3, float v4, float v5, float v6, float v7) tuple)
        {
            var num = tuple.v1 > tuple.v2 ? tuple.v1 : tuple.v2;
            if (num < tuple.v3) num = tuple.v3;
            if (num < tuple.v4) num = tuple.v4;
            if (num < tuple.v5) num = tuple.v5;
            if (num < tuple.v6) num = tuple.v6;
            return num < tuple.v7 ? tuple.v7 : num;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Max(in this (float v1, float v2, float v3, float v4, float v5, float v6) tuple)
        {
            var num = tuple.v1 > tuple.v2 ? tuple.v1 : tuple.v2;
            if (num < tuple.v3) num = tuple.v3;
            if (num < tuple.v4) num = tuple.v4;
            if (num < tuple.v5) num = tuple.v5;
            return num < tuple.v6 ? tuple.v6 : num;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Max(in this (float v1, float v2, float v3, float v4, float v5) tuple)
        {
            var num = tuple.v1 > tuple.v2 ? tuple.v1 : tuple.v2;
            if (num < tuple.v3) num = tuple.v3;
            if (num < tuple.v4) num = tuple.v4;
            return num < tuple.v5 ? tuple.v5 : num;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Max(in this (float v1, float v2, float v3, float v4) tuple)
        {
            var num = tuple.v1 > tuple.v2 ? tuple.v1 : tuple.v2;
            if (num < tuple.v3) num = tuple.v3;
            return num < tuple.v4 ? tuple.v4 : num;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Max(in this (float v1, float v2, float v3) tuple)
        {
            var num = tuple.v1 > tuple.v2 ? tuple.v1 : tuple.v2;
            return num < tuple.v3 ? tuple.v3 : num;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Max(in this (float v1, float v2) tuple)
        {
            return tuple.v1 > tuple.v2 ? tuple.v1 : tuple.v2;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Max(in this (double v1, double v2, double v3, double v4, double v5, double v6, double v7) tuple)
        {
            var num = tuple.v1 > tuple.v2 ? tuple.v1 : tuple.v2;
            if (num < tuple.v3) num = tuple.v3;
            if (num < tuple.v4) num = tuple.v4;
            if (num < tuple.v5) num = tuple.v5;
            if (num < tuple.v6) num = tuple.v6;
            return num < tuple.v7 ? tuple.v7 : num;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Max(in this (double v1, double v2, double v3, double v4, double v5, double v6) tuple)
        {
            var num = tuple.v1 > tuple.v2 ? tuple.v1 : tuple.v2;
            if (num < tuple.v3) num = tuple.v3;
            if (num < tuple.v4) num = tuple.v4;
            if (num < tuple.v5) num = tuple.v5;
            return num < tuple.v6 ? tuple.v6 : num;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Max(in this (double v1, double v2, double v3, double v4, double v5) tuple)
        {
            var num = tuple.v1 > tuple.v2 ? tuple.v1 : tuple.v2;
            if (num < tuple.v3) num = tuple.v3;
            if (num < tuple.v4) num = tuple.v4;
            return num < tuple.v5 ? tuple.v5 : num;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Max(in this (double v1, double v2, double v3, double v4) tuple)
        {
            var num = tuple.v1 > tuple.v2 ? tuple.v1 : tuple.v2;
            if (num < tuple.v3) num = tuple.v3;
            return num < tuple.v4 ? tuple.v4 : num;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Max(in this (double v1, double v2, double v3) tuple)
        {
            var num = tuple.v1 > tuple.v2 ? tuple.v1 : tuple.v2;
            return num < tuple.v3 ? tuple.v3 : num;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Max(in this (double v1, double v2) tuple)
        {
            return tuple.v1 > tuple.v2 ? tuple.v1 : tuple.v2;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static decimal Max(in this (decimal v1, decimal v2, decimal v3, decimal v4, decimal v5, decimal v6, decimal v7) tuple)
        {
            var num = tuple.v1 > tuple.v2 ? tuple.v1 : tuple.v2;
            if (num < tuple.v3) num = tuple.v3;
            if (num < tuple.v4) num = tuple.v4;
            if (num < tuple.v5) num = tuple.v5;
            if (num < tuple.v6) num = tuple.v6;
            return num < tuple.v7 ? tuple.v7 : num;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static decimal Max(in this (decimal v1, decimal v2, decimal v3, decimal v4, decimal v5, decimal v6) tuple)
        {
            var num = tuple.v1 > tuple.v2 ? tuple.v1 : tuple.v2;
            if (num < tuple.v3) num = tuple.v3;
            if (num < tuple.v4) num = tuple.v4;
            if (num < tuple.v5) num = tuple.v5;
            return num < tuple.v6 ? tuple.v6 : num;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static decimal Max(in this (decimal v1, decimal v2, decimal v3, decimal v4, decimal v5) tuple)
        {
            var num = tuple.v1 > tuple.v2 ? tuple.v1 : tuple.v2;
            if (num < tuple.v3) num = tuple.v3;
            if (num < tuple.v4) num = tuple.v4;
            return num < tuple.v5 ? tuple.v5 : num;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static decimal Max(in this (decimal v1, decimal v2, decimal v3, decimal v4) tuple)
        {
            var num = tuple.v1 > tuple.v2 ? tuple.v1 : tuple.v2;
            if (num < tuple.v3) num = tuple.v3;
            return num < tuple.v4 ? tuple.v4 : num;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static decimal Max(in this (decimal v1, decimal v2, decimal v3) tuple)
        {
            var num = tuple.v1 > tuple.v2 ? tuple.v1 : tuple.v2;
            return num < tuple.v3 ? tuple.v3 : num;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static decimal Max(in this (decimal v1, decimal v2) tuple)
        {
            return tuple.v1 > tuple.v2 ? tuple.v1 : tuple.v2;
        }
    }
}
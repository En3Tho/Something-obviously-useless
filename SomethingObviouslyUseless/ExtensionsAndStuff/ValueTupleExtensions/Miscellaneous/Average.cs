using System.Runtime.CompilerServices;

namespace ExtensionsAndStuff.ValueTupleExtensions
{
    public static partial class MiscellaneousExtensions
    { 
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Average(this (int v1, int v2, int v3, int v4, int v5, int v6, int v7) tuple)
            => (tuple.v1 + tuple.v2 + tuple.v3 + tuple.v4 + tuple.v5 + tuple.v6 + tuple.v7) / 7;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Average(this (int v1, int v2, int v3, int v4, int v5, int v6) tuple)
            => (tuple.v1 + tuple.v2 + tuple.v3 + tuple.v4 + tuple.v5 + tuple.v6) / 6;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Average(this (int v1, int v2, int v3, int v4, int v5) tuple)
            => (tuple.v1 + tuple.v2 + tuple.v3 + tuple.v4 + tuple.v5) / 5;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Average(this (int v1, int v2, int v3, int v4) tuple)
            => (tuple.v1 + tuple.v2 + tuple.v3 + tuple.v4) / 4;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Average(this (int v1, int v2, int v3) tuple)
            => (tuple.v1 + tuple.v2 + tuple.v3) / 3;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Average(this (int v1, int v2) tuple)
            => (tuple.v1 + tuple.v2) / 2;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint Average(this (uint v1, uint v2, uint v3, uint v4, uint v5, uint v6, uint v7) tuple)
            => (tuple.v1 + tuple.v2 + tuple.v3 + tuple.v4 + tuple.v5 + tuple.v6 + tuple.v7) / 7;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint Average(this (uint v1, uint v2, uint v3, uint v4, uint v5, uint v6) tuple)
            => (tuple.v1 + tuple.v2 + tuple.v3 + tuple.v4 + tuple.v5 + tuple.v6) / 6;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint Average(this (uint v1, uint v2, uint v3, uint v4, uint v5) tuple)
            => (tuple.v1 + tuple.v2 + tuple.v3 + tuple.v4 + tuple.v5) / 5;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint Average(this (uint v1, uint v2, uint v3, uint v4) tuple)
            => (tuple.v1 + tuple.v2 + tuple.v3 + tuple.v4) / 4;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint Average(this (uint v1, uint v2, uint v3) tuple)
            => (tuple.v1 + tuple.v2 + tuple.v3) / 3;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint Average(this (uint v1, uint v2) tuple)
            => (tuple.v1 + tuple.v2) / 2;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long Average(this (long v1, long v2, long v3, long v4, long v5, long v6, long v7) tuple)
            => (tuple.v1 + tuple.v2 + tuple.v3 + tuple.v4 + tuple.v5 + tuple.v6 + tuple.v7) / 7;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long Average(this (long v1, long v2, long v3, long v4, long v5, long v6) tuple)
            => (tuple.v1 + tuple.v2 + tuple.v3 + tuple.v4 + tuple.v5 + tuple.v6) / 6;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long Average(this (long v1, long v2, long v3, long v4, long v5) tuple)
            => (tuple.v1 + tuple.v2 + tuple.v3 + tuple.v4 + tuple.v5) / 5;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long Average(this (long v1, long v2, long v3, long v4) tuple)
            => (tuple.v1 + tuple.v2 + tuple.v3 + tuple.v4) / 4;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long Average(this (long v1, long v2, long v3) tuple)
            => (tuple.v1 + tuple.v2 + tuple.v3) / 3;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long Average(this (long v1, long v2) tuple)
            => (tuple.v1 + tuple.v2) / 2;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong Average(this (ulong v1, ulong v2, ulong v3, ulong v4, ulong v5, ulong v6, ulong v7) tuple)
            => (tuple.v1 + tuple.v2 + tuple.v3 + tuple.v4 + tuple.v5 + tuple.v6 + tuple.v7) / 7;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong Average(this (ulong v1, ulong v2, ulong v3, ulong v4, ulong v5, ulong v6) tuple)
            => (tuple.v1 + tuple.v2 + tuple.v3 + tuple.v4 + tuple.v5 + tuple.v6) / 6;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong Average(this (ulong v1, ulong v2, ulong v3, ulong v4, ulong v5) tuple)
            => (tuple.v1 + tuple.v2 + tuple.v3 + tuple.v4 + tuple.v5) / 5;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong Average(this (ulong v1, ulong v2, ulong v3, ulong v4) tuple)
            => (tuple.v1 + tuple.v2 + tuple.v3 + tuple.v4) / 4;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong Average(this (ulong v1, ulong v2, ulong v3) tuple)
            => (tuple.v1 + tuple.v2 + tuple.v3) / 3;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong Average(this (ulong v1, ulong v2) tuple)
            => (tuple.v1 + tuple.v2) / 2;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Average(this (float v1, float v2, float v3, float v4, float v5, float v6, float v7) tuple)
            => (tuple.v1 + tuple.v2 + tuple.v3 + tuple.v4 + tuple.v5 + tuple.v6 + tuple.v7) / 7;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Average(this (float v1, float v2, float v3, float v4, float v5, float v6) tuple)
            => (tuple.v1 + tuple.v2 + tuple.v3 + tuple.v4 + tuple.v5 + tuple.v6) / 6;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Average(this (float v1, float v2, float v3, float v4, float v5) tuple)
            => (tuple.v1 + tuple.v2 + tuple.v3 + tuple.v4 + tuple.v5) / 5;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Average(this (float v1, float v2, float v3, float v4) tuple)
            => (tuple.v1 + tuple.v2 + tuple.v3 + tuple.v4) / 4;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Average(this (float v1, float v2, float v3) tuple)
            => (tuple.v1 + tuple.v2 + tuple.v3) / 3;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Average(this (float v1, float v2) tuple)
            => (tuple.v1 + tuple.v2) / 2;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Average(this (double v1, double v2, double v3, double v4, double v5, double v6, double v7) tuple)
            => (tuple.v1 + tuple.v2 + tuple.v3 + tuple.v4 + tuple.v5 + tuple.v6 + tuple.v7) / 7;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Average(this (double v1, double v2, double v3, double v4, double v5, double v6) tuple)
            => (tuple.v1 + tuple.v2 + tuple.v3 + tuple.v4 + tuple.v5 + tuple.v6) / 6;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Average(this (double v1, double v2, double v3, double v4, double v5) tuple)
            => (tuple.v1 + tuple.v2 + tuple.v3 + tuple.v4 + tuple.v5) / 5;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Average(this (double v1, double v2, double v3, double v4) tuple)
            => (tuple.v1 + tuple.v2 + tuple.v3 + tuple.v4) / 4;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Average(this (double v1, double v2, double v3) tuple)
            => (tuple.v1 + tuple.v2 + tuple.v3) / 3;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Average(this (double v1, double v2) tuple)
            => (tuple.v1 + tuple.v2) / 2;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static decimal Average(this (decimal v1, decimal v2, decimal v3, decimal v4, decimal v5, decimal v6, decimal v7) tuple)
            => (tuple.v1 + tuple.v2 + tuple.v3 + tuple.v4 + tuple.v5 + tuple.v6 + tuple.v7) / 7;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static decimal Average(this (decimal v1, decimal v2, decimal v3, decimal v4, decimal v5, decimal v6) tuple)
            => (tuple.v1 + tuple.v2 + tuple.v3 + tuple.v4 + tuple.v5 + tuple.v6) / 6;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static decimal Average(this (decimal v1, decimal v2, decimal v3, decimal v4, decimal v5) tuple)
            => (tuple.v1 + tuple.v2 + tuple.v3 + tuple.v4 + tuple.v5) / 5;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static decimal Average(this (decimal v1, decimal v2, decimal v3, decimal v4) tuple)
            => (tuple.v1 + tuple.v2 + tuple.v3 + tuple.v4) / 4;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static decimal Average(this (decimal v1, decimal v2, decimal v3) tuple)
            => (tuple.v1 + tuple.v2 + tuple.v3) / 3;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static decimal Average(this (decimal v1, decimal v2) tuple)
            => (tuple.v1 + tuple.v2) / 2;
    }
}

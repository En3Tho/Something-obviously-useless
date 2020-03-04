﻿using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ExtensionsAndStuff.ValueTupleExtensions
{
    public static class MemoryMarshalExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Span<T> AsSpan<T>(this (T, T, T, T, T, T, T) tuple)
            => MemoryMarshal.CreateSpan(ref tuple.Item1, 7);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Span<T> AsSpan<T>(this (T, T, T, T, T, T) tuple)
            => MemoryMarshal.CreateSpan(ref tuple.Item1, 6);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Span<T> AsSpan<T>(this (T, T, T, T, T) tuple)
            => MemoryMarshal.CreateSpan(ref tuple.Item1, 5);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Span<T> AsSpan<T>(this (T, T, T, T) tuple)
            => MemoryMarshal.CreateSpan(ref tuple.Item1, 4);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Span<T> AsSpan<T>(this (T, T, T) tuple)
            => MemoryMarshal.CreateSpan(ref tuple.Item1, 3);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Span<T> AsSpan<T>(this (T, T) tuple)
            => MemoryMarshal.CreateSpan(ref tuple.Item1, 2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ReadOnlySpan<T> AsReadOnlySpan<T>(this (T, T, T, T, T, T, T) tuple)
            => MemoryMarshal.CreateReadOnlySpan(ref tuple.Item1, 7);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ReadOnlySpan<T> AsReadOnlySpan<T>(this (T, T, T, T, T, T) tuple)
            => MemoryMarshal.CreateReadOnlySpan(ref tuple.Item1, 6);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ReadOnlySpan<T> AsReadOnlySpan<T>(this (T, T, T, T, T) tuple)
            => MemoryMarshal.CreateReadOnlySpan(ref tuple.Item1, 5);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ReadOnlySpan<T> AsReadOnlySpan<T>(this (T, T, T, T) tuple)
            => MemoryMarshal.CreateReadOnlySpan(ref tuple.Item1, 4);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ReadOnlySpan<T> AsReadOnlySpan<T>(this (T, T, T) tuple)
            => MemoryMarshal.CreateReadOnlySpan(ref tuple.Item1, 3);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ReadOnlySpan<T> AsReadOnlySpan<T>(this (T, T) tuple)
            => MemoryMarshal.CreateReadOnlySpan(ref tuple.Item1, 2);
    }
}
using System;
using System.Runtime.InteropServices;

namespace ExtensionsAndStuff.ValueTupleExtensions
{
    public static class MemoryMarshalExtensions
    {
        public static Span<T> AsSpan<T>(this (T, T, T, T, T, T, T) tuple)
            => MemoryMarshal.CreateSpan(ref tuple.Item1, 7);
        
        public static Span<T> AsSpan<T>(this (T, T, T, T, T, T) tuple)
            => MemoryMarshal.CreateSpan(ref tuple.Item1, 6);
        
        public static Span<T> AsSpan<T>(this (T, T, T, T, T) tuple)
            => MemoryMarshal.CreateSpan(ref tuple.Item1, 5);
        
        public static Span<T> AsSpan<T>(this (T, T, T, T) tuple)
            => MemoryMarshal.CreateSpan(ref tuple.Item1,4);
        
        public static Span<T> AsSpan<T>(this (T, T, T) tuple)
            => MemoryMarshal.CreateSpan(ref tuple.Item1, 3);
        
        public static Span<T> AsSpan<T>(this (T, T) tuple)
            => MemoryMarshal.CreateSpan(ref tuple.Item1, 2);
        
        public static ReadOnlySpan<T> AsReadOnlySpan<T>(this (T, T, T, T, T, T, T) tuple)
            => MemoryMarshal.CreateReadOnlySpan(ref tuple.Item1, 7);
        
        public static ReadOnlySpan<T> AsReadOnlySpan<T>(this (T, T, T, T, T, T) tuple)
            => MemoryMarshal.CreateReadOnlySpan(ref tuple.Item1, 6);
        
        public static ReadOnlySpan<T> AsReadOnlySpan<T>(this (T, T, T, T, T) tuple)
            => MemoryMarshal.CreateReadOnlySpan(ref tuple.Item1, 5);
        
        public static ReadOnlySpan<T> AsReadOnlySpan<T>(this (T, T, T, T) tuple)
            => MemoryMarshal.CreateReadOnlySpan(ref tuple.Item1, 4);
        
        public static ReadOnlySpan<T> AsReadOnlySpan<T>(this (T, T, T) tuple)
            => MemoryMarshal.CreateReadOnlySpan(ref tuple.Item1, 3);
        
        public static ReadOnlySpan<T> AsReadOnlySpan<T>(this (T, T) tuple)
            => MemoryMarshal.CreateReadOnlySpan(ref tuple.Item1, 2);
    }
}
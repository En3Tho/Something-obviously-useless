using System;
using System.Runtime.InteropServices;

namespace ExtensionsAndStuff.ReferenceStackAllocation
{
    public struct ReferenceValueHolder4<T> where T : class
    {
        public T _1;
        public T _2;
        public T _3;
        public T _4;
        
        public Span<T> AsSpan() => MemoryMarshal.CreateSpan(ref _1, 32 / 8);
    }
    
    public struct ReferenceValueHolder8<T> where T : class
    {
        public ReferenceValueHolder4<T> _1;
        public ReferenceValueHolder4<T> _2;
        
        public Span<T> AsSpan() => MemoryMarshal.CreateSpan(ref _1._1, 64 / 8);
    }
    
    public struct ReferenceValueHolder16<T> where T : class
    {
        public ReferenceValueHolder8<T> _1;
        public ReferenceValueHolder8<T> _2;
        
        public Span<T> AsSpan() => MemoryMarshal.CreateSpan(ref _1._1._1, 128 / 8);
    }
    
    public struct ReferenceValueHolder32<T> where T : class
    {
        public ReferenceValueHolder16<T> _1;
        public ReferenceValueHolder16<T> _2;
        
        public Span<T> AsSpan() => MemoryMarshal.CreateSpan(ref _1._1._1._1, 256 / 8);
    }
    
    public struct ReferenceValueHolder64<T> where T : class
    {
        public ReferenceValueHolder32<T> _1;
        public ReferenceValueHolder32<T> _2;

        public Span<T> AsSpan() => MemoryMarshal.CreateSpan(ref _1._1._1._1._1, 512 / 8);
    }
}
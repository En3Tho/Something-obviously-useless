using System;
using System.Runtime.CompilerServices;

namespace ExtensionsAndStuff.RefStructs
{
    public readonly ref struct Disposable<T>
    {
        public readonly T Value { [MethodImpl(MethodImplOptions.AggressiveInlining)] get; }
        private readonly Action<T> _disposer;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Disposable(T value, Action<T> disposer)
        {
            Value = value;
            _disposer = disposer;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Disposable(T value, Action<T> starter, Action<T> disposer)
        {
            starter(value);
            Value = value;
            _disposer = disposer;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Dispose()
        {
            _disposer(Value);
        }
    }
}
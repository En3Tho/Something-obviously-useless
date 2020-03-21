using System;
using System.Runtime.CompilerServices;

namespace En3Tho.HelperClasses.Disposable.RefStructs
{
    public readonly ref struct Disposable<T>
    {
        public readonly T Value
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get;
        }

        private readonly Action<T> _disposer;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Disposable(T value, Action<T> disposer) => (Value, _disposer) = (value, disposer);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Disposable(Func<T> creator, Action<T> disposer) : this(creator(), disposer)
        {
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Disposable(Func<T> creator, Action<T> starter, Action<T> disposer) : this(creator(), starter, disposer)
        {
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Disposable(T value, Action<T> starter, Action<T> disposer)
        {
            starter(value);
            (Value, _disposer) = (value, disposer);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Dispose()
        {
            if (Value is {})
                _disposer(Value);
        }
    }
}
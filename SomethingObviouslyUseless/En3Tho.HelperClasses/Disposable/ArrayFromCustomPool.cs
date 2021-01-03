#if !NETSTANDARD2_0
using System.Buffers;
using System.Runtime.CompilerServices;

namespace En3Tho.HelperClasses.Disposable.RefStructs
{
    public readonly ref struct ArrayFromCustomPool<T>
    {
        private readonly ArrayPool<T>? _pool;
        private readonly bool _clearOnReturn;

        public T[]? Value
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ArrayFromCustomPool(ArrayPool<T> pool, int minimumLength, bool clearOnReturn = false)
        {
            _pool = pool ?? ThrowHelper.ThrowArgumentNullException(pool, nameof(pool))!;
            _clearOnReturn = clearOnReturn;
            Value = _pool!.Rent(minimumLength);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Dispose()
        {
            if (Value is {})
                _pool?.Return(Value, _clearOnReturn);
        }
    }
}

#endif
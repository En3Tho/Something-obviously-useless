#if !NETSTANDARD2_0
using System.Buffers;
using System.Runtime.CompilerServices;

namespace En3Tho.HelperClasses.Disposable.RefStructs
{
    public readonly ref struct ArrayFromSharedPool<T>
    {
        private readonly bool _clearOnReturn;

        public T[]? Value
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ArrayFromSharedPool(int minimumLength, bool clearOnReturn = true)
        {
            Value = ArrayPool<T>.Shared.Rent(minimumLength);
            _clearOnReturn = clearOnReturn;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Dispose()
        {
            if (Value is {})
                ArrayPool<T>.Shared.Return(Value, _clearOnReturn);
        }
    }
}

#endif
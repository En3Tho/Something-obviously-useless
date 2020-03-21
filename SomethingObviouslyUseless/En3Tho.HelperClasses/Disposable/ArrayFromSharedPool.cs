#if !NETSTANDARD2_0
using System.Buffers;
using System.Runtime.CompilerServices;

namespace En3Tho.HelperClasses.Disposable.RefStructs
{
    public readonly struct ArrayFromSharedPool<T>
    {
        private readonly bool m_clearOnReturn;

        public readonly T[] Value
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ArrayFromSharedPool(int minimumLength, bool clearOnReturn = true)
        {
            Value = ArrayPool<T>.Shared.Rent(minimumLength);
            m_clearOnReturn = clearOnReturn;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Dispose()
        {
            if (Value is { })
                ArrayPool<T>.Shared.Return(Value, m_clearOnReturn);
        }
    }
}

#endif
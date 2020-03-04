using System;
using System.Buffers;
using System.Runtime.CompilerServices;
using ExtensionsAndStuff.HelperClasses;

namespace ExtensionsAndStuff.RefStructs
{
    public struct ArrayFromCustomPool
    {
        public readonly ref struct PooledArrayCustom<TPool, T> where TPool : ArrayPool<T>
        {
            private readonly ArrayPool<T> m_Pool;
            private readonly bool m_ClearOnReturn;

            public readonly T[] Value { [MethodImpl(MethodImplOptions.AggressiveInlining)] get; }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public PooledArrayCustom(ArrayPool<T> pool, int minimumLength, bool clearOnReturn = true)
            {
                if (pool == null) ThrowHelper.ThrowArgumentNullException(nameof(pool));
                
                m_Pool = pool!;
                m_ClearOnReturn = clearOnReturn;
                Value = pool!.Rent(minimumLength);
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public void Dispose()
            {
                if (Value is { })
                    m_Pool.Return(Value, m_ClearOnReturn);
            }
        }
    }
}
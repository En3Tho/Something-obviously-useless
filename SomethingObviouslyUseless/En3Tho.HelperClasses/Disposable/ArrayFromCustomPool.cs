﻿using System.Buffers;
using System.Runtime.CompilerServices;

namespace En3Tho.HelperClasses.Disposable.RefStructs
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
                m_Pool = pool ?? ThrowHelper.ThrowArgumentNullException(pool, nameof(pool))!;
                m_ClearOnReturn = clearOnReturn;
                Value = m_Pool!.Rent(minimumLength);
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
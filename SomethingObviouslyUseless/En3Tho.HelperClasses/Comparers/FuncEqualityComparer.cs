using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace En3Tho.HelperClasses.Comparers
{
    public class FuncEqualityComparer<T> : IEqualityComparer<T>
    {
        private readonly Func<T, T, bool> _equals;
        private readonly Func<T, int> _getHashCode;

        public FuncEqualityComparer(Func<T, T, bool> equals, Func<T, int> getHashCode)
        {
            _getHashCode = getHashCode;
            _equals = equals;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(T x, T y) => _equals(x, y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int GetHashCode(T obj) => _getHashCode(obj);
    }
}
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace En3Tho.HelperClasses.Comparers
{
    public sealed class FuncComparer<T> : IComparer<T>
    {
        private readonly Func<T, T, int> _compare;

        public FuncComparer(Func<T, T, int> compare) => _compare = compare;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int Compare(T x, T y) => _compare(x, y);
    }
}
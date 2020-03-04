using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace ExtensionsAndStuff.HelperClasses.DelegateBased
{
    public class DelegateComparer<T> : IComparer<T>
    {
        private readonly Func<T, T, int> _compare;

        public DelegateComparer(Func<T, T, int> compare)
        {
            _compare = compare;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int Compare(T x, T y) => _compare(x, y);
    }
}
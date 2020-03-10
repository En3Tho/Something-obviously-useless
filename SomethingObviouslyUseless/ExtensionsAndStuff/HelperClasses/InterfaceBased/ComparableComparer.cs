using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace ExtensionsAndStuff.HelperClasses.DelegateBased
{
    class ComparableComparer<T> : IComparer<T> where T : IComparable<T>
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int Compare([AllowNull] T x, [AllowNull] T y) => x.CompareTo(y);

        public static ComparableComparer<T> Default { [MethodImpl(MethodImplOptions.AggressiveInlining)] get; } = new ComparableComparer<T>();
    }
}

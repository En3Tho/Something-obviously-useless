using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Text;

namespace ExtensionsAndStuff.HelperClasses.InterfaceBased
{
    class IEqutableEqualityComparer<T> : IEqualityComparer<T> where T : IEquatable<T>
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals([AllowNull] T x, [AllowNull] T y) => x.Equals(y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int GetHashCode([DisallowNull] T obj) => obj.GetHashCode();

        public static IEqutableEqualityComparer<T> Default { [MethodImpl(MethodImplOptions.AggressiveInlining)] get; } = new IEqutableEqualityComparer<T>();
    }
}

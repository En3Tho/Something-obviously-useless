using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Text;

namespace ExtensionsAndStuff.HelperClasses.InterfaceBased
{
    class EquatableEqualityComparer<T> : IEqualityComparer<T> where T : IEquatable<T>
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals([AllowNull] T x, [AllowNull] T y) => x.Equals(y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int GetHashCode([DisallowNull] T obj) => obj.GetHashCode();

        public static EquatableEqualityComparer<T> Default { [MethodImpl(MethodImplOptions.AggressiveInlining)] get; } = new EquatableEqualityComparer<T>();
    }
}

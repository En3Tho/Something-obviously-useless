using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Microsoft.FSharp.Core;

namespace Benchmarks.CSharp.Lib
{
    public static class GSeqCSharp
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TResult Fold<TResult, TItem, TEnumerator>(TResult result, FSharpFunc<TResult, FSharpFunc<TItem, TResult>> folder, TEnumerator enumerator)
            where TEnumerator : IEnumerator<TItem>
        {
            var fSharpFunc = OptimizedClosures.FSharpFunc<TResult, TItem, TResult>.Adapt(folder);
            var enumerator2 = enumerator;
            var result2 = result;
            while (enumerator2.MoveNext())
                result2 = fSharpFunc.Invoke(result2, enumerator2.Current);

            return result2;
        }
    }
}
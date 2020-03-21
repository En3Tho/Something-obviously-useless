using System.Collections.Generic;
 using System.Linq;
 using System.Runtime.CompilerServices;
using ExtensionsAndStuff.RefStructs.SpanList;

namespace ExtensionsAndStuff.Unsafe.SpanHeapListExtensions
 {
     public static class SpanHeapListUnsafeExtensions
     {
         [MethodImpl(MethodImplOptions.AggressiveInlining)]
         public static IEnumerable<T> AsEnumerable<T>(this SpanHeapList<T> list) => new SpanHeapListEnumerable<T>(list.Slice());
     }
 }
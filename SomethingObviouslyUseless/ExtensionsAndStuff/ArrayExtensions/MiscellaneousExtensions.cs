using System;
 using System.Runtime.CompilerServices;
using ExtensionsAndStuff.HelperClasses;

namespace ExtensionsAndStuff.ArrayExtensions
 {
     public static class MiscellaneousExtensions
     {
         [MethodImpl(MethodImplOptions.AggressiveInlining)]
         public static T[] CreateCopy<T>(this T[] array, int start = 0, int count = 0)
         {
             if (count == 0)
                 return Array.Empty<T>();

             if ((uint)start + (uint)count > (uint)array.Length)
                 ThrowHelper.ThrowArgumentOutOfRangeException("Start + count > length");
                 
             var copy = new T[count];
             Array.Copy(array, start, copy, 0, count);
             return copy;
         }
     }
 }
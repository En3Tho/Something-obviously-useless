using System;

namespace ExtensionsAndStuff.HelperClasses
{
    internal static class ThrowHelper
    {
        public static void ThrowArgumentNullException(string paramName) => throw new ArgumentNullException(paramName);
 
         public static void ThrowArgumentOutOfRangeException(string paramName) => throw new ArgumentOutOfRangeException(paramName);
     }
 }
using System;

namespace ExtensionsAndStuff.HelperClasses
{
    public static class ThrowHelper
    {
        public static void ThrowArgumentNullException(string paramName) => throw new ArgumentNullException(paramName);
 
         public static void ThrowArgumentOutOfRangeException(string paramName) => throw new ArgumentOutOfRangeException(paramName);
     }
 }
using System.Runtime.CompilerServices;

namespace ExtensionsAndStuff.HelperClasses
{
    internal class MiscHelper
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Swap<T>(ref T a, ref T b)
        {
            (a, b) = (b, a);
        }
    }
}
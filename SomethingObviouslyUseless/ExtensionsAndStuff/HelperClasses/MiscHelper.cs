using System.Runtime.CompilerServices;

namespace ExtensionsAndStuff.HelperClasses
{
    public class MiscHelper
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Swap<T>(ref T a, ref T b)
        {
            (a, b) = (b, a);
        }
    }
}
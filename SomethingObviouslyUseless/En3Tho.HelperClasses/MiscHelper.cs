using System.Runtime.CompilerServices;

namespace En3Tho.HelperClasses
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
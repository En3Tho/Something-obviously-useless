using System;
using System.Reflection.Emit;

namespace En3Tho.ILHelpers.DynamicMethodBuilder
{
    public static class DynamicMethodExtensions
    {
        public static T CreateDelegate<T>(this DynamicMethod method) where T : Delegate
        {            
            return (T)method.CreateDelegate(typeof(T));
        }

        public static T CreateDelegate<T>(this DynamicMethod method, object target) where T : Delegate
        {
            return (T)method.CreateDelegate(typeof(T), target);
        }
    }
}

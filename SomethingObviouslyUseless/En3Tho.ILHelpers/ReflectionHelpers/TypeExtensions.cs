using System;
using System.Linq;
using System.Reflection;

namespace En3Tho.ILHelpers.ReflectionHelpers
{
    public static class TypeExtensions
    {
        public static MethodInfo GetGenericMethod(this Type t, string name, int genericArgCount, int paramCount)
            => t.GetMethods().FirstOrDefault(m => m.Name == name && m.GetGenericArguments().Length == genericArgCount && m.GetParameters().Length == paramCount);

        public static MethodInfo GetGenericMethod(this Type t, string name, int argAndParamCount)
            => t.GetMethods().FirstOrDefault(m => m.Name == name && m.GetGenericArguments().Length == argAndParamCount && m.GetParameters().Length == argAndParamCount);

        public static MethodInfo GetAndMakeGenericMethod(this Type t, string name, params Type[] types)
            => t.GetMethods().FirstOrDefault(m => m.Name == name && m.GetGenericArguments().Length == types.Length).MakeGenericMethod(types);

        public static MethodInfo GetAndMakeGenericMethod(this Type t, string name, int paramCount, params Type[] types)
            => t.GetMethods().FirstOrDefault(m => m.Name == name && m.GetGenericArguments().Length == types.Length && m.GetParameters().Length == paramCount).MakeGenericMethod(types);
        
        public static bool IsIEquatable(this Type t) => typeof(IEquatable<>).MakeGenericType(t).IsAssignableFrom(t);

        public static bool IsBasicType(this Type t)
        {
            return t == typeof(byte)
                || t == typeof(sbyte)
                || t == typeof(short)
                || t == typeof(ushort)
                || t == typeof(int)
                || t == typeof(uint)
                || t == typeof(long)
                || t == typeof(ulong)
                || t == typeof(float)
                || t == typeof(double)
                || t == typeof(char)
                || t == typeof(bool)
                || t == typeof(IntPtr)
                || t == typeof(UIntPtr);
        }
    }
}
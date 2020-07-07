using System;
using System.Linq;
using System.Reflection;

namespace LearnIntermediateLanguage.ReflectionHelpers
{
    public static class TypeExtensions
    {
        public static MethodInfo GetGenericMethod(this Type t, string name, int genericArgCount, int paramCount)
            => t.GetMethods().FirstOrDefault(m => m.Name == name && m.GetGenericArguments().Length == genericArgCount && m.GetParameters().Length == paramCount);

        public static MethodInfo GetGenericMethod(this Type t, string name, int argAndParamCount)
            => t.GetMethods().FirstOrDefault(m => m.Name == name && m.GetGenericArguments().Length == argAndParamCount && m.GetParameters().Length == argAndParamCount);
    }
}
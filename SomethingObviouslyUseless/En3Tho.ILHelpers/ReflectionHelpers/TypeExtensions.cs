using System;
using System.Linq;
using System.Reflection;

namespace En3Tho.ILHelpers.ReflectionHelpers
{
    public static class TypeExtensions
    {
        private const BindingFlags PrivateAndPublicInstanceMembers = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static;

        public static MethodInfo? GetGenericMethod(this Type t, string name, int genericArgCount, int paramCount, BindingFlags bindingFlags = PrivateAndPublicInstanceMembers)
            => t.GetMethods(bindingFlags).FirstOrDefault(m => m.Name == name && m.GetGenericArguments().Length == genericArgCount && m.GetParameters().Length == paramCount);

        public static MethodInfo? GetGenericMethod(this Type t, string name, int argAndParamCount, BindingFlags bindingFlags = PrivateAndPublicInstanceMembers)
            => t.GetMethods(bindingFlags).FirstOrDefault(m => m.Name == name && m.GetGenericArguments().Length == argAndParamCount && m.GetParameters().Length == argAndParamCount);

        public static MethodInfo? GetAndMakeGenericMethod(this Type t, string name, BindingFlags bindingFlags = PrivateAndPublicInstanceMembers, params Type[] genericArgTypes)
            => t.GetMethods(bindingFlags).FirstOrDefault(m => m.Name == name && m.GetGenericArguments().Length == genericArgTypes.Length)?.MakeGenericMethod(genericArgTypes);

        public static MethodInfo? GetAndMakeGenericMethod(this Type t, string name, params Type[] genericArgTypes)
            => t.GetMethods(PrivateAndPublicInstanceMembers).FirstOrDefault(m => m.Name == name && m.GetGenericArguments().Length == genericArgTypes.Length)?.MakeGenericMethod(genericArgTypes);

        public static MethodInfo? GetAndMakeGenericMethod(this Type t, string name, int paramCount, params Type[] genericArgTypes)
            => t.GetMethods(PrivateAndPublicInstanceMembers).FirstOrDefault(m => m.Name == name && m.GetGenericArguments().Length == genericArgTypes.Length && m.GetParameters().Length == paramCount)?
               .MakeGenericMethod(genericArgTypes);

        public static MethodInfo? GetAndMakeGenericMethod(this Type t, string name, int paramCount, BindingFlags bindingFlags = PrivateAndPublicInstanceMembers, params Type[] types)
            => t.GetMethods(bindingFlags).FirstOrDefault(m => m.Name == name && m.GetGenericArguments().Length == types.Length && m.GetParameters().Length == paramCount)?
               .MakeGenericMethod(types);

        public static bool IsIEquatableOfSelf(this Type t) => typeof(IEquatable<>).MakeGenericType(t).IsAssignableFrom(t);
    }
}
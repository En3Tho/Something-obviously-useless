using System;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using En3Tho.ILHelpers;
using En3Tho.ILHelpers.DynamicMethodBuilder;
using En3Tho.ILHelpers.IL;
using En3Tho.ILHelpers.ReflectionHelpers;

namespace En3Tho.ILEqualityComparer
{
    // TODO: ToBuilder(Options)
    internal static class ILEqualityComparerGenerator
    {
        /// <summary>
        /// Helpers are used for basic type equality calls and for array equality calls
        /// </summary>
        private static class Helpers
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool ObjectEquals<T>(T left, T right) => Equals(left, right);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static int ObjectGetHashCode<T>(T obj) => obj?.GetHashCode() ?? 0;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool IEquatableEquals<T>(T left, T right) where T : IEquatable<T> => left.Equals(right);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static int IEquatableGetHashCode<T>(T obj) where T : IEquatable<T> => obj?.GetHashCode() ?? 0;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool ILEqualityComparerEquals<T>(T left, T right) => ILEqualityComparer<T>.Default.Equals(left, right);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static int CallILEqualityComparerGetHashCode<T>(T obj) => ILEqualityComparer<T>.Default.GetHashCode(obj);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool NoMembersEquals<T>(T _, T __) => true;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static int NoMembersGetHashCode<T>(T _) => 0;

            // TODO: ArrayHelpers
            private static bool ArrayObjectEquals<T>(T[] left, T[] right) => false;
            private static int ArrayObjectGetHashCode<T>(T[] array) => 0;
            private static bool ArrayIEquatableEquals<T>(T[] left, T[] right) where T : IEquatable<T> => false;
            private static int ArrayIEquatableGetHashCode<T>(T[] array) where T : IEquatable<T> => 0;
        }

        private static readonly MethodInfo ObjEquals;
        private static readonly MethodInfo ObjRefEquals;
        private static readonly MethodInfo IntHashCodeCombine2;
        private static readonly Type[] UnsupportedTypes;

        private const int HashCodeCombineGenericArgumentsLength = 7;

        static ILEqualityComparerGenerator()
        {
            ObjEquals = typeof(object).GetMethod(nameof(object.Equals), BindingFlags.Public | BindingFlags.Static)!;
            ObjRefEquals = typeof(object).GetMethod(nameof(ReferenceEquals), BindingFlags.Public | BindingFlags.Static)!;
            IntHashCodeCombine2 = typeof(HashCode).GetAndMakeGenericMethod(nameof(HashCode.Combine), typeof(int), typeof(int));
            UnsupportedTypes = new[] { typeof(object), typeof(string), typeof(Guid), typeof(decimal) };
        }

        /// <summary>
        /// Filter out all basic types to skip generation of new comparers for them in nested scenarios
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool IsSupportedType(Type type)
            => !UnsupportedTypes.Contains(type)
            && !type.IsArray
            && !type.IsBasicType();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool CanGenerateNoMemberFunc(PropertyInfo[] properties, FieldInfo[] fields)
            => properties.Length + fields.Length == 0;

        // This method always assumes we already have 2 variables on stack
        private static ILGenerator CallEquals(ILGenerator il, Type t)
        {
            if (t.IsBasicType())
                return il.CompareEqual();

            // ToOptions
            // This is default option : prefer full member equality then IEquatable then Equals
            var equals = IsSupportedType(t)
                ? typeof(Helpers).GetAndMakeGenericMethod(nameof(Helpers.ILEqualityComparerEquals), 2, t)
                : t.IsIEquatable()
                    ? typeof(Helpers).GetAndMakeGenericMethod(nameof(Helpers.IEquatableEquals), 2, t)
                    : t.GetMethod(nameof(Equals), new[] { t })
                   ?? t.GetMethod(nameof(Equals), new[] { t, t })
                   ?? ObjEquals;

            if (t.IsValueType)
                return il.Call(equals);

            var left = il.DeclareLocal(t);
            var right = il.DeclareLocal(t);

            il.StoreLocal(right.LocalIndex)
              .StoreLocal(left.LocalIndex);

            var ifNull = il.DefineLabel();
            var next = il.DefineLabel();
            return il.LoadLocal(left.LocalIndex)
                     .LoadLocal(right.LocalIndex)
                     .BranchFalse_S(ifNull, il.LoadLocal(left.LocalIndex))
                     .Branch_S(next, equals.IsVirtual ? il.CallVirtual(equals) : il.Call(equals))
                     .Call(ObjRefEquals, il.MarkLabel2(ifNull))
                     .MarkLabel2(next);
        }

        private static Func<T, T, bool> GenerateEqualsFuncInternal<T>(PropertyInfo[] properties, FieldInfo[] fields)
        {
            var func = new DynamicMethodBuilder<Func<T, T, bool>>($"{nameof(ILEqualityComparer<T>)}<{typeof(T).Name}>.Equals{HashCode.Combine(properties, properties.Length, fields, fields.Length)}")
                      .Locals<Types<bool>>()
                      .IL(il =>
                       {
                           var end = il.DefineLabel();
                           foreach (var prop in properties)
                           {
                               var getMethod = prop.GetMethod!;

                               if (getMethod.IsVirtual)
                                   il.CallVirtual(getMethod, il.LoadArgument(0))
                                     .CallVirtual(getMethod, il.LoadArgument(1));
                               else
                                   il.Call(getMethod, il.LoadArgument(0))
                                     .Call(getMethod, il.LoadArgument(1));

                               il.StoreLocal(0, CallEquals(il, prop.PropertyType))
                                 .BranchFalse_S(end, il.LoadLocal(0));
                           }

                           foreach (var field in fields)
                           {
                               var fieldName = field.Name;
                               if (fieldName.EndsWith("k__BackingField")) continue;

                               il.LoadField(field, il.LoadArgument(0))
                                 .LoadField(field, il.LoadArgument(1))
                                 .StoreLocal(0, CallEquals(il, field.FieldType))
                                 .BranchFalse_S(end, il.LoadLocal(0));
                           }

                           il.StoreLocal(0, il.LoadInteger(1))
                             .LoadLocal(0, il.MarkLabel2(end))
                             .Return();
                       })
                      .Build();
            return func;
        }

        private static Func<T, T, bool> GenerateEqualsHelper<T>(PropertyInfo[] properties, FieldInfo[] fields)
        {
            var (eq, name) = typeof(T).IsIEquatable()
                ? (typeof(Helpers).GetAndMakeGenericMethod(nameof(Helpers.IEquatableEquals), typeof(T)), nameof(Helpers.IEquatableEquals))
                : CanGenerateNoMemberFunc(properties, fields)
                    ? (typeof(Helpers).GetAndMakeGenericMethod(nameof(Helpers.NoMembersEquals), typeof(T)), nameof(Helpers.NoMembersEquals))
                    : (typeof(Helpers).GetAndMakeGenericMethod(nameof(Helpers.ObjectEquals), typeof(T)), nameof(Helpers.ObjectEquals));

            var func = new DynamicMethodBuilder<Func<T, T, bool>>($"{nameof(ILEqualityComparer<T>)}<{typeof(T).Name}>.{name}{eq.GetHashCode()}")
                      .IL(il => il.Call(eq, il.LoadArgument(0, 1)).Return())
                      .Build();
            return func;
        }

        public static Func<T, T, bool> GenerateEqualsFunc<T>(PropertyInfo[] properties, FieldInfo[] fields)
        {
            return IsSupportedType(typeof(T))
                ? GenerateEqualsFuncInternal<T>(properties, fields)
                : GenerateEqualsHelper<T>(properties, fields);
        }

        public static Func<T, T, bool> GenerateEqualsFunc<T>(bool includePrivateMembers = false)
        {
            var flags = BindingFlags.Public | BindingFlags.Instance | (includePrivateMembers ? BindingFlags.NonPublic : default);
            var properties = typeof(T).GetProperties(flags);
            var fields = typeof(T).GetFields(flags);
            return GenerateEqualsFunc<T>(properties, fields);
        }

        private static Func<T, int> GenerateGetHashCodeFuncWithHelpers<T>(PropertyInfo[] properties, FieldInfo[] fields)
        {
            var ghc = CanGenerateNoMemberFunc(properties, fields)
                ? typeof(T).IsIEquatable()
                    ? typeof(Helpers).GetAndMakeGenericMethod(nameof(Helpers.IEquatableGetHashCode), typeof(T))
                    : typeof(Helpers).GetAndMakeGenericMethod(nameof(Helpers.NoMembersGetHashCode), typeof(T))
                : typeof(T).IsIEquatable()
                    ? typeof(Helpers).GetAndMakeGenericMethod(nameof(Helpers.IEquatableGetHashCode), typeof(T))
                    : typeof(Helpers).GetAndMakeGenericMethod(nameof(Helpers.ObjectGetHashCode), typeof(T));

            var func = new DynamicMethodBuilder<Func<T, int>>($"{nameof(ILEqualityComparer<T>)}<{typeof(T).Name}>.GetHashCodeBasic")
                      .IL(il => il.Call(ghc, il.LoadArgument(0)).Return())
                      .Build();
            return func;
        }

        private static ILGenerator CallNestedGetHashCode(ILGenerator il, Type t)
        {
            if (t.IsIEquatable())
            {
                var ghcEq = typeof(Helpers).GetAndMakeGenericMethod(nameof(Helpers.IEquatableGetHashCode), 1, t);
                il.Call(ghcEq);
            }
            else if (IsSupportedType(t))
            {
                var ghcComp = typeof(Helpers).GetAndMakeGenericMethod(nameof(Helpers.CallILEqualityComparerGetHashCode), 1, t);
                il.Call(ghcComp);
            }

            return il;
        }

        private static Func<T, int> GenerateGetHashCodeFuncInternal<T>(PropertyInfo[] properties, FieldInfo[] fields)
        {
            var func = new DynamicMethodBuilder<Func<T, int>>($"{nameof(ILEqualityComparer<T>)}<{typeof(T).Name}>.GetHashCode{HashCode.Combine(properties, properties.Length, fields, fields.Length)}")
                      .Locals<Types<int>>()
                      .IL(il =>
                       {
                           void generatePropertyHashCodeCombine(PropertyInfo[] propertyInfos)
                           {
                               if (propertyInfos.Length == 0) return;
                               var types = propertyInfos.Select(p => !IsSupportedType(p.PropertyType) && !p.PropertyType.IsIEquatable() ? p.PropertyType : typeof(int)).ToArray();
                               var ghc = typeof(HashCode).GetAndMakeGenericMethod(nameof(HashCode.Combine), types);

                               foreach (var property in propertyInfos)
                               {
                                   il.Call(property.GetMethod!, il.LoadArgument(0));
                                   CallNestedGetHashCode(il, property.PropertyType);
                               }

                               il.Call(IntHashCodeCombine2, il.Call(ghc).LoadLocal(0))
                                 .StoreLocal(0);
                           }

                           void generateFieldHashCodeCombine(FieldInfo[] fieldInfos)
                           {
                               fieldInfos = fieldInfos.Where(f => !f.Name.EndsWith("k__BackingField")).ToArray();
                               if (fieldInfos.Length == 0) return;

                               var types = fieldInfos.Select(p => !IsSupportedType(p.FieldType) && !p.FieldType.IsIEquatable() ? p.FieldType : typeof(int)).ToArray();
                               var ghc = typeof(HashCode).GetAndMakeGenericMethod(nameof(HashCode.Combine), types);
                               foreach (var field in fieldInfos)
                               {
                                   il.LoadField(field, il.LoadArgument(0));
                                   CallNestedGetHashCode(il, field.FieldType);
                               }

                               il.Call(IntHashCodeCombine2, il.Call(ghc).LoadLocal(0))
                                 .StoreLocal(0);
                           }

                           // filter by !IsSupportedType and generate comparer generated hashcode for supported types
                           const int argsl = HashCodeCombineGenericArgumentsLength;
                           for (int i = 0; i + argsl < properties.Length / argsl; i += argsl)
                               generatePropertyHashCodeCombine(properties.Skip(i).Take(argsl).ToArray());
                           generatePropertyHashCodeCombine(properties.TakeLast(properties.Length % argsl).ToArray());

                           for (int i = 0; i + argsl < fields.Length / argsl; i += argsl)
                               generateFieldHashCodeCombine(fields.Skip(i).Take(argsl).ToArray());
                           generateFieldHashCodeCombine(fields.TakeLast(fields.Length % argsl).ToArray());

                           il.LoadLocal(0)
                             .Return();
                       })
                      .Build();
            return func;
        }

        public static Func<T, int> GenerateGetHashCodeFunc<T>(PropertyInfo[] properties, FieldInfo[] fields)
        {
            return IsSupportedType(typeof(T))
                ? GenerateGetHashCodeFuncInternal<T>(properties, fields)
                : GenerateGetHashCodeFuncWithHelpers<T>(properties, fields);
        }

        public static Func<T, int> GenerateGetHashCodeFunc<T>(bool includePrivateMembers = false)
        {
            var flags = BindingFlags.Public | BindingFlags.Instance | (includePrivateMembers ? BindingFlags.NonPublic : default);
            var properties = typeof(T).GetProperties(flags);
            var fields = typeof(T).GetFields(flags);
            return GenerateGetHashCodeFunc<T>(properties, fields);
        }
    }
}
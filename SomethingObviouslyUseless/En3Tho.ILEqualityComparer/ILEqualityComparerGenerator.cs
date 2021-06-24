using System;
using System.Collections.Generic;
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
    // TODO: Copy Equality Logic From C# 9 Records Feature, enable such logic for any class/struct basically
    internal static class ILEqualityComparerGenerator
    {
        /// <summary>
        /// Helpers are used for basic type equality calls and for array equality calls
        /// </summary>
        private static class Helpers
        {
            private static readonly Type T;

            static Helpers() => T = typeof(Helpers);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private static bool ObjectEquals<T>(T left, T right) => Equals(left, right);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private static int ObjectGetHashCode<T>(T obj) => obj?.GetHashCode() ?? 0;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private static bool IEquatableEquals<T>(T left, T right) where T : IEquatable<T> => left.Equals(right);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private static int IEquatableGetHashCode<T>(T obj) where T : IEquatable<T> => obj?.GetHashCode() ?? 0;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private static bool ILEqualityComparerEquals<T>(T left, T right) => ILEqualityComparer<T>.Default.Equals(left, right);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private static int ILEqualityComparerGetHashCode<T>(T obj) => ILEqualityComparer<T>.Default.GetHashCode(obj!);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private static bool NoMembersEquals<T>(T left, T right) => left is { } && right is { } || left is null && right is null;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private static int NoMembersGetHashCode<T>(T obj) => obj is null ? 0 : 1;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private static bool ArrayBasicEqualityChecks<T>(T[]? left, T[]? right)
            {
                if (ReferenceEquals(left, right)) return true;
                if (left is null || right is null) return false;
                return left.Length == right.Length;
            }

            // TODO: ArrayHelpers
            private static bool ArrayObjectEquals<T>(T[] left, T[] right)
            {
                if (!ArrayBasicEqualityChecks(left, right)) return false;
                for (int i = 0; i < left.Length; i++)
                    if (!Equals(left[i], right[i]))
                        return false;
                return true;
            }

            private static int ArrayObjectGetHashCode<T>(T[] array)
            {
                if ((array?.Length ?? 0) == 0) return 0;
                int hashCode = 0;
                for (int i = 0; i + 8 < array!.Length; i += 8)
                    hashCode = HashCode.Combine(array[i], array[i + 1], array[i + 2], array[i + 3], array[i + 4], array[i + 5], array[i + 6], array[i + 7]);
#pragma warning disable CS8509
                return (array.Length % 8) switch
#pragma warning restore CS8509
                {
                    0 => hashCode,
                    1 => HashCode.Combine(array[0], hashCode),
                    2 => HashCode.Combine(array[0], array[1], hashCode),
                    3 => HashCode.Combine(array[0], array[1], array[2], hashCode),
                    4 => HashCode.Combine(array[0], array[1], array[2], array[3], hashCode),
                    5 => HashCode.Combine(array[0], array[1], array[2], array[3], array[4], hashCode),
                    6 => HashCode.Combine(array[0], array[1], array[2], array[3], array[4], array[5], hashCode),
                    7 => HashCode.Combine(array[0], array[1], array[2], array[3], array[4], array[5], array[6], hashCode)
                };
            }

            private static bool ArrayIEquatableEquals<T>(T[] left, T[] right) where T : IEquatable<T>
            {
                return ArrayBasicEqualityChecks(left, right)
                    && left.AsSpan().SequenceEqual(right.AsSpan());
            }

            private static int ArrayIEquatableGetHashCode<T>(T[] array) where T : IEquatable<T>
            {
                if (array?.Length < 1) return 0;
                int hashCode = 0;
                for (int i = 0; i + 8 < array!.Length; i += 8)
                    hashCode = HashCode.Combine(array[i].GetHashCode(), array[i + 1].GetHashCode(), array[i + 2].GetHashCode(), array[i + 3].GetHashCode(), array[i + 4].GetHashCode(),
                        array[i + 5].GetHashCode(), array[i + 6].GetHashCode(), array[i + 7].GetHashCode());
#pragma warning disable CS8509
                return (array.Length % 8) switch
#pragma warning restore CS8509
                {
                    0 => hashCode,
                    1 => HashCode.Combine(array[0].GetHashCode(), hashCode),
                    2 => HashCode.Combine(array[0].GetHashCode(), array[1].GetHashCode(), hashCode),
                    3 => HashCode.Combine(array[0].GetHashCode(), array[1].GetHashCode(), array[2].GetHashCode(), hashCode),
                    4 => HashCode.Combine(array[0].GetHashCode(), array[1].GetHashCode(), array[2].GetHashCode(), array[3].GetHashCode(), hashCode),
                    5 => HashCode.Combine(array[0].GetHashCode(), array[1].GetHashCode(), array[2].GetHashCode(), array[3].GetHashCode(), array[4].GetHashCode(), hashCode),
                    6 => HashCode.Combine(array[0].GetHashCode(), array[1].GetHashCode(), array[2].GetHashCode(), array[3].GetHashCode(), array[4].GetHashCode(), array[5].GetHashCode(),
                        hashCode),
                    7 => HashCode.Combine(array[0].GetHashCode(), array[1].GetHashCode(), array[2].GetHashCode(), array[3].GetHashCode(), array[4].GetHashCode(), array[5].GetHashCode(),
                        array[6].GetHashCode(), hashCode)
                };
            }

            private static bool ArrayILComparerEquals<T>(T[] left, T[] right)
            {
                if (!ArrayBasicEqualityChecks(left, right)) return false;
                ILEqualityComparer<T> comp = ILEqualityComparer<T>.Default;
                for (int i = 0; i < left.Length; i++)
                    if (!comp.Equals(left[i], right[i]))
                        return false;
                return true;
            }

            private static int ArrayILComparerGetHashCode<T>(T[] array)
            {
                if ((array?.Length ?? 0) == 0) return 0;
                ILEqualityComparer<T> comp = ILEqualityComparer<T>.Default;
                int hashCode = 0;
                for (int i = 0; i + 8 < array!.Length; i += 8)
                    hashCode = HashCode.Combine(comp.GetHashCode(array[i]), comp.GetHashCode(array[i + 1]), comp.GetHashCode(array[i + 2]), comp.GetHashCode(array[i + 3]),
                        comp.GetHashCode(array[i + 4]), comp.GetHashCode(array[i + 5]), comp.GetHashCode(array[i + 6]), comp.GetHashCode(array[i + 7]));
#pragma warning disable CS8509
                return (array.Length % 8) switch
#pragma warning restore CS8509
                {
                    0 => hashCode,
                    1 => HashCode.Combine(comp.GetHashCode(array[0]), hashCode),
                    2 => HashCode.Combine(comp.GetHashCode(array[0]), comp.GetHashCode(array[1]), hashCode),
                    3 => HashCode.Combine(comp.GetHashCode(array[0]), comp.GetHashCode(array[1]), comp.GetHashCode(array[2]), hashCode),
                    4 => HashCode.Combine(comp.GetHashCode(array[0]), comp.GetHashCode(array[1]), comp.GetHashCode(array[2]), comp.GetHashCode(array[3]), hashCode),
                    5 => HashCode.Combine(comp.GetHashCode(array[0]), comp.GetHashCode(array[1]), comp.GetHashCode(array[2]), comp.GetHashCode(array[3]), comp.GetHashCode(array[4]), hashCode),
                    6 => HashCode.Combine(comp.GetHashCode(array[0]), comp.GetHashCode(array[1]), comp.GetHashCode(array[2]), comp.GetHashCode(array[3]), comp.GetHashCode(array[4]),
                        comp.GetHashCode(array[5]), hashCode),
                    7 => HashCode.Combine(comp.GetHashCode(array[0]), comp.GetHashCode(array[1]), comp.GetHashCode(array[2]), comp.GetHashCode(array[3]), comp.GetHashCode(array[4]),
                        comp.GetHashCode(array[5]), comp.GetHashCode(array[6]), hashCode)
                };
            }

            // TODO: Collection Helpers

            public static MethodInfo GenerateObjectEquals(Type t) => T.GetAndMakeGenericMethod(nameof(ObjectEquals), t)!;
            public static MethodInfo GenerateObjectGetHashCode(Type t) => T.GetAndMakeGenericMethod(nameof(ObjectGetHashCode), t)!;
            public static MethodInfo GenerateIEquatableEquals(Type t) => T.GetAndMakeGenericMethod(nameof(IEquatableEquals), t)!;
            public static MethodInfo GenerateIEquatableGetHashCode(Type t) => T.GetAndMakeGenericMethod(nameof(IEquatableGetHashCode), t)!;
            public static MethodInfo GenerateILEqualityComparerEquals(Type t) => T.GetAndMakeGenericMethod(nameof(ILEqualityComparerEquals), t)!;
            public static MethodInfo GenerateOILEqualityComparerGetHashCode(Type t) => T.GetAndMakeGenericMethod(nameof(ILEqualityComparerGetHashCode), t)!;
            public static MethodInfo GenerateNoMembersEquals(Type t) => T.GetAndMakeGenericMethod(nameof(NoMembersEquals), t)!;
            public static MethodInfo GenerateNoMembersGetHashCode(Type t) => T.GetAndMakeGenericMethod(nameof(NoMembersGetHashCode), t)!;
        }

        private static readonly MethodInfo ObjEquals;
        private static readonly MethodInfo ObjRefEquals;
        private static readonly MethodInfo IntHashCodeCombine2;
        private static readonly Type[] UnsupportedTypes;

        private const int HashCodeCombineGenericArgumentsLength = 8;

        static ILEqualityComparerGenerator()
        {
            ObjEquals = typeof(object).GetMethod(nameof(object.Equals), BindingFlags.Public | BindingFlags.Static)!;
            ObjRefEquals = typeof(object).GetMethod(nameof(ReferenceEquals), BindingFlags.Public | BindingFlags.Static)!;
            IntHashCodeCombine2 = typeof(HashCode).GetAndMakeGenericMethod(nameof(HashCode.Combine), typeof(int), typeof(int))!;
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
            && !type.IsArray // TODO: implement Array / ICollection / IEnumerable comparison
            && !type.IsPrimitive;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool CanGenerateNoMemberFunc(PropertyInfo[] properties, FieldInfo[] fields)
            => properties.Length + fields.Length == 0;

        // This method always assumes we already have 2 variables on stack
        private static ILGenerator CallEquals(ILGenerator il, Type t)
        {
            if (t.IsPrimitive)
                return il.CompareEqual();

            // ToOptions
            // This is default option : prefer full member equality then IEquatable then Equals
            var equals = IsSupportedType(t)
                ? Helpers.GenerateILEqualityComparerEquals(t)
                : t.IsIEquatableOfSelf()
                    ? Helpers.GenerateIEquatableEquals(t)
                    : t.GetMethod(nameof(Equals), new[] { t })
                   ?? t.GetMethod(nameof(Equals), new[] { t, t })
                   ?? ObjEquals;

            if (t.IsValueType)
                return equals.Call(il);

            var left = il.DeclareLocal(t);
            var right = il.DeclareLocal(t);

            il.StoreLocal(right);
            il.StoreLocal(left);

            var ifNull = il.DefineLabel();
            var next = il.DefineLabel();

            return il.LoadLocal(left)
                     .LoadLocal(right)
                     .BranchFalse_S(ifNull, il.LoadLocal(left))
                     .Branch_S(next, equals.Call(il))
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
                               prop.Get(il.LoadArgument(0));
                               prop.Get(il.LoadArgument(1))
                                   .StoreLocal(0, CallEquals(il, prop.PropertyType))
                                   .BranchFalse_S(end, il.LoadLocal(0));
                           }

                           foreach (var field in fields)
                           {
                               var fieldName = field.Name;
                               if (fieldName.EndsWith("k__BackingField")) continue; // auto-property backing field

                               field.Load(il.LoadArgument(0));
                               field.Load(il.LoadArgument(1))
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
            var t = typeof(T);
            var (eq, name) = t.IsIEquatableOfSelf()
                ? (Helpers.GenerateIEquatableEquals(t), nameof(Helpers.GenerateIEquatableEquals))
                : CanGenerateNoMemberFunc(properties, fields)
                    ? (Helpers.GenerateNoMembersEquals(t), nameof(Helpers.GenerateNoMembersEquals))
                    : (Helpers.GenerateObjectEquals(t), nameof(Helpers.GenerateObjectEquals));

            var func = new DynamicMethodBuilder<Func<T, T, bool>>($"{nameof(ILEqualityComparer<T>)}<{typeof(T).Name}>.{name[8..]}{eq.GetHashCode()}")
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
            var t = typeof(T);
            var ghc = t.IsIEquatableOfSelf()
                ? Helpers.GenerateIEquatableGetHashCode(t)
                : CanGenerateNoMemberFunc(properties, fields)
                    ? Helpers.GenerateNoMembersGetHashCode(t)
                    : Helpers.GenerateObjectGetHashCode(t);

            var func = new DynamicMethodBuilder<Func<T, int>>($"{nameof(ILEqualityComparer<T>)}<{typeof(T).Name}>.GetHashCodeBasic")
                      .IL(il => il.Call(ghc, il.LoadArgument(0)).Return())
                      .Build();
            return func;
        }

        private static ILGenerator CallGetHashCode(ILGenerator il, Type t)
        {
            // TODO: to options
            var ghc = IsSupportedType(t)
                ? Helpers.GenerateOILEqualityComparerGetHashCode(t)
                : t.IsIEquatableOfSelf()
                    ? Helpers.GenerateIEquatableGetHashCode(t)
                    : Helpers.GenerateObjectGetHashCode(t);
            return il.Call(ghc);
        }

        private static Func<T, int> GenerateGetHashCodeFuncInternal<T>(PropertyInfo[] properties, FieldInfo[] fields) // TODO: Copy Roslyn?
        {
            var func = new DynamicMethodBuilder<Func<T, int>>($"{nameof(ILEqualityComparer<T>)}<{typeof(T).Name}>.GetHashCode{HashCode.Combine(properties, properties.Length, fields, fields.Length)}")
                      .Locals<Types<int>>()
                      .IL(il =>
                       {
                           static MethodInfo generateGetHashCode(IEnumerable<Type> types) =>
                               typeof(HashCode).GetAndMakeGenericMethod(nameof(HashCode.Combine),
                                   types.Select(t => !IsSupportedType(t) && !t.IsIEquatableOfSelf() ? t : typeof(int)).ToArray())!;

                           void generatePropertyHashCodeCombine(PropertyInfo[] propertyInfos)
                           {
                               if (propertyInfos.Length == 0) return;
                               var ghc = generateGetHashCode(propertyInfos.Select(p => p.PropertyType));

                               foreach (var property in propertyInfos)
                                   CallGetHashCode(il.LoadArgument(0).Call(property.GetMethod!), property.PropertyType);

                               il.Call(IntHashCodeCombine2, il.Call(ghc).LoadLocal(0))
                                 .StoreLocal(0);
                           }

                           void generateFieldHashCodeCombine(FieldInfo[] fieldInfos)
                           {
                               if (fieldInfos.Length == 0) return;
                               var ghc = generateGetHashCode(fieldInfos.Select(f => f.FieldType));

                               foreach (var field in fieldInfos)
                                   CallGetHashCode(il.LoadArgument(0).LoadField(field), field.FieldType);

                               il.Call(IntHashCodeCombine2, il.Call(ghc).LoadLocal(0))
                                 .StoreLocal(0);
                           }

                           const int argsl = HashCodeCombineGenericArgumentsLength;
                           for (int i = 0; i + argsl < properties.Length / argsl; i += argsl)
                               generatePropertyHashCodeCombine(properties.Skip(i).Take(argsl).ToArray());
                           generatePropertyHashCodeCombine(properties.TakeLast(properties.Length % argsl).ToArray());

                           for (int i = 0; i + argsl < fields.Length / argsl; i += argsl)
                               generateFieldHashCodeCombine(fields.Skip(i).Take(argsl).ToArray());
                           generateFieldHashCodeCombine(fields.TakeLast(fields.Length % argsl).ToArray());

                           il.LoadLocal(0).Return();
                       })
                      .Build();
            return func;
        }

        public static Func<T, int> GenerateGetHashCodeFunc<T>(PropertyInfo[] properties, FieldInfo[] fields)
        {
            return IsSupportedType(typeof(T))
                ? GenerateGetHashCodeFuncInternal<T>(properties, fields.Where(f => !f.Name.EndsWith("k__BackingField")).ToArray())
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
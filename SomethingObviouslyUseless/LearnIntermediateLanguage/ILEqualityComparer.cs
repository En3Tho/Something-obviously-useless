using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using LearnIntermediateLanguage.IL;
using LearnIntermediateLanguage.ReflectionHelpers;

namespace LearnIntermediateLanguage
{
    /// <summary>
    /// Auto-Generated IL Comparer. Works as EqualityComparer.Default for simple types. Uses HashCode.Combine as HashCodeFunction.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ILEqualityComparer<T> : IEqualityComparer<T>
    {
        private readonly Func<T, T, bool> _equals;
        private readonly Func<T, int> _ghc;

        private ILEqualityComparer(bool includePrivateMembers) :
            this(ILEqualityComparerGenerator.GenerateEqualsFunc<T>(includePrivateMembers), ILEqualityComparerGenerator.GenerateGetHashCodeFunc<T>(includePrivateMembers)) { }

        private ILEqualityComparer(PropertyInfo[] properties, FieldInfo[] fields) :
            this(ILEqualityComparerGenerator.GenerateEqualsFunc<T>(properties, fields), ILEqualityComparerGenerator.GenerateGetHashCodeFunc<T>(properties, fields)) { }

        private ILEqualityComparer(Func<T, T, bool> equals, Func<T, int> ghc)
        {
            _equals = equals;
            _ghc = ghc;
        }

        /// <summary>
        /// Returns a comparer using all public properties and fields
        /// </summary>
        public static ILEqualityComparer<T> Default { get; } = new ILEqualityComparer<T>(false);

        /// <summary>
        /// Returns a comparer using only provided members
        /// </summary>
        /// <param name="expressions"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public static ILEqualityComparer<T> FromMemberExpressions(params Expression<Func<T, object>>[] expressions)
        {
            if (expressions.Length < 1)
                throw new ArgumentException(nameof(expressions));

            var memberExpressions = expressions.Select(e => e.Body).Cast<UnaryExpression>().Select(ue => ue.Operand).Cast<MemberExpression>().Distinct().ToArray();

            var properties = memberExpressions.Select(e => e.Member).OfType<PropertyInfo>().ToArray();
            var fields = memberExpressions.Select(e => e.Member).OfType<FieldInfo>().ToArray();

            return new ILEqualityComparer<T>(properties, fields);
        }

        // TODO: FromSpecifiedEqualityExpression ?

        /// <summary>
        /// Returns a comparer using all public properties and fields and ignoring provided members
        /// </summary>
        /// <param name="expressions"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public static ILEqualityComparer<T> FromIgnoreMemberExpressions(params Expression<Func<T, object>>[] expressions)
        {
            if (expressions.Length < 1)
                throw new ArgumentException(nameof(expressions));

            const BindingFlags flags = BindingFlags.Instance | BindingFlags.Public;

            var memberExpressions = expressions.Select(e => e.Body).Cast<UnaryExpression>().Select(ue => ue.Operand).Cast<MemberExpression>().ToArray();
            var properties = typeof(T).GetProperties(flags).Except(memberExpressions.Select(me => me.Member).OfType<PropertyInfo>()).ToArray();
            var fields = typeof(T).GetFields(flags).Except(memberExpressions.Select(me => me.Member).OfType<FieldInfo>()).ToArray();

            return new ILEqualityComparer<T>(properties, fields);
        }

        /// <summary>
        /// Returns a comparer using all public and private properties and fields
        /// </summary>
        /// <returns></returns>
        public static ILEqualityComparer<T> WithPrivateMembers() => new ILEqualityComparer<T>(true);

        /// <summary>
        /// Returns a comparer using all public (and private) properties
        /// </summary>
        /// <param name="includePrivateMembers"></param>
        /// <returns></returns>
        public static ILEqualityComparer<T> WithPropertiesOnly(bool includePrivateMembers = false)
        {
            var flags = BindingFlags.Public | BindingFlags.Instance | (includePrivateMembers ? BindingFlags.NonPublic : default);
            return new ILEqualityComparer<T>(typeof(T).GetProperties(flags), Array.Empty<FieldInfo>());
        }

        /// <summary>
        /// Returns a comparer using all public (and private) fields
        /// </summary>
        /// <param name="includePrivateMembers"></param>
        /// <returns></returns>
        public static ILEqualityComparer<T> WithFieldsOnly(bool includePrivateMembers = false)
        {
            var flags = BindingFlags.Public | BindingFlags.Instance | (includePrivateMembers ? BindingFlags.NonPublic : default);
            return new ILEqualityComparer<T>(Array.Empty<PropertyInfo>(), typeof(T).GetFields(flags));
        }

        public bool Equals([AllowNull] T x, [AllowNull] T y) => ReferenceEquals(x, y)
                                                             || x is {} && y is {} && _equals(x, y);

        public int GetHashCode([DisallowNull] T obj) => obj is {} ? _ghc(obj) : 0;
    }

    // TODO: ToBuilder?
    // Prefer IEquatable/Equals(T other) // Compare Arrays (fast/full check) // Allow Recursive Pattern
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
            public static int ObjectGetHashCode<T>(T obj) => obj!.GetHashCode();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool IEquatableEquals<T>(T left, T right) where T : IEquatable<T> => left.Equals(right);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static int IEquatableGetHashCode<T>(T obj) where T : IEquatable<T> => obj.GetHashCode();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool ILEqualityComparerEquals<T>(T left, T right) => ILEqualityComparer<T>.Default.Equals(left, right);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static int CallILEqualityComparerGetHashCode<T>(T obj) => ILEqualityComparer<T>.Default.GetHashCode(obj);

            // TODO: ArrayHelpers
            private static bool ArrayObjectEquals<T>(T[] left, T[] right) => false;
            private static int ArrayObjectGetHashCode<T>(T[] array) => 0;
            private static bool ArrayIEquatableEquals<T>(T[] left, T[] right) where T : IEquatable<T> => false;
            private static int ArrayIEquatableGetHashCode<T>(T[] array) where T : IEquatable<T> => 0;
        }

        private static readonly MethodInfo _ObjEquals;
        private static readonly MethodInfo _ObjRefEquals;
        private static readonly MethodInfo _IntHashCodeCombine2;

        private const int HashCodeCombineGenericArgumentsLength = 7;

        static ILEqualityComparerGenerator()
        {
            _ObjEquals = typeof(object).GetMethod(nameof(object.Equals), BindingFlags.Public | BindingFlags.Static)!;
            _ObjRefEquals = typeof(object).GetMethod(nameof(ReferenceEquals), BindingFlags.Public | BindingFlags.Static)!;
            _IntHashCodeCombine2 = typeof(HashCode).GetAndMakeGenericMethod(nameof(HashCode.Combine), typeof(int), typeof(int));
        }

        /// <summary>
        /// Here we filter out all basic types to skip generation of new comparers for them in nested scenarios
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveOptimization)]
        private static bool IsSupportedType(Type type)
            => type != typeof(string)
            && !type.IsArray
            && !type.IsBasicType();

        [MethodImpl(MethodImplOptions.AggressiveOptimization)]
        private static bool CanAutoGenerateFuncForType(Type type, PropertyInfo[] properties, FieldInfo[] fields)
            => IsSupportedType(type) && properties.Length + fields.Length != 0;

        /// <summary>
        /// This method always assumes we already have 2 variables on stack
        /// </summary>
        /// <param name="il"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        private static ILGenerator CallEquals(ILGenerator il, Type t)
        {
            if (t.IsBasicType())
                return il.CompareEqual();

            var equals = t.GetMethod(nameof(Equals), new[] { t }) ?? t.GetMethod(nameof(Equals), new[] { t, t });
            if (equals == null || equals?.GetParameters()[0].ParameterType == typeof(object))
                equals = t.IsIEquatable()
                    ? typeof(Helpers).GetAndMakeGenericMethod(nameof(Helpers.IEquatableEquals), 2, t)
                    : IsSupportedType(t)
                        ? typeof(Helpers).GetAndMakeGenericMethod(nameof(Helpers.ILEqualityComparerEquals), 2, t)
                        : _ObjEquals;

            if (t.IsValueType)
                return il.Call(equals!);

            var left = il.DeclareLocal(t);
            var right = il.DeclareLocal(t);

            il.StoreLocal(right.LocalIndex)
              .StoreLocal(left.LocalIndex);

            var ifNull = il.DefineLabel();
            var next = il.DefineLabel();
            return il.LoadLocal(left.LocalIndex)
                     .LoadLocal(right.LocalIndex)
                     .BranchFalse_S(ifNull, il.LoadLocal(left.LocalIndex))
                     .Branch_S(next, equals!.IsVirtual ? il.CallVirtual(equals) : il.Call(equals))
                     .Call(_ObjRefEquals, il.MarkLabel2(ifNull))
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

        private static Func<T, T, bool> GenerateEqualsHelper<T>()
        {
            var eq = typeof(T).IsIEquatable()
                ? typeof(Helpers).GetAndMakeGenericMethod(nameof(Helpers.IEquatableEquals), typeof(T))
                : typeof(Helpers).GetAndMakeGenericMethod(nameof(Helpers.ObjectEquals), typeof(T));

            var func = new DynamicMethodBuilder<Func<T, T, bool>>($"{nameof(ILEqualityComparer<T>)}<{typeof(T).Name}>.EqualsBasic")
                      .IL(il => il.Call(eq, il.LoadArgument(0, 1)).Return())
                      .Build();
            return func;
        }

        public static Func<T, T, bool> GenerateEqualsFunc<T>(PropertyInfo[] properties, FieldInfo[] fields)
        {
            return CanAutoGenerateFuncForType(typeof(T), properties, fields)
                ? GenerateEqualsFuncInternal<T>(properties, fields)
                : GenerateEqualsHelper<T>();
        }

        public static Func<T, T, bool> GenerateEqualsFunc<T>(bool includePrivateMembers = false)
        {
            var flags = BindingFlags.Public | BindingFlags.Instance | (includePrivateMembers ? BindingFlags.NonPublic : default);
            var properties = typeof(T).GetProperties(flags);
            var fields = typeof(T).GetFields(flags);
            return GenerateEqualsFunc<T>(properties, fields);
        }

        private static Func<T, int> GenerateGetHashCodeFuncWithHelpers<T>()
        {
            var ghc = typeof(T).IsIEquatable()
                ? typeof(Helpers).GetAndMakeGenericMethod(nameof(Helpers.IEquatableGetHashCode), typeof(T))
                : typeof(Helpers).GetAndMakeGenericMethod(nameof(Helpers.ObjectGetHashCode), typeof(T));

            var func = new DynamicMethodBuilder<Func<T, int>>($"{nameof(ILEqualityComparer<T>)}<{typeof(T).Name}>.GetHashCodeBasic")
                      .IL(il =>
                       {
                           il.Call(ghc, il.LoadArgument(0))
                             .Return();
                       }).Build();
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
                                   var t = property.PropertyType;
                                   il.Call(property.GetMethod!, il.LoadArgument(0));
                                   CallNestedGetHashCode(il, t);
                               }

                               il.Call(_IntHashCodeCombine2, il.Call(ghc).LoadLocal(0))
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
                                   var t = field.FieldType;
                                   il.LoadField(field, il.LoadArgument(0));
                                   CallNestedGetHashCode(il, t);
                               }

                               il.Call(_IntHashCodeCombine2, il.Call(ghc).LoadLocal(0))
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
            return CanAutoGenerateFuncForType(typeof(T), properties, fields)
                ? GenerateGetHashCodeFuncInternal<T>(properties, fields)
                : GenerateGetHashCodeFuncWithHelpers<T>();
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
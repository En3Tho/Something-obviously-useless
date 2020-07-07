using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Reflection.Emit;
using LearnIntermediateLanguage.IL;
using LearnIntermediateLanguage.ReflectionHelpers;

namespace LearnIntermediateLanguage
{
    public class ILEqualityComparer<T> : IEqualityComparer<T>
    {
        private readonly Func<T, T, bool> _equals;
        private readonly Func<T, int> _ghc;

        private ILEqualityComparer(bool includePrivateMembers) :
            this(ILEqualityComparerGenerator.GenerateEquals<T>(includePrivateMembers), ILEqualityComparerGenerator.GenerateGetHashCode<T>(includePrivateMembers)) { }
        
        private ILEqualityComparer(Func<T, T, bool> equals, Func<T, int> ghc)
        {
            _equals = equals;
            _ghc = ghc;
        }

        public static ILEqualityComparer<T> Default { get; } = new ILEqualityComparer<T>(false);

        public static ILEqualityComparer<T> WithPrivateMembers { get; } = new ILEqualityComparer<T>(true);

        public static ILEqualityComparer<T> FromMemberExpressions(params Expression<Func<T, object>>[] expressions)
        {
            if (expressions.Length < 1)
                throw new ArgumentException(nameof(expressions));

            var memberExpressions = expressions.Select(e => e.Body).Cast<UnaryExpression>().Select(ue => ue.Operand).Cast<MemberExpression>().ToArray();

            var equals = ILEqualityComparerGenerator.GenerateEquals<T>(memberExpressions);
            var ghc = ILEqualityComparerGenerator.GenerateGetHashCode<T>(memberExpressions);
            return new ILEqualityComparer<T>(equals, ghc);
        }

        public bool Equals(T x, T y) => x is {} && y is {} && _equals(x, y);

        public int GetHashCode(T obj) => obj is {} ? _ghc(obj) : 0;
    }

    internal static class ILEqualityComparerGenerator
    {
        private static readonly MethodInfo _ObjEquals;
        private static readonly MethodInfo _IntHashCodeCombine2;

        static ILEqualityComparerGenerator()
        {
            _ObjEquals = typeof(object).GetMethod(nameof(object.Equals), BindingFlags.Public | BindingFlags.Static)!;
            _IntHashCodeCombine2 = typeof(HashCode).GetGenericMethod(nameof(HashCode.Combine), 2).MakeGenericMethod(typeof(int), typeof(int));
        }

        private static ILGenerator CallEquals(ILGenerator il, Type t)
        {
            if (t == typeof(byte)
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
             || t == typeof(UIntPtr))
                return il.CompareEqual();

            // TODO: check for Explicit IEquatableInterface?
            var equals = t.GetMethod(nameof(object.Equals), new[] { t });
            if (!t.IsClass)
                return equals is {} ? il.Call(equals) : il.Call(_ObjEquals);

            var local1 = il.DeclareLocal(t);
            var local2 = il.DeclareLocal(t);

            il.StoreLocal(local1.LocalIndex)
              .StoreLocal(local2.LocalIndex);

            var ifNull = il.DefineLabel();
            var next = il.DefineLabel();
            il.LoadLocal(local1.LocalIndex)
              .LoadLocal(local2.LocalIndex)
              .BranchFalse_S(ifNull, il.LoadLocal(local1.LocalIndex));

            return (equals is {}
                       ? il.Call(equals)
                       : il.Call(_ObjEquals))
                  .Branch(next)
                  .Call(_ObjEquals, il.MarkLabel2(ifNull))
                  .MarkLabel2(next);
        }

        private static Func<T, T, bool> GenerateEqualsFunc<T>(PropertyInfo[] properties, FieldInfo[] fields)
        {
            var func = new DynamicMethodBuilder<Func<T, T, bool>>($"{nameof(ILEqualityComparer<T>)}<{typeof(T).Name}>.Equals{HashCode.Combine(properties, properties.Length, fields, fields.Length)}")
                      .Locals<Types<bool>>()
                      .IL(il =>
                       {
                           var end = il.DefineLabel();
                           foreach (var prop in properties)
                           {
                               var getMethod = prop.GetMethod!;
                               var localType = prop.PropertyType;

                               il.CallVirtual(getMethod, il.LoadArgument(0))
                                 .CallVirtual(getMethod, il.LoadArgument(0))
                                 .StoreLocal(0, CallEquals(il, localType))
                                 .BranchFalse(end, il.LoadLocal(0));
                           }

                           foreach (var field in fields)
                           {
                               var fieldName = field.Name;
                               if (fieldName.EndsWith("k__BackingField")) continue;

                               var localType = field.FieldType;
                               il.LoadField(field, il.LoadArgument(0))
                                 .LoadField(field, il.LoadArgument(1))
                                 .StoreLocal(0, CallEquals(il, localType))
                                 .BranchFalse(end, il.LoadLocal(0));
                           }

                           il.StoreLocal(0, il.LoadInteger(1))
                             .LoadLocal(0, il.MarkLabel2(end))
                             .Return();
                       })
                      .Build();
            return func;
        }

        public static Func<T, T, bool> GenerateEquals<T>(MemberExpression[] expressions)
        {
            var properties = expressions.Select(e => e.Member).OfType<PropertyInfo>().ToArray();
            var fields = expressions.Select(e => e.Member).OfType<FieldInfo>().ToArray();
            return GenerateEqualsFunc<T>(properties, fields);
        }

        public static Func<T, T, bool> GenerateEquals<T>(bool includePrivateMembers = false)
        {
            var flags = BindingFlags.Public | BindingFlags.Instance | (includePrivateMembers ? BindingFlags.NonPublic : default);
            var properties = typeof(T).GetProperties(flags);
            var fields = typeof(T).GetFields(flags);
            return GenerateEqualsFunc<T>(properties, fields);
        }

        private static Func<T, int> GenerateGetHashCodeFunc<T>(PropertyInfo[] properties, FieldInfo[] fields)
        {
            var func = new DynamicMethodBuilder<Func<T, int>>($"{nameof(ILEqualityComparer<T>)}<{typeof(T).Name}>.GetHashCode{HashCode.Combine(properties, properties.Length, fields, fields.Length)}")
                      .Locals<Types<int>>()
                      .IL(il =>
                       {
                           void generatePropertyHashCodeCombine(PropertyInfo[] propertyInfos)
                           {
                               if (propertyInfos.Length == 0) return;
                               var types = propertyInfos.Select(p => p.PropertyType).ToArray();
                               var ghc = typeof(HashCode).GetGenericMethod(nameof(HashCode.Combine), types.Length).MakeGenericMethod(types);
                               foreach (var property in propertyInfos)
                                   il.Call(property.GetMethod!, il.LoadArgument(0));
                               il.Call(_IntHashCodeCombine2, il.Call(ghc).LoadLocal(0))
                                 .StoreLocal(0);
                           }

                           void generateFieldHashCodeCombine(FieldInfo[] fieldInfos)
                           {
                               if (fieldInfos.Length == 0) return;
                               var types = fieldInfos.Select(f => f.FieldType).ToArray();
                               var ghc = typeof(HashCode).GetGenericMethod(nameof(HashCode.Combine), types.Length).MakeGenericMethod(types);
                               foreach (var field in fieldInfos)
                               {
                                   if (field.Name.EndsWith("k__BackingField")) continue;
                                   il.LoadField(field, il.LoadArgument(0));
                               }

                               il.Call(_IntHashCodeCombine2, il.Call(ghc).LoadLocal(0))
                                 .StoreLocal(0);
                           }

                           for (int i = 0; i + 7 < properties.Length / 7; i += 7)
                               generatePropertyHashCodeCombine(properties.Skip(i).Take(i).ToArray());
                           generatePropertyHashCodeCombine(properties.TakeLast(properties.Length % 7).ToArray());

                           for (int i = 0; i + 7 < fields.Length / 7; i += 7)
                               generateFieldHashCodeCombine(fields.Skip(i).Take(i).ToArray());
                           generateFieldHashCodeCombine(fields.TakeLast(fields.Length % 7).ToArray());

                           il.LoadLocal(0)
                             .Return();
                       })
                      .Build();
            return func;
        }

        public static Func<T, int> GenerateGetHashCode<T>(MemberExpression[] expressions)
        {
            var properties = expressions.Select(e => e.Member).OfType<PropertyInfo>().ToArray();
            var fields = expressions.Select(e => e.Member).OfType<FieldInfo>().ToArray();
            return GenerateGetHashCodeFunc<T>(properties, fields);
        }

        public static Func<T, int> GenerateGetHashCode<T>(bool includePrivateMembers = false)
        {
            var flags = BindingFlags.Public | BindingFlags.Instance | (includePrivateMembers ? BindingFlags.NonPublic : default);
            var properties = typeof(T).GetProperties(flags);
            var fields = typeof(T).GetFields(flags);
            return GenerateGetHashCodeFunc<T>(properties, fields);
        }
    }
}
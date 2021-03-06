﻿using System;
using System.Reflection;
using En3Tho.ILEqualityComparer;
using En3Tho.ILHelpers;
using En3Tho.ILHelpers.DynamicMethodBuilder;
using En3Tho.ILHelpers.IL;
using En3Tho.ILHelpers.ReflectionHelpers;

namespace LearnIntermediateLanguage
{
    public static class DynamicMethods
    {
        public static object GetIlComparer()
        {
            var t = typeof(object);
            var compGen = typeof(ILEqualityComparer<>).MakeGenericType(t);
            var def = compGen.GetProperty("Default")!.GetMethod!;
            var eq = compGen.GetMethod(nameof(Equals), new[] { t, t })!;
            
            var func = new DynamicMethodBuilder<Func<object>>("GetDiv")
                      .IL(il => il
                               .Call(def).CastClass(typeof(object)).Return())
                      .Build();

            var a = func();
            return a;
        }
        
        public static void GetDiv()
        {
            var func = new DynamicMethodBuilder<Func<int, int, int>>("GetDiv")
                      .IL(il => il
                               .Divide(il.LoadArgument(0, 1)) // пусть принимает Builder?
                               .Return())
                      .Build();
        }

        public static bool TestDuplicate()
        {
            var func = new DynamicMethodBuilder<Func<string, bool>>("GetDiv")
                      .IL(il =>
                       {
                           var equals = typeof(object).GetMethod(nameof(object.Equals), BindingFlags.Public | BindingFlags.Static)!;
                           il
                              .LoadArgument(0)
                              .Duplicate()
                              .Call(equals)
                              .Return();
                       })
                      .Build();

            var result = func("lol");
            return result;
        }
        
        public static void GetRem()
        {
            var func = new DynamicMethodBuilder<Func<int, int, int>>("GetRem")
                      .IL(il => il
                               .Remainder(il.LoadArgument(0, 1))
                               .Return())
                      .Build();
        }

        public static void GetDivRemAdd()
        {
            var func = new DynamicMethodBuilder<Func<int, int, int>>("GetDivRemAdd")
                      .IL(il => il
                               .Divide(il.LoadArgument(0), il.LoadArgument(1))
                               .Remainder(il.LoadArgument(0), il.LoadArgument(1))
                               .Add()
                               .Return())
                      .Build();
        }

        public static void CallCtor()
        {
            var func = new DynamicMethodBuilder<Func<int, int, (int, int)>>("GetDivRemTuple")
                      .Locals<Types<(int, int)>>("x", "y")
                      .IL(il => il
                               .Divide(il.LoadArgument(0), il.LoadArgument(1))
                               .Remainder(il.LoadArgument(0), il.LoadArgument(1))
                               .StoreLocal(0, il.NewObject<(int, int), Types<int, int>>())
                               .LoadField<(int, int)>("Item2", il.LoadLocal(0))
                               .LoadField<(int, int)>("Item1", il.LoadLocal(0))
                               .Return(il.NewObject<(int, int), Types<int, int>>()))
                      .Build();

            var result = func(5, 10);
            var name = func.Method.Name;
        }

        public static Func<T> GetEmptyObject<T>()
        {
            var func = new DynamicMethodBuilder<Func<T>>("GetEmptyObject")
                      .IL(il => il
                               .NewObject<T>()
                               .Return())
                      .Build();

            return func;
        }

        public static Func<T> GetEmptyObject2<T>()
        {
            var func = new DynamicMethodBuilder<Func<T>>("GetEmptyObject")
                      .Locals<Types<T>>()
                      .IL(il => il
                          .Return(il.LoadLocal(0)))
                      .Build();

            return func;
        }
    }
}
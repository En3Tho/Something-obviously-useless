using System;
using System.Reflection;
using System.Reflection.Emit;
using LearnIntermediateLanguage.IL;

namespace LearnIntermediateLanguage
{
    public static class DynamicMethods
    {
        public static void GetDiv()
        {
            var func = new DynamicMethodBuilder<Func<int, int, int>>("GetDiv")
            .IL(il => il
                .Divide(il.LoadArgument(0, 1)) // пусть принимает Builder?
                .Return())
            .Build();
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
            .Locals<Types<(int, int)>>()
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
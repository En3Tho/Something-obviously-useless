using System;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;

namespace LearnIntermediateLanguage.IL
{
    public static class ILGeneratorExtensions
    {
        #region Add

        public static ILGenerator Add(this ILGenerator generator, OpCode first, OpCode second)
            => generator.EmitOpCodes(first, second, OpCodes.Add);

        public static ILGenerator Add(this ILGenerator generator, OpCode first)
            => generator.EmitOpCodes(first, OpCodes.Add);

        public static ILGenerator Add(this ILGenerator generator)
           => generator.EmitOpCodes(OpCodes.Add);

        public static ILGenerator Add(this ILGenerator generator, params ILGenerator[] _)
            => generator.EmitOpCodes(OpCodes.Add);

        #endregion

        #region Call

        public static ILGenerator Call<T>(this ILGenerator generator, string methodName)
        {
            generator.Emit(OpCodes.Call, typeof(T).GetMethod(methodName));
            return generator;
        }

        public static ILGenerator Call<T, U>(this ILGenerator generator, string methodName) where U : struct, ITypesMarker
        {
            generator.Emit(OpCodes.Call, typeof(T).GetMethod(methodName, typeof(U).GetGenericArguments()));
            return generator;
        }

        public static ILGenerator CallCtor<T, U>(this ILGenerator generator) where U : struct, ITypesMarker
        {          
            generator.Emit(OpCodes.Call, typeof(T).GetConstructor(typeof(U).GetGenericArguments()));
            return generator;
        }

        #endregion

        #region Divide

        public static ILGenerator Divide(this ILGenerator generator, OpCode first, OpCode second)
           => generator.EmitOpCodes(first, second, OpCodes.Div);

        public static ILGenerator Divide(this ILGenerator generator, OpCode first)
            => generator.EmitOpCodes(first, OpCodes.Div);

        public static ILGenerator Divide(this ILGenerator generator)
            => generator.EmitOpCodes(OpCodes.Div);

        public static ILGenerator Divide(this ILGenerator generator, params ILGenerator[] _)
         => generator.EmitOpCodes(OpCodes.Div);

        #endregion

        #region Remainder

        public static ILGenerator Remainder(this ILGenerator generator, OpCode first, OpCode second)
          => generator.EmitOpCodes(first, second, OpCodes.Rem);

        public static ILGenerator Remainder(this ILGenerator generator, OpCode first)
            => generator.EmitOpCodes(first, OpCodes.Rem);

        public static ILGenerator Remainder(this ILGenerator generator)
            => generator.EmitOpCodes(OpCodes.Rem);

        public static ILGenerator Remainder(this ILGenerator generator, params ILGenerator[] _)
            => generator.EmitOpCodes(OpCodes.Rem);

        #endregion

        #region LoadField

        public static ILGenerator LoadField<T>(this ILGenerator generator, string name, params ILGenerator[] _)
        {
            var field = typeof(T).GetField(name);
            generator.Emit(OpCodes.Ldfld, field);
            return generator;
        }

        #endregion

        #region NewObject

        public static ILGenerator NewObject<T, U>(this ILGenerator generator, params ILGenerator[] _) where U : ITypesMarker
        {
            generator.Emit(OpCodes.Newobj, typeof(T).GetConstructor(typeof(U).GetGenericArguments()));
            return generator;
        }

        #endregion

        #region LoadArgument

        public static ILGenerator LoadArgument(this ILGenerator generator, short index)
        {
            switch (index)
            {
                case 0:
                    generator.Emit(OpCodes.Ldarg_0);
                    break;
                case 1:
                    generator.Emit(OpCodes.Ldarg_1);
                    break;
                case 2:
                    generator.Emit(OpCodes.Ldarg_2);
                    break;
                case 3:
                    generator.Emit(OpCodes.Ldarg_3);
                    break;
                default:
                    generator.Emit(OpCodes.Ldarg, index);
                    break;
            }

            return generator;
        }

        public static ILGenerator LoadArgument(this ILGenerator generator, params short[] index)
        {
            foreach (var i in index)
                generator.LoadArgument(i);

            return generator;
        }

        public static ILGenerator LoadArgument(this ILGenerator generator, byte index)
        {
            switch (index)
            {
                case 0:
                    generator.Emit(OpCodes.Ldarg_0);
                    break;
                case 1:
                    generator.Emit(OpCodes.Ldarg_1);
                    break;
                case 2:
                    generator.Emit(OpCodes.Ldarg_2);
                    break;
                case 3:
                    generator.Emit(OpCodes.Ldarg_3);
                    break;
                default:
                    generator.Emit(OpCodes.Ldarg_S, index);
                    break;
            }

            return generator;
        }

        public static ILGenerator LoadArgument(this ILGenerator generator, params byte[] index)
        {
            foreach (var i in index)
                generator.LoadArgument(i);

            return generator;
        }

        #endregion

        #region LoadLocal

        public static ILGenerator LoadLocal(this ILGenerator generator, short index)
        {
            switch (index)
            {
                case 0:
                    generator.Emit(OpCodes.Ldloc_0);
                    break;
                case 1:
                    generator.Emit(OpCodes.Ldloc_1);
                    break;
                case 2:
                    generator.Emit(OpCodes.Ldloc_2);
                    break;
                case 3:
                    generator.Emit(OpCodes.Ldloc_3);
                    break;
                default:
                    generator.Emit(OpCodes.Ldloc, index);
                    break;
            }

            return generator;
        }

        public static ILGenerator LoadLocal(this ILGenerator generator, params short[] index)
        {
            foreach (var i in index)
                generator.LoadLocal(i);

            return generator;
        }

        public static ILGenerator LoadLocal(this ILGenerator generator, byte index)
        {
            switch (index)
            {
                case 0:
                    generator.Emit(OpCodes.Ldloc_0);
                    break;
                case 1:
                    generator.Emit(OpCodes.Ldloc_1);
                    break;
                case 2:
                    generator.Emit(OpCodes.Ldloc_2);
                    break;
                case 3:
                    generator.Emit(OpCodes.Ldloc_3);
                    break;
                default:
                    generator.Emit(OpCodes.Ldloc, index);
                    break;
            }

            return generator;
        }

        public static ILGenerator LoadLocal(this ILGenerator generator, params byte[] index)
        {
            foreach (var i in index)
                generator.LoadLocal(i);

            return generator;
        }

        #endregion

        #region StoreArgument

        public static ILGenerator StoreArgument(this ILGenerator generator, short index)
        {
            generator.Emit(OpCodes.Starg, index);

            return generator;
        }

        public static ILGenerator StoreArgument(this ILGenerator generator, byte index)
        {
            generator.Emit(OpCodes.Starg_S, index);

            return generator;
        }

        #endregion

        #region StoreLocal

        public static ILGenerator StoreLocal(this ILGenerator generator, short index, params ILGenerator[] _)
        {
            switch (index)
            {
                case 0:
                    generator.Emit(OpCodes.Stloc_0);
                    break;
                case 1:
                    generator.Emit(OpCodes.Stloc_1);
                    break;
                case 2:
                    generator.Emit(OpCodes.Stloc_2);
                    break;
                case 3:
                    generator.Emit(OpCodes.Stloc_3);
                    break;
                default:
                    generator.Emit(OpCodes.Stloc, index);
                    break;
            }

            return generator;
        }

        public static ILGenerator StoreLocal(this ILGenerator generator, byte index, params ILGenerator[] _)
        {
            switch (index)
            {
                case 0:
                    generator.Emit(OpCodes.Stloc_0);
                    break;
                case 1:
                    generator.Emit(OpCodes.Stloc_1);
                    break;
                case 2:
                    generator.Emit(OpCodes.Stloc_2);
                    break;
                case 3:
                    generator.Emit(OpCodes.Stloc_3);
                    break;
                default:
                    generator.Emit(OpCodes.Stloc_S, index);
                    break;
            }

            return generator;
        }

        #endregion

        #region Return

        public static ILGenerator Return(this ILGenerator generator) => generator.EmitOpCodes(OpCodes.Ret);

        public static ILGenerator Return(this ILGenerator generator, params ILGenerator[] _) => generator.EmitOpCodes(OpCodes.Ret);

        #endregion

        #region Emit
        private static ILGenerator EmitOpCodes(this ILGenerator generator, OpCode _1)
        {
            generator.Emit(_1);
            return generator;
        }
        private static ILGenerator EmitOpCodes(this ILGenerator generator, OpCode _1, OpCode _2)
        {
            generator.Emit(_1);
            generator.Emit(_2);
            return generator;
        }
        private static ILGenerator EmitOpCodes(this ILGenerator generator, OpCode _1, OpCode _2, OpCode _3)
        {
            generator.Emit(_1);
            generator.Emit(_2);
            generator.Emit(_3);
            return generator;
        }
        private static ILGenerator EmitOpCodes(this ILGenerator generator, OpCode _1, OpCode _2, OpCode _3, OpCode _4)
        {
            generator.Emit(_1);
            generator.Emit(_2);
            generator.Emit(_3);
            generator.Emit(_4);
            return generator;
        }
        private static ILGenerator EmitOpCodes(this ILGenerator generator, OpCode _1, OpCode _2, OpCode _3, OpCode _4, OpCode _5)
        {
            generator.Emit(_1);
            generator.Emit(_2);
            generator.Emit(_3);
            generator.Emit(_4);
            generator.Emit(_5);
            return generator;
        }
        private static ILGenerator EmitOpCodes(this ILGenerator generator, OpCode _1, OpCode _2, OpCode _3, OpCode _4, OpCode _5, OpCode _6)
        {
            generator.Emit(_1);
            generator.Emit(_2);
            generator.Emit(_3);
            generator.Emit(_4);
            generator.Emit(_5);
            generator.Emit(_6);
            return generator;
        }

        #endregion
    }
}

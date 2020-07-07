using System;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.InteropServices;

namespace LearnIntermediateLanguage.IL
{
    // TODO : add ILGeneratorExtensionsReferenceMethods (param count / names / descr)
    // TODO : add SignatureMethods with 1/2/3 parameters of IlGen + names
    public static class ILGeneratorExtensions
    {
#region Add +

        public static ILGenerator Add(this ILGenerator generator, ILGenerator value1, ILGenerator value2)
            => generator.EmitOpCodes(OpCodes.Add);

        public static ILGenerator Add(this ILGenerator generator, params ILGenerator[] _)
            => generator.EmitOpCodes(OpCodes.Add);

#endregion

#region AddOverflow +

        public static ILGenerator AddOverflow(this ILGenerator generator, ILGenerator value1, ILGenerator value2)
            => generator.EmitOpCodes(OpCodes.Add_Ovf);

        public static ILGenerator AddOverflow(this ILGenerator generator, params ILGenerator[] _)
            => generator.EmitOpCodes(OpCodes.Add_Ovf);

#endregion

#region AddOverflowUnsigned +

        public static ILGenerator AddOverflowUnsigned(this ILGenerator generator, ILGenerator value1, ILGenerator value2)
            => generator.EmitOpCodes(OpCodes.Add_Ovf_Un);

        public static ILGenerator AddOverflowUnsigned(this ILGenerator generator, params ILGenerator[] _)
            => generator.EmitOpCodes(OpCodes.Add_Ovf_Un);

#endregion

#region And +

        public static ILGenerator And(this ILGenerator generator, ILGenerator value1, ILGenerator value2)
            => generator.EmitOpCodes(OpCodes.And);

        public static ILGenerator And(this ILGenerator generator, params ILGenerator[] _)
            => generator.EmitOpCodes(OpCodes.And);

#endregion

#region ArgumentList +

        public static ILGenerator ArgumentList(this ILGenerator generator)
            => generator.EmitOpCodes(OpCodes.Arglist);

        public static ILGenerator ArgumentList(this ILGenerator generator, params ILGenerator[] _)
            => generator.EmitOpCodes(OpCodes.Arglist);

#endregion

#region BranchEqual +

        public static ILGenerator BranchEqual(this ILGenerator generator, Label label, ILGenerator value1, ILGenerator value2)
        {
            generator.Emit(OpCodes.Beq, label);
            return generator;
        }

        public static ILGenerator BranchEqual_S(this ILGenerator generator, Label label, ILGenerator value1, ILGenerator value2)
        {
            generator.Emit(OpCodes.Beq_S, label);
            return generator;
        }

        public static ILGenerator BranchEqual(this ILGenerator generator, Label label, params ILGenerator[] _)
        {
            generator.Emit(OpCodes.Beq, label);
            return generator;
        }

        public static ILGenerator BranchEqual_S(this ILGenerator generator, Label label, params ILGenerator[] _)
        {
            generator.Emit(OpCodes.Beq_S, label);
            return generator;
        }

#endregion +

#region BranchGreaterEqual +

        public static ILGenerator BranchGreaterEqual(this ILGenerator generator, Label label, ILGenerator value1, ILGenerator value2)
        {
            generator.Emit(OpCodes.Bge, label);
            return generator;
        }

        public static ILGenerator BranchGreaterEqual_S(this ILGenerator generator, Label label, ILGenerator value1, ILGenerator value2)
        {
            generator.Emit(OpCodes.Bge_S, label);
            return generator;
        }

        public static ILGenerator BranchGreaterEqualUnsigned(this ILGenerator generator, Label label, ILGenerator value1, ILGenerator value2)
        {
            generator.Emit(OpCodes.Bge_Un, label);
            return generator;
        }

        public static ILGenerator BranchGreaterEqualUnsigned_S(this ILGenerator generator, Label label, ILGenerator value1, ILGenerator value2)
        {
            generator.Emit(OpCodes.Bge_Un_S, label);
            return generator;
        }

        public static ILGenerator BranchGreaterEqual(this ILGenerator generator, Label label, params ILGenerator[] _)
        {
            generator.Emit(OpCodes.Bge, label);
            return generator;
        }

        public static ILGenerator BranchGreaterEqual_S(this ILGenerator generator, Label label, params ILGenerator[] _)
        {
            generator.Emit(OpCodes.Bge_S, label);
            return generator;
        }

        public static ILGenerator BranchGreaterEqualUnsigned(this ILGenerator generator, Label label, params ILGenerator[] _)
        {
            generator.Emit(OpCodes.Bge_Un, label);
            return generator;
        }

        public static ILGenerator BranchGreaterEqualUnsigned_S(this ILGenerator generator, Label label, params ILGenerator[] _)
        {
            generator.Emit(OpCodes.Bge_Un_S, label);
            return generator;
        }

#endregion

#region BranchGreaterThan +

        public static ILGenerator BranchGreaterThan(this ILGenerator generator, Label label, ILGenerator value1, ILGenerator value2)
        {
            generator.Emit(OpCodes.Bgt, label);
            return generator;
        }

        public static ILGenerator BranchGreaterThan_S(this ILGenerator generator, Label label, ILGenerator value1, ILGenerator value2)
        {
            generator.Emit(OpCodes.Bgt_S, label);
            return generator;
        }

        public static ILGenerator BranchGreaterThanUnsigned(this ILGenerator generator, Label label, ILGenerator value1, ILGenerator value2)
        {
            generator.Emit(OpCodes.Bgt_Un, label);
            return generator;
        }

        public static ILGenerator BranchGreaterThanUnsigned_S(this ILGenerator generator, Label label, ILGenerator value1, ILGenerator value2)
        {
            generator.Emit(OpCodes.Bgt_Un_S, label);
            return generator;
        }

        public static ILGenerator BranchGreaterThan(this ILGenerator generator, Label label, params ILGenerator[] _)
        {
            generator.Emit(OpCodes.Bgt, label);
            return generator;
        }

        public static ILGenerator BranchGreaterThan_S(this ILGenerator generator, Label label, params ILGenerator[] _)
        {
            generator.Emit(OpCodes.Bgt_S, label);
            return generator;
        }

        public static ILGenerator BranchGreaterThanUnsigned(this ILGenerator generator, Label label, params ILGenerator[] _)
        {
            generator.Emit(OpCodes.Bgt_Un, label);
            return generator;
        }

        public static ILGenerator BranchGreaterThanUnsigned_S(this ILGenerator generator, Label label, params ILGenerator[] _)
        {
            generator.Emit(OpCodes.Bgt_Un_S, label);
            return generator;
        }

#endregion

#region BranchLessEqual +

        public static ILGenerator BranchLessEqual(this ILGenerator generator, Label label, ILGenerator value1, ILGenerator value2)
        {
            generator.Emit(OpCodes.Ble, label);
            return generator;
        }

        public static ILGenerator BranchLessEqual_S(this ILGenerator generator, Label label, ILGenerator value1, ILGenerator value2)
        {
            generator.Emit(OpCodes.Ble_S, label);
            return generator;
        }

        public static ILGenerator BranchLessEqualUnsigned(this ILGenerator generator, Label label, ILGenerator value1, ILGenerator value2)
        {
            generator.Emit(OpCodes.Ble_Un, label);
            return generator;
        }

        public static ILGenerator BranchLessEqualUnsigned_S(this ILGenerator generator, Label label, ILGenerator value1, ILGenerator value2)
        {
            generator.Emit(OpCodes.Ble_Un_S, label);
            return generator;
        }

        public static ILGenerator BranchLessEqual(this ILGenerator generator, Label label, params ILGenerator[] _)
        {
            generator.Emit(OpCodes.Ble, label);
            return generator;
        }

        public static ILGenerator BranchLessEqual_S(this ILGenerator generator, Label label, params ILGenerator[] _)
        {
            generator.Emit(OpCodes.Ble_S, label);
            return generator;
        }

        public static ILGenerator BranchLessEqualUnsigned(this ILGenerator generator, Label label, params ILGenerator[] _)
        {
            generator.Emit(OpCodes.Ble_Un, label);
            return generator;
        }

        public static ILGenerator BranchLessEqualUnsigned_S(this ILGenerator generator, Label label, params ILGenerator[] _)
        {
            generator.Emit(OpCodes.Ble_Un_S, label);
            return generator;
        }

#endregion

#region BranchLessThan +

        public static ILGenerator BranchLessThan(this ILGenerator generator, Label label, ILGenerator value1, ILGenerator value2)
        {
            generator.Emit(OpCodes.Blt, label);
            return generator;
        }

        public static ILGenerator BranchLessThan_S(this ILGenerator generator, Label label, ILGenerator value1, ILGenerator value2)
        {
            generator.Emit(OpCodes.Blt_S, label);
            return generator;
        }

        public static ILGenerator BranchLessThanUnsigned(this ILGenerator generator, Label label, ILGenerator value1, ILGenerator value2)
        {
            generator.Emit(OpCodes.Blt_Un, label);
            return generator;
        }

        public static ILGenerator BranchLessThanUnsigned_S(this ILGenerator generator, Label label, ILGenerator value1, ILGenerator value2)
        {
            generator.Emit(OpCodes.Blt_Un_S, label);
            return generator;
        }

        public static ILGenerator BranchLessThan(this ILGenerator generator, Label label, params ILGenerator[] _)
        {
            generator.Emit(OpCodes.Blt, label);
            return generator;
        }

        public static ILGenerator BranchLessThan_S(this ILGenerator generator, Label label, params ILGenerator[] _)
        {
            generator.Emit(OpCodes.Blt_S, label);
            return generator;
        }

        public static ILGenerator BranchLessThanUnsigned(this ILGenerator generator, Label label, params ILGenerator[] _)
        {
            generator.Emit(OpCodes.Blt_Un, label);
            return generator;
        }

        public static ILGenerator BranchLessThanUnsigned_S(this ILGenerator generator, Label label, params ILGenerator[] _)
        {
            generator.Emit(OpCodes.Blt_Un_S, label);
            return generator;
        }

#endregion

#region BranchNotEqual +

        public static ILGenerator BranchNotEqualUnsigned(this ILGenerator generator, Label label, ILGenerator value1, ILGenerator value2)
        {
            generator.Emit(OpCodes.Bne_Un, label);
            return generator;
        }

        public static ILGenerator BranchNotEqualUnsigned_S(this ILGenerator generator, Label label, ILGenerator value1, ILGenerator value2)
        {
            generator.Emit(OpCodes.Bne_Un_S, label);
            return generator;
        }

        public static ILGenerator BranchNotEqualUnsigned(this ILGenerator generator, Label label, params ILGenerator[] _)
        {
            generator.Emit(OpCodes.Bne_Un, label);
            return generator;
        }

        public static ILGenerator BranchNotEqualUnsigned_S(this ILGenerator generator, Label label, params ILGenerator[] _)
        {
            generator.Emit(OpCodes.Bne_Un_S, label);
            return generator;
        }

#endregion

#region Box +

        public static ILGenerator Box(this ILGenerator generator, ILGenerator first)
            => generator.EmitOpCodes(OpCodes.Box);

        public static ILGenerator Box(this ILGenerator generator, params ILGenerator[] _)
            => generator.EmitOpCodes(OpCodes.Box);

#endregion

#region Branch +

        public static ILGenerator Branch(this ILGenerator generator, Label label)
        {
            generator.Emit(OpCodes.Br, label);
            return generator;
        }

        public static ILGenerator Branch_S(this ILGenerator generator, Label label)
        {
            generator.Emit(OpCodes.Br_S, label);
            return generator;
        }

        public static ILGenerator Branch(this ILGenerator generator, Label label, params ILGenerator[] _)
        {
            generator.Emit(OpCodes.Br, label);
            return generator;
        }

        public static ILGenerator Branch_S(this ILGenerator generator, Label label, params ILGenerator[] _)
        {
            generator.Emit(OpCodes.Br_S, label);
            return generator;
        }

#endregion + +

#region Break +

        public static ILGenerator Break(this ILGenerator generator)
            => generator.EmitOpCodes(OpCodes.Break);

        public static ILGenerator Break(this ILGenerator generator, params ILGenerator[] _)
            => generator.EmitOpCodes(OpCodes.Break);

#endregion

#region BranchFalse +

        public static ILGenerator BranchFalse(this ILGenerator generator, Label label, ILGenerator value)
        {
            generator.Emit(OpCodes.Brfalse, label);
            return generator;
        }

        public static ILGenerator BranchFalse_S(this ILGenerator generator, Label label, ILGenerator value)
        {
            generator.Emit(OpCodes.Brfalse_S, label);
            return generator;
        }

        public static ILGenerator BranchFalse(this ILGenerator generator, Label label, params ILGenerator[] _)
        {
            generator.Emit(OpCodes.Brfalse, label);
            return generator;
        }

        public static ILGenerator BranchFalse_S(this ILGenerator generator, Label label, params ILGenerator[] _)
        {
            generator.Emit(OpCodes.Brfalse_S, label);
            return generator;
        }

#endregion

#region BranchTrue +

        public static ILGenerator BranchTrue(this ILGenerator generator, Label label, ILGenerator value)
        {
            generator.Emit(OpCodes.Brtrue, label);
            return generator;
        }

        public static ILGenerator BranchTrue_S(this ILGenerator generator, Label label, ILGenerator value)
        {
            generator.Emit(OpCodes.Brtrue_S, label);
            return generator;
        }

        public static ILGenerator BranchTrue(this ILGenerator generator, Label label, params ILGenerator[] _)
        {
            generator.Emit(OpCodes.Brtrue, label);
            return generator;
        }

        public static ILGenerator BranchTrue_S(this ILGenerator generator, Label label, params ILGenerator[] _)
        {
            generator.Emit(OpCodes.Brtrue_S, label);
            return generator;
        }

#endregion

#region Call ?

        // args arg1 - argN ? overloads or just params?

        public static ILGenerator Call(this ILGenerator generator, MethodInfo methodInfo, params ILGenerator[] _)
        {
            generator.Emit(OpCodes.Call, methodInfo);
            return generator;
        }

        public static ILGenerator Call<T>(this ILGenerator generator, string methodName, params ILGenerator[] _)
        {
            generator.Emit(OpCodes.Call, typeof(T).GetMethod(methodName)!);
            return generator;
        }

        public static ILGenerator Call<T, U>(this ILGenerator generator, string methodName, params ILGenerator[] _) where U : struct, ITypesMarker
        {
            generator.Emit(OpCodes.Call, typeof(T).GetMethod(methodName, typeof(U).GenericTypeArguments)!);
            return generator;
        }

        public static ILGenerator CallCtor<T, U>(this ILGenerator generator, params ILGenerator[] _) where U : struct, ITypesMarker
        {
            generator.Emit(OpCodes.Call, typeof(T).GetConstructor(typeof(U).GenericTypeArguments)!);
            return generator;
        }

#endregion

#region CallIndirect ?

        // method arguments arg1 -> argN, methodPointer

        public static ILGenerator CallIndirectManaged<T, U>(this ILGenerator generator, CallingConventions callingConventions = CallingConventions.Standard, params ILGenerator[] _)
            where U : struct, ITypesMarker
        {
            generator.EmitCalli(OpCodes.Calli, callingConventions, typeof(T), typeof(U).GenericTypeArguments, Array.Empty<Type>());
            return generator;
        }

        public static ILGenerator CallIndirectUnmanaged<T, U>(this ILGenerator generator, CallingConvention callingConvention = CallingConvention.StdCall, params ILGenerator[] _)
            where U : struct, ITypesMarker
        {
            generator.EmitCalli(OpCodes.Call, callingConvention, typeof(T), typeof(U).GenericTypeArguments);
            return generator;
        }

#endregion

#region CallVirtual ?

        // obj reference, method arguments arg1 -> argN

        public static ILGenerator CallVirtual(this ILGenerator generator, MethodInfo methodInfo, params ILGenerator[] _)
        {
            generator.Emit(OpCodes.Callvirt, methodInfo);
            return generator;
        }

        public static ILGenerator CallVirtual<T>(this ILGenerator generator, string methodName, params ILGenerator[] _)
        {
            generator.Emit(OpCodes.Callvirt, typeof(T).GetMethod(methodName)!);
            return generator;
        }

        public static ILGenerator CallVirtual<T, U>(this ILGenerator generator, string methodName, params ILGenerator[] _) where U : struct, ITypesMarker
        {
            generator.Emit(OpCodes.Callvirt, typeof(T).GetMethod(methodName, typeof(U).GenericTypeArguments)!);
            return generator;
        }

#endregion

#region CastClass +

        public static ILGenerator CastClass(this ILGenerator generator, Type type, ILGenerator objectReference)
            => generator.EmitOpCodes(OpCodes.Castclass, type);

        public static ILGenerator CastClass(this ILGenerator generator, Type type, params ILGenerator[] _)
            => generator.EmitOpCodes(OpCodes.Castclass, type);
        
        public static ILGenerator CastClass<T>(this ILGenerator generator, ILGenerator objectReference)
            => generator.EmitOpCodes(OpCodes.Castclass, typeof(T));

        public static ILGenerator CastClass<T>(this ILGenerator generator, params ILGenerator[] _)
            => generator.EmitOpCodes(OpCodes.Castclass, typeof(T));

#endregion

#region CompareEqual +

        public static ILGenerator CompareEqual(this ILGenerator generator, ILGenerator value1, ILGenerator value2)
            => generator.EmitOpCodes(OpCodes.Ceq);

        public static ILGenerator CompareEqual(this ILGenerator generator, params ILGenerator[] _)
            => generator.EmitOpCodes(OpCodes.Ceq);

#endregion

#region CompareGreaterThan +

        public static ILGenerator CompareGreaterThan(this ILGenerator generator, ILGenerator value1, ILGenerator value2)
            => generator.EmitOpCodes(OpCodes.Cgt);

        public static ILGenerator CompareGreaterThan(this ILGenerator generator, params ILGenerator[] _)
            => generator.EmitOpCodes(OpCodes.Cgt);

        public static ILGenerator CompareGreaterThanUnsigned(this ILGenerator generator, ILGenerator value1, ILGenerator value2)
            => generator.EmitOpCodes(OpCodes.Cgt_Un);

        public static ILGenerator CompareGreaterThanUnsigned(this ILGenerator generator, params ILGenerator[] _)
            => generator.EmitOpCodes(OpCodes.Cgt_Un);

#endregion

#region CheckFinite +

        public static ILGenerator CheckFinite(this ILGenerator generator, ILGenerator value)
            => generator.EmitOpCodes(OpCodes.Ckfinite);

        public static ILGenerator CheckFinite(this ILGenerator generator, params ILGenerator[] _)
            => generator.EmitOpCodes(OpCodes.Ckfinite);

#endregion

#region CompareLessThan +

        public static ILGenerator CompareLessThan(this ILGenerator generator, ILGenerator value1, ILGenerator value2)
            => generator.EmitOpCodes(OpCodes.Clt);

        public static ILGenerator CompareLessThan(this ILGenerator generator, params ILGenerator[] _)
            => generator.EmitOpCodes(OpCodes.Clt);

        public static ILGenerator CompareLessThanUnsigned(this ILGenerator generator, ILGenerator value1, ILGenerator value2)
            => generator.EmitOpCodes(OpCodes.Clt_Un);

        public static ILGenerator CompareLessThanUnsigned(this ILGenerator generator, params ILGenerator[] _)
            => generator.EmitOpCodes(OpCodes.Clt_Un);

#endregion

#region ConstrainedCallVirtualPrefix ?

        public static ILGenerator ConstrainedCallVirtualPrefix<T>(this ILGenerator generator)
        {
            generator.Emit(OpCodes.Constrained, typeof(T));
            return generator;
        }

        public static ILGenerator ConstrainedCallVirtualPrefix<T>(this ILGenerator generator, params ILGenerator[] _)
        {
            generator.Emit(OpCodes.Constrained, typeof(T));
            return generator;
        }

#endregion

#region ConvertToNativeInt +

        public static ILGenerator ConvertToNativeInt(this ILGenerator generator, ILGenerator value)
            => generator.EmitOpCodes(OpCodes.Conv_I);

        public static ILGenerator ConvertToNativeInt(this ILGenerator generator, params ILGenerator[] _)
            => generator.EmitOpCodes(OpCodes.Conv_I);

        public static ILGenerator ConvertToNativeUInt(this ILGenerator generator, ILGenerator value)
            => generator.EmitOpCodes(OpCodes.Conv_U);

        public static ILGenerator ConvertToNativeUInt(this ILGenerator generator, params ILGenerator[] _)
            => generator.EmitOpCodes(OpCodes.Conv_U);

        public static ILGenerator ConvertToNativeIntOverflow(this ILGenerator generator, ILGenerator value)
            => generator.EmitOpCodes(OpCodes.Conv_Ovf_I);

        public static ILGenerator ConvertToNativeIntOverflow(this ILGenerator generator, params ILGenerator[] _)
            => generator.EmitOpCodes(OpCodes.Conv_Ovf_I);

        public static ILGenerator ConvertToNativeUIntOverflow(this ILGenerator generator, ILGenerator value)
            => generator.EmitOpCodes(OpCodes.Conv_Ovf_U);

        public static ILGenerator ConvertToNativeUIntOverflow(this ILGenerator generator, params ILGenerator[] _)
            => generator.EmitOpCodes(OpCodes.Conv_Ovf_U);

        public static ILGenerator ConvertToNativeIntOverflowUnsigned(this ILGenerator generator, ILGenerator value)
            => generator.EmitOpCodes(OpCodes.Conv_Ovf_I_Un);

        public static ILGenerator ConvertToNativeIntOverflowUnsigned(this ILGenerator generator, params ILGenerator[] _)
            => generator.EmitOpCodes(OpCodes.Conv_Ovf_I_Un);

        public static ILGenerator ConvertToNativeUIntOverflowUnsigned(this ILGenerator generator, ILGenerator value)
            => generator.EmitOpCodes(OpCodes.Conv_Ovf_U_Un);

        public static ILGenerator ConvertToNativeUIntOverflowUnsigned(this ILGenerator generator, params ILGenerator[] _)
            => generator.EmitOpCodes(OpCodes.Conv_Ovf_U_Un);

#endregion

#region ConvertToByteExtendToInt +

        public static ILGenerator ConvertToSignedByteExtendToInt(this ILGenerator generator, ILGenerator value)
            => generator.EmitOpCodes(OpCodes.Conv_I1);

        public static ILGenerator ConvertToSignedByteExtendToInt(this ILGenerator generator, params ILGenerator[] _)
            => generator.EmitOpCodes(OpCodes.Conv_I1);

        public static ILGenerator ConvertToByteExtendToInt(this ILGenerator generator, ILGenerator value)
            => generator.EmitOpCodes(OpCodes.Conv_U1);

        public static ILGenerator ConvertToByteExtendToInt(this ILGenerator generator, params ILGenerator[] _)
            => generator.EmitOpCodes(OpCodes.Conv_U1);

        public static ILGenerator ConvertToSignedByteExtendToIntOverflow(this ILGenerator generator, ILGenerator value)
            => generator.EmitOpCodes(OpCodes.Conv_Ovf_I1);

        public static ILGenerator ConvertToSignedByteExtendToIntOverflow(this ILGenerator generator, params ILGenerator[] _)
            => generator.EmitOpCodes(OpCodes.Conv_Ovf_I1);

        public static ILGenerator ConvertToByteExtendToIntOverflow(this ILGenerator generator, ILGenerator value)
            => generator.EmitOpCodes(OpCodes.Conv_Ovf_U1);

        public static ILGenerator ConvertToByteExtendToIntOverflow(this ILGenerator generator, params ILGenerator[] _)
            => generator.EmitOpCodes(OpCodes.Conv_Ovf_U1);

        public static ILGenerator ConvertToSByteExtendToIntOverflowUnsigned(this ILGenerator generator, ILGenerator value)
            => generator.EmitOpCodes(OpCodes.Conv_Ovf_I1_Un);

        public static ILGenerator ConvertToSByteExtendToIntOverflowUnsigned(this ILGenerator generator, params ILGenerator[] _)
            => generator.EmitOpCodes(OpCodes.Conv_Ovf_I1_Un);

        public static ILGenerator ConvertToByteExtendToIntOverflowUnsigned(this ILGenerator generator, ILGenerator value)
            => generator.EmitOpCodes(OpCodes.Conv_Ovf_U1_Un);

        public static ILGenerator ConvertToByteExtendToIntOverflowUnsigned(this ILGenerator generator, params ILGenerator[] _)
            => generator.EmitOpCodes(OpCodes.Conv_Ovf_U1_Un);

#endregion

#region ConvertToShortExtendToInt +

        public static ILGenerator ConvertToShortExtendToInt(this ILGenerator generator, ILGenerator first)
            => generator.EmitOpCodes(OpCodes.Conv_I2);

        public static ILGenerator ConvertToShortExtendToInt(this ILGenerator generator, params ILGenerator[] _)
            => generator.EmitOpCodes(OpCodes.Conv_I2);

        public static ILGenerator ConvertToUShortExtendToInt(this ILGenerator generator, ILGenerator first)
            => generator.EmitOpCodes(OpCodes.Conv_U2);

        public static ILGenerator ConvertToUShortExtendToInt(this ILGenerator generator, params ILGenerator[] _)
            => generator.EmitOpCodes(OpCodes.Conv_U2);

        public static ILGenerator ConvertToShortExtendToIntOverflow(this ILGenerator generator, ILGenerator first)
            => generator.EmitOpCodes(OpCodes.Conv_Ovf_I2);

        public static ILGenerator ConvertToShortExtendToIntOverflow(this ILGenerator generator, params ILGenerator[] _)
            => generator.EmitOpCodes(OpCodes.Conv_Ovf_I2);

        public static ILGenerator ConvertToUShortExtendToIntOverflow(this ILGenerator generator, ILGenerator first)
            => generator.EmitOpCodes(OpCodes.Conv_Ovf_U2);

        public static ILGenerator ConvertToUShortExtendToIntOverflow(this ILGenerator generator, params ILGenerator[] _)
            => generator.EmitOpCodes(OpCodes.Conv_Ovf_U2);

        public static ILGenerator ConvertToShortExtendToIntOverflowUnsigned(this ILGenerator generator, ILGenerator first)
            => generator.EmitOpCodes(OpCodes.Conv_Ovf_I2_Un);

        public static ILGenerator ConvertToShortExtendToIntOverflowUnsigned(this ILGenerator generator, params ILGenerator[] _)
            => generator.EmitOpCodes(OpCodes.Conv_Ovf_I2_Un);

        public static ILGenerator ConvertToUShortExtendToIntOverflowUnsigned(this ILGenerator generator, ILGenerator first)
            => generator.EmitOpCodes(OpCodes.Conv_Ovf_U2_Un);

        public static ILGenerator ConvertToUShortExtendToIntOverflowUnsigned(this ILGenerator generator, params ILGenerator[] _)
            => generator.EmitOpCodes(OpCodes.Conv_Ovf_U2_Un);

#endregion

#region ConvertToInt +

        public static ILGenerator ConvertToInt(this ILGenerator generator, ILGenerator value)
            => generator.EmitOpCodes(OpCodes.Conv_I4);

        public static ILGenerator ConvertToInt(this ILGenerator generator, params ILGenerator[] _)
            => generator.EmitOpCodes(OpCodes.Conv_I4);

        public static ILGenerator ConvertToUInt(this ILGenerator generator, ILGenerator value)
            => generator.EmitOpCodes(OpCodes.Conv_U4);

        public static ILGenerator ConvertToUInt(this ILGenerator generator, params ILGenerator[] _)
            => generator.EmitOpCodes(OpCodes.Conv_U4);

        public static ILGenerator ConvertToIntOverflow(this ILGenerator generator, ILGenerator value)
            => generator.EmitOpCodes(OpCodes.Conv_Ovf_I4);

        public static ILGenerator ConvertToIntOverflow(this ILGenerator generator, params ILGenerator[] _)
            => generator.EmitOpCodes(OpCodes.Conv_Ovf_I4);

        public static ILGenerator ConvertToUIntOverflow(this ILGenerator generator, ILGenerator value)
            => generator.EmitOpCodes(OpCodes.Conv_Ovf_U4);

        public static ILGenerator ConvertToUIntOverflow(this ILGenerator generator, params ILGenerator[] _)
            => generator.EmitOpCodes(OpCodes.Conv_Ovf_U4);

        public static ILGenerator ConvertToIntOverflowUnsigned(this ILGenerator generator, ILGenerator value)
            => generator.EmitOpCodes(OpCodes.Conv_Ovf_I4_Un);

        public static ILGenerator ConvertToIntOverflowUnsigned(this ILGenerator generator, params ILGenerator[] _)
            => generator.EmitOpCodes(OpCodes.Conv_Ovf_I4_Un);

        public static ILGenerator ConvertToUIntOverflowUnsigned(this ILGenerator generator, ILGenerator value)
            => generator.EmitOpCodes(OpCodes.Conv_Ovf_U4_Un);

        public static ILGenerator ConvertToUIntOverflowUnsigned(this ILGenerator generator, params ILGenerator[] _)
            => generator.EmitOpCodes(OpCodes.Conv_Ovf_U4_Un);

#endregion

#region ConvertToLong +

        public static ILGenerator ConvertToLong(this ILGenerator generator, ILGenerator value)
            => generator.EmitOpCodes(OpCodes.Conv_I8);

        public static ILGenerator ConvertToLong(this ILGenerator generator, params ILGenerator[] _)
            => generator.EmitOpCodes(OpCodes.Conv_I8);

        public static ILGenerator ConvertToUnsginedLong(this ILGenerator generator, ILGenerator value)
            => generator.EmitOpCodes(OpCodes.Conv_U8);

        public static ILGenerator ConvertToUnsginedLong(this ILGenerator generator, params ILGenerator[] _)
            => generator.EmitOpCodes(OpCodes.Conv_U8);

        public static ILGenerator ConvertToLongOverflow(this ILGenerator generator, ILGenerator value)
            => generator.EmitOpCodes(OpCodes.Conv_Ovf_I8);

        public static ILGenerator ConvertToLongOverflow(this ILGenerator generator, params ILGenerator[] _)
            => generator.EmitOpCodes(OpCodes.Conv_Ovf_I8);

        public static ILGenerator ConvertToUnsginedLongOverflow(this ILGenerator generator, ILGenerator value)
            => generator.EmitOpCodes(OpCodes.Conv_Ovf_U8);

        public static ILGenerator ConvertToUnsginedLongOverflow(this ILGenerator generator, params ILGenerator[] _)
            => generator.EmitOpCodes(OpCodes.Conv_Ovf_U8);

        public static ILGenerator ConvertToLongOverflowUnsigned(this ILGenerator generator, ILGenerator value)
            => generator.EmitOpCodes(OpCodes.Conv_Ovf_I8_Un);

        public static ILGenerator ConvertToLongOverflowUnsigned(this ILGenerator generator, params ILGenerator[] _)
            => generator.EmitOpCodes(OpCodes.Conv_Ovf_I8_Un);

        public static ILGenerator ConvertToUnsginedLongOverflowUnsigned(this ILGenerator generator, ILGenerator value)
            => generator.EmitOpCodes(OpCodes.Conv_Ovf_U8_Un);

        public static ILGenerator ConvertToUnsginedLongOverflowUnsigned(this ILGenerator generator, params ILGenerator[] _)
            => generator.EmitOpCodes(OpCodes.Conv_Ovf_U8_Un);

#endregion

#region ConvertToFloat +

        public static ILGenerator ConvertToFloatUnsigned(this ILGenerator generator, ILGenerator value)
            => generator.EmitOpCodes(OpCodes.Conv_R_Un);

        public static ILGenerator ConvertToFloatUnsigned(this ILGenerator generator, params ILGenerator[] _)
            => generator.EmitOpCodes(OpCodes.Conv_R_Un);

        public static ILGenerator ConvertToFloat(this ILGenerator generator, ILGenerator value)
            => generator.EmitOpCodes(OpCodes.Conv_R4);

        public static ILGenerator ConvertToFloat(this ILGenerator generator, params ILGenerator[] _)
            => generator.EmitOpCodes(OpCodes.Conv_R4);

#endregion

#region ConvertToDouble +

        public static ILGenerator ConvertToDouble(this ILGenerator generator, ILGenerator value)
            => generator.EmitOpCodes(OpCodes.Conv_R8);

        public static ILGenerator ConvertToDouble(this ILGenerator generator, params ILGenerator[] _)
            => generator.EmitOpCodes(OpCodes.Conv_R8);

#endregion

#region CopyBlock +

        public static ILGenerator CopyBlock(this ILGenerator generator, ILGenerator destinationAdress, ILGenerator SourceAdress, ILGenerator numberOfBytes)
            => generator.EmitOpCodes(OpCodes.Cpblk);

        public static ILGenerator CopyBlock(this ILGenerator generator, params ILGenerator[] _)
            => generator.EmitOpCodes(OpCodes.Cpblk);

#endregion

#region CopyObject +

        public static ILGenerator CopyObject<T>(this ILGenerator generator, ILGenerator destinationObjectReference, ILGenerator sourceObjectReference)
        {
            generator.Emit(OpCodes.Cpobj, typeof(T));
            return generator;
        }

        public static ILGenerator CopyObject<T>(this ILGenerator generator, params ILGenerator[] _)
        {
            generator.Emit(OpCodes.Cpobj, typeof(T));
            return generator;
        }

#endregion

#region Divide +

        public static ILGenerator Divide(this ILGenerator generator, ILGenerator value1, ILGenerator value2)
            => generator.EmitOpCodes(OpCodes.Div);

        public static ILGenerator Divide(this ILGenerator generator, params ILGenerator[] _)
            => generator.EmitOpCodes(OpCodes.Div);

        public static ILGenerator DivideUnsigned(this ILGenerator generator, ILGenerator value1, ILGenerator value2)
            => generator.EmitOpCodes(OpCodes.Div_Un);

        public static ILGenerator DivideUnsigned(this ILGenerator generator, params ILGenerator[] _)
            => generator.EmitOpCodes(OpCodes.Div_Un);

#endregion

#region Duplicate +

        public static ILGenerator Duplicate(this ILGenerator generator, ILGenerator valueToDuplicate)
            => generator.EmitOpCodes(OpCodes.Dup);

        public static ILGenerator Duplicate(this ILGenerator generator, params ILGenerator[] _)
            => generator.EmitOpCodes(OpCodes.Dup);

#endregion

#region EndFilter +

        public static ILGenerator EndFilter(this ILGenerator generator, ILGenerator handleExceptionFlag)
            => generator.EmitOpCodes(OpCodes.Endfilter);

        public static ILGenerator EndFilter(this ILGenerator generator, params ILGenerator[] _)
            => generator.EmitOpCodes(OpCodes.Endfilter);

#endregion

#region EndFinally +

        public static ILGenerator EndFinally(this ILGenerator generator)
            => generator.EmitOpCodes(OpCodes.Endfinally);

        public static ILGenerator EndFinally(this ILGenerator generator, params ILGenerator[] _)
            => generator.EmitOpCodes(OpCodes.Endfinally);

#endregion

#region InitBlock +

        public static ILGenerator InitBlock(this ILGenerator generator, ILGenerator startingAdress, ILGenerator initializationValue, ILGenerator numberOfBytes)
            => generator.EmitOpCodes(OpCodes.Initblk);

        public static ILGenerator InitBlock(this ILGenerator generator, params ILGenerator[] _)
            => generator.EmitOpCodes(OpCodes.Initblk);

#endregion

#region InitObject +

        public static ILGenerator InitObject<T>(this ILGenerator generator, ILGenerator adressOfValueToInitialize)
        {
            generator.Emit(OpCodes.Initobj, typeof(T));
            return generator;
        }

        public static ILGenerator InitObject<T>(this ILGenerator generator, params ILGenerator[] _)
        {
            generator.Emit(OpCodes.Initobj, typeof(T));
            return generator;
        }

#endregion

#region IsInstance +

        public static ILGenerator IsInstance<T>(this ILGenerator generator, ILGenerator value)
        {
            generator.Emit(OpCodes.Isinst, typeof(T));
            return generator;
        }

        public static ILGenerator IsInstance<T>(this ILGenerator generator, params ILGenerator[] _)
        {
            generator.Emit(OpCodes.Isinst, typeof(T));
            return generator;
        }

#endregion

#region Jump +

        public static ILGenerator Jump(this ILGenerator generator, MethodInfo method)
        {
            generator.Emit(OpCodes.Br, method);
            return generator;
        }

        public static ILGenerator Jump(this ILGenerator generator, MethodInfo method, params ILGenerator[] _)
        {
            generator.Emit(OpCodes.Br, method);
            return generator;
        }

#endregion

#region LoadArgument +

        public static ILGenerator LoadArgument(this ILGenerator generator, int index)
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
                    generator.Emit(OpCodes.Ldarg, (short)index);
                    break;
            }

            return generator;
        }

        public static ILGenerator LoadArgument(this ILGenerator generator, params int[] index)
        {
            foreach (var i in index)
                generator.LoadArgument(i);

            return generator;
        }

        public static ILGenerator LoadArgument_S(this ILGenerator generator, int index)
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
                    generator.Emit(OpCodes.Ldarg_S, (byte)index);
                    break;
            }

            return generator;
        }

        public static ILGenerator LoadArgument_S(this ILGenerator generator, params int[] index)
        {
            foreach (var i in index)
                generator.LoadArgument(i);

            return generator;
        }

#endregion

#region LoadArgumentAdress +

        public static ILGenerator LoadArgumentAdress(this ILGenerator generator, int index)
        {
            generator.Emit(OpCodes.Ldarga, index);
            return generator;
        }

        public static ILGenerator LoadArgumentAdress(this ILGenerator generator, byte index)
        {
            generator.Emit(OpCodes.Ldarga_S, index);
            return generator;
        }

#endregion

#region LoadInteger +

        public static ILGenerator LoadInteger(this ILGenerator generator, int value)
        {
            switch (value)
            {
                case -1:
                    generator.Emit(OpCodes.Ldc_I4_M1);
                    break;
                case 0:
                    generator.Emit(OpCodes.Ldc_I4_0);
                    break;
                case 1:
                    generator.Emit(OpCodes.Ldc_I4_1);
                    break;
                case 2:
                    generator.Emit(OpCodes.Ldc_I4_2);
                    break;
                case 3:
                    generator.Emit(OpCodes.Ldc_I4_3);
                    break;
                case 4:
                    generator.Emit(OpCodes.Ldc_I4_4);
                    break;
                case 5:
                    generator.Emit(OpCodes.Ldc_I4_5);
                    break;
                case 6:
                    generator.Emit(OpCodes.Ldc_I4_6);
                    break;
                case 7:
                    generator.Emit(OpCodes.Ldc_I4_7);
                    break;
                case 8:
                    generator.Emit(OpCodes.Ldc_I4_8);
                    break;
                default:
                    generator.Emit(OpCodes.Ldc_I4, value);
                    break;
            }

            return generator;
        }

        public static ILGenerator LoadInteger(this ILGenerator generator, int value, params ILGenerator[] _)
        {
            generator.Emit(OpCodes.Ldc_I4, value);
            return generator;
        }

        public static ILGenerator LoadByte(this ILGenerator generator, byte value)
        {
            generator.Emit(OpCodes.Ldc_I4_S, value);
            return generator;
        }

        public static ILGenerator LoadByte(this ILGenerator generator, byte value, params ILGenerator[] _)
        {
            generator.Emit(OpCodes.Ldc_I4_S, value);
            return generator;
        }

#endregion

#region LoadLong +

        public static ILGenerator LoadLong(this ILGenerator generator, long value)
        {
            generator.Emit(OpCodes.Ldc_I8, value);
            return generator;
        }

        public static ILGenerator LoadLong(this ILGenerator generator, long value, params ILGenerator[] _)
        {
            generator.Emit(OpCodes.Ldc_I8, value);
            return generator;
        }

#endregion

#region LoadFloat +

        public static ILGenerator LoadFloat(this ILGenerator generator, float value)
        {
            generator.Emit(OpCodes.Ldc_R4, value);
            return generator;
        }

        public static ILGenerator LoadFloat(this ILGenerator generator, float value, params ILGenerator[] _)
        {
            generator.Emit(OpCodes.Ldc_R4, value);
            return generator;
        }

#endregion

#region LoadDouble +

        public static ILGenerator LoadDouble(this ILGenerator generator, double value)
        {
            generator.Emit(OpCodes.Ldc_R8, value);
            return generator;
        }

        public static ILGenerator LoadDouble(this ILGenerator generator, double value, params ILGenerator[] _)
        {
            generator.Emit(OpCodes.Ldc_R8, value);
            return generator;
        }

#endregion

#region LoadElement +

        public static ILGenerator LoadElement<T>(this ILGenerator generator, ILGenerator arrayReference, ILGenerator index)
        {
            generator.Emit(OpCodes.Ldelem, typeof(T));
            return generator;
        }

        public static ILGenerator LoadElement<T>(this ILGenerator generator, params ILGenerator[] _)
        {
            generator.Emit(OpCodes.Ldelem, typeof(T));
            return generator;
        }

        public static ILGenerator LoadElement(this ILGenerator generator, Type type, ILGenerator arrayReference, ILGenerator index)
        {
            generator.Emit(OpCodes.Ldelem, type);
            return generator;
        }

        public static ILGenerator LoadElement(this ILGenerator generator, Type type, params ILGenerator[] _)
        {
            generator.Emit(OpCodes.Ldelem, type);
            return generator;
        }

        public static ILGenerator LoadElementNativeInt(this ILGenerator generator, ILGenerator arrayReference, ILGenerator index)
        {
            generator.Emit(OpCodes.Ldelem_I);
            return generator;
        }

        public static ILGenerator LoadElementNativeInt(this ILGenerator generator, params ILGenerator[] _)
        {
            generator.Emit(OpCodes.Ldelem_I);
            return generator;
        }

        public static ILGenerator LoadElementSByte(this ILGenerator generator, ILGenerator arrayReference, ILGenerator index)
        {
            generator.Emit(OpCodes.Ldelem_I1);
            return generator;
        }

        public static ILGenerator LoadElementSByte(this ILGenerator generator, params ILGenerator[] _)
        {
            generator.Emit(OpCodes.Ldelem_I1);
            return generator;
        }

        public static ILGenerator LoadElementByte(this ILGenerator generator, ILGenerator arrayReference, ILGenerator index)
        {
            generator.Emit(OpCodes.Ldelem_U1);
            return generator;
        }

        public static ILGenerator LoadElementByte(this ILGenerator generator, params ILGenerator[] _)
        {
            generator.Emit(OpCodes.Ldelem_U1);
            return generator;
        }

        public static ILGenerator LoadElementShort(this ILGenerator generator, ILGenerator arrayReference, ILGenerator index)
        {
            generator.Emit(OpCodes.Ldelem_I2);
            return generator;
        }

        public static ILGenerator LoadElementShort(this ILGenerator generator, params ILGenerator[] _)
        {
            generator.Emit(OpCodes.Ldelem_I2);
            return generator;
        }

        public static ILGenerator LoadElementUShort(this ILGenerator generator, ILGenerator arrayReference, ILGenerator index)
        {
            generator.Emit(OpCodes.Ldelem_U2);
            return generator;
        }

        public static ILGenerator LoadElementUShort(this ILGenerator generator, params ILGenerator[] _)
        {
            generator.Emit(OpCodes.Ldelem_U2);
            return generator;
        }

        public static ILGenerator LoadElementInt(this ILGenerator generator, ILGenerator arrayReference, ILGenerator index)
        {
            generator.Emit(OpCodes.Ldelem_I4);
            return generator;
        }

        public static ILGenerator LoadElementInt(this ILGenerator generator, params ILGenerator[] _)
        {
            generator.Emit(OpCodes.Ldelem_I4);
            return generator;
        }

        public static ILGenerator LoadElementUInt(this ILGenerator generator, ILGenerator arrayReference, ILGenerator index)
        {
            generator.Emit(OpCodes.Ldelem_U4);
            return generator;
        }

        public static ILGenerator LoadElementUInt(this ILGenerator generator, params ILGenerator[] _)
        {
            generator.Emit(OpCodes.Ldelem_U4);
            return generator;
        }

        public static ILGenerator LoadElementLong(this ILGenerator generator, ILGenerator arrayReference, ILGenerator index)
        {
            generator.Emit(OpCodes.Ldelem_I8);
            return generator;
        }

        public static ILGenerator LoadElementLong(this ILGenerator generator, params ILGenerator[] _)
        {
            generator.Emit(OpCodes.Ldelem_I8);
            return generator;
        }

        public static ILGenerator LoadElementFloat(this ILGenerator generator, ILGenerator arrayReference, ILGenerator index)
        {
            generator.Emit(OpCodes.Ldelem_R4);
            return generator;
        }

        public static ILGenerator LoadElementFloat(this ILGenerator generator, params ILGenerator[] _)
        {
            generator.Emit(OpCodes.Ldelem_R4);
            return generator;
        }

        public static ILGenerator LoadElementDouble(this ILGenerator generator, ILGenerator arrayReference, ILGenerator index)
        {
            generator.Emit(OpCodes.Ldelem_R8);
            return generator;
        }

        public static ILGenerator LoadElementDouble(this ILGenerator generator, params ILGenerator[] _)
        {
            generator.Emit(OpCodes.Ldelem_R8);
            return generator;
        }

        public static ILGenerator LoadElementReference(this ILGenerator generator, ILGenerator arrayReference, ILGenerator index)
        {
            generator.Emit(OpCodes.Ldelem_Ref);
            return generator;
        }

        public static ILGenerator LoadElementReference(this ILGenerator generator, params ILGenerator[] _)
        {
            generator.Emit(OpCodes.Ldelem_Ref);
            return generator;
        }

        public static ILGenerator LoadElementAdress(this ILGenerator generator, Type type, ILGenerator arrayReference, ILGenerator index)
        {
            generator.Emit(OpCodes.Ldelema, type);
            return generator;
        }

        public static ILGenerator LoadElementAdress(this ILGenerator generator, Type type, params ILGenerator[] _)
        {
            generator.Emit(OpCodes.Ldelema, type);
            return generator;
        }

        public static ILGenerator LoadElementAdress<T>(this ILGenerator generator, ILGenerator arrayReference, ILGenerator index)
        {
            generator.Emit(OpCodes.Ldelema, typeof(T));
            return generator;
        }

        public static ILGenerator LoadElementAdress<T>(this ILGenerator generator, params ILGenerator[] _)
        {
            generator.Emit(OpCodes.Ldelema, typeof(T));
            return generator;
        }

#endregion

#region LoadField +

        public static ILGenerator LoadField<T>(this ILGenerator generator, string name, ILGenerator objectReference)
        {
            var field = typeof(T).GetField(name);
            generator.Emit(OpCodes.Ldfld, field!);
            return generator;
        }

        public static ILGenerator LoadField(this ILGenerator generator, Type type, string name, ILGenerator objectReference)
        {
            var field = type.GetField(name);
            generator.Emit(OpCodes.Ldfld, field!);
            return generator;
        }

        public static ILGenerator LoadField(this ILGenerator generator, FieldInfo fieldInfo, ILGenerator objectReference)
        {
            generator.Emit(OpCodes.Ldfld, fieldInfo);
            return generator;
        }

        public static ILGenerator LoadField<T>(this ILGenerator generator, string name, params ILGenerator[] _)
        {
            var field = typeof(T).GetField(name);
            generator.Emit(OpCodes.Ldfld, field!);
            return generator;
        }

        public static ILGenerator LoadField(this ILGenerator generator, Type type, string name, params ILGenerator[] _)
        {
            var field = type.GetField(name);
            generator.Emit(OpCodes.Ldfld, field!);
            return generator;
        }

        public static ILGenerator LoadField(this ILGenerator generator, FieldInfo fieldInfo, params ILGenerator[] _)
        {
            generator.Emit(OpCodes.Ldfld, fieldInfo);
            return generator;
        }

#endregion

#region LoadFieldAddress +

        public static ILGenerator LoadFieldAddress<T>(this ILGenerator generator, string name, ILGenerator objectReference)
        {
            var field = typeof(T).GetField(name);
            generator.Emit(OpCodes.Ldflda, field!);
            return generator;
        }

        public static ILGenerator LoadFieldAddress(this ILGenerator generator, FieldInfo fieldInfo, ILGenerator objectReference)
        {
            generator.Emit(OpCodes.Ldflda, fieldInfo);
            return generator;
        }

        public static ILGenerator LoadFieldAddress<T>(this ILGenerator generator, string name, params ILGenerator[] _)
        {
            var field = typeof(T).GetField(name);
            generator.Emit(OpCodes.Ldflda, field!);
            return generator;
        }

        public static ILGenerator LoadFieldAddress(this ILGenerator generator, FieldInfo fieldInfo, params ILGenerator[] _)
        {
            generator.Emit(OpCodes.Ldflda, fieldInfo);
            return generator;
        }

#endregion

#region LoadUnmanagedPointer ?

        public static ILGenerator LoadUnmanagedPointer(this ILGenerator generator, MethodInfo methodInfo, ILGenerator unmanagedPointer)
        {
            generator.Emit(OpCodes.Ldftn, methodInfo);
            return generator;
        }

        public static ILGenerator LoadUnmanagedPointer(this ILGenerator generator, MethodInfo methodInfo, params ILGenerator[] _)
        {
            generator.Emit(OpCodes.Ldftn, methodInfo);
            return generator;
        }

#endregion

#region LoadIndirect +

        public static ILGenerator LoadIndirectNativeInt(this ILGenerator generator, ILGenerator nativePointer)
        {
            generator.Emit(OpCodes.Ldind_I);
            return generator;
        }

        public static ILGenerator LoadIndirectSByte(this ILGenerator generator, ILGenerator nativePointer)
        {
            generator.Emit(OpCodes.Ldind_I1);
            return generator;
        }

        public static ILGenerator LoadIndirectShort(this ILGenerator generator, ILGenerator nativePointer)
        {
            generator.Emit(OpCodes.Ldind_I2);
            return generator;
        }

        public static ILGenerator LoadIndirectInt(this ILGenerator generator, ILGenerator nativePointer)
        {
            generator.Emit(OpCodes.Ldind_I4);
            return generator;
        }

        public static ILGenerator LoadIndirectLong(this ILGenerator generator, ILGenerator nativePointer)
        {
            generator.Emit(OpCodes.Ldind_I8);
            return generator;
        }

        public static ILGenerator LoadIndirectFloat(this ILGenerator generator, ILGenerator nativePointer)
        {
            generator.Emit(OpCodes.Ldind_R4);
            return generator;
        }

        public static ILGenerator LoadIndirectDouble(this ILGenerator generator, ILGenerator nativePointer)
        {
            generator.Emit(OpCodes.Ldind_R8);
            return generator;
        }

        public static ILGenerator LoadIndirectObjectReference(this ILGenerator generator, ILGenerator nativePointer)
        {
            generator.Emit(OpCodes.Ldind_Ref);
            return generator;
        }

        public static ILGenerator LoadIndirectByte(this ILGenerator generator, ILGenerator nativePointer)
        {
            generator.Emit(OpCodes.Ldind_U1);
            return generator;
        }

        public static ILGenerator LoadIndirectUShort(this ILGenerator generator, ILGenerator nativePointer)
        {
            generator.Emit(OpCodes.Ldind_U2);
            return generator;
        }

        public static ILGenerator LoadIndirectUInt(this ILGenerator generator, ILGenerator nativePointer)
        {
            generator.Emit(OpCodes.Ldind_U4);
            return generator;
        }

#endregion

#region LoadArrayLength +

        public static ILGenerator LoadArrayLength(this ILGenerator generator, ILGenerator arrayReference)
        {
            generator.Emit(OpCodes.Ldlen);
            return generator;
        }

#endregion

#region LoadLocal +

        public static ILGenerator LoadLocal(this ILGenerator generator, int index, params ILGenerator[] _)
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
                    generator.Emit(OpCodes.Ldloc, (short)index);
                    break;
            }

            return generator;
        }

        public static ILGenerator LoadLocal(this ILGenerator generator, params int[] index)
        {
            foreach (var i in index)
                generator.LoadLocal(i);

            return generator;
        }

        public static ILGenerator LoadLocal_S(this ILGenerator generator, int index, params ILGenerator[] _)
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
                    generator.Emit(OpCodes.Ldloc_S, (byte)index);
                    break;
            }

            return generator;
        }

        public static ILGenerator LoadLocal_S(this ILGenerator generator, params int[] index)
        {
            foreach (var i in index)
                generator.LoadLocal(i);

            return generator;
        }

#endregion

#region LoadLocalAdress +

        public static ILGenerator LoadLocalAddress(this ILGenerator generator, int index)
        {
            generator.Emit(OpCodes.Ldloca, (short)index);
            return generator;
        }

        public static ILGenerator LoadLocalAddress_S(this ILGenerator generator, int index)
        {
            generator.Emit(OpCodes.Ldloca_S, (byte)index);
            return generator;
        }

#endregion

#region LoadNullReference +

        public static ILGenerator LoadNullReference(this ILGenerator generator)
        {
            generator.Emit(OpCodes.Ldnull);
            return generator;
        }

#endregion

#region LoadObject +

        public static ILGenerator LoadObject(this ILGenerator generator, Type type)
        {
            generator.Emit(OpCodes.Ldobj, type);
            return generator;
        }

        public static ILGenerator LoadObject<T>(this ILGenerator generator)
        {
            generator.Emit(OpCodes.Ldobj, typeof(T));
            return generator;
        }

#endregion

#region LoadString +

        public static ILGenerator Box(this ILGenerator generator, string value)
        {
            generator.Emit(OpCodes.Ldstr, value);
            return generator;
        }

#endregion

#region LoadToken +

        public static ILGenerator LoadToken(this ILGenerator generator, MethodInfo value)
        {
            generator.Emit(OpCodes.Ldtoken, value);
            return generator;
        }

        public static ILGenerator LoadToken(this ILGenerator generator, FieldInfo value)
        {
            generator.Emit(OpCodes.Ldtoken, value);
            return generator;
        }

        public static ILGenerator LoadToken(this ILGenerator generator, Type value)
        {
            generator.Emit(OpCodes.Ldtoken, value);
            return generator;
        }

        public static ILGenerator LoadToken<T>(this ILGenerator generator)
        {
            generator.Emit(OpCodes.Ldtoken, typeof(T));
            return generator;
        }

#endregion

#region LoadUnmanagedVirtualMethod +

        public static ILGenerator LoadUnmanagedVirtualMethod(this ILGenerator generator, MethodInfo methodInfo, ILGenerator unmanagedObjectReference)
        {
            generator.Emit(OpCodes.Ldstr, methodInfo);
            return generator;
        }

#endregion

#region Leave +

        public static ILGenerator Leave(this ILGenerator generator, Label label)
        {
            generator.Emit(OpCodes.Leave, label);
            return generator;
        }

        public static ILGenerator Leave_S(this ILGenerator generator, Label label)
        {
            generator.Emit(OpCodes.Leave, label);
            return generator;
        }

#endregion

#region LocalAlloc +

        public static ILGenerator LocalAlloc(this ILGenerator generator, ILGenerator byteCount)
            => generator.EmitOpCodes(OpCodes.Localloc);

#endregion

#region MakeTypedReference +

        public static ILGenerator MakeTypedReference(this ILGenerator generator, Type type)
        {
            generator.Emit(OpCodes.Mkrefany, type);
            return generator;
        }

        public static ILGenerator MakeTypedReference<T>(this ILGenerator generator)
        {
            generator.Emit(OpCodes.Mkrefany, typeof(T));
            return generator;
        }

#endregion

#region Multiply +

        public static ILGenerator Multiply(this ILGenerator generator, ILGenerator value1, ILGenerator value2)
            => generator.EmitOpCodes(OpCodes.Mul);

        public static ILGenerator Multiply(this ILGenerator generator, params ILGenerator[] _)
            => generator.EmitOpCodes(OpCodes.Mul);

#endregion

#region MultiplyOverflow +

        public static ILGenerator MultiplyOverflow(this ILGenerator generator, ILGenerator value1, ILGenerator value2)
            => generator.EmitOpCodes(OpCodes.Mul_Ovf);

        public static ILGenerator MultiplyOverflow(this ILGenerator generator, params ILGenerator[] _)
            => generator.EmitOpCodes(OpCodes.Mul_Ovf);

#endregion

#region MultiplyOverflowUnsigned +

        public static ILGenerator MultiplyOverflowUnsigned(this ILGenerator generator, ILGenerator value1, ILGenerator value2)
            => generator.EmitOpCodes(OpCodes.Mul_Ovf_Un);

        public static ILGenerator MultiplyOverflowUnsigned(this ILGenerator generator, params ILGenerator[] _)
            => generator.EmitOpCodes(OpCodes.Mul_Ovf_Un);

#endregion

#region Negate +

        public static ILGenerator Negate(this ILGenerator generator, ILGenerator value)
            => generator.EmitOpCodes(OpCodes.Neg);

        public static ILGenerator Negate(this ILGenerator generator, params ILGenerator[] _)
            => generator.EmitOpCodes(OpCodes.Neg);

#endregion

#region NewArray +

        public static ILGenerator NewArray<T>(this ILGenerator generator, ILGenerator length)
            => generator.EmitOpCodes(OpCodes.Newarr, typeof(T));

        public static ILGenerator NewArray<T>(this ILGenerator generator, params ILGenerator[] _)
            => generator.EmitOpCodes(OpCodes.Newarr, typeof(T));

        public static ILGenerator NewArray(this ILGenerator generator, Type type, ILGenerator length)
            => generator.EmitOpCodes(OpCodes.Newarr, type);

        public static ILGenerator NewArray(this ILGenerator generator, Type type, params ILGenerator[] _)
            => generator.EmitOpCodes(OpCodes.Newarr, type);

#endregion

#region NewObject

        public static ILGenerator NewObject<T>(this ILGenerator generator, params ILGenerator[] _)
            => generator.EmitOpCodes(OpCodes.Newobj, typeof(T));

        public static ILGenerator NewObject(this ILGenerator generator, Type type, params ILGenerator[] _)
            => generator.EmitOpCodes(OpCodes.Newobj, type);

        public static ILGenerator NewObject<T, U>(this ILGenerator generator, params ILGenerator[] _) where U : ITypesMarker
            => generator.EmitOpCodes(OpCodes.Newobj, typeof(T).GetConstructor(typeof(U).GenericTypeArguments)!);

        public static ILGenerator NewObject(this ILGenerator generator, ConstructorInfo constructorInfo, params ILGenerator[] _)
            => generator.EmitOpCodes(OpCodes.Newobj, constructorInfo);

#endregion

#region NoOperation

        public static ILGenerator NoOperation(this ILGenerator generator, params ILGenerator[] _)
            => generator.EmitOpCodes(OpCodes.Nop);

#endregion

#region Not +

        public static ILGenerator Not(this ILGenerator generator, ILGenerator value)
            => generator.EmitOpCodes(OpCodes.Not);

        public static ILGenerator Not(this ILGenerator generator, params ILGenerator[] _)
            => generator.EmitOpCodes(OpCodes.Not);

#endregion

#region Or +

        public static ILGenerator Or(this ILGenerator generator, ILGenerator value1, ILGenerator value2)
            => generator.EmitOpCodes(OpCodes.Or);

        public static ILGenerator Or(this ILGenerator generator, params ILGenerator[] _)
            => generator.EmitOpCodes(OpCodes.Or);

#endregion

#region Pop +

        public static ILGenerator Pop(this ILGenerator generator, params ILGenerator[] _)
            => generator.EmitOpCodes(OpCodes.Pop);

#endregion

#region Prefix +

        public static ILGenerator Prefix1(this ILGenerator generator, params ILGenerator[] _)
            => generator.EmitOpCodes(OpCodes.Prefix1);

        public static ILGenerator Prefix2(this ILGenerator generator, params ILGenerator[] _)
            => generator.EmitOpCodes(OpCodes.Prefix2);

        public static ILGenerator Prefix3(this ILGenerator generator, params ILGenerator[] _)
            => generator.EmitOpCodes(OpCodes.Prefix3);

        public static ILGenerator Prefix4(this ILGenerator generator, params ILGenerator[] _)
            => generator.EmitOpCodes(OpCodes.Prefix4);

        public static ILGenerator Prefix5(this ILGenerator generator, params ILGenerator[] _)
            => generator.EmitOpCodes(OpCodes.Prefix5);

        public static ILGenerator Prefix6(this ILGenerator generator, params ILGenerator[] _)
            => generator.EmitOpCodes(OpCodes.Prefix6);

        public static ILGenerator Prefix7(this ILGenerator generator, params ILGenerator[] _)
            => generator.EmitOpCodes(OpCodes.Prefix7);

        public static ILGenerator PrefixRef(this ILGenerator generator, params ILGenerator[] _)
            => generator.EmitOpCodes(OpCodes.Prefixref);

#endregion

#region Readonly +

        public static ILGenerator Readonly(this ILGenerator generator, params ILGenerator[] _)
            => generator.EmitOpCodes(OpCodes.Readonly);

#endregion

#region ReferenceTypeToken +

        public static ILGenerator ReferenceTypeToken(this ILGenerator generator, ILGenerator typedReference)
            => generator.EmitOpCodes(OpCodes.Refanytype);

        public static ILGenerator ReferenceTypeToken(this ILGenerator generator, params ILGenerator[] _)
            => generator.EmitOpCodes(OpCodes.Refanytype);

#endregion

#region ReferenceValueAdress +

        public static ILGenerator ReferenceValueAdress<T>(this ILGenerator generator, ILGenerator typedReference)
            => generator.EmitOpCodes(OpCodes.Refanyval, typeof(T));

        public static ILGenerator ReferenceValueAdress<T>(this ILGenerator generator, params ILGenerator[] _)
            => generator.EmitOpCodes(OpCodes.Refanyval, typeof(T));

        public static ILGenerator ReferenceValueAdress(this ILGenerator generator, Type type, ILGenerator typedReference)
            => generator.EmitOpCodes(OpCodes.Refanyval, type);

        public static ILGenerator ReferenceValueAdress(this ILGenerator generator, Type type, params ILGenerator[] _)
            => generator.EmitOpCodes(OpCodes.Refanyval, type);

#endregion

#region Remainder +

        public static ILGenerator Remainder(this ILGenerator generator, ILGenerator value1, ILGenerator value2)
            => generator.EmitOpCodes(OpCodes.Rem);

        public static ILGenerator Remainder(this ILGenerator generator, params ILGenerator[] _)
            => generator.EmitOpCodes(OpCodes.Rem);

#endregion

#region RemainderUnsigned +

        public static ILGenerator RemainderUnsigned(this ILGenerator generator, ILGenerator value1, ILGenerator value2)
            => generator.EmitOpCodes(OpCodes.Rem_Un);

        public static ILGenerator RemainderUnsigned(this ILGenerator generator, params ILGenerator[] _)
            => generator.EmitOpCodes(OpCodes.Rem_Un);

#endregion

#region Return +

        public static ILGenerator Return(this ILGenerator generator)
            => generator.EmitOpCodes(OpCodes.Ret);

        public static ILGenerator Return(this ILGenerator generator, ILGenerator value)
            => generator.EmitOpCodes(OpCodes.Ret);

        public static ILGenerator Return(this ILGenerator generator, params ILGenerator[] _)
            => generator.EmitOpCodes(OpCodes.Ret);

#endregion

#region Rethrow +

        public static ILGenerator Rethrow(this ILGenerator generator, params ILGenerator[] _)
            => generator.EmitOpCodes(OpCodes.Rethrow);

#endregion

#region ShiftLeft +

        public static ILGenerator ShiftLeft(this ILGenerator generator, ILGenerator value, ILGenerator shiftCount)
            => generator.EmitOpCodes(OpCodes.Shl);

        public static ILGenerator ShiftLeft(this ILGenerator generator, params ILGenerator[] _)
            => generator.EmitOpCodes(OpCodes.Shl);

#endregion

#region ShiftRight +

        public static ILGenerator ShiftRight(this ILGenerator generator, ILGenerator value, ILGenerator shiftCount)
            => generator.EmitOpCodes(OpCodes.Shr);

        public static ILGenerator ShiftRight(this ILGenerator generator, params ILGenerator[] _)
            => generator.EmitOpCodes(OpCodes.Shr);

#endregion

#region ShiftRightUnsigned +

        public static ILGenerator ShiftRightUnsigned(this ILGenerator generator, ILGenerator value, ILGenerator shiftCount)
            => generator.EmitOpCodes(OpCodes.Shr_Un);

        public static ILGenerator ShiftRightUnsigned(this ILGenerator generator, params ILGenerator[] _)
            => generator.EmitOpCodes(OpCodes.Shr_Un);

#endregion

#region SizeOf +

        public static ILGenerator SizeOf<T>(this ILGenerator generator)
            => generator.EmitOpCodes(OpCodes.Sizeof, typeof(T));

        public static ILGenerator SizeOf<T>(this ILGenerator generator, params ILGenerator[] _)
            => generator.EmitOpCodes(OpCodes.Sizeof, typeof(T));

        public static ILGenerator SizeOf(this ILGenerator generator, Type type)
            => generator.EmitOpCodes(OpCodes.Sizeof, type);

        public static ILGenerator SizeOf(this ILGenerator generator, Type type, params ILGenerator[] _)
            => generator.EmitOpCodes(OpCodes.Sizeof, type);

#endregion

#region StoreArgument +

        public static ILGenerator StoreArgument(this ILGenerator generator, int index, params ILGenerator[] _)
        {
            generator.Emit(OpCodes.Starg, (short)index);

            return generator;
        }

        public static ILGenerator StoreArgument_S(this ILGenerator generator, int index, params ILGenerator[] _)
        {
            generator.Emit(OpCodes.Starg_S, (byte)index);

            return generator;
        }

        public static ILGenerator StoreArgument(this ILGenerator generator, int index, ILGenerator value)
        {
            generator.Emit(OpCodes.Starg, (short)index);
            return generator;
        }

        public static ILGenerator StoreArgument_S(this ILGenerator generator, int index, ILGenerator value)
        {
            generator.Emit(OpCodes.Starg_S, (byte)index);

            return generator;
        }

#endregion


#region StoreLocal

        public static ILGenerator StoreLocal(this ILGenerator generator, int index, params ILGenerator[] _)
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

        public static ILGenerator StoreLocal(this ILGenerator generator, int index, ILGenerator value)
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

        public static ILGenerator StoreLocal_S(this ILGenerator generator, int index, params ILGenerator[] _)
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

        public static ILGenerator StoreLocal_S(this ILGenerator generator, int index, ILGenerator value)
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

#endregion +


#region Emit

        private static ILGenerator EmitOpCodes(this ILGenerator generator, OpCode opcode)
        {
            generator.Emit(opcode);
            return generator;
        }

        private static ILGenerator EmitOpCodes(this ILGenerator generator, OpCode opcode, Type type)
        {
            generator.Emit(opcode, type);
            return generator;
        }

        private static ILGenerator EmitOpCodes(this ILGenerator generator, OpCode opcode, ConstructorInfo ctorInfo)
        {
            generator.Emit(opcode, ctorInfo);
            return generator;
        }

#endregion

#region MarkLabel

        public static ILGenerator MarkLabel2(this ILGenerator generator, Label label)
        {
            generator.MarkLabel(label);
            return generator;
        }

#endregion
    }
}
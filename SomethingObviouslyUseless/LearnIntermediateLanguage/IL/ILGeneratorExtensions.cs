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

        public static ILGenerator Add(this ILGenerator generator, ILGenerator left, ILGenerator right)
            => generator.EmitOpCodes(OpCodes.Add);

        public static ILGenerator Add(this ILGenerator generator, params ILGenerator[] _)
            => generator.EmitOpCodes(OpCodes.Add);

        #endregion

        #region AddOverflow +

        public static ILGenerator AddOverflow(this ILGenerator generator, ILGenerator left, ILGenerator right)
            => generator.EmitOpCodes(OpCodes.Add_Ovf);

        public static ILGenerator AddOverflow(this ILGenerator generator, params ILGenerator[] _)
            => generator.EmitOpCodes(OpCodes.Add_Ovf);

        #endregion

        #region AddOverflowUnsigned +

        public static ILGenerator AddOverflowUnsigned(this ILGenerator generator, ILGenerator left, ILGenerator right)
            => generator.EmitOpCodes(OpCodes.Add_Ovf_Un);

        public static ILGenerator AddOverflowUnsigned(this ILGenerator generator, params ILGenerator[] _)
            => generator.EmitOpCodes(OpCodes.Add_Ovf_Un);

        #endregion

        #region And +

        public static ILGenerator And(this ILGenerator generator, ILGenerator left, ILGenerator right)
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

        public static ILGenerator BranchEqual(this ILGenerator generator, Label label, ILGenerator left, ILGenerator right)
        {
            generator.Emit(OpCodes.Beq, label);
            return generator;
        }

        public static ILGenerator BranchEqual_S(this ILGenerator generator, Label label, ILGenerator left, ILGenerator right)
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

        public static ILGenerator BranchGreaterEqual(this ILGenerator generator, Label label, ILGenerator left, ILGenerator right)
        {
            generator.Emit(OpCodes.Bge, label);
            return generator;
        }

        public static ILGenerator BranchGreaterEqual_S(this ILGenerator generator, Label label, ILGenerator left, ILGenerator right)
        {
            generator.Emit(OpCodes.Bge_S, label);
            return generator;
        }

        public static ILGenerator BranchGreaterEqualUnsigned(this ILGenerator generator, Label label, ILGenerator left, ILGenerator right)
        {
            generator.Emit(OpCodes.Bge_Un, label);
            return generator;
        }

        public static ILGenerator BranchGreaterEqualUnsigned_S(this ILGenerator generator, Label label, ILGenerator left, ILGenerator right)
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

        public static ILGenerator BranchGreaterThan(this ILGenerator generator, Label label, ILGenerator left, ILGenerator right)
        {
            generator.Emit(OpCodes.Bgt, label);
            return generator;
        }

        public static ILGenerator BranchGreaterThan_S(this ILGenerator generator, Label label, ILGenerator left, ILGenerator right)
        {
            generator.Emit(OpCodes.Bgt_S, label);
            return generator;
        }

        public static ILGenerator BranchGreaterThanUnsigned(this ILGenerator generator, Label label, ILGenerator left, ILGenerator right)
        {
            generator.Emit(OpCodes.Bgt_Un, label);
            return generator;
        }

        public static ILGenerator BranchGreaterThanUnsigned_S(this ILGenerator generator, Label label, ILGenerator left, ILGenerator right)
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

        public static ILGenerator BranchLessEqual(this ILGenerator generator, Label label, ILGenerator left, ILGenerator right)
        {
            generator.Emit(OpCodes.Ble, label);
            return generator;
        }

        public static ILGenerator BranchLessEqual_S(this ILGenerator generator, Label label, ILGenerator left, ILGenerator right)
        {
            generator.Emit(OpCodes.Ble_S, label);
            return generator;
        }

        public static ILGenerator BranchLessEqualUnsigned(this ILGenerator generator, Label label, ILGenerator left, ILGenerator right)
        {
            generator.Emit(OpCodes.Ble_Un, label);
            return generator;
        }

        public static ILGenerator BranchLessEqualUnsigned_S(this ILGenerator generator, Label label, ILGenerator left, ILGenerator right)
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

        public static ILGenerator BranchLessThan(this ILGenerator generator, Label label, ILGenerator left, ILGenerator right)
        {
            generator.Emit(OpCodes.Blt, label);
            return generator;
        }

        public static ILGenerator BranchLessThan_S(this ILGenerator generator, Label label, ILGenerator left, ILGenerator right)
        {
            generator.Emit(OpCodes.Blt_S, label);
            return generator;
        }

        public static ILGenerator BranchLessThanUnsigned(this ILGenerator generator, Label label, ILGenerator left, ILGenerator right)
        {
            generator.Emit(OpCodes.Blt_Un, label);
            return generator;
        }

        public static ILGenerator BranchLessThanUnsigned_S(this ILGenerator generator, Label label, ILGenerator left, ILGenerator right)
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

        public static ILGenerator BranchNotEqualUnsigned(this ILGenerator generator, Label label, ILGenerator left, ILGenerator right)
        {
            generator.Emit(OpCodes.Bne_Un, label);
            return generator;
        }

        public static ILGenerator BranchNotEqualUnsigned_S(this ILGenerator generator, Label label, ILGenerator left, ILGenerator right)
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

        public static ILGenerator BranchFalse(this ILGenerator generator, Label label, ILGenerator _)
        {
            generator.Emit(OpCodes.Brfalse, label);
            return generator;
        }

        public static ILGenerator BranchFalse_S(this ILGenerator generator, Label label, ILGenerator _)
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

        public static ILGenerator BranchTrue(this ILGenerator generator, Label label, ILGenerator _)
        {
            generator.Emit(OpCodes.Brtrue, label);
            return generator;
        }

        public static ILGenerator BranchTrue_S(this ILGenerator generator, Label label, ILGenerator _)
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
            generator.Emit(OpCodes.Call, typeof(T).GetMethod(methodName));
            return generator;
        }

        public static ILGenerator Call<T, U>(this ILGenerator generator, string methodName, params ILGenerator[] _) where U : struct, ITypesMarker
        {
            generator.Emit(OpCodes.Call, typeof(T).GetMethod(methodName, typeof(U).GetGenericArguments()));
            return generator;
        }

        public static ILGenerator CallCtor<T, U>(this ILGenerator generator, params ILGenerator[] _) where U : struct, ITypesMarker
        {
            generator.Emit(OpCodes.Call, typeof(T).GetConstructor(typeof(U).GetGenericArguments()));
            return generator;
        }

        #endregion

        #region CallIndirect ?

        // method arguments arg1 -> argN, methodPointer

        public static ILGenerator CallIndirectManaged<T, U>(this ILGenerator generator, CallingConventions callingConventions = CallingConventions.Standard, params ILGenerator[] _) where U : struct, ITypesMarker
        {
            generator.EmitCalli(OpCodes.Calli, callingConventions, typeof(T), typeof(U).GetGenericArguments(), Array.Empty<Type>());
            return generator;
        }

        public static ILGenerator CallIndirectUnmanaged<T, U>(this ILGenerator generator, CallingConvention callingConvention = CallingConvention.StdCall, params ILGenerator[] _) where U : struct, ITypesMarker
        {
            generator.EmitCalli(OpCodes.Call, callingConvention, typeof(T), typeof(U).GetGenericArguments());
            return generator;
        }

        #endregion

        #region CallVirtual ?

        // obj reference, method arguments arg1 -> argN

        public static ILGenerator CallVirtual<T>(this ILGenerator generator, string methodName, params ILGenerator[] _)
        {
            generator.Emit(OpCodes.Callvirt, typeof(T).GetMethod(methodName));
            return generator;
        }

        public static ILGenerator CallVirtual<T, U>(this ILGenerator generator, string methodName, params ILGenerator[] _) where U : struct, ITypesMarker
        {
            generator.Emit(OpCodes.Callvirt, typeof(T).GetMethod(methodName, typeof(U).GetGenericArguments()));
            return generator;
        }

        #endregion

        #region CastClass +

        public static ILGenerator CastClass(this ILGenerator generator, ILGenerator _)
            => generator.EmitOpCodes(OpCodes.Castclass);

        public static ILGenerator CastClass(this ILGenerator generator, params ILGenerator[] _)
            => generator.EmitOpCodes(OpCodes.Castclass);

        #endregion

        #region CompareEqual +

        public static ILGenerator CompareEqual(this ILGenerator generator, ILGenerator left, ILGenerator right)
            => generator.EmitOpCodes(OpCodes.Ceq);

        public static ILGenerator CompareEqual(this ILGenerator generator, params ILGenerator[] _)
            => generator.EmitOpCodes(OpCodes.Ceq);

        #endregion

        #region CompareGreaterThan +

        public static ILGenerator CompareGreaterThan(this ILGenerator generator, ILGenerator left, ILGenerator right)
            => generator.EmitOpCodes(OpCodes.Cgt);

        public static ILGenerator CompareGreaterThan(this ILGenerator generator, params ILGenerator[] _)
            => generator.EmitOpCodes(OpCodes.Cgt);

        public static ILGenerator CompareGreaterThanUnsigned(this ILGenerator generator, ILGenerator left, ILGenerator right)
            => generator.EmitOpCodes(OpCodes.Cgt_Un);

        public static ILGenerator CompareGreaterThanUnsigned(this ILGenerator generator, params ILGenerator[] _)
            => generator.EmitOpCodes(OpCodes.Cgt_Un);

        #endregion

        #region CheckFinite +

        public static ILGenerator CheckInfinite(this ILGenerator generator, ILGenerator _)
            => generator.EmitOpCodes(OpCodes.Ckfinite);

        public static ILGenerator CheckInfinite(this ILGenerator generator, params ILGenerator[] _)
            => generator.EmitOpCodes(OpCodes.Ckfinite);

        #endregion

        #region CompareLessThan +

        public static ILGenerator CompareLessThan(this ILGenerator generator, ILGenerator left, ILGenerator right)
            => generator.EmitOpCodes(OpCodes.Clt);

        public static ILGenerator CompareLessThan(this ILGenerator generator, params ILGenerator[] _)
            => generator.EmitOpCodes(OpCodes.Clt);

        public static ILGenerator CompareLessThanUnsigned(this ILGenerator generator, ILGenerator left, ILGenerator right)
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

        public static ILGenerator ConvertToNativeInt(this ILGenerator generator, ILGenerator _)
            => generator.EmitOpCodes(OpCodes.Conv_I);

        public static ILGenerator ConvertToNativeInt(this ILGenerator generator, params ILGenerator[] _)
            => generator.EmitOpCodes(OpCodes.Conv_I);

        public static ILGenerator ConvertToNativeUnsignedInt(this ILGenerator generator, ILGenerator _)
            => generator.EmitOpCodes(OpCodes.Conv_U);

        public static ILGenerator ConvertToNativeUnsignedInt(this ILGenerator generator, params ILGenerator[] _)
            => generator.EmitOpCodes(OpCodes.Conv_U);

        public static ILGenerator ConvertToNativeIntOverflow(this ILGenerator generator, ILGenerator _)
            => generator.EmitOpCodes(OpCodes.Conv_Ovf_I);

        public static ILGenerator ConvertToNativeIntOverflow(this ILGenerator generator, params ILGenerator[] _)
            => generator.EmitOpCodes(OpCodes.Conv_Ovf_I);

        public static ILGenerator ConvertToNativeUnsignedIntOverflow(this ILGenerator generator, ILGenerator _)
            => generator.EmitOpCodes(OpCodes.Conv_Ovf_U);

        public static ILGenerator ConvertToNativeUnsignedIntOverflow(this ILGenerator generator, params ILGenerator[] _)
            => generator.EmitOpCodes(OpCodes.Conv_Ovf_U);

        public static ILGenerator ConvertUnsignedToNativeIntOverflow(this ILGenerator generator, ILGenerator _)
            => generator.EmitOpCodes(OpCodes.Conv_Ovf_I_Un);

        public static ILGenerator ConvertUnsignedToNativeIntOverflow(this ILGenerator generator, params ILGenerator[] _)
            => generator.EmitOpCodes(OpCodes.Conv_Ovf_I_Un);

        public static ILGenerator ConvertUnsignedToNativeUnsignedIntOverflow(this ILGenerator generator, ILGenerator _)
            => generator.EmitOpCodes(OpCodes.Conv_Ovf_U_Un);

        public static ILGenerator ConvertUnsignedToNativeUnsignedIntOverflow(this ILGenerator generator, params ILGenerator[] _)
            => generator.EmitOpCodes(OpCodes.Conv_Ovf_U_Un);

        #endregion

        #region ConvertToByteExtendToInt +

        public static ILGenerator ConvertToSignedByteExtendToInt(this ILGenerator generator, ILGenerator _)
            => generator.EmitOpCodes(OpCodes.Conv_I1);

        public static ILGenerator ConvertToSignedByteExtendToInt(this ILGenerator generator, params ILGenerator[] _)
            => generator.EmitOpCodes(OpCodes.Conv_I1);

        public static ILGenerator ConvertToByteExtendToInt(this ILGenerator generator, ILGenerator _)
            => generator.EmitOpCodes(OpCodes.Conv_U1);

        public static ILGenerator ConvertToByteExtendToInt(this ILGenerator generator, params ILGenerator[] _)
            => generator.EmitOpCodes(OpCodes.Conv_U1);

        public static ILGenerator ConvertToSignedByteExtendToIntOverflow(this ILGenerator generator, ILGenerator _)
            => generator.EmitOpCodes(OpCodes.Conv_Ovf_I1);

        public static ILGenerator ConvertToSignedByteExtendToIntOverflow(this ILGenerator generator, params ILGenerator[] _)
            => generator.EmitOpCodes(OpCodes.Conv_Ovf_I1);

        public static ILGenerator ConvertToByteExtendToIntOverflow(this ILGenerator generator, ILGenerator _)
            => generator.EmitOpCodes(OpCodes.Conv_Ovf_U1);

        public static ILGenerator ConvertToByteExtendToIntOverflow(this ILGenerator generator, params ILGenerator[] _)
            => generator.EmitOpCodes(OpCodes.Conv_Ovf_U1);

        public static ILGenerator ConvertUnsignedToSignedByteExtendToIntOverflow(this ILGenerator generator, ILGenerator _)
            => generator.EmitOpCodes(OpCodes.Conv_Ovf_I1_Un);

        public static ILGenerator ConvertUnsignedToSignedByteExtendToIntOverflow(this ILGenerator generator, params ILGenerator[] _)
            => generator.EmitOpCodes(OpCodes.Conv_Ovf_I1_Un);

        public static ILGenerator ConvertUnsignedToByteExtendToIntOverflow(this ILGenerator generator, ILGenerator _)
           => generator.EmitOpCodes(OpCodes.Conv_Ovf_U1_Un);

        public static ILGenerator ConvertUnsignedToByteExtendToIntOverflow(this ILGenerator generator, params ILGenerator[] _)
            => generator.EmitOpCodes(OpCodes.Conv_Ovf_U1_Un);

        #endregion

        #region ConvertToShortExtendToInt +

        public static ILGenerator ConvertToShortExtendToInt(this ILGenerator generator, ILGenerator first)
            => generator.EmitOpCodes(OpCodes.Conv_I2);

        public static ILGenerator ConvertToShortExtendToInt(this ILGenerator generator, params ILGenerator[] _)
            => generator.EmitOpCodes(OpCodes.Conv_I2);

        public static ILGenerator ConvertToUnsignedShortExtendToInt(this ILGenerator generator, ILGenerator first)
            => generator.EmitOpCodes(OpCodes.Conv_U2);

        public static ILGenerator ConvertToUnsignedShortExtendToInt(this ILGenerator generator, params ILGenerator[] _)
            => generator.EmitOpCodes(OpCodes.Conv_U2);

        public static ILGenerator ConvertToShortExtendToIntOverflow(this ILGenerator generator, ILGenerator first)
            => generator.EmitOpCodes(OpCodes.Conv_Ovf_I2);

        public static ILGenerator ConvertToShortExtendToIntOverflow(this ILGenerator generator, params ILGenerator[] _)
            => generator.EmitOpCodes(OpCodes.Conv_Ovf_I2);

        public static ILGenerator ConvertToUnsignedShortExtendToIntOverflow(this ILGenerator generator, ILGenerator first)
            => generator.EmitOpCodes(OpCodes.Conv_Ovf_U2);

        public static ILGenerator ConvertToUnsignedShortExtendToIntOverflow(this ILGenerator generator, params ILGenerator[] _)
            => generator.EmitOpCodes(OpCodes.Conv_Ovf_U2);

        public static ILGenerator ConvertUnsignedToShortExtendToIntOverflow(this ILGenerator generator, ILGenerator first)
            => generator.EmitOpCodes(OpCodes.Conv_Ovf_I2_Un);

        public static ILGenerator ConvertUnsignedToShortExtendToIntOverflow(this ILGenerator generator, params ILGenerator[] _)
            => generator.EmitOpCodes(OpCodes.Conv_Ovf_I2_Un);

        public static ILGenerator ConvertUnsignedToUnsignedShortExtendToIntOverflow(this ILGenerator generator, ILGenerator first)
            => generator.EmitOpCodes(OpCodes.Conv_Ovf_U2_Un);

        public static ILGenerator ConvertUnsignedToUnsignedShortExtendToIntOverflow(this ILGenerator generator, params ILGenerator[] _)
            => generator.EmitOpCodes(OpCodes.Conv_Ovf_U2_Un);

        #endregion

        #region ConvertToInt +

        public static ILGenerator ConvertToInt(this ILGenerator generator, ILGenerator _)
            => generator.EmitOpCodes(OpCodes.Conv_I4);

        public static ILGenerator ConvertToInt(this ILGenerator generator, params ILGenerator[] _)
            => generator.EmitOpCodes(OpCodes.Conv_I4);

        public static ILGenerator ConvertToUnsignedInt(this ILGenerator generator, ILGenerator _)
           => generator.EmitOpCodes(OpCodes.Conv_U4);

        public static ILGenerator ConvertToUnsignedInt(this ILGenerator generator, params ILGenerator[] _)
            => generator.EmitOpCodes(OpCodes.Conv_U4);

        public static ILGenerator ConvertToIntOverflow(this ILGenerator generator, ILGenerator _)
            => generator.EmitOpCodes(OpCodes.Conv_Ovf_I4);

        public static ILGenerator ConvertToIntOverflow(this ILGenerator generator, params ILGenerator[] _)
            => generator.EmitOpCodes(OpCodes.Conv_Ovf_I4);

        public static ILGenerator ConvertToUnsignedIntOverflow(this ILGenerator generator, ILGenerator _)
           => generator.EmitOpCodes(OpCodes.Conv_Ovf_U4);

        public static ILGenerator ConvertToUnsignedIntOverflow(this ILGenerator generator, params ILGenerator[] _)
            => generator.EmitOpCodes(OpCodes.Conv_Ovf_U4);

        public static ILGenerator ConvertUnsignedToIntOverflow(this ILGenerator generator, ILGenerator _)
            => generator.EmitOpCodes(OpCodes.Conv_Ovf_I4_Un);

        public static ILGenerator ConvertUnsignedToIntOverflow(this ILGenerator generator, params ILGenerator[] _)
            => generator.EmitOpCodes(OpCodes.Conv_Ovf_I4_Un);

        public static ILGenerator ConvertUnsignedToUnsignedIntOverflow(this ILGenerator generator, ILGenerator _)
           => generator.EmitOpCodes(OpCodes.Conv_Ovf_U4_Un);

        public static ILGenerator ConvertUnsignedToUnsignedIntOverflow(this ILGenerator generator, params ILGenerator[] _)
            => generator.EmitOpCodes(OpCodes.Conv_Ovf_U4_Un);

        #endregion

        #region ConvertToLong +

        public static ILGenerator ConvertToLong(this ILGenerator generator, ILGenerator _)
            => generator.EmitOpCodes(OpCodes.Conv_I8);

        public static ILGenerator ConvertToLong(this ILGenerator generator, params ILGenerator[] _)
            => generator.EmitOpCodes(OpCodes.Conv_I8);

        public static ILGenerator ConvertToUnsginedLong(this ILGenerator generator, ILGenerator _)
           => generator.EmitOpCodes(OpCodes.Conv_U8);

        public static ILGenerator ConvertToUnsginedLong(this ILGenerator generator, params ILGenerator[] _)
            => generator.EmitOpCodes(OpCodes.Conv_U8);

        public static ILGenerator ConvertToLongOverflow(this ILGenerator generator, ILGenerator _)
            => generator.EmitOpCodes(OpCodes.Conv_Ovf_I8);

        public static ILGenerator ConvertToLongOverflow(this ILGenerator generator, params ILGenerator[] _)
            => generator.EmitOpCodes(OpCodes.Conv_Ovf_I8);

        public static ILGenerator ConvertToUnsginedLongOverflow(this ILGenerator generator, ILGenerator _)
           => generator.EmitOpCodes(OpCodes.Conv_Ovf_U8);

        public static ILGenerator ConvertToUnsginedLongOverflow(this ILGenerator generator, params ILGenerator[] _)
            => generator.EmitOpCodes(OpCodes.Conv_Ovf_U8);

        public static ILGenerator ConvertUnsignedToLongOverflow(this ILGenerator generator, ILGenerator _)
            => generator.EmitOpCodes(OpCodes.Conv_Ovf_I8_Un);

        public static ILGenerator ConvertUnsignedToLongOverflow(this ILGenerator generator, params ILGenerator[] _)
            => generator.EmitOpCodes(OpCodes.Conv_Ovf_I8_Un);

        public static ILGenerator ConvertUnsignedToUnsginedLongOverflow(this ILGenerator generator, ILGenerator _)
           => generator.EmitOpCodes(OpCodes.Conv_Ovf_U8_Un);

        public static ILGenerator ConvertUnsignedToUnsginedLongOverflow(this ILGenerator generator, params ILGenerator[] _)
            => generator.EmitOpCodes(OpCodes.Conv_Ovf_U8_Un);

        #endregion

        #region ConvertToFloat +

        public static ILGenerator ConvertUnsignedToFloat(this ILGenerator generator, ILGenerator _)
           => generator.EmitOpCodes(OpCodes.Conv_R_Un);

        public static ILGenerator ConvertUnsignedToFloat(this ILGenerator generator, params ILGenerator[] _)
            => generator.EmitOpCodes(OpCodes.Conv_R_Un);

        public static ILGenerator ConvertToFloat(this ILGenerator generator, ILGenerator _)
           => generator.EmitOpCodes(OpCodes.Conv_R4);

        public static ILGenerator ConvertToFloat(this ILGenerator generator, params ILGenerator[] _)
            => generator.EmitOpCodes(OpCodes.Conv_R4);

        #endregion

        #region ConvertToDouble +

        public static ILGenerator ConvertToDouble(this ILGenerator generator, ILGenerator _)
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

        public static ILGenerator Divide(this ILGenerator generator, ILGenerator left, ILGenerator right)
         => generator.EmitOpCodes(OpCodes.Div);

        public static ILGenerator Divide(this ILGenerator generator, params ILGenerator[] _)
         => generator.EmitOpCodes(OpCodes.Div);

        public static ILGenerator DivideUnsigned(this ILGenerator generator, ILGenerator left, ILGenerator right)
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

        #region LoadArgumentAdress +

        public static ILGenerator LoadArgumentAdress(this ILGenerator generator, short index)
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

        #region LoadInteger



        #endregion

        #region LoadFloat



        #endregion

        #region Remainder +

        public static ILGenerator Remainder(this ILGenerator generator, ILGenerator left, ILGenerator right)
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

        #region StoreArgument +

        public static ILGenerator StoreArgument(this ILGenerator generator, short index, params ILGenerator[] _)
        {
            generator.Emit(OpCodes.Starg, index);

            return generator;
        }

        public static ILGenerator StoreArgument(this ILGenerator generator, byte index, params ILGenerator[] _)
        {
            generator.Emit(OpCodes.Starg_S, index);

            return generator;
        }

        public static ILGenerator StoreArgument(this ILGenerator generator, short index, ILGenerator _)
        {
            generator.Emit(OpCodes.Starg, index);

            return generator;
        }

        public static ILGenerator StoreArgument(this ILGenerator generator, byte index, ILGenerator _)
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

        public static ILGenerator StoreLocal(this ILGenerator generator, short index, ILGenerator _)
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

        public static ILGenerator StoreLocal(this ILGenerator generator, byte index, ILGenerator _)
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

        #region Return        

        public static ILGenerator Return(this ILGenerator generator, ILGenerator _)
           => generator.EmitOpCodes(OpCodes.Ret);

        public static ILGenerator Return(this ILGenerator generator, params ILGenerator[] _)
            => generator.EmitOpCodes(OpCodes.Ret);

        #endregion +

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

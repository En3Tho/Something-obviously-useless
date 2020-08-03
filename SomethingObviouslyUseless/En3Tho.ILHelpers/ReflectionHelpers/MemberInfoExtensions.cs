using System.Reflection;
using System.Reflection.Emit;
using En3Tho.ILHelpers.IL;

namespace En3Tho.ILHelpers.ReflectionHelpers
{
    public static class MemberInfoExtensions
    {
        public static ILGenerator Call(this MethodInfo mi, ILGenerator values) => mi.IsVirtual ? values.CallVirtual(mi) : values.Call(mi);
        public static ILGenerator Load(this FieldInfo fi, ILGenerator thisPtr) => thisPtr.LoadField(fi);
        public static ILGenerator Get(this PropertyInfo pi, ILGenerator thisPtr) => pi.GetMethod.Call(thisPtr);
        public static ILGenerator Set(this PropertyInfo pi, ILGenerator thisPtr, ILGenerator value) => pi.SetMethod.Call(thisPtr);
        public static ILGenerator Set(this PropertyInfo pi, ILGenerator thisPtr) => pi.SetMethod.Call(thisPtr);
        public static ILGenerator Load(this LocalBuilder lb, ILGenerator gen) => gen.LoadLocal(lb.LocalIndex);
        public static ILGenerator Store(this LocalBuilder lb, ILGenerator value) => value.StoreLocal(lb.LocalIndex);
    }
}
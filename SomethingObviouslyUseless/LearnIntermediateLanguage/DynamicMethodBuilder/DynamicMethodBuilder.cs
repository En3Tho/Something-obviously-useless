using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;

namespace LearnIntermediateLanguage
{
    public class DynamicMethodBuilder<T> where T : Delegate
    {
        private readonly DynamicMethod _dynamicMethod;
        private ILGenerator _ILGenerator;

        public ILGenerator ILGenerator => _ILGenerator ??= _dynamicMethod.GetILGenerator();

        public DynamicMethodBuilder(string methodName)
        {
            _dynamicMethod = GetMethod(methodName, GetArguments());
        }

        public DynamicMethodBuilder<T> IL(Action<ILGenerator> action)
        {
            action(ILGenerator);
            return this;
        }       

        public T Build()
        {
            return _dynamicMethod.CreateDelegate<T>();
        }

        public T Build(object target)
        {
            return _dynamicMethod.CreateDelegate<T>(target);
        }

        private static DynamicMethod GetMethod(string methodName, (Type, Type[]) types)
            => new DynamicMethod(methodName, types.Item1, types.Item2);
       
        private static (Type, Type[]) GetArguments()
        {
            var invoke = typeof(T).GetMethod("Invoke");
            return (invoke.ReturnType, invoke.GetParameters().Select(x => x.ParameterType).ToArray());
        }

        #region Locals

        public DynamicMethodBuilder<T> Locals<U>(bool pinned = false) where U : struct, ITypesMarker
        {
            foreach (var t in typeof(U).GetGenericArguments())
                ILGenerator.DeclareLocal(t, pinned);

            return this;
        }       

        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using En3Tho.ILHelpers.MemberHolders;

namespace En3Tho.ILHelpers.DynamicMethodBuilder
{
    public class DynamicMethodBuilder<T> where T : Delegate
    {
        private readonly DynamicMethod _dynamicMethod;
        private Dictionary<string, MemberHolder>? namedMembers;
        private readonly Type[] _parameterTypes;
        public Dictionary<string, MemberHolder> Members => namedMembers ??= new Dictionary<string, MemberHolder>();

        public ILGenerator ILGenerator { get; }

        public DynamicMethodBuilder(string methodName)
        {
            Type returnType;
            (returnType, _parameterTypes) = GetTypes();
            _dynamicMethod = GetMethod(methodName, (returnType, _parameterTypes));
            ILGenerator = _dynamicMethod.GetILGenerator();
        }

        public DynamicMethodBuilder<T> IL(Action<ILGenerator> action)
        {
            action(ILGenerator);
            return this;
        }

        // TODO: static Create<T>, Create(Type)

        public T Build()
        {
            return _dynamicMethod.CreateDelegate<T>();
        }

        public T Build(object target)
        {
            return _dynamicMethod.CreateDelegate<T>(target);
        }

        private static DynamicMethod GetMethod(string methodName, (Type returnType, Type[] parameterTypes) types)
            => new DynamicMethod(methodName, types.returnType, types.parameterTypes);
       
        private static (Type returnType, Type[] parameterTypes) GetTypes()
        {
            var invoke = typeof(T).GetMethod("Invoke")!;
            return (invoke.ReturnType, invoke.GetParameters().Select(x => x.ParameterType).ToArray());
        }

        #region Locals

        public DynamicMethodBuilder<T> Locals<U>(bool pinned = false) where U : struct, ITypesMarker
        {
            foreach (var t in typeof(U).GetGenericArguments())
                ILGenerator.DeclareLocal(t, pinned);
            return this;
        }
        
        public DynamicMethodBuilder<T> Locals<U>(bool pinned = false, params string[] names) where U : struct, ITypesMarker
        {
            var genericArgs = typeof(U).GetGenericArguments();
            if (names.Length != genericArgs.Length) throw new InvalidOperationException("Lengths of declared locals and names must be equal");
            for (var index = 0; index < typeof(U).GetGenericArguments().Length; index++)
                Members.Add(names[index], new LocalHolder(ILGenerator.DeclareLocal(genericArgs[index], pinned)));
            return this;
        }

        public DynamicMethodBuilder<T> Locals<U>(params string[] names) where U : struct, ITypesMarker => Locals<U>(false, names);

        public DynamicMethodBuilder<T> Local(string name, Type t, bool pinned = false)
        {
            var local = ILGenerator.DeclareLocal(t, pinned);
            Members.Add(name, new LocalHolder(local));
            return this;
        }

        public DynamicMethodBuilder<T> Arguments(params string[] names)
        {
            if (_parameterTypes.Length != names.Length) throw new InvalidOperationException("Lengths of declared arguments and names must be equal");
            for (int i = 0; i < _parameterTypes.Length; i++)
                Members.Add(names[i], new ArgumentHolder(i));
            return this;
        }

        public DynamicMethodBuilder<T> Load(string name, ILGenerator thisPtr)
        {
            Members[name].Load(thisPtr);
            return this;
        }
        
        public DynamicMethodBuilder<T> Load(string name)
        {
            Members[name].Load(ILGenerator);
            return this;
        }
        
        public DynamicMethodBuilder<T> Store(string name, ILGenerator value)
        {
            Members[name].Store(value);
            return this;
        }
        
        public DynamicMethodBuilder<T> Store(string name)
        {
            Members[name].Store(ILGenerator);
            return this;
        }

#endregion
    }
}

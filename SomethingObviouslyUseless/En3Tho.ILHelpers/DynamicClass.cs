using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;

namespace En3Tho.ILHelpers
{
    internal static class DynamicClass // TODO: work on it?
    {
        public static void GetClassWithIntInt()
        {
            var assemblyName = new AssemblyName("DynamicTypes");
            var assemblyBuilder = AssemblyBuilder.DefineDynamicAssembly(assemblyName, AssemblyBuilderAccess.RunAndCollect);
            var moduleBuilder = assemblyBuilder.DefineDynamicModule(assemblyName + ".dll");
            var typeBuilder = moduleBuilder.DefineType("IntIntClass", TypeAttributes.Public, typeof(ValueType));
            var fieldBuilder = typeBuilder.DefineField("In1", typeof(int), FieldAttributes.Public);
            var methodBuilder = typeBuilder.DefineMethod("GetInt1", MethodAttributes.Public);
            var propertyBuilder = typeBuilder.DefineProperty("Int1Prop", PropertyAttributes.None, typeof(int), Array.Empty<Type>());
        }
    }

    public abstract class TypeBuilderBase
    {
        private static readonly int CtorHashCode = "ctor".GetHashCode();
        private static readonly int MethodHashCode = "method".GetHashCode();
        private static readonly int FieldHashCode = "field".GetHashCode();
        private static readonly int PropertyHashCode = "property".GetHashCode();

        public AssemblyBuilder AssemblyBuilder { get; }
        public ModuleBuilder ModuleBuilder { get; }
        public TypeBuilder TypeBuilder { get; }

        protected Dictionary<int, MemberInfo> Members => _members ??= new Dictionary<int, MemberInfo>();
        private Dictionary<int, MemberInfo>? _members;
        protected Dictionary<int, CustomAttributeBuilder> Attributes => _attributes ??= new Dictionary<int, CustomAttributeBuilder>();
        private Dictionary<int, CustomAttributeBuilder>? _attributes;

        protected TypeBuilderBase(AssemblyBuilder assemblyBuilder, ModuleBuilder moduleBuilder, string name, TypeAttributes attributes, Type baseType)
        {
            AssemblyBuilder = assemblyBuilder;
            ModuleBuilder = moduleBuilder;
            TypeBuilder = moduleBuilder.DefineType(name, attributes, baseType);
        }

        private void AddMember(MemberInfo info)
        {
            var nameHashCode = info.Name.GetHashCode();
            var typeHashCode = GetTypeHashCode(info);
            Members.Add(HashCode.Combine(nameHashCode, typeHashCode), info);
        }

        public FieldBuilder GetField(string name)
        {
            var nameHashCode = name.GetHashCode();
            return (FieldBuilder)Members[HashCode.Combine(nameHashCode, FieldHashCode)];
        }

        public MethodBuilder GetMethod(string name)
        {
            var nameHashCode = name.GetHashCode();
            return (MethodBuilder)Members[HashCode.Combine(nameHashCode, MethodHashCode)];
        }

        public ConstructorBuilder GetConstructor(string name)
        {
            var nameHashCode = name.GetHashCode();
            return (ConstructorBuilder)Members[HashCode.Combine(nameHashCode, CtorHashCode)];
        }

        public PropertyBuilder GetProperty(string name)
        {
            var nameHashCode = name.GetHashCode();
            return (PropertyBuilder)Members[HashCode.Combine(nameHashCode, PropertyHashCode)];
        }

        private static int GetTypeHashCode(MemberInfo info)
            => info switch
            {
                FieldBuilder _ => FieldHashCode,
                PropertyBuilder _ => PropertyHashCode,
                ConstructorBuilder _ => CtorHashCode,
                MethodBuilder _ => MethodHashCode,
                _ => throw new InvalidOperationException("Unsupported type")
            };

        public void WithPublicFields(params FieldDescriptor[] descriptors) => WithFields(FieldAttributes.Public, descriptors);
        public void WithPrivateFields(params FieldDescriptor[] descriptors) => WithFields(FieldAttributes.Private, descriptors);
        public void WithPublicStaticFields(params FieldDescriptor[] descriptors) => WithFields(FieldAttributes.Public | FieldAttributes.Static, descriptors);
        public void WithPrivateStaticFields(params FieldDescriptor[] descriptors) => WithFields(FieldAttributes.Private | FieldAttributes.Static, descriptors);

        private void WithFields(FieldAttributes attributes, params FieldDescriptor[] descriptors)
        {
            foreach (var descriptor in descriptors)
            {
                AddMember(TypeBuilder.DefineField(descriptor.Name, descriptor.Type, descriptor.Attributes | attributes));
            }
        }

        public void WithPublicMethods(params MethodDescriptor[] descriptors) => WithMethods(MethodAttributes.Public, descriptors);
        public void WithPrivateMethods(params MethodDescriptor[] descriptors) => WithMethods(MethodAttributes.Private, descriptors);
        public void WithPublicStaticMethods(params MethodDescriptor[] descriptors) => WithMethods(MethodAttributes.Public | MethodAttributes.Static, descriptors);
        public void WithPrivateStaticMethods(params MethodDescriptor[] descriptors) => WithMethods(MethodAttributes.Private | MethodAttributes.Static, descriptors);

        private void WithMethods(MethodAttributes attributes, params MethodDescriptor[] descriptors)
        {
            foreach (var descriptor in descriptors)
            {
                var member = TypeBuilder.DefineMethod(descriptor.Name, descriptor.Attributes | attributes, descriptor.ReturnType, descriptor.ParameterTypes);
                descriptor.Generator(member.GetILGenerator());
                AddMember(member);
            }
        }

        public void WithProperties(PropertyAttributes attributes, params PropertyDescriptor[] descriptors)
        {
            foreach (var descriptor in descriptors)
            {
                var member = TypeBuilder.DefineProperty(descriptor.Name, descriptor.Attributes | attributes, descriptor.Type, Array.Empty<Type>());

                // TODO: Checks
                var getMethodDesc = descriptor.GetMethod;
                var getMethod = TypeBuilder.DefineMethod(getMethodDesc.Name, getMethodDesc.Attributes, getMethodDesc.ReturnType, getMethodDesc.ParameterTypes);
                getMethodDesc.Generator(getMethod.GetILGenerator());

                // TODO: Checks
                var setMethodDesc = descriptor.SetMethod;
                var setMethod = TypeBuilder.DefineMethod(setMethodDesc.Name, setMethodDesc.Attributes, setMethodDesc.ReturnType, setMethodDesc.ParameterTypes);
                setMethodDesc.Generator(getMethod.GetILGenerator());

                member.SetGetMethod(getMethod);
                member.SetSetMethod(setMethod);

                AddMember(member);
            }
        }

        public void WithAttributes(params AttributeDescriptor[] descriptors)
        {

        }
    }

    public class ClassBuilder : TypeBuilderBase
    {
        public ClassBuilder(AssemblyBuilder assemblyBuilder, ModuleBuilder moduleBuilder, string name, TypeAttributes attributes, Type baseType)
            : base(assemblyBuilder, moduleBuilder, name, attributes | TypeAttributes.Class, baseType)
        {
            if (baseType.IsValueType)
                throw new ArgumentException("Base type of class should not be value type", nameof(baseType));
        }
    }

    public class StructBuilder : TypeBuilderBase
    {
        public StructBuilder(AssemblyBuilder assemblyBuilder, ModuleBuilder moduleBuilder, string name, TypeAttributes attributes)
            : base(assemblyBuilder, moduleBuilder, name, attributes | TypeAttributes.Class ^ TypeAttributes.Class, typeof(ValueType))
        {
                
        }
    }

    public struct ConstructorDescriptor
    {
        public readonly string Name;
        public readonly Type Type;
        public readonly Action<ILGenerator> Generator;
    }

    public struct FieldDescriptor
    {
        public readonly string Name;
        public readonly Type Type;
        public readonly FieldAttributes Attributes;
    }

    public struct MethodDescriptor
    {
        public readonly string Name;
        public readonly Type ReturnType;
        public readonly Type[] ParameterTypes;
        public readonly Action<ILGenerator> Generator;
        public readonly MethodAttributes Attributes;
    }

    public struct PropertyDescriptor
    {
        public readonly string Name;
        public readonly Type Type;
        public readonly MethodDescriptor GetMethod;
        public readonly MethodDescriptor SetMethod;
        public readonly PropertyAttributes Attributes;

        public void WithGetMethod(MethodDescriptor descriptor)
        {

        }

        public void WithSetMethod(MethodDescriptor descriptor)
        {

        }
    }

    public struct AttributeDescriptor
    {

    }
}

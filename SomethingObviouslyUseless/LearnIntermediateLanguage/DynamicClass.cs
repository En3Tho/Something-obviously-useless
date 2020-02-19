using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading;

namespace LearnIntermediateLanguage
{
    public static class DynamicClass
    {
        public static Type GetClassWithIntInt()
        {
            AssemblyName assemblyName = new AssemblyName("DynamicTypes");
            var assemblyBuilder = AssemblyBuilder.DefineDynamicAssembly(assemblyName, AssemblyBuilderAccess.RunAndCollect);
            var moduleBuilder = assemblyBuilder.DefineDynamicModule(assemblyName + ".dll");
            TypeBuilder typeBuilder = moduleBuilder.DefineType("IntIntClass", TypeAttributes.Public, typeof(ValueType));
            var fieldBuilder = typeBuilder.DefineField("In1", typeof(int), FieldAttributes.Public);
            
        }        
    }

    public abstract class TypeBuilderBase
    {
        private static readonly int CtorHashCode = "ctor".GetHashCode();
        private static readonly int MethodHashCode = "method".GetHashCode();
        private static readonly int FieldHashCode = "field".GetHashCode();
        private static readonly int PropertyHashCode = "property".GetHashCode();

        private void AddMember(MemberInfo info)
        {
            var nameHashCode = info.Name.GetHashCode();
            var typeHashCode = GetTypeHashCode(info);
            _members[HashCode.Combine(nameHashCode, typeHashCode)] = info;
        }

        private FieldBuilder GetField(string name)
        {
            var nameHashCode = name.GetHashCode();
            return (FieldBuilder)_members[HashCode.Combine(nameHashCode, FieldHashCode)];
        }

        private MethodBuilder GetMethod(string name)
        {
            var nameHashCode = name.GetHashCode();
            return (MethodBuilder)_members[HashCode.Combine(nameHashCode, MethodHashCode)];
        }

        private ConstructorBuilder GetConstructor(string name)
        {
            var nameHashCode = name.GetHashCode();
            return (ConstructorBuilder)_members[HashCode.Combine(nameHashCode, CtorHashCode)];
        }

        private PropertyBuilder GetProperty(string name)
        {
            var nameHashCode = name.GetHashCode();
            return (PropertyBuilder)_members[HashCode.Combine(nameHashCode, PropertyHashCode)];
        }

        private int GetTypeHashCode(MemberInfo info)
            => info switch
            {
                FieldBuilder _ => FieldHashCode,
                PropertyBuilder _ => PropertyHashCode,
                ConstructorBuilder _ => CtorHashCode,
                MethodBuilder _ => MethodHashCode,
                _ => throw new InvalidOperationException("Unsupported type")
            };

        private Dictionary<int, MemberInfo> _members;
        private Dictionary<int, CustomAttributeBuilder> _attributes;

        // string.hashcode combine string hashcode -> 
        // ctor
        // field
        // property
        // method

        public void WithPublicFields() { }
        public void WithPrivateFields() { }

        public void WithPublicStaticFields() { }
        public void WithPrivateStaticFields() { }

        public void WithPublicMethods() { }
        public void WithPrivateMethods() { }

        public void WithPublicProperties() { }
        public void WithPrivateProperties() { }

        public void WithAttributes() { }
    }

    public class ClassBuilder : TypeBuilderBase
    {
        
    }

    public class StructBilder : TypeBuilderBase
    {

    }

    public struct ConstructorDescriptor
    {
        public readonly string Name;
        public readonly Type Type;
        public readonly ILGenerator Generator;
    }

    public struct FieldDescriptor
    {
       public readonly string Name;
       public readonly Type Type;
       public readonly ILGenerator Generator;
       public readonly FieldAttributes Attributes;
    }

    public struct MethodDescriptor
    {
        public readonly string Name;
        public readonly Type Type;
        public readonly ILGenerator Generator;
    }

    public struct PropertyDescriptor
    {
        public readonly string Name;
        public readonly Type Type;
        public readonly ILGenerator Generator;
    }

    public struct AttributeDescriptor
    {

    }
}

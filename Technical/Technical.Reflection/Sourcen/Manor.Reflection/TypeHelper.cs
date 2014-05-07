using System;
using System.ComponentModel;
using System.Diagnostics;

namespace Technical.Reflection
{
    /// <summary>
    /// Helper class for Types
    /// </summary>
    public class TypeHelper
    {
        public static bool IsNullableType(Type typeToCheck)
        {
            Debug.Assert(typeToCheck != null, "Type ist null");
            return (typeToCheck.IsGenericType && typeToCheck.GetGenericTypeDefinition().Equals(typeof (Nullable<>)));
        }

        public static Type GetUnderlyingTypeOfNullable(Type conversionType)
        {
            Debug.Assert(conversionType != null, "Type ist null");
            Debug.Assert(IsNullableType(conversionType), string.Format("Type {0} ist nicht nullable", conversionType));

            var nullableConverter = new NullableConverter(conversionType);
            Type result = nullableConverter.UnderlyingType;
            return result;
        }

        public static Type MakeGenericType(string typeName, params Type[] types)
        {
            Debug.Assert(!string.IsNullOrEmpty(typeName), "typeName ist null");
            Debug.Assert(types != null, "types ist null");

            string t = String.Format("{0}`{1}", typeName, types.Length);
            return Type.GetType(t).MakeGenericType(types);
        }

        public static Type MakeGenericType(string assemblyName, string typeName, params Type[] types)
        {
            Debug.Assert(!string.IsNullOrEmpty(assemblyName), "assemblyName ist null");
            Debug.Assert(!string.IsNullOrEmpty(typeName), "typeName ist null");
            Debug.Assert(types != null, "types ist null");

            string completeTypename = String.Format("{0}`{1}, {2}", typeName, types.Length, assemblyName);
            Type genericType = Type.GetType(completeTypename).MakeGenericType(types);

            return genericType;
        }

        public static string GetAssemblyQualifiedNameNoVersion(Type type)
        {
            string assemblyQualifiedNameNoVersion = null;

            string[] assemblyQualifiedNameArray = type.AssemblyQualifiedName.Split(',');
            assemblyQualifiedNameNoVersion = assemblyQualifiedNameArray[0] + "," + assemblyQualifiedNameArray[1];

            return assemblyQualifiedNameNoVersion;
        }
    }
}
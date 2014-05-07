using System;
using System.Reflection;

namespace Technical.Reflection
{
    public class IgnoringVersionTypeLoader
    {
        public static Type GetType(string typeName)
        {
            Type type = null;

            type = Type.GetType(typeName, false);
            if (type == null)
            {
                var assemblyString = GetAssemblyName(typeName);
                if (!string.IsNullOrEmpty(assemblyString))
                {
                    var assemblyName = new AssemblyName(assemblyString);
                    var assembly = Assembly.LoadWithPartialName(assemblyName.Name);

                    var typeNameString = GetTypeName(typeName);
                    type = assembly.GetType(typeNameString);
                }
            }
            return type;
        }

        private static string GetAssemblyName(string typeName)
        {
            string assemblyName = null;
            Func<AssemblyName, Assembly> assemblyResolver = name =>
            {
                assemblyName = name.FullName;
                return null;
            };

            var type = Type.GetType(typeName, assemblyResolver, null, false);
            if (type != null)
                assemblyName = type.Assembly.FullName;

            return assemblyName;
        }

        private static string GetTypeName(string typeName)
        {
            Func<AssemblyName, Assembly> assemblyResolver = a => { return Assembly.GetExecutingAssembly(); };

            string typeNameString = null;
            Func<Assembly, string, bool, Type> typeResolver = (a, s, b) =>
            {
                typeNameString = s;
                return null;
            };

            var type = Type.GetType(typeName, assemblyResolver, typeResolver, false);
            if (type != null)
                typeName = type.Name;

            return typeNameString;
        }
    }
}
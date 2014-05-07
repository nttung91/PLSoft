using System;
using System.Diagnostics;
using System.Reflection;

namespace Technical.Reflection
{
    /// <summary>
    /// Helper class to create an instance by reflection
    /// </summary>
    public static class ActivatorHelper
    {
        public static bool TypeExists(string assemblyString, string typeName)
        {
            bool exists = false;

            Assembly assem = GetAssembly(assemblyString);
            Type type = assem.GetType(typeName);

            Debug.Assert(type != null, string.Format("Type [{0}, {1}] not found", assemblyString, typeName));

            if (type != null)
            {
                exists = true;
            }

            return exists;
        }

        public static bool ConstructorExists(string assemblyString, string typeName, Type[] parameterTypes)
        {
            Debug.Assert(!string.IsNullOrEmpty(assemblyString), "assemblyString ist null");
            Debug.Assert(!string.IsNullOrEmpty(typeName), "typeName ist null");
            Debug.Assert(parameterTypes != null, "parameterTypes ist null");

            bool exists = false;

            Assembly assem = GetAssembly(assemblyString);
            Type type = assem.GetType(typeName);

            Debug.Assert(type != null, string.Format("Type [{0}, {1}] not found", assemblyString, typeName));

            if (type != null)
            {
                ConstructorInfo constructorInfo = type.GetConstructor(parameterTypes);

                if (constructorInfo != null)
                {
                    exists = true;
                }
            }

            return exists;
        }

        public static object CreateInstance(Assembly assembly, Type type, object[] args)
        {
            Debug.Assert(assembly != null, "assembly ist null");
            Debug.Assert(type != null, "type is null");

            object instance = Activator.CreateInstance(type, args);

            Debug.Assert(instance != null, "instance ist null");

            return instance;
        }

        public static object CreateInstance(string assemblyString, string typeName)
        {
            return CreateInstance(assemblyString, typeName, null, null);
        }

        public static object CreateInstance(string assemblyString, string typeName, object[] args)
        {
            Debug.Assert(!string.IsNullOrEmpty(assemblyString), "assemblyString ist null");
            Debug.Assert(!string.IsNullOrEmpty(typeName), "typeName ist null");

            Assembly assem = GetAssembly(assemblyString);
            Type type = assem.GetType(typeName);

            Debug.Assert(type != null, "type not found");

            object result;

            if (type == null)
            {
                result = null;
            }
            else
            {
                result = CreateInstance(assem, type, args);
            }

            return result;
        }

        public static object CreateInstance(string assemblyName, string typeName, object[] args, Type[] argTypes)
        {
            Debug.Assert(!string.IsNullOrEmpty(assemblyName), "assemblyName ist null");
            Debug.Assert(!string.IsNullOrEmpty(typeName), "typeName ist null");

            string completeTypename = Assembly.CreateQualifiedName(assemblyName, typeName);
            Type type = Type.GetType(completeTypename);

            Debug.Assert(type != null, string.Format("Typ {0} existiert nicht in {1}", completeTypename, assemblyName));
            if (type == null) return null;

            if (argTypes == null) argTypes = Type.EmptyTypes;

            ConstructorInfo constructorInfo = type.GetConstructor(argTypes);
            Debug.Assert(constructorInfo != null, "Dieser Konstruktor existiert nicht ");
            if (constructorInfo == null) return null;

            object result = constructorInfo.Invoke(args);

            Debug.Assert(result != null, "Objekt wurde nicht erstellt");

            return result;
        }

        public static Assembly GetAssembly(string assemblyString)
        {
            Debug.Assert(!string.IsNullOrEmpty(assemblyString), "assemblyString ist null");
            return Assembly.Load(assemblyString);
        }

        /// <summary>
        /// Creates an instance of a generic class
        /// </summary>
        /// <param name="assemblyName"></param>
        /// <param name="typeName"></param>
        /// <param name="parameterTypes"></param>
        /// <returns></returns>
        public static object CreateGenericInstance(string assemblyName, string typeName, params Type[] parameterTypes)
        {
            Debug.Assert(!string.IsNullOrEmpty(assemblyName), "assemblyName ist null");
            Debug.Assert(!string.IsNullOrEmpty(typeName), "typeName ist null");
            Debug.Assert(parameterTypes != null, "parameterTypes ist null");

            string completeTypename = String.Format("{0}`{1}, {2}", typeName, parameterTypes.Length, assemblyName);
            Type genericType = Type.GetType(completeTypename).MakeGenericType(parameterTypes);

            Debug.Assert(genericType != null,
                string.Format("Typ {0} existiert nicht in {1}", completeTypename, assemblyName));
            if (genericType == null) return null;

            return Activator.CreateInstance(genericType);
        }

        public static Type[] GetParameterTypes(object[] parameters)
        {
            Debug.Assert(parameters != null, "parameters ist null");

            var parameterTypes = new Type[parameters.Length];
            int i = 0;
            foreach (object item in parameters)
            {
                if (item != null)
                {
                    parameterTypes[i++] = item.GetType();
                }
                else
                {
                    Debug.Assert(false, "Type unkown, may be object.");
                    parameterTypes[i++] = typeof (object);
                }
            }
            return parameterTypes;
        }

        public static object CreateGenericInstance(string typeName, params Type[] parameterTypes)
        {
            Debug.Assert(!string.IsNullOrEmpty(typeName), "typeName ist null");
            Debug.Assert(parameterTypes != null, "parameterTypes ist null");

            string t = String.Format("{0}`{1}", typeName, parameterTypes.Length);
            Type generic = Type.GetType(t).MakeGenericType(parameterTypes);
            return Activator.CreateInstance(generic);
        }
    }
}
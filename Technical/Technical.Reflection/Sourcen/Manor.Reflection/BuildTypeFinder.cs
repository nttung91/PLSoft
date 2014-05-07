using System;
using System.Diagnostics;
using System.Reflection;

namespace Technical.Reflection
{
    public class BuildTypeFinder
    {
        public static string GetBuildType(string assemblyName)
        {
            return GetBuildType(Assembly.LoadFrom(assemblyName));
        }

        public static string GetBuildType(Assembly assembly)
        {
            object[] attributes = assembly.GetCustomAttributes(typeof (DebuggableAttribute), false);

            if (attributes.Length == 0)
            {
                return "RELEASE";
            }

            foreach (Attribute attr in attributes)
            {
                if (attr is DebuggableAttribute)
                {
                    var d = attr as DebuggableAttribute;

                    if (d.IsJITOptimizerDisabled)
                    {
                        return "DEBUG";
                    }
                    return "RELEASE";
                }
            }

            return "UNKOWN";
        }
    }
}
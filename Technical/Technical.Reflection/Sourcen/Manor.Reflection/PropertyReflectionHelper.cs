using System;
using System.Diagnostics;
using System.Reflection;

namespace Technical.Reflection
{
    public class PropertyReflectionHelper
    {
        public static PropertyInfo GetPropertyInfo(object instance, string propertyName)
        {
            Debug.Assert(instance != null, "instance ist null");
            Debug.Assert(!string.IsNullOrEmpty(propertyName), "propertyName ist null");

            Type type = instance.GetType();
            PropertyInfo res = type.GetProperty(propertyName);
            if (res != null)
            {
                Debug.Assert(res.CanRead, string.Format("Property {0} is not readable", propertyName));
            }
            else
            {
                Debug.Assert(false, string.Format("Property {0} does not exist or is inaccessible", propertyName));
            }
            return res;
        }

        public static Attribute GetAttributeFromProperty(object instance, string propertyName, Type attributeType)
        {
            Debug.Assert(instance != null, "instance ist null");
            Debug.Assert(!string.IsNullOrEmpty(propertyName), "propertyName ist null");
            Debug.Assert(attributeType != null, "attributeType ist null");

            PropertyInfo propertyInfo = GetPropertyInfo(instance, propertyName);

            foreach (object attribute in propertyInfo.GetCustomAttributes(true))
            {
                if (attribute.GetType() == attributeType)
                {
                    return attribute as Attribute;
                }
            }
            return null;
        }

        public static string[] GetPropertyNames(object instance)
        {
            Debug.Assert(instance != null, "instance ist null");

            Type type = instance.GetType();
            PropertyInfo[] propertyInfos = type.GetProperties();
            var result = new string[propertyInfos.Length];
            for (int i = 0; i < propertyInfos.Length; i++)
            {
                result[i] = propertyInfos[i].Name;
            }
            return result;
        }

        public static bool HasProperty(object instance, string propertyName)
        {
            Debug.Assert(instance != null, "instance ist null");
            Debug.Assert(!string.IsNullOrEmpty(propertyName), "propertyName ist null");

            bool hasProperty = false;

            PropertyInfo propertyInfo = GetPropertyInfo(instance, propertyName);
            if (propertyInfo != null)
            {
                hasProperty = true;
            }

            return hasProperty;
        }

        public static T GetPropertyValue<T>(object instance, string propertyName)
        {
            Debug.Assert(instance != null, "instance ist null");
            Debug.Assert(!string.IsNullOrEmpty(propertyName), "propertyName ist null");

            T res = default(T);

            PropertyInfo propertyInfo = GetPropertyInfo(instance, propertyName);
            if (propertyInfo != null)
            {
                res = (T) propertyInfo.GetValue(instance, null);
            }

            return res;
        }

        public static bool PropertyHasAttribute<T>(object instance, string propertyName)
        {
            Debug.Assert(instance != null, "instance ist null");
            Debug.Assert(!string.IsNullOrEmpty(propertyName), "propertyName ist null");

            bool res = false;

            PropertyInfo propertyInfo = GetPropertyInfo(instance, propertyName);
            if (propertyInfo != null)
            {
                object[] attributes = propertyInfo.GetCustomAttributes(typeof (T), true);

                if (attributes != null)
                {
                    res = (attributes.Length > 0);
                }
            }

            return res;
        }

        public static Type GetPropertyType(object instance, string propertyName)
        {
            Debug.Assert(instance != null, "instance ist null");
            Debug.Assert(!string.IsNullOrEmpty(propertyName), "propertyName ist null");

            PropertyInfo propertyInfo = GetPropertyInfo(instance, propertyName);
            Type res = null;
            if (propertyInfo != null)
            {
                res = propertyInfo.PropertyType;
            }

            return res;
        }

        public static void SetPropertyValue<T>(object instance, string propertyName, T value)
        {
            Debug.Assert(instance != null, "instance ist null");
            Debug.Assert(!string.IsNullOrEmpty(propertyName), "propertyName ist null");

            Type type = instance.GetType();
            PropertyInfo propertyInfo = type.GetProperty(propertyName);

            if (propertyInfo != null)
            {
                propertyInfo.SetValue(instance, value, null);
            }
        }
    }
}
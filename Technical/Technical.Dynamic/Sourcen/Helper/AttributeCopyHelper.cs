using System;
using System.Diagnostics;
using System.Reflection;
using Techical.Dynamic.Attributes;

namespace Techical.Dynamic.Helper
{
    public class AttributeCopyHelper
    {
        public static void CopyPropertyValues(object objFrom, object objTo, bool overwrite)
        {
            Debug.Assert(objFrom != null && objTo != null, "At least one of the passed objects is null !");

            Type typeFrom = objFrom.GetType();
            Type typeTo = objTo.GetType();

            Debug.Assert(typeFrom == typeTo, "Objects have different types !");

            PropertyInfo[] propertyArray = typeFrom.GetProperties();
            Debug.Assert(propertyArray != null && propertyArray.Length > 0,
                "Type " + typeFrom.ToString() + " has no properties !");

            for (int i = 0; i < propertyArray.Length; i++)
            {
                if (propertyArray[i].CanRead == false ||
                    propertyArray[i].CanWrite == false) continue;

                object fromValue = propertyArray[i].GetValue(objFrom, null);
                object toValue = propertyArray[i].GetValue(objTo, null);

                if (checkForCopyAttribute(propertyArray[i], toValue) == false) continue;

                if (fromValue == null) continue;
                if (fromValue.Equals(toValue)) continue;
                if (toValue != null && !overwrite) continue;

                propertyArray[i].SetValue(objTo, fromValue, null);
            }
        }

        public static void CopyPropertyValues(object objFrom, object objTo)
        {
            Debug.Assert(objFrom != null && objTo != null, "At least one of the passed objects is null !");

            Type typeFrom = objFrom.GetType();
            Type typeTo = objTo.GetType();

            PropertyInfo[] propertyArray = typeFrom.GetProperties();
            Debug.Assert(propertyArray != null && propertyArray.Length > 0,
                "Type " + typeFrom.ToString() + " has no properties !");

            for (int i = 0; i < propertyArray.Length; i++)
            {
                if (propertyArray[i].CanRead == false ||
                    propertyArray[i].CanWrite == false) continue;

                PropertyInfo piTo = typeTo.GetProperty(propertyArray[i].Name);
                if (piTo == null) continue;

                object fromValue = propertyArray[i].GetValue(objFrom, null);
                if (fromValue == null) continue;

                piTo.SetValue(objTo, fromValue, null);
            }
        }

        private static bool checkForCopyAttribute(PropertyInfo pi, object targetValue)
        {
            if (targetValue == null || targetValue == DBNull.Value) return true;

            object[] customAttributes = pi.GetCustomAttributes(false);

            if (customAttributes == null || customAttributes.Length == 0) return false;

            var cpa = customAttributes[0] as CopyProperyAttribute;
            if (cpa == null) return false;

            return cpa.CopyProperty;
        }
    }
}
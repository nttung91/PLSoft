using System;
using System.ComponentModel;
using System.Reflection;

namespace Technical.Utilities.Helpers
{
    public static class EnumHelper
    {
        public static string GetEnumDescription(Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());
            var attributes =
                (DescriptionAttribute[]) fi.GetCustomAttributes
                    (typeof (DescriptionAttribute), false);
            return (attributes.Length > 0) ? attributes[0].Description : value.ToString();
        }

        public static T GetEnumValueFromDescription<T>(string description)
        {
            FieldInfo[] fiArray = typeof (T).GetFields();

            for (int i = 0; i < fiArray.Length; i++)
            {
                object[] arrAttrs = fiArray[i].GetCustomAttributes(false);
                if (arrAttrs.Length == 0) continue;

                var desAttr = arrAttrs[0] as DescriptionAttribute;
                if (desAttr == null) continue;
                if (string.IsNullOrEmpty(desAttr.Description)) continue;

                if (desAttr.Description.Equals(description))
                {
                    return (T) fiArray[i].GetValue(typeof (T));
                }
            }

            return default(T);
        }
    }
}
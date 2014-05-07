using System;

namespace Technical.Utilities.Helpers
{
    public static class ObjectToValue
    {
        public static T GetValue<T>(object obj)
        {
            object retVal = null;

            if (typeof (T) == typeof (DateTime) || typeof (T) == typeof (DateTime?))
            {
                if (obj == null || obj == DBNull.Value) obj = DateTime.Today;
                else
                {
                    retVal = Convert.ToDateTime(obj);
                }
            }

            if (typeof (T) == typeof (string))
            {
                if (obj == null || obj == DBNull.Value) obj = string.Empty;
                else
                {
                    retVal = obj.ToString();
                }
            }

            if (typeof (T) == typeof (int?))
            {
                if (obj == null || obj == DBNull.Value) return default(T);
            }

            if (typeof (T) == typeof (double?))
            {
                if (obj == null || obj == DBNull.Value) return default(T);
            }

            return (T) obj;
        }
    }
}
using System;

namespace Technical.Utilities.Helpers
{
    public static class StringHelper
    {
        public static string ConvertToString<T>(T[] values, string separator)
        {
            string toString = null;

            if (values != null)
            {
                toString = string.Empty;

                foreach (T value in values)
                {
                    toString += Convert.ToString(value) + (separator == null ? "|" : separator);
                }

                if (separator != null)
                    toString = toString.Remove(toString.Length - separator.Length);
                else
                    toString = toString.Remove(toString.Length - 1);
            }

            return toString;
        }
    }
}
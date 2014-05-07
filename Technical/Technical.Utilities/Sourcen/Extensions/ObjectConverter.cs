using System;
using System.ComponentModel;

namespace Technical.Utilities.Extensions
{
    internal class ObjectConverter
    {
        public static bool TryConvert<T>(object value, out T result)
        {
            //Typenspezifischer default Wert wird auf jeden Fall als resultat
            //der Konvertierung verwendet.
            result = default(T);

            if (value == null || value == DBNull.Value) return false;

            //falls der ZielTyp gleich dem Quelltyp ist, führe direkt die Konvertierung durch
            if (typeof (T) == value.GetType())
            {
                result = (T) value;
                return true;
            }

            string typeName = typeof (T).Name;

            try
            {
                //sollte der Typ Nullable oder ein Enum sein
                //verwende den TypeDescriptor und den TypeConverter
                if (typeName.IndexOf(typeof (Nullable).Name,
                    StringComparison.Ordinal) > -1 ||
                    typeof (T).BaseType.Name.IndexOf(typeof (Enum).Name,
                        StringComparison.Ordinal) > -1)
                {
                    TypeConverter tc = TypeDescriptor.GetConverter(typeof (T));
                    result = (T) tc.ConvertFrom(value);
                }
                else
                {
                    result = (T) Convert.ChangeType(value, typeof (T));
                }
            }
            catch
            {
                return false;
            }

            return true;
        }

        public static bool TryConvert(object value, Type toType, out object result)
        {
            //Typenspezifischer default Wert wird auf jeden Fall als resultat
            //der Konvertierung verwendet.
            result = null;

            if (value == null || value == DBNull.Value) return false;

            //falls der ZielTyp gleich dem Quelltyp ist, führe direkt die Konvertierung durch
            if (toType == value.GetType())
            {
                result = value;
                return true;
            }

            string typeName = toType.Name;

            try
            {
                //sollte der Typ Nullable oder ein Enum sein
                //verwende den TypeDescriptor und den TypeConverter
                if (typeName.IndexOf(typeof (Nullable).Name,
                    StringComparison.Ordinal) > -1 ||
                    toType.BaseType.Name.IndexOf(typeof (Enum).Name,
                        StringComparison.Ordinal) > -1)
                {
                    TypeConverter tc = TypeDescriptor.GetConverter(toType);
                    result = tc.ConvertFrom(value);
                }
                else
                {
                    result = Convert.ChangeType(value, toType);
                }
            }
            catch
            {
                return false;
            }

            return true;
        }

        public static T ConvertConvertible<T>(IConvertible obj)
        {
            Type t = typeof (T);

            if (t.IsGenericType
                && (t.GetGenericTypeDefinition() == typeof (Nullable<>)))
            {
                if (obj == null)
                {
                    return (T) (object) null;
                }
                return (T) Convert.ChangeType(obj, Nullable.GetUnderlyingType(t));
            }
            return (T) Convert.ChangeType(obj, t);
        }
    }
}
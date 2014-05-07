using System;
using Technical.Utilities.Exceptions;

namespace Technical.Utilities.Helpers
{
    public class ValueHelper
    {
        /// <summary>
        /// Convert an Object
        /// </summary>
        /// <param name="obj">Object</param>
        /// <returns>Wert
        ///   Für Obj == Null
        ///     - Numerische Werte --> 0
        ///     - String --> ""
        ///     - Datum --> Today
        /// </returns>
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

        /// <summary>
        /// Convert an Object
        /// </summary>
        /// <param name="obj">Object</param>
        /// <param name="obj">convertNull: Wenn False, ergibt null --> null
        /// </param>
        /// <returns>Wert
        ///   Für Obj == Null (wenn convertNull True):
        ///     - Numerische Werte --> 0
        ///     - String --> ""
        ///     - Datum --> Today
        /// </returns>        
        public static object GetValue<T>(object obj, bool convertNull)
        {
            if (! convertNull && (obj == null || obj == DBNull.Value)) return null;
            return GetValue<T>(obj);
        }


        /// <summary>
        /// Convert an Object to a Number
        /// </summary>
        /// <param name="obj">Object</param>
        /// <returns>Wert 
        ///    (Null wird als 0 konvertiert)
        /// </returns>   
        public static T ObjectAsNumber<T>(object obj)
        {
            //Stringinput Null und Empty zuerst prüfen
            if (obj is string && string.IsNullOrEmpty((string) obj)) return default(T);
            // Wenn der Input leer war (Null oder DBNull
            if (obj == null || Convert.IsDBNull(obj)) return default(T);
            // Wenn beide Typen gleich sind
            if (typeof (T) == obj.GetType()) return (T) obj;

            // Erst jetzt konvertieren mit Changetype

            try
            {
                object retVal = Convert.ChangeType(obj, typeof (T));
                return (T) retVal;
            }
            catch (FormatException)
            {
                string type = typeof (T).ToString();
                throw new PhuLiException(string.Format("Achtung {0} kann nicht in ein {1} umgewandelt werden",
                    obj.ToString(), type));
            }
        }
    }
}
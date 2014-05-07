using System;

namespace Technical.Utilities.Helpers
{
    public class AssignmentHelper
    {
        /// <summary>
        /// Assigns a decimal nullable Value if necessary
        /// </summary>
        /// <param name="oldValue">Property das zugewiesen wird</param>
        /// <param name="newValue">Wert</param>
        /// <returns>True wenn ein Wert zugewiesen wurde, sonst false</returns>
        public static bool AssignNullableValue(ref decimal? oldValue, decimal? newValue)
        {
            return AssignNullableValue(ref oldValue, newValue, null);
        }

        /// <summary>
        /// Assigns a decimal nullable Value if necessary and rounds if round
        /// </summary>
        /// <param name="oldValue">Property das zugewiesen wird</param>
        /// <param name="newValue">Wert</param>
        /// <param name="decimals">Anzahl Nachkommastellen zum Runden</param>
        /// <returns>True wenn ein Wert zugewiesen wurde, sonst false</returns>
        public static bool AssignNullableValue(ref decimal? oldValue, decimal? newValue, int? decimals)
        {
            bool hasChanged = false;
            if (newValue.HasValue && oldValue.HasValue)
            {
                if (oldValue.Value != newValue.Value)
                {
                    assignValue(ref oldValue, newValue, decimals);
                    hasChanged = true;
                }
            }
            else if (newValue.HasValue)
            {
                assignValue(ref oldValue, newValue, decimals);
                hasChanged = true;
            }
            else
            {
                oldValue = null;
                hasChanged = true;
            }
            return hasChanged;
        }

        /// <summary>
        /// Assigns a double nullable Value if necessary
        /// </summary>
        /// <param name="oldValue">Property das zugewiesen wird</param>
        /// <param name="newValue">Wert</param>
        /// <returns>True wenn ein Wert zugewiesen wurde, sonst false</returns>
        public static bool AssignNullableValue(ref double? oldValue, double? newValue)
        {
            return AssignNullableValue(ref oldValue, newValue, null);
        }

        /// <summary>
        /// Assigns a double nullable Value if necessary and rounds if round
        /// </summary>
        /// <param name="oldValue">Property das zugewiesen wird</param>
        /// <param name="newValue">Wert</param>
        /// <param name="decimals">Anzahl Nachkommastellen zum Runden</param>
        /// <returns>True wenn ein Wert zugewiesen wurde, sonst false</returns>
        public static bool AssignNullableValue(ref double? oldValue, double? newValue, int? decimals)
        {
            bool hasChanged = false;
            if (newValue.HasValue && oldValue.HasValue)
            {
                if (oldValue.Value != newValue.Value)
                {
                    assignValue(ref oldValue, newValue, decimals);
                    hasChanged = true;
                }
            }
            else if (newValue.HasValue)
            {
                assignValue(ref oldValue, newValue, decimals);
                hasChanged = true;
            }
            else
            {
                oldValue = null;
                hasChanged = true;
            }
            return hasChanged;
        }

        /// <summary>
        /// Assigns a int  nullable Value if necessary
        /// </summary>
        /// <param name="oldValue">Property das zugewiesen wird</param>
        /// <param name="newValue">Wert</param>
        /// <returns>True wenn ein Wert zugewiesen wurde, sonst false</returns>
        public static bool AssignNullableValue(ref int? oldValue, int? newValue)
        {
            bool hasChanged = false;
            if (newValue.HasValue && oldValue.HasValue)
            {
                if (oldValue.Value != newValue.Value)
                {
                    oldValue = newValue.Value;
                    hasChanged = true;
                }
            }
            else if (newValue.HasValue)
            {
                oldValue = newValue.Value;
                hasChanged = true;
            }
            else
            {
                oldValue = null;
                hasChanged = true;
            }
            return hasChanged;
        }

        /// <summary>
        /// Assigns a long  nullable Value if necessary
        /// </summary>
        /// <param name="oldValue">Property das zugewiesen wird</param>
        /// <param name="newValue">Wert</param>
        /// <returns>True wenn ein Wert zugewiesen wurde, sonst false</returns>
        public static bool AssignNullableValue(ref long? oldValue, long? newValue)
        {
            bool hasChanged = false;
            if (newValue.HasValue && oldValue.HasValue)
            {
                if (oldValue.Value != newValue.Value)
                {
                    oldValue = newValue.Value;
                    hasChanged = true;
                }
            }
            else if (newValue.HasValue)
            {
                oldValue = newValue.Value;
                hasChanged = true;
            }
            else
            {
                oldValue = null;
                hasChanged = true;
            }
            return hasChanged;
        }

        private static void assignValue(ref decimal? oldValue, decimal? newValue, int? decimals)
        {
            if (decimals.HasValue)
                oldValue = Math.Round(newValue.Value, decimals.Value);
            else
                oldValue = newValue.Value;
        }

        private static void assignValue(ref double? oldValue, double? newValue, int? decimals)
        {
            if (decimals.HasValue)
                oldValue = Math.Round(newValue.Value, decimals.Value);
            else
                oldValue = newValue.Value;
        }

        /// <summary>
        /// Assigns a DateTime nullable Value if necessary
        /// </summary>
        /// <param name="oldValue">Property das zugewiesen wird</param>
        /// <param name="newValue">Wert</param>
        /// <returns>True wenn ein Wert zugewiesen wurde, sonst false</returns>
        public static bool AssignNullableValue(ref DateTime? oldValue, DateTime? newValue)
        {
            bool hasChanged = false;
            if (newValue.HasValue && oldValue.HasValue)
            {
                if (oldValue.Value != newValue.Value)
                {
                    oldValue = newValue.Value;
                    hasChanged = true;
                }
            }
            else if (newValue.HasValue)
            {
                oldValue = newValue.Value;
                hasChanged = true;
            }
            else
            {
                oldValue = null;
                hasChanged = true;
            }
            return hasChanged;
        }

        /// <summary>
        /// Assigns an object of type T to another instance
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="oldValue"></param>
        /// <param name="newValue"></param>
        /// <returns></returns>
        public static bool AssignObject<T>(ref T oldValue, T newValue, bool allowNull)
        {
            bool hasChanged = false;
            if (newValue != null && oldValue != null)
            {
                if (!oldValue.Equals(newValue))
                {
                    oldValue = newValue;
                    hasChanged = true;
                }
            }
            else if (newValue != null)
            {
                oldValue = newValue;
                hasChanged = true;
            }
            else
            {
                if (allowNull && oldValue != null)
                {
                    oldValue = default(T);
                    hasChanged = true;
                }
            }
            return hasChanged;
        }
    }
}
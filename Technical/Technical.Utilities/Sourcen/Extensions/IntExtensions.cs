using System;

namespace Technical.Utilities.Extensions
{
    /// <summary>
    /// 	Extension methods for the integer data type
    /// </summary>
    public static class IntExtensions
    {
        /// <summary>
        /// 	Performs the specified action n times based on the underlying int value.
        /// </summary>
        /// <param name = "value">The value.</param>
        /// <param name = "action">The action.</param>
        public static void Times(this int value, Action action)
        {
            value.AsLong().Times(action);
        }

        /// <summary>
        /// 	Performs the specified action n times based on the underlying int value.
        /// </summary>
        /// <param name = "value">The value.</param>
        /// <param name = "action">The action.</param>
        public static void Times(this int value, Action<int> action)
        {
            // NOTE: Is it possible to reuse LongExtensions for this call?
            for (var i = 0; i < value; i++)
                action(i);
        }

        /// <summary>
        /// 	Determines whether the value is even
        /// </summary>
        /// <param name = "value">The Value</param>
        /// <returns>true or false</returns>
        public static bool IsEven(this int value)
        {
            return value.AsLong().IsEven();
        }

        /// <summary>
        /// 	Determines whether the value is odd
        /// </summary>
        /// <param name = "value">The Value</param>
        /// <returns>true or false</returns>
        public static bool IsOdd(this int value)
        {
            return value.AsLong().IsOdd();
        }

        /// <summary>Checks whether the value is in range</summary>
        /// <param name="value">The Value</param>
        /// <param name="minValue">The minimum value</param>
        /// <param name="maxValue">The maximum value</param>
        public static bool InRange(this int value, int minValue, int maxValue)
        {
            return value.AsLong().InRange(minValue, maxValue);
        }

        /// <summary>Checks whether the value is in range or returns the default value</summary>
        /// <param name="value">The Value</param>
        /// <param name="minValue">The minimum value</param>
        /// <param name="maxValue">The maximum value</param>
        /// <param name="defaultValue">The default value</param>
        public static int InRange(this int value, int minValue, int maxValue, int defaultValue)
        {
            return (int) value.AsLong().InRange(minValue, maxValue, defaultValue);
        }

        /// <summary>
        /// A prime number (or a prime) is a natural number that has exactly two distinct natural number divisors: 1 and itself.
        /// </summary>
        /// <param name="candidate">Object value</param>
        /// <returns>Returns true if the value is a prime number.</returns>
        public static bool IsPrime(this int candidate)
        {
            return candidate.AsLong().IsPrime();
        }

        /// <summary>
        /// Converts the value to ordinal string. (English)
        /// </summary>
        /// <param name="i">Object value</param>
        /// <returns>Returns string containing ordinal indicator adjacent to a numeral denoting. (English)</returns>
        public static string ToOrdinal(this int i)
        {
            return i.AsLong().ToOrdinal();
        }

        /// <summary>
        /// Converts the value to ordinal string with specified format. (English)
        /// </summary>
        /// <param name="i">Object value</param>
        /// <param name="format">A standard or custom format string that is supported by the object to be formatted.</param>
        /// <returns>Returns string containing ordinal indicator adjacent to a numeral denoting. (English)</returns>
        public static string ToOrdinal(this int i, string format)
        {
            return i.AsLong().ToOrdinal(format);
        }

        /// <summary>
        /// Returns the integer as long.
        /// </summary>
        public static long AsLong(this int i)
        {
            return i;
        }

        /// <summary>
        /// To check whether an index is in the range of the given array.
        /// </summary>
        /// <param name="index">Index to check</param>
        /// <param name="arrayToCheck">Array where to check</param>
        /// <returns></returns>
        /// <remarks>
        /// 	Contributed by Mohammad Rahman, http://mohammad-rahman.blogspot.com/
        /// </remarks>
        public static bool IsIndexInArray(this int index, Array arrayToCheck)
        {
            return index.GetArrayInedx().InRange(arrayToCheck.GetLowerBound(0), arrayToCheck.GetUpperBound(0));
        }

        /// <summary>
        /// To get Array index from a given based on a number.
        /// </summary>
        /// <param name="at">Real world postion </param>
        /// <returns></returns>
        /// <remarks>
        /// 	Contributed by Mohammad Rahman, http://mohammad-rahman.blogspot.com/
        /// </remarks>
        public static int GetArrayInedx(this int at)
        {
            return at == 0 ? 0 : at - 1;
        }
    }
}
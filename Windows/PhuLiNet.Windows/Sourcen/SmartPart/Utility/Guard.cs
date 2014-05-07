using System;
using System.Globalization;

namespace Windows.Core.SmartPart.Utility
{
    /// <summary>
    /// Common guard clauses
    /// </summary>
    public static class Guard
    {
        /// <summary>
        /// Checks a string argument to ensure it isn't null or empty
        /// </summary>
        /// <param name="argumentValue">The argument value to check.</param>
        /// <param name="argumentName">The name of the argument.</param>
        public static void ArgumentNotNullOrEmptyString(string argumentValue, string argumentName)
        {
            ArgumentNotNull(argumentValue, argumentName);

            if (argumentValue.Length == 0)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture,
                    Localization.SmartPart.StringCannotBeEmpty, argumentName));
        }

        /// <summary>
        /// Checks an argument to ensure it isn't null
        /// </summary>
        /// <param name="argumentValue">The argument value to check.</param>
        /// <param name="argumentName">The name of the argument.</param>
        public static void ArgumentNotNull(object argumentValue, string argumentName)
        {
            if (argumentValue == null)
                throw new ArgumentNullException(argumentName);
        }

        /// <summary>
        /// Checks an Enum argument to ensure that its value is defined by the specified Enum type.
        /// </summary>
        /// <param name="enumType">The Enum type the value should correspond to.</param>
        /// <param name="value">The value to check for.</param>
        /// <param name="argumentName">The name of the argument holding the value.</param>
        public static void EnumValueIsDefined(Type enumType, object value, string argumentName)
        {
            if (Enum.IsDefined(enumType, value) == false)
                throw new ArgumentException(String.Format(CultureInfo.CurrentCulture,
                    Localization.SmartPart.InvalidEnumValue,
                    argumentName, enumType.ToString()));
        }

        /// <summary>
        /// Verifies that an argument type is assignable from the provided type (meaning
        /// interfaces are implemented, or classes exist in the base class hierarchy).
        /// </summary>
        /// <param name="assignee">The argument type.</param>
        /// <param name="providedType">The type it must be assignable from.</param>
        /// <param name="argumentName">The argument name.</param>
        public static void TypeIsAssignableFromType(Type assignee, Type providedType, string argumentName)
        {
            if (!providedType.IsAssignableFrom(assignee))
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture,
                    Localization.SmartPart.TypeNotCompatible, assignee, providedType), argumentName);
        }
    }
}
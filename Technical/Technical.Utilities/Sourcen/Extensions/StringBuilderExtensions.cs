using System;
using System.Text;

namespace Technical.Utilities.Extensions
{
    /// <summary>
    /// Extensions for StringBuilder
    /// </summary>
    public static class StringBuilderExtensions
    {
        /// <summary>
        /// AppendLine version with format string parameters.
        /// </summary>
        public static void AppendLine(this StringBuilder builder, string value, params Object[] parameters)
        {
            builder.AppendLine(string.Format(value, parameters));
        }
    }
}
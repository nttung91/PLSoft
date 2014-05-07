using System;
using System.Runtime.Serialization;

namespace Technical.Settings
{
    /// <summary>
    /// Occurs when on setting errors
    /// </summary>
    [Serializable]
    public class SettingException : ApplicationException
    {
        public SettingException()
        {
        }

        public SettingException(string message) : base(message)
        {
        }

        public SettingException(string message, Exception inner) : base(message, inner)
        {
        }

        protected SettingException(SerializationInfo info,
            StreamingContext context)
            : base(info, context)
        {
        }
    }
}
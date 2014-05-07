using System;
using System.Runtime.Serialization;
using Technical.Utilities.Exceptions;

namespace Windows.Core.HelpProvider
{
    [Serializable]
    public class HelpProviderSettingsException : PhuLiException
    {
        public HelpProviderSettingsException()
        {
        }

        public HelpProviderSettingsException(string message, params object[] messageArguments)
            : base(string.Format(message, messageArguments))
        {
        }

        public HelpProviderSettingsException(string message, Exception inner) : base(message, inner)
        {
        }

        protected HelpProviderSettingsException(SerializationInfo info,
            StreamingContext context)
            : base(info, context)
        {
        }
    }
}
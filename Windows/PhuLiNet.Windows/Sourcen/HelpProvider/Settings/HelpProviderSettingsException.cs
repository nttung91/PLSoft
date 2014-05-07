using System;
using System.Runtime.Serialization;
using Technical.Utilities.Exceptions;

namespace Windows.Core.HelpProvider.Settings
{
    [Serializable]
    public class HelpProviderException : PhuLiException
    {
        public HelpProviderException()
        {
        }

        public HelpProviderException(string message, params object[] messageArguments)
            : base(string.Format(message, messageArguments))
        {
        }

        public HelpProviderException(string message, Exception inner) : base(message, inner)
        {
        }

        protected HelpProviderException(SerializationInfo info,
            StreamingContext context)
            : base(info, context)
        {
        }
    }
}
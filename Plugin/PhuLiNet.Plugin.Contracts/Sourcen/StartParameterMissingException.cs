using System;
using System.Runtime.Serialization;

namespace PhuLiNet.Plugin.Contracts
{
    /// <summary>
    /// Missing start parameter on plugin execution
    /// </summary>
    [Serializable]
    public class StartParameterMissingException : ApplicationException
    {
        public StartParameterMissingException()
        {
        }

        public StartParameterMissingException(string message) : base(message)
        {
        }

        public StartParameterMissingException(string message, Exception inner) : base(message, inner)
        {
        }

        protected StartParameterMissingException(SerializationInfo info,
            StreamingContext context)
            : base(info, context)
        {
        }
    }
}
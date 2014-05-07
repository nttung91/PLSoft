using System;
using System.Runtime.Serialization;

namespace Technical.Utilities.Exceptions
{
    /// <summary>
    /// Exception base class for all specific exception types 
    /// </summary>
    [Serializable]
    public class PhuLiException : Exception
    {
        public PhuLiException()
        {
        }

        public PhuLiException(string message) : base(message)
        {
        }

        public PhuLiException(string message, Exception inner) : base(message, inner)
        {
        }

        protected PhuLiException(SerializationInfo info,
            StreamingContext context)
            : base(info, context)
        {
        }
    }
}
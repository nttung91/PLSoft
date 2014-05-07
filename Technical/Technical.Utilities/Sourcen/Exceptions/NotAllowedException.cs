using System;
using System.Runtime.Serialization;

namespace Technical.Utilities.Exceptions
{
    /// <summary>
    /// Occurs when an operation is not allowed
    /// </summary>
    [Serializable]
    public class NotAllowedException : PhuLiException
    {
        public NotAllowedException()
        {
        }

        public NotAllowedException(string message) : base(message)
        {
        }

        public NotAllowedException(string message, Exception inner) : base(message, inner)
        {
        }

        protected NotAllowedException(SerializationInfo info,
            StreamingContext context)
            : base(info, context)
        {
        }
    }
}
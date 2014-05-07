using System;
using System.Runtime.Serialization;

namespace Technical.Utilities.Exceptions
{
    /// <summary>
    /// Occurs when there is a concurrency problem
    /// </summary>
    [Serializable]
    public class ConcurrencyException : PhuLiException
    {
        public ConcurrencyException()
        {
        }

        public ConcurrencyException(string message) : base(message)
        {
        }

        public ConcurrencyException(string message, Exception inner) : base(message, inner)
        {
        }

        protected ConcurrencyException(SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }
    }
}
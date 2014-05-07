using System;

namespace Technical.Utilities.Extensions
{
    /// <summary>
    /// 	Generic exception for combining several other exceptions
    /// </summary>
    public class CombinedException : Exception
    {
        /// <summary>
        /// 	Initializes a new instance of the <see cref = "CombinedException" /> class.
        /// </summary>
        /// <param name = "message">The message.</param>
        /// <param name = "innerExceptions">The inner exceptions.</param>
        public CombinedException(string message, Exception[] innerExceptions) : base(message)
        {
            InnerExceptions = innerExceptions;
        }

        /// <summary>
        /// 	Gets the inner exceptions.
        /// </summary>
        /// <value>The inner exceptions.</value>
        public Exception[] InnerExceptions { get; protected set; }
    }
}
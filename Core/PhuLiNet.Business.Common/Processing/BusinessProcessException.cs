using System;
using System.Runtime.Serialization;

namespace PhuLiNet.Business.Common.Processing
{
    /// <summary>
    /// Occurs on error in business process
    /// </summary>
    [Serializable]
    public class BusinessProcessException : ApplicationException
    {
        public BusinessProcessException()
        {
        }

        public BusinessProcessException(string message) : base(message)
        {
        }

        public BusinessProcessException(string message, Exception inner) : base(message, inner)
        {
        }

        protected BusinessProcessException(SerializationInfo info,
            StreamingContext context)
            : base(info, context)
        {
        }
    }
}
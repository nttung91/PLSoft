using System;
using System.Runtime.Serialization;

namespace Technical.Utilities.Exceptions
{
    /// <summary>
    /// Occurs on error in MUSIC reporting system
    /// </summary>
    [Serializable]
    public class MusicException : PhuLiException
    {
        public MusicException()
        {
        }

        public MusicException(string message) : base(message)
        {
        }

        public MusicException(string message, Exception inner) : base(message, inner)
        {
        }

        protected MusicException(SerializationInfo info,
            StreamingContext context)
            : base(info, context)
        {
        }
    }
}
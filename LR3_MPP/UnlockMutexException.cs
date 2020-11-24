using System;
using System.Runtime.Serialization;

namespace LR3_MPP
{
    public class UnlockMutexException : Exception
    {
        public UnlockMutexException()
        {
        }

        public UnlockMutexException(string message) : base(message)
        {
        }

        public UnlockMutexException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected UnlockMutexException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}

using System;

namespace SignUpSystem.QueueInfrastructure.AbstractSender
{
    public class QueueSenderException : Exception
    {
        public QueueSenderException()
        {
        }

        public QueueSenderException(string message) : base(message)
        {
        }

        public QueueSenderException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}

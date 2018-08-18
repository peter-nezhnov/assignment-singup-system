﻿using System;
using Newtonsoft.Json;

namespace SignUpSystem.QueueInfrastructure.Manager
{
    internal interface IMessageSerializer
    {
        string SerializerMessage(AbstractQueueMessage message);
    }

    /// <summary>
    /// Can be as well in BusSender Implementation. Depends which part dictates rules for serialization.
    /// </summary>
    class MessageSerializer : IMessageSerializer
    {
        public string SerializerMessage(AbstractQueueMessage message)
        {
            if (message == null)
                throw new ArgumentException("Message was not provided");

            return JsonConvert.SerializeObject(message);
        }
    }
}

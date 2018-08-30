using System;

namespace SignUpSystem.QueueInfrastructure.Manager
{
    public abstract class AbstractQueueMessage
    {
        Guid TrackableId { get; set; }
    }

    public class SignUpMessage : AbstractQueueMessage
    {
        
    }
}

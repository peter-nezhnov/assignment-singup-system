namespace SignUpSystem.QueueInfrastructure.Manager
{
    public class QueueManagerSettings
    {
        public QueueManagerSettings(string singUpQueueName)
        {
            SingUpQueueName = singUpQueueName;
        }

        public readonly string SingUpQueueName;
    }
}

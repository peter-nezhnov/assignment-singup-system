namespace SignUpSystem.QueueInfrastructure.Manager
{
    public class QueueManagerSettings
    {
        public QueueManagerSettings(string singUpQueueName, string connectionString)
        {
            SingUpQueueName = singUpQueueName;
            ConnectionString = connectionString;
        }

        public readonly string SingUpQueueName;
        public readonly string ConnectionString;
    }
}

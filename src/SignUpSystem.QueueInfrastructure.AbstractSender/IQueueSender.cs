using System.Threading.Tasks;

namespace SignUpSystem.QueueInfrastructure.AbstractSender
{
    public interface IQueueSender
    {
        Task SendMessageAsync(string queueName, string message);
    }
}

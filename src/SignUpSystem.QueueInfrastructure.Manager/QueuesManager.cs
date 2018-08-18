using System.Threading.Tasks;
using SignUpSystem.QueueInfrastructure.AbstractSender;

namespace SignUpSystem.QueueInfrastructure.Manager
{
    internal interface IQueuesManager
    {
        Task SendSignUpMessageAsync(SignUpMessage message);
    }

    class QueuesManager : IQueuesManager
    {
        private readonly IQueueSender _queueSender;
        private readonly IMessageSerializer _messageSerializer;
        private readonly QueueManagerSettings _settings;

        public QueuesManager(IQueueSender queueSender, IMessageSerializer messageSerializer, QueueManagerSettings settings)
        {
            _queueSender = queueSender;
            _messageSerializer = messageSerializer;
            _settings = settings;
        }

        public async Task SendSignUpMessageAsync(SignUpMessage message)
        {
            var serialized = _messageSerializer.SerializerMessage(message);

            await _queueSender.SendMessageAsync(_settings.SingUpQueueName, serialized);
        }
    }
}

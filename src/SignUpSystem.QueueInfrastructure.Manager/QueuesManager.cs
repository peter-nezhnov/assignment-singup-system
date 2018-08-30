using System.Threading.Tasks;
using SignUpSystem.Domain.Models.Commands;
using SignUpSystem.QueueInfrastructure.AbstractSender;

namespace SignUpSystem.QueueInfrastructure.Manager
{
    public interface IQueuesManager
    {
        Task SendSignUpCommandAsync(SignUpCommand command);
    }

    class QueuesManager : IQueuesManager
    {
        private readonly IQueueSender _queueSender;
        private readonly ICommandsSerializer _commandsSerializer;
        private readonly QueueManagerSettings _settings;

        public QueuesManager(IQueueSender queueSender, ICommandsSerializer commandsSerializer, QueueManagerSettings settings)
        {
            _queueSender = queueSender;
            _commandsSerializer = commandsSerializer;
            _settings = settings;
        }

        public async Task SendSignUpCommandAsync(SignUpCommand command)
        {
            var serialized = _commandsSerializer.SerializerMessage(command);

            await _queueSender.SendMessageAsync(_settings.SingUpQueueName, serialized);
        }
    }
}

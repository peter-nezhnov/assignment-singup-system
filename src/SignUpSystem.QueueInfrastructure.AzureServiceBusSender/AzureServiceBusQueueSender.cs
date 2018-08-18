using System;
using System.Threading.Tasks;
using SignUpSystem.QueueInfrastructure.AbstractSender;

namespace SignUpSystem.QueueInfrastructure.AzureServiceBusSender
{
    internal class AzureServiceBusQueueSender : IQueueSender
    {
        private readonly string _connectionsString;

        public AzureServiceBusQueueSender(string connectionsString)
        {
            _connectionsString = connectionsString;
        }

        public async Task SendMessageAsync(string queueName, string message)
        {
            try
            {
                //TODO use Azure SDK
                await Task.CompletedTask;
            }
            catch (Exception anyException)
            {
                //TODO log here
                throw new QueueSenderException("Was not able to send message", anyException);
            }
            
        }
    }
}

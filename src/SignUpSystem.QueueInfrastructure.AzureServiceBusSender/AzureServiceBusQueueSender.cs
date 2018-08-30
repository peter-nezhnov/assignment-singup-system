using System;
using System.Threading.Tasks;
using Microsoft.Azure.ServiceBus;
using SignUpSystem.QueueInfrastructure.AbstractSender;

namespace SignUpSystem.QueueInfrastructure.AzureServiceBusAdapter
{
    internal class AzureServiceBusQueueSender : IQueueSender
    {
        private readonly QueueClient _queueClient;

        public AzureServiceBusQueueSender(string connectionsString)
        {
            _queueClient 
                = new QueueClient(
                    new ServiceBusConnectionStringBuilder(connectionsString), 
                    ReceiveMode.PeekLock //default value but giid to be explicti
                );
        }

        public async Task SendMessageAsync(string queueName, string message)
        {
            try
            {
                byte[] messageBody = System.Text.Encoding.Unicode.GetBytes(message);
                
                await _queueClient.SendAsync(new Message(messageBody));
            }
            catch (Exception anyException)
            {
                throw new QueueSenderException("Was not able to send message", anyException);
            }
            
        }
    }
}

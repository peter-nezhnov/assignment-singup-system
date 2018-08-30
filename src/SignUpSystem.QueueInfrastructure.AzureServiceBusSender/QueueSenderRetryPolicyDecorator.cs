using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Polly;
using SignUpSystem.QueueInfrastructure.AbstractSender;

namespace SignUpSystem.QueueInfrastructure.AzureServiceBusAdapter
{
    /// <summary>
    /// For now it lives here. If we have more than 1 implemetation it will be moved out from project with specific implementation.
    /// Can be applied on any <see cref="IQueueSender"/> class
    /// </summary>
    internal class QueueSenderRetryPolicyDecorator : IQueueSender
    {
        private readonly IQueueSender _queueSender;
        private readonly ILogger<QueueSenderRetryPolicyDecorator> _logger;

        //Can be moved to settings. But I am in hurry. 
        private const int MaxWaitingTimeBetweenErrorsInSeconds = 10;
        private const int MaxNumberOfAttempts = 10;

        public QueueSenderRetryPolicyDecorator(IQueueSender queueSender, ILogger<QueueSenderRetryPolicyDecorator> logger)
        {
            _queueSender = queueSender;
            _logger = logger;
        }

        public async Task SendMessageAsync(string queueName, string message)
        {
            try
            {
                await Policy
                    .Handle<QueueSenderException>()
                    .WaitAndRetryAsync(MaxNumberOfAttempts, i => TimeSpan.FromSeconds(Math.Min(MaxWaitingTimeBetweenErrorsInSeconds, i * i)), (ex, delay) =>
                    {
                        _logger.LogError($"Failed to send message {message}", ex);
                    })
                    .ExecuteAsync(async ctx => await _queueSender.SendMessageAsync(queueName, message), new CancellationToken());
            }
            //catch only exceptions that can appear in retry policy use. Other will be propagated up without additional logging
            catch (Exception ex) when (!(ex is QueueSenderException))
            {
                _logger.LogError("Retry policy logic failed during execution");
                throw;
            }
            
        }
    }
}
using System;
using Autofac;
using SignUpSystem.QueueInfrastructure.AbstractSender;

namespace SignUpSystem.QueueInfrastructure.AzureServiceBusAdapter
{
    public class AzureServiceBusModule : Module
    {
        public string ConnectionString { get; set; }

        protected override void Load(ContainerBuilder builder)
        {
            if (string.IsNullOrEmpty(ConnectionString))
                throw new ApplicationException($"Can't instantiate {nameof(AzureServiceBusModule)}");

            builder.RegisterType<AzureServiceBusQueueSender>()
                .WithParameter("queueConnectionString", ConnectionString)
                .Named<IQueueSender>("queueSender")
                .SingleInstance();

            builder.RegisterType<QueueSenderRetryPolicyDecorator>()
                .Named<IQueueSender>("queueSenderPolicyDecorator");

            builder.RegisterDecorator<IQueueSender>((c, inner) => c.ResolveNamed<IQueueSender>("queueSenderPolicyDecorator", TypedParameter.From(inner)), "queueSender")
                .As<IQueueSender>();
        }
    }
}

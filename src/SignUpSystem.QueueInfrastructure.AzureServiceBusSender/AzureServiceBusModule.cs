using System;
using Autofac;
using SignUpSystem.QueueInfrastructure.AbstractSender;

namespace SignUpSystem.QueueInfrastructure.AzureServiceBusSender
{
    public class AzureServiceBusModule : Module
    {
        public string ConnectionString { get; set; }

        protected override void Load(ContainerBuilder builder)
        {
            //should be more restrictive
            if (string.IsNullOrEmpty(ConnectionString))
                throw new ApplicationException($"Can't instantiate {nameof(AzureServiceBusModule)}");

            builder.RegisterType<AzureServiceBusQueueSender>()
                .WithParameter("connectionsString", ConnectionString) //Hardcoded parameter name. Can be changed to nameof() or wrapped in object
                .As<IQueueSender>()
                .SingleInstance();
        }
    }
}

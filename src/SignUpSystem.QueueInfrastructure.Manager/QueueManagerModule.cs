using System;
using Autofac;
using SignUpSystem.QueueInfrastructure.AzureServiceBusSender;
using SignUpSystem.QueueInfrastructure.AbstractSender;

namespace SignUpSystem.QueueInfrastructure.Manager
{
    public class QueueManagerModule : Module
    {
        public QueueManagerSettings Settings { get; set; }

        protected override void Load(ContainerBuilder builder)
        {
            //should be more restrictive
            if(Settings == null)
                throw new ApplicationException($"Can't instantiate {nameof(QueueManagerModule)}");

            builder.RegisterType<AzureServiceBusQueueSender>()
                .WithParameter("connectionsString", Settings.ConnectionString) //Hardcoded parameter name. Can be changed to nameof() or wrapped in object
                .As<IQueueSender>()
                .SingleInstance();

            builder.RegisterType<MessageSerializer>().As<IMessageSerializer>().SingleInstance();
            builder.RegisterType<QueuesManager>().As<IQueuesManager>();
        }
    }
}

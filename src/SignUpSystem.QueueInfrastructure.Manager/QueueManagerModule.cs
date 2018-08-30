using System;
using Autofac;

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

            builder.RegisterType<CommandsSerializer>().As<ICommandsSerializer>().SingleInstance();
            builder.RegisterType<QueuesManager>().As<IQueuesManager>()
                .WithParameter("settings", Settings);
        }
    }
}

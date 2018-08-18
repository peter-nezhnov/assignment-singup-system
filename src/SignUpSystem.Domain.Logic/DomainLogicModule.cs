using System;
using Autofac;
using SignUpSystem.QueueInfrastructure.Manager;

namespace SignUpSystem.Domain.Logic
{

    public class DomainLogicModule : Module
    {
        public QueueManagerSettings QueueManagerSettings { get; set; }

        protected override void Load(ContainerBuilder builder)
        {
            if (QueueManagerSettings == null)
                throw new ApplicationException($"Can't instantiate {nameof(DomainLogicModule)}");

            builder.RegisterModule(new DomainLogicModule
            {
                QueueManagerSettings = QueueManagerSettings
            });

            //register DataAccessModule here

            builder.RegisterType<SignUpManager>().As<ISignUpManager>();
        }
    }
}


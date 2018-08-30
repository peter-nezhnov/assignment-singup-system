using Autofac;
using SignUpSystem.Domain.Logic.Services;
using SignUpSystem.Domain.Logic.Services.Implementations;

namespace SignUpSystem.Domain.Logic
{

    public class DomainLogicModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<SyncSignUpService>().Keyed<ISignUpService>(SignUpServiceType.Sync);
            builder.RegisterType<AsyncSignUpService>().Keyed<ISignUpService>(SignUpServiceType.Async);
            builder.RegisterType<CommandsFactory>().As<ICommandsFactory>();
        }
    }
}


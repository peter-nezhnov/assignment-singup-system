using Autofac;
using SignUpSystem.Domain.Logic.Services;

namespace SignUpSystem.Domain.Logic
{

    public class DomainLogicModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<SignUpService>().As<ISignUpService>();
        }
    }
}


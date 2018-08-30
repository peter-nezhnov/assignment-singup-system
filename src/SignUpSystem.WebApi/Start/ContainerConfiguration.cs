using Autofac;
using SignUpSystem.Domain.Logic;
using SignUpSystem.QueueInfrastructure.AzureServiceBusAdapter;
using SignUpSystem.QueueInfrastructure.Manager;

namespace SignUpSystem.WebApi.Start
{
    public static class ContainerConfiguration
    {
        public static void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterModule<DomainLogicModule>();
            builder.RegisterModule(new QueueManagerModule
            {
                Settings = new QueueManagerSettings("populate", "fron config")
            });
            builder.RegisterModule(new AzureServiceBusModule
            {
                ConnectionString = "from config"
            });
        }
    }
}

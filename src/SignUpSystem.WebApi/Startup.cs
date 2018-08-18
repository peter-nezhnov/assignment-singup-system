using System;
using System.Collections.Generic;
using System.Linq;
using Autofac;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SignUpSystem.Domain.Logic;
using SignUpSystem.QueueInfrastructure.AzureServiceBusSender;
using SignUpSystem.QueueInfrastructure.Manager;

namespace SignUpSystem.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            var builder = new ConfigurationBuilder()
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        public void ConfigureContainer(ContainerBuilder builder)
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

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}

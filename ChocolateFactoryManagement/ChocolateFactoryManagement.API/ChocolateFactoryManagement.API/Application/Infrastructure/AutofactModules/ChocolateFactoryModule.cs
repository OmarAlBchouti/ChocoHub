using Autofac;
using ChocolateFactoryManagement.Services.Infrastructure.AutofactModules;

namespace ChocolateFactoryManagement.API.Application.Infrastructure.AutofactModules
{
    public class ChocolateFactoryModule : Autofac.Module
    {
        public ChocolateFactoryModule() { }

        protected override void Load(ContainerBuilder builder)
        {
            ChocolateFactoryServicesModules.RegisterModules(builder);
        }
    }
}

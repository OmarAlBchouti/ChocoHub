using Autofac;
using ChocolateFactoryManagement.Services.Services;

namespace ChocolateFactoryManagement.Services.Infrastructure.AutofactModules
{
    public static class ChocolateFactoryServicesModules
    {
        public static void RegisterModules(ContainerBuilder builder)
        {
            builder.RegisterType<FactoryService>().As<IFactoryService>().InstancePerLifetimeScope();
            builder.RegisterType<WholesalerService>().As<IWholesalerService>().InstancePerLifetimeScope();
        }
    }
}

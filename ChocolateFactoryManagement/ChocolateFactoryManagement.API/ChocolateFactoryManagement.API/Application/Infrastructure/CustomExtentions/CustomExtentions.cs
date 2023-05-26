using ChocolateFactoryManagement.Domain.AutoMapper;
using ChocolateFactoryManagement.Infrastructure.DbContext;
using ChocolateFactoryManagement.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using static ChocolateFactoryManagement.Domain.AutoMapper.AutoMapperClasses;

namespace ChocolateFactoryManagement.API.Application.Infrastructure.CustomExtentions
{
    public static class CustomExtentions
    {
        public static IServiceCollection AddDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IChocolateBarRepository, ChocolateBarRepository>();
            services.AddScoped<IFactoryRepository, FactoryRepository>();
            services.AddScoped<IWholesalerRepository, WholesalerRepository>();

            services.AddDbContext<ChocolateFactoryDbContext>(options =>
                  options.UseSqlServer(configuration.GetConnectionString("ChocolateDb")));
            return services;
        }

        public static IServiceCollection AddAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(AutoMapperClasses));
            return services;
        }
    }
}

using ChocolateFactoryManagement.Infrastructure.DbContext;
using Microsoft.EntityFrameworkCore;

namespace ChocolateFactoryManagement.API.Application.Infrastructure.CustomExtentions
{
    public static class CustomExtentions
    {
        public static IServiceCollection AddDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ChocolateFactoryDbContext>(options =>
                  options.UseSqlServer(configuration.GetConnectionString("ChocolateDb")));
            return services;
        }
    }
}

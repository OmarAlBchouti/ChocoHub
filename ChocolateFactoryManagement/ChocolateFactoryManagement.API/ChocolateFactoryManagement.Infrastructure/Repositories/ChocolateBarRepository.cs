using ChocolateFactoryManagement.Domain.Models;
using ChocolateFactoryManagement.Infrastructure.DbContext;
using Microsoft.EntityFrameworkCore;

namespace ChocolateFactoryManagement.Infrastructure.Repositories
{
    public interface IChocolateBarRepository
    {
        Task<ChocolateBar> GetChocolateBar(int factoryId, int chocolateBarId);
        Task<ChocolateBar> GetChocolateBarById(int chocolateBarId);
        Task DeleteChocolateBar(ChocolateBar chocolateBar);
    }
    public class ChocolateBarRepository : IChocolateBarRepository
    {
        private readonly ChocolateFactoryDbContext _chocolateFactoryDbContext;
        public ChocolateBarRepository(ChocolateFactoryDbContext context)
        {
            _chocolateFactoryDbContext = context;
        }

        public async Task<ChocolateBar> GetChocolateBar(int factoryId, int chocolateBarId)
        {
            return await _chocolateFactoryDbContext.ChocolateBars.FirstOrDefaultAsync(x => x.Id == chocolateBarId && x.FactoryId == factoryId);
        }

        public async Task<ChocolateBar> GetChocolateBarById(int chocolateBarId)
        {
            return await _chocolateFactoryDbContext.ChocolateBars.FirstOrDefaultAsync(x => x.Id == chocolateBarId);
        }

        public async Task DeleteChocolateBar(ChocolateBar chocolateBar)
        {
            _chocolateFactoryDbContext.Set<ChocolateBar>().Remove(chocolateBar);
            await _chocolateFactoryDbContext.SaveChangesAsync();
        }
    }
}

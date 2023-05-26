using ChocolateFactoryManagement.Domain.Models;
using ChocolateFactoryManagement.Infrastructure.DbContext;
using Microsoft.EntityFrameworkCore;

namespace ChocolateFactoryManagement.Infrastructure.Repositories
{
    public interface IFactoryRepository
    {
        Task<IEnumerable<Factory>> GetAllFactories();
        Task<Factory> GetFactoryById(int Id);
        Task UpdateFactory(Factory factory);
        Task DeleteChocolateBarFromFactory(ChocolateBar chocolateBar);
    }

    public class FactoryRepository : IFactoryRepository
    {
        private readonly ChocolateFactoryDbContext _chocolateFactoryDbContext;
        public FactoryRepository(ChocolateFactoryDbContext context)
        {
            _chocolateFactoryDbContext = context;
        }

        public async Task<IEnumerable<Factory>> GetAllFactories()
        {
            return await _chocolateFactoryDbContext.Factories.Include(x => x.ChocolateBars).ToArrayAsync();
        }

        public async Task<Factory> GetFactoryById(int factoryId)
        {
            return await _chocolateFactoryDbContext.Factories.Where(x => x.Id == factoryId).FirstOrDefaultAsync();
        }

        public async Task UpdateFactory(Factory factory)
        {
            _chocolateFactoryDbContext.Factories.Update(factory);
            await _chocolateFactoryDbContext.SaveChangesAsync();
        }

        public async Task DeleteChocolateBarFromFactory(ChocolateBar chocolateBar)
        {
            _chocolateFactoryDbContext.Set<ChocolateBar>().Remove(chocolateBar);
            await _chocolateFactoryDbContext.SaveChangesAsync();
        }
    }
}

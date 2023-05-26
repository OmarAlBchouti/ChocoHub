using ChocolateFactoryManagement.Domain.Models;
using ChocolateFactoryManagement.Infrastructure.DbContext;
using Microsoft.EntityFrameworkCore;

namespace ChocolateFactoryManagement.Infrastructure.Repositories
{
    public interface IWholesalerRepository
    {
        Task<Wholesaler> GetWholesalerById(int wholesalerId);
        Task<WholesalerStock> GetWholesalerStock(int wholesalerId, int chocolateBarId);
        Task AddStock(WholesalerStock wholesalerStock);
        Task UpdateWholesalerStock(WholesalerStock wholesalerStock);
    }

    public class WholesalerRepository : IWholesalerRepository
    {
        private readonly ChocolateFactoryDbContext _chocolateFactoryDbContext;
        public WholesalerRepository(ChocolateFactoryDbContext context)
        {
            _chocolateFactoryDbContext = context;
        }

        public async Task<Wholesaler> GetWholesalerById(int wholesalerId)
        {
            return await _chocolateFactoryDbContext.Wholesalers.FirstOrDefaultAsync(s => s.Id == wholesalerId);
        }

        public async Task<WholesalerStock> GetWholesalerStock(int wholesalerId, int chocolateBarId)
        {
            return await _chocolateFactoryDbContext.WholesalerStocks.FirstOrDefaultAsync(s => s.WholesalerId == wholesalerId && s.ChocolateBarId == chocolateBarId);
        }

        public async Task AddStock(WholesalerStock wholesalerStock)
        {
            try
            {
                _chocolateFactoryDbContext.WholesalerStocks.Add(wholesalerStock);
                await _chocolateFactoryDbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                var t = "";
            }
        }

        public async Task UpdateWholesalerStock(WholesalerStock wholesalerStock)
        {
            _chocolateFactoryDbContext.WholesalerStocks.Update(wholesalerStock);
            await _chocolateFactoryDbContext.SaveChangesAsync();
        }
    }
}

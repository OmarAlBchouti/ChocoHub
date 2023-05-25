using ChocolateFactoryManagement.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace ChocolateFactoryManagement.Infrastructure.DbContext
{
    public class ChocolateFactoryDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public ChocolateFactoryDbContext(DbContextOptions<ChocolateFactoryDbContext> options)
        : base(options)
        {
        }

        public virtual DbSet<ChocolateBar> ChocolateBars { get; set; }
        public virtual DbSet<Factory> Factories { get; set; }
        public virtual DbSet<Wholesaler> Wholesalers { get; set; }
        public virtual DbSet<WholesalerStock> WholesalerStocks { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);


            builder.ApplyConfiguration(new ChocolateBarConfiguration());
            builder.ApplyConfiguration(new FactoryConfiguration());
            builder.ApplyConfiguration(new WholesalerConfiguration());
            builder.ApplyConfiguration(new WholesalerStockConfiguration());
        }
    }
}

using ChocolateFactoryManagement.Domain.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChocolateFactoryManagement.Infrastructure.DbContext
{
    public class WholesalerStockConfiguration : IEntityTypeConfiguration<WholesalerStock>
    {
        public void Configure(EntityTypeBuilder<WholesalerStock> entity)
        {
            entity.HasKey(x => new { x.WholesalerId, x.ChocolateBarId });

            entity.Property(x => x.Quantity);

            entity.HasOne(x => x.Wholesaler)
              .WithMany(x => x.WholesalerStocks)
              .HasForeignKey(x => x.WholesalerId)
              .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(x => x.ChocolateBar)
                .WithMany(x => x.WholesalerStocks)
                .HasForeignKey(x => x.ChocolateBarId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}

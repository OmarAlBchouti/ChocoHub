using ChocolateFactoryManagement.Domain.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace ChocolateFactoryManagement.Infrastructure.DbContext
{
    public class WholesalerConfiguration : IEntityTypeConfiguration<Wholesaler>
    {
        public void Configure(EntityTypeBuilder<Wholesaler> entity)
        {
            entity.Property(x => x.Id).ValueGeneratedOnAdd();
        }
    }
}

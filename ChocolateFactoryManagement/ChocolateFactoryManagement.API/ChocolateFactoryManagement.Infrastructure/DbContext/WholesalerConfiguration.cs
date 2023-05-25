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
    public class WholesalerConfiguration : IEntityTypeConfiguration<Wholesaler>
    {
        public void Configure(EntityTypeBuilder<Wholesaler> entity)
        {
            entity.Property(x => x.Id).ValueGeneratedOnAdd();
        }
    }
}

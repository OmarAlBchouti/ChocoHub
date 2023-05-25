using ChocolateFactoryManagement.Domain.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography.X509Certificates;
using System.Reflection.Emit;

namespace ChocolateFactoryManagement.Infrastructure.DbContext
{
    public class ChocolateBarConfiguration : IEntityTypeConfiguration<ChocolateBar>
    {
        public void Configure(EntityTypeBuilder<ChocolateBar> entity)
        {
            entity.Property(x => x.Id).ValueGeneratedOnAdd();
            entity.Property(c => c.Price).HasColumnType("decimal(18,2)").HasConversion<double>();

            entity.HasOne(x => x.Factory)
                .WithMany(x => x.ChocolateBars)
                .HasForeignKey(x => x.FactoryId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

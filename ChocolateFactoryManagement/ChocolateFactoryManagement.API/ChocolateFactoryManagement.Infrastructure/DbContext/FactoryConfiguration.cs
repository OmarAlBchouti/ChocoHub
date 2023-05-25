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
    public class FactoryConfiguration : IEntityTypeConfiguration<Factory>
    {
        public void Configure(EntityTypeBuilder<Factory> entity)
        {
            entity.Property(x => x.Id).ValueGeneratedOnAdd();
        }
    }
}

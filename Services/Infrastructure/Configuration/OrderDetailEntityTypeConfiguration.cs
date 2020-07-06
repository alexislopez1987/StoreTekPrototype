using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreTekPrototype.Services.Infrastructure.Configuration
{
    internal class OrderDetailEntityTypeConfiguration : IEntityTypeConfiguration<Models.OrderDetail>
    {
        public void Configure(EntityTypeBuilder<Models.OrderDetail> builder)
        {
            builder.HasKey(o => o.Id);
            builder.Property(o => o.OrderId).IsRequired();
            builder.Property(o => o.ProductId).IsRequired();
            builder.Property(o => o.Quantity).IsRequired();
            builder.Property(o => o.Price).IsRequired();
        }
    }
}

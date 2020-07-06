using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreTekPrototype.Services.Infrastructure.Configuration
{
    internal class OrderEntityTypeConfiguration : IEntityTypeConfiguration<Models.Order>
    {
        public void Configure(EntityTypeBuilder<Models.Order> builder)
        {
            //builder.ToTable("Orders");
            builder.HasKey(o => o.Id);
            builder.Property(o => o.CreatedDate).IsRequired();
            builder.Property(o => o.CustomerId).IsRequired();

            builder.Metadata.FindNavigation(nameof(Models.Order.Details)).SetPropertyAccessMode(PropertyAccessMode.Field);
            builder.HasMany(o => o.Details).WithOne(b => b.Order).HasForeignKey(b => b.OrderId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

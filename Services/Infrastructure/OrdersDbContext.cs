using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models = StoreTekPrototype.Services.Models;

namespace StoreTekPrototype.Services.Infrastructure
{
    public class OrdersDbContext : DbContext
    {
        public OrdersDbContext(DbContextOptions<OrdersDbContext> options): base(options)
        { }
        public DbSet<Models.Order> Orders { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new OrderEntityTypeConfiguration());
        }
    }
    public class OrderEntityTypeConfiguration : IEntityTypeConfiguration<Models.Order>
    {
        public void Configure(EntityTypeBuilder<Models.Order> builder)
        {
            //builder.ToTable("Orders");
            builder.HasKey(o => o.Id);
            //builder.Property(o => o.CustomerName).HasMaxLength(255).IsRequired();
            builder.Property(o => o.CreatedDate).IsRequired();
            builder.Property(o => o.CustomerId).IsRequired();
        }
    }
}

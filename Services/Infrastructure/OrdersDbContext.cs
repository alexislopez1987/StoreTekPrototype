using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StoreTekPrototype.Services.Infrastructure.Configuration;
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
        public DbSet<Models.OrderDetail> OrderDetails { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new OrderEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new OrderDetailEntityTypeConfiguration());
        }
    }
}

using StoreTekPrototype.Services.Infrastructure;
using Models = StoreTekPrototype.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreTekPrototype.Services.Order.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly OrdersDbContext _ordersDbContext;
        public OrderRepository(OrdersDbContext ordersDbContext)
        {
            _ordersDbContext = ordersDbContext;
        }
        public void CreateOrder(Models.Order order)
        {
            _ordersDbContext.Orders.Add(order);
            _ordersDbContext.SaveChanges();
        }
    }
}

using StoreTekPrototype.Services.Infrastructure;
using Models = StoreTekPrototype.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace StoreTekPrototype.Services.Order.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly OrdersDbContext _ordersDbContext;
        public OrderRepository(OrdersDbContext ordersDbContext)
        {
            _ordersDbContext = ordersDbContext;
        }
        async public Task CreateOrder(Models.Order order, IEnumerable<Models.OrderDetail> details)
        {
            _ordersDbContext.Orders.Add(order);
            _ordersDbContext.OrderDetails.AddRange(details);
            await _ordersDbContext.SaveChangesAsync();
        }
        async public Task<List<Models.Order>> GetOrderByCustomer(Guid customerId)
        {
            var orders = await _ordersDbContext.Orders.Include(o => o.Details).Where(o => o.CustomerId == customerId).ToListAsync();
            return orders;
        }
    }
}

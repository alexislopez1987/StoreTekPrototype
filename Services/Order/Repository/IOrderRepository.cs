using Models = StoreTekPrototype.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreTekPrototype.Services.Order.Repository
{
    public interface IOrderRepository
    {
        Task CreateOrder(Models.Order order, IEnumerable<Models.OrderDetail> details);
        Task<List<Models.Order>> GetOrderByCustomer(Guid customerId);
        Task<List<Models.Order>> GetOrders();
    }
}

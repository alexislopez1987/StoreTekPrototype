using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreTekPrototype.Services.Order.Service
{
    public interface IOrderService
    {
        Task CreateOrder(Models.Order order, IEnumerable<Models.OrderDetail> details);
        Task<List<Models.Order>> GetOrderByCustomer(Guid customerId);
    }
}

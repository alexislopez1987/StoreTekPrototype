using StoreTekPrototype.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreTekPrototype.Services.Order.Repository
{
    public interface IOrderRepository
    {
        void CreateOrder(OrderDTO order);
    }
}

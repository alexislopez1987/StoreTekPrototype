using MassTransit;
using StoreTekPrototype.Services.EventContracts;
using StoreTekPrototype.Services.Order.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreTekPrototype.Services.Order.Service
{
    public class OrderService : IOrderService
    {
        readonly IPublishEndpoint _publishEndpoint;
        private readonly IOrderRepository _orderRepository;
        public OrderService(IOrderRepository orderRepository, IPublishEndpoint publishEndpoint)
        {
            _orderRepository = orderRepository;
            _publishEndpoint = publishEndpoint;
        }
        async public Task CreateOrder(Models.Order order, IEnumerable<Models.OrderDetail> details)
        {
            await _orderRepository.CreateOrder(order, details);

            await _publishEndpoint.Publish<OrderEntered>(new
            {
                Id = order.Id,
                CreatedDate = order.CreatedDate,
                CustomerId = order.CustomerId,
                CustomerName = order.CustomerName
            });
        }
        async public Task<List<Models.Order>> GetOrderByCustomer(Guid customerId)
        {
            return await _orderRepository.GetOrderByCustomer(customerId);
        }
    }
}

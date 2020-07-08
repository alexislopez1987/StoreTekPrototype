using MassTransit;
using Microsoft.Extensions.Logging;
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
        private readonly ILogger<Models.Order> _logger;
        public OrderService(IOrderRepository orderRepository, IPublishEndpoint publishEndpoint, ILogger<Models.Order> logger)
        {
            _orderRepository = orderRepository;
            _publishEndpoint = publishEndpoint;
            _logger = logger;
        }
        async public Task CreateOrder(Models.Order order, IEnumerable<Models.OrderDetail> details)
        {
            await _orderRepository.CreateOrder(order, details);

            _logger.LogInformation($"Order {order.Id} saved");

            await _publishEndpoint.Publish<OrderEntered>(new
            {
                Id = order.Id,
                CreatedDate = order.CreatedDate,
                CustomerId = order.CustomerId,
                CustomerName = order.CustomerName
            });

            _logger.LogInformation($"Event order created");
        }
        async public Task<List<Models.Order>> GetOrderByCustomer(Guid customerId)
        {
            return await _orderRepository.GetOrderByCustomer(customerId);
        }
        async public Task<List<Models.Order>> GetOrders()
        {
            return await _orderRepository.GetOrders();
        }
    }
}

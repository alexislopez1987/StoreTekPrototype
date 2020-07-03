using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StoreTekPrototype.Services.Order.DTO;
using StoreTekPrototype.Services.Order.Repository;
using Models = StoreTekPrototype.Services.Models;

namespace StoreTekPrototype.Services.Order.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly ILogger<OrderDTO> _logger;
        private readonly IOrderRepository _orderRepository;
        public OrderController(ILogger<OrderDTO> logger, IOrderRepository orderRepository)
        {
            _logger = logger;
            _orderRepository = orderRepository;
        }
        [HttpPost]
        async public Task CreateOrder(OrderDTO orderDTO)
        {
            var order = new Models.Order() 
            { 
                Id = orderDTO.Id,
                CustomerId = orderDTO.CustomerId,
                CustomerName = orderDTO.CustomerName,
                CreatedDate = orderDTO.CreatedDate
            };
            await _orderRepository.CreateOrder(order);
        }
    }
}

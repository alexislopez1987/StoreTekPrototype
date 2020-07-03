using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StoreTekPrototype.Services.Models;
using StoreTekPrototype.Services.Order.Repository;

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
        public void CreateOrder(OrderDTO order)
        {
            _orderRepository.CreateOrder(order);
        }
    }
}

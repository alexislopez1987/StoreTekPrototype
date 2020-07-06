using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StoreTekPrototype.Services.Order.DTO;
using StoreTekPrototype.Services.Order.Service;
using Models = StoreTekPrototype.Services.Models;

namespace StoreTekPrototype.Services.Order.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly ILogger<OrderDTO> _logger;
        
        public OrderController(ILogger<OrderDTO> logger, IOrderService orderService)
        {
            _logger = logger;
            _orderService = orderService;
        }
        [HttpPost]
        async public Task CreateOrder([FromBody] OrderDTO orderDTO)
        {
            if (orderDTO.Details != null && orderDTO.Details.Count() > 0)
                orderDTO.Details.ToList().ForEach(od => od.OrderId = orderDTO.Id);

            var order = new Models.Order() 
            { 
                Id = orderDTO.Id,
                CustomerId = orderDTO.CustomerId,
                CustomerName = orderDTO.CustomerName,
                CreatedDate = orderDTO.CreatedDate
            };

            await _orderService.CreateOrder(order);
        }
    }
}

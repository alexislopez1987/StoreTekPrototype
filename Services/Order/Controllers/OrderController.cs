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
            try
            {
                if (orderDTO.Details != null && orderDTO.Details.Count() > 0)
                    orderDTO.Details.ToList().ForEach(od => od.OrderId = orderDTO.Id);

                var order = new Models.Order()
                {
                    Id = orderDTO.Id,
                    CustomerId = orderDTO.CustomerId,
                    CustomerName = orderDTO.CustomerName,
                    CreatedDate = orderDTO.CreatedDate,
                };

                var details = new List<Models.OrderDetail>();
                foreach (var detail in orderDTO.Details)
                {
                    var newDetail = new Models.OrderDetail()
                    {
                        Id = detail.Id,
                        OrderId = detail.OrderId,
                        ProductId = detail.ProductId,
                        Quantity = detail.Quantity,
                        Price = detail.Price
                    };

                    details.Add(newDetail);
                }

                //order.Details = details;

                await _orderService.CreateOrder(order, details);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error when create order");
                throw;
            }
        }

        [Route("{customerId}")]
        [HttpGet]
        async public Task<List<Models.Order>> GetOrderByCustomer(Guid customerId)
        {
            try
            {
                var orders = await _orderService.GetOrderByCustomer(customerId);

                return orders;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error when get orders");
                throw;
            }
        }
    }
}

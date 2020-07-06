using MassTransit;
using Microsoft.Extensions.Logging;
using StoreTekPrototype.Services.EventContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace StoreTekPrototype.Services.Billing.Service
{
    public class OrderEnteredConsumer : IConsumer<OrderEntered>
    {
        ILogger<OrderEnteredConsumer> _logger;
        public OrderEnteredConsumer(ILogger<OrderEnteredConsumer> logger)
        {
            _logger = logger;
        }
        public async Task Consume(ConsumeContext<OrderEntered> context)
        {
            await Task.Delay(5000);

            _logger.LogInformation($"Billing: Order received with ID {context.Message.Id} , Customer Name {context.Message.CustomerName}");
        }
    }
}

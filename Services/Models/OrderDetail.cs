using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreTekPrototype.Services.Models
{
    public class OrderDetail
    {
        public Guid Id { get; set; }
        public Guid OrderId { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
        public Order Order { get; set; }
    }
}

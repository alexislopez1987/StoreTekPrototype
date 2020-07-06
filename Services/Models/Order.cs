using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;

namespace StoreTekPrototype.Services.Models
{
    public class Order
    {
        public Guid Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid CustomerId { get; set; }
        public string CustomerName { get; set; }
        //public IEnumerable<OrderDetail> Details { get; set; }
        private readonly List<OrderDetail> _details = new List<OrderDetail>();
        public IEnumerable<OrderDetail> Details => _details;
    }
}

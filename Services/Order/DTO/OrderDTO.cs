using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreTekPrototype.Services.Order.DTO
{
    public class OrderDTO
    {
        public Guid Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid CustomerId { get; set; }
        public string CustomerName { get; set; }
        public IEnumerable<OrderDetailDTO> Details { get; set; }
        //public OrderDetailDTO[] Details { get; set; }
        public override string ToString()
        {
            return $"Order: ID {Id} , CustomerId {CustomerId} , CustomerName {CustomerName} , Date {CreatedDate.ToString("dd/MM/yyyy")} ";
        }
    }
}

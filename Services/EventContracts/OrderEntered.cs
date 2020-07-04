using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreTekPrototype.Services.EventContracts
{
    public interface OrderEntered
    {
        public Guid Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid CustomerId { get; set; }
        public string CustomerName { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kestra.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
        public int TickerId { get; set; }
        public Ticker Ticker{ get; set; }
        public decimal Quantity { get; set; }
        public DateTime CreatedOnUtc { get; set; }
        public bool Deleted { get; set; }
    }
}

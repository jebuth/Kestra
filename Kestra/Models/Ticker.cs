using System.Collections.Generic;

namespace Kestra.Models
{
    public class Ticker
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Deleted { get; set; }
        public IEnumerable<Transaction> Transactions { get; set; }
    }
}
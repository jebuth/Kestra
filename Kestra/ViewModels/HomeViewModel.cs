using Kestra.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Kestra.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Order> Orders { get; set; }
        public IEnumerable<Ticker> Tickers { get; set; }

        [Required]
        public int selectedOrderTypeId { get; set; }
        [Required]
        public decimal selectedQuantity { get; set; }
        [Required]
        public int selectedTickerId { get; set; }
    }
}

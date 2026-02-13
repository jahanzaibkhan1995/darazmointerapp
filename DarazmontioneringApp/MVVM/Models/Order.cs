using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DarazmontioneringApp.MVVM.Models
{
    public class Order
    {
        public string OrderId { get; set; }
        public string Status { get; set; }
        public decimal TotalPrice { get; set; }
    }
}

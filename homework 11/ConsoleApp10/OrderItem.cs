using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp10
{
    public class OrderItem
    {
        public int OrderItemId { get; set; }
        public string TradeName { get; set; }
        public double Price { get; set; }
        public int BuyNum { get; set; }
        public int OrderId { get; set; }
        public Order order { get; set; }
    }
}

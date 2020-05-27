using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp10
{
    public class Order
    {
        public int OrderId { get; set; }
        public string BuyTime { get; set; }
        public string Location { get; set; }
        public string Customer { get; set; }
        public List<OrderItem> Items { get; set; }
        public double TotalPrice
        {
            get
            {
                double total = 0;
                foreach (OrderItem orderItem in Items)
                    total += orderItem.Price * orderItem.BuyNum;
                return total;
            }
        }
        public Order(string Name)
        {
            Customer = Name;
        }
    }
}

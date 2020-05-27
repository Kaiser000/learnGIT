using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp10
{
    class OrderService
    {
        OrderContext db;

        public void addOrder(string Name, List<OrderItem> orderItems)
        {
            using (db = new OrderContext())
            {
                var order = new Order(Name);
                order.Items = orderItems;
                db.Orders.Add(order);
                db.SaveChanges();
            }
        }

        public void deleteOrder(int orderId)
        {
            using (db = new OrderContext())
            {
                var order = db.Orders.Include("OrderItems").FirstOrDefault(p => p.OrderId == orderId);
                if (order != null)
                {
                    db.Orders.Remove(order);
                    db.SaveChanges();
                }
            }
        }

        public Order searchOrderById(int id)
        {
            Order order = null;
            using (db = new OrderContext())
            {
                order = db.Orders.FirstOrDefault(p => p.OrderId == id);
                if (order == null)
                    return null;
            }
            return order;
        }

        public Order searchOrderByCustomer(string Name)
        {
            Order order = null;
            using (db = new OrderContext())
            {
                order = db.Orders.FirstOrDefault(p => p.Customer == Name);
                if (order == null)
                    return null;
            }
            return order;
        }
    }
}

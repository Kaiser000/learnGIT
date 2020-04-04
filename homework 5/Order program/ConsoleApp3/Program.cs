using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{//写一个订单管理的控制台程序，能够实现添加订单、删除订单、修改订单、查询订单（按照订单号、商品名称、客户等字段进行查询）功能。
 //提示：主要的类有order（订单）、orderitem（订单明细项），orderservice（订单服务），订单数据可以保存在orderservice中一个list中。在program里面可以调用orderservice的方法完成各种订单操作。
 //要求：
 //（1）使用linq语言实现各种查询功能，查询结果按照订单总金额排序返回。（pass）
 //（2）在订单删除、修改失败时，能够产生异常并显示给客户错误信息。
 //（3）作业的订单和订单明细类需要重写equals方法，确保添加的订单不重复，每个订单的订单明细不重复。(pass)
 //（4）订单、订单明细、客户、货物等类添加tostring方法，用来显示订单信息。(pass)
 //（5）orderservice提供排序方法对保存的订单进行排序。默认按照订单号排序，也可以使用lambda表达式进行自定义排序。

    class OrderItem
    {
        public string TradeName { get; set; }    
        public double Price { get; set; }
        public int BuyNum { get; set; }
        public OrderItem(string TradeName, double Price, int BuyNum)
        {
            this.TradeName = TradeName;
            this.Price = Price;
            this.BuyNum = BuyNum;
        }
        public override bool Equals(object obj)
        {
            var item = obj as OrderItem;
            return item != null &&
                   TradeName == item.TradeName &&
                   Price == item.Price &&
                   BuyNum == item.BuyNum;
        }

        public override int GetHashCode()
        {
            var hashCode = 463983925;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(TradeName);
            hashCode = hashCode * -1521134295 + Price.GetHashCode();
            hashCode = hashCode * -1521134295 + BuyNum.GetHashCode();
            return hashCode;
        }

        public override string ToString()
        {
            return TradeName + "      " + Price + "       " + BuyNum;
        }
    }

    class Order:IComparable<Order>
    {
        public string OrderNum { get; set; }     //订单号
        public DateTime BuyTime { get; set; }    //购买日期
        public string Location { get; set; }     //购买地址
        public string Customer { get; set; }     //客户 
        public List<OrderItem> Items;                   //订单明细项   
        public double TotalPrice = 0;        //总价
        public Order(string OrderNum, DateTime BuyTime, string Location, string Customer,List<OrderItem> Items)
        {
            this.OrderNum = OrderNum;
            this.BuyTime = BuyTime;
            this.Location = Location;
            this.Customer = Customer;
            this.Items = Items;
            foreach(OrderItem i in Items)
            {
                TotalPrice += i.Price * i.BuyNum;
            }

        }
        public int CompareTo(Order p)
        {
            int a, b;
            int.TryParse(this.OrderNum, out a);
            int.TryParse(p.OrderNum, out b);
            return a - b;
        }
        public override string ToString()
        {
            return OrderNum + "      " + BuyTime.ToString() + "        " + Location + "      " + Customer;
        }

        public override bool Equals(object obj)
        {
            var order = obj as Order;
            return order != null && OrderNum == order.OrderNum;
        }

        public override int GetHashCode()
        {
            var hashCode = -390525843;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(OrderNum);
            hashCode = hashCode * -1521134295 + BuyTime.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Location);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Customer);
            hashCode = hashCode * -1521134295 + EqualityComparer<List<OrderItem>>.Default.GetHashCode(Items);
            return hashCode;
        }
    }
    class OrderService
    {
        List<Order> Orders = new List<Order>();
        bool diff = true;       //标识新添加订单是否和表中重复
        public void AddOrder(Order NewOrder)
        {
            foreach(Order i in Orders)
            {
                if (i.Equals(NewOrder))
                {
                    diff = false;
                    break;
                }
            }
            if (diff == true)
            {
                Orders.Add(NewOrder);
                Console.WriteLine("添加成功");
            }
            else
            {
                Console.WriteLine("订单重复，添加失败");
            }
        }
        public void SearchOrder(string type,string value)
        {
            switch (type)    //查找类型包括“ordernum”订单号，“customer”客户名，“tradename”商品名称
            {
                case "OrderNum":
                    var quary1 = from n in Orders
                               where n.OrderNum.Contains(value)
                               orderby n.TotalPrice                      
                               select n;
                    List<Order> newOrders1 = quary1.ToList<Order>();
                    Console.WriteLine("OrderNum " + "      " + "BuyTime" + "        " + "Location" + "      " + "Customer");
                    foreach(Order i in newOrders1)
                    {
                        Console.WriteLine(i.ToString());
                    }
                            break;
                case "Customer":
                    var quary2=from n in Orders
                               where n.Customer.Contains(value)
                               orderby n.TotalPrice
                               select n;
                    List<Order> newOrders2 = quary2.ToList<Order>();
                    Console.WriteLine("OrderNum " + "      " + "BuyTime" + "        " + "Location" + "      " + "Customer");
                    foreach (Order i in newOrders2)
                    {
                        Console.WriteLine(i.ToString());
                    }
                    break;
                case "TradeName":
                    var quary3 = from n in Orders
                                 where (from i in n.Items
                                        select i.TradeName).Contains(value)
                                 select n;
                    List<Order> newOrders3 = quary3.ToList<Order>();
                    Console.WriteLine("OrderNum " + "      " + "BuyTime" + "        " + "Location" + "      " + "Customer");
                    foreach (Order i in newOrders3)
                    {
                        Console.WriteLine(i.ToString());
                    }
                    break;
                default:
                    Console.WriteLine("输入错误，查找失败");
                    break; 
            }
        }
        public void DeleteOrder(string type,string value)    //先模糊搜索，再精确删除
        {
            SearchOrder(type, value);   //查询类似项
            Console.WriteLine("请输入要删除的订单号");
            string s = Console.ReadLine();
            for(int i = 0; i < Orders.Count; i++)
            {
                if (Orders[i].OrderNum == s)
                {
                    Orders.RemoveAt(i);
                    Console.WriteLine("删除成功");
                    break;
                }
            }

        }
        public void ChangeOrder(string type,string value,Order newOrder)    //先模糊搜索，再精确覆盖
        {
            SearchOrder(type, value);   //查询类似项
            Console.WriteLine("请输入要更改订单的订单号");
            string s = Console.ReadLine();
            for (int i = 0; i < Orders.Count; i++)
            {
                if (Orders[i].OrderNum == s)
                {
                    Orders[i] = newOrder;
                    Console.WriteLine("更改成功");
                    break;
                }
            }
        }
    }
        class Program
    {
        static void Main(string[] args)
        {
            OrderItem book = new OrderItem("三国演义", 24.99, 1);
            OrderItem food = new OrderItem("饼干", 16.9, 3);
            OrderItem toy = new OrderItem("毛绒熊", 39.9, 1);
            OrderItem light = new OrderItem("台灯", 29, 1);
            OrderItem product = new OrderItem("ipad", 3999, 1);
            OrderItem keyboard = new OrderItem("机械键盘",399, 6);
            List<OrderItem> orderList1 = new List<OrderItem>();
            orderList1.Add(book);
            orderList1.Add(food);
            List<OrderItem> orderList2 = new List<OrderItem>();
            orderList2.Add(toy);
            orderList2.Add(light);
            List<OrderItem> orderList3 = new List<OrderItem>();
            orderList3.Add(product);
            orderList3.Add(keyboard);
            Order order1 = new Order("0001", DateTime.Now, "湖北", "张三", orderList1);
            Order order2 = new Order("0002", DateTime.Now.AddHours(3), "山西", "李四", orderList2);
            Order order3 = new Order("0003", DateTime.Now.AddMinutes(39), "北京", "王五", orderList3);
            OrderService service = new OrderService();
            service.AddOrder(order1);
            service.AddOrder(order2);
            service.AddOrder(order3);
            //service.AddOrder(order3);
            service.SearchOrder("OrderNum", "0001");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;
namespace ConsoleApp3
{//写一个订单管理的控制台程序，能够实现添加订单、删除订单、修改订单、查询订单（按照订单号、商品名称、客户等字段进行查询）功能。
 //提示：主要的类有order（订单）、orderitem（订单明细项），orderservice（订单服务），订单数据可以保存在orderservice中一个list中。在program里面可以调用orderservice的方法完成各种订单操作。
 //要求：
 //（1）使用linq语言实现各种查询功能，查询结果按照订单总金额排序返回。（pass）
 //（2）在订单删除、修改失败时，能够产生异常并显示给客户错误信息。
 //（3）作业的订单和订单明细类需要重写equals方法，确保添加的订单不重复，每个订单的订单明细不重复。(pass)
 //（4）订单、订单明细、客户、货物等类添加tostring方法，用来显示订单信息。(pass)
 //（5）orderservice提供排序方法对保存的订单进行排序。默认按照订单号排序，也可以使用lambda表达式进行自定义排序。
    [Serializable]
    public class OrderItem
    {
        public string TradeName { get; set; }
        public double Price { get; set; }
        public int BuyNum { get; set; }
        public OrderItem()
        {

        }
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
    [Serializable]
    public class Order : IComparable<Order>
    {
        public string OrderNum { get; set; }     //订单号
        public DateTime BuyTime { get; set; }    //购买日期
        public string Location { get; set; }     //购买地址
        public string Customer { get; set; }     //客户 
        public List<OrderItem> Items;                   //订单明细项   
        public double TotalPrice = 0;        //总价
        public Order()
        {
            
        }
        public Order(string OrderNum, DateTime BuyTime, string Location, string Customer, List<OrderItem> Items)
        {
            this.OrderNum = OrderNum;
            this.BuyTime = BuyTime;
            this.Location = Location;
            this.Customer = Customer;
            this.Items = Items;
            foreach (OrderItem i in Items)
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
    public class OrderService
    {
        public List<Order> Orders = new List<Order>();       
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
                throw new ArgumentException("订单不得重复");
            }
        }
        public List<Order> SearchOrder(string type,string value)
        {
            List<Order> newOrders = null;
            switch (type)    //查找类型包括“ordernum”订单号，“customer”客户名，“tradename”商品名称
            {
                case "OrderNum":
                    var quary1 = from n in Orders
                               where n.OrderNum.Contains(value)
                               orderby n.TotalPrice                      
                               select n;
                    newOrders = quary1.ToList<Order>();
                    Console.WriteLine("OrderNum " + "      " + "BuyTime" + "        " + "Location" + "      " + "Customer");
                    foreach(Order i in newOrders)
                    {
                        Console.WriteLine(i.ToString());
                    }
                    return newOrders;                         
                case "Customer":
                    var quary2=from n in Orders
                               where n.Customer.Contains(value)
                               orderby n.TotalPrice
                               select n;
                    newOrders = quary2.ToList<Order>();
                    Console.WriteLine("OrderNum " + "      " + "BuyTime" + "        " + "Location" + "      " + "Customer");
                    foreach (Order i in newOrders)
                    {
                        Console.WriteLine(i.ToString());
                    }
                    return newOrders;
                case "TradeName":
                    var quary3 = from n in Orders
                                 where (from i in n.Items select i.TradeName).Contains(value)   //存在小bug 不支持模糊查询
                                 orderby n.TotalPrice
                                 select n;
                    newOrders = quary3.ToList<Order>();
                    Console.WriteLine("OrderNum " + "      " + "BuyTime" + "        " + "Location" + "      " + "Customer");
                    foreach (Order i in newOrders)
                    {
                        Console.WriteLine(i.ToString());
                    }
                    return newOrders;
                default:
                    Console.WriteLine("输入错误，查找失败");
                    throw new ArgumentException("输入格式不正确");                    
            }
        }
        public void DeleteOrder(string s)    //s为订单号
        {   
            for(int i = 0; i < Orders.Count; i++)
            {
                if (Orders[i].OrderNum == s)
                {
                    Orders.RemoveAt(i);
                    Console.WriteLine("删除成功");
                    return;
                }                
            }           
                throw new ArgumentException("删除失败，订单号不正确");   
        }
        public void ChangeOrder(string s,Order newOrder)    //s为订单号
        {           
            for (int i = 0; i < Orders.Count; i++)
            {
                if (Orders[i].OrderNum == s)
                {
                    Orders[i] = newOrder;
                    Console.WriteLine("更改成功");
                    return;
                }
            }
            throw new ArgumentException("更改失败，订单号不正确");
        }
        public void Exoprt(List<Order> orders)    //将所有的订单序列化为XML文件
        {
            try
            {
                XmlSerializer xs = new XmlSerializer(typeof(List<Order>));
                using (FileStream fs = new FileStream("s.xml", FileMode.Create))
                {
                    xs.Serialize(fs, Orders);
                }
                Console.WriteLine("\n序列化如下");
                Console.WriteLine(File.ReadAllText("s.xml"));
            }
            catch(Exception e){
                Console.WriteLine(e.Message);  
            }
        }
        public void Import(string location)    //从XML文件中载入订单      locaton代表XML文件路径
        {
            try
            {
                XmlSerializer xs = new XmlSerializer(typeof(List<Order>));
                using (FileStream fs = new FileStream(location, FileMode.Open))
                {
                    List<Order> ORDERS = (List<Order>)  xs.Deserialize(fs);
                    Console.WriteLine("\n反序列化如下");
                    foreach(Order a in ORDERS)
                    {
                        Console.WriteLine(a.ToString());
                    }
                }  
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
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
            service.Exoprt(service.Orders);
            string location = "s.xml";
            service.Import(location);
        }
    }
}

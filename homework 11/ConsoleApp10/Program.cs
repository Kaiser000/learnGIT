using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp10
{
    class Program
    {
        static void Main(string[] args)
        {
            OrderService orderService = new OrderService();
            List<OrderItem> orderItems = new List<OrderItem>();
            while (true)
            {
                int mod = 0;
                Console.WriteLine("选择模式：1.添加订单 2.查询订单 3.删除订单");
                mod = Int32.Parse(Console.ReadLine());
                switch (mod)
                {
                    case 1:
                        {
                            bool flag = true;
                            while (flag)
                            {
                                OrderItem orderItem = new OrderItem();
                                Console.WriteLine("输入商品名：");
                                orderItem.TradeName= Console.ReadLine();
                                Console.WriteLine("输入商品单价");
                                orderItem.Price = Int32.Parse(Console.ReadLine());
                                Console.WriteLine("输入商品数量");
                                orderItem.BuyNum = Int32.Parse(Console.ReadLine());
                                orderItems.Add(orderItem);
                                Console.WriteLine("是否继续添加订单项:1.是 2.否");
                                mod = Int32.Parse(Console.ReadLine());
                                if (mod == 2)
                                {
                                    string cusName = "";
                                    Console.WriteLine("输入用户名：");
                                    cusName = Console.ReadLine();
                                    orderService.addOrder(cusName, orderItems);
                                    orderItems.Clear();
                                }
                            }
                            break;
                        }
                }
            }
        }
    }
}

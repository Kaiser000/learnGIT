using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleApp3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3.Tests
{
    [TestClass()]
    public class OrderServiceTests
    {
        static Order order1 = null;
        static Order order2 = null;
        static Order order3 = null;
        [ClassInitialize]
        public static void ClassInit(TestContext testcontext)
        {
            OrderItem book = new OrderItem("三国演义", 24.99, 1);     //订单项 三国演义 价格24.99 数量1
            OrderItem food = new OrderItem("饼干", 16.9, 3);          //订单项 饼干     价格16.9  数量3
            OrderItem toy = new OrderItem("毛绒熊", 39.9, 1);         //订单项 毛绒熊   价格39.9  数量1
            OrderItem light = new OrderItem("台灯", 299, 1);          //订单项 台灯     价格299   数量1 
            OrderItem product = new OrderItem("ipad", 3999, 1);       //订单项 ipad     价格3999  数量1
            OrderItem keyboard = new OrderItem("机械键盘", 399, 6);   //订单项 机械键盘 价格399   数量6
            List<OrderItem> orderList1 = new List<OrderItem>();
            orderList1.Add(book);
            orderList1.Add(food);
            List<OrderItem> orderList2 = new List<OrderItem>();
            orderList2.Add(toy);
            orderList2.Add(light);
            List<OrderItem> orderList3 = new List<OrderItem>();
            orderList3.Add(product);
            orderList3.Add(keyboard);
            order1 = new Order("0001", DateTime.Now, "湖北", "张三", orderList1);   //订单1 三国演义 饼干
            order2 = new Order("0002", DateTime.Now.AddHours(3), "山西", "李四", orderList2);//订单2 毛绒熊 台灯
            order3 = new Order("0003", DateTime.Now.AddMinutes(39), "北京", "王五", orderList3);//订单3 ipad 机械键盘
        }

        
        [TestMethod()]
        public void AddOrderTest()
        {
            OrderService service = new OrderService();
            List<Order> result = new List<Order>();
            service.AddOrder(order1);
            service.AddOrder(order2);
            service.AddOrder(order3);
            result.Add(order1);
            result.Add(order2);
            result.Add(order3);
            CollectionAssert.AreEqual(result, service.Orders);
        }
        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void AddOrderTest2()
        {
            OrderService service = new OrderService();
            service.AddOrder(order1);
            service.AddOrder(order1);
        }
        [TestMethod()]
        public void SearchOrderTest()
        {
            OrderService service = new OrderService();
            List<Order> result = new List<Order>();
            service.AddOrder(order1);
            service.AddOrder(order2);
            service.AddOrder(order3);
            List<Order> orders=service.SearchOrder("OrderNum", "00");      
            result.Add(order1);
            result.Add(order2);
            result.Add(order3);
            CollectionAssert.AreEqual(result,orders);
        }
        [TestMethod()]
        public void SearchOrderTest2()
        {
            OrderService service = new OrderService();
            List<Order> result = new List<Order>();
            service.AddOrder(order1);
            service.AddOrder(order2);
            service.AddOrder(order3);
            List<Order> orders = service.SearchOrder("Customer", "李");           
            result.Add(order2);
            CollectionAssert.AreEqual(result, orders);
        }
        [TestMethod()]
        public void SearchOrderTest3()
        {
            OrderService service = new OrderService();
            List<Order> result = new List<Order>();
            service.AddOrder(order1);
            service.AddOrder(order2);
            service.AddOrder(order3);
            List<Order> orders = service.SearchOrder("TradeName", "三国演义");
            result.Add(order1);
            CollectionAssert.AreEqual(result, orders);
        }
        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void SearchOrderTest4()
        {
            OrderService service = new OrderService();            
            service.AddOrder(order1);
            service.AddOrder(order2);
            service.AddOrder(order3);
            service.SearchOrder("false", "三国演义");
        }
        [TestMethod()]
        public void DeleteOrderTest()
        {
            OrderService service = new OrderService();
            List<Order> result = new List<Order>();
            service.AddOrder(order1);
            service.AddOrder(order2);
            service.AddOrder(order3);
            service.DeleteOrder("0002");
            result.Add(order1);
            result.Add(order3);
            CollectionAssert.AreEqual(result, service.Orders);
        }
        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void DeleteOrderTest2()
        {
            OrderService service = new OrderService();
            service.AddOrder(order1);
            service.AddOrder(order2);
            service.AddOrder(order3);
            service.DeleteOrder("00026");
        }
        [TestMethod()]
        public void ChangeOrderTest()
        {
            OrderService service = new OrderService();
            List<Order> result = new List<Order>();
            service.AddOrder(order1);
            service.AddOrder(order2);
            service.ChangeOrder("0002", order3);
            result.Add(order1);
            result.Add(order3);
            CollectionAssert.AreEqual(result, service.Orders);
        }
        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void ChangeOrderTest2()
        {
            OrderService service = new OrderService();
            service.AddOrder(order1);
            service.AddOrder(order2);
            service.AddOrder(order3);
            service.ChangeOrder("ad", order3);
        }
        [TestMethod()]
        public void ExoprtTest()
        {
           // Assert.Fail();
        }

        [TestMethod()]
        public void ImportTest()
        {
            //Assert.Fail();
        }
    }
}
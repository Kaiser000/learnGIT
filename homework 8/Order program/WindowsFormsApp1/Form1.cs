using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ConsoleApp3;
namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();


        }

        private void button3_Click(object sender, EventArgs e)
        {
            List<Order> orders = service.SearchOrder("TradeName", textBox3.Text);
            dataGridView1.DataSource = orders;
        }
        OrderService service = null;
        private void Form1_Load(object sender, EventArgs e)
        {
            OrderItem book = new OrderItem("三国演义", 24.99, 1);
            OrderItem food = new OrderItem("饼干", 16.9, 3);
            OrderItem toy = new OrderItem("毛绒熊", 39.9, 1);
            OrderItem light = new OrderItem("台灯", 29, 1);
            OrderItem product = new OrderItem("ipad", 3999, 1);
            OrderItem keyboard = new OrderItem("机械键盘", 399, 6);
            List<OrderItem> orderList1 = new List<OrderItem>();
            orderList1.Add(book);
            orderList1.Add(food);
            List<OrderItem> orderList2 = new List<OrderItem>();
            orderList2.Add(toy);
            orderList2.Add(light);
            List<OrderItem> orderList3 = new List<OrderItem>();
            orderList3.Add(product);
            orderList3.Add(keyboard);
            Order order1 = new Order("0001", "2010-1-1", "湖北", "张三", orderList1);
            Order order2 = new Order("0002", "2014-3-4", "山西", "李四", orderList2);
            Order order3 = new Order("0003", "2019-9-9", "北京", "王五", orderList3);
            service = new OrderService();
            service.AddOrder(order1);
            service.AddOrder(order2);
            service.AddOrder(order3);
            orderServiceBindingSource.DataSource = service.Orders;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<Order> orders = service.SearchOrder("OrderNum", textBox1.Text);
            dataGridView1.DataSource = orders;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            List<Order> orders = service.SearchOrder("Customer", textBox2.Text);
            dataGridView1.DataSource = orders;
        }
        
        private void button7_Click(object sender, EventArgs e)    //删除订单
        {
            service.DeleteOrder(textBox4.Text);
            orderServiceBindingSource.DataSource = null;      //为了性能，实时更新太慢
            orderServiceBindingSource.DataSource = service.Orders;

        }

        private void button6_Click(object sender, EventArgs e)   //修改订单
        {
            Form2 form2 = new Form2(orderServiceBindingSource);
            form2.service = service;
            //form2.source = orderServiceBindingSource;
            form2.Show();            
           
        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)    //添加订单
        {

            Form2 form2 = new Form2(orderServiceBindingSource);
            form2.service = service;
            form2.Show();
            orderServiceBindingSource.DataSource = null;      //为了性能，实时更新太慢
            orderServiceBindingSource.DataSource = service.Orders;
        }
    }
}

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
    public partial class Form2 : Form
    {
        public OrderService service = null;
        private BindingSource source = null;
        Order order = null;
        List<OrderItem> orderList1 = new List<OrderItem>();
        List<OrderItem> orderList2 = new List<OrderItem>();
        public Form2(BindingSource bds)
        {
            InitializeComponent();
            source = bds;
            order = new Order();
            orderBindingSource.DataSource = orderList1;
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OrderItem item= new OrderItem(textBox7.Text, double.Parse(textBox2.Text),int.Parse(textBox6.Text));
            orderList1.Add(item);
            orderBindingSource.DataSource = null;
            orderBindingSource.DataSource = orderList1;
        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)    //添加订单
        {
            order = new Order(textBox1.Text,textBox5.Text, textBox4.Text, textBox3.Text, orderList1);          
            service.AddOrder(order);
            source.DataSource = null;      //为了性能，实时更新太慢
            source.DataSource = service.Orders;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OrderItem item = new OrderItem(textBox12.Text, double.Parse(textBox13.Text), int.Parse(textBox14.Text));
            orderList2.Add(item);
            orderBindingSource.DataSource = null;
            orderBindingSource.DataSource = orderList2;
        }

        private void button4_Click(object sender, EventArgs e)    //修改订单
        {
          
            order = new Order(textBox8.Text, textBox11.Text, textBox10.Text, textBox9.Text, orderList2);
            service.ChangeOrder(textBox15.Text, order);
            source.DataSource = null;      //为了性能，实时更新太慢
            source.DataSource = service.Orders;
        }
    }
}

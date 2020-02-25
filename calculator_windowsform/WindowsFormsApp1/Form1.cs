using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            double a;
            double b;
            double c=0;
            string d = "";
            string no = "false:除数不能为0";
            try
            {
                a = Int32.Parse(firstNUM.Text);
                b = Int32.Parse(lastNUM.Text);
                d = symbol.Text;
                switch (d)
                {
                    case "+":
                        c = a + b; break;
                    case "-":
                        c = a - b; break;
                    case "*":
                        c = a * b; break;
                    case "/":
                        if (b == 0)   //除数不为零
                        {
                            label1.Text = no;
                            return;
                        }
                        c = a / b; break;
                }
            }
            catch(Exception x)
            {
                label1.Text = "false:输入错误";   //输入有误
                return;
            }
            label1.Text = "result:" + c;


        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}

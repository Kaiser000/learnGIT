using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//将课本中例5-31的Cayley树绘图代码进行修改。
//添加一组控件用以调节树的绘制参数。
//参数包括递归深度（n）、主干长度（leng）、右分支长度比（per1）、左分支长度比（per2）、
//右分支角度（th1）、左分支角度（th2）、画笔颜色（pen）。


namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private Graphics graphics;
        double th1 = 30 * Math.PI / 180;
        double th2 = 20 * Math.PI / 180;
        double per1 = 0.1;
        double per2 = 0.1;
        int n=1;
        int leng = 50;
        Pen p = new Pen(Color.Black);
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            if (graphics == null) graphics = this.CreateGraphics();
            drawCaleyTree(n, 200, 310, leng, -Math.PI / 2);
        }

        void drawCaleyTree(int n, double x0, double y0, double leng, double th)
        {
            if (n == 0) return;
            double x1 = x0 + leng * Math.Cos(th);
            double y1 = y0 + leng * Math.Sin(th);
            drawLine(x0, y0, x1, y1);
            drawCaleyTree(n - 1, x1, y1, per1 * leng, th + th1);
            drawCaleyTree(n - 1, x1, y1, per2 * leng, th - th2);

        }
        void drawLine(double x0, double y0, double x1, double y1)
        {
           
            graphics.DrawLine(p, (int)x0, (int)y0, (int)x1, (int)y1);
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            n = trackBar1.Value;
            label2.Text = trackBar1.Value.ToString();
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            graphics.Clear(BackColor);
            drawCaleyTree(n, 200, 310, leng, -Math.PI / 2);
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            leng = trackBar2.Value;
            label4.Text = trackBar2.Value.ToString();
        }

        private void trackBar2_ValueChanged(object sender, EventArgs e)
        {
            graphics.Clear(BackColor);
            drawCaleyTree(n, 200, 310, leng, -Math.PI / 2);
        }

        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            per1 = (double)trackBar3.Value / 10;
            label6.Text = per1.ToString();
        }

        private void trackBar3_ValueChanged(object sender, EventArgs e)
        {
            graphics.Clear(BackColor);
            drawCaleyTree(n, 200, 310, leng, -Math.PI / 2);
        }

        private void trackBar4_Scroll(object sender, EventArgs e)
        {
            per2 = (double)trackBar4.Value / 10;
            label8.Text = per2.ToString();
        }

        private void trackBar4_ValueChanged(object sender, EventArgs e)
        {
            graphics.Clear(BackColor);
            drawCaleyTree(n, 200, 310, leng, -Math.PI / 2);
        }

        private void trackBar5_Scroll(object sender, EventArgs e)
        {
            th1 = trackBar5.Value * Math.PI / 180;
            label10.Text = trackBar5.Value.ToString();
        }

        private void trackBar5_ValueChanged(object sender, EventArgs e)
        {
            graphics.Clear(BackColor);
            drawCaleyTree(n, 200, 310, leng, -Math.PI / 2);
        }

        private void trackBar6_Scroll(object sender, EventArgs e)
        {
            th2 = trackBar6.Value * Math.PI / 180;
            label12.Text = trackBar6.Value.ToString();
        }

        private void trackBar6_ValueChanged(object sender, EventArgs e)
        {
            graphics.Clear(BackColor);
            drawCaleyTree(n, 200, 310, leng, -Math.PI / 2);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //显示颜色对话框
            DialogResult dr = colorDialog1.ShowDialog();
            //如果选中颜色，单击“确定”按钮则改变文本框的文本颜色
            if (dr == DialogResult.OK)
            {
                p.Color = colorDialog1.Color;
            }
        }
    }
}

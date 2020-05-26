using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConsoleApp5
{
    public partial class Form1 : Form
    {
        Crawler mycrawler = new Crawler();
        string startUrl;
        string preurl;
        public Form1()
        {
            InitializeComponent();           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            startUrl = textBox1.Text;
            preurl = startUrl.Remove(startUrl.IndexOf('/', 8) + 1);//获取url的根目录地址
            mycrawler.urls.Add(startUrl, false);
            mycrawler.Crawl(startUrl,preurl);
            foreach (string url in mycrawler.urls.Keys)
            {
                listBox1.Items.Add(url);
            }
        }
    }
}

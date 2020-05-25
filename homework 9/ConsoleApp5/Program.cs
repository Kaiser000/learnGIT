using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Collections;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
//改进书上例子9-10的爬虫程序。
// （1）只爬取起始网站上的网页 
//（2）只有当爬取的是html文本时，才解析并爬取下一级URL。
// （3）相对地址转成绝对地址进行爬取。
//（4）尝试使用Winform来配置初始URL，启动爬虫，显示已经爬取的URL和错误的URL信息。

namespace ConsoleApp5
{
   public class Crawler
    {
        public Hashtable urls = new Hashtable();
        public int count = 0;
        public string Download(string url)
        {
            try
            {
                WebClient webclient = new WebClient();
                webclient.Encoding = Encoding.UTF8;
                string html = webclient.DownloadString(url);
                string fileName = count.ToString();
                File.WriteAllText(fileName,html, Encoding.UTF8);
                return html;

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return "";
            }
        }
        public void Parse(string html,string preurl1)
        {
            string strRef = @"(href|HREF)[]*=[]*[""'][^""'#>]+[""']";
            MatchCollection matches = new Regex(strRef).Matches(html);            
                foreach (Match match in matches)
                {
                strRef = match.Value.Substring(match.Value.IndexOf('=')+1).Trim('"','\'','#',' ','>');               
                if (strRef.Length == 0) continue;
                if (urls[strRef] == null) urls[strRef] = false;
                }
            strRef = @"(href|HREF)[ ]*=[ ]*[""'][^(http|https)][^""'#>]+..html.*?[""']";
            matches = new Regex(strRef).Matches(html);
            foreach (Match match in matches)
            {
                var url = match.Value.Substring(match.Value.IndexOf('=') + 1).Trim('"', '\"', '#', '>');
                if (url.Length == 0) continue;
                Uri baseUri = new Uri(preurl1);
                Uri absoluteUri = new Uri(baseUri, url);              
                if (urls[absoluteUri.ToString()] == null)
                    urls[absoluteUri.ToString()] = false;
            }
        }
        public void Crawl(string preurl)
        {
           
            Console.WriteLine("开始爬行了…");
            while (true)
            {
                string current = null;
                foreach(string url in urls.Keys)
                {
                    if ((bool)urls[url]) continue;    //把键值对中值为假的键添加到current中 值为真说明爬取过了  倒着爬取的
                    current = url;
                }
                if (current == null || count > 10) break;
                Console.WriteLine("爬行" + current + "页面！");
                string html = Download(current);
               
                if (html.Contains("<html"))
                {
                    if (count < 1) {
                        Parse(html, preurl);
                    }         // 只爬取起始网站上的网页 只解析一次    
                }
                count++;
                urls[current] = true;             
            }
            Console.WriteLine("爬行结束");
        }
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}

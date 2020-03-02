using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 0;
            try
            {
               
                Console.WriteLine("please enter an integer number");
                string s = Console.ReadLine();
                n = Int32.Parse(s);
                if (n == 1)
                {
                    Console.WriteLine("this number hasn't prime factor");
                    return;
                }              
                for (int i = 2; i*i <= n; i++)    //算法优化
                {
                    while (n % i == 0)
                    {
                        n = n / i;
                        Console.Write(i + "     ");
                    }                
                }
                Console.Write(n + "     ");      //最后一个除不尽的也是质数因子
            }
            catch(Exception e)
            {
                Console.Write(e.Message);
            }
        }
    }
}

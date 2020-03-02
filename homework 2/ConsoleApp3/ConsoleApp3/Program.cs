using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            int n=99;
            int[] a=new int[n];
            for(int i = 0; i < n; i++)
            {
                a[i] = i + 2;
            }
            int j;
            int mul;
            for (j = 2; j < 10; j++)
            {
                for (mul = 1; mul * j <n+2; mul++)
                {
                    a[mul * j - 2] = 0;
                }
            }
            for(int k = 0; k < n; k++)
            {
                if (a[k] != 0)
                {
                    Console.Write(a[k] + "    ");
                }
               
            }
        }
    }
}

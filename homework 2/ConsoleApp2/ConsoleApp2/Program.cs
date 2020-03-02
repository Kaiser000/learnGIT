using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        static void GetMax(int[] a)
        {
            int max= -2147483648;
            for(int i = 0; i < a.Length; i++)
            {
                if (a[i] > max)
                {
                    max = a[i];
                }
            }
            Console.WriteLine("" + max);
            return;
        }
        static void GetMin(int[] a)
        {
            int min = 2147483647;
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] < min)
                {
                    min = a[i];
                }
            }
            Console.WriteLine("" + min);
            return;
        }
        static void GetAvg(int[] a)
        {
            int sum = 0;
            for (int i = 0; i < a.Length; i++)
            {
                sum += a[i];
            }
            Console.WriteLine("" + sum/a.Length);
            return;

        }
        static void GetSum(int[] a)
        {
            int sum = 0;
            for (int i = 0; i < a.Length; i++)
            {
                sum += a[i];
            }
            Console.WriteLine("" + sum);
            return;

        }
        static void Main(string[] args)
        {
            int[] a = { 1, 2, 343, 4, 4, 9 }; 
            try
            {
                GetMax(a);
                GetMin(a);
                GetAvg(a);
                GetSum(a);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
           
        }
    }
}

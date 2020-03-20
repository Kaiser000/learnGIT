using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    public class ClockEventArgs {}
    public delegate void ClockHandler(object sender, ClockEventArgs args);
    
    public class Clock
    {       
        public event ClockHandler StartTick;
        public event ClockHandler StartAlarm;
        public bool Pass(ref DateTime Time)
        {
                Console.WriteLine("当前时间：" + Time.ToString("HH-mm-ss"));
                System.Threading.Thread.Sleep(1000);
                 Time= Time.AddSeconds(1);
            return true;
        }
       
        public void Tick(ref DateTime Time)
        {            
            Pass(ref Time);        
            Console.WriteLine("Tick");
          
           // StartTick(this,new ClockEventArgs());
        }
        public void Alarm(DateTime T,ref DateTime Time)
        {

            TimeSpan timeSpan = T - Time;        
            if (timeSpan.Seconds<=1&&timeSpan.Seconds>0)//因为这样计时不准，必须用时间差进行统计
            {
                Console.WriteLine("Alarm!");
            }
            //StartAlarm(this,new ClockEventArgs());
        }
    }
    public class Form
    {
        public Clock clock = new Clock();
        public Form()
        {

        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            DateTime T = DateTime.Now.AddSeconds(5);
            Console.WriteLine(T.ToString());
            DateTime Time = DateTime.Now;
            while (true)
            {
               
                Form form = new Form();
                form.clock.Tick(ref Time);
                form.clock.Alarm(T,ref Time);
            }
          
           
        }
    }
}

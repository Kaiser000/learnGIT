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
        DateTime Time = DateTime.Now;
        public event ClockHandler StartTick;
        public event ClockHandler StartAlarm;
        public void Pass()
        {
                Console.WriteLine("当前时间：" + Time.ToString("HH:mm:ss"));
                System.Threading.Thread.Sleep(1000);
                 Time= Time.AddSeconds(1);           
        }
       
        public void Tick()
        {            
            Pass();        
            Console.WriteLine("Tick");
          
           // StartTick(this,new ClockEventArgs());
        }
        public void Alarm(DateTime T)
        {

            TimeSpan timeSpan = T.AddSeconds(1) - Time.AddSeconds(-1);//因为T的构造和form的构造并不是完全同时，中间有毫秒级别的时差        
            if (timeSpan.TotalMilliseconds<1000&&timeSpan.TotalMilliseconds>0)
            {
                Console.WriteLine("Alarm!");
            }
           // StartAlarm(this,new ClockEventArgs());
        }
    }
    public class Form
    {
        public Clock clock = new Clock();       
    }
    class Program
    {
        static void Main(string[] args)
        {
            DateTime T = DateTime.Now.AddSeconds(10);
            Console.WriteLine(T.ToString());
            Form form = new Form();
            while (true)
            {           
                form.clock.Tick();
                form.clock.Alarm(T);
            }          
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public abstract class graph
    {
       public abstract double GetArea();//计算面积
       public abstract bool IsRight();//判断是否正确
    }  //父类，用于简单工厂实现
    
  
    class Rectangle: graph           //长方形
    {
       private double width;              //长
       private double height;             //宽
        public Rectangle()                 //随机构造一个长方形
        {
            Random rd1 = new Random();
            this.width = rd1.Next();
            Random rd2 = new Random();
            this.height = rd2.Next();
        }
         Rectangle(double width,double height)     //参数构造
        {
            this.width = width;
            this.height = height; 
        }
        public override double GetArea()            //求面积
        {
            return width*height;
        }
        public override bool IsRight()    //判断是否正确
        {
            return width > 0 && height > 0;
        }
    }
     class Triangle: graph
    {
        public double s;//底
        public double h;//高
        public Triangle()              //随机构造一个三角形
        {
            Random rd1 = new Random();
            this.s = rd1.Next();
            Random rd2 = new Random();
            this.h = rd2.Next();
        }
        Triangle(double s, double h)          //参数构造
        {
            this.s = s;
            this.h = h;
        }
        public override double GetArea()            //求面积
        {

            return s * h;
        }
        public override bool IsRight()       //判断是否正确
        {
            return s > 0 && h > 0;
        }
    }
     class Square: graph
    {
        private double a;           //边长
       public Square()             //随机构造一个三角形
        {
            Random rd = new Random();
            this.a = rd.Next();
           
        }
        Square(double a)        //参数构造
        {
            this.a = a;
        }
        public override double GetArea()     //求面积
        {
            return a * a;
        }
        public override  bool IsRight()   //判断是否正确
        {
            return a > 0;
        }
    }
   public class Factory        //工厂类
    {
        public static graph GetGraph(string type)
        {

            switch (type)
            {
                case "Square":
                    return new Square();
                case "Rectangle":
                    return new Rectangle();
                default:
                    return new Triangle();
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            graph[] graphs = new graph[10];
            string shapeType;
            double sumArea=0;
            int i = 0;
            while (i <10)
            {
                Console.WriteLine("please enter the shape");
                shapeType = Console.ReadLine();
                graphs[i] = Factory.GetGraph(shapeType);
                if (graphs[i].IsRight())
                {
                    sumArea += graphs[i].GetArea();
                    i++;
                }
            }
            Console.WriteLine("面积和:" + sumArea);   
               
            
        }
    }
}

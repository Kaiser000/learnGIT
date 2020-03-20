using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        public class Node<T>  //链表节点
        {
            public Node<T> Next { get; set; }
            public T Data { get; set; }
            public Node(T t)
            {
                Next = null;
                Data = t;
            }
        }
        public class GenericList<T>
        {
            private Node<T> head;
            private Node<T> tail;
            public GenericList()
            {
                tail = head = null;
            }
            public Node<T> Head
            {
                get;
            }
            public void Add(T t)
            {
                Node<T> n = new Node<T>(t);
                if (tail == null)
                {
                    head = tail = n;
                    tail = n;
                }
            }
           public void ForEach(Action<T> action)
            {
                for(Node<T> i = Head; i != null; i = i.Next)
                {
                    action(i.Data);
                }
            }

        }
        static void Main(string[] args)
        {
            GenericList<int> list = new GenericList<int>();
            int sum=0;
            int max=-99999999;
            int min=99999999;
            Action<int> Action1 = m => Console.WriteLine(m);
            Action<int> Action2 = m => sum += m;
            Action<int> Action3 = m => { if (m > max) max = m; };
            Action<int> Action4 = m => { if (m < min) min = m; };
            list.ForEach(Action1);
            list.ForEach(Action2);
            list.ForEach(Action3);
            list.ForEach(Action4);



        }
    }
}

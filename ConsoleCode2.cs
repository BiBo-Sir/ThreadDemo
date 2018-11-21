using System;
using System.Threading;

namespace ThreadTest2
{
    class Program
    {
        static void Method1()
        {
            Console.WriteLine("Starting Print 1");
            for (int i = 1; i < 10; i++)
            {
                Thread.Sleep(800);
                Console.WriteLine(i+"  "+"Method1");
            }
        }

        static void Method2()
        {
            Console.WriteLine("Starting Print 2");
            for (int i = 1; i < 10; i++)
            {
                Thread.Sleep(500);
                Console.WriteLine(i+"  "+"Method2");
            }
        }

        static void Main(string[] args)
        {
            Thread t = new Thread(Method2);
            t.Start();//启用新线程
            Method1();//在主线程运行

            Console.ReadKey();
        }
    }
}


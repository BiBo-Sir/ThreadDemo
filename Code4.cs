using System;
using System.Threading;

namespace OverThread
{
    class Program
    {
        static void PrintNumbers()
        {
            Console.WriteLine("Starting...");

            for (int i = 1; i < 10; i++)
            {
                Console.WriteLine(i);
            }
        }

        static void PrintNumbersWithDelay()
        {
            Console.WriteLine("Starting With delay...");
            for (int i = 1; i < 10; i++)
            {
                Thread.Sleep(2000);
                Console.WriteLine(i+" "+"delay");
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Starting program...");
            Thread t = new Thread(PrintNumbersWithDelay);
            t.Start();
            Thread.Sleep(3000);
            t.Abort();//结束线程
            Console.WriteLine("A thread has been aborted");
            t = new Thread(PrintNumbers);
            t.Start();
            PrintNumbers();

            Console.ReadKey();
        }
    }
}

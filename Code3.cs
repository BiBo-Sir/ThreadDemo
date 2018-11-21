using System;
using System.Threading;

namespace ThreadTest3
{
    class Program
    {
        static void PrintNumbersWithDelay()
         {
             for(int i = 1; i< 10; i++)
             {
                 Thread.Sleep(1000);
                 Console.WriteLine(i);
             }
         }
 
         static void Main(string[] args)
         {
             Console.WriteLine("Starting...");
             Thread t = new Thread(PrintNumbersWithDelay);
             t.Start();
             t.Join();//t.Join方法允许等待线程执行完毕再执行Main中剩余的代码
             Console.WriteLine("Thread completed");//PrintNumbersWithDelay方法执行完毕才会执行

            Console.ReadKey();
        }
    }
}

using System;
using System.Threading;
using static System.Console;

namespace ThreadPoolTest
{
    class Program
    {
        private static string Test(out int threadId)
        {
            WriteLine("Starting...");
            WriteLine($"Is thread pool thread: {Thread.CurrentThread.IsThreadPoolThread}");
            Thread.Sleep(TimeSpan.FromSeconds(2));
            threadId = Thread.CurrentThread.ManagedThreadId;
            return $"Thread pool worker thread id was : {threadId}";
        }

        private static void Callback(IAsyncResult ar)
        {
            WriteLine("Starting a callback...");
            WriteLine($"State passed to a callback: {ar.AsyncState}");
            WriteLine($"Is thread pool thread: {Thread.CurrentThread.IsThreadPoolThread}");
            WriteLine($"Thread pool worker thread id: {Thread.CurrentThread.ManagedThreadId}");
        }

        private delegate string RunOnThreadPool(out int threadId);

        static void Main(string[] args)
        {
            int threadId = 0;
            //因为thread的构造方法只接收不带返回值的委托方法，因此，我们给它传递一个lambda表达式，在该表达式中我们调用了“Test”方法
            var t = new Thread(() => Test(out threadId));
            t.Start();
            t.Join();
            WriteLine($"Thread id: {threadId}");

            RunOnThreadPool poolDelegate = Test;
            //在线程池中调用委托
            IAsyncResult r = poolDelegate.BeginInvoke(out threadId, Callback, "a delegate asynchronous call");
            r.AsyncWaitHandle.WaitOne();//等待异步委托方法执行完毕  另外一种判断方式：while(r.IsCompleted)....
            string result = poolDelegate.EndInvoke(out threadId, r);//获取异步方法返回的结果
            WriteLine($"Thread pool worker thread id: {threadId}");
            WriteLine(result);

            Thread.Sleep(TimeSpan.FromSeconds(2));
            ReadKey();
        }
    }
}

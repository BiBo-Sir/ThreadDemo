using System;
using System.Threading;

namespace ThreadPoolTest3
{
    class ThreadPool_Demo
    {
        //ThreadPool是一个静态类，可以直接使用
        // 用于保存每个线程的计算结果
        static int[] result = new int[10];

        //注意：由于WaitCallback委托的声明带有参数，
        //      所以将被调用的Fun方法必须带有参数，即：Fun(object obj)。
        static void Fun(object obj)
        {
            int n = (int)obj;

            //计算阶乘
            int fac = 1;
            for (int i = 1; i <= n; i++)
            {
                fac *= i;
            }
            //保存结果
            result[n] = fac;
        }

        static void Main(string[] args)
        {
            //向线程池中排入9个工作线程
            for (int i = 1; i <= 10; i++)
            {
                //QueueUserWorkItem()方法：将工作任务排入线程池。
                //每排入一个工作函数，相当于请求创建一个线程
                //排入9个工作函数，对应9个独立的、互不干扰的线程

                ThreadPool.QueueUserWorkItem(new WaitCallback(Fun), i);
                // Fun：工作函数， 表示要执行的方法(与WaitCallback委托的声明必须一致)。
                // i ：工作函数的参数，为传递给Fun方法的参数(obj将接受)。

                //Fun(i);在一个线程上，比使用线程池慢很多
            }

            //输出计算结果
            for (int i = 1; i <= 9; i++)
            {
                Console.WriteLine("线程{0}: {0}! = {1}", i, result[i]);
            }

            Console.ReadKey();
        }

    }
}

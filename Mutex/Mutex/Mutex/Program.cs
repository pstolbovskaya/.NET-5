using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Mutex
{
    class Program
    {
        static void Main(string[] args)
        {
            Mutex mutex = new Mutex();
            List<Thread> threads = new List<Thread>();

            Thread thread = new Thread(() =>
            {
                for (int i = 0; i < 5; i++)
                {
                    mutex.Lock();
                    for (int j = 0; j < 5; j++)
                    {
                        Console.Write(Thread.CurrentThread.ManagedThreadId);

                    }

                    mutex.Unlock();
                    Console.WriteLine();

                }
            });

            Thread thread2 = new Thread(() =>
            {
                for (int i = 0; i < 5; i++)
                {
                    mutex.Lock();
                    for (int j = 0; j < 5; j++)
                    {
                        Console.Write(Thread.CurrentThread.ManagedThreadId);

                    }
                    mutex.Unlock();
                    Console.WriteLine();

                }
            });

            Thread thread3 = new Thread(() =>
            {
                for (int i = 0; i < 5; i++)
                {
                    mutex.Lock();
                    for (int j = 0; j < 5; j++)
                    {
                        Console.Write(Thread.CurrentThread.ManagedThreadId);

                    }
                    mutex.Unlock();
                    Console.WriteLine();

                }
            });

            thread.Start();
            thread2.Start();
            thread3.Start();
            Console.ReadKey();

        }
    }
}

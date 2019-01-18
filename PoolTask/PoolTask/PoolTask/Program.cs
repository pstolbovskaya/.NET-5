using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PoolTask
{
    class Program
    {
        static void Main(string[] args)
        {
            int count;
            Console.WriteLine("Enter the count of threads: ");
            try
            {
                count = int.Parse(Console.ReadLine());
                TaskQueue taskQueue = new TaskQueue(count);
                taskQueue.CreateThreads();
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
            }


            Console.ReadKey();

        }
    }
}

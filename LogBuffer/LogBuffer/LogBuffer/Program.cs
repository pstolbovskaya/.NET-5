using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace LogBuffer
{
    class Program
    {
        static void Main(string[] args)
        {
            LogBuffer buf = new LogBuffer();


            for (int i = 1; i <= 10000; i++)
            {
                buf.Add(i.ToString());
            }
            Console.WriteLine("Ready.");

            Console.ReadKey();

        }
    }
}

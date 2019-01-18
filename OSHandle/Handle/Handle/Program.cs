using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Handle
{
    class Program
    {
        static void Main(string[] args)
        {

            OSHandle file = new OSHandle();

            Console.WriteLine("Handle = " + file.Handle.Handle);

            Console.WriteLine("Call Dispose func.");
            file.Dispose();

            Console.ReadKey();

        }
    }
}

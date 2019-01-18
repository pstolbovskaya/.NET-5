using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generic
{
    class Program
    {
        static void Main(string[] args)
        {
            DynamicList<int> list = new DynamicList<int>();

            list.Add(5);
            list.Add(0);
            list.Add(5);
            list.Add(1);

            Console.WriteLine("Full array");
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("-----------------------");
            Console.WriteLine("RemoveAt(0)");
            list.RemoveAt(0);
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("-----------------------");
            Console.WriteLine("RemoveAt(10)");
            list.RemoveAt(10);
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("-----------------------");
            Console.WriteLine("Remove(5)");
            list.Remove(5);
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("-----------------------");
            Console.WriteLine("Remove(7)");
            list.Remove(7);
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }


            Console.ReadLine();
        }

    }
}

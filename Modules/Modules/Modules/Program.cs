using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.IO;

namespace Modules
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Type> types = new List<Type>();
            List<Type> sortedTypes = new List<Type>();

            Console.WriteLine("Input the path to dll...");

            while (types.Count == 0)
            {
                try
                {
                    string path = Console.ReadLine();
                    Assembly assembly = Assembly.LoadFrom(path);
                    types = assembly.GetTypes().ToList();
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (FileNotFoundException ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }

            foreach (Type type in types)
            {
                if (type.IsPublic)
                {
                    sortedTypes.Add(type);
                }
            }

            sortedTypes = sortedTypes.OrderBy(nmspc => nmspc.Namespace).ThenBy(nm => nm.Name).ToList();

            foreach (Type type in sortedTypes)
            {
                Console.WriteLine(type.FullName);
            }

            Console.ReadKey();

        }
    }
    public class Temp
    {

    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Threading.Tasks;
using A;

namespace B
{
    [ExportClass]
    public class PublicClass1 { }
    [ExportClass]
    public class PublicClass2 { }

    public enum PublicEnum { };

    internal class InternalClass { }
}

namespace A
{
    static class Program
    {
        static void ListTypesInAssembly(Assembly assembly)
        {
            var types = assembly.GetTypes().Where(t => t.IsPublic && t.IsDefined(typeof(ExportClassAttribute), false));
            foreach (var type in types)
            {
                Console.WriteLine(type.FullName);
            }
        }

        static void Main(string[] args)
        {
            var assemblyPath = Assembly.GetExecutingAssembly().Location;
            var assembly = Assembly.LoadFrom(assemblyPath);
            ListTypesInAssembly(assembly);
            Console.ReadKey();
        }
    }

    [AttributeUsage(AttributeTargets.Class)]
    public class ExportClassAttribute : Attribute { }

    [ExportClass]
    public class PublicClass1 { }
    public class PublicClass2 { }

    public enum PublicEnum { };

    internal class InternalClass { }
}

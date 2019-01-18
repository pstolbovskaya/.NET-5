using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;

namespace Files
{
    class Program
    {
        private static int copiedfilescounter = 0;

        private static void TestTask()
        {
           
            Console.WriteLine("Input the source path: ");
            string sourcePath = Console.ReadLine();
            Console.WriteLine("Input the destination path: ");
            string destPath = Console.ReadLine();
            //Создать идентичную структуру папок
            foreach (string dirPath in Directory.GetDirectories(sourcePath, "*", SearchOption.AllDirectories))
            {
                try
                {
                    Directory.CreateDirectory(dirPath.Replace(sourcePath, destPath));
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }

            //Копировать все файлы и перезаписать файлы с идентичным именем
            foreach (string newPath in Directory.GetFiles(sourcePath, "*.*", SearchOption.AllDirectories))
            {
                try
                {
                    File.Copy(newPath, newPath.Replace(sourcePath, destPath), true);
                    Interlocked.Increment(ref copiedfilescounter);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
        }

        static void Main(string[] args)
        {
            var taskQueue = new TaskQueue(2);
            //for(int i = 0; i < 2; i++)
            taskQueue.EnqueueTask(TestTask);
            Thread.Sleep(5000);
            Console.WriteLine("Copied files: " + copiedfilescounter);
            Console.ReadLine();
        }
    }
   
}

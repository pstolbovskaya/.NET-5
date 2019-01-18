using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.IO;

namespace Handle
{
    class OSHandle : IDisposable
    {
        //private bool isDisposed = false;
        private string path;
        private bool flag = false;
        public FileStream Handle { get; set; }

        public OSHandle()
        {
            //isDisposed = false;
            while (!flag)
            {
                try
                {
                    Console.WriteLine("Enter the full path with file name...");
                    path = Console.ReadLine();
                    flag = true;
                    Handle = File.Open(path, FileMode.Open);
                }
                catch (ArgumentException)
                {
                    flag = false;
                    Console.WriteLine("The path cannot be empty. Try again.");
                }
                catch (FileNotFoundException)
                {
                    flag = false;
                    Console.WriteLine("Wrong path. Try again.");
                }

            }
        }



        public void Dispose()
        {
            try
            {
                Handle.Close();
                //Handle = null;
                //isDisposed = true;
                Console.WriteLine("File is disposed.");
                GC.SuppressFinalize(this);
            }
            catch
            {
                Console.WriteLine("File was disposed earlier.");
            }

        }

        ~OSHandle()
        {
            Handle.Dispose();
        }
    }
}

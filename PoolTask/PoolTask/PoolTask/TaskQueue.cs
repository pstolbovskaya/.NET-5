using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace PoolTask
{
    public class TaskQueue
    {
        readonly int threadCount;
        public TaskQueue(int threadCount)
        {
            this.threadCount = threadCount;
        }

        List<Thread> threads = new List<Thread>();

        Queue<TaskDelegate> taskQueue = new Queue<TaskDelegate>();
        public delegate void TaskDelegate();

        public void CreateThreads()
        {
            for (int i = 0; i < this.threadCount
                ; i++)
            {
                threads.Add(new Thread(new ThreadStart(TaskExecution)));
                threads[i].Start();
            }
        }
        private static void TaskExecution()
        {
            Console.WriteLine("Do something");
        }

        public void EnqueueTask(TaskDelegate task)
        {
            taskQueue.Enqueue(task);
        }
    }
}

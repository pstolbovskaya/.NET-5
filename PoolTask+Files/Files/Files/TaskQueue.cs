using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Concurrent;
using System.Threading;

namespace Files
{
    public delegate void TaskDelegate();

    class TaskQueue
    {
        private readonly BlockingCollection<TaskDelegate> blockingQueue = new BlockingCollection<TaskDelegate>();

        public TaskQueue(int threadCount)
        {
            for (int i = 0; i < threadCount; i++)
            {
                var thread = new Thread(DoThreadWork);
                thread.Start();
            }
        }

        public void EnqueueTask(TaskDelegate task)
        {
            blockingQueue.Add(task);
        }

        private void DoThreadWork()
        {
            while (true)
            {
                var task = blockingQueue.Take();
                try
                {
                    task();
                }
                catch (ThreadAbortException)
                {
                    Thread.ResetAbort();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
        }
    }
}

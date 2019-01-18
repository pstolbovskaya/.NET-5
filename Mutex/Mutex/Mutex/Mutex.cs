using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Mutex
{
    class Mutex
    {
        private int flag = 1;
        public Mutex()
        {
        }

        public void Lock()
        {
            while (Interlocked.CompareExchange(ref flag, 0, 1) == 0)
            {
                Thread.Sleep(100);
            }
        }

        public void Unlock()
        {
            Interlocked.CompareExchange(ref flag, 1, 0);
        }
    }
}


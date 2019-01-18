using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace LogBuffer
{
    class LogBuffer
    {
        private List<string> myList;
        private List<string> myListToFile;
        private int limitTime;
        private int limitNumbOfItems;
        private static System.Timers.Timer aTimer;
        private string path;
        private Mutex mt;

        public LogBuffer()
        {
            this.limitTime = 30000;
            this.limitNumbOfItems = 10;
            path = @"List.txt";
            myList = new List<string>();
            myListToFile = new List<string>();
            mt = new Mutex();
            SetTimer();
        }

        public void Add(string item)
        {
            myList.Add(item);
            myListToFile.Add(item);

            if (myListToFile.Count >= limitNumbOfItems)
            {
                SaveToFile();
            }
        }

        private void SaveToFile()
        {
            mt.WaitOne();
            if (myListToFile.Count != 0)
            {
                File.AppendAllLines(path, myListToFile);
                myListToFile.Clear();
            }
            mt.ReleaseMutex();
        }

        private void CallTimerSaveToFile(object source, System.Timers.ElapsedEventArgs e)
        {
            if (myListToFile.Count != 0)
            {
                SaveToFile();
            }
        }

        private void SetTimer()
        {
            aTimer = new System.Timers.Timer(limitTime);
            aTimer.Elapsed += CallTimerSaveToFile;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;
        }
    }
}

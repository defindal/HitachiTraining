using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HitachiTraining
{
    class ThreadClass
    {
        public void print(int i)
        {
            Console.WriteLine("step-" + i);
            Console.WriteLine(Thread.CurrentThread.Priority);
            // Thread.Sleep(3000);
        }
    }
}

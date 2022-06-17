using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HitachiTraining
{
    class ThreadPractice
    {
        private static int[] toPrint = new int[] {
                1, 2, 3, 4, 5, 6, 7, 8, 9 };

        public static void singleThread()
        {
            var startTime = DateTime.Now;
            foreach (var i in toPrint)
            {
                Console.WriteLine("step-" + i);
                // Thread.Sleep(3000);
            }
            var endTime = DateTime.Now;
            var miliseconds = (endTime - startTime).TotalMilliseconds;
            Console.WriteLine("Single Thread =" + miliseconds);
        }


        public static void multiThread()
        {
            ThreadClass job = new ThreadClass();
            
            var startTime = DateTime.Now;
            foreach (var i in toPrint)
            {
                var t = new Thread(
                    () => job.print(i)
                );
                t.Priority = (ThreadPriority) new Random().Next(0, 4);
                t.Start();
            }
            var endTime = DateTime.Now;
            var miliseconds = (endTime - startTime).TotalMilliseconds;
            Console.WriteLine("MultiThread = "  + miliseconds);
        }
    }
}

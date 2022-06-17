using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HitachiTraining
{
    class ThreadPractice
    {
        private static int[] toPrint = new int[] {
                1, 2, 3, 4, 5, 6, 7, 8, 9 , 10,
                1, 2, 3, 4, 5, 6, 7, 8, 9 , 10,
                1, 2, 3, 4, 5, 6, 7, 8, 9 , 10,
                1, 2, 3, 4, 5, 6, 7, 8, 9 , 10,
                1, 2, 3, 4, 5, 6, 7, 8, 9 , 10,
                1, 2, 3, 4, 5, 6, 7, 8, 9 , 10,
                1, 2, 3, 4, 5, 6, 7, 8, 9 , 10,
                1, 2, 3, 4, 5, 6, 7, 8, 9 , 10};

        public static void singleThread()
        {
            var startTime = DateTime.Now;
            foreach (var i in toPrint)
            {
                Console.WriteLine("step-" + i);
                Thread.Sleep(1000);
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

        public static void print(object obj)
        {
            object[] temp = (object[]) obj;
            Console.WriteLine("step-" + temp[0]);
            Console.WriteLine(Thread.CurrentThread.Priority);
            Thread.Sleep(8000);
        }
        // 
        public static void pooledThread()
        {
            var startTime = DateTime.Now;
            foreach (var i in toPrint)
            {
                ThreadPool.QueueUserWorkItem(new WaitCallback(print), 
                    new object[] { i});
            }
            var endTime = DateTime.Now;
            var miliseconds = (endTime - startTime).TotalMilliseconds;
            Console.WriteLine("Thread Pool = " + miliseconds);
        }

        public static async Task<object> GetJSON()
        {
            Thread.Sleep(10000);
            var url = "https://data.bmkg.go.id/DataMKG/TEWS/gempadirasakan.json";

            dynamic message;

            try 
            {
                //var response = await client.GetStringAsync(url);
                //return response;
                var client = new HttpClient();
                var response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                message = await response.Content.ReadAsStringAsync();

            }
            catch (HttpRequestException exception)
            {
                message = exception;
            }

            return message;
        }

        public static async void MultiTask()
        {
            var taskList = new List<Task<int>>();
            var startTime = DateTime.Now;

            foreach (var i in toPrint)
            {
                taskList.Add(
                    Task.Factory.StartNew(
                        x =>
                        {
                            // Console.WriteLine(i);
                            Thread.Sleep(1000);
                            return i;
                            // return (int) x! * (int)x;
                        }, i));
                // tasks.Add(Task.Factory.StartNew(b => (int)b! * (int)b, baseValue));
            }

            var results = await Task.WhenAll(taskList);
            
            var endTime = DateTime.Now;
            var miliseconds = (endTime - startTime).TotalMilliseconds;
            Console.WriteLine("MultiTask = " + miliseconds);
                        
            for(var i=0; i < results.Length; i++)
            {
                // Console.WriteLine(results[i]);
            }
        }

        public static async void AnyTask()
        {
            var taskList = new List<Task<int>>();
            var startTime = DateTime.Now;

            foreach (var i in toPrint)
            {
                taskList.Add(
                    Task.Factory.StartNew(
                        x =>
                        {
                            // Console.WriteLine(i);
                            Thread.Sleep(1000);
                            return i;
                            // return (int) x! * (int)x;
                        }, i));
                // tasks.Add(Task.Factory.StartNew(b => (int)b! * (int)b, baseValue));
            }

            var results = await Task.WhenAny(taskList);

            var endTime = DateTime.Now;
            var miliseconds = (endTime - startTime).TotalMilliseconds;
            Console.WriteLine("AnyTask = " + miliseconds);


        }
    }
}

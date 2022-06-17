using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;

namespace HitachiTraining
{
    class Program
    {
        static void Main(string[] args)
        {
            //ExceptionHandling exceptionHandling = new ExceptionHandling();
            //var result = exceptionHandling.cicilanPerBulan(10000, -2);
            //Console.WriteLine(result);
            // LINQPractice.fromJSON();

            //try
            //{
            //    int? x = null;
            //    // int y = null;
            //    // x = 18;

            //    Debug.Assert(x.HasValue);
            //    Console.WriteLine(x.Value);
            //    int z = 6 / x.Value;

            //} catch(Exception ex)
            //{
            //    // logging
            //    Console.WriteLine(ex.Message);
            //}
            //finally
            //{
            //    Console.ReadLine();
            //}
            ThreadPractice.singleThread();
            // ThreadPractice.multiThread();
            ThreadPractice.pooledThread();
            Console.ReadKey();
        }
    }
}

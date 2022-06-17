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
            // ThreadPractice.singleThread();
            // ThreadPractice.multiThread();
            ThreadPractice.MultiTask();
            ThreadPractice.AnyTask();
            // Console.WriteLine(result);
            VarDynamic();
            Console.ReadKey();
        }

        static void VarDynamic()
        {
            // VAR
            // 1. mempermudah penulisan type
            // 2. harus diinisialisasi dengan value 
            var i = 6.7;
            // var x;

            // DYNAMIC
            // 1. mendeklarasikan variable yang memang belum ditentukan typenya
            // 2. biasanya karena mengambil dari 2 source berbeda ( xml, json)
            //      atau output bisa beberapa kemungkinan
            // 3. tidak harus diinisialisasi di awal
            dynamic data;


        }
    }
}

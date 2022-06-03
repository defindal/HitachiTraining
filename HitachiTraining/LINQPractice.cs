using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HitachiTraining
{
    class LINQPractice
    {
        static int parse(String x)
        {
            return Int32.Parse(x);
        }

        public static void fromCollection(ICollection myCollection)
        {
            //var result = from item in myCollection.AsQueryable()
            // select item;

            int[] idx = new int[] { 4,8,9, 20, 27};
            List<int> idy = new List<int>() { 3, 9, 17, 21, 80, 65, 44, 0 };
            
            var idzString = File.ReadAllLines("idz.txt");
            var idz = new List<int>();
            
            idzString.ToList().ForEach(x => {
                idz.Add(Int32.Parse(x));
            });

            foreach(var x in idzString)
            {
                idz.Add(parse(x));
            }

            var odd = from i in idz
                      where i % 2 == 1
                      select i;

            // Console.WriteLine(odd.ToArray());
            
            odd.ToList().ForEach(i => Console.WriteLine(i));

        }

        public static void fromRDBMS()
        {

        }
    }
}

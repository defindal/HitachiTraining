using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HitachiTraining
{
    class CollectionPractice
    {
        void practice()
        {
            Console.WriteLine("Hello World!");

            ListDictionary listDictionary = new ListDictionary();
            listDictionary.Add(62, "Indonesia");
            listDictionary.Add(63, "Philippine");
            listDictionary.Add(60, "Malaysia");

            foreach (var item in listDictionary.Keys)
            {
                Console.WriteLine(item + " - " + listDictionary[item]);
            }

            Console.WriteLine("Sorted Dictionary");

            SortedDictionary<int, List<String>> countries = new SortedDictionary<int, List<String>>();
            countries.Add(62, new List<string>());
            countries.Add(63, new List<string>());
            countries.Add(60, new List<string>());

            foreach (var item in countries.Keys)
            {
                Console.WriteLine(item + " - " + countries[item]);
            }

            Console.WriteLine("Hashtable");

            Hashtable myHash = new Hashtable();
            myHash.Add(62, "Indonesia");
            myHash.Add(63, "Philippine");
            myHash.Add(60, "Malaysia");

            foreach (var item in myHash.Keys)
            {
                Console.WriteLine(item + " - " + myHash[item]);
            }

        }
    }
}

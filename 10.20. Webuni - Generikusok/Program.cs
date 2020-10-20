using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace _10._20.Webuni___Generikusok
{
    class Program
    {
        static void Main(string[] args)
        {

            //Lista típus

            Console.WriteLine("Lista generikus, példa:\n");
            List<string> myList = new List<string>();
            myList.Add("alma");
            myList.Add("körte");
            myList.Add("autó");
            myList.Add("könyv");
            myList.Add("ország");
            myList.Add("város");
            myList.Add("dinnye");

            //myList.Remove("alma");
            //myList.RemoveAt(0);

            int capacity = myList.Capacity;

            foreach (string item in myList)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine(capacity);
            Console.WriteLine();

            //ArrayLista típus >> using System.Collections !!;

            Console.WriteLine("ArrayLista generikus, példa:\n");

            ArrayList aList = new ArrayList();
            aList.Add("Fülöp");
            aList.Add("Péter");
            aList.Add("male");
            aList.Add(true);
            aList.Add(25);
            aList.Add(25.54);
            aList.Add("1993.08.17");

            foreach (var item in aList)
            {
                Console.WriteLine(item);
            }


            Console.WriteLine("\n");
            // Szótár típus
            Dictionary<string, string> dict = new Dictionary<string, string>();

            Console.WriteLine("Dictionary generikus, példa:\n");

            dict.Add("alma", "apple");
            dict.Add("körte", "pear");
            dict.Add("könyv", "book");
            dict.Add("autó", "car");
            dict.Add("város", "city");
            dict.Add("név", "name");
            dict.Add("vallás", "religion");
            dict.Add("nem", "gender");

            foreach (KeyValuePair<string,string> item in dict)
            {
                Console.WriteLine($"item.key: {item.Key}, item.value: {item.Value}");
            }




            Console.ReadKey();

        }
    }
}

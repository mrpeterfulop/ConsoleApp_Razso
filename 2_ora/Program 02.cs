using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_ora
{
    class Program
    {
        static void Main(string[] args)
        {

            /*
            string[] husleves = { "víz", "húsleves", "répa", "hagyma", "só", "bors" };
            string[] turosteszta = { "víz", "tészta", "túró", "szalonna", "tejföl" };

            if (DateTime.Today.DayOfWeek == DayOfWeek.Monday)
            {
                   Array.Sort(husleves);
                   foreach (string i in husleves)
                {
                    Console.WriteLine(i);
                }
            }
            else
            {

                Array.Sort(turosteszta);
                foreach (string i in turosteszta)
                {
                    Console.WriteLine(i);
                }

            }

            Console.ReadKey();
            */



            //09.08. Óra

           /* var hetfo = "Szünet";
            var kedd = "Keddi órarend";
            var szerda = "Szerdai órarend";
            var csutortok = "Csütörtöki órarend" ;
            var pentek = "Szünet";*/

            var today = DateTime.Today.DayOfWeek;

            string[] holidays = { "Nincsenek óráid! :)" };
            string[] tuesday = { "Programozás elmélet", "Programozás gyakorlat"};
            string[] wednesday = { "Programozás", "Angol"};
            string[] thursday = { "Hálózati ismeretek"};


            
            if (today == DayOfWeek.Monday && today == DayOfWeek.Friday && today == DayOfWeek.Saturday && today == DayOfWeek.Sunday)
            {
                Console.WriteLine("Today is: " + today + "\n" + "Az óráid: ");
                foreach (string i in holidays)
                {
                    Console.WriteLine(i);
                }
            }

            else if (today == DayOfWeek.Tuesday)
            {
                Console.WriteLine("Today is: " + today + "\n" + "Az óráid: ");
                foreach (string i in tuesday)
                {
                    Console.WriteLine(i);
                }   
            }

            else if (today == DayOfWeek.Wednesday)
            {
                Console.WriteLine("Today is: " + today + "\n" + "Az óráid: ");
                foreach (string i in wednesday)
                {
                    Console.WriteLine(i);
                }
            }

            else if (today == DayOfWeek.Thursday)
            {
                Console.WriteLine("Today is: " + today + "\n" + "Az óráid: ");
                foreach (string i in thursday)
                {
                    Console.WriteLine(i);
                }
            }
            Console.ReadLine();
        }
    }
}

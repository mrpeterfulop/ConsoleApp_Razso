using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09_08_orarend_fuggveny
{
    class Program
    {
        static void Main(string[] args)
        {


            var today = DateTime.Today.DayOfWeek;

            string[] holidays = { "Nincsenek óráid! :)" };
            string[] tuesday = { "Programozás elmélet", "Programozás gyakorlat" };
            string[] wednesday = { "Programozás", "Angol" };
            string[] thursday = { "Hálózati ismeretek" };

            orarend(today, holidays, tuesday, wednesday, thursday);

            Console.ReadLine();



        }

        private static void orarend(DayOfWeek today, string[] holidays, string[] tuesday, string[] wednesday, string[] thursday)
        {
            if (today == DayOfWeek.Monday || today == DayOfWeek.Friday || today == DayOfWeek.Saturday || today == DayOfWeek.Sunday)
            {
                holidaysFunction(today, holidays);
            }

            else if (today == DayOfWeek.Tuesday)
            {
                tuesdayFunction(today, tuesday);
            }

            else if (today == DayOfWeek.Wednesday)
            {
                wednesdayFunction(today, wednesday);
            }

            else if (today == DayOfWeek.Thursday)
            {
                NewMethod(today, thursday);
            }
        }


        private static void NewMethod(DayOfWeek today, string[] thursday)
        {
            Console.WriteLine("Today is: " + today + "\n" + "Az óráid: ");
            foreach (string i in thursday)
            {
                Console.WriteLine(i);
            }
        }

        private static void wednesdayFunction(DayOfWeek today, string[] wednesday)
        {
            Console.WriteLine("Today is: " + today + "\n" + "Az óráid: ");
            foreach (string i in wednesday)
            {
                Console.WriteLine(i);
            }
        }

        private static void holidaysFunction(DayOfWeek today, string[] holidays)
        {
            Console.WriteLine("Today is: " + today + "\n" + "Az óráid: ");
            foreach (string i in holidays)
            {
                Console.WriteLine(i);
            }
        }

        private static void tuesdayFunction(DayOfWeek today, string[] tuesday)
        {
            Console.WriteLine("Today is: " + today + "\n" + "Az óráid: ");
            foreach (string i in tuesday)
            {
                Console.WriteLine(i);
            }
        }
    }
}

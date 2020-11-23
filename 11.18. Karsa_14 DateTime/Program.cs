using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11._18.Karsa_14_DateTime
{
    class Program
    {
        static void Main(string[] args)
        {

            DateTime dt = new DateTime(2020,12,2);

            DateTime dt2 = new DateTime(2010,3,7,14,5,46);
            var today = DateTime.Today;
            var now = DateTime.Now;

            var newDate1 = today.AddDays(1);
            var newDate2 = today.AddYears(1);
            var newDate3 = today.AddMonths(1);


            Console.WriteLine("ToLongDateString(): " + dt2.ToLongDateString());
            Console.WriteLine("ToShortDateString(): " + dt2.ToShortDateString());
            Console.WriteLine("ToLongTimeString(): " + dt2.ToLongTimeString());
            Console.WriteLine("ToShortTimeString(): " + dt2.ToShortTimeString());

            Console.WriteLine("DateTime.Today: " + today);
            Console.WriteLine("DateTime.Now: " + now);

            Console.WriteLine("DateTime.Today.AddDays(+1): " + newDate1);
            Console.WriteLine("DateTime.Today.AddYears(+1): " + newDate2);
            Console.WriteLine("DateTime.Today.AddMonths(+1): " + newDate3);

            Console.WriteLine("DateTime.Today.Day(): " + today.Day);
            Console.WriteLine("DateTime.Today.Month(): " + today.Month);
            Console.WriteLine("DateTime.Today.Year(): " + today.Year);


            DateTime myBirtday = DateTime.Parse("1993/08/17");
            TimeSpan year = DateTime.Now - myBirtday;
            Console.WriteLine("Születési időpont: 1993/08/17");
            Console.WriteLine("Életkorom: " + year.TotalDays/365);


            Console.ReadKey();

        }
    }
}

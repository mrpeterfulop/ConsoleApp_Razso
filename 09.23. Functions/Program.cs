using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09._23.Functions
{
    class Program
    {

        static void Greetings(string name, string partOfTheDay)
        {
            string greetings = "Szia " + name + "! Jó " + partOfTheDay + "!";
            Console.WriteLine(greetings);

        }


        static string StrGreetings(string name, string partOfTheDay)
        {

            string greetings = "Szia " + name + "! Jó " + partOfTheDay + "!";
            return greetings;
        }




        static void Main(string[] args)
        {


            Greetings("Pista", "reggelt");
            string name2 = "Sanyi";
            string partOfTheDay2 = "estét";

            Greetings(name2, partOfTheDay2);


            string greetings = StrGreetings("Béla", "napot");

            Console.WriteLine(greetings);

            Console.ReadKey();

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10._30.Karsa_06_Structs
{
    class Program
    {

        struct Human //A struktúra értéktípus!
        {
            public string name; //mezők
            public int age;
            public string home;

            public Human(string n, int a, string h) // Konstruktor függvény
            {

                name = n;
                age = a;
                home = h;

            }

            public void writeData()
            {
                Console.WriteLine($"Név: {name}");
                Console.WriteLine($"Életkor: {age}");
                Console.WriteLine($"Lakhely: {home}");
            }


        }

        static void Main(string[] args)
        {

            Human h = new Human("Péter",20,"Budapest");
            Human h2 = h;

            h2.name = "András";
            h2.age = 19;
            h2.home = "Budapest";

            h.writeData();
            h2.writeData();


            List<Human> humanList = new List<Human>();
            Human hu = new Human("Tamás", 43, "Sopron");
            humanList.Add(hu);
            hu.writeData();


            Console.ReadKey();

        }
    }
}

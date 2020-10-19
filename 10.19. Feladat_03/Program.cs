using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10._19.Feladat_03
{
    class Program
    {
        static void Main(string[] args)
        {
            /*3.Feladat
             -  Írj programot, ami csak pozitív számot hajlandó beolvasni. Írja ki ezek után a beolvasott számot

             */

            int input;
            bool loop = true;

            do
            {
                try
                {
                    loopDataInput(out input, out loop);
                }
                catch (Exception)
                {
                    Console.WriteLine("Nem megfelelő karakterek! Csak pozitív egész számot adhatsz meg!");
                }

            } while (loop == true);

            Console.ReadKey();

        }

        public static void loopDataInput(out int input, out bool loop)
        {
            do
            {

                Console.WriteLine("Adj meg egy pozitív egész számot!");
                input = Convert.ToInt32(Console.ReadLine());
                if (input <= 0)
                {
                    Console.WriteLine("Hiba! Csak pozitív egész számot adhatsz meg!");
                }

            } while (input <= 0);

            Console.WriteLine("Program vége");
            loop = false;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10._19.Feladat_04
{
    class Program
    {
        static void Main(string[] args)
        {
            /* Feladat 4.
            -Készítsünk programot, mely bekér a felhasználótól egy számot, majd kiírja az adott számról, hogy páros, páratlan, vagy nulla.
            */

            bool loop1 = true;
            bool loop2 = true;

            do
            {
                loopProgram(ref loop1, ref loop2);

            } while (loop1 == true);

        }

        private static void loopProgram(ref bool loop1, ref bool loop2)
        {
            runProgram(ref loop1, ref loop2);

            Console.WriteLine("Szeretnéd újraindítani? IGEN:'Y'");
            var key = Console.ReadLine().ToUpper();

            loop1 = (key == "Y") ? true : false;
        }

        public static void runProgram(ref bool loop1, ref bool loop2)
        {
            do
            {
                try
                {
                    Console.WriteLine("Kérlek adj meg egy számot:");
                    var input = Convert.ToDouble(Console.ReadLine());

                    if (input % 2 == 0 & input != 0)
                    {
                        Console.WriteLine("A szám páros!");
                    }
                    else if (input % 2 != 0)
                    {
                        Console.WriteLine("A szám páratlan!");
                    }
                    else if (input == 0)
                    {
                        Console.WriteLine("A szám nulla!");
                    }
                    loop2 = false;
                }
                catch (Exception)
                {
                    Console.WriteLine("Hibás karakterek! Kérlek csak számokat használj!");
                    loop1 = true;
                }


            } while (loop2 == true);
        }
    }
}

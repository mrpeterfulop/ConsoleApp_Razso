using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10._19.Feladat_01
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
              
            Feladat 1. Írj programot, ami beolvassa a háromszög oldalainak hosszát, és megmondja, hogy ilyen oldalakkal szerkeszthető - e háromszög!
            
            a < b + c
            b < a + c
            c < a + b

            */

            var loop = true;
            string errMsg = "Hibásan megadott oldalhosszak! A háromszög bármely oldalának hossza kisebb a másik két oldal hosszának összegénél!";

            do
            {

                try
                {
                    loop = loopProgram(loop, errMsg);

                }
                catch (FormatException)
                {
                    Console.WriteLine("Csak pozitív egész számokat adhatsz meg!");
                }

            } while (loop == true);


            Console.ReadLine();

        }

        private static bool loopProgram(bool loop, string errMsg)
        {
            Console.WriteLine("Add meg a háromszög 'A' oldalhosszát:");
            var sideA = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Add meg a háromszög 'B' oldalhosszát:");
            var sideB = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Add meg a háromszög 'C' oldalhosszát:");
            var sideC = Convert.ToDouble(Console.ReadLine());

            if (sideA >= sideB + sideC)
            {
                Console.WriteLine(errMsg);
            }
            else if (sideB >= sideA + sideC)
            {
                Console.WriteLine(errMsg);
            }
            else if (sideC >= sideA + sideB)
            {
                Console.WriteLine(errMsg);
            }

            else
            {
                Console.WriteLine("A megadott hosszakból szerkeszthető háromszög!");
                loop = false;
            }

            return loop;
        }
    }
}

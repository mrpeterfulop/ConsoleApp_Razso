using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10._19.Feladat_02
{
    class Program
    {
        static void Main(string[] args)
        {
            /* Feladat 2.
             - Írj programot, mely beolvas egy pozitív egész számot, és kiírja az egész számokat a képernyőre eddig a számig, egymástól szóközzel elválasztva!

             */

            var loop = true;

            do
            {
                try
                {
                    Console.WriteLine("Adj meg egy pozitív egész számot!");
                    var inputString = Console.ReadLine();
                    var inputInt = Convert.ToInt32(inputString);

                    for (int i = 1; i < inputInt+1; i++)
                    {
                        if (i < inputInt)
                        {
                        Console.Write(i+" ");
                        }
                        else
                        {
                        Console.Write(i);
                        }
                    }
                    loop = false;
                    Console.WriteLine();
                }
                catch (Exception)
                {
                    Console.WriteLine("Csak pozitív egész számot adhatsz meg!");
                }

            } while (loop == true);

            Console.ReadKey();

        }
    }
}

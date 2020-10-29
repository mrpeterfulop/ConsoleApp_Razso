using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10._29.Karsa_01
{
    public class ConsoleWrite
    {


        public void WriteData(ref int num1, ref int num2, ref int sum, string evenOdd)
        {

            Console.WriteLine($"Adat1: {num1}");
            Console.WriteLine($"Adat2: {num2}");
            Console.WriteLine($"A bekért számok összege: {sum}");
            Console.WriteLine($"A szám: {evenOdd}");

        }



    }
}
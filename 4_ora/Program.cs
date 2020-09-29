using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4_ora
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Meddig írjam ki a számokat?");

            var input = Convert.ToInt64(Console.ReadLine());
            

            for (int i = 1; i < input+1; i++)
            {
                Console.WriteLine(i);
                System.Threading.Thread.Sleep(500);


            }

            Console.ReadKey();
        }
    }
}

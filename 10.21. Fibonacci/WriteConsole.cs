using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10._21.Fibonacci
{
    public class WriteConsole
    {
      
        public void writeData(int input)
        {
            Console.Clear();
            Console.WriteLine($"Az első {input} szám a Fibonacci sorozatból:");
            ColorAlerts.colorGreen();
            Console.WriteLine(string.Join(",", ListShare.FibonacciList));
            ColorAlerts.colorWhite();

            /*
            for (int i = 0; i < ListShare.FibonacciList.Count; i++)
            {
                Console.Write(ListShare.FibonacciList[i] + (i != (ListShare.FibonacciList.Count - 1) ? "," : ""));
            }
            */

            Console.WriteLine("\n");

            Console.WriteLine($"Az első {input} szám közül {ListShare.FibonacciEven.Count-1} db páros, 1 db nulla:");
            ColorAlerts.colorBlue();
            Console.WriteLine(string.Join(",", ListShare.FibonacciEven));
            ColorAlerts.colorWhite();


            Console.WriteLine("\n");

            Console.WriteLine($"Az első {input} szám közül {ListShare.FibonacciOdd.Count} db páratlan:");
            ColorAlerts.colorRed();
            Console.WriteLine(string.Join(",", ListShare.FibonacciOdd));
            ColorAlerts.colorWhite();


            Console.WriteLine();
        }


        
    }
}
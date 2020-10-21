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
            Console.WriteLine($"Az első {input} szám a Fibonacci sorozatból:");
            ColorAlerts.colorGreen();
            for (int i = 0; i < ListShare.FibonacciList.Count; i++)
            {
                Console.Write(ListShare.FibonacciList[i] + (i != (ListShare.FibonacciList.Count - 1) ? "," : ""));
            }
            ColorAlerts.colorWhite();

            Console.WriteLine("\n");

            Console.WriteLine($"Az első {input} szám közül {ListShare.FibonacciEven.Count-1} db páros, 1 db nulla:");

            ColorAlerts.colorBlue();
            for (int i = 0; i < ListShare.FibonacciEven.Count; i++)
            {
                Console.Write(ListShare.FibonacciEven[i] + (i != (ListShare.FibonacciEven.Count - 1) ? "," : ""));
            }
            ColorAlerts.colorWhite();



            Console.WriteLine("\n");

            Console.WriteLine($"Az első {input} szám közül {ListShare.FibonacciOdd.Count} db páratlan:");

            ColorAlerts.colorRed();
            for (int i = 0; i < ListShare.FibonacciOdd.Count; i++)
            {
                Console.Write(ListShare.FibonacciOdd[i] + (i != (ListShare.FibonacciOdd.Count - 1) ? "," : ""));
            }
            ColorAlerts.colorWhite();
            Console.WriteLine();
        }


        
    }
}
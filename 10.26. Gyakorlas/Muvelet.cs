using System;
using System.Collections.Generic;

namespace _10._26.Gyakorlas
{
    class Muvelet {

        List<int> FibonacciList = new List<int>();
        List<int> FibonacciEven = new List<int>();
        List<int> FibonacciOdd = new List<int>();

        public void Do(int input) {
            int a = 0;
            int b = 0;
            int c = a + b;

            if (input == 1)
            {

                a = 0;
                b = 0;
                c = a + b;
                FibonacciList.Add(c);

            }
            else
            {
                for (int i = 0; i < input; i++)
                {
                    if (i == 0)
                    {
                        a = 0;
                        b = 0;
                        c = a + b;
                        FibonacciList.Add(c);
                    }

                    else if (i == 1)
                    {
                        a = 0;
                        b = 1;
                        c = a + b;
                        FibonacciList.Add(c);
                        b = 0;
                    }

                    else if (i > 1)
                    {
                        a = b;
                        b = c;
                        c = a + b;
                        FibonacciList.Add(c);
                    }
                }
            }

            Console.WriteLine($"A fibonacci sorozat első {input} száma a következő:");
            Color.Green();
            Console.WriteLine(string.Join(",", FibonacciList));
            Color.White();
            Console.WriteLine();
        }

        public void selectData(int input)
        {

            for (int i = 0; i < FibonacciList.Count; i++)
            {
                if (FibonacciList[i] % 2 == 0)
                {
                    FibonacciEven.Add(FibonacciList[i]);
                }
                else
                {
                    FibonacciOdd.Add(FibonacciList[i]);
                }
            }

            Console.WriteLine($"A lekért {input} szám közül {FibonacciEven.Count} páros, 1 db nulla:");

            Color.Blue();
            Console.WriteLine(string.Join(",", FibonacciEven));
            Color.White();
            Console.WriteLine();

            Console.WriteLine($"A lekért {input} szám közül {FibonacciOdd.Count} páratlan:");
            Color.Blue();
            Console.WriteLine(string.Join(",", FibonacciOdd));
            Color.White();
            Console.WriteLine();
        }

        public void clearLists() {
            Console.Clear();
            FibonacciList.Clear();
            FibonacciEven.Clear();
            FibonacciOdd.Clear();
        }



    }
}

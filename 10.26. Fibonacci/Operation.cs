﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10._26.Fibonacci
{

    class Operation {

        List<int> FibonacciList = new List<int>();
        List<int> FibonacciEven = new List<int>();
        List<int> FibonacciOdd = new List<int>();

        public void Do(int input)
        {
            int a = 0;
            int b = 0;
            int c = a+b;

            if (input == 1)
            {
                FibonacciList.Add(c);
            }
            else
            {
                for (int i = 0; i < input; i++)
                {
                    switch (i)
                    {
                        case 0:
                            {
                                a = 0;
                                b = 0;
                                c = a + b;
                                FibonacciList.Add(c);
                                break;
                            }
                        case 1:
                            {
                                a = 0;
                                b = 1;
                                c = a + b;
                                FibonacciList.Add(c);
                                b = 0;
                                break;
                            }
                        default:
                            {
                                a = b;
                                b = c;
                                c = a + b;
                                FibonacciList.Add(c);
                                break;
                            }
                    }
                }
            }

            Console.WriteLine($"A Fibonacci sorozat első {input} eleme a következő:");

            Random rnd = new Random();

            foreach (var item in FibonacciList)
            {
                var setColor = rnd.Next(1, 16);

                Console.Write(item + " ");

                Console.ForegroundColor = ((ConsoleColor)setColor);
            }

            Color.White();
            Console.WriteLine("\n");
        }

        public void selectData(int input)
        {
            for (int i = 0; i < FibonacciList.Count; i++)
            {

                if (FibonacciList[i] % 2 == 0 && FibonacciList[i] != 0)
                {
                    FibonacciEven.Add(FibonacciList[i]);
                }
                else if(FibonacciList[i] != 0)
                {
                    FibonacciOdd.Add(FibonacciList[i]);
                }
            }

            Console.WriteLine($"A lekért {input} szám közül 1 db ='0', és {FibonacciEven.Count}db páros:");

            Color.Blue();
            Console.WriteLine(string.Join(",", FibonacciEven));
            Color.White();
            Console.WriteLine();

            Console.WriteLine($"A lekért {input} szám közül {FibonacciOdd.Count} db páratlan:");
            Color.Blue();
            Console.WriteLine(string.Join(",", FibonacciOdd));
            Color.White();
            Console.WriteLine();
        }

        public void clearLists()
        {
            Console.Clear();
            FibonacciList.Clear();
            FibonacciEven.Clear();
            FibonacciOdd.Clear();
        }


    }
}

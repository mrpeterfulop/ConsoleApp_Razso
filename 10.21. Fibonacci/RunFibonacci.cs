using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace _10._21.Fibonacci
{


    public class RunFibonacci
    {

        public void runFibonacci(int input)
        {
            clearAllLists();

            int a = 0;
            int b = 0;
            int c = a + b;

            //0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, 377, 610, 987 …

            if (input == 1)
            {
                
                a = 0;
                b = 0;
                c = a + b;
                ListShare.FibonacciList.Add(c);
                
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
                        ListShare.FibonacciList.Add(c);

                    }
                    else if (i == 1)
                    {
                        a = 0;
                        b = 1;
                        c = a + b;
                        ListShare.FibonacciList.Add(c);
                        b = 0;
                    }

                    else if (i > 1)
                    {
                        a = b;
                        b = c;
                        c = a + b;
                        ListShare.FibonacciList.Add(c);
                    }
                }
            }
        }

        private static void clearAllLists()
        {
            ListShare.FibonacciList.Clear();
            ListShare.FibonacciEven.Clear();
            ListShare.FibonacciOdd.Clear();
        }

        public void selectValues()
        {

            for (int i = 0; i < ListShare.FibonacciList.Count; i++)
            {
                var item = ListShare.FibonacciList[i];
                var even = ListShare.FibonacciEven;
                var odd = ListShare.FibonacciOdd;

                if (item%2 == 0)
                {
                    even.Add(item);
                }
                else 
                {
                    odd.Add(item);
                }

            }

        }
    }
}
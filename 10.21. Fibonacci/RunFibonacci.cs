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
            int b = 1;
            int c = a + b;

            ListShare.FibonacciList.Add(a);
            ListShare.FibonacciList.Add(c);

            for (int i = 0; i < input - 3; i++)
            {
                if (i == 0)
                {
                    a = i;
                    b = i + 1;
                    c = a + b;
                    ListShare.FibonacciList.Add(c);
                }
                a = b;
                b = c;
                c = a + b;
                ListShare.FibonacciList.Add(c);
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
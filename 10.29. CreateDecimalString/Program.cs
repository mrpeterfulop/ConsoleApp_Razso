using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10._29.CreateDecimalString
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Add meg az átalakításra váró karakterláncot:");
            var a = decProcess(Console.ReadLine(), " Euro");
            Console.WriteLine(a);
            Console.ReadKey();
        }

        private static string decProcess(string input, string ending=" Ft")
        {
            var a = input;
            string num;
            string dec;

            a = a.Replace(" ", "");
            a = a.Replace(".", ",");

            var nr = 0;
            for (int i = 0; i < a.Length; i++)
            {
                char ch = a[i];
                if (ch == ',')
                {
                    nr++;
                }
            }


            if (a.Contains(","))
            {
                //Ha több vessző van, redukálja egyre!
                var lastDec = a.LastIndexOf(",");
                a = a.Replace(",", "");
                a = a.Insert((lastDec - nr + 1), ",");

                // Tizedesek külön váalsztása
                var start = a.LastIndexOf(",");
                var end = a.Length - 1 - start;
                dec = "," + a.Substring(start + 1, end);
                num = a.Substring(0, start);
                a = num;
            }
            else
            {
                dec = null;
            }

            var getLength = a.Length;
            double muvelet = (double)getLength / 3;

            for (int i = 0; i < muvelet; i++)
            {
                if (muvelet > 1)
                {
                    if (i != 0)
                    {
                        a = a.Insert(getLength - i * 3, ".");
                    }
                }
            }
            a = a + dec + ending;
            return a;
        }
    }
}

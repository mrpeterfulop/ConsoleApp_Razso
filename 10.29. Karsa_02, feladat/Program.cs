using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10._29.Karsa_02__feladat
{
    class Program
    {
        static void Main(string[] args)
        {

            float sideA = getDataControl("Add meg az 'a' oldal hosszát:", 0, 10000);
            float sideB = getDataControl("Add meg a 'b' oldal hosszát:", 0, 10000);

            float per = perimeter(sideA, sideB);
            float ar = area(sideA, sideB);

            var perString = decProcess(per);
            var areaString = decProcess(ar);


            Console.WriteLine();

            Console.WriteLine($"A téglalap kerülete: {perString} m");
            Console.WriteLine($"A téglalap területe: {areaString} m2");


            Console.ReadKey();

        }


        private static string decProcess(float input) //Lebegőpontos értékek ezres osztályokba bontása
        {
            var a = Convert.ToString(input);

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

            var lastDec = a.LastIndexOf(",");
            a = a.Replace(",", "");
            a = a.Insert((lastDec - nr + 1), ",");

            if (a.Contains(","))
            {
                var start = a.LastIndexOf(",");
                var end = a.Length - 1 - start;
                dec = "," + a.Substring(start+1, end);
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
            a = a + dec;
            return a;
        }


        static float perimeter(float a, float b)
        {
            float pmeter = (float)2 * (a + b);

            return pmeter;
        }

        static float area(float a, float b)
        {
            float area = a * b;
            return area;
        }


        static float getDataControl(string enteringMsg, float dataFrom=float.MinValue, float dataTo = float.MaxValue)
        {
            float myNumber;

            Console.WriteLine(enteringMsg);

            while (!float.TryParse(Console.ReadLine(), out myNumber) || !(myNumber > dataFrom && myNumber < dataTo))
            {

                Console.WriteLine(enteringMsg);
            }


            return myNumber;


        }




    }
}

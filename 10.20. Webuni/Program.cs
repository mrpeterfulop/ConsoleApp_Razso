using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10._20.Webuni
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            float f = 15.6f; // 4 bájt
            double d = f; // 8 bájt

            double d2 = 156.5;
            float f2 = (float) d2; //Típuskényszerítés, castolás

            //parsing --> parsolás
            string strNum = "15";
            int i = int.Parse(strNum);

            // Convert osztály használata

            int i2 = 156;
            short s = Convert.ToInt16(i2);


            // is, as operatorok
            if (strNum is string)
            {
                Console.WriteLine("Ez egy string");
            }

            object obj = strNum as object;
            */


            //Fontosabb matematikai függvények

            var a = 25;
            double sqrt = Math.Sqrt(a); //Gyökvonás
            Console.WriteLine($"Érték: {a}. Gyökvonás eredménye: {sqrt}");

            var b1 = 2;
            var b2 = 6;
            double pow = Math.Pow(b1, b2); //Hatványozás 2 a 6-on
            Console.WriteLine($"Hatvány alap: {b1}, kivető: {b2}. Hatványozás eredménye: {pow}");

            var c = 15.55;
            double round = Math.Round(c); //Kerekítés, matematikai szabályok szerint
            Console.WriteLine($"Érték: {c}. Kerekítés eredménye: {round}");


            var d = 15.8;
            double floor = Math.Floor(d); //Kerekítés, kizárólag felfelé
            Console.WriteLine($"Érték: {d}. Felfele kerekítés eredménye: {floor}");

            var e = 15.2;
            double ceiling = Math.Ceiling(e);//Kerekítés, kizárólag lefelé
            Console.WriteLine($"Érték: {e}. Lefele kerekítés eredménye: {ceiling}");

            Console.WriteLine();

            /* Írjunk programot, ami bekér a felhasználótól egy 3-mal, és 5-tel is osztható számot.
               Ha a felhasználó nem a feltételnek megfelelő számot ad meg, írjunk hibaüzenetet, és ismételjük meg a bekérést!
            */

            /*
            int num;
            bool again;

            do
            {
                Console.WriteLine("Adj meg egy öttel, és hárommal osztható számot:");
                num = int.Parse(Console.ReadLine());
                if (num % 5 == 0 & num % 3 == 0)
                {
                    again = false;
                }
                else
                {
                    Console.WriteLine("Nem megfelelő számot adtál meg!");
                    again = true;
                }

            } while (again == true);

            */

            int[] array = { 3, 1, 11, 4, 5, 84, 4, 8, 7, 60, 2, 9, 8, 12, 854, 87, 12, 6, 65, 77 };
            int counter = 0;
            int rule = 20;
            int sum = 0;
            int sumRule = 0;
            int min = array[0];
            int max = array[0];

            List <int> ruleArray = new List<int>();

            Console.WriteLine("A tömb elemei:");
            foreach (var item in array)
            {
               Console.Write(item + ",");
            }

            Console.WriteLine();

            for (int i = 0; i < array.Length; i++)
            {
                sum += array[i];

                if (array[i] > rule)
                {
                    counter++;
                    ruleArray.Add(array[i]);
                    sumRule += array[i];
                }

                if (array[i] > max)
                {
                    max = array[i];
                }

                if (array[i] < min)
                {
                    min = array[i];
                }
            }



            Console.WriteLine($"A tömb elemeinek összege: {sum}.\n" +
                $"A tömb legnagyobb értéke: {max}.\n" +
                $"A tömb legkisebb értéke: {min}.\n" +
                $"A tömb elemei közül {counter} db nagyobb, mint {rule}.\n" +
                $"A kivételek összege: {sumRule}.\n" +
                $"A kivételek a következő elemek:");


            
            foreach (var item in ruleArray)
            {
                Console.Write(item + ",");

            }
            

            Console.ReadKey();

        }
    }
}

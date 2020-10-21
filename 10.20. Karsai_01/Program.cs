using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10._20.Karsa_01
{
    class Program
    {
        static void Main(string[] args)
        {


            Console.Title = "ablak";

            //Console.ForegroundColor = ConsoleColor.Green;
            //Console.BackgroundColor = ConsoleColor.Blue;
            //Console.Clear(); //Ablak tartalmának törlése
            //Console.ResetColor();
            //Console.Beep(400, 1000);


            Console.SetWindowSize(80, 25);

            // int m = Console.WindowHeight; int sz = Console.WindowWidth; //Console.SetCursorPosition(sz / 2, m / 2);


            //Az ablak méretét adhatom meg.
            /*
            // Végtelen ciklus, ami kiírja az aktuális ablak méretét
            while (true)
            {
                int m = Console.WindowHeight;
                int sz = Console.WindowWidth;
                Console.WriteLine(m + "*" + sz);
            }
            */


            // Convert.To... , castolás
            int szam1 = 5;
            int szam2 = 120;

            double maradek = (double)szam1 / szam2;
            double maradek2 = Convert.ToDouble(szam1) / szam2;

            //Console.WriteLine(maradek);
            //Console.WriteLine(maradek2);


            //Szelekciók, elágazás, switch
            /////////////////////////////////////////////////
            /*
            Console.WriteLine("Dobj egy számot!");
            int dobottszam = int.Parse(Console.ReadLine());

            switch (dobottszam)
            {
                case 1:
                    Console.WriteLine("A dobott szám: Egy"); break;
                case 2:
                    Console.WriteLine("A dobott szám: Kettő"); break;
                case 3:
                    Console.WriteLine("A dobott szám: Három"); break;
                case 4:
                    Console.WriteLine("A dobott szám: Négy"); break;
                case 5:
                    Console.WriteLine("A dobott szám: Öt"); break;
                case 6:
                    Console.WriteLine("A dobott szám: Hat"); break;
                default:
                    Console.WriteLine("Dobj újra!"); break;
     
            }
            */
            /////////////////////////////////////////////////

            // While, elől tesztelő ciklus
            ////////////////////////////////////////////////
            /*
            int meddig = int.Parse(Console.ReadLine());
            int parosszam = 0;
            int osszeg = 0;
            while (parosszam < meddig)
            {
                parosszam += 1;
                Console.Write(parosszam + ", ");
                osszeg = parosszam + osszeg;
            }

            Console.WriteLine(osszeg);
            */
            /////////////////////////////////////////////////



            // Összetett adatszerkezetek, tömbök
            //////////////////////////////////////////////////
            /*
            int[] myArray = new int[10];

            Random rnd = new Random();

            Console.WriteLine("A random számokkal feltöltött tömböm elemei:");
            for (int i = 0; i < 10; i++)
            {
                
                myArray[i] = rnd.Next(1, 1000);
            }

            foreach (var item in myArray)
            {
                Console.Write(item+",");
            }
            Console.WriteLine("\n");


            var sum = Convert.ToString(myArray.Sum());

            Console.WriteLine($"A tömb elemeinek száma: {myArray.Length}\n" +
                $"A tömb legnagyobb értéke: {myArray.Max()}\n" +
                $"A tömb legkisebb értéke: {myArray.Min()}\n" +
                $"A tömb első eleme: {myArray[0]}\n" +
                $"A tömb utolsó eleme: {myArray[myArray.Length-1]}\n"+
                $"A tömb elemeinek összege: {myArray.Sum()}\n" +
                $"A tömb összegének karakterhossza: {sum.Length}\n" +
                $"A tömb összegének karakterei:"
                );

            foreach (var item in sum)
            {
                Console.Write(item + ",");
            }


            Console.WriteLine();

            int sumSUM = 0;
            
            for (int j = 0; j < sum.Length; j++)
            {
                var a = int.Parse(sum[j].ToString()); //A sum változó konvertálása char > Int!
                sumSUM += a;

            }

            Console.WriteLine($"A tömb összegének karakterösszege: {sumSUM}\n");

            */
            //  FELADAT  //////////////////////////////////////////////////


            int[] bevetel = new int[365];
            int[] kiadas = new int[365];
            int[] haszon = new int[365];

            Random rnd = new Random();



            for (int i = 0; i < bevetel.Length; i++)
            {
                bevetel[i] = rnd.Next(4000, 12001);
                kiadas[i] = rnd.Next(2000, 4001);

            }

            for (int i = 0; i < bevetel.Length; i++)
            {
                haszon[i] = bevetel[i] - kiadas[i];

            }

            Console.WriteLine("Tiszta haszon az év 365 napjára bontva:");

            var day = 0;
            foreach (var item in haszon)
            {
                day += 1;
                Console.WriteLine($"Bevétel a(z){day}. napon: {item}");
            }

            var indexAtMax = haszon.ToList().IndexOf(haszon.Max()) + 1;
            var indexAtMin = haszon.ToList().IndexOf(haszon.Min()) + 1;

            var haszonMax = haszon.Max();
            var haszonMin = haszon.Min();
            var haszonAll = haszon.Sum();

            var a = Convert.ToString(haszonMax);
            var b = Convert.ToString(haszonMin);
            var c = Convert.ToString(haszonAll);


            c = tizedesOsztalyozas(c);
            b = tizedesOsztalyozas(b);
            a = tizedesOsztalyozas(a);

            Console.WriteLine($"Összes bevételem az évben: {c} Ft\n" +
            $"A legtöbb bevételem: {b} Ft, az év {indexAtMax}. napján.\n" +
            $"A legkevesebb bevételem: {a} Ft, az év {indexAtMin}. napján.\n");



            Console.ReadLine();

        }

        private static string tizedesOsztalyozas(string input)
        {
            var getLength = input.Length;
            double muvelet = (double)getLength / 3;
            
            for (int i = 0; i < muvelet; i++)
            {
                if (muvelet > 1)
                {
                    if (i != 0)
                    {
                        input = input.Insert(getLength - i * 3, ".");
                    }
                }
            }

            return input;
        }
    }
}

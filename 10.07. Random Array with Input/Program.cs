using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10._07.Random_Array_with_Input
{
    class Program
    {

      /*
      Feladat
      Készíts programot, ami bekér a felhasználótól egy egész számot.Ennek a felhasználásával készíts egy olyan sorozatot, amit véletlen számokkal(1-1000) tölt fel a program.Ellenőrizze, hogy a felhasználó csak egész számot (mást nem) adott meg.
          • írasd ki a sorozat utolsó elemét
          • írasd ki a sorozat eredményét egy sorba
          • írasd ki a legnagyobb értékét
          • írasd ki a legkisebb értékét
          • rendezd a sorozatot növekvő sorrendbe
        A feladat megoldásához használj osztályt, függvényt, ciklust.A kiíratásokat a megadott sorrendbe végazd el!
        */
        static void Main(string[] args)
        {
            /*
            //int numVal = 0;

            Console.Write("Kérlek adj meg egy pozitív egész számot:\n");
            var myNumber = Console.ReadLine();
            var test = Convert.ToDecimal(myNumber);
            //numVal = Convert.ToInt32(myNumber);

                      
            if (test> 1)
            {
                Console.WriteLine("Érvényes értéket adtál meg!");
            }
            else
            {
                Console.WriteLine("A megadott szám hibás!");
            }
            

            Console.ReadKey();
            */


            /*
             
            int numVal = -1;
            bool repeat = true;

            while (repeat)
            {
                Console.Write("Enter a number between −2,147,483,648 and +2,147,483,647 (inclusive): ");

                string input = Console.ReadLine();

                // ToInt32 can throw FormatException or OverflowException.
                try
                {
                    numVal = Convert.ToInt32(input);
                    if (numVal < Int32.MaxValue)
                    {
                        Console.WriteLine($"Az érték: {numVal}");
                    }
                    else
                    {
                        Console.WriteLine("numVal cannot be incremented beyond its current value");
                    }

                }
                catch (FormatException)
                {
                    Console.WriteLine("Input string is not a sequence of digits.");
                }
                catch (OverflowException)
                {
                    Console.WriteLine("The number cannot fit in an Int32.");
                }

                Console.Write("Go again? Y/N: ");
                string go = Console.ReadLine();
                if (go.ToUpper() != "Y")
                {
                    repeat = false;
                }
            }
            */
            


          // var fill = new FillArray();
           //fill.fillData();

            var print = new PrintData();
            print.writeAll();

           Console.WriteLine("Program vége");



           Console.ReadLine();

        }
    }
}

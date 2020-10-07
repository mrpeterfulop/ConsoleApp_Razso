using System;
using System.Linq;
namespace _10._07.Random_Array_with_Input
{
    internal class PrintData
    {

        public void writeAll() {

            var alert = new ColorAlerts();

            //1. írasd ki a sorozat utolsó elemét
            var array = new FillArray();
            array.fillData();

            int lastElement = array.myArray.Length-1;
            alert.colorWhite();
            Console.WriteLine($"A sorozat utolsó eleme:");
            alert.colorBlue();
            Console.WriteLine($"{array.myArray[lastElement]}\n");

            //2. írasd ki a sorozat eredményét egy sorba
            
            alert.colorWhite();
            Console.WriteLine("A sorozat elemei:");
            alert.colorBlue();
            foreach (var item in array.myArray)
            {
                Console.Write($"{item},");
            }
            Console.WriteLine("\n");

            //3. írasd ki a legnagyobb értékét
            int maxValue = array.myArray.Max();
            alert.colorWhite();
            Console.WriteLine($"A sorozat legnagyobb értéke:");
            alert.colorBlue();
            Console.WriteLine($"{maxValue}\n");

            //4. írasd ki a legkisebb értékét
            alert.colorWhite();
            int minValue = array.myArray.Min();
            Console.WriteLine($"A sorozat legkisebb értéke:");
            alert.colorBlue();
            Console.WriteLine($"{minValue}\n");

            //5. rendezd a sorozatot növekvő sorrendbe
            Array.Sort(array.myArray);
            alert.colorWhite();
            Console.WriteLine("A sorozat elemei növekvő sorrendben:");
            alert.colorBlue();
            foreach (var item in array.myArray)
            {
                Console.Write($"{item},");
            }
            Console.WriteLine("\n");
            alert.colorWhite();
        }
    }
}
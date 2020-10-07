using System;
using System.Linq;
namespace _10._07.Random_Array_with_Input
{
    internal class PrintData
    {

        public void writeAll()
        {

            var alert = new ColorAlerts();
            var array = new FillArray();
            array.fillData();

            Write1(alert, array);
            Write2(alert, array);
            Write3(alert, array);
            Write4(alert, array);
            Write5(alert, array);
        }

        private static void Write5(ColorAlerts alert, FillArray array)
        {
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

        private static void Write4(ColorAlerts alert, FillArray array)
        {
            //4. írasd ki a legkisebb értékét
            alert.colorWhite();
            int minValue = array.myArray.Min();
            Console.WriteLine($"A sorozat legkisebb értéke:");
            alert.colorBlue();
            Console.WriteLine($"{minValue}\n");
        }

        private static void Write3(ColorAlerts alert, FillArray array)
        {
            //3. írasd ki a legnagyobb értékét
            int maxValue = array.myArray.Max();
            alert.colorWhite();
            Console.WriteLine($"A sorozat legnagyobb értéke:");
            alert.colorBlue();
            Console.WriteLine($"{maxValue}\n");
        }

        private static void Write2(ColorAlerts alert, FillArray array)
        {
            //2. írasd ki a sorozat eredményét egy sorba
            alert.colorWhite();
            Console.WriteLine("A sorozat elemei:");
            alert.colorBlue();
            foreach (var item in array.myArray)
            {
                Console.Write($"{item},");
            }
            Console.WriteLine("\n");
        }

        private static void Write1(ColorAlerts alert, FillArray array)
        {
            //1. írasd ki a sorozat utolsó elemét
            int lastElement = array.myArray.Length - 1;
            alert.colorWhite();
            Console.WriteLine($"A sorozat utolsó eleme:");
            alert.colorBlue();
            Console.WriteLine($"{array.myArray[lastElement]}\n");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10._06.Imput_Data
{
    class Program
    {
        static void Main(string[] args)
        {
            var today = DateTime.Now;
            var hour = today.Hour;
            var minute = today.Minute;



            var run = new GetUserData();

            var name = run.Data();


             do
             {
                run.Data();

                if (name.Length <= 2)
                 {
                    Console.WriteLine(name);
                     colorRed();
                     Console.Write("A neved nem lehet rövidebb 3 karakternél!\n");
                     colorWhite();
                 }
                 else
                 {
                     colorGreen();
                     greetings(hour, minute, run.Data());
                 }

             } while (name.Length <= 2);

            Console.WriteLine(name.Length);
             colorWhite();


             

            Console.ReadLine();

        }



        private static void greetings(int hour, int minute, string userName)
        {
            if (hour >= 5 & hour <= 12)
            {
                Console.WriteLine($"Jó reggelt {userName}! Az aktuális idő: {hour}:{minute}");
            }
            else if (hour >= 12 & hour <= 18)
            {
                Console.WriteLine($"Szép napot {userName}! Az aktuális idő: {hour}:{minute}");
            }

            else
            {
                Console.WriteLine($"Jó estét {userName}! Az aktuális idő: {hour}:{minute}");
            }
        }

        private static void colorWhite()
        {
            Console.ForegroundColor = ConsoleColor.White;
        }

        private static void colorGreen()
        {
            Console.ForegroundColor = ConsoleColor.Green;
        }

        private static void colorRed()
        {
            Console.ForegroundColor = ConsoleColor.Red;
        }

 




    }
}

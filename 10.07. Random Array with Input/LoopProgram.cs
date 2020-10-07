using System;

namespace _10._07.Random_Array_with_Input
{
    internal class LoopProgram
    {

        internal void start()
        {
            bool run = true;


            while (run)
            {
                var color = new ColorAlerts();
                var print = new PrintData();
                print.writeAll();
                run = false;

                color.colorGreen();
                Console.WriteLine("Újra szeretnéd indítani?(Y + ENTER)");
                color.colorRed();
                Console.WriteLine("A befejezéshez nyomj meg egy tetszőelges gombot!");
                color.colorWhite();

                var a = Console.ReadLine();

                if (a.ToUpper() == "Y")
                {
                    run = true;
                }
                else
                {
                    run = false;
                    Console.WriteLine("A befejezéshez: tetszőleges gomb + ENTER!");
                }
            }
        }
    }
}
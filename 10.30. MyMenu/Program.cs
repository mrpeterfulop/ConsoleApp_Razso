using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10._30.MyMenu
{
    class Program
    {

        static ConsoleColor color = ConsoleColor.Blue;
        static int index = 0;
        static bool  runMenu;

        enum myMenu
        {
            _Belépés,
            _Különböző_feladatatok,
            _Extra,
            _Kilépés
        };

        static void Main(string[] args)
        {
            string[] menu = Enum.GetNames(typeof(myMenu));

            var spc = menu.Max().Length + 50;
            Console.Title = "Menubar";
            Console.CursorVisible = false;

            /*
            do
            {
            Write(spc, runMenu);
            } while (runMenu == true);
            */

            runMenu = true;

            while (runMenu == true)
            {
                Console.WriteLine("fut");
                Write(spc, runMenu);
            }

            Console.WriteLine("Stop");
        }

        static void Write(int spc, bool runMenu)
        {
    
            for (int i = 0; i < 4; i++)
            {

                if(i == index)
                {

                    Console.BackgroundColor = color;
                    Console.WriteLine(((myMenu)i).ToString().PadRight(spc));
                    Console.ResetColor();

                }
                else
                {
                    Console.WriteLine(((myMenu)i).ToString().PadRight(spc));
                }
            }
            Control(runMenu);
            Console.Clear();

        }

 

        static void Control(bool runMenu)
        {

            ConsoleKey ck = Console.ReadKey().Key;
            switch (ck)
            {
                case ConsoleKey.UpArrow:
                    if (index-- == 0)
                    {
                        index = 3;
                    }

                    break;
                case ConsoleKey.DownArrow:
                    if (index++ == 3)
                    {
                        index = 0;
                    }

                    break;
                case ConsoleKey.Enter:
                    runMenu = false;
                    color = ConsoleColor.Red;
                    Console.Clear();
                    Console.WriteLine("Program vége");
                    
                    break;
            }


        }
    }
}

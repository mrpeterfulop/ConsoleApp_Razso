using System;

namespace _10._06.Input_Data__Classes
{
    public class accept
    {
       public string name;

              
        public void acceptdetails()

        {

            do
            {
                Console.Write("Szia! Kérlek add meg a felhasználóneved:\t");
                name = Console.ReadLine();

                if (name.Length <= 2)
                {
                    colorRed();
                    Console.Write("A neved nem lehet rövidebb 3 karakternél!\n");
                    colorWhite();
                }
                else
                {
                    colorGreen();
                }

            } while (name.Length <= 2);

        }
        public void colorWhite()
        { Console.ForegroundColor = ConsoleColor.White; }

        public void colorGreen()
        { Console.ForegroundColor = ConsoleColor.Green; }

        public void colorRed()
        { Console.ForegroundColor = ConsoleColor.Red; }

        

    }
}
using System;

namespace _10._06.Input_Data__Classes
{
    public class print
    {

        public void printdetails()
        {
            //Creating object of 1st. class
            var a = new accept();
            var time = new myTime();

            //executing method of 1st class.
            a.acceptdetails();
            time.checkTheTime();

            //Printing value of name variable
            Console.WriteLine("----------------------------------------------------------------");
            Console.WriteLine($"{time.greating} {a.name}! Belépésed időpontja: {time.timeNow}");
            Console.WriteLine("----------------------------------------------------------------");

            
            string text = System.IO.File.ReadAllText(@"C:\Users\Mrpet\Documents\database.txt");

            // Display the file contents to the console. Variable text is a string.
            Console.WriteLine($"Contents of WriteText.txt:\n{text}");
            

            /*
            string[] lines = System.IO.File.ReadAllLines(@"C:\Users\Mrpet\Documents\database.txt");

            // Display the file contents by using a foreach loop.
            Console.WriteLine("Contents of WriteLines2.txt:");
            foreach (string line in lines)
            {
                // Use a tab to indent each line of the file.
                Console.WriteLine("\t" + line + "|");
            }
            */
            // Keep the console window open in debug mode.
            Console.WriteLine("Press any key to exit.");


            a.colorWhite();
        }
    }
}
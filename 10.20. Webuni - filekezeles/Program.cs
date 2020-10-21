using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace _10._20.Webuni___filekezeles
{
    class Program
    {
        static void Main(string[] args)
        {

            List<string> shoppingList = new List<string>()
            {
                "Tej",
                "Vaj",
                "Kenyér",
                "Felvágott",
                "Gyümölcs",
                "Élesztő",
                "Gomba",
                "Liszt"
            };

            //ASCII 7bites 128char
            // UNICODE 2 bájt, 65536 char
            // UTF-8 2,3,4 változó hsszúságú karakterkódolás


            StreamWriter sw = new StreamWriter(@"d:\IT\bevasarlolista.txt");

            foreach (var item in shoppingList)
            {
                sw.WriteLine("- " + item);
            }

            sw.Flush();
            sw.Close();

            StreamReader sr = new StreamReader(@"d:\IT\bevasarlolista.txt", Encoding.UTF8);

            while (!sr.EndOfStream)
            {
                Console.WriteLine(sr.ReadLine());
            }

            sr.Close();



            Console.ReadKey();
        }   
    }
}

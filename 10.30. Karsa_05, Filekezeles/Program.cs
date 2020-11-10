using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _10._30.Karsa_05__Filekezeles
{
    class Program
    {
        static void Main(string[] args)
        {


            Console.WriteLine("Alapszintű filekezelés ////////////////////////////////////");

            StreamWriter sw = new StreamWriter(@"empytestfile.txt"); //a meghajtó betűjele KICSI legyen!!! A file tartalma teljes mértékben törlődik, és felülírja a lentiek szerint

            sw.WriteLine("Alma");
            sw.WriteLine("Körte");
            sw.WriteLine("Banán");
            sw.WriteLine("Dinnye");

            StreamReader sr = new StreamReader(@"pc_list.txt");  //Alapesetben 1 sort olvas be.
            string list = sr.ReadLine();
            Console.WriteLine(list);

            List<string> readList = new List<string>();

            while (!sr.EndOfStream) // EndOfStream metódussal addig olvas be, amíg van sor a doksiban!
            {
                string listEndOf = sr.ReadLine();
                readList.Add(listEndOf);
            }


            Console.WriteLine(string.Join("\n",readList));

            sw.Flush(); //Puffer ürítése
            sw.Close(); // bezárása a filebaírás folyamatnak

            Console.ReadKey();
        }
    }
}

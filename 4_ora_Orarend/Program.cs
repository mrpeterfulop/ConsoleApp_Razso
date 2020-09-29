using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4_ora_Orarend
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Válassz egy napot hétfő és péntek között!");

            var input = Console.ReadLine().ToLower();
            var hetfo = "Hétfői órarend:" + "\n" + "Matek" + "\n" + "Angol" + "\n" + "Tesi" + "\n" + "Földrajz";
            var kedd = "Keddi órarend";
            var szerda = "Szerdai órarend";
            var csutortok = "Csütörtöki órarend";
            var pentek = "Pénteki órarend";

            if (input == "Hétfő".ToLower())
            {
                Console.WriteLine(hetfo);
            }
            else if (input == "Kedd".ToLower())
            {
                Console.WriteLine(kedd);

            }
            else if (input == "Szerda".ToLower())
            {
                Console.WriteLine(szerda);

            }
            else if (input == "Csütörtök".ToLower())
            {
                Console.WriteLine(csutortok);

            }
            else if (input == "Péntek".ToLower())
            {
                Console.WriteLine(pentek);

            }


            Console.ReadLine();


        }
    }
}

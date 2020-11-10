using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11._10.Órai_munka
{


    class Program
    {
        static void Main(string[] args)
        {

            string txt = GetText.GetTextOnly();
            Console.WriteLine($"A megadott szöveg: {txt}");

            Console.ReadKey();
        }
        
        
    }
}

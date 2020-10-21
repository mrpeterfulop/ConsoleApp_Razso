using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _10._20.Webuni___Structure
{
    class Program
    {

        static void Main(string[] args)
        {



            string fileName = @"pc_list.txt";

            PC pc = new PC();

            pc.DisplayPC(fileName);

            Console.ReadKey();

        }
    }
}

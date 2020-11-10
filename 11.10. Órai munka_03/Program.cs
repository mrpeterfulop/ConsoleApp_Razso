using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace _11._10.Órai_munka_03
{

    class Program
    {
        static void Main(string[] args)
        {
            /* ELSŐ PÉLDA
            string filePath = @"c:\Users\xqsmb8\Documents\C#\data.txt";
            FileStream fs = new FileStream(filePath, FileMode.Open);
            StreamReader sr = new StreamReader(fs, Encoding.Default);

            while (!sr.EndOfStream)
            {
                var line = sr.ReadLine();
                Console.WriteLine(line);
            }

            sr.Close();
            fs.Close();
            */


            string filePath = @"c:\Users\xqsmb8\Documents\C#\data.txt";

            using (FileStream fs = new FileStream(filePath, FileMode.Open))
            {
                using (StreamReader sr = new StreamReader(fs, Encoding.Default))
                {
                    while (!sr.EndOfStream)
                    {
                        var line = sr.ReadLine();
                        Console.WriteLine(line);
                    }
                }
            }

            Console.ReadKey();
        }

    }
}

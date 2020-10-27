using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace _10._26.PhotoSearchApp
{
    class Program
    {
        static void Main(string[] args)
        {

            //var ext = Console.ReadLine();

            /*
            string[] files = Directory.GetFileSystemEntries(rootdir, $"*.{ext}", SearchOption.AllDirectories);
            */
            /*
             *
            List<string> files = new List<string>();

            string [] f = Directory.GetFileSystemEntries(rootdir, $"*.{ext}", SearchOption.AllDirectories);

            for (int i = 0; i < f.Length; i++)
            {
                files.Add(f[i]);
                Console.WriteLine(Path.GetFileName(f[i]));
            }

          */


            //Console.WriteLine(String.Join(Environment.NewLine, files));


            string path = @"D:\Untitled Export\2020\07.18. Fruzsi és Ákos - ESKÜVŐ\02 Kreatív\Original\DHU08421.jpg";

            var name = Path.GetFileName(path);
            var pathonly = Path.GetDirectoryName(path);

            Console.WriteLine(name);
            Console.WriteLine(pathonly);

            Console.ReadKey();

        }
    }
}

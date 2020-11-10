using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace _10._12.Select_and_Copy_files
{
    public class SyncArrays
    {
        
        public List <string> syncArrays(string[] neededFiles, string rootPath) //PART 2.
        {

            LoadClientFiles r = new LoadClientFiles();

            List<string> myFiles = new List<string>();
            List<string> failedFiles = new List<string>();

            Console.WriteLine($"\nSzükséges fileok száma: {neededFiles.Length} db");

            var cntr = 0;

            while (cntr < neededFiles.Length)
            {
                var name = Path.GetFileName(neededFiles[cntr]);

                string[] rootDirectory = Directory.GetFiles(rootPath, name, SearchOption.AllDirectories);

                try
                {
                    myFiles.Add(rootDirectory[0]);
                    cntr++;
                }
                catch (Exception)
                {
                    string fileToRemove = name;
                    neededFiles = neededFiles.Where(val => val != fileToRemove).ToArray();
                    Console.WriteLine($"A következő file nem található: {name}");
                    failedFiles.Add(name);
                }

            }


            if (failedFiles.Count != 0)
            {
                Console.WriteLine("\nA következő elemeket nem kerülnek másolásra:");
                foreach (var item in failedFiles)
                {
                    Console.WriteLine(item);
                }
            }
            return  myFiles;
        }


    }
}

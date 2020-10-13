using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace _10._12.Select_and_Copy_files
{
    class Program
    {
        static void Main(string[] args)
        {

            //var rootPath = @"D:\Untitled Export\2020\09.18. Marietta és Gyuri - ESKÜVŐ";
            //var newPath = @"C:\Project Manager-old\Edit\To\Képek\New\";

            Console.WriteLine("Add meg a főkönyvtár elérési útját:");
            string rootPath = Console.ReadLine();
            Console.WriteLine("Add meg az ügyfél fileok elérési útját:");
            var clientPath = Console.ReadLine();


            try
            {
                string[] neededFiles = loadClientFiles(clientPath); // PART 1.
                summaryFiles(neededFiles); // PART 2.
                string[] myFiles = createPufferArray(rootPath, neededFiles); // PART 3.
                forkArrays(rootPath, neededFiles, myFiles); // PART 4.
                copyTheFiles(myFiles, rootPath); // PART 5.

                Console.WriteLine("Művelet vége!");

            }

            catch (FileNotFoundException) //Nem létező file
            {
                Console.WriteLine("Hiba!");
            }

            catch (DirectoryNotFoundException) //Nem létező elérési út
            {

            }

            catch (IOException)
            {
                Console.WriteLine($"A file már szerepel a célkönyvtárban!");
            }


            Console.ReadKey();

        }

        private static void forkArrays(string rootPath, string[] neededFiles, string[] myFiles)
        {
            for (int k = 0; k < neededFiles.Length; k++)
            {
                var searchFile = neededFiles[k];

                //************** File név ***********************************************
                var name = searchFile.Substring((searchFile.LastIndexOf(@"\") + 1), (searchFile.Length) - (searchFile.LastIndexOf(@"\") + 1));

                string[] rootDirectory = Directory.GetFiles(rootPath, name, SearchOption.AllDirectories);
                myFiles[k] = rootDirectory[0];

            }
        }

        private static string[] createPufferArray(string rootPath, string[] neededFiles)
        {
            string[] puffer = Directory.GetFiles(rootPath, "*.jpg", SearchOption.AllDirectories);
            string[] myFiles = new string[neededFiles.Length];

            Console.WriteLine($"Főkönyvtári fileok száma: {puffer.Length} db");
            Console.WriteLine($"Szükséges fileok száma: {neededFiles.Length} db");
            return myFiles;
        }

        private static void summaryFiles(string[] neededFiles)
        {
            for (int j = 0; j < neededFiles.Length; j++)
            {
                var patchFile = neededFiles[j];

                //************** File név ***********************************************
                var name = patchFile.Substring((patchFile.LastIndexOf(@"\") + 1), (patchFile.Length) - (patchFile.LastIndexOf(@"\") + 1));

                //************** Kiterjesztés *******************************************
                int extStart = patchFile.LastIndexOf(".") + 1;
                int extensionLength = patchFile.Length - extStart;
                var Extension = patchFile.Substring(extStart, extensionLength);

                //************** Új file név ********************************************
                int endOfName = patchFile.LastIndexOf("-");
                string firstPart = patchFile.Substring(0, endOfName);
                string newName = firstPart + "." + Extension;

                neededFiles[j] = newName; //A tömböm elemeinek adom az új nevet

            }
        }

        private static string[] loadClientFiles(string clientPath)
        {

            //Fileok, amikre szükségem van
            string[] neededFiles = Directory.GetFiles(clientPath, "*.jpg", SearchOption.AllDirectories);

            for (int i = 0; i < neededFiles.Length; i++)
            {
                var patchFrom = neededFiles[i];
                var name = patchFrom.Substring((patchFrom.LastIndexOf(@"\") + 1), (patchFrom.Length) - (patchFrom.LastIndexOf(@"\") + 1));
            }

            return neededFiles;
        }

        private static void copyTheFiles(string[] myFiles, string rootPath)
        {

            Console.WriteLine("A célkönyvtár alapértelmezett eléréi útja:\n"+$@"{rootPath}EXPORT\"+"\nElfogad: (Y), Módosít: (N)");
            string endPath;
            var answ = Console.ReadLine();
            if (answ.ToUpper() == "Y")
            {
                var home = @"EXPORT\";
                endPath = rootPath + home;
                bool existsDirectory = Directory.Exists(endPath);

                if (existsDirectory == false)
                {
                    Directory.CreateDirectory(endPath);
                    Console.WriteLine($"Az elérési út {endPath} létrehozva!");

                }

            }
            else if (answ.ToUpper() == "N")
            {
  

                Console.WriteLine("Add meg a célkönyvtár elérési útját:");
                endPath = Console.ReadLine();
                Console.WriteLine($"Az elérési út {endPath} létrehozva!");

            }
            else
            {
                var home = @"EXPORT\";
                endPath = rootPath + home;
            }



            for (int i = 0; i < myFiles.Length; i++)
            {

                var item = myFiles[i];

                //************** File név ***********************************************
                var name = item.Substring((item.LastIndexOf(@"\") + 1), (item.Length) - (item.LastIndexOf(@"\") + 1));


                var copyFrom = myFiles[i];
                var pasteTo = endPath + name;

                File.Copy(copyFrom, pasteTo);

            }
        }
    }
}

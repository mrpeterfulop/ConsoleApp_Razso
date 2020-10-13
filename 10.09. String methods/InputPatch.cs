using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace _10._09.String_methods
{
    internal class InputPatch
    { 

        public string[] extensionFile = new string[] { };
        bool stopLoop = false;

        public void Patch()
        {

            extensionFile = File.ReadLines(@"C:\Users\mrpet\Documents\textExtensions.txt").ToArray();

            string patch;
            string fileName;
            string fileExtension;
            string textFile;
            bool validExt;

            do
            {

                Console.WriteLine("Kérlek add meg a dokumentum elérési útját:");
                patch = Console.ReadLine();
                int locateLength = patch.Length;

                int extStart = patch.LastIndexOf(".") + 1;
                int fileNameStart = patch.LastIndexOf(@"\") + 1;

                int extensionLength = locateLength - extStart;
                int fileNameLength = locateLength - fileNameStart;

                fileExtension = patch.Substring(extStart, extensionLength);
                fileName = patch.Substring(fileNameStart, fileNameLength - extensionLength - 1);

                textFile = File.ReadAllText($@"{patch}");
                validExt = Array.IndexOf(extensionFile, fileExtension) >= 0;

                if (validExt == false)
                {
                    Console.WriteLine("A kiterjesztés nem megfelelő!");
                }


            } while (validExt == false);

            stopLoop = true;
            Console.WriteLine($"\nA file neve: {fileName}");
            Console.WriteLine($"A file kiterjesztés: {fileExtension}");
            Console.WriteLine();
            Console.Write($"A tallózott {fileName} dokumentum tartalma:\n{textFile}");

        }


        public void loopPatch() 
        {

            do
            {
                try
                {
                    Patch();
                }

                catch (ArgumentOutOfRangeException)
                {

                    Console.WriteLine("Hiba az elérési útvonalban!");
                }
                catch(ArgumentException) 
                {
                    Console.WriteLine("Érvénytelen karaktert tartalmaz az útvonal!");
                }

                catch (UnauthorizedAccessException)
                {
                    Console.WriteLine("Hiba az elérési útvonalban!");
                }

            } while (stopLoop == false);

        }

    }

    
}


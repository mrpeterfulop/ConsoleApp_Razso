using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace _10._12.Select_and_Copy_files
{
    class CopyTheFiles
    {
        public void copyTheFiles(List <string> myFiles, string rootPath) //PART 3.
        {

            var home = @"BOOK\";

            Console.WriteLine("\nA célkönyvtár alapértelmezett eléréi útja:\n" + $@"{rootPath}{home}" + "\nElfogad: (Y), Módosít: (N)");
            string endPath;

            var answ = Console.ReadLine();

            if (answ.ToUpper() == "Y")
            {
                endPath = rootPath + home;
                bool existsDirectory = Directory.Exists(endPath);

                if (existsDirectory == false)
                {
                    Directory.CreateDirectory(endPath);
                }

            }
            else if (answ.ToUpper() == "N")

            {
                Console.WriteLine("\nAdd meg a célkönyvtár elérési útját:");
                endPath = Console.ReadLine();
                Directory.CreateDirectory(endPath);
            }

            else
            {
                endPath = rootPath + home;
            }

            /////////////////////////////////////////////////////////////////
            List<string> existFiles = new List<string>();
            bool isExist = false;

            for (int i = 0; i < myFiles.Count; i++)
            {
                var fileName = Path.GetFileName(myFiles[i]);
                var fileExist = File.Exists(endPath + fileName);

                if (fileExist)
                {
                    existFiles.Add(endPath + fileName);
                    isExist = true;
                }
            }
            //////////////////////////////////////////////////////////////////
            

            if (isExist)
            {
                Console.WriteLine($"A következő {existFiles.Count} file már szerepel a célkönyvtárban:");
                foreach (var item in existFiles)
                {
                    Console.WriteLine($"{Path.GetFileName(item)}");
                }

                Console.WriteLine("\nMit szeretnél tenni?\nFileok felülírása: 'Y'\nFileok kihagyása: 'X'\n");


                answ = Console.ReadLine();

                if (answ.ToUpper()=="Y")
                {

                    var removed = 0;

                    for (int i = 0; i < myFiles.Count; i++)
                    {
                        var item = myFiles[i];
                        var name = Path.GetFileName(item);
                        var path = Path.GetDirectoryName(item)+@"\";

                        
                        if (endPath == path)
                        {
                            myFiles.Remove(myFiles[i]);
                            Console.WriteLine($"Fantom file eltávolítva: {name}.");
                            removed++;
                        }

                    }

                    if (removed > 0)
                    {
                        Console.WriteLine($"Eltávolításra került fájlok, amik a célmappában voltak mint 'forrásfájlok': {removed}.");

                    }

                    var length = existFiles.Count;
                    for (int i = 0; i < length; i++)
                    {
                        File.Delete(existFiles[0]);
                        existFiles.Remove(existFiles[0]);
                    }
                }

                if (answ.ToUpper() == "X")
                {
                    var cntr = 0;
                    while (existFiles.Count != 0)
                    {
                        if (Path.GetFileName(existFiles[0]) == Path.GetFileName(myFiles[cntr]))
                        {
                            myFiles.Remove(myFiles[cntr]);
                            existFiles.Remove(existFiles[0]);
                        }
                        else
                        {
                            cntr++;
                        }
                    }
                }
            }

            Console.WriteLine();

            for (int i = 0; i < myFiles.Count; i++)
            {
                var item = myFiles[i];
                var name = Path.GetFileName(item);

                var copyFrom = myFiles[i];
                var pasteTo = endPath + name;
                File.Copy(copyFrom, pasteTo);

                    Console.Write($"Pillanat, dolgozom... {name} ({i + 1}/{myFiles.Count})");
                    Console.CursorLeft = 0;
            }

            Console.Write($"\nMűvelet vége! {myFiles.Count} file átmásolva ide:\n{endPath}\n");

            Console.WriteLine("\nMegnyitod a mappát a fájlokkal? Igen: (Y)");
            var ans = Console.ReadLine();
            if (ans.ToUpper() == "Y")
            {
                Process.Start(endPath);
            }

        }
    }
}

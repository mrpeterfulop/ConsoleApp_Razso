using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;



namespace _10._12.File_System__folders__files
{
    class Program
    {
        static void Main(string[] args)
        {

            try
            {
                //string fileName = "L_H94158_153518_02.12.inc";
                //string sourcePath = @"C:\Project Manager-old\Edit\From";
                //string targetPath = @"C:\Project Manager-old\Edit\To";

                //string sourceFile = sourcePath + fileName;
                //string targetFile = targetPath + fileName;

                //sourceFile = Path.Combine(sourcePath, fileName);
                //targetFile = Path.Combine(targetPath, fileName);

                //System.IO.File.Copy(sourceFile, targetFile);
                //System.IO.File.Move(sourceFile, targetFile);

                //string testDirectory = @"C:\Project Manager-old\Edit\From\TestFolder\";
                //string testFile = "testfile.txt";

                /*
                Console.WriteLine("Kérlek add meg az új file elérési útját:");
                string testDirectory = Console.ReadLine();
                Console.WriteLine("Kérlek add új file nevét, és kiterjesztését:");
                string testFile = Console.ReadLine();
                */

                // string testFilePath = Path.Combine(testDirectory, testFile);

                //bool existsFile = File.Exists(testFilePath);
                // bool existsDirectory = Directory.Exists(testDirectory);

                /*
                if (existsFile == true)
                {
                    Console.WriteLine("A File létezik! Szeretnéd felülírni?");
                    var answ = Console.ReadLine();

                    if (answ.ToUpper() == "Y")
                    {
                        //File.SetAttributes(testFilePath, FileAttributes.Hidden);
                        //File.Delete(testFilePath);
                        Console.WriteLine("A file-t töröltük!");
                        checkFolder(testDirectory);
                        checkFile(testFile, testFilePath);
                    }
                }
                else
                {
                    Console.WriteLine("Ellenőzés...");
                    checkFolder(testDirectory);
                    checkFile(testFile, testFilePath);
                }*/



                //string[] fileArray = Directory.GetFiles(@"c:\Dir\", "*.jpg", SearchOption.AllDirectories); //-almappákkal együtt, minden file!

                /*
                foreach (string file in fileArray)
                {
                    Console.WriteLine(file);
                }
                */


                /*
                string[] fileArray = Directory.GetFiles(@"C:\Project Manager-old\Edit");
                var copyTo = @"C:\Project Manager-old\Edit\To";

                for (int i = 0; i < fileArray.Length; i++)
                {

                    var patchFrom = fileArray[i];
                    var name = patchFrom.Substring((patchFrom.LastIndexOf(@"\") + 1), (patchFrom.Length) - (patchFrom.LastIndexOf(@"\") + 1));
                    var patchTo = Path.Combine(copyTo, name);
                    File.Copy(patchFrom, patchTo);


                    Console.WriteLine("Művelet vége");
                }

                */
                //d:\Untitled Export\2020\08.22. Réka és Máté - ESKÜVŐ\
                //C:\Project Manager-old\Edit\To\Képek\



                //Fileok, amikre szükségem van
                string[] neededFiles = Directory.GetFiles(@"c:\Users\mrpet\Downloads\drive-download-20201012T163139Z-001\", "*.jpg", SearchOption.AllDirectories);

                for (int i = 0; i < neededFiles.Length; i++)
                {

                    var patchFrom = neededFiles[i];
                    var name = patchFrom.Substring((patchFrom.LastIndexOf(@"\") + 1), (patchFrom.Length) - (patchFrom.LastIndexOf(@"\") + 1));

                    //Console.WriteLine($"File régi neve:{patchFrom}");

                }


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


                    //Fizikailag átnevezem a fileokat
                    //File.Move(patchFrom, newName);

                    neededFiles[j] = newName; //A tömböm elemeinek adom az új nevet


                    //Console.WriteLine($"File új név: {neededFiles[j]}");

                }
                Console.WriteLine($"Szükséges fileok száma: {neededFiles.Length} db");


                string[] puffer = Directory.GetFiles(@"D:\Untitled Export\2020\09.18. Marietta és Gyuri - ESKÜVŐ", "*.jpg", SearchOption.AllDirectories);

                Console.WriteLine($"Főkönyvtári fileok száma: {puffer.Length} db");




                /*
                for (int x = 0; x < puffer.Length; x++)
                {
                    Console.WriteLine(puffer[x]);
                }
                */


                string[] myFiles = new string[neededFiles.Length];


                for (int k = 0; k < neededFiles.Length; k++)
                {

                    var searchFile = neededFiles[k];

                    var rootPath = @"D:\Untitled Export\2020\09.18. Marietta és Gyuri - ESKÜVŐ";
                    var newPath = @"C:\Project Manager-old\Edit\To\Képek\New\";

                    //************** File név ***********************************************
                    var name = searchFile.Substring((searchFile.LastIndexOf(@"\") + 1), (searchFile.Length) - (searchFile.LastIndexOf(@"\") + 1));

                    string[] rootDirectory = Directory.GetFiles(rootPath, name, SearchOption.AllDirectories);


                    myFiles[k] = rootDirectory[0];

                    //Console.WriteLine(myFiles[k]);

                    /*
                    for (int i = 0; i < 1; i++)
                    {
                        string[] rootDirectory = Directory.GetFiles(rootPath, name, SearchOption.AllDirectories);
                        files[i] = rootDirectory[0];
                        Console.WriteLine(files[0]);

                    }
                    
                    /*
                    //var copyFrom = rootPath + name;
                    //var pasteTo = newPath + name;

                    //File.Copy(copyFrom, pasteTo)

                    //Console.WriteLine(copyFrom);
                    //Console.WriteLine(pasteTo);

                    //File.Copy(copyFrom, pasteTo);
                    //Console.WriteLine(rootDirectory[k]);
                    */



                }


                for (int i = 0; i < myFiles.Length; i++)
                {

                    var item = myFiles[i];
                    var newPath = @"C:\Project Manager-old\Edit\To\Képek\New\";

                    //************** File név ***********************************************
                    var name = item.Substring((item.LastIndexOf(@"\") + 1), (item.Length) - (item.LastIndexOf(@"\") + 1));


                    var copyFrom = myFiles[i];
                    var pasteTo = newPath + name;

                    File.Copy(copyFrom, pasteTo);

                }

                Console.WriteLine("Művelet vége!");



                /*

                //Forrásfájlok
                string[] fileArray = Directory.GetFiles(@"d:\Untitled Export\2020\09.18. Marietta és Gyuri - ESKÜVŐ\", "*-2.jpg", SearchOption.AllDirectories);
             
                for (int j = 0; j < fileArray.Length; j++)
                {
                    var patchFrom = fileArray[j];
                    var name = patchFrom.Substring((patchFrom.LastIndexOf(@"\") + 1), (patchFrom.Length) - (patchFrom.LastIndexOf(@"\") + 1));

                    Console.WriteLine(patchFrom);

                }


                //Szükséges fileok másolása
                for (int k = 0; k < fileArray.Length; k++)
                    {
                        var patchFrom = fileArray[k];
                        var name = patchFrom.Substring((patchFrom.LastIndexOf(@"\") + 1), (patchFrom.Length) - (patchFrom.LastIndexOf(@"\") + 1));
                        var copyFrom = fileArray[k];
                        var pasteTo = @"C:\Project Manager-old\Edit\To\Képek\New\"+ name;

                        File.Copy(copyFrom, pasteTo);

                    }

    */

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


        private static void checkFolder(string testDirectory)
        {
            try
            {

                if (Directory.Exists(testDirectory))
                {
                    // Console.WriteLine("A mappa már létezik!");

                }
                else
                {
                    Console.WriteLine("A mappa nem létezik! Szeretnéd létrehozni? (Y)");

                    var answ = Console.ReadLine();

                    if (answ.ToUpper() == "Y")
                    {
                        Directory.CreateDirectory(testDirectory);
                        Console.WriteLine("A mappát létrehoztuk!");
                       // Process.Start(testDirectory); //mappa megnyitása
                    }
                }
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Érvénytelen karakterek az elérési útban!");
 
            }
        }

        private static void checkFile(string testFile, string testFilePath)
        {

            try
            {
                if (File.Exists(testFile))
                {
                    //Console.WriteLine("A file már létezik!");
                }
                else
                {
                    Console.WriteLine("A file nem létezik! Szeretnéd létrehozni? (Y)");

                    var answ = Console.ReadLine();

                    if (answ.ToUpper() == "Y")
                    {
                        File.Create(testFilePath);
                        //File.SetAttributes(testFilePath, FileAttributes.Hidden);
                        Console.WriteLine("A file-t létrehoztuk!");
                        
                    }

                }

            }
            catch (ArgumentException)
            {
                Console.WriteLine("Érvénytelen karakterek a file nevében!");

            }

        }
    }
}

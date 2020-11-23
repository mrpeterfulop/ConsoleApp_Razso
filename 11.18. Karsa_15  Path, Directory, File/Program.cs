using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;



namespace _11._18.Karsa_15__Path__Directory__File
{
    class Program
    {
        static void Main(string[] args)
        {

            string file = @"d:\IT\testfile.txt";

            Console.WriteLine("Path osztály:");
            Console.WriteLine("Path.GetFileName(path): " + Path.GetFileName(file));
            Console.WriteLine("Path.GetExtension(path): " + Path.GetExtension(file));
            Console.WriteLine("Path.GetDirectoryName(path): " + Path.GetDirectoryName(file));

            Console.WriteLine("\nDirectory osztály:");
            Console.WriteLine(@"Directory.CreateDirectory(@'C:\FolderName1\FolderName2\...')");
            //Directory.CreateDirectory(@"C:\");


            var folderPath = @"C:\";
            var filePath = @"C:\Windows";

            Console.WriteLine($"\nAdd vissza az összes mappát-t innen: {folderPath}");

            foreach (var item in Directory.GetDirectories(folderPath))
            {
                Console.WriteLine(item);
            }

            Console.WriteLine($"\nAdd vissza az összes file-t innen: {filePath}");
            foreach (var item in Directory.GetFiles(filePath))
            {
                Console.WriteLine(Path.GetFileName(item));
            }

            var comb1 = @"d:\IT\Proba\Eleres";
            var comb2 = @"files\test.txt";

            Console.WriteLine($"\nÖsszefűzése 2 elérési útnak: {comb1} és {comb2}");
            Console.WriteLine(Path.Combine(comb1, comb2));


            var fldr1 = @"d:\IT\test\üres mappa\";
            var fldr2 = @"d:\IT\test\nem üres mappa\";


            var dex = Directory.Exists(comb1);
            Console.WriteLine($"\nDirectory.Exists('{comb1}') >>>>> {dex} ");

            //Directory.CreateDirectory(fldr1);
            //Directory.CreateDirectory(fldr2);
            Console.WriteLine($"Directory.Create('{fldr1}')  >> Mappaszerkezet létrehozása");
            Console.WriteLine($"Directory.Delete('{fldr1}')  >> Csak akkor töröl, ha üres a mappa!");
            Console.WriteLine($"Directory.Delete('{fldr2}', true)  >> Minden esetben törli a mappát, a tartalmával együtt!");

            //Directory.Delete(fldr1, true);
            //Directory.Delete(fldr2, true);


            string sourceDirectory = @"d:\IT\test\mappa1\testfile.txt";
            string destinationDirectory = @"d:\\IT\\mappa20\testfile.txt";

            Console.WriteLine("Filok, mappák másolása:");
            /*
             try
             {
                 Directory.Move(sourceDirectory, destinationDirectory);
             }
             catch (Exception e)
             {
                 Console.WriteLine(e.Message);
             }
            */
            var myPath = @"d:\ELADÓ CUCCOK\";
            // listSubfolderFiles(myPath);

            //Console.WriteLine($"Directory.Move('{copyFrom}', '{pasteTo}'");


            var myFile = @"D:\IT\test\BH4K8270.jpg";
            var myFile2 = @"D:\IT\test\H.jpg";
            FileInfo info = new FileInfo(myFile);
            long length = info.Length;

            var fileSize = Convert.ToString(length);
            float asd = (length / 1024 / 1024);
            var fileSize2 = Math.Round(asd,2);

            Console.WriteLine($"File neve: {Path.GetFileName(myFile)}");
            Console.WriteLine($"File kiterjesztése: {Path.GetExtension(myFile)}");
            Console.WriteLine($"File mérete: {fileSize} byte");
            Console.WriteLine($"File mérete: {fileSize2} MB");
            
            Console.WriteLine($"File GetCreationTime: {File.GetCreationTime(myFile)}");
            Console.WriteLine($"File GetCreationTimeUtc: {File.GetCreationTimeUtc(myFile)}");
            Console.WriteLine($"File GetLastAccessTime: {File.GetLastAccessTime(myFile)}");
            Console.WriteLine($"File GetLastAccessTimeUtc: {File.GetLastAccessTimeUtc(myFile)}");
            Console.WriteLine($"File GetLastWriteTime: {File.GetLastWriteTime(myFile)}");
            Console.WriteLine($"File GetLastWriteTimeUtc: {File.GetLastWriteTimeUtc(myFile)}");

            var oldDate = File.GetLastWriteTimeUtc(myFile);
            var newDate = oldDate;


            Console.WriteLine($"Old Date: {oldDate}");
            Console.WriteLine($"New Date {newDate}");

            /*
            newDate = newDate.AddYears(1);
            newDate = newDate.AddMonths(1);
            newDate = newDate.AddDays(1);
            newDate = newDate.AddHours(1);
            newDate = newDate.AddMinutes(1);
            newDate = newDate.AddSeconds(1);
            */

            Console.WriteLine($"New Date {newDate}");

            
            var str = File.ReadAllLines(myFile);
            Console.WriteLine(str);


            File.SetLastWriteTimeUtc(myFile, newDate);
            Console.WriteLine($"File GetLastWriteTimeUtc: {File.GetLastWriteTimeUtc(myFile)}");


            Console.ReadLine();

        }

       static void listSubfolderFiles(string path)
        {
            if (Directory.Exists(path))
            {
                foreach (var item in Directory.GetDirectories(path))
                {
                    Console.WriteLine(Directory.GetCreationTime(item) + $" <DIR> " + Path.GetFileName(item));
                    listSubfolderFiles(item);
                }

                foreach (var item in Directory.GetFiles(path))
                {
                 Console.WriteLine(File.GetCreationTime(item) + $" # " + Path.GetFileName(item));
                }

            }
        }
    }
}

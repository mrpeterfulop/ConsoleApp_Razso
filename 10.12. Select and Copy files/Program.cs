using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace _10._12.Select_and_Copy_files
{
    partial class Program
    {


        static void Main(string[] args)
        {

            
            Console.WriteLine("Add meg a főkönyvtár elérési útját:");
                string rootPath = Console.ReadLine();

            Console.WriteLine("\nAdd meg az ügyfél fileok elérési útját:");
                var clientPath = Console.ReadLine();


            try
            {

                var load = new LoadClientFiles();
                var sync = new SyncArrays();
                var copy = new CopyTheFiles();


                
                string[] neededFiles = load.loadClientFiles(clientPath); // PART 1.
                List <string> myFiles = sync.syncArrays(neededFiles, rootPath); // PART 2.
                copy.copyTheFiles(myFiles, rootPath); // PART 3.


            }

            catch (FileNotFoundException) //Nem létező file
            {
                Console.WriteLine("\nHiba!");
            }

            catch (DirectoryNotFoundException) //Nem létező elérési út
            {
                Console.WriteLine($"\nHiba! Nem létező elérési út!");
            }

            catch (IOException)
            {
                Console.WriteLine($"\nA file már szerepel a célkönyvtárban!");
                Console.WriteLine($"Szeretnéd felülírni az összes lehetséges ütközést? Igen = 'Y', Nem = 'X'");
                var ans = Console.ReadLine();
                if (ans.ToUpper() == "Y")
                {

                }
                if (ans.ToUpper() == "X")
                {

                }

            }
            /*catch (Exception)
            {
                Console.WriteLine($"\nHiba! Lehet hogy felcserélted a fileok elérési útvonalát!");
            }*/

            Console.ReadKey();
        }

    }
}

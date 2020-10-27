using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace _10._12.Select_and_Copy_files
{
    public class LoadClientFiles
    {
        public string[] loadClientFiles(string clientPath) //PART 1.
        {

            //Fileok, amikre szükségem van
            string[] neededFiles = Directory.GetFiles(clientPath, "*.jpg", SearchOption.AllDirectories);

            // Gyökölés, a "-2" végződés kiiktatása, és csak a filenevek tárolása a tömbbe!
            for (int i = 0; i < neededFiles.Length; i++)
            {
                var fileName = Path.GetFileName(neededFiles[i]);
                var extension = Path.GetExtension(neededFiles[i]);

                int endOfName = fileName.LastIndexOf("-");
                string firstPart = fileName.Substring(0, endOfName);
                string newName = firstPart + extension;

                neededFiles[i] = newName;
            }


            return neededFiles;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace _11._19.DateRecoveryApp
{
    class myFiles
    {
        string fullPath;
        string fileName;
        string fileExtension;

        DateTime fileCreationTime;
        DateTime fileCreationTimeUtc;
        DateTime fileLastAccessTime;
        DateTime fileLastAccessTimeUtc;
        DateTime fileLastWriteTime;
        DateTime fileLastWriteTimeUtc;

        long fileSize;
        string fileMsg;

        public myFiles(string fullPath, string fileName, string fileExtension, DateTime fileCreationTime, DateTime fileCreationTimeUtc, DateTime fileLastAccessTime, DateTime fileLastAccessTimeUtc, DateTime fileLastWriteTime, DateTime fileLastWriteTimeUtc)
        {

            try
            {
                this.FullPath = fullPath;
                this.FileName = fileName;
                this.FileExtension = fileExtension;
                this.FileCreationTime = fileCreationTime;
                this.FileCreationTimeUtc = fileCreationTimeUtc;
                this.FileLastAccessTime = fileLastAccessTime;
                this.FileLastAccessTimeUtc = fileLastAccessTimeUtc;
                this.FileLastWriteTime = fileLastWriteTime;
                this.FileLastWriteTimeUtc = fileLastWriteTimeUtc;
                this.FileMsg = fileMsg;
                AddFileMsg(fullPath);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

        }

        public string FullPath { get => fullPath; set => fullPath = value; }
        public string FileName
        {
            get { return fileName; }
            set {fileName = value;}
        }

        public string FileExtension { get => fileExtension; set => fileExtension = value; }
        public DateTime FileCreationTime { get => fileCreationTime; set => fileCreationTime = value; }
        public DateTime FileCreationTimeUtc { get => fileCreationTimeUtc; set => fileCreationTimeUtc = value; }
        public DateTime FileLastAccessTime { get => fileLastAccessTime; set => fileLastAccessTime = value; }
        public DateTime FileLastAccessTimeUtc { get => fileLastAccessTimeUtc; set => fileLastAccessTimeUtc = value; }
        public DateTime FileLastWriteTime { get => fileLastWriteTime; set => fileLastWriteTime = value; }
        public DateTime FileLastWriteTimeUtc { get => fileLastWriteTimeUtc; set => fileLastWriteTimeUtc = value; }
        public long FileSize { get => fileSize; set => fileSize = value; }

        public string FileMsg{ get => fileMsg; set => fileMsg = value; }


        public void AddFileMsg(string fullPath)
        {
            FileInfo info = new FileInfo(fullPath);
            if (fullPath.Length > 259)
            {
                this.FileMsg = "A file hossza meghaladja a 259 karaktert!";
                this.FileSize = 0;

            }
            else
            {
                this.FileSize = info.Length;
            }
        }

    }


    class Program
    {

        static void Main(string[] args)
        {

            try
            {
                string filePath = getFilePath();

                string[] neededFiles = fileValidation(filePath);

                List<myFiles> NFL = fillPathToList(neededFiles);

                var folderPath = createDirectory();
                var logFilePath = createLogFile(folderPath);

                writeDataToLogFile(filePath, NFL, logFilePath);

            }
            catch (UnauthorizedAccessException)
            {

                Console.WriteLine("Sajnos nincs jogosultságom bejárni egyes mappákat! :(");  
            }

            
            Console.ReadLine();

        }

        private static void writeDataToLogFile(string filePath, List<myFiles> NFL, string logFilePath)
        {

            var extList = getExtensionsOnly(NFL);

            using (FileStream fs = new FileStream(logFilePath, FileMode.Open))
            {
                using (StreamWriter writer = new StreamWriter(fs, Encoding.UTF8))
                {
                    var ctr = 0;
                    writer.WriteLine(@"######################################## - INFO - ########################################" + "\n");
                    writer.WriteLine($"Export Date: {DateTime.Now}.\nFile count: {NFL.Count()}\nFiles from: {filePath}\nFile extension criteria: {extList}");
                    writer.WriteLine("\n"+ @"##########################################################################################" + "\n");

                    foreach (var item in NFL)
                    {
                        ctr++;
                        writer.Write($"ID: {ctr}\nName: {item.FileName} \nExtension: {item.FileExtension}\nLastWriteTime: {item.FileLastWriteTime}\nSize: {item.FileSize} byte.\nInfo: {item.FileMsg}\n");
                        writer.WriteLine("-------------------------------------------------------------------------------");
                    }
                    Console.WriteLine("File-ba írás kész!");
                }
            }
        }

        private static string getExtensionsOnly(List<myFiles> NFL)
        {
            List<string> extensions = new List<string>();

            foreach (var item in NFL)
            {
                if (extensions.IndexOf(item.FileExtension) == -1 && item.FileExtension != "")
                {
                    extensions.Add(item.FileExtension);
                }
            }

            return string.Join(", ", extensions);
        }

        private static string createTimeSpan(string sep)
        {
            DateTime dt = DateTime.Now;
            var hh = Convert.ToString(dt.Hour);
            var mm = Convert.ToString(dt.Minute);
            var ss = Convert.ToString(dt.Second);
            var ms = Convert.ToString(dt.Millisecond);

            if (hh.Length < 2)
            {
                hh = "0" + hh;
            }
            if (mm.Length < 2)
            {
                mm = "0" + mm;
            }
            if (ss.Length < 2)
            {
                ss = "0" + ss;
            }
            if (ms.Length < 3)
            {
                ms = "0" + ss;
            }

            string timeSpan = hh + sep + mm + sep + ss + sep + ms;
            return timeSpan;
        }

        private static string getDefaultDiscInfo()
        {
            var localPath = Path.GetPathRoot(Environment.SystemDirectory) + @"Users\" + Convert.ToString(Environment.UserName) + @"\Documents\.logFile";

            return localPath;
        }

        private static string createDirectory()
        {
            string inputText = "Add meg a mappa helyét:";
            Console.WriteLine(inputText);


            string defaultLogPath = getDefaultDiscInfo();

            string folderPath = Console.ReadLine();

            if (folderPath == "") folderPath = defaultLogPath;

            while (int.TryParse(Convert.ToString(folderPath[0]), out int number) || folderPath[1] != ':' || folderPath[2] != '\\' || folderPath.Length<= 3)
            {
                Console.WriteLine("Az elérési út formátuma hibás, vagy rövid!");
                Console.WriteLine(inputText);
                folderPath = Console.ReadLine();
            }
            try
            {
                if (!(Directory.Exists(folderPath)))
                {
                    Directory.CreateDirectory(folderPath);
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                createDirectory();
            }

            return folderPath;
        }

        private static string createLogFile(string folderPath)
        {
            string timeSpan = createTimeSpan("-");
            var logFileName = ("log_" + timeSpan + ".log");
            string logFilePath = Path.Combine(folderPath, logFileName);
            var myFile = File.Create(logFilePath);
            myFile.Close();

            return logFilePath;
        }


        private static void consolWriteListItems(List<myFiles> NFL)
        {
            Console.WriteLine($"{NFL.Count} file beolvasása megtörtént!\n\n----------------------------------------------------------------------------------------");

            var ctr = 0;
            foreach (var item in NFL)
            {
                ctr++;
                Console.WriteLine($"ID: {ctr}\nName: {item.FileName} \nExtension: {item.FileExtension}\nLastWriteTime: {item.FileLastWriteTime}\nSize: {item.FileSize} byte.");
                Console.WriteLine("----------------------------------------------------------------------------------------");

            }
        }

        private static List<myFiles> fillPathToList(string[] neededFiles)
        {
            List<myFiles> NFL = new List<myFiles>();

            for (int i = 0; i < neededFiles.Length; i++)
            {
                var FullPath = Path.GetFullPath(neededFiles[i]);
                var Name = Path.GetFileName(neededFiles[i]);
                var Extension = Path.GetExtension(neededFiles[i]);
                var CreationTime = File.GetCreationTime(neededFiles[i]);
                var CreationTimeUtc = File.GetCreationTimeUtc(neededFiles[i]);
                var LastAccessTime = File.GetLastAccessTime(neededFiles[i]);
                var LastAccessTimeUtc = File.GetLastAccessTimeUtc(neededFiles[i]);
                var LastWriteTime = File.GetLastWriteTime(neededFiles[i]);
                var LastWriteTimeUtc = File.GetLastWriteTimeUtc(neededFiles[i]);

                var temp = new myFiles(FullPath, Name, Extension, CreationTime, CreationTimeUtc, LastAccessTime, LastAccessTimeUtc, LastWriteTime, LastWriteTimeUtc);

                NFL.Add(temp);

            }

            return NFL;
        }

        private static string[] fileValidation(string filePath)
        {
            string consoleQuestion = "\nMilyen kiterjesztésű filokat keresel? (txt, jpg, png, docx, xlsx...)";

            Console.WriteLine(consoleQuestion);
            string extensionFilter = Console.ReadLine();
            if (extensionFilter == "") extensionFilter = "*";
            string[] neededFiles;

            neededFiles = Directory.GetFiles(filePath, "*." + extensionFilter, SearchOption.AllDirectories);


            while (neededFiles.Length == 0)
            {
                Console.WriteLine($"Hiba! '.{extensionFilter}' kiterjesztésű fileok nem találhatóak!");
                Console.WriteLine(consoleQuestion);
                extensionFilter = Console.ReadLine();
                if (extensionFilter == "") extensionFilter = "*";
                Console.WriteLine($"Kritérium: *.{extensionFilter}");
                neededFiles = Directory.GetFiles(filePath, "*." + extensionFilter, SearchOption.AllDirectories);
            }

            return neededFiles;
        }

        private static string getFilePath()
        {
            string inputText = "Add meg a fileokat tartalmazó könyvtár elérési útját:";
            Console.WriteLine(inputText);
            string filePath = Console.ReadLine();

            int fileCount = 0;
            do
            {
                while ((!Directory.Exists(filePath)))
                {
                    Console.WriteLine("Hiba az útvonalban!");
                    Console.WriteLine(inputText);
                    filePath = Console.ReadLine();
                }
                fileCount = Directory.GetFiles(filePath, "*.*", SearchOption.AllDirectories).Length;
                if (fileCount == 0)
                {
                    Console.WriteLine("Hiba! A mappa nem tartalmaz fileokat!");
                    Console.WriteLine(inputText);
                    filePath = Console.ReadLine();
                }

            } while (fileCount == 0); 


            return filePath;
        }

    }
}

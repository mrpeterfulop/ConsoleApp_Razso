using System;
using System.IO;
using System.Drawing;

namespace _12._11._File_Exif_Data
{
    class Program
    {
        static void Main(string[] args)
        {

            System.Drawing.Image.PropertyItems

            myFile = @"‪f:\Analog\SEOtester.jpg";

            var directories = ImageMetadataReader.ReadMetadata(myFile);


            /*

            // print out all metadata
            foreach (var directory in directories)
                foreach (var tag in directory.Tags)
                    Console.WriteLine($"{directory.Name} - {tag.Name} = {tag.Description}");

            // access the date time
            var subIfdDirectory = directories.OfType<ExifSubIfdDirectory>().FirstOrDefault();
            var dateTime = subIfdDirectory?.GetDateTime(ExifDirectoryBase.TagDateTime);
            */

            /*
            var myFile = @"‪f:\Analog\SEOtester.jpg";

            StreamReader sr = new StreamReader(myFile, FileMode.Open);



            FileInfo info = new FileInfo(myFile);
            long length = info.Length;

            var fileSize = Convert.ToString(length);
            float asd = (length / 1024 / 1024);
            var fileSize2 = Math.Round(asd, 2);

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
            */

            Console.ReadKey();

        }
    }
}

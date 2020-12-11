using MetadataExtractor;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Directory = MetadataExtractor.Directory;

namespace _12._11.File_Operations
{
    /// <summary>
    /// install PM> "Install-Package MetadataExtractor -Version 2.4.3"
    /// </summary>

    public class Data
    {

        string dirName;
        string tagName;
        string tagDesc;

        public Data(string dirName, string tagName, string tagDesc)
        {
            DirName = dirName;
            TagName = tagName;
            TagDesc = tagDesc;
        }

        public string DirName { get => dirName; set => dirName = value; }
        public string TagName { get => tagName; set => tagName = value; }
        public string TagDesc { get => tagDesc; set => tagDesc = value; }
    }

    class Program
    {
        static void Main(string[] args)
        {
        //29844 

        // Console.WriteLine("Elérési út megadása:");
        //string file = Console.ReadLine();
            string file = @"E:\2020 Backup All\06.02. Niki és Laci - Családi fotózás\DEN04279.ARW";
            Console.WriteLine($"File: {file}");


            IEnumerable<Directory> directories = ImageMetadataReader.ReadMetadata(file);

            List<Data> MyList = new List<Data>();


            foreach (var directory in directories)
            {
                foreach (var tag in directory.Tags)
                {
                    var a = directory.Name;
                    var b = tag.Name;
                    var c = tag.Description;

                    Data line = new Data(a, b, c);
                    MyList.Add(line);
                }
            }

            /*
            foreach (var directory in directories)
                foreach (var tag in directory.Tags)
                    Console.WriteLine($"{directory.Name} - {tag.Name} = {tag.Description}");
            */


            // var asd = directories.Where(seen => seen.HaveSeen == false).Where(date => date.ReleaseDate != "NI").Where(date => Convert.ToDateTime(date.ReleaseDate)

            // Console.WriteLine($"{directories.Name} - {tag.Name} = {tag.Description}");

            /*
            foreach (var item in MyList)
            {
                Console.WriteLine(item.DirName + " # " + item.TagName + " # " + item.TagDesc);
            }
            */


            var testline1 = MyList.Where(name => name.TagName == "Make").Select(data => data.TagDesc).First();
            var testline2 = MyList.Where(name => name.TagName == "Model").Select(data => data.TagDesc).First();
            var testline3 = MyList.Where(name => name.TagName == "Software").Select(data => data.TagDesc).First();
            var testline4 = MyList.Where(name => name.TagName == "Full Image Size").Select(data => data.TagDesc).First();

            Console.WriteLine(testline1);
            Console.WriteLine(testline2);
            Console.WriteLine(testline3);
            Console.WriteLine(testline4);

            Console.ReadKey();

        }
    }
}

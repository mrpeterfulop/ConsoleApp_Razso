using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace _11._11.Orai_munka
{
    public class Process
    {
        public static List<MetData> metData = new List<MetData>();
        public static List<string> allCity = new List<string>();

        // 1. FELADAT
        public static void ImportData()
        {
            using (FileStream fs = new FileStream("tavirathu13.txt", FileMode.Open))
            {
                using (StreamReader sr = new StreamReader(fs, Encoding.Default))
                {
                    while (!sr.EndOfStream)
                    {
                        string[] puffer = sr.ReadLine().Split(' ');
                        var city = puffer[0];
                        var time = puffer[1];
                        var wind = puffer[2];
                        var temp = Convert.ToInt32(puffer[3]);
                        MetData line = new MetData(city, time, wind, temp);
                        metData.Add(line);
                    }
                }
            }
        }

        public static void CreateCityList()
        {
            foreach (var item in metData)
            {
                while (!(allCity.Contains(item.City)))
                {
                    allCity.Add(item.City);
                }
            }
        }

        // 2.1 FELADAT
        public static string GetCityName()
        {
            Console.WriteLine("2. feladat");
            Console.Write("Adja meg egy település kódját! Település: ");
            string inputCity = Console.ReadLine().ToUpper();

            while (!(allCity.Contains(inputCity)))
            {
                Console.Write("Adja meg egy település kódját! Település: ");
                inputCity = Console.ReadLine();
            }
            return inputCity;
        }

        // 2.2 FELADAT
        public static void SelectLastMeasureTime(string city)
        {
            MetData lastMeasure = metData[0];
            for (int i = metData.Count - 1; i >= 0; i--)
            {
                if (city == metData[i].City)
                {
                    lastMeasure = metData[i];
                    break;
                }
            }
            Console.WriteLine($"Az utolsó mérési adat a megadott településről {lastMeasure.Time[0]}{lastMeasure.Time[1]}:{lastMeasure.Time[2]}{lastMeasure.Time[3]}-kor érkezett.");
        }

        // 3. FELADAT
        public static void GetMaxMinTemp()
        {
            Console.WriteLine("\n3. feladat");
            MetData maxTemp = metData[0];
            MetData minTemp = metData[0];

            foreach (var item in metData)
            {
                if (maxTemp.Temp < item.Temp)
                {
                    maxTemp = item;
                }
                if (minTemp.Temp > item.Temp)
                {
                    minTemp = item;
                }
            }
            Console.WriteLine($"A legalacsonyabb hőmérséklet: {minTemp.City} {minTemp.Time[0]}{minTemp.Time[1]}:{minTemp.Time[2]}{minTemp.Time[3]} {minTemp.Temp} fok.");
            Console.WriteLine($"A legmagasabb hőmérséklet: {maxTemp.City} {maxTemp.Time[0]}{maxTemp.Time[1]}:{maxTemp.Time[2]}{maxTemp.Time[3]} {maxTemp.Temp} fok.");
        }

        //4. FELADAT
        public static void ZeroWindInfo()
        {
            Console.WriteLine("\n4. feladat");
            var counter = 0;
            foreach (var item in metData)
            {
                if (item.Wind == "00000")
                {
                    Console.WriteLine($"{ item.City} { item.Time[0]}{ item.Time[1]}:{ item.Time[2]}{item.Time[3]}");
                    counter++;
                }
            }
            if (counter == 0)
            {
                Console.WriteLine("Nincs szélcsendes időszak!");
            }
        }

        //5. FELADAT
        public static void Calculations()
        {
            Console.WriteLine("\n5. feladat");

            List<string> exc = new List<string>() { "01", "07", "13", "19" };
            List<string> cont = new List<string>();
            double sum = 0;
            int counter = 0;

            for (int i = 0; i < allCity.Count; i++)
            {
                int maxTemp = 0;
                int minTemp = 100; // Kezdeti érték, ami az első vizsgálatnál felülíródik.
                cont.Clear();

                foreach (var item in metData)
                {
                    if (allCity[i] == item.City)
                    {
                        if (item.Temp > maxTemp)
                        {
                            maxTemp = item.Temp;
                        }
                        if (item.Temp < minTemp)
                        {
                            minTemp = item.Temp;
                        }

                        string hour = item.Time.Substring(0, 2);

                        if (exc.Contains(hour) && !(cont.Contains(hour)))
                        {
                            sum = sum + item.Temp;
                            counter++;
                            cont.Add(hour);
                        }
                    }
                }

                if (cont.Count == 4)
                {
                        Console.Write($"{allCity[i]} Középhőmérséklet: {Math.Round(sum / counter)};");
                        Console.WriteLine($" Hőmérséklet-ingadozás: {maxTemp - minTemp}");
                }
                else
                {
                        Console.Write($"{allCity[i]} NA;");
                        Console.WriteLine($" Hőmérséklet-ingadozás: {maxTemp - minTemp}");
                }
            }
        }

        //6. FELADAT
        public static void WriteToFile()
        {
            Console.WriteLine("\n6. feladat");

            for (int i = 0; i < allCity.Count; i++)
            {
                int wind = 0;
                string windchar = "";
                var filePath = allCity[i] + ".txt";
                StreamWriter sw = new StreamWriter(filePath);
                sw.WriteLine(allCity[i]);

                foreach (var item in metData)
                {
                    if (allCity[i] == item.City)
                    {
                        wind = Convert.ToInt32(item.Wind.Substring(3));
                        windchar = "";

                        for (int j = 0; j < wind; j++)
                        {
                            windchar += "#";
                        }
                        sw.WriteLine($"{item.Time[0]}{item.Time[1]}:{item.Time[2]}{item.Time[3]} {windchar}");
                    }
                }
                sw.Flush();
                sw.Close();
            }

            Console.WriteLine("A file-ba írás megtörtént!");
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace _11._11.Orai_munka
{
   public class MetData
    {
        string city;
        string time;
        string wind;
        int temp;

        public MetData(string city, string time, string wind, int temp)
        {
            City = city;
            Time = time;
            Wind = wind;
            Temp = temp;
        }

        public string City { get => city; set => city = value; }
        public string Time { get => time; set => time = value; }
        public string Wind { get => wind; set => wind = value; }
        public int Temp { get => temp; set => temp = value; }

    }

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
            /*
            foreach (var item in metData)
            {
                Console.WriteLine(item.City + " " + item.Time + " " + item.Wind + " " + item.Temp);
            }
            */

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
            List<int> noData = new List<int>();

            double sum = 0;
            int counter = 0;

            for (int i = 0; i < allCity.Count; i++)
            {
                int maxTemp = 0;
                int minTemp = 100;
                noData.Clear();

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
                        switch (hour)
                        {
                            case "01":
                                sum = sum + item.Temp;
                                counter++;
                                noData.Add(1);
                                break;

                            case "07":
                                sum = sum + item.Temp;
                                counter++;
                                noData.Add(2);
                                break;

                            case "13":
                                sum = sum + item.Temp;
                                counter++;
                                noData.Add(3);
                                break;

                            case "19":
                                sum = sum + item.Temp;
                                counter++;
                                noData.Add(4);
                                break;

                            default:
                                break;
                        }

                    }

                }

                if (noData.Contains(1) && noData.Contains(2) && noData.Contains(3) && noData.Contains(4))
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

        }
    }


    class Program
    {
        static void Main(string[] args)
        {

            // 1. Olvassa be és tárolja el a tavirathu13.txt állomány adatait!
            //Tavirat.ReadDataFromTXT();
            Process.ImportData();

            // 1.2 Városnevek lista létrehozása
            // Tavirat.createCityList();
            Process.CreateCityList();


            // 2. Kérje be a felhasználótól egy város kódját! Adja meg, hogy az adott városból mikor érkezett az utolsó mérési adat!A kiírásban az időpontot óó:pp formátumban jelenítse meg!
            //// Tavirat.GetLastMeasurementMoment();
            string city = Process.GetCityName();
            Process.SelectLastMeasureTime(city);

            // 3. Határozza meg, hogy a nap során mikor mérték a legalacsonyabb és a legmagasabb hőmérsékletet! Jelenítse meg a méréshez kapcsolódó település nevét, az időpontot és a hőmérsékletet! Amennyiben több legnagyobb vagy legkisebb érték van, akkor elég az egyiket kiírnia.
            // Tavirat.GetMaxMinTemperature();
            Process.GetMaxMinTemp();

            // 4. Határozza meg, azokat a településeket és időpontokat, ahol és amikor a mérések idején szélcsend volt!(A szélcsendet a táviratban 00000 kóddal jelölik.) Ha nem volt ilyen, akkor a „Nem volt szélcsend a mérések idején.” szöveget írja ki! A kiírásnál a település kódját és az időpontot jelenítse meg.
            // Tavirat.GetZeroWind();
            Process.ZeroWindInfo();

            // 5. Határozza meg a települések napi középhőmérsékleti adatát és a hőmérséklet - ingadozását! A kiírásnál a település kódja szerepeljen a sor elején a minta szerint!A kiírásnál csak a megoldott feladatrészre vonatkozó szöveget és értékeket írja ki!
            // Tavirat.GetMedTempAndFluct();
            Process.Calculations();

            // 6. Hozzon létre településenként egy szöveges állományt, amely első sorában a település kódját tartalmazza! A további sorokban a mérési időpontok és a hozzá tartozó szélerősségek jelenjenek meg! A szélerősséget a minta szerint a számértéknek megfelelő számú kettőskereszttel(#) adja meg! A fájlban az időpontokat és a szélerősséget megjelenítő kettőskereszteket szóközzel válassza el egymástól! A fájl neve X.txt legyen, ahol az X helyére a település kódja kerüljön!
            // Tavirat.writeDataToTxt();
            Process.WriteToFile();



            // PROGRAM VÉGE
            Console.ReadKey();

        }
    }
}

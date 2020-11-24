using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace _11._11.Orai_munka
{
    public class Tavirat
    {

        public Tavirat()
        {
        }

        public static List<Tavirat> tElements = new List<Tavirat>();
        public static List<string> Cities = new List<string>();

        private string station;
        private string time;
        private string dow;
        private int temp;
        public Tavirat(string station, string time, string dow, int temp)
        {
            this.Station = station;
            this.Time = time;
            this.Dow = dow;
            this.Temp = temp;
        }

        public string Station
        {
            get { return station;}
            set { station = value;}
        }
        public string Time
        {
            get{return time;}
            set{time = value;}
        }
        public string Dow
        {
            get{return dow;}
            set{dow = value;}
        }
        public int Temp
        {
            get{return temp;}
            set{temp = value;}
        }

        //IDŐ FORMÁTUM GENERÁLÁSA (00:00)
        public string TimeFormatShow(string tm)
        {
            return tm = tm.Substring(0, 2) + ":" + tm.Substring(2);
        }

        // 1. FELADAT
        public static void ReadDataFromTXT()
        {
            string filePath = "tavirathu13.txt";

            using (FileStream fs = new FileStream(filePath, FileMode.Open)) {

                using (StreamReader sr = new StreamReader(fs, Encoding.Default)) {

                    while (!sr.EndOfStream)
                    {
                        string[] puffer = sr.ReadLine().Split(' ');
                        string a = puffer[0];
                        string b = puffer[1];
                        string c = puffer[2];
                        int d = Convert.ToInt32(puffer[3]);
                        Tavirat temp = new Tavirat(a, b, c, d);
                        Tavirat.tElements.Add(temp);
                    }
                }
            }
        }

            // 1.1 Városnevek kigyűjtése listába, hogy bekérésnél lehessen valami alapján ellenőrizni az adatokat.
            public static void createCityList()
            {
                foreach (var item in tElements)
                {
                    if (!(Cities.Contains(item.Station)))
                    {
                        Cities.Add(item.Station);
                    }
                }
            }

        // 2. FELADAT
        public static void GetLastMeasurementMoment()
        {
            Console.WriteLine("2. Feladat");

            Console.Write("Adja meg egy település kódját! Település:");
            string userData = Console.ReadLine().ToUpper();

            while (!Cities.Contains(userData))
            {
                Console.WriteLine("A kfiejezés nem szerepel a városkódok között!\nAz alábbiak közül tudsz váalsztani:");
                Console.WriteLine(string.Join(", ", Cities));
                Console.Write("\nAdja meg egy település kódját! Település:");
                userData = Console.ReadLine().ToUpper();
            }

            string time = "";
            for (int i = tElements.Count-1; i >= 0 ; i--)
            {
                if (userData == tElements[i].Station)
                {
                    time = tElements[i].Time;
                    break;
                }
            }

            Console.WriteLine(time);

            Tavirat tv = new Tavirat();
            string tm = Convert.ToString(time);

            Console.WriteLine($"Az utolsó mérési adat {userData} településről {tv.TimeFormatShow(tm)} időpontban érkezett!\n");


        }

        // 3. FELADAT
        public static void GetMaxMinTemperature()
        {

            Tavirat minTemp = tElements[0];
            Tavirat maxTemp = tElements[0];

            Console.WriteLine("3. Feladat");

            for (int i = 0; i < tElements.Count; i++)
            {
                if (minTemp.Temp > tElements[i].Temp)
                {
                    minTemp = tElements[i];
                }

                if (maxTemp.Temp < tElements[i].Temp)
                {
                    maxTemp = tElements[i];
                }
            }

            Console.Write($"A minimum hőmrséklet: ");
            Console.WriteLine($"{minTemp.Station} {minTemp.TimeFormatShow(minTemp.Time)} {minTemp.Temp} fok");


            Console.Write($"A maximum hőmrséklet: ");
            Console.WriteLine($"{maxTemp.Station} {maxTemp.TimeFormatShow(maxTemp.Time)} {maxTemp.Temp} fok");

        } 

        // 4. FELADAT
        public static void GetZeroWind()
        {
            Console.WriteLine("4. Feladat");

            List<Tavirat> zeroWind = new List<Tavirat>();

            foreach (Tavirat item in tElements)
            {
                if (item.Dow == "00000")
                {
                    Tavirat op = new Tavirat(item.Station, item.Time, item.Dow, item.Temp);
                    zeroWind.Add(op);
                }
            }

            if (zeroWind.Count() == 0)
            {
                Console.WriteLine($"Nincs szélcsendes időszak!");
            }
            else
            {
                Console.WriteLine("Szélcsendes települések, és időszakok:");
                foreach (Tavirat item in zeroWind)
                {
                    Console.WriteLine(item.Station + " " + item.TimeFormatShow(item.Time));
                }
                Console.WriteLine();
            }

        }

        // 5. FELADAT
        public static void GetMedTempAndFluct()
        {
            Console.WriteLine("5. Feladat");

            // Ideiglenes, középhőmérsékleti adatokat tároló lista létrehozása
            List<Tavirat> MedTempList = new List<Tavirat>();

            // 5/a FELADAT
            Console.WriteLine("Középhőmérsékleti adatok:");

            // A VÁROSOK SZÁMA HATÁROZZA MEG A FOLYAMAT SZÁMÁT
            for (int i = 0; i < Cities.Count; i++)
            {
                var counter = 0;
                var sum = 0;
                var maxTemp = 0;
                var minTemp = 100;

                List<char> checkList = new List<char>(); // Ellenőrző lista létrehozása, egy későbbi metódus számára

                MedTempList.Clear(); //Az ideiglenes listát ürítem

                // 5.1 >>> Adott[i] városnév adatait kiszedem az ideiglenes listába
                createPufferList(Cities, MedTempList, i);

                // 5.2 >>> Az adott kritériumok alapján számítom a szükséges méréseket
                searchDefaultTimes(MedTempList, ref counter, ref sum, ref maxTemp, ref minTemp, checkList);

                // 5.3 >>> Adott[i] városra vonatkozó adatok kiírása consolra. Az utolsó számítások itt történnek.
                float medTemp = (float)sum / counter;
                var tempText = (checkList.Count <= 4) ? $"{MedTempList[i].Station} NA;" : $"{MedTempList[i].Station} középhőmérséklet: {Math.Round(medTemp)}°C";
                Console.WriteLine(tempText + $"  Hőmérséklet-ingadozás: {maxTemp - minTemp}");


                // 6. FELADAT Talán gyorsabb, egyszerűbb itt futtatni a file-ba írást is
                //  Az adott városnév adatait kiírom a kritériumoknak megfelelően egy .txt file-ba! 
                //  writeDataToTXT(Cities, MedTempList, i);

            }

            Console.WriteLine();
        }

            // 5.1 FELADAT
            private static void createPufferList(List<string> Cities, List<Tavirat> MedTempList, int i)
            {
                foreach (Tavirat item in tElements)
                {
                    if (item.Station == Cities[i])
                    {
                        Tavirat op = new Tavirat(item.Station, item.Time, item.Dow, item.Temp);
                        MedTempList.Add(op);
                    }
                }
            }

            // 5.2 FELADAT
            private static void searchDefaultTimes(List<Tavirat> MedTempList, ref int counter, ref int sum, ref int maxTemp, ref int minTemp, List<char> checkList)
            {
                foreach (Tavirat item in MedTempList)
                {
                    if (item.Temp > maxTemp)
                    {
                        maxTemp = item.Temp;
                    }
                    if (item.Temp < minTemp)
                    {
                        minTemp = item.Temp;
                    }

                    var crit = item.Time.Substring(0, 2);

                    switch (crit)
                    {
                        case "01":
                            sum += item.Temp;
                            counter++;
                            checkList.Add('!');
                            break;
                        case "07":
                            sum += item.Temp;
                            counter++;
                            checkList.Add('!');
                            break;
                        case "13":
                            sum += item.Temp;
                            counter++;
                            checkList.Add('!');
                            break;
                        case "19":
                            sum += item.Temp;
                            counter++;
                            checkList.Add('!');
                            break;
                        default:
                            break;
                    }

                }
            }


        // 6. FELADAT
        public static void writeDataToTxt()
        {
            Console.Write("6. Feladat");

            for (int i = 0; i < Cities.Count; i++)
            {

                string CityTxtPath = Cities[i] + ".txt";
                StreamWriter sw = new StreamWriter(CityTxtPath);
                sw.WriteLine(Cities[i]);

                foreach (Tavirat item in tElements)
                {

                    if (item.Station == Cities[i])
                    {
                        int windPower = Convert.ToInt32(item.Dow.Substring(3));
                        string windChar = "";

                        if (windPower >= 1)
                        {
                            for (int j = 0; j < windPower; j++)
                            {
                                windChar += "#";
                            }
                        }
                        else
                        {
                            windChar = "";
                        }

                        sw.WriteLine(item.TimeFormatShow(item.Time) + " " + windChar);
                    }
                }

                sw.Flush();
                sw.Close();
            }

            Console.WriteLine("\nA szöveges állományok feltöltése megtörtént!");
        }

    }
}

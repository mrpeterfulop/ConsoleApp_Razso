using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

            FileStream fs = new FileStream(filePath, FileMode.Open);
            StreamReader sr = new StreamReader(fs, Encoding.Default);

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

            sr.Close();
            fs.Close();

        }

            // 1.1 Városnevek kigyűjtése listába, hogy bekérésnél lehessen valami alapján ellenőrizni az adatokat.
            public static void createCityList()
            {
                // List<string> Cities = new List<string>();

                foreach (var item in tElements)
                {
                    if (!(Cities.Contains(item.Station)))
                    {
                        Cities.Add(item.Station);
                    }
                }


                // return Cities;
            }

        // 2. FELADAT
        public static void GetLastMeasurementMoment()
        {
            Console.Write("Adja meg egy település kódját! Település:");
            string userData = Console.ReadLine().ToUpper();


            while (!Cities.Contains(userData))
            {
                Console.WriteLine("A kfiejezés nem szerepel a városkódok között!\nAz alábbiak közül tudsz váalsztani:");
                Console.WriteLine(string.Join(", ", Cities));
                Console.Write("\nAdja meg egy település kódját! Település:");
                userData = Console.ReadLine().ToUpper();
            }

            int maximumNumber = 0;

            foreach (Tavirat item in tElements)
            {
                if (userData == item.Station)
                {
                    while (maximumNumber < Convert.ToInt32(item.Time))
                    {
                        maximumNumber = Convert.ToInt32(item.Time);
                    }
                }
            }
           
            Tavirat tv = new Tavirat();
            string tm = Convert.ToString(maximumNumber);

           // Console.Clear();
            Console.WriteLine($"Az utolsó mérési adat {userData} településről {tv.TimeFormatShow(tm)} időpontban érkezett!\n");


        }

        // 3. FELADAT
        public static void GetMaxMinTemperature()
        {
            var maxValue = 0;
            var minValue = 1000;

            //List<Tavirat> maxTemp = new List<Tavirat>(); // Megoldás listával
            //List<Tavirat> minTemp = new List<Tavirat>(); // Megoldás listával

            Tavirat[] maxTemp = new Tavirat[1]; // Megoldás tömbbel
            Tavirat[] minTemp = new Tavirat[1]; // Megoldás tömbbel

            foreach (Tavirat item in tElements)
            {

                while (maxValue < item.Temp)
                {
                    // Megoldás listával
                    //maxTemp.Clear();
                    //maxValue = item.Temp;
                    //Tavirat op = new Tavirat(item.Station, item.Time, item.Dow, item.Temp);
                    //maxTemp.Add(op);

                    // Megoldás tömbbel
                    maxValue = item.Temp;
                    Tavirat op = new Tavirat(item.Station, item.Time, item.Dow, item.Temp);
                    maxTemp[0] = op;
                }

                while (minValue > item.Temp)
                {
                    // Megoldás listával
                    //minTemp.Clear();
                    //minValue = item.Temp;
                    //Tavirat op = new Tavirat(item.Station, item.Time, item.Dow, item.Temp);
                    //minTemp.Add(op);

                    // Megoldás tömbbel
                    minValue = item.Temp;
                    Tavirat op = new Tavirat(item.Station, item.Time, item.Dow, item.Temp);
                    minTemp[0] = op;

                }
            }

            Console.Write($"A minimum hőmrséklet: ");
            Console.WriteLine($"{minTemp[0].Station} {minTemp[0].TimeFormatShow(minTemp[0].Time)} {minTemp[0].Temp} fok");
            Console.Write($"A maximum hőmrséklet: ");
            Console.WriteLine($"{maxTemp[0].Station} {maxTemp[0].TimeFormatShow(maxTemp[0].Time)} {maxTemp[0].Temp} fok\n");

        } 

        // 4. FELADAT
        public static void GetZeroWind()
        {
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





        // Nem használt metódus
        /*        private static string writeDataToTXT(List<string> Cities, List<Tavirat> MedTempList, int i)
        {
            string CityTxtPath = Cities[i] + ".txt";
            StreamWriter sw = new StreamWriter(CityTxtPath);
            sw.WriteLine(Cities[i]);

            foreach (Tavirat item in MedTempList)
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

            sw.Flush();
            sw.Close();

            return CityTxtPath;
        }*///


    }

    class Program
    {
        static void Main(string[] args)
        {

            // 1. Olvassa be és tárolja el a tavirathu13.txt állomány adatait!
            Tavirat.ReadDataFromTXT();

            // 1.2 Városnevek lista létrehozása
            Tavirat.createCityList();


            // 2. Kérje be a felhasználótól egy város kódját! Adja meg, hogy az adott városból mikor érkezett az utolsó mérési adat!A kiírásban az időpontot óó:pp formátumban jelenítse meg!
            Console.WriteLine("2. Feladat");
            Tavirat.GetLastMeasurementMoment();


            // 3. Határozza meg, hogy a nap során mikor mérték a legalacsonyabb és a legmagasabb hőmérsékletet! Jelenítse meg a méréshez kapcsolódó település nevét, az időpontot és a hőmérsékletet! Amennyiben több legnagyobb vagy legkisebb érték van, akkor elég az egyiket kiírnia.
            Console.WriteLine("3. Feladat");
            Tavirat.GetMaxMinTemperature();


            // 4. Határozza meg, azokat a településeket és időpontokat, ahol és amikor a mérések idején szélcsend volt!(A szélcsendet a táviratban 00000 kóddal jelölik.) Ha nem volt ilyen, akkor a „Nem volt szélcsend a mérések idején.” szöveget írja ki! A kiírásnál a település kódját és az időpontot jelenítse meg.
            Console.WriteLine("4. Feladat");
            Tavirat.GetZeroWind();


            // 5. Határozza meg a települések napi középhőmérsékleti adatát és a hőmérséklet - ingadozását! A kiírásnál a település kódja szerepeljen a sor elején a minta szerint!A kiírásnál csak a megoldott feladatrészre vonatkozó szöveget és értékeket írja ki!
            Console.WriteLine("5. Feladat");
            Tavirat.GetMedTempAndFluct();


            // 6. Hozzon létre településenként egy szöveges állományt, amely első sorában a település kódját tartalmazza! A további sorokban a mérési időpontok és a hozzá tartozó szélerősségek jelenjenek meg! A szélerősséget a minta szerint a számértéknek megfelelő számú kettőskereszttel(#) adja meg! A fájlban az időpontokat és a szélerősséget megjelenítő kettőskereszteket szóközzel válassza el egymástól! A fájl neve X.txt legyen, ahol az X helyére a település kódja kerüljön!
            Console.Write("6. Feladat");
            Tavirat.writeDataToTxt();




            // PROGRAM VÉGE
            Console.ReadKey();

        }
    }
}

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
        public static List<Tavirat> tElements = new List<Tavirat>();

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

            get { return station; }

            set
            {
                station = value;
            }
        }
        public string Time
        {
            get
            {

                return time;
            }
            set
            {

                time = value;
            }
        }
        public string Dow
        {
            get
            {

                return dow;
            }
            set
            {
                dow = value;
            }
        }
        public int Temp
        {
            get
            {
                return temp;
            }
            set
            {
                temp = value;
            }
        }

        public string TempFormatShow(int tmp)
        {
            string celsius = "";
            if (tmp != 0)
            {
                celsius = Convert.ToString(tmp);

            }
            return Convert.ToString(tmp) + "°C";

        }
        public string DowFormatShow(string dw)
        {
            //string dowFormat = "";
            if (dow != "err")
            {
                if (dow.Substring(0, 3) == "VRB")
                {
                    dw = dow.Substring(0, 3) + ", " + dow.Substring(3);
                }
                else
                {
                    if (dow[0] != '0')
                    {
                        dw = dow.Substring(0, 3) + "°, " + dow.Substring(3);
                    }

                    else
                    {

                        if (dow[0] == '0' && dow[1] != '0')
                        {
                            var a = dow.Substring(0, 3);
                            var b = a.Substring(1);
                            dw = b + "° " + dow.Substring(3);
                        }

                        if (dow[0] == '0' && dow[1] == '0' && dow[2] != '0')
                        {
                            var a = dow.Substring(0, 3);
                            var b = a.Substring(2);
                            dw = b + "° " + dow.Substring(3);
                        }

                        if (dow[0] == '0' && dow[1] == '0' && dow[2] == '0')
                        {

                            dw = 0 + "°, " + dow.Substring(3);

                        }

                    }

                }

            }

            return dw;
        }
        public string TimeFormatShow(string tm)
        {
            return TimeFormatSh(tm);
        }

        public static string TimeFormatSh(string tm)
        {
            if (tm != "err")
            {
                tm = tm.Substring(0, 2) + ":" + tm.Substring(2);
            }

            return tm;
        }

        public static void ShowListItemsSimple()
        {
            //Console.Clear();
            Console.WriteLine("Az importált lista formázott tartalma:\n");
            foreach (var item in tElements)
            {

                Console.WriteLine(item.Station + " " + item.Time + " " + item.Dow + " " + item.Temp);


            }

        }
        public static void ShowListItems()
        {
            //Console.Clear();
            Console.WriteLine("Az importált lista teljes, formázott tartalma:\n");

            foreach (Tavirat item in tElements)
            {
                ShowFormatedLines(item);
            }

        }
        public static void ShowFormatedLines(Tavirat item)
        {
            if (item.Station == "err" || item.Time == "err" || item.Dow == "err" || item.Temp == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }

            Console.WriteLine(item.Station + " " + item.TimeFormatShow(item.Time) + " " + item.DowFormatShow(item.Dow) + " " + item.TempFormatShow(item.Temp));

            Console.ForegroundColor = ConsoleColor.White;
        }


        public static void GetCityAllData()
        {
            //Console.Clear();
            Console.WriteLine("\nAdd meg a város kódját:");
            string userData = Console.ReadLine().ToUpper();

            while (userData.Length != 2)
            {
                Console.WriteLine("Add meg a város kódját:");
                userData = Console.ReadLine();

            }

            var counter = 0;
            foreach (Tavirat item in tElements)
            {
                if (userData == item.Station)
                {
                    ShowFormatedLines(item);
                    counter++;
                }
            }
            if (counter == 0)
            {
                Console.WriteLine("Sajnos nincs a keresésnek megfelelő adat!");
            }
        }
        public static void GetLastMeasurementMoment()
        {
            //Console.Clear();
            Console.WriteLine("\nAdd meg a város kódját, az utolsó mérési adathoz:");
            string userData = Console.ReadLine().ToUpper();

            int maximumNumber = 0;

            foreach (Tavirat item in tElements)
            {
                if (userData == item.Station)
                {
                    while (item.Time != "err" && maximumNumber < Convert.ToInt32(item.Time))
                    {
                        maximumNumber = Convert.ToInt32(item.Time);
                    }
                }
            }

            var tm = Convert.ToString(maximumNumber);

            Console.WriteLine($"Az utolsó mérési adat {userData} településről {TimeFormatSh(tm)} időpontban érkezett!");

        }
        public static void GetMaxMinTemperature()
        {
            var maxValue = 0;
            var minValue = 1000;

            List<Tavirat> maxTemp = new List<Tavirat>();
            List<Tavirat> minTemp = new List<Tavirat>();

            foreach (Tavirat item in tElements)
            {

                while (item.Temp != 0 && maxValue < item.Temp)
                {
                    maxTemp.Clear();
                    maxValue = item.Temp;
                    Tavirat op = new Tavirat(item.Station, item.Time, item.Dow, item.Temp);
                    maxTemp.Add(op);
                }

                while (item.Temp != 0 && minValue > item.Temp)
                {
                    minTemp.Clear();
                    minValue = item.Temp;
                    Tavirat op = new Tavirat(item.Station, item.Time, item.Dow, item.Temp);
                    minTemp.Add(op);
                }

            }
            Console.Write($"A minimum hőmrséklet: ");
            ShowFormatedLines(minTemp[0]);
            Console.Write($"A maximum hőmrséklet: ");
            ShowFormatedLines(maxTemp[0]);

        }

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
                Console.WriteLine($"Találatok száma: {zeroWind.Count()}");
                Console.WriteLine("Szélcsendes települések, és időszakok:");
                foreach (Tavirat item in zeroWind)
                {
                    Console.WriteLine(item.Station + " " + item.TimeFormatShow(item.Time));
                }
            }

        }

        public static void GetMedTempAndFluct()
        {


            List<string> Cities = new List <string>();
            // BP,DC,SM,PA,SN,PR,BC,PP,KE,

            foreach (var item in tElements)
            {
                if (!(Cities.Contains(item.Station)))
                {
                    Cities.Add(item.Station);
                }
            }

            List<Tavirat> MedTempList = new List<Tavirat>();
            
            for (int i = 0; i < Cities.Count; i++)
            {
                var counter = 0;
                var sum = 0;
                var maxTemp = 0;
                var minTemp = 100;
                var tempText = "";
                string CityTxtPath = "";

                MedTempList.Clear();



                foreach (Tavirat item in tElements)
                {
                    if (item.Station == Cities[i])
                    {
                        Tavirat op = new Tavirat(item.Station, item.Time, item.Dow, item.Temp);
                        MedTempList.Add(op);

                    }

                }

                CityTxtPath = Cities[i] + ".txt";

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

                List<char> checkList = new List<char>();


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

                float a = (float)sum / counter;

                if (checkList.Count <= 4)
                {
                    tempText = $"{MedTempList[i].Station} NA;";
                }

                else
                {
                    tempText = $"{MedTempList[i].Station} középhőmérséklet: {Math.Round(a)}°C";
                }


                Console.WriteLine(tempText + $"  Hőmérséklet-ingadozás: {maxTemp - minTemp}");

            }

        }
    }

    class Program
    {

        static void Main(string[] args)
        {

            string filePath = "tavirathu13.txt";

            FileStream fs = new FileStream(filePath, FileMode.Open);
            StreamReader sr = new StreamReader(fs, Encoding.Default);

            while (!sr.EndOfStream)
            {
                Tavirat temp = new Tavirat("", "", "", 0);

                try
                {
                    string[] puffer = sr.ReadLine().Split(' ');
                    string a = puffer[0];
                    string b = puffer[1];
                    string c = puffer[2];
                    int d = Convert.ToInt32(puffer[3]);
                    
                    if (a.Length !=2)
                    {
                        a = "err";
                    }
                    if (b == "")
                    {
                        b = "err";
                    }
                    if (c == "")
                    {
                        c = "err";
                    }
                    
                    temp = new Tavirat(a, b, c, d);
                    Tavirat.tElements.Add(temp);
                    
                }
                catch (Exception)
                {
                    temp = new Tavirat("err", "err", "err", 0);
                    Tavirat.tElements.Add(temp);
                }


            }

            Console.WriteLine($"Sorok száma: { Tavirat.tElements.Count()}");

           
            sr.Close();
            fs.Close();

            Tavirat.GetLastMeasurementMoment();
            Tavirat.GetMaxMinTemperature();
            Tavirat.GetZeroWind();
            Tavirat.GetMedTempAndFluct();

            Console.ReadKey();

        }
    }
}

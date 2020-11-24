using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11._23._2018_Tarsalgo
{
    class Lounge
    {
        public static List<Lounge> doorList = new List<Lounge>();
        public static List<int> users = new List<int>();
        public static List<int> usersIN = new List<int>();

        int hour;
        int minute;
        int id;
        string direction;
        int headcount;

        public static int counter = 0;

        public Lounge(int hour, int minute, int id, string direction)
        {
            Hour = hour;
            Minute = minute;
            Id = id;
            Direction = direction;
            Headcount = HeadCounter(Direction);
        }

        public int HeadCounter(string direction)
        {
            if (direction == "be")
            {
                counter++;
            }
            else
            {
                counter--;

            }
            return counter;
        }

        public int Hour { get => hour; set => hour = value; }
        public int Minute { get => minute; set => minute = value; }
        public int Id { get => id; set => id = value; }
        public string Direction { get => direction; set => direction = value; }
        public int Headcount { get => headcount; set => headcount = value; }


        // 1. FELADAT
        public static void ImportData()
        {
            using (FileStream fs = new FileStream("ajto.txt", FileMode.Open))
            {
                using (StreamReader sr = new StreamReader(fs, Encoding.Default))
                {
                    while (!sr.EndOfStream)
                    {
                        string[] puffer = sr.ReadLine().Split(' ');
                        var hour = Convert.ToInt32(puffer[0]);
                        var minute = Convert.ToInt32(puffer[1]);
                        var id = Convert.ToInt32(puffer[2]);
                        var direction = puffer[3];

                        Lounge line = new Lounge(hour, minute, id, direction);
                        doorList.Add(line);
                    }
                }
            }

        }

        // Óra formátum létrehozása
        public static string CreateTimeFormat(int hour, int minute)
        {
            string h = "";
            string m = "";

            if (hour < 10) h = "0" + Convert.ToString(hour); else h = Convert.ToString(hour);
            if (minute < 10) m = "0" + Convert.ToString(minute); else m = Convert.ToString(minute);

            return h + ":" + m;
        }

        // 2. FELADAT ------------------------------------------
        public static void GetFirstIN_LastOUT_ID()
        {
            int firstIn = GetFirstIn();
            int lastOut = GetLastOut();

            Console.WriteLine("\n2.feladat");
            Console.WriteLine($"Az első belépő: {firstIn}");
            Console.WriteLine($"Az utolsó kilépő: {lastOut}");
        }

        // 2.1 FELADAT
        public static int GetLastOut()
        {
            for (int i = doorList.Count - 1; i >= 0; i--)
            {
                if (doorList[i].Direction == "ki")
                {
                    return doorList[i].Id;
                }
            }
            return -1;
        }

        // 2.2 FELADAT
        public static int GetFirstIn()
        {
            foreach (Lounge item in doorList)
            {
                if (item.Direction == "be")
                {
                    return item.Id;
                }
            }
            return -1;
        }
        // -----------------------------------------------------

        // 3. FELADAT
        public static void GetCountof_IN_OUT_byUsers()
        {

            // ID azonosítók külön listába szedése
            foreach (Lounge item in doorList)
            {
                if (!(users.Contains(item.Id)))
                {
                    users.Add(item.Id);
                }
            }

            users.Sort();

            // Adatok Fileba írása
            using (StreamWriter sw = File.CreateText("athaladas.txt"))
            {
                for (int i = 0; i < users.Count; i++)
                {
                    var counter = 0;
                    foreach (var item in doorList)
                    {
                        if (item.Id == users[i])
                        {
                            counter++;
                        }
                    }
                    // 4. Feladat
                    if (counter % 2 != 0)
                    {
                        usersIN.Add(users[i]);
                    }

                    var line = "ID: " + Convert.ToString(users[i]) + " " + counter;
                    sw.WriteLine(line);
                }
            }
        }

        // 4. FELADAT
        public static void GetLastUsersfromLounge()
        {
            Console.Write("\n4. feladat\nA végén a társalgóban voltak: ");
            Console.WriteLine(string.Join(" ", usersIN));

        }

        // 5. FELADAT
        public static void MaxUserCountIN()
        {
            var max = 0;
            int hour = 0;
            int minute = 0;

            foreach (var item in doorList)
            {
                if (max < item.Headcount)
                {
                    max = item.Headcount;
                    hour = item.Hour;
                    minute = item.Minute;
                }
            }
            
            Console.WriteLine("\n5. feladat");
            Console.WriteLine("10. sorban bentlévők száma: " + doorList[10].Headcount);
            Console.WriteLine($"Például {CreateTimeFormat(hour, minute)} - kor voltak a legtöbben({max} fő) a társalgóban.");

        }

        // 6. FELADAT
        public static int GetUserID()
        {
            Console.WriteLine();
            Console.WriteLine("\n6. feladat");
            Console.Write("Adja meg a személy azonosítóját! ");
            int inputData = Convert.ToInt32(Console.ReadLine());

            while (!(users.Contains(inputData)))
            {
                Console.WriteLine("A keresett felhasználó nem található!\nAz alábbi lehetőségek közül tudsz váalsztani:");
                Console.WriteLine(string.Join(", ", users));
                Console.Write("Adja meg a személy azonosítóját! ");
                inputData = Convert.ToInt32(Console.ReadLine());
            }

            return inputData;

        }

        // 7. FELADAT
        public static void InputUserFromToTime(int ID)
        {
            Console.WriteLine("\n7. feladat");

            foreach (Lounge item in doorList)
            {
                if (ID == item.Id)
                {
                    if (item.Direction == "be")
                    {
                        Console.Write($"{CreateTimeFormat(item.Hour, item.Minute)}-");
                    }
                    else
                    {
                        Console.WriteLine($"{CreateTimeFormat(item.Hour, item.Minute)}");
                    }
                }
            }

            Console.WriteLine();
        }

        // 8. FELADAT
        public static void TimeAboutInputUser(int ID)
        {

            Console.WriteLine("\n8. feladat");

            TimeSpan starTime = new TimeSpan();
            TimeSpan endTime = new TimeSpan();
            double minutes = 0;
            var counter = 0;
            bool stayedInside = false;

            foreach (Lounge item in doorList)
            {
                if (ID == item.Id)
                {
                    if (item.Direction == "be")
                    {
                        starTime = new TimeSpan(item.Hour, item.Minute, 0);
                        stayedInside = true;
                    }

                    else
                    {
                        endTime = new TimeSpan(item.Hour, item.Minute, 0);
                        minutes += (endTime - starTime).Minutes;
                        stayedInside = false;
                    }

                    counter++;
                }
            }

            if (stayedInside == true)
            {
                endTime = new TimeSpan(15, 0, 0);
                minutes += (endTime - starTime).Minutes; // A Start Time, az utolsó belépési időpont, ami a korábbi ciklusból egyszerűen megmaradt érték... 
                counter++;
            }

            var position = "";
            if (counter % 2 != 0) position = "a társalgóban volt"; else position = "nem volt a társalgóban";

            Console.WriteLine($"A(z) {ID}. személy összesen {minutes} percet volt bent, a megfigyelés végén {position}.");
        }

    }

    class Program
    {
        static void Main(string[] args)
        {


            //1. Olvassa be és tárolja el az ajto.txt fájl tartalmát!
            Lounge.ImportData();


            //2. Írja a képernyőre annak a személynek az azonosítóját, aki a vizsgált időszakon belül először lépett be az ajtón, és azét, aki utoljára távozott a megfigyelési időszakban!
            Lounge.GetFirstIN_LastOUT_ID();


            //3. Határozza meg a fájlban szereplő személyek közül, ki hányszor haladt át a társalgó ajtaján! A meghatározott értékeket azonosító szerint növekvő sorrendben írja az athaladas.txt fájlba!Soronként egy személy azonosítója, és tőle egy szóközzel elválasztva az áthaladások száma szerepeljen!
            Lounge.GetCountof_IN_OUT_byUsers();


            //4. Írja a képernyőre azon személyek azonosítóját, akik a vizsgált időszak végén a társalgóban tartózkodtak!
            Lounge.GetLastUsersfromLounge();


            //5. Hányan voltak legtöbben egyszerre a társalgóban? Írjon a képernyőre egy olyan időpontot (óra: perc), amikor a legtöbben voltak bent!
            Lounge.MaxUserCountIN();


            //6. Kérje be a felhasználótól egy személy azonosítóját! A további feladatok megoldásánál ezt használja fel!
            int ID = Lounge.GetUserID();


            //7. Írja a képernyőre, hogy a beolvasott azonosítóhoz tartozó személy mettől meddig tartózkodott a társalgóban!
            Lounge.InputUserFromToTime(ID);


            //8. Határozza meg, hogy a megfigyelt időszakban a beolvasott azonosítójú személy összesen hány percet töltött a társalgóban! Az előző feladatban példaként szereplő 22 - es személy 5 alkalommal járt bent, a megfigyelés végén még bent volt. Róla azt tudjuk, hogy 18 percet töltött bent a megfigyelés végéig. A 39 - es személy 6 alkalommal járt bent, a vizsgált időszak végén nem tartózkodott a helyiségben. Róla azt tudjuk, hogy 39 percet töltött ott.Írja ki, hogy a beolvasott azonosítójú személy mennyi időt volt a társalgóban, és a megfigyelési időszak végén bent volt - e még!
            Lounge.TimeAboutInputUser(ID);


            Console.ReadLine();

        }
    }
}

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
        public static List<Lounge> enterData = new List<Lounge>();
        public static List<Lounge> exitData = new List<Lounge>();
        public static List<string> users = new List<string>();
        public static List<string> usersIN = new List<string>();

        int hour;
        int minute;
        string id;
        string direction;
        int headcount;

        public static int counter = 0;

        public Lounge(int hour, int minute, string id, string direction)
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
        public string Id { get => id; set => id = value; }
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
                        var id = puffer[2];
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
            string m  = "";

            if (hour < 10) h = "0" + Convert.ToString(hour);else h = Convert.ToString(hour);
            if (minute < 10) m = "0" + Convert.ToString(minute);else m = Convert.ToString(minute);

            return h + ":" + m;
        }

        // 2. FELADAT
        public static void GetFirstIN_LastOUT_ID()
        {
            enterData.Clear();
            exitData.Clear();

            foreach (Lounge item in doorList)
            {

                if (item.Direction == "be")
                {
                    Lounge line = new Lounge(item.Hour, item.Minute, item.Id, item.Direction);
                    enterData.Add(line);
                }

               if(item.Direction == "ki") {
                    Lounge line = new Lounge(item.Hour, item.Minute, item.Id, item.Direction);
                    exitData.Add(line);
                }
 
            }
            var firstIn = enterData[0].Id;
            var lastOut = exitData[exitData.Count - 1].Id;

            Console.WriteLine("\n2.feladat");
            Console.WriteLine($"Az első belépő: {firstIn}");
            Console.WriteLine($"Az utolsó kilépő: {lastOut}");
        }

        // 3. FELADAT
        public static void GetCountof_IN_OUT_byUsers()
        {

            List<string> userDataSUM = new List<string>();

            // ID azonosítók külön listába szedése
            foreach (Lounge item in doorList)
            {
                if (!(users.Contains(item.Id)))
                {
                    users.Add(item.Id);
                }
            }
            users = users.OrderBy(a => a).ToList();

            // Sorok File-ba írása
            userDataSUM.Clear();
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

                if (counter % 2 != 0)
                {
                    usersIN.Add(users[i]);
                }

                var line = "ID:" + users[i] + " " + counter;
                userDataSUM.Add(line);
            }

            // Adatok Fileba írása
            using (FileStream fs = new FileStream("athaladas.txt",FileMode.Open)) {

                using (StreamWriter sw = new StreamWriter(fs, Encoding.Default)) {

                    foreach (var item in userDataSUM)
                    {
                        sw.WriteLine(item);

                    }
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
            Console.WriteLine($"Például {CreateTimeFormat(hour, minute)} - kor voltak a legtöbben({max} fő) a társalgóban.");

        }

        // 6. FELADAT
        public static string GetUserID()
        {
            Console.WriteLine();
            Console.WriteLine("\n6. feladat");
            Console.Write("Adja meg a személy azonosítóját! ");
            string inputData = Console.ReadLine();

            while (!(users.Contains(inputData)))
            {
                Console.WriteLine("A keresett felhasználó nem található!\nAz alábbi lehetőségek közül tudsz váalsztani:");
                Console.WriteLine(string.Join(", " ,users));
                Console.Write("Adja meg a személy azonosítóját! ");
                inputData = Console.ReadLine();
            }

            return inputData;

        }

        // 7. FELADAT
        public static List<Lounge> InputUserFromToTime(string input)
        {

            List<Lounge> activeUser = new List<Lounge>();
            activeUser.Clear();
            Console.WriteLine("\n7. feladat");

            foreach (var item in doorList)
            {

                if (input == item.Id)
                {
                    Lounge line = new Lounge(item.Hour, item.Minute, item.Id, item.Direction);
                    activeUser.Add(line);
                }

            }

            for (int i = 0; i < activeUser.Count; i++)
            {
                if (i%2 == 0 || i == 0)
                {
                    Console.Write(CreateTimeFormat(activeUser[i].Hour, activeUser[i].Minute) + "-");
                }
                else
                {
                    Console.Write(CreateTimeFormat(activeUser[i].Hour, activeUser[i].Minute)+"\n");
                }
            }

            return activeUser;

        }

        // 8. FELADAT
        public static void TimeAboutInputUser(List<Lounge> activeUser)
        {
            var id =  activeUser[0].Id;
            var position = "";
            var counter = 0;
            
            if (activeUser.Count % 2 != 0)
            {
               counter = activeUser.Count + 1;

            }
            else
            {
                counter = activeUser.Count;
            }

            double minutes = 0;
            int i = 0;

            while ( i <= counter-2)
            {
                int date1_h = 0;
                int date1_m = 0;
                int date2_h = 0;
                int date2_m = 0;

                if (activeUser.Count % 2 != 0)
                {
                    if (i <= counter - 4)
                    {
                        date1_h = activeUser[i].Hour;
                        date1_m = activeUser[i].Minute;
                        date2_h = activeUser[i + 1].Hour;
                        date2_m = activeUser[i + 1].Minute;
                    }
                    else
                    {
                        date1_h = activeUser[i].Hour;
                        date1_m = activeUser[i].Minute;
                        date2_h = 15;
                        date2_m = 0;
                    }
                }
                else
                {
                    if (i <= counter - 2)
                    {
                        date1_h = activeUser[i].Hour;
                        date1_m = activeUser[i].Minute;
                        date2_h = activeUser[i + 1].Hour;
                        date2_m = activeUser[i + 1].Minute;
                    }
                }

                i = i + 2;

                DateTime date1 = new DateTime(2000, 01, 01, date1_h, date1_m, 00);
                DateTime date2 = new DateTime(2000, 01, 01, date2_h, date2_m, 00);

                DateTime startTime = date1;
                DateTime endTime = date2;

                TimeSpan span = endTime.Subtract(startTime);
                minutes = minutes + Convert.ToInt32(span.TotalMinutes);


            }

            if (activeUser.Count % 2 != 0) position = "a társalgóban volt"; else position = "nem volt a társalgóban";

            Console.WriteLine("\n\n8. feladat");
            Console.WriteLine($"A(z) {id}. személy összesen {minutes} percet volt bent, a megfigyelés végén {position}.");

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
            string inputData = Lounge.GetUserID();


            //7. Írja a képernyőre, hogy a beolvasott azonosítóhoz tartozó személy mettől meddig tartózkodott a társalgóban!
            List<Lounge> activeUser = Lounge.InputUserFromToTime(inputData);


            //8. Határozza meg, hogy a megfigyelt időszakban a beolvasott azonosítójú személy összesen hány percet töltött a társalgóban! Az előző feladatban példaként szereplő 22 - es személy 5 alkalommal járt bent, a megfigyelés végén még bent volt. Róla azt tudjuk, hogy 18 percet töltött bent a megfigyelés végéig. A 39 - es személy 6 alkalommal járt bent, a vizsgált időszak végén nem tartózkodott a helyiségben. Róla azt tudjuk, hogy 39 percet töltött ott.Írja ki, hogy a beolvasott azonosítójú személy mennyi időt volt a társalgóban, és a megfigyelési időszak végén bent volt - e még!
            Lounge.TimeAboutInputUser(activeUser);

           
            Console.ReadLine();

        }
    }
}

using System;
using System.IO;
using System.Text;
using System.Linq;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Collections.Generic;

namespace _12._08._2020_Sorozatok_V1
{

    public class Methods
    {
        public  void SumSeriesTime()
        {
            var listOfSeries = Series.Films.Select(film => film.Title).Distinct();
            List<string> AllTitles = new List<string>();

            foreach (var title in listOfSeries)
            {
                AllTitles.Add(title);
            }

            using (FileStream fs = new FileStream("summa.txt", FileMode.Create))
            {
                using (StreamWriter sw = new StreamWriter(fs, Encoding.UTF8))
                {
                    for (int i = 0; i < AllTitles.Count; i++)
                    {
                        var count = 0;
                        var filmLength = 0;
                        foreach (var film in Series.Films)
                        {
                            if (film.Title == AllTitles[i])
                            {
                                filmLength += film.Length;
                                count++;
                            }
                        }
                        string textLine = AllTitles[i] + " " + filmLength + " " + count;
                        sw.WriteLine(textLine);

                    }
                }
            }
            Console.WriteLine("\n8.Feladat\nFileba írás kész!");
        }

        public void selectDaysOfInput()
        {
            Console.Write($"\n7. feladat\nAdja meg a hét egy napját(például cs)! Nap = ");
            var userInput = Console.ReadLine().ToUpper();
            Hetnapja(userInput);
        }

        public void Hetnapja(string userInput)
        {
            string[] weekdays = new string[] { "V", "H", "K", "SZ", "CS", "P", "SZO" };

            if (weekdays.Contains(userInput))
            {
                int id = Array.IndexOf(weekdays, userInput);

                var selectUserDays = Series.Films.Where(date => date.ReleaseDate != "NI").Where(date => Convert.ToDateTime(date.ReleaseDate).DayOfWeek == (DayOfWeek)(id)).Select(film=>film.Title).Distinct();

                foreach (var titles in selectUserDays)
                {
                    Console.WriteLine(titles);
                }
            }
            else
            {
                Console.WriteLine("Az adott napon nem kerül adásba sorozat.");
                selectDaysOfInput();
            }
        }

        public static void listUnwatchedFilmsbyDate(){

            try
            {
                Console.Write($"\n5. feladat\nAdjon meg egy dátumot! Dátum = ");
                var userInput = Console.ReadLine();

                var getWatchedMinutes = Series.Films.Where(seen => seen.HaveSeen == false).Where(date => date.ReleaseDate != "NI").Where(date => Convert.ToDateTime(date.ReleaseDate) <= Convert.ToDateTime(userInput));

                if (getWatchedMinutes.Count() != 0)
                {
                    foreach (var film in getWatchedMinutes)
                    {
                        Console.WriteLine($"{film.Info}  {film.Title}");
                    }
                }
                else
                {
                    Console.WriteLine("A megadott időszakra vonatkozóan nincs találat!");
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Hibás karakterek, nem megfelelő dátumformátum!");
                listUnwatchedFilmsbyDate();
            }



        }

        public static void getWatchedTime()
        {
            var getWatchedMinutes = Series.Films.Where(seen => seen.HaveSeen == true).Select(minute =>minute.Length).Sum();
            TimeSpan ts =  TimeSpan.FromMinutes(getWatchedMinutes);

            Console.WriteLine($"\n4. feladat\nSorozatnézéssel {ts.Days} napot {ts.Hours} órát és {ts.Minutes} percet töltött.");
        }

        public static void getWatchedFilmsPercent()
        {
            double haveSeenCount = Series.Films.Where(seen => seen.HaveSeen ==true).Count();
            var result = (haveSeenCount / Series.Films.Count()).ToString("p2");
            Console.WriteLine($"\n3. feladat\nA listában lévő epizódok {result}-át látta.");
        }

        public static void getKnowDateCounts()
        {
            var countOfFilms = Series.Films.Where(date => date.ReleaseDate != "NI").Count();
            Console.WriteLine($"2. feladat\nA listában {countOfFilms} db vetítési dátummal rendelkező epizód van.");
        }

        public static void readTextFileIn()
        {
            string filePath = "lista.txt";

            using (FileStream fs = new FileStream(filePath,FileMode.Open))
            {
                using (StreamReader sr = new StreamReader(fs,Encoding.Default))
                {
                    while (!sr.EndOfStream)
                    {
                        string[] puffer = new string[5];

                        for (int i = 0; i < 5; i++)
                        {
                            puffer[i] = sr.ReadLine();
                        }

                        Series film = new Series(puffer[0], puffer[1], puffer[2], Convert.ToInt32(puffer[3]), puffer[4].Contains("1"));
                        Series.Films.Add(film);
                    }

                }
            }

            #region Check list items
            /*
            foreach (var film in Series.Films)
            {
                var dt = (DayOfWeek)(1);

                if (film.ReleaseDate != "NI")
                {
                    if (Convert.ToDateTime(film.ReleaseDate).DayOfWeek == dt)
                    {
                        Console.WriteLine($"{Convert.ToDateTime(film.ReleaseDate).DayOfWeek},{film.Title}, {film.Info}, {film.Length}, {film.HaveSeen}");
                    }
                }

                Console.WriteLine($"{film.ReleaseDate},{film.Title},{film.Info}, {film.Length},{film.HaveSeen}");
            }*/
            #endregion

        }

    }
}

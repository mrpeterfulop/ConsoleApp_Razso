using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace _21._01._04.Ceges_autok
{
    class Methods
    {
        public static List<string> cars = new List<string>();


        public static void StartProgram()
        {
            ReadFileToList();

            LastCarOut();

            TraficOnDay();

            OutOfCars();

            GetAllKm();

            GetLongestDistance();

            WriteToTextFile();

            Console.ReadKey();

        }

        public static void ReadFileToList()
        {
            using (FileStream fs = new FileStream("autok.txt", FileMode.Open))
            {
                using (StreamReader sr = new StreamReader(fs,Encoding.UTF8))
                {
                    while (!sr.EndOfStream)
                    {
                        var puffer = sr.ReadLine().Split(' ');

                        string parkInText = (puffer[5] == "0") ? "ki" : "be";

                        Movements activeLine = new Movements(Convert.ToInt32(puffer[0]), puffer[1], puffer[2], Convert.ToInt32(puffer[3]), Convert.ToInt32(puffer[4]), puffer[5].Contains("1"), parkInText);

                        Movements.carMovements.Add(activeLine);
                    }
                }
            }

            CreateCarsList();
        }

        public static void CreateCarsList()
        {
            foreach (var item in Movements.carMovements)
            {
                if (!cars.Contains(item.CarId))
                {
                    cars.Add(item.CarId);
                }
                cars.Sort();
            }
        }

        public static void LastCarOut()
        {
            Console.WriteLine("2. feladat");
            var lastDay = Movements.carMovements.Select(day => day.Day).Max();
            var carList = Movements.carMovements.Where(car => car.ParkIn == false && car.Day == lastDay).Select(car=> car.CarId).First();
            Console.WriteLine($"{lastDay}. nap rendszám: {carList}");
        }

        public static void TraficOnDay()
        {
            Console.WriteLine("3. feladat\nNap: ");
            var userInput = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine($"Forgalom a(z) {userInput}. napon:");

            foreach (var item in Movements.carMovements)
            {
                if (item.Day == userInput)
                {
                    Console.WriteLine(item.Time + " " + item.CarId + " " + item.PersonId + " " + item.ParkInText);
                }
            }
        }

        public static void OutOfCars()
        {
            Console.WriteLine("4.feladat");

            var carsOut = 0;

            for (int i = 0; i < cars.Count; i++)
            {
                var counter = 0;

                foreach (var item in Movements.carMovements)
                {
                    if (cars[i] == item.CarId)
                    {
                        counter++;
                    }
                }

                if (!(counter % 2 == 0))
                {
                    carsOut++;
                }
            }

            Console.WriteLine($"A hónap végén {carsOut} autót nem hoztak vissza.");
        }

        public static void GetAllKm()
        {
            Console.WriteLine("5. feladat");

            for (int i = 0; i < cars.Count; i++)
            {
                string actual = cars[i];
                var firstKm = Movements.carMovements.Where(cars => cars.CarId == actual).First().Km;
                var lastKm = Movements.carMovements.Where(cars => cars.CarId == actual).Last().Km;
                Console.WriteLine($"{cars[i]} {lastKm- firstKm} km");
            }
        }

        public static void GetLongestDistance(){

            List<Movements> Puffer = new List<Movements>();

            var recordDistance = 0;
            var recordPerson = 0;

            for (int i = 0; i < cars.Count; i++)
            {

                Puffer.Clear();
                foreach (var item in Movements.carMovements)
                {
                    if (item.CarId == cars[i])
                    {
                        Puffer.Add(item);
                    }
                }
                
                for (int j = 0; j < Puffer.Count / 2; j++)
                {
                    var distance = Puffer[j + j + 1].Km - Puffer[j + j].Km;

                    if (recordDistance < distance)
                    {
                        recordDistance = distance;
                        recordPerson = Puffer[j + 1].PersonId;
                    }
                }
            }

            Console.WriteLine("6.feladat");
            Console.WriteLine($"Leghosszabb út: {recordDistance} km, személy: {recordPerson}");

        }

        public static void WriteToTextFile()
        {
            Console.WriteLine("7. feladat\nRendszám: ");

            var userInput = Console.ReadLine();

            var fileName = $"{userInput}_menetlevel.txt";

            using (FileStream fs = new FileStream(fileName,FileMode.Create))
            {

                using (StreamWriter sw = new StreamWriter(fs, Encoding.UTF8))
                {

                    var actualPerson = 0;
                    var firstTime = true;

                    foreach (var item in Movements.carMovements)
                    {
                        var tab = '\u0009';

                        if (item.CarId == userInput && firstTime)
                        {
                                var line = $"{item.PersonId}\t{item.Day}. {item.Time}\t{item.Km} km";
                                sw.Write(line);
                                actualPerson = item.PersonId;
                                firstTime = false;
                        }

                        else if(item.CarId == userInput)
                        {
                            if (actualPerson == item.PersonId)
                            {
                                var line = $"{tab}{item.Day}. {item.Time}\t{item.Km} km";
                                sw.Write(line);
                            }
                            else
                            {
                                var line = $"\n{item.PersonId}\t{item.Day}. {item.Time}\t{item.Km} km";
                                sw.WriteLine();  
                                sw.Write(line.Trim());
                            }
                            actualPerson = item.PersonId;
                        }

                    }
                }
                Console.WriteLine("Menetlevél kész.");
            }
        }
    }
}

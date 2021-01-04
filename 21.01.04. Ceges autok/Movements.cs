using System.Collections.Generic;

namespace _21._01._04.Ceges_autok
{
    class Movements
    {
        public static List<Movements> carMovements = new List<Movements>();


        public int Day { get; set; }
        public string Time { get; set; }
        public string CarId { get; set; }
        public int PersonId { get; set; }
        public int Km { get; set; }
        public bool ParkIn { get; set; }
        public string ParkInText { get; set; }


         
        public Movements(int day, string time, string carId, int personId, int km, bool parkIn, string parkInText)
        {
            Day = day;
            Time = time;
            CarId = carId;
            PersonId = personId;
            Km = km;
            ParkIn = parkIn;
            ParkInText = parkInText;
        }



    }
}

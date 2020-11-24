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
}

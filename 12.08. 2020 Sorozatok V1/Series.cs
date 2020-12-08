using System.Collections.Generic;

namespace _12._08._2020_Sorozatok_V1
{
    public class Series
    {

        public static List<Series> Films = new List<Series>();

        string releaseDate;
        string title;
        string info;
        int length;
        bool haveSeen;

        public Series(string releaseDate, string title, string info, int length, bool haveSeen)
        {
            ReleaseDate = releaseDate;
            Title = title;
            Info = info;
            Length = length;
            HaveSeen = haveSeen;
        }

        public string ReleaseDate { get => releaseDate; set => releaseDate = value; }
        public string Title { get => title; set => title = value; }
        public string Info { get => info; set => info = value; }
        public int Length { get => length; set => length = value; }
        public bool HaveSeen { get => haveSeen; set => haveSeen = value; }

    }
}

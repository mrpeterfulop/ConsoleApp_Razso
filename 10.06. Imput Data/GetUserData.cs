using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace _10._06.Imput_Data
{

    public class GetUserData
    {
        string username = "";

        public string Data()
        {
            Console.WriteLine("Szia! Kérlek add meg a felhasználóneved:");
            username = Console.ReadLine();
            return username;
        }

    }
}
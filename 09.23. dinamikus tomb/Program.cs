using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _09._23.dinamikus_tomb
{
    class Program
    {
        static void Main(string[] args)
        {


            var rnd = new Random();
            var myList = new List<int>() {};
            

            for (int i = 0; i < 50; i++)
            {
                var getRandom = rnd.Next(100, 999);
                myList.Add(getRandom);

                var a = (i + 1 < 10) ? "0" : "";
                       
                Console.WriteLine($"A lista {a}{i+1}. eleme: {myList[i]}");

            }


            Console.ReadLine();



        }
    }
}

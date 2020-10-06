using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09._30._01_coin_counterfeiting
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.ForegroundColor = ConsoleColor.Green; //Betűszín módosítása a konzolon!
            //var coin = new Coin();
            var coin = new FakeCoin();
            //var coin = (Coin)(new FakeCoin()); //Coin osztály tipusú lesz a FakeCoin, kasztolással!
            //Coin coin = new FakeCoin();

            DoGetCoin(coin);
            Console.ReadKey();
        }
        

        private static void DoGetCoin(Coin coin) //paraméter átadás történik, un. kasztolás.
        {
            Console.WriteLine("Az érmefeldobás eredménye:");
            for (int i = 0; i < 100; i++)
            {
                Console.Write($"{coin.getCoin()}, ");
            }
        }
    }
}


using System;

namespace _10._26.Gyakorlas
{
    class Adatbekeres {

        public int Beker()
        {
            Console.WriteLine($"Adj meg egy számot 1-40 ig:");
            
            var valasz = Console.ReadLine();
            int szam;
            while (!int.TryParse(valasz, out szam) || szam <= 0 || szam > 40)
            {
                Color.Red();
                Console.WriteLine($"Hibásan bevitt adatok! Csak pozitív egész számot adj meg!");
                Color.White();
                Console.WriteLine($"Adj meg egy számot 1-40 ig:");

                valasz = Console.ReadLine();
            }

            return szam;
        }

    }
}

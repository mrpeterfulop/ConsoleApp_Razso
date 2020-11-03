using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10._26.Fibonacci
{

    public class GetData
    {
        public int getData()
        {
            var firstText = "A Fibonacci sorozat elkészítéséhez adj meg egy számot 1 és 40 között:";
            Console.WriteLine(firstText);

            var answer = Console.ReadLine();
            int number;
            while (!int.TryParse(answer, out number) || number <= 0 || number > 40)
            {
                Color.Red();
                Console.WriteLine($"Hibásan bevitt adatok! A kapott érték nem felel meg a kritériumoknak!");
                Color.White();
                Console.WriteLine(firstText);

                answer = Console.ReadLine();
            }

            return number;
        }

    }


}

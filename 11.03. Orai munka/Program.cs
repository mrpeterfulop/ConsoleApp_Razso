using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace _11._03.Orai_munka
{

    public class ListOperation
    {



    }




    class Program
    {
        static void Main(string[] args)
        {
            List<int> Numbers = new List<int>();
            List<int> evenNumbers = new List<int>();
            List<int> oddNumbers = new List<int>();
            
            fillList(getData(), Numbers);
            sortValues(Numbers, evenNumbers, oddNumbers);

            Console.ReadKey();
        }

        public static int getData()
        {
            string Msg1 = "Adj meg egy pozitív egész számot:";
            Console.WriteLine(Msg1);
            string input = Console.ReadLine();


            while (!int.TryParse(input, out int num) || num <= 0 || Int32.MaxValue <= num)
            {
                Console.WriteLine(Msg1);
                input = Console.ReadLine();
            }
            return Convert.ToInt32(input);


        }

        public static void fillList(int input, List <int> Numbers)
        {
            Random rnd = new Random();

            for (int i = 0; i < input; i++)
            {
                Numbers.Add(rnd.Next(1, 101));
            }

            Console.Clear();
            Console.WriteLine($"A lista {Numbers.Count}db eleme:\n{string.Join(";", Numbers)}\n");

        }

        public static void sortValues(List<int> Numbers, List<int> evenNumbers, List<int> oddNumbers)
        {
            for (int i = 0; i < Numbers.Count; i++)
            {
                if (Numbers[i] % 2 == 0)
                {
                    evenNumbers.Add(Numbers[i]);
                }
                else
                {
                    oddNumbers.Add(Numbers[i]);
                }
            }

            Console.WriteLine($"Páros szám: {evenNumbers.Count}db:\n{string.Join(";", evenNumbers)}\n");
            Console.WriteLine($"Páratlan szám: {oddNumbers.Count}db:\n{string.Join(";", oddNumbers)}\n");

        }
        
    }
}

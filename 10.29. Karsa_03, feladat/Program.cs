using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10._29.Karsa_03__feladat
{
    class Program
    {
        static void Main(string[] args)
        {

            List<int> payments = new List<int>();


            var coll = getUserData();
            var input = generatePayments(coll, payments);
            var str = decProcess(Convert.ToString(input)," Euro");

            writePayments(coll, payments, str);

            Console.ReadKey();

        }

        public static string decProcess(string input, string ending = " Ft")
        {
            var a = input;
            string num;
            string dec;

            a = a.Replace(" ", "");
            a = a.Replace(".", ",");

            var nr = 0;
            for (int i = 0; i < a.Length; i++)
            {
                char ch = a[i];
                if (ch == ',')
                {
                    nr++;
                }
            }

            if (a.Contains(","))
            {
                //Ha több vessző van, redukálja egyre!
                var lastDec = a.LastIndexOf(",");
                a = a.Replace(",", "");
                a = a.Insert((lastDec - nr + 1), ",");

                // Tizedesek külön váalsztása
                var start = a.LastIndexOf(",");
                var end = a.Length - 1 - start;
                dec = "," + a.Substring(start + 1, end);
                num = a.Substring(0, start);
                a = num;

            }
            else
            {
                dec = null;
            }

            var getLength = a.Length;
            double muvelet = (double)getLength / 3;

            for (int i = 0; i < muvelet; i++)
            {
                if (muvelet > 1)
                {
                    if (i != 0)
                    {
                        a = a.Insert(getLength - i * 3, ".");
                    }
                }
            }
            a = a + dec + ending;
            return a;
        }

        static int getUserData()
        {

            Console.WriteLine("Add meg a dolgozók számát:");
            int coll;

            while (!int.TryParse(Console.ReadLine(), out coll) || !(5 < coll && 101 > coll))
            {
                Console.WriteLine("Add meg a dolgozók számát:");

            }
            return coll;
        }

        static int generatePayments(int coll, List <int> payments)
        {

            Random rnd = new Random();

            for (int i = 0; i < coll; i++)
            {
                var pay = rnd.Next(900, 2800);
                payments.Add(pay);
            }
            var sum = payments.Sum();

            return sum;

        }

        static void writePayments(int coll, List<int> payments, string sum)
        {
            
            
            Console.Clear();
            Console.WriteLine($"\nA {coll} dolgozó fizetési listája: \n");

            var nr = 0;
            foreach (var item in payments)
            {
                var call = decProcess(Convert.ToString(item), " Euro");
                nr++;
                Console.WriteLine($"{nr}. dolgozó fizetése: {call}");
            }

            var maxValue = decProcess(Convert.ToString(payments.Max()), " Euro");
            var minValue = decProcess(Convert.ToString(payments.Min()), " Euro");

            Console.WriteLine($"\nA(z) {nr} dolgozó fizetése összesen: {sum}.");
            Console.WriteLine($"A legmagasabb fizetés: {maxValue}, a {payments.IndexOf(payments.Max())+1}.számú dolgozóé.");
            Console.WriteLine($"A legalacsonyabb fizetés: {minValue}, a {payments.IndexOf(payments.Min())+1}.számú dolgozóé.");

        }

    }
}

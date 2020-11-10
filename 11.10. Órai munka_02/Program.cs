using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11._10.Órai_munka_02
{
    static class StaticClass
    {
        public static int Tester()
        {
            return 10;
        }

    }


    class Program
    {
        static public IEnumerable EnumerableMethod(int max)
        {
            for (int i = 0; i < max; ++i)
            {
                yield return i;
            }
        }

        static void Main(string[] args)
        {
            /* //KÖNYV
            foreach (int i in EnumerableMethod(10))
            {
                Console.Write(i);
            }
            */

            foreach (var item in sorozatlista())
            {
                Console.WriteLine(item);
            }

            sorozatlista();

            var a = new Program();
            a.Probacseresznye();


            Console.ReadKey();
        }

        private static IEnumerable<object> sorozatlista()
        {
            yield return "valami1";
            yield return "valami2";
            yield return "valami3";
            yield return "valami4";

        }

        private int Probacseresznye()
        {
            Console.WriteLine("01");
            return 1;
        }

    }
}

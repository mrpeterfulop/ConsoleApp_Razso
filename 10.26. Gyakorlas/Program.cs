using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace _10._26.Gyakorlas
{

    class Program
    {
        static void Main(string[] args)
        {
            Adatbekeres beker = new Adatbekeres();
            Muvelet muv = new Muvelet();


            var loop = true;

            while (loop)
            {
                start(beker, muv);
                Color.Magenta();
                Console.WriteLine("Szeretnéd újraindítani a programot? Y = Igen");
                Console.WriteLine("Kilépéshez: tetszőleges bill. + ENTER");
                Color.White();
                var ans = Console.ReadLine();
                if (ans.ToUpper() == "Y")
                {
                    loop = true;
                    Console.Clear();

                }
                else
                {
                    loop = false;
                }

            }

        }

        private static void start(Adatbekeres beker, Muvelet muv)
        {
            
            int sz = beker.Beker();
            muv.clearLists();
            muv.Do(sz);
            muv.selectData(sz);
        }
    }
}

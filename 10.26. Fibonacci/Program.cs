using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10._26.Fibonacci
{

    
    class Program
    {
        static void Main(string[] args)
        {
            GetData get = new GetData();
            Operation op = new Operation();
            var loop = true;
            startProgram(get, op, loop);
        }

        private static bool startProgram(GetData get, Operation op, bool loop)
        {
            while (loop)
            {
                loopProgram(get, op);
                Color.Magenta();
                Console.WriteLine("Újraindítás: Y + ENTER\nKilépés: tetszőleges bill. + ENTER");
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
            return loop;
        }

        private static void loopProgram(GetData get, Operation op)
        {
            int input = get.getData();
            op.clearLists();
            op.Do(input);
            op.selectData(input);
        }

    }
}

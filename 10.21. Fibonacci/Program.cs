using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10._21.Fibonacci
{
    class Program
    {
        static void Main(string[] args)
        {

            var get = new GetData();
            var run = new RunFibonacci();
            var write = new WriteConsole();
            bool loopProgram = true;

            loopProgram = Start(get, run, write, loopProgram);

        }

        private static bool Start(GetData get, RunFibonacci run, WriteConsole write, bool loopProgram)
        {
            while (loopProgram)
            {
                Program.loopProgram(get, run, write);
                Console.WriteLine("\nÚjraindításhoz: Y + ENTER");
                Console.WriteLine("Kilépéshez: tetszőleges bill. + ENTER");

                var a = Console.ReadLine();
                if (a.ToUpper() == "Y")
                {
                    loopProgram = true;
                }
                else
                {
                    loopProgram = false;
                }
            }
            return loopProgram;
        }

        private static void loopProgram(GetData get, RunFibonacci run, WriteConsole write)
        {
            get.getData();
            run.runFibonacci(get.input);
            run.selectValues();
            write.writeData(get.input);


        }


    }
}

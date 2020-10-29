using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10._29.Karsa_01
{
    class Program
    {
        static void Main(string[] args)
        {

            GetData g = new GetData();
            Operation o = new Operation();
            ConsoleWrite c = new ConsoleWrite();

            g.GetDataPath1(ref g.num1);
            g.GetDataPath2(ref g.num2);
            o.Oper(ref g.num1, ref g.num2, out bool value, out o.evenOdd);
            c.WriteData(ref g.num1, ref g.num2, ref o.sum, o.evenOdd);






            Console.ReadKey();

        }

   }
}

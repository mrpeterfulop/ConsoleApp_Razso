using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10._29.Karsa_01
{
    public class GetData
    {
        
        public int num1;
        public int num2;

        public int GetDataPath1(ref int num1)
        {
            Console.WriteLine("Add meg az 1. számot: ");
             num1 = Convert.ToInt32(Console.ReadLine());
            return num1;
        }

        public int GetDataPath2(ref int num2)
        {
            Console.WriteLine("Add meg a 2. számot: ");
             num2 = Convert.ToInt32(Console.ReadLine());
            return num2;
        }

    }


}

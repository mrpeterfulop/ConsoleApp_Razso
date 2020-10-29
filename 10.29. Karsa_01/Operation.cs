using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10._29.Karsa_01
{
    public class Operation
    {

        public int sum;
        public bool value;
        public string evenOdd;


        public int Oper(ref int num1, ref int num2, out bool value, out string evenOdd)
        {
            num1++;
            sum = num1 + num2;

            if (sum % 2 == 0)
            {
                value = true;
                evenOdd = "páros";
            }
            else
            {
                value = false;
                evenOdd = "páratlan";

            }

            return sum;

        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10._21.Fibonacci
{
    public class GetData
    {


          
        public int input;        
        bool loopGetData = true;
        bool loopTry = true;

        public int getData()
        {

            do
            {
                try
                {

                    do
                    {
                       Console.WriteLine("Adj meg egy pozitív egész számot 1 és 40 között!");
                       input = Convert.ToInt32(Console.ReadLine());

                        if (input > 40 || input < 1)
                        {
                            ColorAlerts.colorRed();
                            Console.WriteLine("Hibásan megadott érték!");
                            loopGetData = true;
                            ColorAlerts.colorWhite();
                        }
                        else
                        {
                            loopGetData = false;
                            loopTry = false;
                        }

                    } while (loopGetData == true);

                }

                catch (Exception)
                {
                    loopTry = true;
                    ColorAlerts.colorRed();
                    Console.WriteLine("Hibás formátum!");
                    ColorAlerts.colorWhite();
                }

            } while (loopTry == true);

            return input;

        }

    }
}
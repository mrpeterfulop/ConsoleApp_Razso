using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10._07.Random_Array_with_Input
{
    class Program
    {

      /*
      Feladat
      Készíts programot, ami bekér a felhasználótól egy egész számot.Ennek a felhasználásával készíts egy olyan sorozatot, amit véletlen számokkal(1-1000) tölt fel a program.Ellenőrizze, hogy a felhasználó csak egész számot (mást nem) adott meg.
          • írasd ki a sorozat utolsó elemét
          • írasd ki a sorozat eredményét egy sorba
          • írasd ki a legnagyobb értékét
          • írasd ki a legkisebb értékét
          • rendezd a sorozatot növekvő sorrendbe
        A feladat megoldásához használj osztályt, függvényt, ciklust.A kiíratásokat a megadott sorrendbe végazd el!
        */
        static void Main(string[] args)
        {

           var print = new PrintData();
           print.writeAll();

           Console.WriteLine("Program vége");
           Console.ReadLine();
        }
    }
}

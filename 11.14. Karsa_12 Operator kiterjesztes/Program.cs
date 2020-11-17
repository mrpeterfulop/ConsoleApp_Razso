using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11._14.Karsa_12_Operator_kiterjesztes
{
    class EgeszSzam {

        int szam;
        public int Szam { get => szam; set => szam = value; }

        public EgeszSzam(int szam)
        {
            this.szam = szam;
        }

        public static EgeszSzam operator +(EgeszSzam sz1, EgeszSzam sz2)
        {
            return new EgeszSzam(sz1.szam + sz2.szam);
        }

        // Ha az egyenlőség operátort vizsgáljuk, ki kell dolgoznunk mellé a "nem egyenlő" verziót is!
        public static bool operator ==(EgeszSzam sz1, EgeszSzam sz2)
        {
            return sz1.szam == sz2.szam ? true : false;
        }

        public static bool operator !=(EgeszSzam sz1, EgeszSzam sz2)
        {
           // return sz1.szam != sz2.szam ? false : true;
            return !(sz1 == sz2);
        }

        public static EgeszSzam operator ++(EgeszSzam sz1)
        {
            sz1.szam += 1;
            return sz1;
        }

        public static implicit operator EgeszSzam(int sz)
        {
            return new EgeszSzam(sz);
        }
        public static explicit operator EgeszSzam(string sz)
        {
            return new EgeszSzam(int.Parse(sz));
        }


    }

    public class RectAngle
    {
        public int Width = 0;
        public int Height = 0;

        public RectAngle(int width, int height)
        {
            Width = width;
            Height = height;
        }

        public static RectAngle operator + (RectAngle rect1, RectAngle rect2)
        {
            RectAngle rectResult = new RectAngle(rect1.Width + rect2.Width, rect1.Height + rect2.Height);
            return rectResult;

        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            // Operátor kiterjesztés
            // Lényege, hogy műveleteket végezhessünk objektumokkal, mintha egyszerű értéktípusok lennének.

            EgeszSzam a = new EgeszSzam(54);
            EgeszSzam b = new EgeszSzam(27);
            EgeszSzam ossz = a + b;

            var plan1 = a != b;
            var plan2 = a == b;

            EgeszSzam plan3 = a++;

            EgeszSzam plan4 = 243;
            EgeszSzam plan5 = (EgeszSzam)"568";


            Console.WriteLine($"a változó értéke: {a.Szam}");
            Console.WriteLine($"a változó értéke: {b.Szam}\n");

            Console.WriteLine("Operátor kiterjesztés, összeadás: " + ossz.Szam);
            Console.WriteLine("Operátor kiterjesztés, bool értékvizsgálat 1: " + plan1);
            Console.WriteLine("Operátor kiterjesztés, bool értékvizsgálat 2: " + plan2);
            Console.WriteLine("Operátor kiterjesztés, 1 operandus, ++: " + plan3.Szam);
            Console.WriteLine("Operátor kiterjesztés, implicit mód (int > string): " + plan4.Szam + ", mint string");
            Console.WriteLine("Operátor kiterjesztés, explicit mód (string > int): " + plan5.Szam + ", mint integer");

            Console.WriteLine();

            RectAngle var1 = new RectAngle(16,8);
            RectAngle var2 = new RectAngle(12,14);

            RectAngle sumVar1Var2 = var1 + var2;

            Console.WriteLine("Sum Widths: 'RectAngle(16,8)' + 'RectAngle(12,14)' = " + sumVar1Var2.Height);
            Console.WriteLine("Sum Heights: 'RectAngle(16,8)' + 'RectAngle(12,14)' = " + sumVar1Var2.Width);


            Console.ReadKey();

        }
    }
}

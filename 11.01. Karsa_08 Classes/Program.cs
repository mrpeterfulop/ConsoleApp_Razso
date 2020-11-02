using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11._01.Karsa_08_Classes
{

    class Craft
    {
        public int speed;

        public Craft(int sp)
        {
            speed = sp;
        }

        public int Go(int h)
        {
            return h * speed;
        }
    }

    class Car : Craft
    {
        public int doors;
        public int carTrunk;

        public Car(int speed, int doors, int carTrunk) : base(speed)
        {
            this.doors = doors;
            this.carTrunk = carTrunk;
        }

    }



    /////////////////////////////////////////////

    class A
    {
        private int a;
        public A(int a)
        {
            this.a = a;
        }
    }

    class B : A
    {
        // 1. Az ősosztály konstruktora minden esetben lefut a származtatott osztályokban, hiszen minden mezőt, paramétert, metódust megörököl. 
        // 2. Ha az ősosztály konstruktora kapott paramétert, akkor azt valahogy a származtatott osztályban is jelezni kell! A ": base()"szignatúra bevezetésével, és az ősosztály átadott paraméterének lokális, újrafelvételével tudjuk "átemelni" az ősosztályban kapott paramétert!
        protected int b;
        public B(int b, int a) : base(a)
        {
            this.b = b;
        }
    }

    class OldClass
    {
        public int old;

        private int constPar = 4;

        public OldClass(int constPar)
        {
            old = 10 + constPar;
            Console.WriteLine("Ez az ősosztály konstruktora: " + old);
        }

    }

    class  ChildrenClass1 : OldClass // Öröklődés >> inheritance
    {
        // 1. Az ősosztály konstruktora minden esetben lefut a származtatott osztályokban, hiszen minden mezőt, paramétert, metódust megörököl. 
        // 2. Ha az ősosztály konstruktora kapott paramétert, akkor azt valahogy a származtatott osztályban is jelezni kell! A ": base()"szignatúra bevezetésével, és az ősosztály átadott paraméterének lokális, újrafelvételével tudjuk "átemelni" az ősosztályban kapott paramétert!


        public ChildrenClass1(int constPar) : base(constPar) 
        {
            Console.WriteLine("Örökölt konstruktor lefutása, paraméterekkel!");
        }

        public int Osszeg(int a, int b)
        {
            Console.WriteLine("A művelet összege: " + (a + b));
            return a + b;
        }

    }

    /////////////////////////////////////////////
    static class statAllandok
    {


    }
    class Allandok
    {
        
        //private static double PI = 3.14;

        public static double PropPI
        {
            get { return 3.14; }
        }

    }
    class Diak {

        public string nev;
        public byte evfolyam;

        
        public void Kiir()
        {
            Console.WriteLine($"Név: {nev}\nÉvfolyam: {evfolyam}");
        }
        

         public static void Kiir(Diak d)
        {
            Console.WriteLine($"Név: {d.nev}\nÉvfolyam: {d.evfolyam}");
        }

        
        public static string nev2;
        public static byte evfolyam2;

        public static void Kiir2()
        {
            Console.WriteLine($"Név: {nev2}\nÉvfolyam: {evfolyam2}");
        }

    }
    class Ido
    {
        private int s;
        public int Masodperc
        {
            set { s = value; }
        }

        public double Perc
        {
            get { return s / 60.0; }
        }
        

    }
    class Pont
    {
        private int x;
        private int y;

        public Pont(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public Pont()
        {

        }


        public int X {

            get { return x; }
            set {

                if (value > 0 && value < Console.WindowWidth)
                {
                    x = value;
                }
                else
                {
                    Exception("Rossz koordináta!");
                }

            }

        }
        
        public int Y {

            get { return y; }
            set {
                if (value > 0 && value < Console.WindowHeight)
                {
                    y = value;
                }
                else
                {
                    Exception("Rossz koordináta!");
                }
            }
        }

        private void Exception(string s)
        {
            throw new FormatException(s);
        }


        public void Kirajzol()
        {
            Console.SetCursorPosition(X, Y);
            Console.WriteLine("x");
        }

    }
    class Ember
    {
        public string name;
        private string email;
        protected int age;
        string home;



        public Ember(string n, string e, int a, string h)  //Konstruktor
        {
            name = n;
            email = e;
            age = a;
            home = h;
        }

        ~Ember()  //Destruktor
        {

        }
    }
    /////////////////////////////////////////////
    class Program
    {

        static void CraftWrite(Craft c, int h)
        {

            Console.WriteLine($"A jármű sebessége: {c.speed}");
            Console.WriteLine($"Megtett út: {c.Go(h)}");

            if (c is Car) // Ha a változó az osztályból került példányodításra
            {
                Car car = (Car)c;
                Console.WriteLine(car.carTrunk);
                Console.WriteLine(car.doors);

            }
        }
        static void CraftWrite2(Craft c, int h)
        {

            Console.WriteLine($"A jármű sebessége: {c.speed}");
            Console.WriteLine($"Megtett út: {c.Go(h)}");
            Car car = c as Car;

            if (c !=null) // Ha a változó az osztályból került példányodításra
            {
                Console.WriteLine(car.carTrunk);
                Console.WriteLine(car.doors);

            }
        }

        static void Main(string[] args)
        {

            //Pont p = new Pont();
            //p.X = 11;
            //p.Y = 11;


            //Pont p = new Pont(25,2);
            //p.Kirajzol();


            // Ido t = new Ido();
            // t.Masodperc = 120;
            // Console.WriteLine(t.Perc);

            /*
            Diak d = new Diak();
            d.nev = "Peti";
            d.evfolyam = 7;
            d.Kiir();

            //Diak d = new Diak();
            d.nev = "Laci";
            d.evfolyam = 11;
            Diak.Kiir(d);

            Diak.nev2 = "Zolika";
            Diak.evfolyam2 = 4;
            Diak.Kiir2();

            Console.WriteLine($"Állandók, PI értéke: {Allandok.PropPI}");
            */

            /// OOP öröklődések
            /*
            ChildrenClass1 ch1 = new ChildrenClass1();
            var a = 6;
            var b = 10;

            ch1.Osszeg(a,b);
            */


            Craft craft = new Craft(30);
            CraftWrite(craft, 2);

            Car car = new Car(50,5,120);
            CraftWrite(car, 2);


            Craft craft2 = car;


            Console.ReadKey();
        }
    }
}

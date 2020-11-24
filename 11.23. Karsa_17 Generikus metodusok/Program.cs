using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11._23.Karsa_17_Generikus_metodusok
{

    public class Parent<T> { }
    public class Child1<T> : Parent<T> {

        int number;
        string text;

        public int Number { get => number; set => number = value; }
        public string Text { get => text; set => text = value; }


        public int testMethod(int i)
        {
            return number++;

        }
    }
    public class Child2 : Child1<string> { } // Generikus osztály elveszíti a generikusságát. Csak a "string" típusok öröklődnek!!!


    class GenWithMoreParameters<T, U, K> { }
    class GenPelda<T> where T : class { }


    class GenPuffer<T>
    {

        private T[] puffer;
        private int index = 0;

        public GenPuffer(int kapacity)
        {
            puffer = new T[kapacity]; 
        }

        public T Add
        {
            set {

                try
                {
                    puffer[index++] = value;
                }
                catch (IndexOutOfRangeException)
                {
                    Console.WriteLine("Megtelt a tároló!"); 
                }
            }
        }

        public T query(int i)
        {
           return puffer[i];
        }
    }
    class Generic<T>
    {
        T ertek;
        public T Ertek
        {
            get {return ertek; }
            set { ertek = value; }
        }
    }

    class GenClass
    {
        public static void ChangeParameters<T>(ref T a, ref T b)
        {
            T x = a;
            a = b;
            b = x;
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            // Generikus metódus, példa 1.
            int a = 457;
            int b = 123;
            Console.WriteLine("Generikus metódus, példa 1.");
            Console.WriteLine($"'a' értéke: {a} 'b' értéke: {b}");
            GenClass.ChangeParameters(ref a, ref b);
            Console.WriteLine($"'a' értéke: {a} 'b' értéke: {b}\n");

            // Generikus metódus, példa 2.
            string c = "alma";
            string d = "körte";
            Console.WriteLine("Generikus metódus, példa 2.");
            Console.WriteLine($"'c' értéke: {c} 'd' értéke: {d}");
            GenClass.ChangeParameters(ref c, ref d);
            Console.WriteLine($"'c' értéke: {c} 'd' értéke: {d}\n");

            // Generikus osztály, példa 1.
            Console.WriteLine("Generikus osztály, példa 1.");
            Generic<string> genClassStr1 = new Generic<string>();
            genClassStr1.Ertek = "alma";
            Console.WriteLine("Generic<string> genClassStr1.Ertek = " + genClassStr1.Ertek+'\n');


            // Generikus osztály, példa 2.
            Console.WriteLine("Generikus osztály, példa 2.");
            Generic<int> genClassStr2 = new Generic<int>();
            genClassStr2.Ertek = 123876;
            Console.WriteLine("Generic<int> genClassStr1.Ertek = " + genClassStr2.Ertek+'\n');



            Console.WriteLine("\nGenerikus osztály, generikus tömb.\n");
            GenPuffer<int> intPuffer = new GenPuffer<int>(10);
            intPuffer.Add = 32;
            Console.WriteLine("intPuffer.query(0)): " + intPuffer.query(0));


            Console.WriteLine("\nGenerikus osztály öröklődések:");
            var child1_text = new Child1<string>();
            var child_numb = new Child1<int>();

            child1_text.Text = "Szöveg";
            child_numb.Number = 100;

            Console.WriteLine($"'child1.Text': {child1_text.Text}, 'child1.Number': { child_numb.Number}");


            var c2 = new Child2();
            c2.Number = 99;
            c2.Text = "Szöveg 2";


            Console.WriteLine($"'child2.Text': {c2.Text}, 'child2.Number': { c2.Number}");

            Console.ReadLine();
        }
    }
}

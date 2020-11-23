using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11._17.Karsa_13__Delegate__event
{
    //A delegate-ek olyan típusok, amelyek egy-egy metódusra vagy metódusokra mutatnak, egy delegate megadásával olyan mutatót hozunk létre, amely a megadott metódusra hivatkozik. A metódusra hivatozó delegate paraméterlistájának meg kell eggyeznie a megadott metódus paraméterlistájával, a delegate ezután példányosítás után használható, konstruktorának a hivatkozott metódust kell megadnunk, majd a delegate objektum nevével hívjuk meg.

    class Delegate
    {
        public delegate void Meghivas(int i);
        public static void Ciklus(Meghivas mh)
        {
            for (int i = 0; i < 100; i++)
            {
                mh(i);
            }
        }
    }

    //Az event-eket másnéven eseményeket használó osztályok az osztály állapotának megváltoztatásakor értesíthetnek más osztályokat. Úgy, hogy az eseményt használó osztály egy eseménykezelővel meghívja azokat a metódusokat, amelyek feliratkoztak az eseményre. Az eseményhez meg kell adnunk egy delegate-t is, amivel az eseményhez megfelelő szignatúrát adjuk meg.Létezik beépített delegate (EventHandler), erről késöbb.

    class Number
    {
        public delegate void EventHandler(string str);
        public event EventHandler statusChange;
        int numb;
        public int Numb {
            get { return numb; }
            set { numb = value;
                statusChangeMethod();
            }
        }
        private void statusChangeMethod()
        {
            if (statusChange != null)
            {
                statusChange("Megváltozott a mező!");
            }
        }


    }
    /*
    class ObjectBoxUnbox
    {
        int a = 120;

        public int A { get => a; set => a = value; }

        public override string ToString()
        {
            return A.ToString();
        }

        public override bool Equals(object obj)
        {
            ObjectBoxUnbox OBU = obj as ObjectBoxUnbox;

            if (OBU != null)
              if (OBU.a == this.a) return true;
            return false;
            
        }



    }
    */
    class Program
    {
        delegate void VoidDelegate(string name);
        static void Method1()
        {
           Console.WriteLine("Metódus1 ");
        }
        static void Method2(string name)
        {
            Console.WriteLine("Metódus2 " + name);
        }
        static void Method3(string name)
        {
            Console.WriteLine(name + " Metódus3");
        }

        public static void consoleWr(int i)
        {
            Console.WriteLine($"i=={i}");
        }

        static void EventHandlerProgram(string str)
        {
            Console.WriteLine(str);
        }




        static void Main(string[] args)
        {
            ///Delegate
            VoidDelegate vd = new VoidDelegate(Method2);
            vd += Method3;
            vd("alma");

            Delegate.Meghivas dg = new Delegate.Meghivas(consoleWr);
            Delegate.Ciklus(dg);



            ///Event
            Number nbr = new Number();
            nbr.statusChange += EventHandlerProgram;

            nbr.Numb = 20;
            Console.WriteLine($"Numb érték: {nbr.Numb}");
            nbr.Numb = 20;
            Console.WriteLine($"Numb érték: {nbr.Numb}");
            nbr.Numb = 10;
            Console.WriteLine($"Numb érték: {nbr.Numb}");
            nbr.Numb = 10;


            //C# Programozás 34.rész - OOP12 - Object osztály, boxing, unboxing

            Console.WriteLine("Object osztály, boxing, unboxing");
            //ObjectBoxUnbox OBU = new ObjectBoxUnbox();


            OBU.A = 100000;
            var strA = OBU.ToString();

            Console.WriteLine(strA);


            // Boxing, unboxing
            int a = 11;
            object b = a;
            int c = (int)b;
            byte d = (byte)b;


            Console.ReadLine();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11._01.Karsa_Késői__korai_kötés__polimorfizmus
{

    partial class PartialClass
    {

        public void Kiir()
        {

            Console.WriteLine("Parciális osztály pálda, 1!");
        }


        partial void NewPartialMethod();
    }
    partial class PartialClass
    {

        public void Kiir2()
        {

            Console.WriteLine("Parciális osztály pálda, 2!");
        }
    }







    class Kulso
    {
        private int szam = 15;
        private Belso b;

        public Kulso()
        {
            b = new Belso(this);
        }


        public class Belso
        {
            private Kulso k;        
            public Belso(Kulso k)   /// | 
            {                       /// |> A konstruktorokon keresztül, paraméter átadással érik el egymást az osztályok! Kell egy referencia oda-vissza, ami alapján kapcsolat lesz köztük!
                this.k = k;         /// |
            }                      

             public void Hello()
            {
                Console.WriteLine("Hello vilag!" + k.szam);
            }
        }

    }

    class Fegyver { 
        public virtual int Sebzes()
        {
            return 20;
        }
        
    }
    class Gepfegyver : Fegyver
    {
        public override int Sebzes()
        {
            return 5* 20;
        }
    }
     class Program
    {

        static void Elsut(Fegyver f)
        {
            Console.WriteLine($"Sebzés: {f.Sebzes()}");
        }

        static void Main(string[] args)
        {
            Fegyver f = new Fegyver();
            Elsut(f);

            Gepfegyver g = new Gepfegyver();
            Elsut(g);


            PartialClass pc = new PartialClass();

            pc.Kiir();
            pc.Kiir2();
        


            Console.ReadKey();

        }
    }
}

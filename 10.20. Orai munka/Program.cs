using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;

namespace _10._20.Orai_munka
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            List<string> lines = File.ReadLines(@"C:\Users\xqsmb8\Documents\data.txt").ToList();

            foreach (string line in lines)
            {
                Console.WriteLine(line);
            }
            */

            //Azonosíthatóság
            
            var PlaneShapes1 = new PlaneShape();
            

            //shapePlanes2.Start();
            //Console.WriteLine(shapePlanes2.a);

            //1. EL TUDJUK-E DÖNTENI, HOGY A 2 PÉLDÁNY AZONOS?
            //A két példányra mutató referecia van a két változóban.
            //A két referecia oda mutat-e, a tartalmát nem vizsgáljuk

            /*
            if (PlaneShapes1 == PlaneShapes2)
            {
                Console.WriteLine("Azonos a 2 példány!");
            }

            else
            {
                Console.WriteLine("Nem azonos a 2 példány!");
            }
            */

            //2. Állapot vizsgálata
            
            PlaneShapes1.angleNumberPublic = 3;
            PlaneShapes1.angleNumberPublic = 5;

            PlaneShapes1.Name = "SÍKIDOMOK"; //setter függvényt hívjuk meg


            //Console.WriteLine(PlaneShapes1.Name);


            // 3. viselkedés
            // A viselkedést függvényeken keresztül szabályozzuk
            // A függvény neve és paramétere jelenti a függvényt szignatúráját
            // A függvények paraméterlistája jelenti a szignatúrát

            //3.1 Függvény szignatúra
            //PlaneShapes1.Show(1,5); //CTRL + Shift + Space >>> a függvények mutatása zárójelen belül

            //3.2 Függvények paraméterátadása

            //3.2.1 Érték szerinti átadás ///////////////////////////////////
            Console.WriteLine("Érték szerinti átadás:");
            var ertek = 2;
            Console.WriteLine($"ertek: {ertek}");
            PlaneShapes1.Show(ertek);
            Console.WriteLine($"ertek: {ertek}");
            ////////////////////////////////////////////////////////////////

            Console.WriteLine();

            //3.2.2 Referencia szerinti átadás //////////////////////////////
            Console.WriteLine("Referencia szerinti átadás:");
            var refer = new RefTyp() {value = 3};
            Console.WriteLine($"ertek: {refer.value}");
            PlaneShapes1.Show(refer);
            Console.WriteLine($"ertek: {refer.value}");
            ////////////////////////////////////////////////////////////////

            Console.WriteLine();

            //3.2.3 Átadás, több módszerrel /////////////////////////////////
            Console.WriteLine("Érték + referencia szerinti átadás:");
            refer = new RefTyp() { value = 3 };
            Console.WriteLine($"ertek: {refer.value}");
            PlaneShapes1.Show(ertek, refer);
            Console.WriteLine($"ertek: {refer.value}");
            ////////////////////////////////////////////////////////////////

            Console.WriteLine();

            //3.2.4 Érték átadása referencia szerint ///////////////////////
            Console.WriteLine("Érték átadása referencia szerint:");
            var ertek2 =2;
            Console.WriteLine($"ertek2: {ertek2}");
            PlaneShapes1.Show(ref ertek2);
            Console.WriteLine($"ertek2: {ertek2}");
            ////////////////////////////////////////////////////////////////

            Console.WriteLine();


            //3.2.5 OUT int, csak kifelé ad paramétert!//////////////////////
           
            Console.WriteLine("Out int érték átadása:");
            PlaneShapes1.ShowOut(out int ertek3);
            Console.WriteLine($"out int ertek3: {ertek3}");
            /*
              int ertek3;
              PlaneShapes1.ShowOut(out ertek3);
              Régi megoldás, most már referenciaként átadható az int, mint típus!!!
            */

            ////////////////////////////////////////////////////////////////
            ///
            Console.WriteLine();

            //3.2.6 Átadás, több módszerrel /////////////////////////////////
            Console.WriteLine("Érték + referencia + érték referencia szerinti + out int érték átadása:");
            refer = new RefTyp() { value = 3 };
            ertek2 = 4;
            Console.WriteLine($"ertek: {ertek}, Referencia:{refer.value}, ertek2: {ertek2}, ertek3 (out):{ertek3}");
            PlaneShapes1.Show(ertek, refer, ref ertek,out ertek3);
            Console.WriteLine($"ertek: {ertek}, Referencia:{refer.value}, ertek2: {ertek2}, ertek3 (out):{ertek3}");
            ////////////////////////////////////////////////////////////////

            Console.WriteLine();

            var a = 10;
            var b = 2;
            var c = "dfgd";

            //Függvények paramétereinek alapértelmezett érték átadása
            PlaneShapes1.Show(a,b,c);
            PlaneShapes1.Show(width:4, name:"");


            Console.ReadLine();
      
        }
    }
}


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

            //3.2.1 Érték szerinti átadás

            var ertek = 2;
            Console.WriteLine($"ertek: {ertek}");
            PlaneShapes1.Show(ertek);
            Console.WriteLine($"ertek: {ertek}");

            //3.2.2 Paraméter szerinti átadás



            Console.ReadLine();
      


        }
    }
}


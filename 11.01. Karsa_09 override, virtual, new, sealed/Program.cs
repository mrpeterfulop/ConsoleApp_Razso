using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11._01.Karsa_09_override__virtual__new__sealed
{

     public abstract class EP
    {
        int a = 10;
        int b = 10;

        public int start() {

            return a;
        }
    }

    interface IPlane
    {
        int PlanseProgram();
    }


    public class MainClass : EP
    {

    }




    class Program //override, virtual, new, sealed
    {
        // virtual: Az ősoztályban adjuk meg anná la metódusnál, ami szintén szerepel később a származtatott osztályokban is! Ez alapján határozzuk meg, hogy melyik metódus fogja felülírni az alosztály. 

        // override: Az override szó megadásával jelezzük, hogy az ősosztályban szereplő "virtual" szóval ellátott metódust szeretnénk felülírni, az aktuális osztályban! Megadása egyben "virtual" jelzőként is szolgál, tehát ha újabb alosztályban lévő, az ősosztály nevével egyező függvényt futtatunk, már nem szükséges a virtual szót is megadni, elég az "override"!

        // /////////////////////////////////////////////////////////////////////////////////////////////

        // new virtual: override helyett haszálható

        // sealed override: Az osztály "class" meghatározása elé kerül a "sealed" jelző, illetve az osztályban szereőlő függvény is megkapja "sealead override" bővítést! Akkor használjuk, ha nem akarjuk az adott osztálynál tovább vinni a metódus felülírást.

        class Mammalias
        {
            public virtual void Feeding()
            {

                Console.WriteLine("Evés");
            }
        }

        class Dogs : Mammalias
        {
            /*public override void Feeding()
            {

                Console.WriteLine("Evés - Kutya");
            }*/
            public override void Feeding()
            {

                Console.WriteLine("Evés - Kutya");
            }

        }

        class Labrador: Dogs
        {
           /* public override void Feeding()
            {

                Console.WriteLine("Evés - Labrador");
            }*/
            public override void Feeding()
            {

                Console.WriteLine("Evés - Labrador");
            }
        }


        static void Main(string[] args)
        {

            Labrador l = new Labrador();

            l.Feeding();


            Console.ReadKey();
        }
    }
}

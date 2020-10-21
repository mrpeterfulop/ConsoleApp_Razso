using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
using System.Management.Instrumentation;
using System.Reflection;

namespace _10._20.Orai_munka
{
    public class PlaneShape
    {
        //2. Állapot vizsgálata
        //Két tulajdonság: Mező, Property.

        private int angleNumber;

        //2.1 Mező
        //Úgy viselkedik mint egy változó, mindenki által elérhető
        //Kívülről is elérhetők: írható, olvasható, használatuk nem javasolt, nem korlátozható

        public int angleNumberPublic;

        //2.2 Property (tulajdonság) alapértelemzetten mező!
        public int Csucsok { get; set; }


        //A. Azonban a fordító egy ilyen kóddá alakítja át, külön veszi az írást és az olvasást
        // backing filed: ez tartalmazza a property értékét

        private int _Csucsok;

        //B. Ez a getter függveny, ami visszaadja a backingField értékét
        public int Csucsok_GET()
        {
            return _Csucsok;
        }

        //C. Ez a setter függvény, ami arra való, hogy írjuk vele a backing field-et
        public void Csucsok_SET(int value)
        {
            _Csucsok = value;
        }

        //2.2.1. Ezekből következik: Külön tudunk csak írható, és csak olvasható probertyt létrehozni.

        //Csak olvasható Property
        public int Data1 { get;}

        //Csak írható Property, itt implementálnom kell mert csakígy férek hozzá a bejövő adatokhoz
        //A deff szerint a bejövő paraméter alapértelmezett neve "value" a típusa mindig a proterty típusa.
        private int _Data2;
        public int Data2 { set { _Data2 = value; } }

        //2.2.2 Külön tudjuk a láthatóságát is szabályozni.
        //Olvasni csak osztályon belül, írni pedig kívülről is.
        public int Data3 {private get; set; }

        //Csak oztályon belül tudom írni, olvasni bárhonnan!
        public int Data4 { get; private set; }


        //2.2.3 Saját magam implementálom

        private string _Name;
        public string Name { get { return _Name;/*tetszőleges művelet*/ } set { _Name = value; /*tetszőleges művelet*/} }


        // 3. viselkedés
        // A viselkedést függvényeken keresztül szabályozzuk
        // A függvény neve és paramétere jelenti a függvényt szignatúráját
        // A függvények paraméterlistája jelenti a szignatúrát


        //3.1 a függvény signature azonos függvénynév 
        //függvény overloading-nak hívjuk az esetet! (Túlterhelés)
        public void Show()
        { 

        }

        // Nem a név, hanem a signatura (név + paraméterek) azonosítja a függvényt
        public void Show(bool disable)
        {

        }

        public void Show(int posx, int posy) // X és Y irányú pozíció
        {

        }

        /*
        public void Show(int x, int y) // A paraméternév nem a szignatúra része
        {

        }
        */


        /*
        public int Show() //A visszatérési érték sem a szignatúra része!
        {
            return 0;
        }
        */



        //3.2.1 Érték szerinti átadás ///////////////////////////////////
        public void Show(int height)
        {
            Console.WriteLine($"Show ertek: {height}");
            height *= 2;
            Console.WriteLine($"Show ertek szorzás után: {height}");
        }

        //3.2.2 Referencia szerinti átadás //////////////////////////////
        public void Show(RefTyp refer)
        {
            Console.WriteLine($"Show refer: {refer.value}");
            refer.value *= 2;
            Console.WriteLine($"Show refer, szorzás után: {refer.value}");
        }

        //3.2.3 Érték + Referencia szerinti átadás ///////////////////////
        public void Show(int height, RefTyp refer)
        {
            Console.WriteLine($"Show ertek: {height} Show refer: {refer.value}");
            height *= 2;
            refer.value *= 2;
            Console.WriteLine($"Show ertek, szorzás után: {height} Show refer, szorzás után: {refer.value}");
        }

        //3.2.4 Referencia típusként történő érték átadás ///////////////
        public void Show(ref int height)
        {
            Console.WriteLine($"Show ertek2: {height}");
            height *= 2;
            Console.WriteLine($"Show ertek2 szorzás után: {height}");
        }


        //3.2.3 Érték + Referencia szerinti átadás ///////////////////////
        public void Show(int height, RefTyp refer, ref int ertek2, out int ertek3)
        {
            ertek3 = 10;
            Console.WriteLine($"Show ertek: {height} Show refer: {refer.value}, Show ertek2:{ertek2}, Show ertek3 (out):{ertek3}");
            height *= 2;
            refer.value *= 2;
            ertek2 *= 2;
            Console.WriteLine($"Show ertek, szorzás után: {height} Show refer, szorzás után: {refer.value}, Show ertek3 (out):{ertek3}");
        }

        
        public void ShowOut(out int ertek3)
        {
            ertek3 = 10; //Mindenképpen kell értéket adni OUT használata esetén a változónak!

        }


        //Függvények paramétereinek alapértelmezett érték átadása

        public void Show(int height = 10, int width = 7, string name = "név")
        { 
          
        }


        //3.2.2 Paraméter szerinti átadás

    }
}
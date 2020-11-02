using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Remoting.Lifetime;
using System.Text;
using System.Threading.Tasks;

namespace _11._02.Karsa_11_partialClass__Interface
{

    class MyInt
    {
        public MyInt(int value)
        {
            this.value = value;
        }
        public int value { get; private set; }
        static public MyInt operator + (MyInt lhs, MyInt rhs)
        {
            return new MyInt(lhs.value + rhs.value);
        }
    }

    class EgeszSzam
    {
        int szam;
        public int Szam
        {
            get { return szam; }
            set { szam = value; }
        }
        public EgeszSzam(int sz)
        {
            this.szam = sz;
        }

        static public EgeszSzam operator + (EgeszSzam lhs, EgeszSzam rhs)
        {
            return new EgeszSzam(lhs.szam + rhs.szam);
        }
    }


    interface IPelda1
    {
        void Pelda();
    }

    interface IPelda2
    {
        void Pelda();
    }

    class Pelda : IPelda1, IPelda2
    {
        void IPelda1.Pelda()
        {
            Console.WriteLine("Hello1!");

        }
        void IPelda2.Pelda()
        {
            Console.WriteLine("Hello2!");
        }
    }

    interface IAnimal
    {
        void Eat();
    }

    interface IExtra1
    {

        void Extra1();

    }

    interface IExtra2
    {
        void Extra2();

    }

    class Dog : IAnimal
    {

        public void Eat()
        {
            Console.WriteLine("ŐsInterfész: Kutya eszik...");

        }

        public void Extra1()
        {
            Console.WriteLine("Intefész2: Kutya eszik...");
        }

        public void Extra3()
        {
            Console.WriteLine("Intefész3: Kutya eszik...");
        }
    }


    public class OroklesTeszt
    {
       /* public OroklesTeszt()
        {
            Console.WriteLine("Konstruktor alapművelet!");
        }
       */
        public virtual void Alapmuvelet()
        {
            Console.WriteLine("Ősosztály alapművelet.");
        }



    }

    public class Alosztaly : OroklesTeszt
    {
        public  override void Alapmuvelet()
        {
            Console.WriteLine("Alosztály alapművelet.");
        }
    }


    public class KovetkezoAlosztlay : Alosztaly
    {
        public new virtual void Alapmuvelet()
        {
            Console.WriteLine("Következő alapművelet.");
        }


    }
    
    public class UtolsoAlosztlay : KovetkezoAlosztlay
    {
        public override void Alapmuvelet()
        {
            Console.WriteLine("Utolsó alapművelet.");

        }
    }
    

    public class VirtualMethods
    {
        public class Animal
        {
            public void EatAll()
            {
                Console.WriteLine("Egy állat eszik...");
            }
            public virtual void Eat()
            {
                Console.WriteLine("Egy állat eszik...");
            }
        }

        public class Dog : Animal
        {
            public string name;
            public string Name{

                get { return name; }
                set { value = name; }
            }

            public Dog(string n)
            {
                this.name = n;
            }

            public void AboutMe()
            {
                Console.WriteLine($"Az én nevem: {this.name}");
            }

            public string type = "kutya";
            public override void Eat()
            {
               Console.WriteLine($"{name} {type} csontot rág...");
            }
        }

        public class Crocodile : Animal
        {
            public string type = "korokdil";

            public string name;

            public Crocodile(string n)
            {
                this.name = n;
            }

            public override void Eat()
            {
               Console.WriteLine($"{name} {type} embert rág...");
            }
        }

    }



    public class BaseGyakorlat
    {
        public class Animals
        {
            public string Name { get; set; }

            public Animals(string name = "Álltalános nevén")
            {
                this.Name = name;
            }

            public void Eat()
            {
                Console.WriteLine($"Hamm - Hamm - szólt {Name}.");
            }
        }

        public class Dog : Animals
        {
            public Dog(string name) : base(name)
            {

            }
        }

        public class Crocodile : Animals
        {
            public Crocodile(string name) : base(name)
            {

            }
        }
    }

    abstract class Alap
    {
        public int a = 10;
        public int b = 20;
        public abstract int osztas();
        public void kiir()
        {
            Console.WriteLine(a+b);
        }

    }

    class Oszt : Alap
    {

        public override int osztas()
        {
            Console.WriteLine("Hello");
            int c = 100;
            return c + b + a;
        }
    }

    interface IQuess
    {
        void Morning();
        void Evening();
    }
    public class Early
    {
       public virtual int TestFunction()
        {
            return 10 + 1;
        }
    }

    public class Late : Early
    {
        public override int TestFunction()
        {
            return 10 + 2;
        }
    }

    class Ember
    {
        public Ember(string n, int a, int p)
        {
            Name = n;
            Age = a;
            PostalCode = p;
        }

        private string name;
        public string Name
        {

            get { return name; }
            set {

                if (value.Length == 0)
                {
                    Console.WriteLine("Hibásan megadott névérték!");
                }
                else
                {
                    name = value;
                }
            }
        }

        private int age;
        public int Age
        {
            get { return age; }
            set {
                if (value <= 0)
                {
                    Console.WriteLine("Az életkor nem lehet kisebb, mint 0!");
                }
                else
                {
                    age = value;
                }
            }
        }

        private int postalCode;
        public int PostalCode
        {
            get { return postalCode; }
            set
            {
                if (value.ToString().Length == 4) postalCode = value;
                else {
                    Console.WriteLine("Rossz irányítszám");
                }
            }
        }

        /*
        public void getData()
        {
            Console.WriteLine("Add meg a neved:");
            this.name = Console.ReadLine();

            Console.WriteLine("Add meg a korod:");
            this.age = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Add meg a címed:");
            this.postalCode = Convert.ToInt32(Console.ReadLine());
        }
        */
        public void Write()
        {
            Console.WriteLine($"Név: {Name}");
            Console.WriteLine($"Életkor: {Age}");
            Console.WriteLine($"Irányítószám: {PostalCode}");
        }

    }

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

    class Program
    {
        static void Main(string[] args)
        {
            
            PartialClass pc = new PartialClass();
            pc.Kiir();
            pc.Kiir2();
            

            var customer3 = new Customer(8, "Sanyi");


            var order = new Order();

            Console.WriteLine(customer3.Id);
            Console.WriteLine(customer3.Name);

            Console.WriteLine("\n////////////////////////////////////////\n");

            /*
            Console.WriteLine("Add meg a neved:");
            var getName = Console.ReadLine();

            Console.WriteLine("Add meg a korod:");
            var getAge = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Add meg a címed:");
            var getPostalCode = Convert.ToInt32(Console.ReadLine());
            

            Ember e = new Ember(getName, getAge, getPostalCode);

            e.Write();
            */

            Early e = new Early();
            Late l = new Late();


            Read(e);
            Read(l);


            var abs = new Oszt();

            abs.osztas();


            var bgy = new BaseGyakorlat.Animals();
            var bgya = new BaseGyakorlat.Dog("");
            var bgyb = new BaseGyakorlat.Crocodile("");

            bgya.Name = "A kutyám";
            bgyb.Name = "A krokodilom";

            string[] Names = new string[] { "Zoli", "Feri", "Kata", "János", "Tibor", "Zsolti", "Lala", "Gabi" };

            for (int i = 0; i < Names.Length; i++)
            {
                bgy.Name = Names[i];
                bgy.Eat();
            }


            var an = new VirtualMethods.Animal();
            var dog = new VirtualMethods.Dog("Zoli");
            var cro = new VirtualMethods.Crocodile("Rokko");

            //an.Eat();
            dog.Eat();
            cro.Eat();
            Console.WriteLine();
            var asd = new Alosztaly(); // A példányosítást követően a konstruktorban lévő események lefutnak!

            var sdf = new KovetkezoAlosztlay();
            var dfg = new UtolsoAlosztlay();


            asd.Alapmuvelet();
            sdf.Alapmuvelet();
            dfg.Alapmuvelet();



            Console.WriteLine("\n////////////////////////////////////////\n");

            /*
            VirtualMethods.Animal d = new VirtualMethods.Dog("Zoli-kutya");
            dog.Eat();
            */

            Dog d = new Dog();
            d.Eat();

            var Iface = new Pelda();



            EgeszSzam esz1 = new EgeszSzam(20);
            EgeszSzam esz2 = new EgeszSzam(13);
            EgeszSzam ossz = esz1 + esz2;
            Console.WriteLine(ossz.Szam);


            MyInt x = new MyInt(10);
            MyInt y = new MyInt(20);
            MyInt result = x + y;
            Console.WriteLine(result.value); // 30


            Console.ReadKey();
        }


        static void Read(Early e)
        {
            Console.WriteLine("Kapott érték: " + e.TestFunction());
        }
        static void Read(Late l)
        {
            Console.WriteLine("Kapott érték: " + l.TestFunction());
        }

    }
}

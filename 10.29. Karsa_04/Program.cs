using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10._29.Karsa_04
{
    class Program
    {

        enum Animals
        {
            Dog,
            Cat,
            Elephant,
            Leon,
            Crocodile,
        }

        enum abc
        {
            A,B,C,D,E,F,G,H
        }

        enum linux { 
            Ubuntu,Mint,Debian,Lubuntu,Xubuntu,openSuse
        }


        enum myMenu
        {
            Belépés,
            Különböző_feladatatok,
            Extra,
            Kilépés
        };
        static void Main(string[] args)
        {






            Console.WriteLine("Adj meg egy számot:");
            int index = int.Parse(Console.ReadLine());

            Animals a = Animals.Elephant;

            Console.WriteLine((ConsoleColor)5);

            Console.WriteLine();

            Console.WriteLine((abc)index);
            Console.WriteLine((int)a);
            Console.WriteLine(a);

            linux[] l = (linux[])Enum.GetValues(typeof(linux));

            foreach (var item in l)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();

            string[] linuxStrT = Enum.GetNames(typeof(linux));

            foreach (var item in linuxStrT)
            {
                Console.WriteLine(item);
            }


            Console.WriteLine();
            string linStr = Enum.GetName(typeof(linux), 2);
            Console.WriteLine(linStr);

            /*

            linux l1;
            if (Enum.TryParse(Console.ReadLine(), out l1)) 
            {
                Console.WriteLine("Sikerült! " + l1);
            }
            else
            {
                Console.WriteLine("Nincs ilyen elem!");

            }

            */

            /*
            var t = 0;


            try
            {
                t = int.Parse(Console.ReadLine());
            }
            catch (Exception e)
            {


                Console.WriteLine(e);

            }

            finally {
                Console.WriteLine( "Ez a programrész mindenképpen lefut, hibától függetlenül");
            }
            */
            /*
            bool fail = true;
            do
            {
                try
                {
                    Console.WriteLine("Add meg a neved:");
                    string name = Console.ReadLine();
                    if (name.Length == 0)
                    {
                        throw new ApplicationException("Nem adtál meg nevet!");
                    }
                    fail = false;
                    Console.WriteLine($"Üdv {name}!");
                }
                catch (ApplicationException e)
                {
                    Console.WriteLine(e + e.Message);
                }

            } while (fail);

            */

            Random rnd = new Random();

            List<int> myList = new List<int>();

            List<List<int>> matrixList = new List<List<int>>()
            {

            };

            
            for (int i = 0; i < 10; i++)
            {
                matrixList.Add(new List<int>());
                matrixList[i].Add(rnd.Next(10000, 200000));
                Console.WriteLine(matrixList[i][0]);
            }


            Console.WriteLine(matrixList.Count());

            for (int i = 0; i < 20; i++)
            {
                myList.Add(rnd.Next(1, 100));
            }

            Console.WriteLine(string.Join(",", myList));

            myList.Sort();
            Console.WriteLine(string.Join(",", myList));

            myList.Reverse();
            Console.WriteLine(string.Join(",", myList));

            Console.WriteLine();


            /*
            string[] menu = Enum.GetNames(typeof(myMenu));

            var a = menu.Max().Length + 5;

            Console.WriteLine(a);

            foreach (var item in menu)
            {
                Console.BackgroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine(item.PadRight(a, ' '));
                Console.WriteLine();
            }

            Console.ResetColor();
            */


            //LÁNCOLT LISTÁK
            Console.WriteLine("Láncolt lista típus:\n");

            LinkedList<string> chainList = new LinkedList<string>();

            chainList.AddLast("utolsó előtti elem");
            chainList.AddLast("utolsó elem");
            chainList.AddFirst("első elem");

            foreach (var item in chainList)
            {
                Console.WriteLine(item + ", ");
            }


            LinkedListNode<string> chainListNode = chainList.First;

            Console.WriteLine(chainListNode.Value);

            chainListNode = chainListNode.Next;

            Console.WriteLine("\n");

            Console.WriteLine("Szótár típus:\n");


            // SZÓTÁRAK
            Dictionary<string, string> dict = new Dictionary<string, string>()
            {
                { "ablak","Fenster"}, { "váza","Vase"}, { "alma","Appfel"}

            };

            dict.Add("asztal", "Tisch");

            foreach (var item in dict)
            {
                Console.WriteLine(item);
            }

            foreach (KeyValuePair<string, string> item in dict)
            {
                Console.WriteLine(item.Key +" - "+ item.Value);
            }

            Console.WriteLine();

            Dictionary<int, string> dictInt = new Dictionary<int, string>();

            dictInt.Add(1, "alma");
            dictInt.Add(2, "kettő");
            dictInt.Add(3, "körte");
            dictInt.Add(4, "négy");

            dictInt.ContainsValue("alma");
            dictInt.ContainsKey(1);


            foreach (KeyValuePair<int, string> item in dictInt)
            {
                Console.WriteLine(item.Key + " - " + item.Value);
            }


            var searchValue = "alma";
            var searchKey = 25;

            Console.WriteLine($"\nA keresett érték:{searchValue} státusza:{dictInt.ContainsValue(searchValue)}");
            Console.WriteLine($"A keresett kulcs:{searchKey} státusza:{dictInt.ContainsKey(searchKey)}");

            


            // VEREM, Stack
            // Last IN, first OUT LIFO
            Console.WriteLine("\nVerem, Stack típus:\n");
            Stack<string> stack = new Stack<string>();

            stack.Push("first");
            stack.Push("second");
            stack.Push("third");
            stack.Push("fourth");
            stack.Push("fifth");
            stack.Push("sixth");
            stack.Push("seventh");
            stack.Push("eighth");
            stack.Push("ninth");
            stack.Push("tenth");
            stack.Pop(); // Kiveszek egy tételt, a végéről fog törölni.

            foreach (var item in stack)
            {
                Console.WriteLine(item);
            }

            // SOR, Queue
            // First IN, first OUT FIFO

            Console.WriteLine("\nSOR, Queue típus:\n");
            Queue<int> queue = new Queue<int>();

            queue.Enqueue(17);
            queue.Enqueue(18);
            queue.Enqueue(19);
            queue.Enqueue(20);
            queue.Enqueue(21);
            queue.Enqueue(22);
            queue.Dequeue();  // Kiveszek egy tételt, az elejéről fog törölni.

            foreach (var item in queue)
            {
                Console.WriteLine(item);
            }


            // Halmazok, Queue - CSAK és kizárólag 1x szerepelhet egy érték! 

            Console.WriteLine("\nHalmazok, Queue - CSAK és kizárólag 1x szerepelhet egy érték! :\n");
            HashSet<int> halmaz = new HashSet<int>()
            { 
             10,18,20,22,84            
            };



            halmaz.Add(34);
            halmaz.Add(18); //Szereplő elemet már NEM ad hozzá!

            foreach (var item in halmaz)
            {
                Console.WriteLine(item+", ");
            }
            Console.WriteLine();


            Console.WriteLine("Lottó számok generálása:\n");
            HashSet<int> lotto = new HashSet<int>();


            while (lotto.Count < 20)
            {
                lotto.Add(rnd.Next(91));
            }

            Console.WriteLine(string.Join(", ", lotto));


            Console.WriteLine("\n\nHalmazműveletek (UNIO, KIVONÁS, METSZET)\n");
            HashSet<int> baseSet = new HashSet<int>(){ 10,23,43,76, 28};
            Console.WriteLine("\nAlaphalmaz elemei:");
            Console.WriteLine(string.Join(", ", baseSet));

            HashSet<int> secSet = new HashSet<int>(){ 10,2,3,76};
            Console.WriteLine("\nMásodhalmaz elemei:");
            Console.WriteLine(string.Join(", ", secSet));

            Console.WriteLine("\nUNIO KÉPZÉSE: 'UnionWith' kifejezés /////////////////////////////");

            baseSet.UnionWith(secSet); // Unio, Összes elem visszaadása, ismétlődés nélkül!
            Console.WriteLine($"\nUnio elemei, az alaphalmazba képezve:");
            Console.WriteLine(string.Join(", ", baseSet));


            /*
            secSet.UnionWith(baseSet); // Unio, Összes elem visszaadása, ismétlődés nélkül!
            Console.WriteLine($"\nUnio elemei, a másodhalmazba képezve:");
            Console.WriteLine(string.Join(", ", secSet));
            */

            Console.WriteLine("\n///////////////////////////////////////////////////////////////");

            Console.WriteLine("\nMETSZET KÉPZÉSE: 'Intersect' kifejezés ////////////////////////");

            baseSet = new HashSet<int>() { 10, 23, 43, 76, 28 };
            Console.WriteLine("\nAlaphalmaz elemei:");
            Console.WriteLine(string.Join(", ", baseSet));

            secSet = new HashSet<int>() { 10, 2, 3, 76 };
            Console.WriteLine("\nMásodhalmaz elemei:");
            Console.WriteLine(string.Join(", ", secSet));


            Console.WriteLine("\nAlaphalmaz-másodhalmaz metszete, alaphalmazba képezve:");
            baseSet.Intersect(secSet); // Metszet képzés, szintén felülírással jön létre.
            Console.WriteLine(string.Join(", ", baseSet));
            Console.WriteLine("\n///////////////////////////////////////////////////////////////");

            /*
            Console.WriteLine("\nMásodhalmaz-alaphalmaz metszete, másodhalmazba képezve:");
            secSet.Intersect(baseSet); // Metszet képzés, szintén felülírással jön létre.
            Console.WriteLine(string.Join(", ", secSet));
            */

            Console.WriteLine("\nKIVONÁS KÉPZÉSE: 'Intersect' kifejezés ////////////////////////");

            baseSet = new HashSet<int>() { 10, 23, 43, 76, 28 };
            Console.WriteLine("\nAlaphalmaz elemei:");
            Console.WriteLine(string.Join(", ", baseSet));

            secSet = new HashSet<int>() { 10, 2, 3, 76 };
            Console.WriteLine("\nMásodhalmaz elemei:");
            Console.WriteLine(string.Join(", ", secSet));


            Console.WriteLine("\nAlaphalmaz-másodhalmaz kivonása, alaphalmazba képezve:");
            baseSet.ExceptWith(secSet); // Kivonás képzés, szintén felülírással jön létre.
            Console.WriteLine(string.Join(", ", baseSet));

            /*
            Console.WriteLine("\nMásodhalmaz-alaphalmaz kivonása, másodhalmazba képezve:");
            secSet.ExceptWith(baseSet); // Kivonás képzés, szintén felülírással jön létre.
            Console.WriteLine(string.Join(", ", secSet));
            */

            Console.WriteLine("\n///////////////////////////////////////////////////////////////");



            Console.ReadKey();

        }
        

        

    }
}

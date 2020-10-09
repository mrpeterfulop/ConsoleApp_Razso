using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _10._09.String_methods
{
    class Program
    {
        static void Main(string[] args)
        {



            //1. Substring metódus

            //Substrin metódus: A zárójelben megadott értéktől kezdi a tömb elemeinek felsorolását. Jelen esetben a string, szöveg tartalmának megjeleíntése az 5. karaktertől kezdődik! Számolás a tömbök logikája alapján, 0-tól! 

            //Kiegészíthető egy második paraméterrel is (5,3) ami alapján az első paraméterrel meghatározott tartalomkezdés a második paraméterben meghatározott paraméterig tart! Jelen esetben 3 karaktert számol még az 5. elemtől!

            /* string str = "Géza kék az ég!";
             string subStr = str.Substring(6);
             Console.WriteLine($"Substring={subStr}");*/

            // string word = "alma";
            // string text = "Ebben a szövegben valahol az alma szó szerepel, alma módra!!";



            /*
            Console.WriteLine($"A szöveg a következő:\n{text}\nA keresett szó:\n{word}");

            Console.WriteLine($"A szövegben a(z) {word} szó első előfordulási helye a(z) {text.IndexOf(word)}. indexű elemnél kezdődik!");

            Console.WriteLine($"A szövegben a(z) {word} szó utolsó előfordulási helye a(z) {text.LastIndexOf(word)}. indexű elemnél kezdődik!");

            */
            /*
            Console.WriteLine($"A korábbi kifejezés: {word}");
            
            Console.WriteLine($"Kérlek add meg az új kifejezést:");

            string newInput = Console.ReadLine();

            word = newInput;

            //string replace = word.Replace(text, newInput);



            Console.WriteLine($"A megadott kifejezés: {newInput}");

            Console.WriteLine($"A szöveg a következő:\n{text}\nA keresett szó:\n{word}");

            Console.WriteLine($"A szövegben a(z) {word} szó első előfordulási helye a(z) {text.IndexOf(word)}. indexű elemnél kezdődik!");

            Console.WriteLine($"A szövegben a(z) {word} szó utolsó előfordulási helye a(z) {text.LastIndexOf(word)}. indexű elemnél kezdődik!");
              */




            



            /*
            foreach (var item in extensionFile)
            {
                Console.Write($"{item},");
            }
            */


            var inputPatch = new InputPatch();

            inputPatch.loopPatch();

            
            //Console.WriteLine($"A tömb elemeinek száma:{ extensionFile.Length}");
            //Console.WriteLine($"A tömb elemei:");










            Console.ReadKey();


        }
    }
}

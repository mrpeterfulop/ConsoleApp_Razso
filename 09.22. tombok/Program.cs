using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace _09._22.tombok
{
    class Program
    {
        static void Main(string[] args)
        {

            /*
            string[] myFruits = { "alma", "körte" };
            var array3 = new int[] { 16, 2, 82, 5, 95 };
            int[] myArray = { 16, 2, 82, 5, 95 };
            */

            /* Console.WriteLine("A tömb elemeinek száma: " + myArray.Length);
             Console.WriteLine("Az utolsó elem száma: " + myArray[myArray.Length-1]);
             Console.WriteLine("A tömb 3. eleme: " + myArray[2]);*/


            /*
            foreach (var i in myArray)
            {
                Console.WriteLine(i);
            }
            

            for (int i = 0; i < myArray.Length; i++)
            {
                Console.WriteLine($"A tomb {i+1}. eleme:{myArray[i]}");
            }*/


            /*
            Random rnd = new Random();
            var numbers = new int[100];
                       
            
            for (int i = 0; i < 50; i++)
            {
                var getRandom = rnd.Next(1, 1000);
                numbers[i] = getRandom;
                Console.WriteLine($"A tömb {i+1}. eleme: { numbers[i]}");

            }*/


            //val typ

            var value1 = 10;
            var value2 = value1;

            Console.WriteLine($"Az első érték:{value1}, a második érték:{value2}");
            value1 = 20;
            Console.WriteLine($"Az első érték:{value1}, a második érték:{value2}\n");


            //ref typ

            var ref1 = new MyReference1();

            ref1.value = 10;
            var ref2 = ref1;

            Console.WriteLine($"Referenia 1: {ref1.value}, Referencia 2: {ref2.value}");
            ref1.value = 20;
            Console.WriteLine($"Referenia 1: {ref1.value}, Referencia 2: {ref2.value}\n");
                                   

            //Összetett beépített adattípusok

            var array1 = new int[] { 10 };
            var array2 = array1;

            Console.WriteLine($"Tömb 1: {array1[0]} tömb 2: {array2[0]}");

            array1[0] = 20;

            Console.WriteLine($"Tömb 1: {array1[0]} tömb 2: {array2[0]}");


            //Karakterekből álló tömb

            var text1 = new string( new char[] { 'a', 'b' }); //A karakterekből álló tömböt becsomagoljuk egy stringbe

            var text2 = text1;

            Console.WriteLine("\n" + $"Szöveg 1: {text1} Szöveg 2: {text2}");

            text1 = "c";

            Console.WriteLine("\n" + $"Szöveg 1: {text1} Szöveg 2: {text2}");
            
            
            Console.ReadLine();

        }
    }
}

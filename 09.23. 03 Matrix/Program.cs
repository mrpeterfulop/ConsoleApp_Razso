using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09._23._03_Matrix
{
    class Program
    {
        static void Main(string[] args)
        {



            int[,] myMatrix = new int [6,7];
            string[] myMatrixHeader = { "Hétfő", "Kedd", "Szerda", "Csütörtök", "Péntek", "Szombat", "Vasárnap" };

            Random rnd = new Random();

            string[] puffer = new string[7];
            string[] characters = new string[10];
            int[] charNumbers = new int[7];


            for (int i = 0; i < myMatrixHeader.Length; i++) //A fejléc tömb elemeinek hosszát egy új tömbbe mentem, számként!
            {
                              
                var textLength = myMatrixHeader[i].Length;
                var pointNumbers = textLength - 2;
                charNumbers[i] = pointNumbers;

            }


            for (int i = 0; i < charNumbers.Length; i++) //charNumbers.Length;

            {
                Array.Clear(puffer, 0, puffer.Length); //A puffer tömb ürítése új kör előtt!
                for (int j = 0; j < charNumbers[i]; j++)
                {
                    puffer[j] = " ";
                    //Console.Write(puffer[j]);

                }

                string text = string.Concat(puffer);
                characters[i] = text;
                
               // Console.WriteLine(characters[i]);
               //Console.WriteLine();
                

            }




            /*
            var text = string.Concat(puffer);

            Console.WriteLine(text);*/


            /*
            for (int i = 0; i < charNumbers.Length; i++)
            {
                Console.WriteLine(charNumbers[i]);
            }*/



            for (int k = 0; k < myMatrixHeader.Length; k++)
                    {
                        Console.Write("| " + myMatrixHeader[k] + " ");
                    }
            Console.WriteLine();
            Console.WriteLine("/////////////////////////////////////////////////////////////////");


            for (int i = 0; i < myMatrix.GetLength(0)-1; i++)
            {
                for (int j = 0; j < myMatrix.GetLength(1); j++)
                {

                    myMatrix[i,j] = rnd.Next(10, 99);
                    Console.Write("| " + characters[j] + myMatrix[i, j] + " ");
                }
                    Console.WriteLine();
            }

            Console.WriteLine("-----------------------------------------------------------------");





            Console.ReadLine();

        }
    }
}

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


            /*
                int[,] myMatrix = new int[6, 7];
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

            /*

            for (int k = 0; k < myMatrixHeader.Length; k++)
            {
                Console.Write("| " + myMatrixHeader[k] + " ");
            }
            Console.WriteLine();
            Console.WriteLine("/////////////////////////////////////////////////////////////////");


            for (int i = 0; i < myMatrix.GetLength(0) - 1; i++)
            {
                for (int j = 0; j < myMatrix.GetLength(1); j++)
                {

                    myMatrix[i, j] = rnd.Next(10, 99);
                    Console.Write("| " + characters[j] + myMatrix[i, j] + " ");
                }
                Console.WriteLine();
            }

            Console.WriteLine("-----------------------------------------------------------------");
            
    */


            /*
            int[,] matrix = new int[3, 3];

            Random rnd = new Random();

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = rnd.Next(0, 99);
                    Console.Write($"{matrix[i,j]}, ");
                }
                Console.WriteLine();
            }*/




            // Többdimenziós tömb feltöltése random 

            /* int[][] matrix = new int[2][];

             Random rnd = new Random();

             for (int i = 0; i < 2; i++)
             {
                 matrix[i] = new int[rnd.Next(1, 5)];

                 for (int j = 0; j < matrix[i].Length; j++)
                 {
                     matrix[i][j] = i + j;
                     Console.WriteLine($"Helloszia: {matrix[i][j]},");
                 }

                 Console.WriteLine();
             }*/

            //10.06. Operátorok
            /*
            int a = 15;
            int b = 16;

            bool bo1 = a == b;
            bool bo2 = a != b;
            bool bo3 = a < b;
            bool bo4 = a > b;
            bool bo5 = a >= b;
            bool bo6 = a <= b;
            */

            //10.06. Ciklusok
            /*
            var a = 5;
            var i = 0;

            // Elől tesztelő ciklus
            while (a < 10)
            {
                i++;
                Console.WriteLine($"Lefutás száma:{i}. Érték: {a}");
                ++a;
            }
            */
            /*
            //Hátul tesztelő ciklus
            var a = 5;
            var i = 0;
            do
            {
                Console.WriteLine(a);
                a++;
            } while (a < 10);
            */

            //10.06. Elágazások

            // If, else


        }
    }
}

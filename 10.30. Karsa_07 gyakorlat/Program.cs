using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10._30.Karsa_07_gyakorlat
{
    class Program
    {
        struct Product
        {

            public string name;
            public int quantity;
            public int price;
            public int warranty;

            public Product(string name, int quantity, int price, int warranty) {

                this.name = name;
                this.quantity = quantity;
                this.price = price;
                this.warranty = warranty;

            }

            public void printList()
            {
                Console.WriteLine("--------------------------------------------------------");
                Console.WriteLine($"Név: {name}");
                Console.WriteLine($"Mennyiség: {quantity} db");
                Console.WriteLine($"Ár: {price} Ft");
                Console.WriteLine($"Garancia: {warranty} év");
                Console.WriteLine($"Bevétel összesen: {sumPrice()} Ft");
            }

            public int sumPrice()
            {
                return price * quantity;
            }

        }

        static List<Product> readFile(string filename)
        {
            List <Product> puffer = new List<Product>();
            try
            {
                StreamReader sr = new StreamReader(filename);
                while (!sr.EndOfStream)
                {
                    try
                    {
                        string[] line = sr.ReadLine().Split('-');
                        Product temp = new Product(line[0], int.Parse(line[1]), int.Parse(line[2]), int.Parse(line[3]));
                        puffer.Add(temp);
                    }
                    catch (Exception)
                    {
                        Product temp = new Product("Hiba történt az adatok beolvasása közben",0,0,0);
                        puffer.Add(temp);
                    }
                   
                }
                 sr.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e+ "Hiba az útvonalban!");
            }

            return puffer;
        }


        static void writeToFile(string fileName, string text) {


            try
            {
                StreamWriter sw = new StreamWriter(fileName);
                sw.WriteLine(text);
                sw.Flush();
                sw.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Adja meg a file elérési útvonalát");
            var fileLoc = Console.ReadLine();
            Console.WriteLine("A beolvasás folyamatban van...");

            List <Product> lager = readFile(fileLoc);
            ulong sum = 0;
            foreach (Product item in lager)
            {
                item.printList();
                sum += (ulong)item.sumPrice();
            }

            writeToFile("sum.txt", sum.ToString());

            Console.ReadKey();


        }

    }
}

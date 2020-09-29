using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09._23._02_sikidomok
{
    class Program
    { //Program, mely segítségével ki tudjuk számítani a különböző síkidomok területét.
        static void Main(string[] args)
        {

            var square = new Square(sideLength: 4);
            Console.WriteLine($"A négyzet területe: {square.Area()}");


            var circle = new Circle(Radius: 5);
            Console.WriteLine($"A kör területe: {circle.Area()}");


            var triangle = new Triangle(height: 5, sideLength:6);
            Console.WriteLine($"A háromszög területe: {triangle.Area()}");



            Console.ReadLine();

        }
    }
}

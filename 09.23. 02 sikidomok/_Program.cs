using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09._23._02_sikidomok
{
    class _Program
    { //Program, mely segítségével ki tudjuk számítani a különböző síkidomok területét.
        static void Main(string[] args)
        {

            // square
            var square = new Square(sideLength: 4);
            Console.WriteLine($"A négyzet területe: {square.Area()}");

            // circle
            var circle = new Circle(Radius: 5);
            Console.WriteLine($"A kör területe: {circle.Area()}");

            // triangle
            var triangle = new Triangle(height: 5, sideLength:6);
            Console.WriteLine($"A háromszög területe: {triangle.Area()}");


            var sumArea = square.Area() + circle.Area() + triangle.Area();
            Console.WriteLine($"Területösszeg: {sumArea} m2");
            //Console.WriteLine("Terület összeg:{0}", sumArea);




            //var sum = 0;

            var planeShapes = new List<IPlaneshapes>();

            planeShapes.Add(square);
            planeShapes.Add(circle);
            planeShapes.Add(triangle);


            /*
            foreach (var item in planeShapes)
            {
                sum += item.Area();
            }
            */
            /*
            foreach (var item in planeShapes)
            {
                Console.WriteLine(item);
            }
            */

            // Terület meghatározás LINQ
            var sum = planeShapes.Sum(x=>x.Area());
            

            Console.WriteLine($"Az összes terület: {sum} m2");



            Console.ReadLine();

        }
    }
}

using System;

namespace _09._23._02_sikidomok
{
    public class Circle : IPlaneshapes
    {
        private int Radius;

        public Circle(int Radius)
        {
            this.Radius = Radius;
        }



        /*public int Area()
        {
        return (int)(Radius * Radius * Math.PI);
        }*/

        public double Area()
        {

            return Radius * Radius * Math.PI;


        }
    }
}
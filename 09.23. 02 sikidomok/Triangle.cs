using System;

namespace _09._23._02_sikidomok
{
    public class Triangle : IPlaneshapes
    {
        private int height;
        private int sideLength;

        public Triangle(int height, int sideLength)
        {
            this.height = height;
            this.sideLength = sideLength;
        }

        public double Area()
        {
            return (height * sideLength) / 2;
        }
    }
}
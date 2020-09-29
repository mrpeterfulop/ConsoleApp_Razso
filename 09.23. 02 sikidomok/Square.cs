using System;

namespace _09._23._02_sikidomok
{//
    public class Square : IPlaneshapes
    {
        private int sideLength;

        public Square(int sideLength) //Konstruktor függvény
        {
            this.sideLength = sideLength;
        }


        public int Area()

        {

            return sideLength * sideLength;


        }
    }
}
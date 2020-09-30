using System;

namespace _09._30._01_coin_counterfeiting
{

    public class Coin
    {

        public Coin()
        {
            //Console.Write("Run constructor function in Coin class...");
        }


        Random rnd = new Random();

        public virtual int getCoin() //virtual kulcsszó használatával elérhetővé tesszük a függvényt az ősosztályon(Coin) keresztül! 
        {
           // Console.Write("Run getCoin class in Coin class...");
            return rnd.Next(0, 2);
        }

    }
}
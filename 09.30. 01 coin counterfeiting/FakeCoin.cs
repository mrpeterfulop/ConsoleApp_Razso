using System;

namespace _09._30._01_coin_counterfeiting
{
    internal class FakeCoin : Coin
    {

        public FakeCoin()
        {
            //Console.Write("Run constructor function in FakeCoin class...");
        }


        public  int getCoin() //override kulcsszó használatával visszatér a függvény, és az alosztály(FakeCoin) függvényét futtatja le. Ha elhagyjuk, az ősosztály (Coin) függvénye fut le! 
        {
            //Console.Write("Run getCoin class in FakeCoin class...");

            return 0;
        }
                    
        
    }
}
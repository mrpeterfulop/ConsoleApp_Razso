using System;

namespace _10._07.Random_Array_with_Input
{
    public class GetUserData
    {

        string input;
        bool validation;
        int myValue;

        public int getData() {
            
            var alert = new ColorAlerts();
            

            do
            {
                alert.colorWhite();
                
                Console.WriteLine("Adj meg egy pozitív egész számot:");
                input = Console.ReadLine();
                validation = int.TryParse(input, out myValue);

                if (myValue <= 0 && validation == true)
                {
                    alert.colorRed();
                    Console.WriteLine($"Hiba! A megadott értéknek nagyobbnak kell lennie, mint 0!"); 
                }

                else if (validation == false)
                {
                    alert.colorRed();
                    Console.WriteLine($"Hiba! A megadott érték csak szám lehet!");
                }


            } while (myValue <= 0 || validation == false);

            alert.colorGreen();
            Console.WriteLine($"\nA tömböd elemeinek száma: {myValue}\n");
            alert.colorWhite();

            return myValue;


        }


    }
}
 
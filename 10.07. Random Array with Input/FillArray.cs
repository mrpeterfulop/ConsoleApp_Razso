using System;

namespace _10._07.Random_Array_with_Input
{
    public class FillArray
    {

        public int[] myArray = new int[] { };

        public void fillData()
        {
            var getUserData = new GetUserData();
            int value = getUserData.getData();

            var printData = new PrintData();

            Random rnd = new Random();

            myArray = new int[value];

            for (int i = 0; i < myArray.Length; i++)
            {
                myArray[i] = rnd.Next(0, 1001);
            }
        }
    }
}
 
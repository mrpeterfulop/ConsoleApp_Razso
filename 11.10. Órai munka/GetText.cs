using System;

namespace _11._10.Órai_munka
{
    public class GetText
    {
        public static string GetTextOnly()
        {
            string consoleMessage = "Adj meg valami szöveget:";


            Console.WriteLine(consoleMessage);
            string inputText = Console.ReadLine();
            //inputText = ReplaceDots(inputText);


            while (int.TryParse(inputText, out int num) || float.TryParse(inputText, out float flo) || char.TryParse(inputText, out char character) || inputText == "")
            {
                Console.WriteLine(consoleMessage);
                inputText = Console.ReadLine();
                //inputText = ReplaceDots(inputText);

            }

            Console.WriteLine("Helyes adat, köszönöm!");
            //ReplaceComas(inputText);
            return inputText;

        }


        public static string ReplaceDots(string inputText)
        {

            for (int i = 0; i < inputText.Length; i++)
            {
                if (Char.IsNumber(inputText[i]) && Char.IsNumber(",",inputText[i]))
                {

                }
            }


            if (inputText.Contains("."))
            {
                inputText = inputText.Replace(".", ",");
            }
            return inputText;
        }
        public static string ReplaceComas(string inputText)
        {
            if (inputText.Contains(","))
            {
                inputText = inputText.Replace(",", ".");
            }
            return inputText;
        }

    }
}

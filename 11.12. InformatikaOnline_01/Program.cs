using System;
using System.Collections.Generic;
using System.Linq;
using System.Speech.Synthesis;
using System.Text;
using System.Threading.Tasks;

namespace _11._12.InformatikaOnline_01
{
    //FELADAT
    //Szeretnénk használatba venni egy "jegyzetfüzetet".
    //Három lapból áll a jegyzetfüzet.
    //Minden napra legfeljebb 250 karakter hosszú szöveget írhatunk.
    //Minden lapnak 3 féle színe lehet: sárga(s), kék(k), zöld(z).
    //Amikor használatba vesszük a lapot, ellenőrizzük a megadott szín helyességét!
    //A lap színét, csak az objektum létrehozásakor lehessen megadni, utána már csak lekérdezni lehessen.
    //Minden lap esetén legyen egy kiírató metódus, amely kiírja a lap színét, és a "rajta" tárolt szöveget.
    //Sokszor lesz szükség arra, hogy mennyi szóból áll a lapra írt szöveg!
    //Néha arra is szükség lesz, hogy mennyi betűből áll a szöveg!
    //Néha a szöveget egy másik színű lapon szeretnénk látni.
    //Szeretnénk egy olyan metódust, amely 2 jegyzetlapot kapva a rövidebb szöveget és a papírlap színét adja vissza eredményül!


    // Újraformázás: CTRL + K + D
    // Összes előfordulás kijelölése: CTRL + R + R

    class NotePage
    {

        private byte id = 0;
        private string text;
        private char pageColor;
        private int numberOfWords;
        private List<char> colorCodes = new List<char> { 's', 'k', 'z' };

        public NotePage(byte ctorID, string ctorText, char ctorPageColor)
        {
            this.Text = ctorText;
            this.PageColor = ctorPageColor;
            this.Id = ctorID;
        }

        public byte Add_ID()
        {
            id += 1;
            return id;
        }

        public byte Id
        {
            get
            { return id; }

            set
            {
             id = value; }

        }

        public string Text
        {
            get
            { return text; }

            set
            {
                if (value.Length <= 250)
                {
                    text = value;
                    NumberOfWords = Get_Number_Of_Words(Text);

                }
                else
                {
                    throw new FormatException("Túl hosszú a megadott szöveg!");
                }
            }
        }

        private char PageColor
        {
            get
            { return pageColor; }

            set
            {
                if (colorCodes.Contains(value))
                {
                    pageColor = value;
                }
                else
                {
                    throw new Exception("Nem létező szín!");
                }
            }
        }

        private int NumberOfWords
        {
            set { numberOfWords = value; }
        }

        /*
        public byte Set_ID()
        {
            var pr = new Program();
            pr.
            var listCount = Program.np.Count();
            byte setID = 0;

            if (listCount == 0)
            {
                setID = 0;
            }
            else
            {
                setID = Convert.ToByte(listCount + 1);
            }

            return setID;
        }
        */

        public string Get_Page_Color()
        {
            string color = "";

            switch (PageColor)
            {
                case 's':
                    color = "sárga";
                    break;
                case 'k':
                    color = "kék";
                    break;
                case 'z':
                    color = "zöld";
                    break;

                default:
                    break;
            }

            return color;
        }

        public void Get_Page_Info(byte index)
        {
            Console.WriteLine($"{Id}.lap tartalma:\n{Text}");
            Console.WriteLine($"A lap színe: {Get_Page_Color()}");
            Console.WriteLine($"Szavak száma: {Get_Number_Of_Words(Text)}");
            Console.WriteLine($"Karakterek száma: {Get_Number_Of_Characters(Text)}\n");
        } // Void típussal, kiíratással együtt!

        public void Get_Page_Info(NotePage text)
        {
            Console.WriteLine($"A lap tartalma:\n{text.Text}\nA lap színe: {Get_Page_Color()}\n");
        } // string visszatérő típussal, kiíratás a főprogramban!

        public int Get_Number_Of_Words(string Text)
        {
            int count = 0;

            for (int i = 0; i < Text.Length; i++)
            {
                if (Text[i] == ' ')
                {
                    count++;
                }
            }

            return count+1;

        }

        public int Get_Number_Of_Characters(string Text)
        {
            return Text.Length;
        }

        public void Change_Page_Color()
        {
            Random rnd = new Random();
            int cc = rnd.Next(colorCodes.Count);

            while (colorCodes[cc] == PageColor)
            {
                cc = rnd.Next(colorCodes.Count);
            }

            PageColor = colorCodes[cc];

        }

        public static void Return_Sorter_Text_With_Info(NotePage Text1, NotePage Text2)
        {
            if (Text1.Text.Length < Text2.Text.Length)
            {
                Text1.Get_Page_Info(Text1.Id);
            }
            else
            {
                Text2.Get_Page_Info(Text1.Id);
            }

        }
    }



    class Program
    {
        //public static List<NotePage> np = new List<NotePage>();

        public static byte myID = 0;
        public static byte GET_ID()
        {
           return myID += 1;

        }

        static void Main(string[] args)
        {

            var addText1 = "Konstruktor létrehozása, paraméteres konstruktor generálása, a konstruktor meghívása. Property létrehozása, a get és set blokkok használata.";
            var addText2 = "Az objektumorientált programozás, haladó szintű megismerése C sharp programnyelven, példafeladat megoldásának bemutatásával.";
            var addText3 = "Az osztályszintű tagok használata, a tagok hozzáférési, elérési szintjeinek beállítása.";

            var addColor1 = 's';
            var addColor2 = 'k';
            var addColor3 = 'z';




            /* // NotePage típusú tömb létrehozásával
            NotePage[] np = new NotePage [3];
            np[0] = new NotePage(addText1, addColor1);
            np[1] = new NotePage(addText2, addColor2);
            np[2] = new NotePage(addText3, addColor3);

            or (int i = 0; i < np.Length; i++)
            {
                np[i].GetPageInfo(i);
            }

            Console.WriteLine("\n");

            foreach (NotePage page in np)
            {
                Console.WriteLine(page.GetPageInfo());
            }
            */


            List<NotePage> np = new List<NotePage>();

            np.Add(new NotePage(GET_ID(), addText1.Trim(), addColor1));
            np.Add(new NotePage(GET_ID(), addText2.Trim(), addColor2));
            np.Add(new NotePage(GET_ID(), addText3.Trim(), addColor3));

            
            for (int i = 0; i < np.Count; i++)
            {
                np[i].Get_Page_Info(np[i].Id);
            }
            

            /*
            foreach (NotePage page in np)
            {
                Console.WriteLine(page.Get_Page_Info(page.Id));
            }
            */


            // Szavak számának lekérdezése, az összes esetben:
            /*foreach (NotePage page in np)
            {
                Console.WriteLine("Szavak száma: " + page.Get_Number_Of_Words());
            }
            */


            //np[1].Text = "Három szavú mondat!";
            //Console.WriteLine(np[1].Text);
            //Console.WriteLine(np[1].GetNumberOfWords(np[1].Text));


            NotePage.Return_Sorter_Text_With_Info(np[0], np[1]);

            var addText4 = "Az osztályszintű tagok használata.";

            np.Add(new NotePage(GET_ID(), addText4.Trim(), addColor3));

            for (int i = 0; i < np.Count; i++)
            {
                np[i].Get_Page_Info(np[i].Id);
            }


            Console.ReadKey();
        }
    }
}

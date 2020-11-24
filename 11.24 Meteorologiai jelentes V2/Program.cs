using System;
using System.Linq;

namespace _11._11.Orai_munka
{

    class Program
    {
        static void Main(string[] args)
        {

            // 1. Olvassa be és tárolja el a tavirathu13.txt állomány adatait!
            Process.ImportData();

            // 1.2 Városnevek lista létrehozása
            Process.CreateCityList();

            // 2. Kérje be a felhasználótól egy város kódját! Adja meg, hogy az adott városból mikor érkezett az utolsó mérési adat!A kiírásban az időpontot óó:pp formátumban jelenítse meg!
            string city = Process.GetCityName();
            Process.SelectLastMeasureTime(city);

            // 3. Határozza meg, hogy a nap során mikor mérték a legalacsonyabb és a legmagasabb hőmérsékletet! Jelenítse meg a méréshez kapcsolódó település nevét, az időpontot és a hőmérsékletet! Amennyiben több legnagyobb vagy legkisebb érték van, akkor elég az egyiket kiírnia.
            Process.GetMaxMinTemp();

            // 4. Határozza meg, azokat a településeket és időpontokat, ahol és amikor a mérések idején szélcsend volt!(A szélcsendet a táviratban 00000 kóddal jelölik.) Ha nem volt ilyen, akkor a „Nem volt szélcsend a mérések idején.” szöveget írja ki! A kiírásnál a település kódját és az időpontot jelenítse meg.
            Process.ZeroWindInfo();

            // 5. Határozza meg a települések napi középhőmérsékleti adatát és a hőmérséklet - ingadozását! A kiírásnál a település kódja szerepeljen a sor elején a minta szerint!A kiírásnál csak a megoldott feladatrészre vonatkozó szöveget és értékeket írja ki!
            Process.Calculations();

            // 6. Hozzon létre településenként egy szöveges állományt, amely első sorában a település kódját tartalmazza! A további sorokban a mérési időpontok és a hozzá tartozó szélerősségek jelenjenek meg! A szélerősséget a minta szerint a számértéknek megfelelő számú kettőskereszttel(#) adja meg! A fájlban az időpontokat és a szélerősséget megjelenítő kettőskereszteket szóközzel válassza el egymástól! A fájl neve X.txt legyen, ahol az X helyére a település kódja kerüljön!
            Process.WriteToFile();

            // PROGRAM VÉGE
            Console.ReadKey();

        }
    }
}

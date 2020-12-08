using System;
using System.Linq;
using System.Threading.Tasks;

namespace _12._08._2020_Sorozatok_V1
{

    class Program
    {
        static void Main(string[] args)
        {

            #region 1.Feladat
            Methods.readTextFileIn();
            #endregion

            #region 2.Feladat
            Methods.getKnowDateCounts();
            #endregion

            #region 3.Feladat
            Methods.getWatchedFilmsPercent();
            #endregion

            #region 4.Feladat
            Methods.getWatchedTime();
            #endregion

            #region 5.Feladat
            Methods.listUnwatchedFilmsbyDate();
            #endregion

            #region 6+7.Feladat
            Methods m = new Methods();
            m.selectDaysOfInput();
            #endregion

            #region 8.Feladat
            m.SumSeriesTime();
            #endregion



            #region Helper
            Console.ReadKey();
            #endregion
        }
    }
}

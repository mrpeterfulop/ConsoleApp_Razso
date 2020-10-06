using System;

namespace _10._06.Input_Data__Classes
{
    public class myTime
    {
        public string greating;
        public string timeNow;

        public void checkTheTime()

        {
            var today = DateTime.Now;
            var hour = today.Hour;
            var minute = today.Minute;

            var hourZero = (hour < 10) ? "0" : "";
            var minuteZero = (minute < 10) ? "0" : "";
            
            timeNow = $"{hourZero}{hour}:{minuteZero}{minute}";


            if (hour >= 5 & hour <= 12){
                greating = "jó reggelt";}
               else if (hour >= 12 & hour <= 18){
                greating = "jó napot";}
                    else{greating = "jó estét";}
        }

    }
}
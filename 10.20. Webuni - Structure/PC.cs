using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace _10._20.Webuni___Structure
{
    struct PC
    {
        
        public string procType;
        public string memoryType;
        public string hardDriveType;
        public int procClockSpeed;
        public int memoryClockSpeed;


        public PC(string procType, string memoryType, string hardDriveType, int procClockSpeed, int memoryClockSpeed)
        {

            this.procType = procType;
            this.memoryType = memoryType;
            this.hardDriveType = hardDriveType;
            this.procClockSpeed = procClockSpeed;
            this.memoryClockSpeed = memoryClockSpeed;

        }
        

        public void DisplayPC(string fileName)
        {
            StreamReader sr = new StreamReader(fileName);
            List<PC> pcList = new List<PC>();

            while (!sr.EndOfStream)
            {
                string[] pcInfo = sr.ReadLine().Split();
                int procSpeed = int.Parse(pcInfo[3]);
                int memorySpeed = int.Parse(pcInfo[4]);
                PC pc = new PC(pcInfo[0], pcInfo[1], pcInfo[2], procSpeed, memorySpeed);

                pcList.Add(pc);

            }

            sr.Close();

            foreach (PC item in pcList)
            {
                Console.WriteLine($"{item.procType},{item.memoryType},{item.hardDriveType},{item.procClockSpeed},{item.memoryClockSpeed}");
            }


        }




    }
}

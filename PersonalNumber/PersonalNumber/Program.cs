using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace PersonalNumber
{
    class Program
    {
        static bool YearCheck(string yearstr)
        {
            int yearint = Convert.ToInt32(yearstr);
            if (yearint >= 1753 && yearint <= 2020)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        static void Main(string[] args)
        {
            bool yearVal;
            string[] numCom = new string[1];
            int[] prsNr = new int[12] { 1, 9, 9, 9, 1, 1, 2, 2, 7, 1, 3, 1 };
            for (int i = 0; i < 4; i++)
            {
                numCom[0] += Convert.ToString(prsNr[i]);
            }
            yearVal = YearCheck(numCom[0]);
            Console.ReadKey();
        }
    }
}

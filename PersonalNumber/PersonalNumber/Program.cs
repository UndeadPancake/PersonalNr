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
        static bool YearCheck(int year)
        {
            if (year >= 1753 && year <= 2020)
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
            bool yearBool;
            string[] numCom = new string[1];
            int[] prsNr = new int[12] { 1, 9, 9, 9, 1, 1, 2, 2, 7, 1, 3, 1 };
            for (int i = 0; i < 4; i++)
            {
                numCom[0] += prsNr[i];
            }
            yearBool = YearCheck(Convert.ToInt32(numCom[0]));
            if (yearBool == true)
            {
                Console.WriteLine("true");
            }
            Console.WriteLine(numCom[0]);
            Console.ReadKey();
        }
    }
}

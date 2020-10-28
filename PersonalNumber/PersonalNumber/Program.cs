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
            if (year >= 1753 && year <= 2020) return true;
            else return false;
        }
        static bool MonthCheck(int month)
        {
            if (month >= 1 && month <= 12) return true;
            else return false;
        }
        static void Main(string[] args)
        {
            string toChar;
            bool yearBool;
            bool monthBool;
            bool daybool;
            bool numBool;
            char[] prsNr = new char[12];
            string[] numCom = new string[4];
            Console.Write("Skriv ditt personummer:");
            toChar = Console.ReadLine();
            prsNr = toChar.ToCharArray();
            for (int i = 0; i < 4; i++)
            {
                numCom[0] += prsNr[i];
            }
            yearBool = YearCheck(Convert.ToInt32(numCom[0]));
            for (int i = 4; i < 6; i++)
            {
                numCom[1] += prsNr[i];
            }
            monthBool = MonthCheck(Convert.ToInt32(numCom[1]));
            if (yearBool && monthBool)
            {
                Console.WriteLine("true");
            }
            Console.WriteLine(numCom[0]);
            Console.WriteLine(numCom[1]);
            Console.ReadKey();
        }
    }
}

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
        static bool DayCheck(int year, int month, int day)
        {
            double yearDouble = (double)year;
            if (month == 01 || month == 03 || month == 05 || month == 07 || month == 08 || month == 10 || month == 12)
            {
                if (day >= 1 && day <= 31) return true;
                else return false;
            }
            else if (month == 04 || month == 06 || month == 09 || month == 11)
            {
                if (day >= 1 && day <= 30) return true;
                else return false;
            }
            else
            {
                if (year / 400 == yearDouble / 400)
                {
                    if (day >= 1 && day <= 29) return true;
                    else return false;
                }
                else if (year / 100 == yearDouble / 100)
                {
                    if (day >= 1 && day <= 28) return true;
                    else return false;
                }
                else if (year / 4 == yearDouble / 4)
                {
                    if (day >= 1 && day <= 29) return true;
                    else return false;
                }
                else
                {
                    if (day >= 1 && day <= 28) return true;
                    else return false;
                }
            }
        }
        static void Main(string[] args)
        {
            string toChar;
            bool yearBool;
            bool monthBool;
            bool dayBool;
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
            for (int i = 6; i < 8; i++)
            {
                numCom[2] += prsNr[i];
            }
            dayBool = DayCheck(Convert.ToInt32(numCom[0]), Convert.ToInt32(numCom[1]), Convert.ToInt32(numCom[2]));
            if (yearBool && monthBool && dayBool)
            {
                Console.WriteLine("true");
            }
            Console.WriteLine(numCom[0]);
            Console.WriteLine(numCom[1]);
            Console.WriteLine(numCom[2]);
            Console.ReadKey();
        }
    }
}

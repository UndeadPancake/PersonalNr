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
        static bool YearCheck(int year) //Simple year check
        {
            if (year >= 1753 && year <= 2020) return true;
            else return false;
        }
        static bool MonthCheck(int month) //Simple month check
        {
            if (month >= 1 && month <= 12) return true;
            else return false;
        }
        static bool DayCheck(int year, int month, int day)  
        {
            double yearDouble = (double)year;
            if (month == 01 || month == 03 || month == 05 || month == 07 || month == 08 || month == 10 || month == 12) //Checks for 31 day month
            {
                if (day >= 1 && day <= 31) return true;
                else return false;
            }
            else if (month == 04 || month == 06 || month == 09 || month == 11)  //Checks for 30 day month
            {
                if (day >= 1 && day <= 30) return true;
                else return false;
            }
            else //If neither 31 or 30 day month, it's February
            {
                if (year / 400 == yearDouble / 400) //First step for leap year check, if true it's a leap year
                {
                    if (day >= 1 && day <= 29) return true;
                    else return false;
                }
                else if (year / 100 == yearDouble / 100) //Second step for leap year check, if true it's not a leap year
                {
                    if (day >= 1 && day <= 28) return true;
                    else return false;
                }
                else if (year / 4 == yearDouble / 4)  //Last step for leap year check, if true it's a leap year
                {
                    if (day >= 1 && day <= 29) return true;
                    else return false;
                }
                else //If no previous leap year check has been true, it's not a leap year
                {
                    if (day >= 1 && day <= 28) return true;
                    else return false;
                }
            }
        }
        static bool NumCheck(int num)   //Simple number check
        {
            if (num >= 000 && num <= 999) return true;
            else return false;
        }
        static bool GenderCheck(int num) //Checks gender by creating an equal double, dividing both in half and checking if they're still equal
        {
            double numDouble = (double)num;
            if (num / 2 == numDouble / 2) return true;
            else return false;
        }
        static void Main(string[] args)
        {
            string toChar;  //To char
            bool yearBool;  
            bool monthBool; 
            bool dayBool;
            bool numBool;
            char[] prsNr = new char[12];      //Personal number saved in char array
            string[] numConv = new string[4]; //String array for easier conversion to int
            Console.Write("Skriv ditt personummer:");
            toChar = Console.ReadLine();  //To char variable used to convert user input to string format
            prsNr = toChar.ToCharArray(); //Converts user string input to char array
            for (int i = 0; i < 4; i++)
            {
                numConv[0] += prsNr[i];   //Inserts first four characters into a string array to get year as a string
            }
            yearBool = YearCheck(Convert.ToInt32(numConv[0]));
            for (int i = 4; i < 6; i++)
            {
                numConv[1] += prsNr[i];   //Gets month as string
            }
            monthBool = MonthCheck(Convert.ToInt32(numConv[1]));
            for (int i = 6; i < 8; i++)
            {
                numConv[2] += prsNr[i];   //Gets day as string
            }
            dayBool = DayCheck(Convert.ToInt32(numConv[0]), Convert.ToInt32(numConv[1]), Convert.ToInt32(numConv[2]));
            for (int i = 8; i < 11; i++)
            {
                numConv[3] += prsNr[i];   //Gets numbers as string
            }
            numBool = NumCheck(Convert.ToInt32(numConv[3]));
            if (yearBool && monthBool && dayBool && numBool)   //Checks if all numbers are valid, results have been saved in booleans 
            {                                                  //to not have to invoke every method here
                Console.Write("Ditt personummer är giltigt. ");
            }
            else
            {
                Console.Write("Ditt personummer är inte giltigt. ");
            }
            if (GenderCheck(Convert.ToInt32(prsNr[10])))    //Invokes gender check
            {
                Console.WriteLine("Du är en kvinna.");
            }
            else
            {
                Console.WriteLine("Du är en man.");
            }
            Console.ReadKey();
        }
    }
}

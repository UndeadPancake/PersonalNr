﻿using System;
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
            if (num / 2 == numDouble / 2) return true;     //If equal, it is an even number and the user is female
            else return false;                             //If not, it is an odd number and the user is male
        }
        static string NumConvMinus(string input) //Conv
        {
            string output = "";
            int year;
            char[] inputArray = new char[12];
            char[] convertArray = new char[12];
            inputArray = input.ToCharArray();
            input = Convert.ToString(inputArray[0]) + Convert.ToString(inputArray[1]);
            year = Convert.ToInt32(input);
            if (year >= 21)
            {
                for (int i = 2; i < 12; i++)
                {
                    if (inputArray[i - 2] == '-')
                    {
                        inputArray[i - 2] = inputArray[i - 1];
                        inputArray[i - 1] = inputArray[i];
                        inputArray[i] = inputArray[i + 1];
                        inputArray[i + 1] = inputArray[i + 2];
                        convertArray[i] = inputArray[i - 2];
                    }
                    else
                    {
                        convertArray[i] = inputArray[i - 2];
                    }
                }
                convertArray[0] = '1';
                convertArray[1] = '9';
            }
            else
            {
                for (int i = 2; i < 12; i++)
                {
                    if (inputArray[i - 2] == '-')
                    {
                        inputArray[i - 2] = inputArray[i - 1];
                        inputArray[i - 1] = inputArray[i];
                        inputArray[i] = inputArray[i + 1];
                        inputArray[i + 1] = inputArray[i + 2];
                        convertArray[i] = inputArray[i - 2];
                    }
                    else
                    {
                        convertArray[i] = inputArray[i - 2];
                    }
                }
                convertArray[0] = '2';
                convertArray[1] = '0';
            }
            for (int i = 0; i < 12; i++)
            {
                output += convertArray[i];
            }
            return output;
        }
        static string NumConvPlus(string input)  //Conv
        {
            string output = "";
            int year;
            char[] inputArray = new char[12];
            char[] convertArray = new char[12];
            inputArray = input.ToCharArray();
            input = Convert.ToString(inputArray[0]) + Convert.ToString(inputArray[1]);
            year = Convert.ToInt32(input);
            if (year >= 21)
            {
                for (int i = 2; i < 12; i++)
                {
                    if (inputArray[i - 2] == '+')
                    {
                        inputArray[i - 2] = inputArray[i - 1];
                        inputArray[i - 1] = inputArray[i];
                        inputArray[i] = inputArray[i + 1];
                        inputArray[i + 1] = inputArray[i + 2];
                        convertArray[i] = inputArray[i - 2];
                    }
                    else
                    {
                        convertArray[i] = inputArray[i - 2];
                    }
                }
                convertArray[0] = '1';
                convertArray[1] = '8';
            }
            else
            {
                for (int i = 2; i < 12; i++)
                {
                    if (inputArray[i - 2] == '+')
                    {
                        inputArray[i - 2] = inputArray[i - 1];
                        inputArray[i - 1] = inputArray[i];
                        inputArray[i] = inputArray[i + 1];
                        inputArray[i + 1] = inputArray[i + 2];
                        convertArray[i] = inputArray[i - 2];
                    }
                    else
                    {
                        convertArray[i] = inputArray[i - 2];
                    }
                }
                convertArray[0] = '1';
                convertArray[1] = '9';
            }
            for (int i = 0; i < 12; i++)
            {
                output += convertArray[i];
            }
            return output;
        }
        static bool ControlCheck(string input)
        {
            string middleMan;
            int control;
            double id;
            char[] toInt = new char[14];
            int[] toResult = new int[14];
            toInt = input.ToCharArray();
            input = "";
            middleMan = Convert.ToString(toInt[9]);
            control = Convert.ToInt32(middleMan);
            for (int i = 0; i < toInt.Length - 1; i++)
            {
                id = (double)i;
                middleMan = Convert.ToString(toInt[i]);
                toResult[i] = Convert.ToInt32(middleMan);
                if (i / 2 == id / 2)
                {
                    toResult[i] *= 2;
                }
                input += toResult[i];
            }
            toInt = input.ToCharArray();
            for (int i = 0; i < toInt.Length; i++)
            {
                middleMan = Convert.ToString(toInt[i]);
                toResult[i] = Convert.ToInt32(middleMan);
            }
            for (int i = 0; i < toResult.Length - 1; i++) //remember here
            {
                toResult[0] += toResult[i + 1];
            }
            id = (double)toResult[0];
            input = "";
            if (id / 10 == toResult[0] / 10)
            {
                toResult[0] = 0;
            }
            else
            {
                input = Convert.ToString(toResult[0]);
                toInt = input.ToCharArray();
                switch (toInt[1])
                {
                    case '1':
                        toResult[0] = 9;
                        break;
                    case '2':
                        toResult[0] = 8;
                        break;
                    case '3':
                        toResult[0] = 7;
                        break;
                    case '4':
                        toResult[0] = 6;
                        break;
                    case '5':
                        toResult[0] = 5;
                        break;
                    case '6':
                        toResult[0] = 4;
                        break;
                    case '7':
                        toResult[0] = 3;
                        break;
                    case '8':
                        toResult[0] = 2;
                        break;
                    case '9':
                        toResult[0] = 1;
                        break;
                }
            }
            if (toResult[0] == control) return true;
            else return false;
        }
        static void Main(string[] args)
        {
            string toChar;  //To char
            bool yearBool;  
            bool monthBool; 
            bool dayBool;
            bool numBool;
            bool controlBool;
            char[] prsNr = new char[12];      //Personal number saved in char array
            string[] numConv = new string[4]; //String array for easier conversion to int
            Console.Write("Skriv ditt personummer:");
            toChar = Console.ReadLine();  //To char variable used to convert user input to string format
            prsNr = toChar.ToCharArray(); //Converts user string input to char array
            if (prsNr[6] == '-')
            {
                toChar = NumConvMinus(toChar);
                prsNr = toChar.ToCharArray();
            }
            else if (prsNr[6] == '+')
            {
                toChar = NumConvPlus(toChar);
                prsNr = toChar.ToCharArray();
            }
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
            toChar = "";
            for (int i = 2; i < prsNr.Length; i++)
            {
                toChar += prsNr[i];
            }
            controlBool = ControlCheck(toChar);
            if (yearBool && monthBool && dayBool && numBool && controlBool)   //Checks if all numbers are valid, results have been saved in booleans 
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

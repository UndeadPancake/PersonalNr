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
            if (num / 2 == numDouble / 2) return true;     //If equal, it is an even number and the user is female
            else return false;                             //If not, it is an odd number and the user is male
        }
        static string NumConvMinus(string input) //Converts 10-numbered personal number with a dash into a 12-numbered form
        {
            string output = "";
            int year;
            char[] inputArray = new char[12];
            char[] convertArray = new char[12];
            inputArray = input.ToCharArray();
            input = Convert.ToString(inputArray[0]) + Convert.ToString(inputArray[1]);
            year = Convert.ToInt32(input);
            if (year >= 21)   //Checks if the year is 21 or over, if it is it's 19XX
            {
                for (int i = 2; i < 12; i++)        //Starts at two to make it easy for convertArray
                {
                    if (inputArray[i - 2] == '-')        //Checks if this character is a dash
                    {                                    //if it is it moves the rest of the numbers to get rid of the dash
                        inputArray[i - 2] = inputArray[i - 1];
                        inputArray[i - 1] = inputArray[i];
                        inputArray[i] = inputArray[i + 1];
                        inputArray[i + 1] = inputArray[i + 2];
                        convertArray[i] = inputArray[i - 2];
                    }
                    else
                    {
                        convertArray[i] = inputArray[i - 2];  //Moves all numbers over to convertArray to make
                    }                                         //convertArray the full number in 12 numbered form
                }
                convertArray[0] = '1';                        //Adds the missing year numbers
                convertArray[1] = '9';
            }
            else         //If the year is not 21 or over it is 20XX
            {
                for (int i = 2; i < 12; i++)        //Starts at two to make it easy for convertArray
                {
                    if (inputArray[i - 2] == '-')       //Checks if this character is a dash
                    {                                   //if it is it moves the rest of the numbers to get rid of the dash
                        inputArray[i - 2] = inputArray[i - 1];
                        inputArray[i - 1] = inputArray[i];
                        inputArray[i] = inputArray[i + 1];
                        inputArray[i + 1] = inputArray[i + 2];
                        convertArray[i] = inputArray[i - 2];
                    }
                    else
                    {
                        convertArray[i] = inputArray[i - 2];  //moves all numbers over to convertArray to make
                    }                                         //convertArray the full number in 12 numbered form
                }
                convertArray[0] = '2';                        //Adds the missing year numbers
                convertArray[1] = '0';
            }
            for (int i = 0; i < 12; i++)
            {
                output += convertArray[i];                    //makes output the full 12 numbered personal number
            }
            return output;
        }
        static string NumConvPlus(string input)  //Converts 10-numbered personal number with a dash into a 12-numbered form
        {
            string output = "";
            int year;
            char[] inputArray = new char[12];
            char[] convertArray = new char[12];
            inputArray = input.ToCharArray();
            input = Convert.ToString(inputArray[0]) + Convert.ToString(inputArray[1]);
            year = Convert.ToInt32(input);
            if (year >= 21)   //Checks if the year is 21 or over, if it is it's 18XX
            {
                for (int i = 2; i < 12; i++)        //Starts at two to make it easy for convertArray
                {
                    if (inputArray[i - 2] == '+')       //Checks if this character is a plus
                    {                                   //if it is it moves the rest of the numbers to get rid of the dash
                        inputArray[i - 2] = inputArray[i - 1];
                        inputArray[i - 1] = inputArray[i];
                        inputArray[i] = inputArray[i + 1];
                        inputArray[i + 1] = inputArray[i + 2];
                        convertArray[i] = inputArray[i - 2];
                    }
                    else
                    {
                        convertArray[i] = inputArray[i - 2];  //moves all numbers over to convertArray to make
                    }                                         //convertArray the full number in 12 numbered form
                }
                convertArray[0] = '1';                        //Adds the missing year numbers
                convertArray[1] = '8';
            }
            else
            {
                for (int i = 2; i < 12; i++)
                {
                    if (inputArray[i - 2] == '+')       //Checks if this character is a plus
                    {                                   //if it is it moves the rest of the numbers to get rid of the dash
                        inputArray[i - 2] = inputArray[i - 1];
                        inputArray[i - 1] = inputArray[i];
                        inputArray[i] = inputArray[i + 1];
                        inputArray[i + 1] = inputArray[i + 2];
                        convertArray[i] = inputArray[i - 2];
                    }
                    else
                    {
                        convertArray[i] = inputArray[i - 2];  //moves all numbers over to convertArray to make
                    }                                         //convertArray the full number in 12 numbered form
                }
                convertArray[0] = '1';                        //Adds the missing year numbers
                convertArray[1] = '9';
            }
            for (int i = 0; i < 12; i++)
            {
                output += convertArray[i];                    //makes output the full 12 numbered personal number
            }
            return output;
        }
        static bool ControlCheck(string input)   //Checks the last number
        {
            string middleMan;  //Used for converting chars into ints
            int control;
            double id;
            char[] toInt = new char[14];
            int[] toResult = new int[14];
            toInt = input.ToCharArray();         
            input = "";    //Unassigns input for future use
            middleMan = Convert.ToString(toInt[9]);
            control = Convert.ToInt32(middleMan);        //Saves the control number
            for (int i = 0; i < toInt.Length - 1; i++)
            {
                id = (double)i;
                middleMan = Convert.ToString(toInt[i]);
                toResult[i] = Convert.ToInt32(middleMan); //Puts numbers in int array to be able to double them
                if (i / 2 == id / 2)                      //Because of how vectors count checks if i is an even number
                {                                         //If i is even it doubles the number
                    toResult[i] *= 2;
                }
                input += toResult[i];                     //Puts the resulting numbers into a string to be able to separate them
            }
            toInt = input.ToCharArray();
            for (int i = 0; i < toInt.Length; i++)
            {
                middleMan = Convert.ToString(toInt[i]);
                toResult[i] = Convert.ToInt32(middleMan); //Puts numbers in int array to be able to add them
            }
            for (int i = 0; i < toResult.Length - 1; i++)
            {
                toResult[0] += toResult[i + 1];           //Adds numbers together
            }
            middleMan = ""; //Unassign middleMan for use in converting
            {
                middleMan = Convert.ToString(toResult[0]);
                toInt = middleMan.ToCharArray();
                switch (toInt[1])     //Checks what the final number in the result of all numbers added together is
                {                     //to determine what the control number should be. It's all based on the final number according to this switch case
                    case '0':
                        toResult[0] = 0;
                        break;
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
            bool loopBool = true;
            string toChar = "";  //To char
            bool yearBool = false;
            bool monthBool = false;
            bool dayBool = false;
            bool numBool = false;
            bool controlBool = false;
            char[] prsNr = new char[12];      //Personal number saved in char array
            string[] numConv = new string[5]; //String array for easier conversion to int
            int[] test = new int[12];
            while (loopBool)
            {
                Console.Write("Skriv ditt personummer:");
                toChar = Console.ReadLine();  //To char variable used to convert user input to string format
                prsNr = toChar.ToCharArray(); //Converts user string input to char array
                try
                {
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
                    for (int i = 0; i < prsNr.Length; i++)
                    {
                        test[i] = prsNr[i];
                    }
                    loopBool = false;
                }
                catch
                {
                    Console.WriteLine("Var god skriv endast i 12-siffrigt format, eller 10-siffrigt format med bindestreck eller plustecken.");
                }
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
            for (int i = 2; i < prsNr.Length; i++)
            {
                numConv[4] += prsNr[i];   //Gets entire personal number minus the first two letter as string
            }                             //as the first two letters are unnecessary for method
            controlBool = ControlCheck(numConv[4]);
            if (yearBool && monthBool && dayBool && numBool && controlBool)   //Checks if all numbers are valid, results have been saved in booleans 
            {                                                                 //to not have to invoke every method here
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
            loopBool = false;
            Console.ReadKey();
        }
    }
}

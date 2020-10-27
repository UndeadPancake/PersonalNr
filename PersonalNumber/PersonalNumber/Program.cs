using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalNumber
{
    class Program
    {
        static bool YearCheck(int[] prsNr = new int[])
        {
            if (prsNr[0] == 1)
            {
                if (prsNr[1] == 7)
                {
                    if (prsNr[2] == 5)
                    {
                        if (prsNr[3] > 2)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else if (prsNr[2] > 5)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else if (prsNr[1] > 7)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else if (prsNr[0] == 2)
            {
                if (prsNr[1] == 0)
                {
                    if (prsNr[2] == 2)
                    {
                        if (prsNr[3] == 0)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else if (prsNr[2] < 2)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        static void Main(string[] args)
        {
            int[] prsNr = new int[12] { 1, 9, 9, 9, 1, 1, 2, 2, 7, 1, 3, 1 };
            if (YearCheck(prsNr[]);
            { 
                Console.WriteLine("true"); 
            }
            Console.ReadKey();
        }
    }
}

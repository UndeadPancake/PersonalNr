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
        static void Main(string[] args)
        {
            string[] numCom = new string[12];
            int[] prsNr = new int[12] { 1, 9, 9, 9, 1, 1, 2, 2, 7, 1, 3, 1 };
            for (int i = 0; i < 4; i++)
            {
                numCom[i] = Convert.ToString(prsNr[i]);
            }
            Console.WriteLine(numCom);
            Console.ReadKey();
        }
    }
}

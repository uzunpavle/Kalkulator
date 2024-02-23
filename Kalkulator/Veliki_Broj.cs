using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalkulator
{
    internal class Veliki_Broj
    {
        public static bool Proveri_Veliki(string input) //ne radi posle odredjenog broja cifara, napravi ga rucno, broj je validan kad je na pocetku minus(moze i ne mora), sve su brojevi i 0 ili 1 tacka
        {
            if (float.TryParse(input, out float result))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static string Saberi(string num1, string num2)
        {
            StringBuilder sum = new StringBuilder();
            int carry = 0;
            int i = num1.Length - 1;
            int j = num2.Length - 1;

            while (i >= 0 || j >= 0 || carry > 0)
            {
                int digit1 = i >= 0 ? num1[i] - '0' : 0;
                int digit2 = j >= 0 ? num2[j] - '0' : 0;

                int total = digit1 + digit2 + carry;
                int digitSum = total % 10;
                carry = total / 10;

                sum.Insert(0, digitSum);
                i--;
                j--;
            }

            return sum.ToString();
        }

    }
}

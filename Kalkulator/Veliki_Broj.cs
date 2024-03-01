using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Kalkulator
{
    internal class Veliki_Broj
    {
        public static bool Proveri_Veliki(string input) //ne radi posle odredjenog broja cifara, napravi ga rucno, broj je validan kad je na pocetku minus(moze i ne mora), sve su brojevi i 0 ili 1 tacka
        {
            string reg = "[+-]?([0-9]*[.])?[0-9]+";
            Regex re = new Regex(reg);
            if (re.IsMatch(input))
                return true;
            else
                return false;
        }

        public static string Saberi(string num1, string num2)
        {
            // Find the positions of the decimal points
            int decimalIndex1 = num1.IndexOf('.');
            int decimalIndex2 = num2.IndexOf('.');

            // Determine the maximum length
            int maxLength = Math.Max(num1.Length, num2.Length);

            // Adjust the lengths of the numbers to align the decimal points
            num1 = num1.PadRight(maxLength, '0');
            num2 = num2.PadRight(maxLength, '0');

            // Initialize result and carry
            char[] result = new char[maxLength + 1];
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = '0';
            }
            int carry = 0;

            // Iterate through the digits, starting from the least significant digit
            for (int i = maxLength - 1; i >= 0; i--)
            {
                // Skip the decimal point
                if (num1[i] == '.')
                    continue;

                // Convert characters to integers
                int digit1 = i < num1.Length ? num1[i] - '0' : 0;
                int digit2 = i < num2.Length ? num2[i] - '0' : 0;

                // Perform addition
                int sum = digit1 + digit2 + carry;

                // Update carry
                carry = sum / 10;

                // Update result
                result[i + 1] = (char)((sum % 10) + '0');
            }

            // Convert result to string
            string resultString = new string(result);

            // Insert decimal point at appropriate position
            int decimalPosition = maxLength - Math.Max(decimalIndex1, decimalIndex2);
            resultString = resultString.Insert(decimalPosition, ".");

            // Trim leading zeros and return the result
            return resultString.TrimStart('0');
        }

    }
}

using System;
using System.Collections;
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
            string pattern = @"^[-+]?[0-9]*\.?[0-9]+$";
            Regex regex = new Regex(pattern);
            return regex.IsMatch(input);
        }

        static List<char> PrebaciUListu(string input)
        {
            List<char> charList = new List<char>();
            foreach (char c in input)
            {
                charList.Add(c);
            }
            return charList;
        }

        static void Izjednaci_Liste(List<char> list1, List<char> list2)
        {
            int maxLength = Math.Max(list1.Count, list2.Count);

            while (list1.Count < maxLength)
            {
                list1.Insert(0, '0'); 
            }

            while (list2.Count < maxLength)
            {
                list2.Insert(0, '0'); 
            }
        }
        public static string Saberi(string num1, string num2)
        {

            string[] prvi = num1.Split('.');
            string[] drugi = num2.Split('.');

            List<char> prvi_ceo = PrebaciUListu(prvi[0]);
            List<char> drugi_ceo = PrebaciUListu(drugi[0]);
            Izjednaci_Liste(prvi_ceo, drugi_ceo);

            string celi = "";
            int carry = 0;

            for (int i = prvi_ceo.Count - 1; i >= 0; i--)
            {
                int Num1 = prvi_ceo[i] - '0';
                int Num2 = drugi_ceo[i] - '0';

                int sum = Num1 + Num2 + carry;
                carry = sum / 10;
                sum %= 10;

                celi = (char)(sum + '0') + celi;
            }

            if (carry > 0)
            {
                celi = (char)(carry + '0') + celi;
            }

            if (prvi.Length == 1) 
            {
                prvi.;
            }
            if (drugi[1] == null)
            {
                drugi[1] = "0";
            }


            List<char> prvi_deci = PrebaciUListu(prvi[1]);
            List<char> drugi_deci = PrebaciUListu(drugi[1]);
            Izjednaci_Liste(prvi_deci, drugi_deci);

            string deci = "";
            carry = 0;

            for (int i = prvi_deci.Count - 1; i >= 0; i--)
            {
                int Num1 = prvi_deci[i] - '0';
                int Num2 = drugi_deci[i] - '0';

                int sum = Num1 + Num2 + carry;
                carry = sum / 10;
                sum %= 10;

                deci = (char)(sum + '0') + deci;
            }

            if (carry > 0)
            {
                deci = (char)(carry + '0') + deci;
            }

            if ((deci.Length > prvi[1].Length) && (deci.Length > drugi[1].Length))
            {
                int celi_p = Convert.ToInt32(celi);
                celi_p++;
                celi = Convert.ToString(celi_p);
                deci = deci.Substring(1);
            }

            string rez;
            if (deci == "0")
            {
                rez = celi;
            }
            else
            {
                rez = celi + "." + deci;
            }

            return rez;
        }
        

    }
}

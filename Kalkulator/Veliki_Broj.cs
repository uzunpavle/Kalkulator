﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

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

        public static string TrimZerosFromDecimal(string number)
        {
            int decimalIndex = number.IndexOf('.');

            if (decimalIndex == -1)
                return number;

            int endIndex = number.Length - 1;
            while (endIndex > decimalIndex && number[endIndex] == '0')
            {
                endIndex--;
            }

            if (number[endIndex] == '.')
            {
                endIndex--;
            }

            return number.Substring(0, endIndex + 1);
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

        public static string[] Split(string a)
        {
            bool ima_tacku = false;
            foreach (char c in a)
            {
                if (c == '.') ima_tacku = true;
            }

            string[] niz = new string[2];
            if (ima_tacku == true)
            {
                niz = a.Split('.');
            }
            else
            {
                niz[0] = a;
                niz[1] = "0";
            }
            return niz;
        }

        public static List<char> Izbaci_Tacku(string a)
        {
            List<char> chars = new List<char>();
            foreach (char c in a)
            {
                if (c == '.') continue;
                chars.Add(c);
            }
            return chars;
        }

        static string Dodaj_Tacku(string originalString, char charToInsert, int insertionIndex)
        {
            StringBuilder stringBuilder = new StringBuilder(originalString);
            stringBuilder.Insert(insertionIndex, charToInsert);
            return stringBuilder.ToString();
        }

        public static string Saberi(string num1, string num2)
        {

            string[] prvi = Split(num1);
            string[] drugi = Split(num2);

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
        
        public static string Oduzmi(string num1, string num2)
        {
            List<char> prvi = Izbaci_Tacku(num1);
            List<char> drugi = Izbaci_Tacku(num2);

            int tacka_prvi = 0;
            bool ima_tacke = false;
            foreach (char c in num1)
            {
                if (c == '.')
                {
                    ima_tacke = true;
                    continue;
                }
                if (ima_tacke == true)
                {
                    tacka_prvi++;
                }
            }
            int tacka_drugi = 0;
            ima_tacke = false;
            foreach (char c in num2)
            {
                if (c == '.')
                {
                    ima_tacke = true;
                    continue;
                }
                if (ima_tacke == true)
                {
                    tacka_drugi++;
                }
            }
            int tacka = tacka_prvi;
            if (tacka_drugi > tacka_prvi) tacka = tacka_drugi;

            Izjednaci_Liste(prvi, drugi);

            int carry = 0;
            StringBuilder result = new StringBuilder();

            for (int i = prvi.Count - 1; i >= 0; i--)
            {
                int digit1 = prvi[i] - '0';
                int digit2 = drugi[i] - '0';

                int diff = digit1 - digit2 - carry;

                if (diff < 0)
                {
                    diff += 10;
                    carry = 1;
                }
                else
                {
                    carry = 0;
                }

                result.Insert(0, diff);
            }

            string broj = result.ToString().TrimStart('0');

            if ((prvi.Count - tacka) > 0)
            {
                broj = Dodaj_Tacku(broj, '.', prvi.Count - tacka);
            }

            return broj;
        }

        public static string Pomnozi(string num1, string num2)
        {
            bool flag = false;
            int eks_prvi = 0;
            int eks_drugi = 0;
            foreach (char c in num1)
            {
                if (c == '.')
                {
                    flag = true;
                    continue;
                }
                if (flag == true)
                {
                    eks_prvi++;
                }
            }
            flag = false;
            foreach (char c in num2)
            {
                if (c == '.')
                {
                    flag = true;
                    continue;
                }
                if (flag == true)
                {
                    eks_drugi++;
                }
            }

            List<char> prvi = Izbaci_Tacku(num1);
            List<char> drugi = Izbaci_Tacku(num2);
            Izjednaci_Liste(prvi, drugi);

            prvi.Reverse();
            drugi.Reverse();

            List<int> result = new List<int>(new int[prvi.Count + drugi.Count]);

            for (int i = 0; i < prvi.Count; i++)
            {
                for (int j = 0; j < drugi.Count; j++)
                {
                    result[i + j] += (prvi[i] - '0') * (drugi[j] - '0');
                    result[i + j + 1] += result[i + j] / 10;
                    result[i + j] %= 10;
                }
            }

            StringBuilder sb = new StringBuilder();
            for (int i = result.Count - 1; i >= 0; i--)
            {
                sb.Insert(0, result[i]);
            }

            while (sb.Length > 1 && sb[0] == '0')
            {
                sb.Remove(0, 1);
            }

            string broj = sb.ToString();
            /*
            if ((prvi.Count - eks_prvi - eks_drugi) > 0)
            {
                broj = Dodaj_Tacku(broj, '.', prvi.Count - eks_drugi - eks_prvi);
            }
            */
            return broj;
        }
    }
}

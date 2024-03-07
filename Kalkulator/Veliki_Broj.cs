using System;
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

        public static int CompareDecimalStrings(string strNum1, string strNum2)
        {
            // Splitting the strings into integer and decimal parts
            string[] parts1 = strNum1.Split('.');
            string[] parts2 = strNum2.Split('.');

            // Padding the decimal parts with trailing zeros to ensure equal lengths
            if (parts1.Length == 1)
            {
                parts1 = new string[] { parts1[0], "0" };
            }
            if (parts2.Length == 1)
            {
                parts2 = new string[] { parts2[0], "0" };
            }

            int maxLengthInteger = Math.Max(parts1[0].Length, parts2[0].Length);
            int maxLengthDecimal = Math.Max(parts1[1].Length, parts2[1].Length);

            parts1[0] = parts1[0].PadLeft(maxLengthInteger, '0');
            parts2[0] = parts2[0].PadLeft(maxLengthInteger, '0');
            parts1[1] = parts1[1].PadRight(maxLengthDecimal, '0');
            parts2[1] = parts2[1].PadRight(maxLengthDecimal, '0');

            // Comparing integer parts
            for (int i = 0; i < maxLengthInteger; i++)
            {
                if (parts1[0][i] > parts2[0][i])
                {
                    return 1; // First number is larger
                }
                else if (parts1[0][i] < parts2[0][i])
                {
                    return 2; // Second number is larger
                }
            }

            // Comparing decimal parts
            for (int i = 0; i < maxLengthDecimal; i++)
            {
                if (parts1[1][i] > parts2[1][i])
                {
                    return 1; // First number is larger
                }
                else if (parts1[1][i] < parts2[1][i])
                {
                    return 2; // Second number is larger
                }
            }

            // If both numbers are equal
            return 0;
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

        public static bool Decimalan(string s)
        {
            if (s.IndexOf('.') != -1)
            {
                return true;
            }
            else return false;
        }

        public static int MestoZareza(string s)
        {
            return s.IndexOf('.');
        }

        static int Eksponent(string s)
        {
            bool flag = false;
            int eks = 0;
            foreach (char c in s)
            {
                if (c == '.')
                {
                    flag = true;
                    continue;
                }
                if (flag == true)
                {
                    eks++;
                }
            }
            return eks;
        }

        public static string RemoveDot(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return input;
            }
            string result = input.Replace(".", "");

            return result;
        }

        static int Uporedi(string pom1, string pom2)
        {
            int n1 = pom1.Length;
            int n2 = pom2.Length;
            if (n1 > n2)
            {
                for (int i = 0; i < (n1 - n2); i++) { pom2 = "0" + pom2; }
            }
            else if (n1 < n2)
            {
                for (int i = 0; i < (n2 - n1); i++) { pom1 = "0" + pom1; }
            }
            for (int i = 0; i < pom1.Length; i++)
            {
                if ((pom1[i] - '0') > (pom2[i] - '0')) return 1;
                if ((pom2[i] - '0') > (pom1[i] - '0')) return 2;
            }
            return 0;
        }

        public static int Podeli_Medjurezultat(string a, string b)
        {
            string razlika = Oduzmi(a, b);
            int t = 0;
            while (!(razlika[0] == 45))
            {
                if (razlika == "0") return t + 1;
                razlika = Oduzmi(razlika, b);
                t++;
            }
            return t;
        }

        public static string Kolicnik(string a, string b)
        {
            if (a == "0") return "0";
            if (Uporedi(a, b) == 2) return "0";
            string pom1 = a;
            string rez = string.Empty;
            string s1 = pom1.Substring(0, b.Length);
            if (Uporedi(b, s1) == 1)
            {
                s1 = pom1.Substring(0, b.Length + 1);
            }
            int duzina = s1.Length;
            for (int i = duzina; i <= pom1.Length; i++)
            {
                int kol = Podeli_Medjurezultat(s1, b);
                rez = rez + kol;
                if (i == pom1.Length) break;
                s1 = Oduzmi(s1, Pomnozi(kol.ToString(), b));
                if (s1 == "0") { s1 = (pom1[i] - '0').ToString(); }
                else s1 = s1 + pom1[i];
            }
            return rez;
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
        
        public static string Oduzmi(string a, string b)
        {
            /*
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
            */

            if (a == b) return "0";
            if (!Decimalan(a) && !Decimalan(b))
            {
                string pom1 = a;
                string pom2 = b;
                pom1 = pom1 + "." + "0";
                pom2 = pom2 + "." + "0";
                string rez = Oduzmi(pom1,pom2);
                rez = rez.TrimEnd('0');
                rez = rez.Replace(".", string.Empty);
                return rez;

            }
            if (Decimalan(a) && Decimalan(b))
            {
                if (a == b) return "0";
                string pom1 = a;
                string pom2 = b;
                int mz1 = MestoZareza(a);
                int mz2 = MestoZareza(b);
                string minus = string.Empty;
                if (mz1 > mz2)
                {
                    for (int i = 0; i < (mz1 - mz2); i++) { pom2 = "0" + pom2; }
                }
                else if (mz1 < mz2)
                {
                    for (int i = 0; i < (mz2 - mz1); i++) { pom1 = "0" + pom1; }
                }
                int n1 = pom1.Length;
                int n2 = pom2.Length;
                if (n1 > n2)
                {
                    for (int i = 0; i < (n1 - n2); i++) { pom2 = pom2 + "0"; }
                }
                else if (n1 < n2)
                {
                    for (int i = 0; i < (n2 - n1); i++) { pom1 = pom1 + "0"; }
                }
                n1 = pom1.Length;
                for (int i = 0; i < n1; i++)
                {
                    if (pom1[i] > pom2[i]) break;
                    else if ((pom1[i] - '0') < (pom2[i] - '0'))
                    {
                        string temp = pom1;
                        pom1 = pom2;
                        pom2 = temp;
                        minus = "-";
                        break;
                    }
                }
                string rez = string.Empty;
                int prenesi = 0;
                n1 = pom1.Length;
                for (int i = n1 - 1; i >= 0; i--)
                {
                    int zbir = 0;
                    if (pom1[i] == 46) { rez = "." + rez; continue; }

                    if (((pom1[i] - '0') - (pom2[i] - '0') - prenesi) < 0)
                    {
                        zbir = 10 + (pom1[i] - '0') - (pom2[i] - '0') - prenesi;
                        prenesi = 1;
                    }
                    else
                    {
                        zbir = (pom1[i] - '0') - (pom2[i] - '0') - prenesi;
                        prenesi = 0;
                    }
                    rez = zbir.ToString() + rez;

                }
                rez = rez.TrimStart('0');
                if (rez[0] == 46) rez = "0" + rez;
                return minus + rez;
            }
            if (Decimalan(a) && !Decimalan(b))
            {
                string pom1 = a;
                string pom2 = b;
                pom2 = pom2 + "." + "0";
                return Oduzmi(pom1,pom2);
            }
            else
            {
                string pom1 = a;
                string pom2 = b;
                pom1 = pom1 + "." + "0";
                return Oduzmi(pom1, pom2);
            }
        }

        public static string Pomnozi(string num1, string num2)
        {
            int eks_prvi = Eksponent(num1);
            int eks_drugi = Eksponent(num2);
            int eks = eks_drugi + eks_prvi;

            List<char> prvi = Izbaci_Tacku(num1);
            List<char> drugi = Izbaci_Tacku(num2);

            string[] brojevi = new string[drugi.Count];
            int carry = 0;
            for (int i = drugi.Count; i > 0; i--)
            {
                for (int j = prvi.Count; j > 0; j--)
                {
                    int broj = Convert.ToInt32(char.GetNumericValue(drugi[i - 1])) * Convert.ToInt32(char.GetNumericValue(prvi[j - 1])) + carry;
                    carry = broj / 10;
                    brojevi[i - 1] = Convert.ToString(broj % 10) + brojevi[i - 1];
                }
                if (carry > 0) brojevi[i - 1] = Convert.ToString(carry) + brojevi[i - 1];
                carry = 0;
            }

            string dopuna = "0";
            for (int i = brojevi.Length; i > 1; i--)
            {               
                string pom = brojevi[i - 2] + dopuna;
                brojevi[i - 2] = Saberi(brojevi[i - 1], pom);
                dopuna += "0";
            }
            string rez = brojevi[0];

            if (eks > 0)
            {
                rez = Dodaj_Tacku(rez, '.', rez.Length - eks);
            }

            return rez;    
            

        }

        public static string Podeli(string a, string b)
        {
            if (b == "0") return "Ne mozete deliti sa 0";
            string rez = string.Empty;
            string kol = Kolicnik(a, b);
            string temp = Oduzmi(a,Pomnozi(kol,b));
            if (temp == "0") return rez + kol;
            else rez = rez + kol + ".";
            //int br_decimala = int.Parse(Form1.form1instance.textBox4.Text);
            for (int i = 0; i < 42; i++)
            {
                if (temp == "0") break;
                temp = temp + "0";
                kol = Kolicnik(temp, b);
                rez = rez + kol;
                temp = Oduzmi(temp,Pomnozi(kol,b));
            }
            return rez;
        }
    }
}

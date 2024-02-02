using System;
using System.Text.RegularExpressions;

public class Rimski_Broj
{
    public static int KonverzijaRim(char c)
    {
        int a = 0;
        switch (c)
        {
            case 'I':
                a = 1;
                break;
            case 'V':
                a = 5;
                break;
            case 'X':
                a = 10;
                break;
            case 'L':
                a = 50;
                break;
            case 'C':
                a = 100;
                break;
            case 'D':
                a = 500;
                break;
            case 'M':
                a = 1000;
                break;
        }
        return a;
    }
    public static int RomanToInt(string s)
    {
        int broj = 0;
        int prvi = 0;
        int drugi = 0;
        for (int i = 0; i < s.Length - 1; i++)
        {
            prvi = KonverzijaRim(s[i]);
            drugi = KonverzijaRim(s[i + 1]);
            if (prvi >= drugi)
            {
                broj += prvi;
            }
            else
            {
                broj -= prvi;
            }
        }
        if (s.Length == 1)
        {
            return KonverzijaRim(s[0]);
        }
        else
        {
            broj += drugi;
            return broj;
        }
    }
    public static bool ProveriRimski(string rimski)
    {
        string strRegex = @"^M{0,3}(CM|CD|D?C{0,3})(XC|XL|L?X{0,3})(IX|IV|V?I{0,3})$";
        Regex re = new Regex(strRegex);
        if (re.IsMatch(rimski))
            return true;
        else
            return false;
    }
    public static string IntToRoman(int broj)
    {
        int pom = broj;
        int jedinice = broj % 10;
        int desetice = broj % 100 - jedinice;
        int stotine = broj % 1000 - jedinice - desetice;
        string rezultat = "";
        while (pom > 0)
        {
            if (pom >= 1000)
            {
                pom -= 1000;
                rezultat += "M";
                continue;
            }

            else if (stotine == 900)
            {
                pom -= 900;
                stotine -= 900;
                rezultat += "CM";
                continue;
            }
            else if (stotine >= 500)
            {
                pom -= 500;
                stotine -= 500;
                rezultat += "D";
                continue;
            }
            else if (stotine == 400)
            {
                pom -= 400;
                stotine -= 400;
                rezultat += "CD";
                continue;
            }
            else if (stotine >= 100)
            {
                pom -= 100;
                stotine -= 100;
                rezultat += "C";
                continue;
            }
            else if (desetice == 90)
            {
                pom -= 90;
                desetice -= 90;
                rezultat += "XC";
                continue;
            }
            else if (desetice >= 50)
            {
                pom -= 50;
                desetice -= 50;
                rezultat += "L";
                continue;
            }
            else if (desetice == 40)
            {
                pom -= 40;
                desetice -= 40;
                rezultat += "XL";
                continue;
            }
            else if (desetice >= 10)
            {
                pom -= 10;
                desetice -= 10;
                rezultat += "X";
                continue;
            }
            else if (jedinice == 9)
            {
                pom -= 9;
                jedinice -= 9;
                rezultat += "IX";
                continue;
            }
            else if (jedinice >= 5)
            {
                pom -= 5;
                jedinice -= 5;
                rezultat += "V";
                continue;
            }
            else if (jedinice == 4)
            {
                pom -= 4;
                jedinice -= 4;
                rezultat += "IV";
                continue;
            }
            else if (jedinice >= 1)
            {
                pom -= 1;
                jedinice -= 1;
                rezultat += "I";
                continue;
            }

        }
        return rezultat;
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Numerics;

namespace Kalkulator
{
    public partial class Form1 : Form
    {
        public string operacija;
        public Form1()
        {
            InitializeComponent();
        }

        private void Brisanje_Click(object sender, EventArgs e)
        {
            if (tabPage1.Visible == true)
            {
                Prvi.Text = string.Empty;
                Drugi.Text = string.Empty;
                Rez.Text = string.Empty;
            }
            else
            {
                Prvi_Big.Text = string.Empty;
                Drugi_Big.Text = string.Empty;
                Rez_Big.Text = string.Empty;
            }
        }

        private void Jedan_rim_Click(object sender, EventArgs e)
        {
            if (Prvi_broj_izabran.Checked)
            {
                Prvi.Text = Prvi.Text + "I";
            }
            else if (Drugi_broj_izabran.Checked)
            {
                Drugi.Text = Drugi.Text + "I";
            }
        }

        private void Pet_rim_Click(object sender, EventArgs e)
        {
            if (Prvi_broj_izabran.Checked)
            {
                Prvi.Text = Prvi.Text + "V";
            }
            else if (Drugi_broj_izabran.Checked)
            {
                Drugi.Text = Drugi.Text + "V";
            }
        }

        private void Deset_rim_Click(object sender, EventArgs e)
        {
            if (Prvi_broj_izabran.Checked)
            {
                Prvi.Text = Prvi.Text + "X";
            }
            else if (Drugi_broj_izabran.Checked)
            {
                Drugi.Text = Drugi.Text + "X";
            }
        }

        private void Pedeset_rim_Click(object sender, EventArgs e)
        {
            if (Prvi_broj_izabran.Checked)
            {
                Prvi.Text = Prvi.Text + "L";
            }
            else if (Drugi_broj_izabran.Checked)
            {
                Drugi.Text = Drugi.Text + "L";
            }
        }

        private void Sto_rim_Click(object sender, EventArgs e)
        {
            if (Prvi_broj_izabran.Checked)
            {
                Prvi.Text = Prvi.Text + "C";
            }
            else if (Drugi_broj_izabran.Checked)
            {
                Drugi.Text = Drugi.Text + "C";
            }
        }

        private void Petsto_rim_Click(object sender, EventArgs e)
        {
            if (Prvi_broj_izabran.Checked)
            {
                Prvi.Text = Prvi.Text + "D";
            }
            else if (Drugi_broj_izabran.Checked)
            {
                Drugi.Text = Drugi.Text + "D";
            }
        }

        private void Hiljadu_rim_Click(object sender, EventArgs e)
        {
            if (Prvi_broj_izabran.Checked)
            {
                Prvi.Text = Prvi.Text + "M";
            }
            else if (Drugi_broj_izabran.Checked)
            {
                Drugi.Text = Drugi.Text + "M";
            }
        }

        private void Sabiranje_Click(object sender, EventArgs e)
        {
            operacija = "+";
        }

        private void Oduzimanje_Click(object sender, EventArgs e)
        {
            operacija = "-";
        }

        private void Mnozenje_Click(object sender, EventArgs e)
        {
            operacija = "*";
        }

        private void Deljenje_Click(object sender, EventArgs e)
        {
            operacija = "/";
        }

        private void Jednako_Click(object sender, EventArgs e)
        {
            if (tabPage1.Visible == true)
            {
                switch (operacija)
                {
                    case "+":
                        if ((Rimski_Broj.ProveriRimski(Prvi.Text) == true) && (Rimski_Broj.ProveriRimski(Drugi.Text) == true))
                        {
                            int prvi = Rimski_Broj.RomanToInt(Prvi.Text);
                            int drugi = Rimski_Broj.RomanToInt(Drugi.Text);
                            int rez = prvi + drugi;
                            if ((rez > 0) && (rez < 4000))
                            {
                                string rezultat = Rimski_Broj.IntToRoman(rez);
                                Rez.Text = rezultat;
                            }
                            else
                            {
                                Rez.Text = Convert.ToString(rez);
                            }
                        }
                        else
                        {
                            if ((Rimski_Broj.ProveriRimski(Prvi.Text) == false) && (Rimski_Broj.ProveriRimski(Drugi.Text) == false))
                            {
                                MessageBox.Show("Ni prvi ni drugi broj nisu validni rimski brojevi.");
                            }
                            else if (Rimski_Broj.ProveriRimski(Prvi.Text) == false)
                            {
                                MessageBox.Show("Prvi broj nije validan rimski broj.");
                            }
                            else if (Rimski_Broj.ProveriRimski(Drugi.Text) == false)
                            {
                                MessageBox.Show("Drugi broj nije validan rimski broj.");
                            }
                        }
                        break;
                    case "-":
                        if ((Rimski_Broj.ProveriRimski(Prvi.Text) == true) && (Rimski_Broj.ProveriRimski(Drugi.Text) == true))
                        {
                            int prvi = Rimski_Broj.RomanToInt(Prvi.Text);
                            int drugi = Rimski_Broj.RomanToInt(Drugi.Text);
                            int rez = prvi - drugi;
                            if ((rez > 0) && (rez < 4000))
                            {
                                string rezultat = Rimski_Broj.IntToRoman(rez);
                                Rez.Text = rezultat;
                            }
                            else
                            {
                                Rez.Text = Convert.ToString(rez);
                            }
                        }
                        else
                        {
                            if ((Rimski_Broj.ProveriRimski(Prvi.Text) == false) && (Rimski_Broj.ProveriRimski(Drugi.Text) == false))
                            {
                                MessageBox.Show("Ni prvi ni drugi broj nisu validni rimski brojevi.");
                            }
                            else if (Rimski_Broj.ProveriRimski(Prvi.Text) == false)
                            {
                                MessageBox.Show("Prvi broj nije validan rimski broj.");
                            }
                            else if (Rimski_Broj.ProveriRimski(Drugi.Text) == false)
                            {
                                MessageBox.Show("Drugi broj nije validan rimski broj.");
                            }
                        }
                        break;
                    case "*":
                        if ((Rimski_Broj.ProveriRimski(Prvi.Text) == true) && (Rimski_Broj.ProveriRimski(Drugi.Text) == true))
                        {
                            int prvi = Rimski_Broj.RomanToInt(Prvi.Text);
                            int drugi = Rimski_Broj.RomanToInt(Drugi.Text);
                            int rez = prvi * drugi;
                            if ((rez > 0) && (rez < 4000))
                            {
                                string rezultat = Rimski_Broj.IntToRoman(rez);
                                Rez.Text = rezultat;
                            }
                            else
                            {
                                Rez.Text = Convert.ToString(rez);
                            }
                        }
                        else
                        {
                            if ((Rimski_Broj.ProveriRimski(Prvi.Text) == false) && (Rimski_Broj.ProveriRimski(Drugi.Text) == false))
                            {
                                MessageBox.Show("Ni prvi ni drugi broj nisu validni rimski brojevi.");
                            }
                            else if (Rimski_Broj.ProveriRimski(Prvi.Text) == false)
                            {
                                MessageBox.Show("Prvi broj nije validan rimski broj.");
                            }
                            else if (Rimski_Broj.ProveriRimski(Drugi.Text) == false)
                            {
                                MessageBox.Show("Drugi broj nije validan rimski broj.");
                            }
                        }
                        break;
                    case "/":
                        if ((Rimski_Broj.ProveriRimski(Prvi.Text) == true) && (Rimski_Broj.ProveriRimski(Drugi.Text) == true))
                        {
                            int prvi = Rimski_Broj.RomanToInt(Prvi.Text);
                            int drugi = Rimski_Broj.RomanToInt(Drugi.Text);
                            int rez = prvi / drugi;
                            int ostatak = prvi % drugi;
                            if ((rez > 0) && (rez < 4000))
                            {
                                string rezultat = Rimski_Broj.IntToRoman(rez);
                                string ost = Rimski_Broj.IntToRoman(ostatak);
                                if (ostatak == 0)
                                {
                                    Rez.Text = rezultat;
                                }
                                else
                                {
                                    Rez.Text = rezultat + " (Ostatak = " + ost + ")";
                                }
                            }
                            else
                            {
                                Rez.Text = Convert.ToString(rez);
                            }
                        }
                        else
                        {
                            if ((Rimski_Broj.ProveriRimski(Prvi.Text) == false) && (Rimski_Broj.ProveriRimski(Drugi.Text) == false))
                            {
                                MessageBox.Show("Ni prvi ni drugi broj nisu validni rimski brojevi.");
                            }
                            else if (Rimski_Broj.ProveriRimski(Prvi.Text) == false)
                            {
                                MessageBox.Show("Prvi broj nije validan rimski broj.");
                            }
                            else if (Rimski_Broj.ProveriRimski(Drugi.Text) == false)
                            {
                                MessageBox.Show("Drugi broj nije validan rimski broj.");
                            }
                        }
                        break;
                }
            }
            else
            {
                switch (operacija)
                {
                    case "+":
                        if ((Veliki_Broj.Proveri_Veliki(Prvi_Big.Text) == true) && (Veliki_Broj.Proveri_Veliki(Drugi_Big.Text) == true))
                        {
                            string prvi = Prvi_Big.Text;
                            string drugi = Drugi_Big.Text;
                            string rez = "";
                            if ((prvi[0] == '-') && (drugi[0] == '-'))
                            {
                                prvi = prvi.Substring(1);
                                drugi = drugi.Substring(1);
                                rez = "-" + Veliki_Broj.Saberi(prvi, drugi);                               
                            }
                            else if ((prvi[0] == '-') && (drugi[0] != '-'))
                            {
                                
                            }

                                rez = Veliki_Broj.Saberi(prvi,drugi);
                            Rez_Big.Text = rez;
                        }
                        else
                        {
                            if ((Veliki_Broj.Proveri_Veliki(Prvi_Big.Text) == false) && (Veliki_Broj.Proveri_Veliki(Drugi_Big.Text) == false))
                            {
                                MessageBox.Show("Ni prvi ni drugi broj nisu validni decimalni/celi brojevi.");
                            }
                            else if (Veliki_Broj.Proveri_Veliki(Prvi_Big.Text) == false)
                            {
                                MessageBox.Show("Prvi broj nije validan decimalan/celo broj.");
                            }
                            else if (Veliki_Broj.Proveri_Veliki(Drugi_Big.Text) == false)
                            {
                                MessageBox.Show("Drugi broj nije validan decimalan/celo broj.");
                            }
                        }
                        break;
                    case "-":
                        if ((Veliki_Broj.Proveri_Veliki(Prvi_Big.Text) == true) && (Veliki_Broj.Proveri_Veliki(Drugi_Big.Text) == true))
                        {
                            string prvi = Prvi_Big.Text;
                            string drugi = Drugi_Big.Text;
                            prvi = Veliki_Broj.TrimZerosFromDecimal(prvi);
                            drugi = Veliki_Broj.TrimZerosFromDecimal(drugi);
                            string rez = Veliki_Broj.Oduzmi(prvi, drugi);
                            Rez_Big.Text = rez;
                        }
                        else
                        {
                            if ((Veliki_Broj.Proveri_Veliki(Prvi_Big.Text) == false) && (Veliki_Broj.Proveri_Veliki(Drugi_Big.Text) == false))
                            {
                                MessageBox.Show("Ni prvi ni drugi broj nisu validni decimalni/celi brojevi.");
                            }
                            else if (Veliki_Broj.Proveri_Veliki(Prvi_Big.Text) == false)
                            {
                                MessageBox.Show("Prvi broj nije validan decimalan/celo broj.");
                            }
                            else if (Veliki_Broj.Proveri_Veliki(Drugi_Big.Text) == false)
                            {
                                MessageBox.Show("Drugi broj nije validan decimalan/celo broj.");
                            }
                        }
                        break;
                    case "*":
                        if ((Veliki_Broj.Proveri_Veliki(Prvi_Big.Text) == true) && (Veliki_Broj.Proveri_Veliki(Drugi_Big.Text) == true))
                        {
                            string prvi = Prvi_Big.Text;
                            string drugi = Drugi_Big.Text;
                            string rez = Veliki_Broj.Pomnozi(prvi, drugi);
                            Rez_Big.Text = rez;
                        }
                        else
                        {
                            if ((Veliki_Broj.Proveri_Veliki(Prvi_Big.Text) == false) && (Veliki_Broj.Proveri_Veliki(Drugi_Big.Text) == false))
                            {
                                MessageBox.Show("Ni prvi ni drugi broj nisu validni decimalni/celi brojevi.");
                            }
                            else if (Veliki_Broj.Proveri_Veliki(Prvi_Big.Text) == false)
                            {
                                MessageBox.Show("Prvi broj nije validan decimalan/celo broj.");
                            }
                            else if (Veliki_Broj.Proveri_Veliki(Drugi_Big.Text) == false)
                            {
                                MessageBox.Show("Drugi broj nije validan decimalan/celo broj.");
                            }
                        }
                        break;
                    case "/":
                        if ((Veliki_Broj.Proveri_Veliki(Prvi_Big.Text) == true) && (Veliki_Broj.Proveri_Veliki(Drugi_Big.Text) == true))
                        {

                        }
                        else
                        {
                            if ((Veliki_Broj.Proveri_Veliki(Prvi_Big.Text) == false) && (Veliki_Broj.Proveri_Veliki(Drugi_Big.Text) == false))
                            {
                                MessageBox.Show("Ni prvi ni drugi broj nisu validni decimalni/celi brojevi.");
                            }
                            else if (Veliki_Broj.Proveri_Veliki(Prvi_Big.Text) == false)
                            {
                                MessageBox.Show("Prvi broj nije validan decimalan/celo broj.");
                            }
                            else if (Veliki_Broj.Proveri_Veliki(Drugi_Big.Text) == false)
                            {
                                MessageBox.Show("Drugi broj nije validan decimalan/celo broj.");
                            }
                        }
                        break;
                }
            }
            
        }

        private void Jedan_Click(object sender, EventArgs e)
        {
            if (Prvi_broj_izabran.Checked)
            {
                Prvi_Big.Text = Prvi_Big.Text + "1";
            }
            else if (Drugi_broj_izabran.Checked)
            {
                Drugi_Big.Text = Drugi_Big.Text + "1";
            }
        }

        private void Dva_Click(object sender, EventArgs e)
        {
            if (Prvi_broj_izabran.Checked)
            {
                Prvi_Big.Text = Prvi_Big.Text + "2";
            }
            else if (Drugi_broj_izabran.Checked)
            {
                Drugi_Big.Text = Drugi_Big.Text + "2";
            }
        }

        private void Tri_Click(object sender, EventArgs e)
        {
            if (Prvi_broj_izabran.Checked)
            {
                Prvi_Big.Text = Prvi_Big.Text + "3";
            }
            else if (Drugi_broj_izabran.Checked)
            {
                Drugi_Big.Text = Drugi_Big.Text + "3";
            }
        }

        private void Cetiri_Click(object sender, EventArgs e)
        {
            if (Prvi_broj_izabran.Checked)
            {
                Prvi_Big.Text = Prvi_Big.Text + "4";
            }
            else if (Drugi_broj_izabran.Checked)
            {
                Drugi_Big.Text = Drugi_Big.Text + "4";
            }
        }

        private void Pet_Click(object sender, EventArgs e)
        {
            if (Prvi_broj_izabran.Checked)
            {
                Prvi_Big.Text = Prvi_Big.Text + "5";
            }
            else if (Drugi_broj_izabran.Checked)
            {
                Drugi_Big.Text = Drugi_Big.Text + "5";
            }
        }

        private void Sest_Click(object sender, EventArgs e)
        {
            if (Prvi_broj_izabran.Checked)
            {
                Prvi_Big.Text = Prvi_Big.Text + "6";
            }
            else if (Drugi_broj_izabran.Checked)
            {
                Drugi_Big.Text = Drugi_Big.Text + "6";
            }
        }

        private void Sedam_Click(object sender, EventArgs e)
        {
            if (Prvi_broj_izabran.Checked)
            {
                Prvi_Big.Text = Prvi_Big.Text + "7";
            }
            else if (Drugi_broj_izabran.Checked)
            {
                Drugi_Big.Text = Drugi_Big.Text + "7";
            }
        }

        private void Osam_Click(object sender, EventArgs e)
        {
            if (Prvi_broj_izabran.Checked)
            {
                Prvi_Big.Text = Prvi_Big.Text + "8";
            }
            else if (Drugi_broj_izabran.Checked)
            {
                Drugi_Big.Text = Drugi_Big.Text + "8";
            }
        }

        private void Devet_Click(object sender, EventArgs e)
        {
            if (Prvi_broj_izabran.Checked)
            {
                Prvi_Big.Text = Prvi_Big.Text + "9";
            }
            else if (Drugi_broj_izabran.Checked)
            {
                Drugi_Big.Text = Drugi_Big.Text + "9";
            }
        }

        private void Nula_Click(object sender, EventArgs e)
        {
            if (Prvi_broj_izabran.Checked)
            {
                Prvi_Big.Text = Prvi_Big.Text + "0";
            }
            else if (Drugi_broj_izabran.Checked)
            {
                Drugi_Big.Text = Drugi_Big.Text + "0";
            }
        }

        private void Tacka_Click(object sender, EventArgs e)
        {
            if (Prvi_broj_izabran.Checked)
            {
                Prvi_Big.Text = Prvi_Big.Text + ".";
            }
            else if (Drugi_broj_izabran.Checked)
            {
                Drugi_Big.Text = Drugi_Big.Text + ".";
            }
        }
    }
}

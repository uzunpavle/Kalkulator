using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            Prvi.Text = string.Empty;
            Drugi.Text = string.Empty;
            Rez.Text = string.Empty;
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
    }
}

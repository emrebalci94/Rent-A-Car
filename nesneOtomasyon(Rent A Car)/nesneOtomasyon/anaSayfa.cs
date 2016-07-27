using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
namespace nesneOtomasyon
{
    public partial class anaSayfa : Form
    {
        public anaSayfa()
        {
            InitializeComponent();
        }

        public void liste()
        {
            FileStream akis;
            StreamReader Okuma;
            string Yol = "not.txt";
            akis = new FileStream(Yol, FileMode.Open, FileAccess.Read);
            Okuma = new StreamReader(akis, Encoding.GetEncoding("iso-8859-9"), false);
            textBox1.Text = Okuma.ReadToEnd();
            Okuma.Close();
        }

        private void anaSayfa_Load(object sender, EventArgs e)
        {
            textBox2.Focus();
            liste();
        }

        private void anaSayfa_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            arabaIslemleri a = new arabaIslemleri();
            a.TopLevel = false;
            panel2.Controls.Add(a);
            a.Show();
            a.BringToFront();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            markaIslemleri m = new markaIslemleri();
            m.TopLevel = false;
            panel2.Controls.Add(m);
            m.Show();
            m.BringToFront();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            musteriIslemleri m = new musteriIslemleri();
            m.TopLevel = false;
            panel2.Controls.Add(m);
            m.Show();
            m.BringToFront();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            try
            {
                kiraIslemleri k = new kiraIslemleri();
                k.TopLevel = false;
                panel2.Controls.Add(k);
                k.Show();
                k.BringToFront();
            }
            catch (Exception)
            {

            }
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            faturaIslemleri k = new faturaIslemleri();
            k.TopLevel = false;
            panel2.Controls.Add(k);
            k.Show();
            k.BringToFront();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            sorgulamaIslemleri k = new sorgulamaIslemleri();
            k.TopLevel = false;
            panel2.Controls.Add(k);
            k.Show();
            k.BringToFront();
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            notAl n = new notAl();
            n.ShowDialog();
        }
    }
}

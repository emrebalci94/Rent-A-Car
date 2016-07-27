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
    public partial class notAl : Form
    {
        public notAl()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FileStream akis;
            StreamWriter SW;
            akis = new FileStream("not.txt", FileMode.Truncate, FileAccess.Write);
            SW = new StreamWriter(akis, Encoding.GetEncoding("iso-8859-9"));
            SW.WriteLine(textBox1.Text);
            SW.Close();
            this.Close();
        }

        private void notAl_Load(object sender, EventArgs e)
        {

            FileStream akis;
            StreamReader Okuma;
            string Yol = "not.txt";
            akis = new FileStream(Yol, FileMode.Open, FileAccess.Read);
            Okuma = new StreamReader(akis,Encoding.GetEncoding("iso-8859-9"), false);
            textBox1.Text = Okuma.ReadToEnd();
            Okuma.Close();
        }
    }
}

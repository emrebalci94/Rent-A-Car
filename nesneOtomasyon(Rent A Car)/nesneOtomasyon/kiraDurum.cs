using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace nesneOtomasyon
{
    public partial class kiraDurum : Form
    {
        public kiraDurum()
        {
            InitializeComponent();
        }
        public static bool hasar = false;
        public static DateTime tarih;
        public static bool pesin = false;
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                 hasar = true;
            }
            else
            {
                hasar = false;
            }
           
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            tarih = DateTime.Now;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
            {
                pesin = true;
            }
            else
            {
                pesin = false;
            }
        }
        public static int fiyat;
        private void kiraDurum_Load(object sender, EventArgs e)
        {
            label1.Text = "Ücret:" + fiyat + "TL";
        }
    }
}

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
    public partial class musteriBilgi : Form
    {
        public musteriBilgi()
        {
            InitializeComponent();
        }
        public static int bilgi;
        private void musteriBilgi_Load(object sender, EventArgs e)
        {
            baglantiDataContext b = new baglantiDataContext();
            var a = b.kiras.Where(p => p.kiraNo==bilgi);
            foreach (kira i in a)
            {
                string[] al = { i.musteri.kimlikNo, i.musteri.adSoyad, i.musteri.ehliyetTip, i.musteri.telefon, i.musteri.adres };
                ListViewItem l = new ListViewItem(al);
                listView1.Items.Add(l);
            }
        }

        private void musteriBilgi_MouseCaptureChanged(object sender, EventArgs e)
        {
            //this.Close();
        }
    }
}

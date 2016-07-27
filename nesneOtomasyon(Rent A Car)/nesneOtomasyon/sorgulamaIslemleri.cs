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
    public partial class sorgulamaIslemleri : Form
    {
        public sorgulamaIslemleri()
        {
            InitializeComponent();
        }

        private void enCokKiralananArac()
        {
            listView3.Items.Clear();
            baglantiDataContext b = new baglantiDataContext();
            var veri = from p in b.kiras group p by p.plakaNo into g select new { g.Key, OkunmaSayısı = g.Count() };
            foreach (var i in veri)
            {
                string[] al = { i.Key, i.OkunmaSayısı.ToString()+" Kişi" };
                ListViewItem l = new ListViewItem(al);
                listView3.Items.Add(l);
            }
        }

        private void listele()
        {
            listView1.Items.Clear();
            baglantiDataContext b = new baglantiDataContext();
            var veri = b.kiras.Where(p=> p.durum =="1");
            foreach (kira i in veri)
            {
                string[] al = { i.kiraNo.ToString(), i.plakaNo, i.musteri.adSoyad, i.kiraTarih.ToString(), i.gelisTarih.ToString() };
                ListViewItem l = new ListViewItem(al);
                listView1.Items.Add(l);
            }
        }

        private void gunuGecenKiralar()
        {
            listView2.Items.Clear();
            baglantiDataContext b = new baglantiDataContext();
            var veri = b.kiras.Where(p => p.durum == "1" & p.gelisTarih < DateTime.Now);
            foreach (kira i in veri)
            {
                string[] al = { i.kiraNo.ToString(), i.plakaNo, i.musteri.adSoyad, i.kiraTarih.ToString(), i.gelisTarih.ToString() ,i.musteri.telefon};
                ListViewItem l = new ListViewItem(al);
                listView2.Items.Add(l);
            }    
        }

        private void sorgulamaIslemleri_Load(object sender, EventArgs e)
        {
            listele();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            if (textBox3.Text=="")
            {
                listele();
            }
            else
            {
                baglantiDataContext b = new baglantiDataContext();
                var veri = b.kiras.Where(p => p.durum == "1" && p.kimlikNo==textBox3.Text || p.plakaNo.Contains(textBox3.Text) & p.durum=="1");
                foreach (kira i in veri)
                {
                    string[] al = { i.kiraNo.ToString(), i.plakaNo, i.musteri.adSoyad, i.kiraTarih.ToString(), i.gelisTarih.ToString() };
                    ListViewItem l = new ListViewItem(al);
                    listView1.Items.Add(l);
                }   
            }
        }

        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {
            if (e.TabPageIndex==0)
            {
                this.Width = 555;
                this.Height = 375;
                listele();
            }
            else if (e.TabPageIndex==1)
            {
                this.Width = 635;
                this.Height = 375;
                gunuGecenKiralar();
            }
            else if (e.TabPageIndex==3)
            {
                this.Width = 341;
                this.Height = 375;
                enCokKiralananArac();
            }
            else if (e.TabPageIndex==2)
            {
                this.Width = 630;
                this.Height = 375;
                comboBox1.SelectedIndex = 0;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            listView4.Items.Clear();
            baglantiDataContext b = new baglantiDataContext();
            try
            {
                if (comboBox1.SelectedIndex == 0)
                {
                    var a = b.arabas.Where(p => (p.sigortaTarih >= dateTimePicker1.Value && p.sigortaTarih <= dateTimePicker2.Value) & p.silmeDurum != "1");
                    foreach (araba i in a)
                    {
                        string[] al = { i.plakaNo, i.ruhsatNo, i.sase, i.marka.markaAdi, i.model,i.sigortaTarih.Value.ToShortDateString() };
                        ListViewItem l = new ListViewItem(al);
                        listView4.Items.Add(l);
                    }
                    if (listView4.Items.Count <= 0)
                    {
                        string[] al = { "Verilen", " İki","Tarih", "Arasında", "Araç", "Bulunamadı..." };
                        ListViewItem l = new ListViewItem(al);
                        listView4.Items.Add(l);
                    }
                }
                else if (comboBox1.SelectedIndex == 1)
                {
                    var a = b.arabas.Where(p => (p.kaskoTarih >= dateTimePicker1.Value && p.kaskoTarih <= dateTimePicker2.Value) & p.silmeDurum != "1");
                    foreach (araba i in a)
                    {
                        string[] al = { i.plakaNo, i.ruhsatNo, i.sase, i.marka.markaAdi, i.model, i.kaskoTarih.Value.ToShortDateString() };
                        ListViewItem l = new ListViewItem(al);
                        listView4.Items.Add(l);
                    }
                    if (listView4.Items.Count <= 0)
                    {
                        string[] al = { "Verilen", " İki","Tarih", "Arasında", "Araç", "Bulunamadı..." };
                        ListViewItem l = new ListViewItem(al);
                        listView4.Items.Add(l);
                    }
                }
                else if (comboBox1.SelectedIndex == 2)
                {
                    var a = b.arabas.Where(p => (p.vizeTarih >= dateTimePicker1.Value && p.vizeTarih <= dateTimePicker2.Value) & p.silmeDurum != "1");
                    foreach (araba i in a)
                    {
                        string[] al = { i.plakaNo, i.ruhsatNo, i.sase, i.marka.markaAdi, i.model, i.vizeTarih.Value.ToShortDateString() };
                        ListViewItem l = new ListViewItem(al);
                        listView4.Items.Add(l);
                    }
                    if (listView4.Items.Count <= 0)
                    {
                        string[] al = { "Verilen", " İki","Tarih", "Arasında", "Araç", "Bulunamadı..." };
                        ListViewItem l = new ListViewItem(al);
                        listView4.Items.Add(l);
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Sorgulama Yapılamadı.Lütfen Sonra Bir Daha Deneyin.", "Sorgu Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                musteriBilgi.bilgi = Convert.ToInt16(listView2.SelectedItems[0].SubItems[0].Text);
                musteriBilgi m = new musteriBilgi();
                m.ShowDialog();
            }
            catch (Exception)
            {

            }
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                musteriBilgi.bilgi = Convert.ToInt16(listView1.SelectedItems[0].SubItems[0].Text);
                musteriBilgi m = new musteriBilgi();
                m.ShowDialog();
            }
            catch (Exception)
            {

            }
        }

        private void yazdırToolStripMenuItem_Click(object sender, EventArgs e)
        {
            printDocument1.Print();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Font kocabaslik = new System.Drawing.Font("Arial", 20, FontStyle.Bold);
            Font grupBaslik = new System.Drawing.Font("Arial", 15, FontStyle.Underline);
            Font baslik = new System.Drawing.Font("Arial", 10, FontStyle.Bold);
            Font altbaslik = new System.Drawing.Font("Arial", 12, FontStyle.Regular);
            Font dublealtbaslik = new System.Drawing.Font("Arial", 9, FontStyle.Italic);
            Font uzundublealtbaslik = new System.Drawing.Font("Arial", 7, FontStyle.Underline);
            System.Drawing.Printing.PageSettings sayfa = printDocument1.DefaultPageSettings;
            e.Graphics.DrawString("ULUBORLU", kocabaslik, Brushes.Black, 300, 100);
            e.Graphics.DrawString("Rent a Car", baslik, Brushes.Gold, 380, 130);
            e.Graphics.DrawImage(Image.FromFile("images/logoForm.png"), 580, 100);
            e.Graphics.DrawString("En Çok Kiralanan Araç Listesi", grupBaslik, Brushes.Black, 100, 200);
            e.Graphics.DrawString("Plaka Numarası", baslik, Brushes.Black, 200, 250);
            e.Graphics.DrawString("Kiralayan Kişi Sayısı", baslik, Brushes.Black, 400, 250);
            e.Graphics.DrawLine(new Pen(Color.Black, 2), sayfa.Margins.Left, 280, sayfa.PaperSize.Width - sayfa.Margins.Right, 280);
            int x = 200, y = 300;
            foreach (ListViewItem item in listView3.Items)
            {
                for (int i = 0; i < item.SubItems.Count; i++)
                {
                    e.Graphics.DrawString(item.SubItems[i].Text, altbaslik, Brushes.Black, x, y);
                    x += 200;
                }
                x = 200;
                y += 50;
            }
            e.Graphics.DrawLine(new Pen(Color.Black, 2), sayfa.Margins.Left, y+30, sayfa.PaperSize.Width - sayfa.Margins.Right, y+30);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (comboBox1.SelectedIndex == 0)
                {
                    listView4.Columns[5].Text = "Sigorta Tarihi";
                }
                else if (comboBox1.SelectedIndex == 1)
                {
                    listView4.Columns[5].Text = "Kasko Tarihi";
                }
                else if (comboBox1.SelectedIndex == 2)
                {
                    listView4.Columns[5].Text = "Vize Tarihi";
                }
            }
            catch (Exception)
            {

            }
        }
    }
}

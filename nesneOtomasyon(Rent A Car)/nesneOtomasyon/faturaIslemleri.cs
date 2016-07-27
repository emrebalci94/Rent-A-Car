using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Printing;

namespace nesneOtomasyon
{
    public partial class faturaIslemleri : Form
    {
        public faturaIslemleri()
        {
            InitializeComponent();
        }
        private void listele()
        {
            listView1.Items.Clear();
            baglantiDataContext b = new baglantiDataContext();
            var veri = b.odemes;
            foreach (odeme i in veri)
            {
                string[] al = { i.kiraNo.ToString(), i.odemeNo.ToString(),i.musteri.adSoyad , i.musteri.telefon, i.odemeTutar.ToString()+" TL" };
                ListViewItem l = new ListViewItem(al);
                listView1.Items.Add(l);
            }
            if (listView1.Items.Count < 1)
            {
                MessageBox.Show("Kira Süresi Bitmiş Bir Araç Bulunmamaktadır...", "Fatura Uyarı ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }
        private void faturaIslemleri_Load(object sender, EventArgs e)
        {
            listele();
        }

        private void tümünüListeleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listele();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            if (textBox3.Text == "")
            {
                listele();
            }
            else
            {
                baglantiDataContext b = new baglantiDataContext();
                var veri = b.odemes.Where(p=> p.musteri.adSoyad.Contains(textBox3.Text) | p.kiraNo.ToString()==textBox3.Text);
                foreach (odeme i in veri)
                {
                    string[] al = { i.kiraNo.ToString(), i.odemeNo.ToString(), i.musteri.adSoyad, i.musteri.telefon, i.odemeTutar.ToString() + " TL" };
                    ListViewItem l = new ListViewItem(al);
                    listView1.Items.Add(l);
                }
            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            baglantiDataContext b=new baglantiDataContext();
            TimeSpan toplamGun;
            double gun;
            kira k= b.kiras.First(p=> p.kiraNo==Convert.ToInt16(listView1.SelectedItems[0].SubItems[0].Text));
            odeme o=b.odemes.First(p=> p.odemeNo==Convert.ToInt16(listView1.SelectedItems[0].SubItems[1].Text));
            Font kocabaslik = new System.Drawing.Font("Arial", 20, FontStyle.Bold);
            Font grupBaslik = new System.Drawing.Font("Arial", 15, FontStyle.Underline);
            Font baslik = new System.Drawing.Font("Arial", 10, FontStyle.Bold);
            Font altbaslik = new System.Drawing.Font("Arial", 12, FontStyle.Regular);
            Font dublealtbaslik = new System.Drawing.Font("Arial", 9, FontStyle.Italic);
            Font uzundublealtbaslik = new System.Drawing.Font("Arial", 7, FontStyle.Underline);
            System.Drawing.Printing.PageSettings sayfa = printDocument1.DefaultPageSettings;
            e.Graphics.DrawImage(Image.FromFile("images/logoForm.png"),580,40);
            e.Graphics.DrawImage(Image.FromFile("images/muhur2.png"), 580, 240);
            e.Graphics.DrawImage(Image.FromFile("images/mb.png"), 350, 400);
            e.Graphics.DrawString("Fatura Numarası:", baslik, Brushes.Black, 550, 180);
            e.Graphics.DrawString(listView1.SelectedItems[0].SubItems[1].Text, altbaslik, Brushes.Black, 680, 175);
            e.Graphics.DrawString("Kira Numarası:", baslik, Brushes.Black, 550, 200);
            e.Graphics.DrawString(k.kiraNo.ToString(), altbaslik, Brushes.Black, 650, 200);
            e.Graphics.DrawString("Ödeme Şekli:", baslik, Brushes.Black, 550, 220);
            if (o.odemeSekli=='1')
            {
                e.Graphics.DrawString("Peşin", altbaslik, Brushes.Black, 650, 220);  
            }
            else
            {
                e.Graphics.DrawString("Kredi Kartı", altbaslik, Brushes.Black, 650, 220);  
            }
            
            e.Graphics.DrawString("ULUBORLU", kocabaslik, Brushes.Black, 300, 20);
            e.Graphics.DrawString("Rent a Car", baslik, Brushes.Gold, 380, 50);
            e.Graphics.DrawString("Fatura Tarihi:", altbaslik, Brushes.Black, 100, 580);          
            e.Graphics.DrawString(DateTime.Now.ToShortDateString() + "-" + DateTime.Now.ToLongTimeString(), altbaslik, Brushes.Black, 250,580 );
            e.Graphics.DrawString("Müşteri Bilgileri",grupBaslik,Brushes.Black,75,175);
            e.Graphics.DrawString("Müşteri Kimlik Numarası:",baslik,Brushes.Black,50,210);
            e.Graphics.DrawString(k.musteri.kimlikNo, altbaslik, Brushes.Black, 225, 208);
            e.Graphics.DrawString("Müşteri Ad Soyad:", baslik, Brushes.Black, 50, 230);
            e.Graphics.DrawString(k.musteri.adSoyad, altbaslik, Brushes.Black, 175, 228);
            e.Graphics.DrawString("Müşteri Telefon:", baslik, Brushes.Black, 50, 250);
            e.Graphics.DrawString(k.musteri.telefon, altbaslik, Brushes.Black, 165, 248);
            e.Graphics.DrawString("Araç Bilgileri", grupBaslik, Brushes.Black, 75, 300);
            e.Graphics.DrawString("Araç Plaka Numarası:", baslik, Brushes.Black, 50, 330);
            e.Graphics.DrawString(k.araba.plakaNo, altbaslik, Brushes.Black, 200, 328);
            e.Graphics.DrawString("Araç Marka Adı:", baslik, Brushes.Black, 50, 350);
            e.Graphics.DrawString(k.araba.marka.markaAdi, altbaslik, Brushes.Black, 160, 348);
            e.Graphics.DrawString("Araç Tipi:", baslik, Brushes.Black, 50, 370);
            e.Graphics.DrawString(k.araba.cins, altbaslik, Brushes.Black, 130, 368);
            e.Graphics.DrawLine(new Pen(Color.Black, 2), sayfa.Margins.Left, 125, sayfa.PaperSize.Width - sayfa.Margins.Right, 125);
            e.Graphics.DrawLine(new Pen(Color.Black, 2), sayfa.Margins.Left, 420, sayfa.PaperSize.Width - sayfa.Margins.Right, 420);
            e.Graphics.DrawLine(new Pen(Color.Black, 2), sayfa.Margins.Left, 470, sayfa.PaperSize.Width - sayfa.Margins.Right, 470);
            e.Graphics.DrawString("Kira No", baslik, Brushes.Black, 10, 450);
            e.Graphics.DrawString(k.kiraNo.ToString(), altbaslik, Brushes.Black, 10, 480);
            e.Graphics.DrawString("Plaka No", baslik, Brushes.Black, 100, 450);
            e.Graphics.DrawString(k.plakaNo, altbaslik, Brushes.Black, 100, 480);
            e.Graphics.DrawString("Ad Soyad", baslik, Brushes.Black, 200, 450);
            e.Graphics.DrawString(k.musteri.adSoyad, altbaslik, Brushes.Black, 200, 480);
            e.Graphics.DrawString("Kira Veriliş Tarih", baslik, Brushes.Black, 300, 450);
            e.Graphics.DrawString(k.kiraTarih.Value.ToShortDateString(), altbaslik, Brushes.Black, 300, 480);
            e.Graphics.DrawString("Kira Bitiş Tarih", baslik, Brushes.Black, 450, 450);
            e.Graphics.DrawString(k.gelisTarih.Value.ToShortDateString(), altbaslik, Brushes.Black, 450, 480);
            e.Graphics.DrawString("Gün Başına Ücret", baslik, Brushes.Black, 600, 450);
            e.Graphics.DrawString("150 TL", altbaslik, Brushes.Black, 600, 480);
            e.Graphics.DrawLine(new Pen(Color.Black, 2), sayfa.Margins.Left, 500, sayfa.PaperSize.Width - sayfa.Margins.Right, 500);
            e.Graphics.DrawString("Kiralanan Gün Sayısı:", altbaslik, Brushes.Black, 100, 520);
            toplamGun = k.gelisTarih.Value - k.kiraTarih.Value;
            gun = toplamGun.TotalDays + 1;
            e.Graphics.DrawString(gun.ToString()+" Gün", altbaslik, Brushes.Black, 280, 520);
            e.Graphics.DrawString("Toplam Kira Fiyatı:", altbaslik, Brushes.Black, 100, 540);
            e.Graphics.DrawString((gun * 150).ToString()+" TL", altbaslik, Brushes.Black, 250, 540);
            e.Graphics.DrawString("Ödenecek Tutar:", altbaslik, Brushes.Black, 100, 560);
            e.Graphics.DrawString(((gun*150)+(gun * 150)*0.20).ToString()+" TL", altbaslik, Brushes.Black, 250, 560);
            e.Graphics.DrawLine(new Pen(Color.Black, 2), sayfa.Margins.Left, 620, sayfa.PaperSize.Width - sayfa.Margins.Right, 620);
            e.Graphics.DrawString("Not:Ücretlendirmemizde %20 KDV Bulunmaktadır...",dublealtbaslik, Brushes.Black, 100, 650);

        }

        private void faturaKesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            printDocument1.Print();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

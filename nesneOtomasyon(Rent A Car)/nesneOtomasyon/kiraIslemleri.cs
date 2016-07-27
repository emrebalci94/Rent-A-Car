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
    public partial class kiraIslemleri : Form
    {
        public kiraIslemleri()
        {
            InitializeComponent();
        }
        private void aracKira()
        {
            baglantiDataContext b = new baglantiDataContext();
            comboBox1.DataSource = b.arabas.Where(p => p.silmeDurum != "1");
            comboBox1.DisplayMember = "plakaNo";
            comboBox1.ValueMember = "plakaNo";

            comboBox2.DataSource = b.musteris.Where(p => p.silmeDurumu != "1");
            comboBox2.DisplayMember = "adSoyad";
            comboBox2.ValueMember = "kimlikNo";

            if (comboBox1.Items.Count <= 0)
            {
                DialogResult sonuc = MessageBox.Show("Hiç Aracınız Bulunmamakta. Lütfen Önce Araç Bilgilerini Giriniz. Araç İşlemlerine Gidilsin mi ?", "Araç Bilgileri ?", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (sonuc == DialogResult.Yes)
                {
                    arabaIslemleri a = new arabaIslemleri();
                    this.Close();
                    a.ShowDialog();

                }
                else
                {
                    this.Close();
                }
            }
            else if (comboBox2.Items.Count <= 0)
            {
                DialogResult sonuc = MessageBox.Show("Hiç Müşteriniz Bulunmamakta. Lütfen Önce Müşteri Bilgilerini Giriniz. Müşteri İşlemlerine Gidilsin mi ?", "Müşteri Bilgileri ?", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (sonuc == DialogResult.Yes)
                {
                    musteriIslemleri m = new musteriIslemleri();
                    this.Close();
                    m.ShowDialog();
                }
                else
                {
                    this.Close();
                }
            }
        }
        private void kiraIslemleri_Load(object sender, EventArgs e)
        {
            baglantiDataContext b = new baglantiDataContext();
            comboBox1.DataSource = b.arabas.Where(p => p.silmeDurum != "1");
            comboBox1.DisplayMember = "plakaNo";
            comboBox1.ValueMember = "plakaNo";

            comboBox2.DataSource = b.musteris.Where(p => p.silmeDurumu != "1");
            comboBox2.DisplayMember = "adSoyad";
            comboBox2.ValueMember = "kimlikNo";

            if (comboBox1.Items.Count<=0)
            {
               DialogResult sonuc = MessageBox.Show("Hiç Aracınız Bulunmamakta. Lütfen Önce Araç Bilgilerini Giriniz. Araç İşlemlerine Gidilsin mi ?", "Araç Bilgileri ?", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
               if (sonuc == DialogResult.Yes)
               {
                   arabaIslemleri a = new arabaIslemleri();
                   this.Close();
                   a.ShowDialog();
                 
               }
               else
               {
                   this.Close();
               }
            }
            else if(comboBox2.Items.Count<=0)
            {
                DialogResult sonuc = MessageBox.Show("Hiç Müşteriniz Bulunmamakta. Lütfen Önce Müşteri Bilgilerini Giriniz. Müşteri İşlemlerine Gidilsin mi ?", "Müşteri Bilgileri ?", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (sonuc == DialogResult.Yes)
                {
                    musteriIslemleri m = new musteriIslemleri();
                    this.Close();
                    m.ShowDialog();
                }
                else
                {
                    this.Close();
                }
            }
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            baglantiDataContext dc = new baglantiDataContext();
            AutoCompleteStringCollection namesCollection = new AutoCompleteStringCollection();
            var query = from c in dc.arabas.Where(p=> p.silmeDurum !="1")
                        select c.plakaNo;
            foreach (String comp in query)
            {
                namesCollection.Add(comp);
            }
            textBox1.AutoCompleteSource = AutoCompleteSource.CustomSource;
            textBox1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            textBox1.AutoCompleteCustomSource = namesCollection;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text !="")
            {
                if (comboBox1.FindString(textBox1.Text) > -1)
                {
                    comboBox1.SelectedIndex = comboBox1.FindStringExact(textBox1.Text);

                } 
            }
        }

        
        private void button2_Click(object sender, EventArgs e)
        {
            musteriSecim.durum = "kira";
            musteriSecim m = new musteriSecim();
            m.ShowDialog();
        }
        int id;
        private void button3_Click(object sender, EventArgs e)
        {
            baglantiDataContext b = new baglantiDataContext();
            kira bak = new kira();
            try
            {
                bak = b.kiras.First(p => p.plakaNo == comboBox1.SelectedValue && p.durum == "1");
            }
            catch (Exception)
            {

            }
            if (bak.durum == "0" || bak.durum == null)
            {
                DialogResult sonuc = MessageBox.Show(comboBox1.Text + " Plakalı Araç " + comboBox2.Text + " Adlı Müşteriye Kiralansın mı ?", "Kira Uyarı ", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (sonuc == DialogResult.Yes)
                {
                    kira k = new kira();
                    k.plakaNo = comboBox1.SelectedValue.ToString();
                    k.kimlikNo = comboBox2.SelectedValue.ToString();
                    k.kiraTarih = dateTimePicker1.Value;
                    k.gelisTarih = dateTimePicker2.Value;
                    k.durum = "1";
                    b.kiras.InsertOnSubmit(k);
                    b.SubmitChanges();
                    id = k.kiraNo;
                    printDocument1.Print();
                    MessageBox.Show("Araç Başarıyla Kiralandı...", "Kira Uyarı ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    comboBox1.SelectedIndex = 0;
                    comboBox2.SelectedIndex = 0;
                    dateTimePicker1.Value = DateTime.Now;
                    dateTimePicker2.Value = DateTime.Now;
                }

            }
            else
            {
                MessageBox.Show("Bu Araç Zaten Kiralandı...", "Kira Uyarı ", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        

              }
            
         
      
        private void aracDonus()
        {
            listView1.Items.Clear();
            baglantiDataContext b = new baglantiDataContext();
            var veri = b.kiras.Where(p => p.durum == "1" && p.araba.silmeDurum!="1");
            foreach (kira i in veri)
            {
                string[] al = {i.kiraNo.ToString(), i.plakaNo, i.musteri.adSoyad, i.kiraTarih.ToString(), i.gelisTarih.ToString() };
                ListViewItem l = new ListViewItem(al);
                listView1.Items.Add(l);
            }
            if (listView1.Items.Count <1)
            {
                MessageBox.Show("Kirada Aracınız Bulunmamakta...", "Kira Uyarı ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tabControl1.SelectedIndex = 0;
            }
        }

        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {
            if (e.TabPageIndex==0)
            {
            //    this.Height = 227;
            //    this.Width = 505;
                aracKira();
            }
            else if (e.TabPageIndex==1)
            {
                //this.Height = 316;
                //this.Width = 535;
                aracDonus();
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            if (textBox3.Text=="")
            {
                aracDonus();
            }
            else 
            {
                baglantiDataContext b = new baglantiDataContext();
                var veri = b.kiras.Where(p => p.durum == "1" && p.plakaNo==textBox3.Text || p.durum == "1" && p.musteri.adSoyad.Contains(textBox3.Text));
                foreach (kira i in veri)
                {
                    string[] al = {i.kiraNo.ToString(), i.plakaNo, i.musteri.adSoyad, i.kiraTarih.ToString(), i.gelisTarih.ToString() };
                    ListViewItem l = new ListViewItem(al);
                    listView1.Items.Add(l);
                }
            }
        }

        private void listeleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            aracDonus();
        }

        private void aracıKiradanAlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            baglantiDataContext b = new baglantiDataContext();
            TimeSpan toplamGun;
            double gun;
            odeme o = new odeme();
           

            kira al = b.kiras.First(p => p.kiraNo==Convert.ToInt16(listView1.SelectedItems[0].SubItems[0].Text));
               DialogResult sonuc = MessageBox.Show("Araç Kiradan Alınsın mı ?", "Kira Uyarı ", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
               if (sonuc == DialogResult.Yes)
               {
                   kiraDurum k = new kiraDurum();
                   toplamGun = al.gelisTarih.Value - al.kiraTarih.Value;
                   gun = toplamGun.TotalDays + 1;
                   kiraDurum.fiyat = (int)(gun * 150) + (int)(gun * 150 * 0.20);
                   k.ShowDialog();
                   if (kiraDurum.hasar == true)
                   {
                       al.hasarDurum = "1";
                   }
                   else
                   {
                       al.hasarDurum = "0";
                   }
                   if (kiraDurum.tarih!=Convert.ToDateTime("01.01.01"))
                   {
                       al.gelisTarih = DateTime.Now;
                   }
                   al.durum = "0";
                   b.SubmitChanges();

                   o.kiraNo = al.kiraNo;
                   o.kimlikNo = al.kimlikNo;
                
                   o.odemeTutar = (int)(gun*150)+(int)(gun * 150 * 0.20);
                   if (kiraDurum.pesin==true)
                   {
                       o.odemeSekli = '1';
                   }
                   else
                   {
                       o.odemeSekli = '0';
                   }

                   b.odemes.InsertOnSubmit(o);
                   b.SubmitChanges();

                   aracDonus();
                 
               }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            baglantiDataContext b = new baglantiDataContext();
            kira k=b.kiras.First(p=> p.kiraNo==id);
            Font kocabaslik = new System.Drawing.Font("Arial", 20, FontStyle.Bold);
            Font grupBaslik = new System.Drawing.Font("Arial", 15, FontStyle.Underline);
            Font baslik = new System.Drawing.Font("Arial", 10, FontStyle.Bold);
            Font altbaslik = new System.Drawing.Font("Arial", 12, FontStyle.Regular);
            Font dublealtbaslik = new System.Drawing.Font("Arial", 9, FontStyle.Italic);
            Font uzundublealtbaslik = new System.Drawing.Font("Arial", 7, FontStyle.Underline);
            System.Drawing.Printing.PageSettings sayfa = printDocument1.DefaultPageSettings;
            e.Graphics.DrawImage(Image.FromFile("images/muhur2.png"), 300, 300);
            e.Graphics.DrawString("ULUBORLU", kocabaslik, Brushes.Black, 300, 100);
            e.Graphics.DrawString("Rent a Car", baslik, Brushes.Gold, 380, 130);
            e.Graphics.DrawString(k.kiraNo.ToString()+" kira numaralı "+k.plakaNo+" plakalı araç "+k.musteri.adSoyad+" adlı müşteriye "+DateTime.Now.ToShortDateString()+" tarihinde kiralanmıştır.", altbaslik, Brushes.Black, 20, 250);
            e.Graphics.DrawString("Kira Bilgileri", grupBaslik, Brushes.Black, 70, 280);
            e.Graphics.DrawString("Kira Numarası: "+k.kiraNo, baslik, Brushes.Black, 70, 320);
            e.Graphics.DrawString("Plaka Numarası: "+k.plakaNo, baslik, Brushes.Black, 70, 340);   
            e.Graphics.DrawString("Kira Tarihi: "+k.kiraTarih.Value.ToShortDateString(), baslik, Brushes.Black, 70, 360);
            e.Graphics.DrawString("Dönüş Tarihi: " + k.gelisTarih.Value.ToShortDateString(), baslik, Brushes.Black, 70, 380);
            e.Graphics.DrawImage(Image.FromFile("images/logoForm.png"), 580, 100);
            e.Graphics.DrawString("Not:Geliş Tarihinden Geç Gelmesi Durumunda Ücrete %50 Ceza Uygulanmaktadır...", dublealtbaslik, Brushes.Black, 100, 450);

        }
   }
}


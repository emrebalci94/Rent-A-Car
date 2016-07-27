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
    public partial class arabaIslemleri : Form
    {
        public arabaIslemleri()
        {
            InitializeComponent();
        }
     
       private void markaListele()
        {
            baglantiDataContext b = new baglantiDataContext();
            comboBox1.DataSource = b.markas;
            comboBox1.DisplayMember = "markaAdi";
            comboBox1.ValueMember = "markaNo";
            comboBox1.SelectedValue = 2;
        }

        private void arabaIslemleri_Load(object sender, EventArgs e)
        {
            markaListele();
            comboBox2.SelectedIndex = 0;
            comboBox3.SelectedIndex = 0;
        }


        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

            this.Height = 410;
            this.Width = 660;
  
            
        }

        private void plakaListeGuncelle()
        {
            try
            {
                baglantiDataContext b = new baglantiDataContext();
                comboBox4.DataSource = b.arabas.Where(p => p.silmeDurum != "1");
                comboBox4.DisplayMember = "plakaNo";
                comboBox4.ValueMember = "plakaNo";
            }
            catch (Exception)
            {
                comboBox4.Enabled = false; 
            }
        }

        private void plakaListeSil()
        {
            try
            {
                baglantiDataContext b = new baglantiDataContext();
                comboBox8.DataSource = b.arabas.Where(p=> p.silmeDurum !="1");
                comboBox8.DisplayMember = "plakaNo";
                comboBox8.ValueMember = "plakaNo";
            }
            catch (Exception)
            {
                comboBox8.Enabled = false;
            }
        }
        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {
            
            if (e.TabPageIndex==1)
            {
                this.Height = 110;
                this.Width = 450;
                plakaListeGuncelle();
            }
            else if (e.TabPageIndex==0)
            {
                this.Height = 330;
                this.Width = 630;
            }
            else if (e.TabPageIndex==2)
            {
                this.Width = 600;
                this.Height = 120;
                plakaListeSil();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text.Length==6 && textBox10.Text.Length ==4 && textBox4.Text.Length==20 && textBox3.Text.Length==15)
            {
               
                try
                {
                    DialogResult sonuc = MessageBox.Show("Verileriniz Kayıt Edilsin mi ?", "Kayıt Eklensin mi?", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (sonuc==DialogResult.Yes)
                    {
                        baglantiDataContext b = new baglantiDataContext();
                        araba a = new araba();
                        a.plakaNo = textBox1.Text;
                        a.ruhsatNo = textBox2.Text;
                        a.cins = comboBox3.Text;
                        a.markaNo = Convert.ToInt16(comboBox1.SelectedValue);
                        a.model = textBox10.Text;
                        a.yakit = comboBox2.Text;
                        a.sase = textBox4.Text;
                        a.sigortaTarih = dateTimePicker1.Value;
                        a.kaskoTarih = dateTimePicker2.Value;
                        a.vizeTarih = dateTimePicker3.Value;
                        a.band = textBox3.Text;
                        a.aciklama = textBox5.Text;
                        a.silmeDurum = "0";
                        b.arabas.InsertOnSubmit(a);
                        b.SubmitChanges();
                        textBox1.Clear();
                        textBox2.Clear();
                        comboBox3.SelectedIndex = 0;
                        comboBox1.SelectedIndex = 1;
                        textBox10.Clear();
                        comboBox3.SelectedIndex = 0;
                        textBox4.Clear();
                        textBox3.Clear();
                        textBox5.Clear();
                        dateTimePicker1.Value = DateTime.Now;
                        dateTimePicker2.Value = DateTime.Now;
                        dateTimePicker3.Value = DateTime.Now;
                        MessageBox.Show("Verileriniz Başarılı Bir Şekilde Kayıt Edildi.", "Kayıt Sonuç", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }

                }
                catch (Exception h)
                {
                    if (h.HResult==-2146232060)//PlakoNo Aynı ise
                    {
                      MessageBox.Show("Böyle Bir Plaka Zaten Bulunmaktadır.","Kayıt Uyarı",MessageBoxButtons.OK,MessageBoxIcon.Error);  
                    }
                    else
                    {
                        MessageBox.Show("Program Bir Hata İle Karşılaştı. Lütfen Bilgilerinizin Doğrulundan Emin Olun." , "Kayıt Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);                        
                    }
                }
            }
            else
            {
                
                MessageBox.Show("Lütfen Araç Bilgilerini Eksiksiz Doldurunuz.","Kayıt Uyarı",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }


        private void comboBox1_DropDownClosed(object sender, EventArgs e)
        {
            if (comboBox1.Text == "...")
            {
                DialogResult sonuc = MessageBox.Show("Yeni Marka Ekle ?", "Marka İşlemleri ?", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (sonuc == DialogResult.Yes)
                {
                    string markaGiris = Microsoft.VisualBasic.Interaction.InputBox("Lütfen Marka Adını Giriniz:(Örn:AUDI)", "Marka Girişi", "", 100, 100);

                    if (markaGiris != "")
                    {
                        baglantiDataContext b = new baglantiDataContext();
                        marka t = new marka();
                        t.markaAdi = markaGiris.ToUpper() ;
                        b.markas.InsertOnSubmit(t);
                        b.SubmitChanges();
                        MessageBox.Show("Marka Ekleme Başarılı", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        markaListele();
                    }
                    else
                    {
                        MessageBox.Show("Lütfen Gerçeli Bir Marka Adı Giriniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        comboBox1.SelectedValue = 2;
                    }

                }
                else
                {
                    comboBox1.SelectedIndex = 1;
                }
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text.Length < 6)
            {
                textBox2.BackColor = Color.DarkRed;
                textBox2.ForeColor = Color.White;
            }
            else
            {
                textBox2.BackColor = Color.White;
                textBox2.ForeColor = Color.Black;
            }
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {
            if (textBox10.Text.Length < 4)
            {
                textBox10.BackColor = Color.DarkRed;
                textBox10.ForeColor = Color.White;
            }
            else
            {
                textBox10.BackColor = Color.White;
                textBox10.ForeColor = Color.Black;
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if (textBox4.Text.Length < 20)
            {
                textBox4.BackColor = Color.DarkRed;
                textBox4.ForeColor = Color.White;
            }
            else
            {
                textBox4.BackColor = Color.White;
                textBox4.ForeColor = Color.Black;
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (textBox3.Text.Length < 15)
            {
                textBox3.BackColor = Color.DarkRed;
                textBox3.ForeColor = Color.White;
            }
            else
            {
                textBox3.BackColor = Color.White;
                textBox3.ForeColor = Color.Black;
            }
        }

        private void comboBox4_ValueMemberChanged(object sender, EventArgs e)
        {
            try
            {

                baglantiDataContext b = new baglantiDataContext();
                araba a = b.arabas.First(p => p.plakaNo == comboBox4.SelectedValue.ToString());
                textBox9.Text = a.ruhsatNo;
                comboBox5.Text = a.cins;
                textBox11.Text = a.model;
                comboBox6.Text = a.yakit;
                textBox7.Text = a.sase;
                comboBox7.DataSource = b.markas;
                comboBox7.DisplayMember = "markaAdi";
                comboBox7.ValueMember = "markaNo";
                marka m = b.markas.First(p => p.markaNo == a.markaNo);
                comboBox7.Text = m.markaAdi;
                dateTimePicker6.Value = a.sigortaTarih.Value;
                dateTimePicker5.Value = a.kaskoTarih.Value;
                dateTimePicker4.Value = a.vizeTarih.Value;
                textBox8.Text = a.band;
                textBox6.Text = a.aciklama;
            }
            catch (Exception)
            {

            }
        }

        private void textBox12_Click(object sender, EventArgs e)
        {
            baglantiDataContext dc = new baglantiDataContext();
            AutoCompleteStringCollection namesCollection = new AutoCompleteStringCollection();
            var query = from c in dc.arabas.Where(p=> p.silmeDurum!="1")
                        select c.plakaNo;
            foreach (String comp in query)
            {
                namesCollection.Add(comp);
            }
            textBox12.AutoCompleteSource = AutoCompleteSource.CustomSource;
            textBox12.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            textBox12.AutoCompleteCustomSource = namesCollection;
        }
  

        private void button4_Click(object sender, EventArgs e)
        {
                if (comboBox4.FindString(textBox12.Text) > -1 && textBox12.Text !="") 
                {
                    comboBox4.SelectedIndex = comboBox4.FindStringExact(textBox12.Text) ;
                }
           
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            if (textBox9.Text.Length<6)
            {
                textBox9.BackColor = Color.DarkRed;
                textBox9.ForeColor = Color.White;
            }
            else
            {
                textBox9.BackColor = Color.White;
                textBox9.ForeColor = Color.Black;
            }
        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {
            if (textBox11.Text.Length<4)
            {
                 textBox11.BackColor = Color.DarkRed;
                textBox11.ForeColor = Color.White;
            }
            else
            {
                textBox11.BackColor = Color.White;
                textBox11.ForeColor = Color.Black;
            }
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            if (textBox7.Text.Length<20)
            {
                 textBox7.BackColor = Color.DarkRed;
                textBox7.ForeColor = Color.White;
            }
            else
            {
                textBox7.BackColor = Color.White;
                textBox7.ForeColor = Color.Black;
            }
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            if (textBox8.Text.Length<15)
            {
                 textBox8.BackColor = Color.DarkRed;
                textBox8.ForeColor = Color.White;
            }
            else
            {
                textBox8.BackColor = Color.White;
                textBox8.ForeColor = Color.Black;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox8.Text.Length==15 && textBox7.Text.Length==20 && textBox11.Text.Length==4 && textBox9.Text.Length==6)
            {
                try
                {
                   DialogResult sonuc = MessageBox.Show("Bilgileriniz Güncellensin mi ?", "Güncelleme Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                   if (sonuc == DialogResult.Yes)
                   {
                       baglantiDataContext b = new baglantiDataContext();
                       araba a = b.arabas.First(p => p.plakaNo == comboBox4.SelectedValue);
                       a.ruhsatNo = textBox9.Text;
                       a.markaNo = Convert.ToInt16(comboBox7.SelectedValue);
                       a.model = textBox11.Text;
                       a.cins = comboBox5.Text;
                       a.yakit = comboBox6.Text;
                       a.sase = textBox7.Text;
                       a.sigortaTarih = dateTimePicker6.Value;
                       a.kaskoTarih = dateTimePicker5.Value;
                       a.vizeTarih = dateTimePicker4.Value;
                       a.band = textBox8.Text;
                       a.aciklama = textBox6.Text;
                       b.SubmitChanges();
                       MessageBox.Show("Bilgileriniz Başarı İle Güncellenmiştir.", "Güncelleme Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                   }
                }
                catch (Exception)
                {
                    MessageBox.Show("Güncelleme Başarısız. Lütfen Bilgilerinizi Kontrol Edip Tekrar Deneyin.", "Güncelleme Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);                    
                }
            }
            else
            {
                MessageBox.Show("Lütfen Araç Bilgilerini Eksiksiz Doldurunuz.", "Güncelleme Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
             DialogResult sonuc = MessageBox.Show("Araç Silinsin mi ?", "Sil Uyarı ?", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
             if (sonuc == DialogResult.Yes)
             {
                 try
                 {
                     baglantiDataContext b = new baglantiDataContext();                
                     araba a = b.arabas.First(p => p.plakaNo == comboBox8.SelectedValue);
                     a.silmeDurum = "1";
                     b.SubmitChanges();
                     textBox13.Clear();
                     plakaListeSil();
                 }
                 catch (Exception)
                 {

                     MessageBox.Show("Plakaya Ait Araç Bulunamadı.Lütfen Plakayı Düzgün Girdiğinizden Emin Olun.", "Silme Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
                 }
             }
        }

        private void textBox13_Click(object sender, EventArgs e)
        {
            baglantiDataContext dc = new baglantiDataContext();
            AutoCompleteStringCollection namesCollection = new AutoCompleteStringCollection();
            var query = from c in dc.arabas.Where(p => p.silmeDurum != "1")
                        select c.plakaNo;
            foreach (String comp in query)
            {
                namesCollection.Add(comp);
            }
            textBox13.AutoCompleteSource = AutoCompleteSource.CustomSource;
            textBox13.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            textBox13.AutoCompleteCustomSource = namesCollection;
        }


    }
}

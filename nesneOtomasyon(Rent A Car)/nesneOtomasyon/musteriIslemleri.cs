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
    public partial class musteriIslemleri : Form
    {
        public musteriIslemleri()
        {
            InitializeComponent();
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void textBox1_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length==11 && textBox2.Text != "" && textBox5.Text!="" && textBox6.Text.Length==5)
            {
                try
                {
                    DialogResult sonuc = MessageBox.Show("Verileriniz Kayıt Edilsin mi ?", "Kayıt Eklensin mi?", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (sonuc == DialogResult.Yes)
                    {
                        baglantiDataContext b = new baglantiDataContext();
                        musteri m = new musteri();
                        m.kimlikNo = textBox1.Text;
                        m.adSoyad = textBox2.Text;
                        m.dogumTarih = dateTimePicker1.Value;
                        m.adres = textBox3.Text;
                        m.email = textBox4.Text;
                        m.babaAdi = textBox5.Text;
                        m.kanGrup = comboBox1.Text;
                        m.ehliyetNo = textBox6.Text;
                        m.ehliyetTip = comboBox2.Text;
                        m.ehliyetTarih = dateTimePicker2.Value;
                        m.telefon = maskedTextBox1.Text;
                        m.silmeDurumu = "0";
                        b.musteris.InsertOnSubmit(m);
                        b.SubmitChanges();
                        MessageBox.Show("Verileriniz Başarı İle Kayıt Edildi", "Kayıt Başarı", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        textBox6.Clear();
                        textBox5.Clear();
                        textBox4.Clear();
                        textBox3.Clear();
                        textBox2.Clear();
                        textBox1.Clear();
                        maskedTextBox1.Clear();
                        comboBox1.SelectedIndex = 0;
                        comboBox2.SelectedIndex = 0;
                        dateTimePicker1.Value = DateTime.Now;
                        dateTimePicker2.Value = DateTime.Now;
                    }
                }
                catch (Exception h)
                {
                    if (h.HResult==-2146232060)
                    {
                        MessageBox.Show("Böyle Bir Müşteri Zaten Bulunmakta.", "Müşteri Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);                        
                    }
                    else
                    {
                        MessageBox.Show("Program Bir Hata İle Karşılaştı. Lütfen Bilgilerinizin Doğrulundan Emin Olun.", "Müşteri Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Lütfen Müşteri Bilgilerini Eksiksiz Doldurunuz.", "Müşteri Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text.Length < 11)
            {
                textBox1.BackColor = Color.DarkRed;
                textBox1.ForeColor = Color.White;
            }
            else
            {
                textBox1.BackColor = Color.White;
                textBox1.ForeColor = Color.Black;
            }
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            if (textBox6.Text.Length < 5)
            {
                textBox6.BackColor = Color.DarkRed;
                textBox6.ForeColor = Color.White;
            }
            else
            {
                textBox6.BackColor = Color.White;
                textBox6.ForeColor = Color.Black;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text=="")
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

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            if (textBox5.Text=="")
            {
                textBox5.BackColor = Color.DarkRed;
                textBox5.ForeColor = Color.White;
            }
            else
            {
                textBox5.BackColor = Color.White;
                textBox5.ForeColor = Color.Black;
            }
        }

        private void musteriIslemleri_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;

        }

        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {
            if (e.TabPageIndex==0)
            {
                this.Height = 305;
                this.Width = 519;
            }
            else if (e.TabPageIndex==1)
            {
                this.Height = 125;
                this.Width = 519;
                baglantiDataContext b = new baglantiDataContext();
                comboBox5.DataSource = b.musteris.Where(p=> p.silmeDurumu!="1");
                comboBox5.DisplayMember = "adSoyad";
                comboBox5.ValueMember = "kimlikNo";
                if (comboBox5.Items.Count <= 0)
                {
                    MessageBox.Show("Günceleme İşlemi Yapılamaz. Hiç Müşteri Bulunmamakta.", "Müşteri Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    tabControl1.SelectedIndex = 0;
                }
            }
            else if (e.TabPageIndex==2)
            {
                this.Height = 125;
                this.Width = 337;
                baglantiDataContext b = new baglantiDataContext();
                comboBox6.DataSource = b.musteris.Where(p => p.silmeDurumu != "1");
                comboBox6.DisplayMember = "adSoyad";
                comboBox6.ValueMember = "kimlikNo";
                if (comboBox6.Items.Count <= 0)
                {
                    MessageBox.Show("Silme İşlemi Yapılamaz. Hiç Müşteri Bulunmamakta.", "Müşteri Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    tabControl1.SelectedIndex = 0;
                }
            }
        }


        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.Height = 375;
        }

        private void comboBox5_ValueMemberChanged(object sender, EventArgs e)
        {
            try
            {
                baglantiDataContext b = new baglantiDataContext();
                musteri m = b.musteris.First(p => p.kimlikNo == comboBox5.SelectedValue);
                textBox12.Text = m.kimlikNo;
                textBox11.Text = m.adSoyad;
                textBox10.Text = m.adres;
                textBox9.Text = m.email;
                textBox8.Text = m.babaAdi;
                textBox7.Text = m.ehliyetNo;
                dateTimePicker4.Value = m.dogumTarih.Value;
                dateTimePicker3.Value = m.ehliyetTarih.Value;
                comboBox4.Text = m.kanGrup;
                comboBox3.Text = m.ehliyetTip;
                maskedTextBox2.Text = m.telefon;
            }
            catch (Exception)
            {
               
            }
        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {
            if (textBox12.Text.Length < 11)
            {
                textBox12.BackColor = Color.DarkRed;
                textBox12.ForeColor = Color.White;
            }
            else
            {
                textBox12.BackColor = Color.White;
                textBox12.ForeColor = Color.Black;
            }
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            if (textBox7.Text.Length < 5)
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

        private void textBox11_TextChanged(object sender, EventArgs e)
        {
            if (textBox11.Text=="")
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

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            if (textBox8.Text=="")
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
            if (textBox12.Text.Length==11 && textBox11.Text != "" && textBox8.Text!="" && textBox7.Text.Length==5)
            {
                try
                {
                    DialogResult sonuc = MessageBox.Show("Verileriniz Üzerinde Güncelleme Yapılsın mı ?", "Güncelleme Yapılsın mı ?", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (sonuc == DialogResult.Yes)
                    {
                        baglantiDataContext b = new baglantiDataContext();
                        musteri m = b.musteris.First(p => p.kimlikNo == comboBox5.SelectedValue);
                        m.adSoyad = textBox11.Text;
                        m.adres = textBox10.Text;
                        m.email = textBox9.Text;
                        m.babaAdi = textBox8.Text;
                        m.ehliyetNo = textBox7.Text;
                        m.dogumTarih = dateTimePicker4.Value;
                        m.ehliyetTarih = dateTimePicker3.Value;
                        m.kanGrup = comboBox4.Text;
                        m.ehliyetTip = comboBox3.Text;
                        m.telefon = maskedTextBox2.Text;
                        b.SubmitChanges();
                        MessageBox.Show("Verileriniz Başarı İle Güncellendi", "Güncelleme Başarı", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        comboBox5.DataSource = b.musteris.Where(p => p.silmeDurumu != "1");
                        comboBox5.DisplayMember = "adSoyad";
                        comboBox5.ValueMember = "kimlikNo";
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Program Bir Hata İle Karşılaştı. Lütfen Daha Sonra Tekrar Deneyin.", "Güncelleme Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Lütfen Müşteri Bilgilerini Eksiksiz Doldurunuz.", "Müşteri Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
                try
                {
                    DialogResult sonuc = MessageBox.Show("Verileriniz Üzerinde Silme İşlemi Yapılsın mı ?", "Silme İşlemi Yapılsın mı ?", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (sonuc == DialogResult.Yes)
                    {
                        baglantiDataContext b = new baglantiDataContext();
                        musteri m = b.musteris.First(p => p.kimlikNo == comboBox6.SelectedValue);
                        m.silmeDurumu = "1";
                        b.SubmitChanges();
                        MessageBox.Show("Silme İşlemi Başarı İle Gerçekleşti", "Silme Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        comboBox6.DataSource = b.musteris.Where(p => p.silmeDurumu != "1");
                        comboBox6.DisplayMember = "adSoyad";
                        comboBox6.ValueMember = "kimlikNo";
                        if (comboBox6.Items.Count <= 0)
                        {
                            tabControl1.SelectedIndex = 0;
                        }
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Silme İşlemi Yapılamıyor.Lütfen Sonra Bir Daha Deneyin.", "Silme Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            
            
        }


        private void button5_Click(object sender, EventArgs e)
        {
            musteriSecim.durum = "musteriGuncelle";
            musteriSecim m = new musteriSecim();
            m.ShowDialog();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            musteriSecim.durum = "musteriSil";
            musteriSecim m = new musteriSecim();
            m.ShowDialog();
        }
    }
}

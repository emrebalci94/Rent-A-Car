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
    public partial class markaIslemleri : Form
    {
        public markaIslemleri()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                try
                {
                    DialogResult sonuc = MessageBox.Show("Kayıt Eklensin mi ?", "Kayıt İşlemi Yapılsın mı ?", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (sonuc == DialogResult.Yes)
                    {
                        baglantiDataContext b = new baglantiDataContext();
                        marka m = new marka();
                        m.markaAdi = textBox1.Text;
                        b.markas.InsertOnSubmit(m);
                        b.SubmitChanges();
                        MessageBox.Show("Kayıt İşlemi Başarı İle Tamamlandı.", "Kayıt Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        textBox1.Clear();
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Kayıt İşlemi Yapılamıyor.Lütfen Sonra Bir Daha Deneyin.", "Kayıt Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Lütfen Gerekli Yeri Doldurunuz.", "Marka Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void markaIslemleri_Load(object sender, EventArgs e)
        {
            

        }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.Text=="...")
            {
                MessageBox.Show("Bu Kayıt Üzerinde İşlem Yapılamaz...", "Marka Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
                comboBox2.SelectedIndex = 1;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "...")
            {
                MessageBox.Show("Bu Kayıt Üzerinde İşlem Yapılamaz...", "Marka Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
                comboBox1.SelectedIndex = 1;
            }
            else
            {
                textBox2.Text = comboBox1.Text;
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            groupBox2.Visible = true;
            groupBox3.Visible = false;
            groupBox4.Visible = false;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            baglantiDataContext b = new baglantiDataContext();
            comboBox1.DataSource = b.markas;
            comboBox1.DisplayMember = "markaAdi";
            comboBox1.ValueMember = "markaNo";
            comboBox1.SelectedIndex = 1;
            groupBox3.Visible = true;
            groupBox2.Visible = false;
            groupBox4.Visible = false;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            baglantiDataContext b = new baglantiDataContext();
            comboBox2.DataSource = b.markas;
            comboBox2.DisplayMember = "markaAdi";
            comboBox2.ValueMember = "markaNo";
            comboBox2.SelectedIndex = 1;
            groupBox4.Visible = true;
            groupBox3.Visible = false;
            groupBox2.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "")
            {
                try
                {
                    DialogResult sonuc = MessageBox.Show("Güncelleme İşlemi Yapılsın mı ?", "Marka Güncelle ?", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (sonuc == DialogResult.Yes)
                    {
                        baglantiDataContext b = new baglantiDataContext();
                        marka m = b.markas.First(p => p.markaNo == Convert.ToInt16(comboBox1.SelectedValue));
                        m.markaAdi = textBox2.Text;
                        b.SubmitChanges();
                        MessageBox.Show("Güncelleme İşlemi Başarı İle Tamamlandı.", "Güncelleme Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        textBox2.Clear();
                        comboBox1.DataSource = b.markas;
                        comboBox1.DisplayMember = "markaAdi";
                        comboBox1.ValueMember = "markaNo";
                        comboBox1.SelectedIndex = 1;
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Güncelleme İşlemi Yapılamıyor.Lütfen Sonra Bir Daha Deneyin.", "Güncelleme Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Lütfen Gerekli Yeri Doldurunuz.", "Marka Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult sonuc = MessageBox.Show("Silme İşlemi Yapılsın mı ?", "Marka Sil ?", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (sonuc == DialogResult.Yes)
                {
                    baglantiDataContext b = new baglantiDataContext();
                    marka m = b.markas.First(p => p.markaNo == Convert.ToInt16(comboBox2.SelectedValue));
                    b.markas.DeleteOnSubmit(m);
                    b.SubmitChanges();
                    MessageBox.Show("Silme İşlemi Başarı İle Tamamlandı.", "Silme Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    comboBox2.DataSource = b.markas;
                    comboBox2.DisplayMember = "markaAdi";
                    comboBox2.ValueMember = "markaNo";
                    if (comboBox2.Items.Count>1)
                    {
                        comboBox2.SelectedIndex = 1;
                    }
                   
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Silme İşlemi Yapılamıyor.Lütfen Sonra Bir Daha Deneyin.", "Silme Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            textBox2.Text = comboBox1.Text;
        }

        private void markaIslemleri_FormClosed(object sender, FormClosedEventArgs e)
        {
          
        
            
           
        
        }
    }
}

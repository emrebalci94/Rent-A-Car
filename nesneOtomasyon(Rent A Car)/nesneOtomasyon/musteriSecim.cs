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
    public partial class musteriSecim : Form
    {
        public musteriSecim()
        {
            InitializeComponent();
        }
        private void listele()
        {
            listView1.Items.Clear();
            baglantiDataContext b = new baglantiDataContext();
            var veri = b.musteris.Where(p=> p.silmeDurumu!="1");
            foreach (musteri i in veri)
            {
                string[] al = { i.kimlikNo.ToString(), i.adSoyad.ToString(), i.ehliyetTip, i.telefon, i.adres };
                ListViewItem l = new ListViewItem(al);
                listView1.Items.Add(l);
            }
            if (listView1.Items.Count < 1)
            {
                MessageBox.Show("Hiç Müşteri Bulunmamaktadır...", "Musteri Uyarı ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }
        private void musteriSecim_Load(object sender, EventArgs e)
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
                var veri = b.musteris.Where(p => p.adSoyad.Contains(textBox3.Text) & p.silmeDurumu != "1" | p.kimlikNo == textBox3.Text & p.silmeDurumu != "1");
                foreach (musteri i in veri)
                {
                    string[] al = { i.kimlikNo.ToString(), i.adSoyad.ToString(), i.ehliyetTip, i.telefon, i.adres };
                    ListViewItem l = new ListViewItem(al);
                    listView1.Items.Add(l);
                }
            }
        }
        public static string durum;
        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                
                musteriIslemleri m = Application.OpenForms["musteriIslemleri"] as musteriIslemleri;
                kiraIslemleri k = Application.OpenForms["kiraIslemleri"] as kiraIslemleri;
                if (durum=="musteriGuncelle")
                {
                    m.comboBox5.SelectedValue = listView1.SelectedItems[0].SubItems[0].Text;
                }
                else if (durum == "musteriSil")
                {
                    m.comboBox6.SelectedValue = listView1.SelectedItems[0].SubItems[0].Text; 
                }
                else if (durum=="kira")
                {
                   k.comboBox2.SelectedValue = listView1.SelectedItems[0].SubItems[0].Text; 
                }
                this.Close();
            }
            catch (Exception)
            {  
        
            }
        }
    }
}

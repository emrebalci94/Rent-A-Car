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
    public partial class acilis : Form
    {
        public acilis()
        {
            InitializeComponent();
        }

        private void acilis_Load(object sender, EventArgs e)
        {
            
           
        }

        private void acilis_Shown(object sender, EventArgs e)
        {
            
           
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            anaSayfa a = new anaSayfa();
            this.Hide();
            a.Show();
            timer1.Stop();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}

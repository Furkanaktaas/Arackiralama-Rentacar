using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Arac_Kiralama_Otomasyonu
{ 
   
    public partial class Panel : Form
    {
        YetkiCekme ytk = new YetkiCekme();
        public araclar arc = new araclar();
        public Panel()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

      

        private void button4_Click_1(object sender, EventArgs e)
        {
            arackirala kirala = new arackirala();
            kirala.Show();
        }

        private void button1_Click(object sender, EventArgs e)

        { 
             araclar a = new araclar();
            if (ytk.yetkiAnahtar.ToString() == "OKUYUCU")
            {
                a.button1.Enabled = false;
                a.importY.Enabled = false;
            }
            a.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Calisanlar c = new Calisanlar();
            if (ytk.yetkiAnahtar.ToString() == "OKUYUCU")
            {
                c.button1.Enabled = false;
            }
            else if(ytk.yetkiAnahtar.ToString() == "YAZICI")
            {
                c.button1.Enabled = false;
            }            
            c.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            muhasebe muhasebe = new muhasebe();
            muhasebe.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            KullaniciYetkilendirme ayar = new KullaniciYetkilendirme();
            ayar.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
           if (MessageBox.Show("Çıkış Yapmak İstiyor Musunuz?","Dikkat",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
            {
                this.Hide();
                giris g = new giris();
                g.Show();
            }

           
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Makbuz mkz = new Makbuz();
            mkz.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            hasar hsr = new hasar();
            hsr.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            silinen sil = new silinen();
            sil.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            YedekForm nesne = new YedekForm();
            nesne.Show();

        }
    }
}

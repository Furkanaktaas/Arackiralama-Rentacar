using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Arac_Kiralama_Otomasyonu
{
    public partial class giris : Form
    {
        Panel pnl = new Panel();
        araclar arc = new araclar();
        public giris()
        {
            InitializeComponent();
        }
        private void btnGiris_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Server = DESKTOP-L0GT8MC\\FURKAN; Database=Rehber;Trusted_Connection=True;");

            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }


            /*
             *  SqlCommand com1 = new SqlCommand("Select * from tblKullanici where kullaniciadi = '" + tbK_adi.Text + "' and sifre = '" + tbParola.Text + "", con);
              SqlCommand com2 = new SqlCommand("Select * from tblKullanici where kullaniciadi = '" + tbK_adi.Text + "' and sifre = '" + tbParola.Text + "", con);

              SqlDataReader sd = com1.ExecuteReader();sd.Read();
              */

            YetkiCekme yetkiNesne = new YetkiCekme();           
            if (yetkiNesne.yetkiCek(tbK_adi.Text,tbParola.Text).Equals("ADMIN"))
            {
                
                pnl.Show();
                this.Hide();
            }
            else if (yetkiNesne.yetkiCek(tbK_adi.Text, tbParola.Text).Equals("OKUYUCU"))
            {
                pnl.button5.Enabled = false;
                pnl.button3.Enabled = false;
                pnl.button4.Enabled = false;
                pnl.Show();
                this.Hide();
            }
            else if (yetkiNesne.yetkiCek(tbK_adi.Text, tbParola.Text).Equals("YAZICI"))
            { 
                    pnl.button5.Enabled = false;
                pnl.Show();
                this.Hide();
            }
            else
                MessageBox.Show("Kullanıcı adı veya Şifre hatalı!","Başarısız",MessageBoxButtons.OK,MessageBoxIcon.Error);


/*            SqlCommand com = new SqlCommand("Select * from tblKullanici where kullaniciadi = '"+tbK_adi.Text+"' and sifre = '"+tbParola.Text+"", con);
            com.ExecuteNonQuery();
            SqlDataReader dr = com.ExecuteReader();
            if(dr.Read())
            {
                Panel frm2 = new Panel();
                frm2.Show();
                this.Hide();

            }
            */
            
           


        }

        private void giris_Load(object sender, EventArgs e)
        {

        }
    }
}

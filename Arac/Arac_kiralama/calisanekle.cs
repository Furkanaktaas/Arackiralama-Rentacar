using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Arac_Kiralama_Otomasyonu
{
    public partial class calisanekle : Form
    {
        public calisanekle()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        SqlConnection baglanti = new SqlConnection(@"Server=DESKTOP-KJPA1CG\MSSQLSERVER2;Database=arac_kiralama;User Id=sa;Password = 3529654;");

        private void button1_Click(object sender, EventArgs e)
        {
            if (tc.Text.Trim() == "" || isim.Text.Trim() == "" || soyisim.Text.Trim() == "" || adres.Text.Trim() == "" || email.Text.Trim() == "" || telefon.Text.Trim()=="")
            {
                MessageBox.Show("Boş Alan Bırakmadan Doldurunuz.", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                tc.Text = tc.Text.Trim();
                isim.Text = isim.Text.Trim();
                soyisim.Text = soyisim.Text.Trim();
                telefon.Text = telefon.Text.Trim();
                email.Text = email.Text.Trim();
                adres.Text = adres.Text.Trim();
                baglanti.Open();
                SqlCommand command = new SqlCommand("sp_calisanEkle", baglanti);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@tc", tc.Text);
                command.Parameters.AddWithValue("@isim", isim.Text);
                command.Parameters.AddWithValue("@soyisim", soyisim.Text);
                command.Parameters.AddWithValue("@adres", adres.Text);
                command.Parameters.AddWithValue("@tel", telefon.Text);
                command.Parameters.AddWithValue("@email", email.Text);
                command.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Kaydınız Başarı ile Gerçekleştirilmiştir.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tc.Clear();
                isim.Clear();
                soyisim.Clear();
                adres.Clear();
                telefon.Clear();
                email.Clear();


            }


        }

        private void calisanekle_FormClosed(object sender, FormClosedEventArgs e)
        {
            Calisanlar calisanlar = new Calisanlar();
            calisanlar.Show();
            baglanti.Open();

            string calisanlariCek = "select * from tblCalisan";
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(calisanlariCek, baglanti);
            da.Fill(dt);
            calisanlar.dataGridView1.DataSource = dt;
        }

        private void calisanekle_Load(object sender, EventArgs e)
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace Arac_Kiralama_Otomasyonu
{
    public partial class CalisanGuncelle : Form
    {
        public CalisanGuncelle()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Server=DESKTOP-KJPA1CG\MSSQLSERVER2;Database=arac_kiralama;User Id=sa;Password = 3529654;");
        private void button1_Click(object sender, EventArgs e)
        {
            tc.Text= tc.Text.Trim();
            isim.Text=isim.Text.Trim();
            soyisim.Text = soyisim.Text.Trim();
           telefon.Text= telefon.Text.Trim();
           email.Text= email.Text.Trim();
            adres.Text = adres.Text.Trim();
            if (baglanti.State == ConnectionState.Closed)
            {
                baglanti.Open();
            }
            SqlCommand command = new SqlCommand("sp_calisanGuncelle", baglanti);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@calisanno", label7.Text);
            command.Parameters.AddWithValue("@tc", tc.Text);
            command.Parameters.AddWithValue("@isim", isim.Text);
            command.Parameters.AddWithValue("@soyisim", soyisim.Text);
            command.Parameters.AddWithValue("@adres", adres.Text);
            command.Parameters.AddWithValue("@tel",telefon.Text);
            command.Parameters.AddWithValue("@email", email.Text);
            command.ExecuteNonQuery();
            MessageBox.Show("Güncelleme Başarılı");
            baglanti.Close();


        }

        private void CalisanGuncelle_FormClosed(object sender, FormClosedEventArgs e)
        {
            baglanti.Open();
            Calisanlar calis = new Calisanlar();
            string calisanlariCek = "select * from tblCalisan";
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(calisanlariCek, baglanti);
            da.Fill(dt);
           calis.dataGridView1.DataSource = dt;
            calis.Show();
            baglanti.Close();
        }

        private void CalisanGuncelle_Load(object sender, EventArgs e)
        {

        }

        private void telefon_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

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
    public partial class AracGeriAlma : Form
    {
        public AracGeriAlma()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Server=DESKTOP-KJPA1CG\MSSQLSERVER2;Database=arac_kiralama;User Id=sa;Password = 3529654;");
        private void AracGeriAlma_Load(object sender, EventArgs e)
        {
            hasarsız.Checked = true;
            textBox2.Text = "0";

        }

        private void hasarlı_CheckedChanged(object sender, EventArgs e)
        {
            if (hasarlı.Checked)
            {
                textBox2.Enabled = true;
            }
            else
            {
                textBox2.Enabled = false;
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(baglanti.State == ConnectionState.Closed)
            {
                baglanti.Open();
            }
            string sql = "select kira_no from tblArac_Kiralama WHERE a_no=" + label1.Text;
            SqlCommand KOMUT = new SqlCommand(sql, baglanti);
            SqlDataReader dr = KOMUT.ExecuteReader();
            dr.Read();
            string kira_no = dr["kira_no"].ToString();
            dr.Close();
            if(hasarlı.Checked)
            {
                sql = "UPDATE tblHasar SET durumu=1,Maliyet="+textBox2.Text+" WHERE hasar_no="+kira_no;
                KOMUT = new SqlCommand(sql, baglanti);
                KOMUT.ExecuteNonQuery();
                
            }
            sql = "DELETE FROM tblArac_Kiralama WHERE kira_no=" + kira_no;
            KOMUT = new SqlCommand(sql, baglanti);
            KOMUT.ExecuteNonQuery();
            sql = "UPDATE tblMakbuz SET urcet=urcet+"+textBox2.Text;
            KOMUT = new SqlCommand(sql, baglanti);
            KOMUT.ExecuteNonQuery();
            string ucret = "Select urcet from tblMakbuz where makbuz_no=" + kira_no ;
            SqlCommand kom = new SqlCommand(ucret,baglanti);
            SqlDataReader dr2 = kom.ExecuteReader();dr2.Read();
            string ucretmiktar = dr2["urcet"].ToString();
            MessageBox.Show("Toplam ucret"+ucretmiktar);
            dr.Close();
            baglanti.Close();
        }

        private void AracGeriAlma_FormClosed(object sender, FormClosedEventArgs e)
        {
            baglanti.Open();
            muhasebe muha = new muhasebe();

            string vericek = "select * from tblArac where kiraDurumu='true'";
            SqlDataAdapter da = new SqlDataAdapter(vericek, baglanti);
            DataTable dt = new DataTable();
            da.Fill(dt);
            muha.dataGridView1.DataSource = dt;
            muha.Show();
            baglanti.Close();               
        }
    }
}

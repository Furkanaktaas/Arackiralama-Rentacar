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
    public partial class YedekForm : Form
    {
        SqlConnection baglanti = new SqlConnection(@"Server=DESKTOP-KJPA1CG\MSSQLSERVER2;Database=arac_kiralama;User Id=sa;Password = 3529654;");

        public YedekForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (baglanti.State == ConnectionState.Closed)
            {
                baglanti.Open();
            }
            string sql = @"BACKUP DATABASE [arac_kiralama] TO  DISK = N'"+textBox1.Text.ToString()+textBox2.Text.ToString()+".bak' WITH NOFORMAT, NOINIT,  NAME = N'arac_kiralama-Full Database Backup', SKIP, NOREWIND, NOUNLOAD,  STATS = 10";
            SqlCommand komut = new SqlCommand(sql, baglanti);
            komut.ExecuteNonQuery();
            MessageBox.Show("Başarıyla yedekleme yapıldı", "yedekleme", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            baglanti.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox3.Text = openFileDialog1.FileName.ToString();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (baglanti.State == ConnectionState.Closed)
            {
                baglanti.Open();
            }
            string sqlsingle = string.Format("ALTER DATABASE [arac_kiralama] SET SINGLE_USER WITH ROLLBACK IMMEDIATE");
            string sqlmulti = string.Format("ALTER DATABASE [arac_kiralama] SET MULTI_USER");
            string sql = @"USE [master] RESTORE DATABASE [arac_kiralama] FROM  DISK = N'"+textBox3.Text.ToString()+"' WITH  FILE = 1,  NOUNLOAD,  STATS = 5";
            SqlCommand komut = new SqlCommand(sqlsingle, baglanti);
            komut.ExecuteNonQuery();
            komut = new SqlCommand(sql, baglanti);
            komut.ExecuteNonQuery();
            komut = new SqlCommand(sqlmulti, baglanti);
            komut.ExecuteNonQuery();
            MessageBox.Show("Başarıyla Geri yükleme yapıldı", "Geri Yükleme", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            baglanti.Close();
        }

        private void YedekForm_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}

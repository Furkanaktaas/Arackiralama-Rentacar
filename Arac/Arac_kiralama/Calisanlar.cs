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
    public partial class Calisanlar : Form
    {
        YetkiCekme ytk = new YetkiCekme();
        public Calisanlar()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            calisanekle calisan = new calisanekle();
            calisan.Show();
            this.Hide();
        }

        SqlConnection baglanti = new SqlConnection(@"Server=DESKTOP-KJPA1CG\MSSQLSERVER2;Database=arac_kiralama;User Id=sa;Password = 3529654;");

        private void Calisanlar_Load(object sender, EventArgs e)
        {
            baglanti.Open();
            string calisanlariCek = "select * from tblCalisan";
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(calisanlariCek, baglanti);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            if (ytk.yetkiAnahtar.ToString() == "ADMIN")
            {
                DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
                dataGridView1.Columns.Add(btn);
                btn.HeaderText = "İşlem";
                btn.Text = "Sil";
                btn.Name = "sil";
                btn.UseColumnTextForButtonValue = true;

                DataGridViewButtonColumn btn2 = new DataGridViewButtonColumn();
                dataGridView1.Columns.Add(btn2);
                btn2.HeaderText = "İşlem";
                btn2.Text = "Güncelle";
                btn2.Name = "guncelle";
                btn2.UseColumnTextForButtonValue = true;
            }


        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text.Equals(""))
            {
                string cumle = "select * from tblCalisan";
                // textBox1.Text = textBox1.Text.Replace(" ", "");
                SqlDataAdapter da = new SqlDataAdapter(cumle, baglanti);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Equals(""))
            {
                string cumle = "select * from tblCalisan";
                // textBox1.Text = textBox1.Text.Replace(" ", "");
                SqlDataAdapter da = new SqlDataAdapter(cumle, baglanti);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;

            }
            else
            {
                string cumle = "select * from tblCalisan where tc='" + textBox1.Text.Replace(" ", "") + "'";
                textBox1.Text = textBox1.Text.Replace(" ", "");
                SqlDataAdapter da = new SqlDataAdapter(cumle, baglanti);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["sil"].Index)
            {
                if (MessageBox.Show("Silmek istediğinize emin misiniz ? ", "DİKKAT", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {


                    string kullaniciSilme = "Delete from tblCalisan where tc=" + dataGridView1.CurrentRow.Cells[dataGridView1.Columns["tc"].Index].Value.ToString();
                    SqlCommand com = new SqlCommand(kullaniciSilme, baglanti);
                    com.ExecuteNonQuery();

                    SqlDataAdapter da = new SqlDataAdapter("select * from tblCalisan", baglanti);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;


                }


            }
            if (e.ColumnIndex == dataGridView1.Columns["guncelle"].Index)
            {
                CalisanGuncelle calisanguncel = new CalisanGuncelle();

                calisanguncel.label7.Text= dataGridView1.CurrentRow.Cells[0].Value.ToString();
                calisanguncel.tc.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                calisanguncel.isim.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                calisanguncel.soyisim.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                calisanguncel.adres.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                calisanguncel.telefon.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                calisanguncel.email.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
                
                this.Hide();
                calisanguncel.Show();

            }
        }
    }
}

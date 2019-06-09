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
    public partial class muhasebe : Form
    {
        public muhasebe()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Server=DESKTOP-KJPA1CG\MSSQLSERVER2;Database=arac_kiralama;User Id=sa;Password = 3529654;");
        private void muhasebe_Load(object sender, EventArgs e)
        {
            baglanti.Open();
            string vericek = "select * from tblArac where kiraDurumu='true'";
            SqlDataAdapter da = new SqlDataAdapter(vericek,baglanti);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            DataGridViewButtonColumn btn2 = new DataGridViewButtonColumn();
            dataGridView1.Columns.Add(btn2);
            btn2.HeaderText = "İşlem";
            btn2.Text = "Geri Al";
            btn2.Name = "geri";
            btn2.UseColumnTextForButtonValue = true;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.ColumnIndex == dataGridView1.Columns["geri"].Index)
            {
                if (MessageBox.Show("Geri almak istediğinize emin misiniz ? ", "DİKKAT", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    AracGeriAlma geri = new AracGeriAlma();
                    string arac_no = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                    geri.label1.Text = arac_no;
                    geri.Show();
                    this.Hide();
                }


            }
        }
    }
}

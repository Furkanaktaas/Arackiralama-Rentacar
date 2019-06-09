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
    public partial class arackirala : Form
    {
        public arackirala()
        {
            InitializeComponent();
        }

     
        SqlConnection baglanti = new SqlConnection(@"Server=DESKTOP-KJPA1CG\MSSQLSERVER2;Database=arac_kiralama;User Id=sa;Password = 3529654;");
        private void arackirala_Load(object sender, EventArgs e)
        {
          
            baglanti.Open();
            string cumle = "Select * from tblArac where kiraDurumu='false'";
            SqlDataAdapter da = new SqlDataAdapter(cumle, baglanti);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            baglanti.Close();
            DataGridViewButtonColumn btn2 = new DataGridViewButtonColumn();
            dataGridView1.Columns.Add(btn2);
            btn2.HeaderText = "İşlem";
            btn2.Text = "Kirala";
            btn2.Name = "kirala";
            btn2.UseColumnTextForButtonValue = true;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            kiralama kira = new kiralama();
            kira.label17.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            kira.Show();
            this.Hide();

        }
    }
}

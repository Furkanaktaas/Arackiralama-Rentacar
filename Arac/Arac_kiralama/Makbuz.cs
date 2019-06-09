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
    public partial class Makbuz : Form
    {
        SqlConnection baglanti = new SqlConnection(@"Server=DESKTOP-KJPA1CG\MSSQLSERVER2;Database=arac_kiralama;User Id=sa;Password = 3529654;");
        public Makbuz()
        {
            InitializeComponent();
        }

        private void Makbuz_Load(object sender, EventArgs e)
        {
            if(baglanti.State == ConnectionState.Closed)
            {
                baglanti.Open();
            }
            SqlDataAdapter da = new SqlDataAdapter("Select * from tblMakbuz",baglanti);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            baglanti.Close();
        }
    }
}

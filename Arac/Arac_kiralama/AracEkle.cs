
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;

namespace Arac_Kiralama_Otomasyonu
{
    public partial class AracEkle : Form
    {
        public AracEkle()
        {
            InitializeComponent();
        }

        private void AracEkle_Load(object sender, EventArgs e)
        {
            klimayok.Checked = true;
            sigortayok.Checked = true;
         
            
        }

        SqlConnection baglanti = new SqlConnection(@"Server=DESKTOP-KJPA1CG\MSSQLSERVER2;Database=arac_kiralama;User Id=sa;Password = 3529654;");

        private void button1_Click(object sender, EventArgs e)
        {
          if(plaka.Text.Trim() == "" || marka.Text.Trim() == "" || model.Text.Trim() == "" || ruhsat.Text.Trim() == "" || motorguc.Text.Trim() == "" || motorhacim.Text.Trim() == "" || renk.Text.Trim() == "" || yakit.Text.Trim() == "" || vites.Text.Trim() == ""  || tork.Text.Trim() == "" || ucret.Text.Trim() == "")
            {
                MessageBox.Show("Boş Alan Bırakmadan Doldurunuz.","UYARI",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
         
                  
           
            else {
                if (Convert.ToInt32(motorhacim.Text) >= 1000 && Convert.ToInt32(motorhacim.Text) <= 5000)
                {
                    
                   
                    baglanti.Open();
                    plaka.Text = plaka.Text.Replace(" ", "");
                    marka.Text = marka.Text.Trim();
                    model.Text = model.Text.Trim();
                    ruhsat.Text = ruhsat.Text.Trim();
                    motorguc.Text = motorguc.Text.Trim();
                    motorhacim.Text = motorhacim.Text.Trim();
                    tork.Text = tork.Text.Trim();
                    ucret.Text = ucret.Text.Trim();
                    renk.Text = renk.Text.Trim();
                    
                  

                    SqlCommand command = new SqlCommand("sp_aracKayit", baglanti);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@marka", marka.Text);
                    command.Parameters.AddWithValue("@model", model.Text);
                    command.Parameters.AddWithValue("@plaka", plaka.Text);
                    command.Parameters.AddWithValue("@yakitTuru", yakit.Text);
                    command.Parameters.AddWithValue("@motorGucu", motorguc.Text);
                    command.Parameters.AddWithValue("@tork", tork.Text);
                    command.Parameters.AddWithValue("@motorHacmi", motorhacim.Text);
                    command.Parameters.AddWithValue("@renk", renk.Text);
                    command.Parameters.AddWithValue("@vites", vites.Text);
                    bool klima = false;
                    if (klimavar.Checked)
                        klima = true;
                    else
                        klima = false;
                    command.Parameters.AddWithValue("@klima", klima);
                    command.Parameters.AddWithValue("@ruhsatNo", ruhsat.Text);
                    bool sigorta = false;
                    if (sigortavar.Checked)
                        sigorta = true;
                    else
                        sigorta = false;
                    command.Parameters.AddWithValue("@sigorta", sigorta);
                    command.Parameters.AddWithValue("@muayneBitTar",muayene.Value.ToString("MM.dd.yyyy"));
                    command.Parameters.AddWithValue("@ucret", ucret.Text);
                    command.Parameters.AddWithValue("@kiraDurumu", false);
                    command.ExecuteNonQuery();

                    MessageBox.Show("Kaydınız Başarı ile Gerçekleştirilmiştir.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    plaka.Clear();
                    marka.Clear();
                    model.Clear();
                    motorguc.Clear();
                    motorhacim.Clear();
                    ruhsat.Clear();
                    renk.Clear();
                    tork.Clear();
                    ucret.Clear();
                    klimayok.Checked = true;
                    sigortayok.Checked = true;
                    vites.Text = "";
                    yakit.Text = "";
                    // buralarda clear yap
                    baglanti.Close();

                }
                else
                {
                    MessageBox.Show("Motor Hacmi 1000 ile 5000 arasında olmalıdır.", "DİKKAT", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
             
            }        

        }

        private void AracEkle_FormClosed(object sender, FormClosedEventArgs e)
        {
            baglanti.Open();
            SqlDataAdapter da = new SqlDataAdapter("select * from tblArac", baglanti);
            DataTable dt = new DataTable();
            da.Fill(dt);
            araclar a = new araclar();
            a.dataGridView1.DataSource = dt;
            a.Show();
            baglanti.Close();
        }

        private void motorguc_TextChanged(object sender, EventArgs e)
        {

        }

        private void muayene_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}

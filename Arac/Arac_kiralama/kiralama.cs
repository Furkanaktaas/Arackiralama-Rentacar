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

    public partial class kiralama : Form
    {
        SqlConnection baglanti = new SqlConnection(@"Server=DESKTOP-KJPA1CG\MSSQLSERVER2;Database=arac_kiralama;User Id=sa;Password = 3529654;");

        public kiralama()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {


            baglanti.Open();
            SqlCommand command = new SqlCommand("sp_musteriKayit", baglanti);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@ad", isim.Text);
            command.Parameters.AddWithValue("@soyad", soyisim.Text);
            command.Parameters.AddWithValue("@mus_tc", tc.Text);
            command.Parameters.AddWithValue("@adres", adres.Text);
            command.Parameters.AddWithValue("@mus_tel", telefon.Text);
            command.Parameters.AddWithValue("@mus_email", mail.Text);
            char cinsiyet = 'E';
            if (bay.Checked)
                cinsiyet = 'E';
            else
                cinsiyet = 'K';
            command.Parameters.AddWithValue("@cinsiyet", cinsiyet);
            command.Parameters.AddWithValue("@dogumtar", dogumtarihi.Text);
            command.Parameters.AddWithValue("@dogumyer", dogumyeri.Text);
            command.ExecuteNonQuery();

            string musId = "select mus_no from tblMusteri where mus_tc=" + tc.Text;

            SqlCommand command2 = new SqlCommand(musId, baglanti);

            SqlDataReader reader = command2.ExecuteReader();
            reader.Read();
            int musNo = Convert.ToInt32(reader["mus_no"]);
            reader.Close();
            string deneme="insert into tblEhliyet values("+musNo+",'"+ehliyetno.Text+"','"+ehliyetsinif.Text+"','"+kan.Text+"','"+ehliyetalim.Text+"','"+ehliyetbitis.Text+"')";
            SqlCommand cm = new SqlCommand(deneme, baglanti);

            YetkiCekme yc = new YetkiCekme();
            string calisanNo = "select calisan_no from tblCalisan where calisan_no="+yc.idAnahtar;
            SqlCommand command3 = new SqlCommand(calisanNo, baglanti);
            SqlDataReader reader2 = command3.ExecuteReader();
            reader2.Read();
            int cali = Convert.ToInt32(reader2["calisan_no"]);
            reader2.Close();


            cm.ExecuteNonQuery();
            string arackayit = "insert into tblArac_Kiralama values(" + musNo + ","+label17.Text+","+cali+",null,null,'"+dateTimePicker1.Value.ToString("MM.dd.yyyy") +"','"+dateTimePicker2.Value.ToString("MM.dd.yyyy")+"')";
            SqlCommand arac = new SqlCommand(arackayit, baglanti);
            arac.ExecuteNonQuery();

            string aracGuncele = "update tblArac set kiraDurumu='true' where arac_no=" + label17.Text;
            SqlCommand guncelle = new SqlCommand(aracGuncele, baglanti);
            
            guncelle.ExecuteNonQuery();    

            baglanti.Close();
            MessageBox.Show("Araç Kiralama Başarılı","Başarılı",MessageBoxButtons.OK,MessageBoxIcon.Information);

        }

        private void kiralama_Load(object sender, EventArgs e)
        {
           
            bay.Checked = true;
           

        }

        private void kiralama_FormClosed(object sender, FormClosedEventArgs e)
        {
            arackirala arac = new arackirala();
           

            baglanti.Open();
            string cumle = "Select * from tblArac where kiraDurumu='false'";
            SqlDataAdapter da = new SqlDataAdapter(cumle, baglanti);
            DataTable dt = new DataTable();
            da.Fill(dt);
            arac.dataGridView1.DataSource = dt;
            arac.Show();
            baglanti.Close();
        }

        private void soyisim_TextChanged(object sender, EventArgs e)
        {

        }

        private void tc_TextChanged(object sender, EventArgs e)
        {

        }

        private void isim_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

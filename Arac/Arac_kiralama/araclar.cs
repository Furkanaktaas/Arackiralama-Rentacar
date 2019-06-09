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
using System.Data.OleDb;
using Excel;
using System.IO;
namespace Arac_Kiralama_Otomasyonu
{
    public partial class araclar : Form
    {
        YetkiCekme ytk = new YetkiCekme();
        SqlConnection baglanti = new SqlConnection(@"Server=DESKTOP-KJPA1CG\MSSQLSERVER2;Database=arac_kiralama;User Id=sa;Password = 3529654;");
        public araclar()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            AracEkle aracEkle = new AracEkle();
            this.Hide();
            aracEkle.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AracGuncelle aracguncelle = new AracGuncelle();
            aracguncelle.Show();
        }

        private void araclar_Load(object sender, EventArgs e)
        {
            radioButton3.Checked = true;

            string sql = "select * from tblArac";
            if (baglanti.State == ConnectionState.Closed)
            {
                baglanti.Open();
            }
            SqlDataAdapter da = new SqlDataAdapter(sql, baglanti);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            string sqlMarka = "select marka from tblArac group by marka";
            string sqlModel = "select model from tblArac group by model";
            string sqlVites = "select vites from tblArac group by vites";
            string sqlYakit = "select yakit_turu from tblArac group by yakit_turu";
            SqlCommand komut = new SqlCommand(sqlMarka, baglanti);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                marka.Items.Add(dr["marka"]);
            }
            komut = new SqlCommand(sqlModel, baglanti);
            dr.Close();
            dr = komut.ExecuteReader();
            while (dr.Read())
            {
                model.Items.Add(dr["model"]);
            }
            dr.Close();
       
            komut = new SqlCommand(sqlVites, baglanti);
            dr = komut.ExecuteReader();
            while (dr.Read())
            {
                vites.Items.Add(dr["vites"]);
            }
            dr.Close();
            komut = new SqlCommand(sqlYakit, baglanti);
            dr = komut.ExecuteReader();
            while (dr.Read())
            {
                yakit.Items.Add(dr["yakit_turu"]);
            }
            dr.Close();
            if (ytk.yetkiAnahtar.ToString() != "OKUYUCU")
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





        private void button3_Click(object sender, EventArgs e)
        {


        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1[0, 0].Value == null)
            {
                MessageBox.Show("Veri Bulunmamaktadır");

            }
            else
            {
                if (e.ColumnIndex == dataGridView1.Columns["sil"].Index)
                {
                    if (MessageBox.Show("Silmek istediğinize emin misiniz ? ", "DİKKAT", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {


                        string silme = "Delete from tblArac where plaka='" + dataGridView1.CurrentRow.Cells[dataGridView1.Columns["plaka"].Index].Value.ToString() + "'";
                        SqlCommand com = new SqlCommand(silme, baglanti);
                        com.ExecuteNonQuery();

                        SqlDataAdapter da = new SqlDataAdapter("select * from tblArac", baglanti);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dataGridView1.DataSource = dt;


                    }


                }
                if (e.ColumnIndex == dataGridView1.Columns["guncelle"].Index)
                {
                    AracGuncelle gunce = new AracGuncelle();


                    gunce.marka.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                    gunce.model.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                    gunce.plaka.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                    gunce.yakit.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                    gunce.motorguc.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                    gunce.tork.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
                    gunce.motorhacim.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
                    gunce.renk.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
                    gunce.vites.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();

                    if (dataGridView1.CurrentRow.Cells[10].Value.ToString() == "True")
                    {
                        gunce.klimavar.Checked = true;
                    }
                    else
                        gunce.klimayok.Checked = true;

                    if (dataGridView1.CurrentRow.Cells[12].Value.ToString() == "True")
                    {
                        gunce.sigortavar.Checked = true;
                    }
                    else
                        gunce.sigortayok.Checked = true;

                    gunce.ruhsat.Text = dataGridView1.CurrentRow.Cells[11].Value.ToString();
                    gunce.muayene.Text = dataGridView1.CurrentRow.Cells[13].Value.ToString();
                    gunce.ucret.Text = dataGridView1.CurrentRow.Cells[14].Value.ToString();
                    gunce.label15.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();



                    this.Hide();
                    gunce.Show();

                }

            }



        }


        private void marka_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("sp_markaArama", baglanti);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@marka", marka.Text);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = command;
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;

         

        }

        private void model_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("sp_modelArama", baglanti);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@model", model.Text);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = command;
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;

        }

       

        private void vites_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("sp_yakitVitesArama", baglanti);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@yakit_turu", yakit.Text);
            command.Parameters.AddWithValue("@vites", vites.Text);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = command;
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;

        }

        private void yakit_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("sp_yakitVitesArama", baglanti);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@yakit_turu", yakit.Text);
            command.Parameters.AddWithValue("@vites", vites.Text);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = command;
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
    /*    public void degistir(ComboBox gelen, string sgelen, ComboBox giden, string sgiden)
        {
            string sqlCumle = "Select " + sgelen + " from tblArac where " + sgiden + "='" + giden.Text + "' group by " + sgelen;
            SqlCommand komut = new SqlCommand(sqlCumle, baglanti);
            SqlDataReader dr = komut.ExecuteReader();

            gelen.Items.Clear();
            while (dr.Read())
            {
                gelen.Items.Add(dr[sgelen]);
            }
            dr.Close();
        }
      */

        private void button4_Click(object sender, EventArgs e)
        {


            if (plaka.Text.Equals(""))
            {
                string cumle = "select * from tblArac";
                plaka.Text = plaka.Text.Replace(" ", "");
                SqlDataAdapter da = new SqlDataAdapter(cumle, baglanti);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            else
            {
                string cumle = "select * from tblArac where plaka='" + plaka.Text.Replace(" ", "") + "'";
                plaka.Text = plaka.Text.Replace(" ", "");
                SqlDataAdapter da = new SqlDataAdapter(cumle, baglanti);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }



        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            string cumle = "select * from tblArac where kiraDurumu='false'";

            SqlDataAdapter da = new SqlDataAdapter(cumle, baglanti);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            string cumle = "select * from tblArac where kiraDurumu='true'";

            SqlDataAdapter da = new SqlDataAdapter(cumle, baglanti);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            string cumle = "select * from tblArac";

            SqlDataAdapter da = new SqlDataAdapter(cumle, baglanti);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void plaka_TextChanged(object sender, EventArgs e)
        {
            if (plaka.Text == "")
            {
                string cumle = "select * from tblArac";

                SqlDataAdapter da = new SqlDataAdapter(cumle, baglanti);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;

            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            pdfAktarma pdf = new pdfAktarma();
            pdf.pdfileYazma(dataGridView1);
        }
        OleDbConnection baglanti2 = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\son.xls; Extended Properties='Excel 12.0 xml;HDR=YES;'");

        private void button2_Click_1(object sender, EventArgs e)
        {
            open_file_dialog.ShowDialog();
            textBox1.Text = open_file_dialog.FileName;
            string dosya_yolu = open_file_dialog.FileName;

            OleDbConnection deneme = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;  Data Source = " + dosya_yolu + "; Extended Properties = Excel 12.0");
            deneme.Open();
            string sorgu = "select * from [Arabalar$] ";
            OleDbDataAdapter data_adaptor = new OleDbDataAdapter(sorgu, deneme);
            deneme.Close();

            DataTable dt = new DataTable();
            data_adaptor.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.Columns["sil"].Visible = false;
            dataGridView1.Columns["guncelle"].Visible = false;
            for (int i = 0; i <= dt.Rows.Count - 1; i++)
            {

                string cumle = "insert into tblArac values('" + dataGridView1.Rows[i].Cells["marka"].Value + "','" + dataGridView1.Rows[i].Cells["model"].Value + "','" + dataGridView1.Rows[i].Cells["plaka"].Value + "','" + dataGridView1.Rows[i].Cells["yakit_turu"].Value + "'," + dataGridView1.Rows[i].Cells["motor_gucu"].Value + "," + dataGridView1.Rows[i].Cells["tork"].Value + "," + dataGridView1.Rows[i].Cells["motor_hacmi"].Value + ",'" + dataGridView1.Rows[i].Cells["renk"].Value + "','" + dataGridView1.Rows[i].Cells["vites"].Value + "'," + dataGridView1.Rows[i].Cells["klima"].Value + "," + dataGridView1.Rows[i].Cells["ruhsat_no"].Value + "," + dataGridView1.Rows[i].Cells["sigorta"].Value + ",'" + dataGridView1.Rows[i].Cells["muayne_bit_tar"].Value.ToString() + "'," + dataGridView1.Rows[i].Cells["ucret"].Value + "," + dataGridView1.Rows[i].Cells["kiraDurumu"].Value + ")";
                SqlCommand komut = new SqlCommand(cumle, baglanti);
                komut.ExecuteNonQuery();


            }
            MessageBox.Show("Yükleme İşlemi başarılı", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.Hide();
            baglanti.Close();
            araclar a = new araclar();
            a.Show();

        }

        internal class test
        {
            public test()
            {
            }
        }

        private void button2_Click_2(object sender, EventArgs e)
        {
            Microsoft.Office.Interop.Excel.Application Excelver = new Microsoft.Office.Interop.Excel.Application();
            Excelver.Visible = true;
            Microsoft.Office.Interop.Excel.Workbook objBook = Excelver.Workbooks.Add(System.Reflection.Missing.Value);
            Microsoft.Office.Interop.Excel.Worksheet objSheet = (Microsoft.Office.Interop.Excel.Worksheet)objBook.Worksheets.get_Item(1);
            for (int i = 0; i < dataGridView1.Columns.Count; i++)
            {
                Microsoft.Office.Interop.Excel.Range objRange = (Microsoft.Office.Interop.Excel.Range)objSheet.Cells[1, i + 1];
                objRange.Value2 = dataGridView1.Columns[i].HeaderText;

            }
            for (int i = 0; i < dataGridView1.Columns.Count-2; i++)
            {
                for (int j = 0; j < dataGridView1.Rows.Count-2; j++)
                {
                    Microsoft.Office.Interop.Excel.Range objRange = (Microsoft.Office.Interop.Excel.Range)objSheet.Cells[j + 2, i + 1];
                    objRange.Value2 = dataGridView1[i, j].Value;
                    
                }
            }
        }

        private void model_TextChanged(object sender, EventArgs e)
        {
            if (model.Text.Equals(""))
            {
                string sql = "select * from tblArac";
                SqlDataAdapter da= new SqlDataAdapter(sql, baglanti);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;

            }
        }

        private void marka_TextChanged(object sender, EventArgs e)
        {
            if (marka.Text.Equals(""))
            {
                string sql = "select * from tblArac";
                SqlDataAdapter da = new SqlDataAdapter(sql, baglanti);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;

            }
        }

        private void vites_TextChanged(object sender, EventArgs e)
        {
            string sql = "select * from tblArac";
            SqlDataAdapter da = new SqlDataAdapter(sql, baglanti);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;

        }

        private void yakit_TextChanged(object sender, EventArgs e)
        {
            string sql = "select * from tblArac";
            SqlDataAdapter da = new SqlDataAdapter(sql, baglanti);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            marka.Text = null;
            model.Text = null;
            vites.Text = null;
            yakit.Text = null;
            string sql = "select * from tblArac";
            SqlDataAdapter da = new SqlDataAdapter(sql, baglanti);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;

        }
    }
}
    


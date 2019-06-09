using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace Arac_Kiralama_Otomasyonu
{
    public partial class silinen : Form
    {
        pdfAktarma pda = new pdfAktarma();
        SqlConnection baglanti = new SqlConnection(@"Server=DESKTOP-KJPA1CG\MSSQLSERVER2;Database=arac_kiralama;User Id=sa;Password = 3529654;");
        public silinen()
        {
            InitializeComponent();
        }

        private void silinen_Load(object sender, EventArgs e)
        {
            if (baglanti.State == ConnectionState.Closed)
            {
                baglanti.Open();
            }
            string sql = "SELECT sk.sil_no as 'Silinen Kayıt Numarası',m.ad+' '+m.soyad as 'Müşteri',a.plaka as 'Aracın Plakası',c.isim+' '+c.soyisim as 'Kiralayan Çalışan',mak.urcet as 'Ödenmiş Olan Tutar',h.durumu as 'Hasar Durumu',sk.sil_bas_tar as 'Kira Tarihi',sk.sil_bit_tar as 'Teslim Tarihi' FROM tblSilinenKiralanmis sk INNER JOIN tblMusteri m ON sk.sil_m_no=m.mus_no INNER JOIN tblArac a ON sk.sil_a_no=a.arac_no INNER JOIN tblCalisan c ON sk.sil_c_no = c.calisan_no INNER JOIN tblMakbuz mak ON sil_mak_no=mak.makbuz_no INNER JOIN tblHasar h ON h.hasar_no = sil_h_no";
            SqlDataAdapter da = new SqlDataAdapter(sql, baglanti);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            baglanti.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            pda.pdfileYazma(dataGridView1);
        }
    }
}

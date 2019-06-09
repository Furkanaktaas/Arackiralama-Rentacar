using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arac_Kiralama_Otomasyonu
{
    class YetkiCekme
    {
        SqlConnection con = new SqlConnection("Server = DESKTOP-L0GT8MC\\FURKAN; Database=Rehber;Trusted_Connection=True;");
        private static string yetki;
        private static string id;
        public string yetkiAnahtar
        {
            get
            {
                return yetki;
            }
        }
        public string idAnahtar
        {
            get
            {
                return id;
            }
        }
        public string yetkiCek(string kullaniciAdi,string parola)
        {
            if(con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand oku = new SqlCommand("Select yetki,calisan_no from tblKullanici where kullaniciadi = '" + kullaniciAdi + "' and sifre = '" + parola+ "'", con);
            SqlDataReader re = oku.ExecuteReader();
            if(re.Read())
            {
                yetki = Convert.ToString(re["yetki"]);
                id = Convert.ToString(re["calisan_no"]);
            }
            else
            {
                yetki = "Şeyhmuz hoca yanlış yazar diye";
            }            
            re.Close();
            return yetki;
        }
    }
}
